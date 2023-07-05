using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Dto_.LabReportDto;
using Hospital_Management_API.Models_Response_.LabReportResponses;
using Hospital_Management_API.Repositories.LabReportRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        [Route("requestlabreport")]
        [Authorize(Roles = "Patient")]
        public async Task<LabReportPatientResponse> RequestLabReport(LabReportPatientDTO labReport)
        {
            return await repoContext.LabReportPatient(labReport);
        }
        [HttpPut]
        [Route("providelabreport")]
        [Authorize(Roles = "ROLEID003")]
        public async Task<LabReportIssuerResponse> GenerateLabReport(LabReportIssuerDTO labReport)
        {
            return await repoContext.LabReportIssuer(labReport);
        }
        [HttpGet]
        [Route("getlabreports")]
        [Authorize(Roles = "ROLEID003")]
        public async Task<List<LabReport>> GetLabReports()
        {
            return await repoContext.GetLabReports();
        }
        [HttpGet]
        [Route("getlabreportsbypatients")]
        [Authorize(Roles = "Patient")]
        public async Task<List<LabReport>> GetLabReportsByPatients(string patientId)
        {
            return await repoContext.GetLabReportsByPatients(patientId);
        }
    }
}
