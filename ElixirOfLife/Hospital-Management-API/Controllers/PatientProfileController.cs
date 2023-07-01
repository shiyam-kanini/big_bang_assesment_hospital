using Hospital_Management_API.Models_Response_.ProfileResponses;
using Hospital_Management_API.Repositories.PatientProfileRepo;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class PatientProfileController : ControllerBase
    {
        private readonly IRepoPatientProfile repoContext;
        public PatientProfileController(IRepoPatientProfile repoContext)
        {
                this.repoContext = repoContext;
        }
        [HttpGet]
        public async Task<PatientProfileResponse> GetPatientProfile(string sessionId)
        {
            return await repoContext.GetPatientProfile(sessionId);
        } 
    }
}
