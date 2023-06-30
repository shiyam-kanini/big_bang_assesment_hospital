using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class SymptomsDrugs
    {
        [Key]
        public string? SDID { get; set; }
        public HealthSymptoms? Symptoms { get; set; }
        public DrugInventory? Drug { get; set; }
    }
}
