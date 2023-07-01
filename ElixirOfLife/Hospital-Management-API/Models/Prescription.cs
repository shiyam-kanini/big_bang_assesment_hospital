using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class Prescription
    {
        [Key]
        public string? PrescriptionId { get; set; }
        public bool SessionActive { get; set; }
        public Employee? PrescriptionIssuer { get; set; }
        public Patient? Patient { get; set; }
        public string? Medication { get; set; }
        public int MedicationPrice { get; set; }
        public bool Bought { get; set; }
    }
}
