using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;

namespace Hospital_Management_API.Repositories.DrugInventoryRepo
{
    public interface IRepoDrugInventory
    {
        Task<DrugInventoryResponse> GetDrugs();

        Task<DrugInventoryResponse> GetDrugById(string id);
        Task<DrugInventoryResponse> PutDrug(string id, DrugInventoryDTO drugData);
        Task<DrugInventoryResponse> DeleteDrug(string id);
        Task<DrugInventoryResponse> PostDrug(DrugInventoryDTO drugData);
    }
}
