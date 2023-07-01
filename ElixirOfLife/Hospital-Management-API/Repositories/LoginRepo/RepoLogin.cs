using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Hospital_Management_API.Repositories.LoginRepo
{
    public class RepoLogin : IRepoLogin
    {
        private readonly Random random = new();
        private readonly HospitalDbContext _context;
        private readonly IConfiguration Configuration;
        public RepoLogin(HospitalDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public LoginResponse loginResponse = new();
        public LoginLog loginLog = new LoginLog();
        public async Task<LoginResponse> LoginEmployee(LoginDTO loginCredentials)
        {
            try
            {
                Employee? isEmployeeExist = await _context.Employees.FindAsync(loginCredentials.LoginId ?? "");
                if (isEmployeeExist == null)
                {
                    AddLoginResPonse(false, $"Employee Id {loginCredentials.LoginId} doesn't exists", loginLog);
                    return loginResponse;
                }
                if (!VerifyPassword(loginCredentials.Password ?? "", isEmployeeExist.PasswordHash, isEmployeeExist.passwordKey))
                {
                    AddLoginResPonse(false, "Passwords dont match", loginLog); return loginResponse;
                }
                string role = _context.Employees.Where(x => x.EmployeeId.Equals(loginCredentials.LoginId)).Select(y => y.Role.RoleId).FirstOrDefaultAsync().Result ?? "";
                string token = CreateToken(loginCredentials, role);
                AddLoginLog($"SID{random.Next(1000, 9999)}", loginCredentials, token);
                await _context.LoginLogs.AddAsync(loginLog);
                await _context.SaveChangesAsync();
                AddLoginResPonse(true, $"Employee {isEmployeeExist.EmployeeId} has logged in {loginLog.SessionId}", loginLog);
                return loginResponse;
            }
            catch (Exception ex)
            {
                AddLoginResPonse(false, ex.Message, loginLog);
                return loginResponse;
            }
        }
        public async Task<LoginResponse> LoginPatient(LoginDTO loginCredentials)
        {
            try
            {
                Patient? isPatientExist = await _context.Patients.FindAsync(loginCredentials.LoginId ?? "");
                if (isPatientExist == null)
                {
                    AddLoginResPonse(false, $"Employee Id {loginCredentials.LoginId} doesn't exists", loginLog);
                    return loginResponse;
                }
                if (!VerifyPassword(loginCredentials.Password ?? "", isPatientExist.PasswordHash, isPatientExist.passwordKey))
                {
                    AddLoginResPonse(false, "Passwords dont match", loginLog); return loginResponse;
                }
                string token = CreateToken(loginCredentials, "Patient");
                AddLoginLog($"SID{random.Next(1000, 9999)}", loginCredentials, token);
                await _context.LoginLogs.AddAsync(loginLog);
                await _context.SaveChangesAsync();
                AddLoginResPonse(true, $"Patient {isPatientExist.PatientId} has logged in on a session {loginLog.SessionId}", loginLog);
                return loginResponse;
            }
            catch (Exception ex)
            {
                AddLoginResPonse(false, ex.Message, loginLog);
                return loginResponse;
            }
        }
        public async Task<LoginResponse> Logout(string SessionId)
        {
            try
            {
                loginLog = await _context.LoginLogs.FindAsync(SessionId);
                if (loginLog == null)
                {
                    AddLoginResPonse(false, $"Session Not Found", loginLog);
                    return loginResponse;
                }
                if (!loginLog.IsLoggedIn)
                {
                    AddLoginResPonse(false, $"Session already logged out", null);
                    return loginResponse;
                }
                loginLog.IsLoggedIn = false;
                _context.LoginLogs.Update(loginLog);
                await _context.SaveChangesAsync();
                AddLoginResPonse(true, $"Session {SessionId} Logged out", loginLog);
                return loginResponse;
            }
            catch (Exception ex)
            {
                AddLoginResPonse(false, ex.Message, loginLog);
                return loginResponse;
            }
        }
        public void AddLoginLog(string sId, LoginDTO loginCredentials, string token)
        {
            loginLog = new LoginLog()
            {
                SessionId = sId,
                LoginId = loginCredentials.LoginId,
                Token = token,
                IsLoggedIn = true,
            };
        }
        public void AddLoginResPonse(bool status, string Message, LoginLog loginLog)
        {
            loginResponse = new LoginResponse()
            {
                Status = status,
                Message = Message,
                LoginLog = loginLog
            };
        }
        public bool VerifyPassword(string password, byte[]? storedHash, byte[]? storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public string CreateToken(LoginDTO loginCredentials, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginCredentials.LoginId ?? ""),
                new Claim(ClaimTypes.Role, role)
            };
            string secretKey = Configuration["JWT:Key"] ?? "";
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:ValidIssuer"],
                audience: Configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
