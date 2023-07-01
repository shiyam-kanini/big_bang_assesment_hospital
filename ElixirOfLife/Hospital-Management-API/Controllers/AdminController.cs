using Hospital_Management_API.Models_Dto_.AdminDto;
using Hospital_Management_API.Models_Response_.AdminResponses;
using Hospital_Management_API.Repositories.AdminRepo;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class AdminController : Controller
    {
        private readonly IRepoAdmin repoContext;
        public AdminController(IRepoAdmin repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpPost]
        [Route("enableemployee")]
        public async Task<EnableEmployeeResponse> EnableEmployee(EnableEmployeeDto employee)
        {
            return await repoContext.EnableEmployee(employee);
        }
        [HttpPost]
        [Route("addemployeespecialization")]
        public async Task<AddSpecializationResponse> InsertAddSpecialization(AddSpecializationDto employeeSpecializationData)
        {
            return await repoContext.AddSpecialization(employeeSpecializationData);
        }
    }
}
