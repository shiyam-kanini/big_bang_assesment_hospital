using Hospital_Management_API.Models_Dto_.AuthDTO;
using Hospital_Management_API.Models_Dto_.RegisterDTO;
using Hospital_Management_API.Models_Response_.AuthResponse;

namespace Hospital_Management_API.Repositories.RegisterRepo
{
    public interface IRepoRegister
    {
        Task<RegisterResponse> RegisterEmployee(RegisterEmloyeeDTO employeeDetails);
        Task<RegisterResponse> RegisterPatient(RegisterPatientDTO patientDetails);
    }
}
