using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Dto_.LabReportDto;
using Hospital_Management_API.Models_Response_.LabReportResponses;

namespace Hospital_Management_API.Repositories.LabReportRepo
{
    public interface IRepoLabReport
    {
        Task<LabReportPatientResponse> LabReportPatient(LabReportPatientDTO labReport);
        Task<LabReportIssuerResponse> LabReportIssuer(LabReportIssuerDTO labReport);
    }
}
