using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Hospital_Management_API.Repositories.SpecializationRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    [Authorize(Roles = "ROLEID001")]
    public class SpecializationController : Controller
    {
        private readonly IRepoSpecialization repoContext;
        public SpecializationController(IRepoSpecialization repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpGet]
        [Route("getallspecializations")]
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
        [Route("postspecialization")]
        public async Task<SpecializationResponse> InsertSpecialization(SpecializationDTO specializationData)
        {
            return await repoContext.InsertSpecialization(specializationData);
        }
        [HttpPut]
        [Route("putspecialization")]
        public async Task<SpecializationResponse> UpdataeSpecialization(string id, SpecializationDTO specializationData)
        {
            return await repoContext.UpdateSpecialization(id, specializationData);
        }
        [HttpDelete]
        [Route("deletespecialization")]
        public async Task<SpecializationResponse> DeleteSpecialization(string id)
        {
            return await repoContext.DeleteSpecialization(id);
        }
    }
}
