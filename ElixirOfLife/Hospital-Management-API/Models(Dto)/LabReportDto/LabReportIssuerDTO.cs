using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Dto_.LabReportDto
{
    public class LabReportIssuerDTO
    {
        public string? Issuer { get; set; }
        public string? ReportId { get; set; }
        public string? DiagnosedImgURL { get; set; }
        public string? Description { get; set; }
    }
}
