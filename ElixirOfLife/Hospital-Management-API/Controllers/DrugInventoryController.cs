using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Hospital_Management_API.Repositories.DrugInventoryRepo;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class DrugInventoryController : ControllerBase
    {
        private readonly IRepoDrugInventory repoContext;
        public DrugInventoryController(IRepoDrugInventory repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpGet]
        public async Task<DrugInventoryResponse> GetDrugs()
        {
            return await repoContext.GetDrugs();
        }
        [HttpGet]
        [Route("getdrugbyid")]
        public async Task<DrugInventoryResponse> GetDrugById(string id)
        {
            return await repoContext.GetDrugById(id);
        }
        [HttpPost]
        public async Task<DrugInventoryResponse> InsertDrug(DrugInventoryDTO drugData)
        {
            return await repoContext.PostDrug(drugData);
        }
        [HttpPut]
        public async Task<DrugInventoryResponse> PutDrug(string id,DrugInventoryDTO drugData)
        {
            return await repoContext.PutDrug(id, drugData);
        }
        [HttpDelete]
        public async Task<DrugInventoryResponse> DeleteDrug(string id)
        {
            return await repoContext.DeleteDrug(id);
        }
    }
}
