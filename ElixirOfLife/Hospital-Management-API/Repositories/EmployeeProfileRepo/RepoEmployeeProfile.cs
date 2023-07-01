using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.ProfileDto;
using Hospital_Management_API.Models_Response_.ProfileResponses;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_API.Repositories.ProfileRepo
{
    public class RepoEmployeeProfile : IRepoEmployeeProfile
    {
        private readonly HospitalDbContext _context;
        public RepoEmployeeProfile(HospitalDbContext context)
        {
            _context = context;
        }
        EmployeeProfileResponse employeProfileResponse = new EmployeeProfileResponse();
        EmployeeProfileGetDTO employeeProfileGetDTO = new EmployeeProfileGetDTO();
        EmployeeProfileUpdateDTO employeeProfileUpdateDTO = new EmployeeProfileUpdateDTO(); 
        Employee? employeeUpdated= new Employee();
        LoginLog? isLoggedIn = new LoginLog();
        public async Task<EmployeeProfileResponse> GetEmployeeProfile(string sessionId)
        {
            try
            {
                isLoggedIn = await _context.LoginLogs.FindAsync(sessionId);
                if(isLoggedIn == null)
                {
                    AddGetEmployeeProfileResponse(false, $"Session {sessionId} not found", employeeProfileGetDTO);
                    return employeProfileResponse;
                }
                if (!isLoggedIn.IsLoggedIn)
                {
                    AddGetEmployeeProfileResponse(false, $"Session {sessionId} Expired", employeeProfileGetDTO);
                    return employeProfileResponse;
                }
                Employee isEmployeeExists = await _context.Employees.Include(y => y.Role).Where(x => x.EmployeeId.Equals(isLoggedIn.LoginId)).Select(y => new Employee(){EmployeeId = y.EmployeeId, EmployeeFirstName =  y.EmployeeFirstName, EmployeeLastName = y.EmployeeLastName, EmployeeImgURL = y.EmployeeImgURL, EmployeeQualification = y.EmployeeQualification, Role = y.Role, Gender = y.Gender}).FirstOrDefaultAsync();
                List<string> specialization = await _context.EmployeeSpecialization.Where(x => x.Doctor.EmployeeId.Equals(isEmployeeExists.EmployeeId)).Select(y => y.Specialization.SpecializationName).ToListAsync();
                AddGetEmployeeProfile(isEmployeeExists, isLoggedIn, specialization);
                AddGetEmployeeProfileResponse(true, $"Welcome {isEmployeeExists.EmployeeFirstName} {isEmployeeExists.EmployeeLastName}", employeeProfileGetDTO);
                return employeProfileResponse;
            }
            catch(Exception ex) 
            {
                AddGetEmployeeProfileResponse(false, ex.Message, employeeProfileGetDTO);
                return employeProfileResponse;
            }
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.Include(x => x.Role).ToListAsync();
        }
        public void AddGetEmployeeProfileResponse(bool status, string message, EmployeeProfileGetDTO employeeGet)
        {
            employeProfileResponse = new EmployeeProfileResponse()
            {
                Status = status, 
                Message = message,
                EmployeeProfile = employeeGet
            };
        }
        public void AddUpdateEmployeeProfileResponse(bool status, string message, EmployeeProfileUpdateDTO employeeUpdate)
        {
            employeProfileResponse = new EmployeeProfileResponse()
            {
                Status = status,
                Message = message,
                EmployeeProfileUpdate= employeeUpdate
            };
        }
        public void AddGetEmployeeProfile(Employee employee, LoginLog log, List<string> specialization)
        {
            employeeProfileGetDTO = new EmployeeProfileGetDTO()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeFirstName = employee.EmployeeLastName,
                EmployeeLastName = employee.EmployeeLastName,
                EmployeeImgURL= employee.EmployeeImgURL,
                EmployeeQualification = employee.EmployeeQualification,
                Gender = employee.Gender,
                SessionId = log.SessionId,
                Role = employee.Role.Roleame,
                Specializations = specialization,
            };
        }
        public void UpdateEmployeeProfile(Employee employee, EmployeeProfileUpdateDTO eu)
        {
            employeeUpdated = new Employee()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeFirstName= eu.EmployeeFirstName,
                EmployeeLastName= eu.EmployeeLastName,
                EmployeeImgURL = eu.EmployeeImgURL,
                EmployeeQualification= eu.EmployeeQualification,
                Gender = eu.Gender,
                Role = employee.Role,
                isActive = employee.isActive,
                PasswordHash = employee.PasswordHash,
                passwordKey = employee.passwordKey,

            };
        }

        public Task<EmployeeProfileResponse> UpdateEmployeeProfile(string id, EmployeeProfileUpdateDTO employeeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
