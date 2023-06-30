using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class Prescription
    {
        [Key]
        public string? PrescriptionId { get; set; }
        public Employee? PrescriptionIssuer { get; set; }
        public Patient? Patient { get; set; }
        public string? DiagnosedWith { get; set; }
        public string? Medication { get; set; }
        public int MedicationPrice { get; set; }
    }
}
