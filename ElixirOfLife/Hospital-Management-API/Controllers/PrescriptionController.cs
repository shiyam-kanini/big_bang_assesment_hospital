using Hospital_Management_API.Models;
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
        [Route("requestdoctorsession")]
        [Authorize(Roles = "Patient")]
        public async Task<PrescriptionResponse> StartSession(DoctorSessionDTO sessionData)
        {
            return await repoContext.InitiateSession(sessionData);
        }
        [HttpPut]
        [Route("diagnosesymptoms")]
        [Authorize(Roles = "Patient")]
        public async Task<DiagnoseResponse> DiagnoseSymptoms(DiagnoseDTO diagnoseData)
        {
            return await repoContext.DiagnoseSymptoms(diagnoseData);
        }
        [HttpPut]
        [Route("buydrugs")]
        [Authorize(Roles = "Patient")]
        public async Task<PrescriptionResponse> BuyDrugs(BuyDrugsDTO medicationDTO)
        {
            return await repoContext.BuyDrugs(medicationDTO);
        }
        [HttpGet]
        [Route("getallprescription")]
        [Authorize(Roles = "ROLEID002")]
        public async Task<List<Prescription>> GetAllPrescription()
        {
            return await repoContext.GetAllPrescriptions();
        }
        [HttpGet]
        [Route("getalldoctors")]
        [Authorize(Roles = "Patient")]
        public async Task<List<Employee>> GetDoctors()
        {
            return await repoContext.GetDoctors();
        }
        [HttpGet]
        [Route("getprescriptionbyid")]
        [Authorize(Roles = "Patient")]
        public async Task<Prescription> GetPrescriptionById(string id)
        {
            return await repoContext.GetPrescriptionById(id);
        }
        [HttpGet]
        [Route("getprescriptionbydoctor")]
        [Authorize(Roles ="ROLEID002")]
        public async Task<List<Prescription>> GetPrescriptionByDoctor(string doctorId)
        {
            return await repoContext.GetPrescriptionByDoctor(doctorId);
        }

    }
}
