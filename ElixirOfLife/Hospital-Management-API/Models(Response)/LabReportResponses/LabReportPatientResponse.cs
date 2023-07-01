using Hospital_Management_API.Models_Dto_;

namespace Hospital_Management_API.Models_Response_.LabReportResponses
{
    public class LabReportPatientResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public LabReportPatientDTO? labReport { get; set; }
    }
}
