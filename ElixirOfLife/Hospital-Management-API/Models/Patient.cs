using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class Patient
    {
        [Key]
        public string? PatientId { get; set; }
        public string? PatientName { get;set; }
        public string? Gender { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? passwordKey { get; set; } 
        public int Bill { get; set; }
        public ICollection<LabReport>? LabReport { get; set; }
        public ICollection<PatientBill>? PatientBill { get; set;}
        public ICollection<Prescription>? Prescriptions { get; set; }

    }
}
