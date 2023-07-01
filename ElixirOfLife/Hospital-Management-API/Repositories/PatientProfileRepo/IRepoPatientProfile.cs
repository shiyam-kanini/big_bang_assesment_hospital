using Hospital_Management_API.Models_Dto_.ProfileDto;
using Hospital_Management_API.Models_Response_.ProfileResponses;

namespace Hospital_Management_API.Repositories.PatientProfileRepo
{
    public interface IRepoPatientProfile
    {
        Task<PatientProfileResponse> GetPatientProfile(string sessionId);
    }
}
