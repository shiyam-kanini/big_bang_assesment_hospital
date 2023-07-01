using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.ProfileDto;
using Hospital_Management_API.Models_Response_.ProfileResponses;

namespace Hospital_Management_API.Repositories.ProfileRepo
{
    public interface IRepoEmployeeProfile
    {
        Task<EmployeeProfileResponse> GetEmployeeProfile(string id);
        Task<EmployeeProfileResponse> UpdateEmployeeProfile(string id, EmployeeProfileUpdateDTO employeeUpdate);
        Task<List<Employee>> GetAllEmployees();


    }
}
