using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;

namespace Hospital_Management_API.Repositories.SpecializationRepo
{
    public interface IRepoSpecialization
    {
        Task<SpecializationResponse> GetSpecializations();
        Task<SpecializationResponse> UpdateSpecialization(string id, SpecializationDTO specializationData);
        Task<SpecializationResponse> DeleteSpecialization(string speciaalizationId);
        Task<SpecializationResponse> GetSpecializationById(string id);
        Task<SpecializationResponse> InsertSpecialization(SpecializationDTO specializationData);
    }
}
