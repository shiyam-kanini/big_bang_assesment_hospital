using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.ProfileDto;
using Hospital_Management_API.Models_Response_.ProfileResponses;
using Hospital_Management_API.Repositories.ProfileRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class EmployeeProfileController : ControllerBase
    {
        private readonly IRepoEmployeeProfile repoContext;
        public EmployeeProfileController(IRepoEmployeeProfile repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpGet]
        [Route("getemployeeprofile")]
        public async Task<EmployeeProfileResponse> GetEmployeeProfile(string id)
        {
            return await repoContext.GetEmployeeProfile(id);
        }
        [HttpGet]
        [Route("getallemployees")]
        [Authorize(Roles ="ROLEID001")]
        public async Task<List<Employee>> GetAll()
        {
            return await repoContext.GetAllEmployees();
        }
    }
}
