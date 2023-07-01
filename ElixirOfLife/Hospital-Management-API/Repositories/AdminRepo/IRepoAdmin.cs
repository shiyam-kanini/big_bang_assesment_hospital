using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.AdminDto;
using Hospital_Management_API.Models_Response_.AdminResponses;
using Hospital_Management_API.Repositories.SpecializationRepo;

namespace Hospital_Management_API.Repositories.AdminRepo
{
    public interface IRepoAdmin
    {
        Task<EnableEmployeeResponse> EnableEmployee(EnableEmployeeDto enableEmployee);
        Task<AddSpecializationResponse> AddSpecialization(AddSpecializationDto addSpecialization);
    }
}
