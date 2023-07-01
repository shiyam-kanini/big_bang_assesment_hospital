using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Hospital_Management_API.Repositories.SpecializationRepo;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class SpecializationController : Controller
    {
        private readonly IRepoSpecialization repoContext;
        public SpecializationController(IRepoSpecialization repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpGet]
        public async Task<SpecializationResponse> GetSpecializations()
        {
            return await repoContext.GetSpecializations();
        }
        [HttpGet]
        [Route("getspecializationbyid")]
        public async Task<SpecializationResponse> GetSpecializationById(string id)
        {
            return await repoContext.GetSpecializationById(id);
        }
        [HttpPost]
        public async Task<SpecializationResponse> InsertSpecialization(SpecializationDTO specializationData)
        {
            return await repoContext.InsertSpecialization(specializationData);
        }
        [HttpPut]
        public async Task<SpecializationResponse> UpdataeSpecialization(string id, SpecializationDTO specializationData)
        {
            return await repoContext.UpdateSpecialization(id, specializationData);
        }
        [HttpDelete]
        public async Task<SpecializationResponse> DeleteSpecialization(string id)
        {
            return await repoContext.DeleteSpecialization(id);
        }
    }
}
