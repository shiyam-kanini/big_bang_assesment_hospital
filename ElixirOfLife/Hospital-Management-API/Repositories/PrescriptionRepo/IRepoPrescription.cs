using Hospital_Management_API.Models_Dto_.PrescriptionDto;
using Hospital_Management_API.Models_Response_.PrescriptionResponses;

namespace Hospital_Management_API.Repositories.PrescriptionRepo
{
    public interface IRepoPrescription
    {
        Task<PrescriptionResponse> InitiateSession(DoctorSessionDTO sessionData);
        Task<DiagnoseResponse> DiagnoseSymptoms(DiagnoseDTO diagnoseData);
        Task<PrescriptionResponse> BuyDrugs(BuyDrugsDTO medicationDTO);
    }
}
