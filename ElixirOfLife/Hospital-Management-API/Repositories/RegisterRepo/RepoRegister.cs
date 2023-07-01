using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.AuthDTO;
using Hospital_Management_API.Models_Dto_.RegisterDTO;
using Hospital_Management_API.Models_Response_.AuthResponse;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Hospital_Management_API.Repositories.RegisterRepo
{
    public class RepoRegister : IRepoRegister
    {
        private readonly Random random = new();
        private readonly HospitalDbContext _context;
        private readonly IConfiguration Configuration;
        byte[]? passwordHash;
        byte[]? passwordSalt;

        public RepoRegister(HospitalDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public RegisterResponse registerResponse = new();
        public Employee newEmployee = new Employee();
        public Patient newPatient = new Patient();

        public async Task<RegisterResponse> RegisterEmployee(RegisterEmloyeeDTO employeeDetails)
        {
            try
            {
                CreatePasswordHash(employeeDetails.Password ?? "", out passwordHash, out passwordSalt);
                AddEmployee($"EMPID{random.Next(1000, 9999)}", employeeDetails, false);
                await _context.Employees.AddAsync(newEmployee);
                await _context.SaveChangesAsync();
                AddRegisterEmployeeResponse(true, $"Mx.{employeeDetails.EmployeeFirstName} {employeeDetails.EmployeeLastName} has been registered as Employee, LoginId : {newEmployee.EmployeeId}");
                return registerResponse;
            }
            catch (Exception ex)
            {
                AddRegisterEmployeeResponse(false, ex.Message);
                return registerResponse;
            }
        }

        public async Task<RegisterResponse> RegisterPatient(RegisterPatientDTO patientDetails)
        {
            try
            {
                CreatePasswordHash(patientDetails.Password ?? "", out passwordHash, out passwordSalt);
                AddPatient($"PID{random.Next(1000, 9999)}", patientDetails);
                await _context.Patients.AddAsync(newPatient);
                await _context.SaveChangesAsync();
                AddRegisterEmployeeResponse(true, $"Mx.{patientDetails.PatientName} has been registered as Patient, LoginId : {newPatient.PatientId} ");
                return registerResponse;
            }
            catch (Exception ex)
            {
                AddRegisterEmployeeResponse(false, ex.InnerException.ToString());
                return registerResponse;
            }
        }

        public void AddEmployee(string employeeId, RegisterEmloyeeDTO registerEmloyeeDTO, bool isactive)
        {
            newEmployee = new Employee()
            {
                EmployeeId = employeeId,
                EmployeeFirstName = registerEmloyeeDTO.EmployeeFirstName,
                EmployeeLastName = registerEmloyeeDTO.EmployeeLastName,
                EmployeeImgURL = registerEmloyeeDTO.EmployeeImgURL,
                EmployeeQualification = registerEmloyeeDTO.EmployeeQualification,
                Gender = registerEmloyeeDTO.Gender,
                isActive = isactive,
                PasswordHash = passwordHash,
                passwordKey = passwordSalt,
                Role = null,
            };
        }

        public void AddPatient(string patientId, RegisterPatientDTO registerPatientDTO)
        {
            newPatient = new Patient()
            {
                PatientId = patientId,
                PatientName = registerPatientDTO.PatientName,
                Gender = registerPatientDTO.Gender,
                passwordKey = passwordSalt,
                PasswordHash = passwordHash,
            };
        }

        public void AddRegisterEmployeeResponse(bool status, string message)
        {
            registerResponse = new RegisterResponse()
            {
                Status = status,
                Message = message,
            };
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
