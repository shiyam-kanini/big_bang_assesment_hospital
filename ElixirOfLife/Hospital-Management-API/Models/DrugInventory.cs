using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class DrugInventory
    {
        [Key]
        public string? DrugId { get; set; }
        public string? DrugType { get; set; }
        public string? DrugName { get;set; }
        public string? DrugDescription { get;set; }
        public string? DrugImgURL { get; set; }
        public int DrugPrice { get; set; }
        public ICollection<SymptomsDrugs>? SymptomsDrugs { get; set;}
    }
}
