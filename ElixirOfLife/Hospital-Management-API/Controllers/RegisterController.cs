using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_.AuthResponse;
using Hospital_Management_API.Models_Dto_.AuthDTO;
using Hospital_Management_API.Models_Dto_.RegisterDTO;
using Hospital_Management_API.Repositories.RegisterRepo;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private readonly IRepoRegister repoContext;
        public RegisterController(IRepoRegister repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpPost]
        [Route("registeremployee")]
        public async Task<RegisterResponse> RegisterEmployee(RegisterEmloyeeDTO employeeDetails)
        {
            return await repoContext.RegisterEmployee(employeeDetails);
        }
        [HttpPost]
        [Route("registerpatient")]
        public async Task<RegisterResponse> RegisterPatient(RegisterPatientDTO patientDetails)
        {
            return await repoContext.RegisterPatient(patientDetails);
        }
    }
}
