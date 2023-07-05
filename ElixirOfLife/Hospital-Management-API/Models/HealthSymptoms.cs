using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class HealthSymptoms
    {
        [Key]
        public string? SymptomId { get; set; }
        public string? SymptomName { get;set; }
        public string? SymptomDescription { get; set; }
    }
}
