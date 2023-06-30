using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class PatientBill
    {
        [Key]
        public string? BillId { get; set; }
        public Patient? Patient { get; set; }
        public int BillPrice { get; set; }
    }
}
