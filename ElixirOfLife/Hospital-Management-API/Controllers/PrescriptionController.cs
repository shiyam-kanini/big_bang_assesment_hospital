using Hospital_Management_API.Models_Dto_.PrescriptionDto;
using Hospital_Management_API.Models_Response_.PrescriptionResponses;
using Hospital_Management_API.Repositories.PrescriptionRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IRepoPrescription repoContext;
        public PrescriptionController(IRepoPrescription repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpPost]
        public async Task<IActionResult> StartSession(DoctorSessionDTO sessionData)
        {
            PrescriptionResponse response = await repoContext.InitiateSession(sessionData);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPut]
        [Route("diagnosesymptoms")]
        public async Task<IActionResult> DiagnoseSymptoms(DiagnoseDTO diagnoseData)
        {
            DiagnoseResponse response = await repoContext.DiagnoseSymptoms(diagnoseData);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPut]
        [Route("buydrugs")]
        public async Task<IActionResult> BuyDrugs(BuyDrugsDTO medicationDTO)
        {
            PrescriptionResponse response = await repoContext.BuyDrugs(medicationDTO);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
