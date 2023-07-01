using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class LabReport
    {
        [Key]
        public string? LabReportId { get; set; }
        public Patient? Patient { get; set; }
        public Employee? Issuer { get; set; }
        public string? DiagnosedImgURL { get; set; }
        public string? Description { get; set; }
        public bool Issued { get; set; }
    }
}
