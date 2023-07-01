using Hospital_Management_API.Models_Dto_.LabReportDto;

namespace Hospital_Management_API.Models_Response_.LabReportResponses
{
    public class LabReportIssuerResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public LabReportIssuerDTO? labReport { get; set; }
    }
}
