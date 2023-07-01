using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Hospital_Management_API.Repositories.LoginRepo;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class LoginController : ControllerBase
    {
        private readonly IRepoLogin repoContext;
        public LoginController(IRepoLogin repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpPost]
        [Route("employeelogin")]
        public async Task<LoginResponse> LoginEmployee(LoginDTO loginCredentials)
        {
            return await repoContext.LoginEmployee(loginCredentials);
        }
        [HttpPost]
        [Route("patientlogin")]
        public async Task<LoginResponse> LoginPatient(LoginDTO loginCredentials)
        {
            return await repoContext.LoginPatient(loginCredentials);
        }
        [HttpGet]
        [Route("logout")]
        public async Task<LoginResponse> Logout(string sessionId)
        {
            return await repoContext.Logout(sessionId);
        }
    }
}
