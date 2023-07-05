using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.PrescriptionDto;
using Hospital_Management_API.Models_Response_.PrescriptionResponses;

namespace Hospital_Management_API.Repositories.PrescriptionRepo
{
    public interface IRepoPrescription
    {
        Task<PrescriptionResponse> InitiateSession(DoctorSessionDTO sessionData);
        Task<DiagnoseResponse> DiagnoseSymptoms(DiagnoseDTO diagnoseData);
        Task<PrescriptionResponse> BuyDrugs(BuyDrugsDTO medicationDTO);
        Task<List<Prescription>> GetAllPrescriptions();
        Task<List<Employee>> GetDoctors();
        Task<Prescription> GetPrescriptionById(string id);
        Task<List<Prescription>> GetPrescriptionByDoctor(string doctorId);
        Task<Prescription> GetPrescriptionByPatient(string prescriptionId);
    }
}
