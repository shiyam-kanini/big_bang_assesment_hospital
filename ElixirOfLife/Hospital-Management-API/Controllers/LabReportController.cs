using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Dto_.LabReportDto;
using Hospital_Management_API.Models_Response_.LabReportResponses;
using Hospital_Management_API.Repositories.LabReportRepo;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class LabReportController : ControllerBase
    {
        private readonly IRepoLabReport repoContext;
        public LabReportController(IRepoLabReport repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpPost]
        public async Task<IActionResult> RequestLabReport(LabReportPatientDTO labReport)
        {
            LabReportPatientResponse result = await repoContext.LabReportPatient(labReport);
            if (!result.Status)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<LabReportIssuerResponse> GenerateLabReport(LabReportIssuerDTO labReport)
        {
            return await repoContext.LabReportIssuer(labReport);
        }
    }
}
