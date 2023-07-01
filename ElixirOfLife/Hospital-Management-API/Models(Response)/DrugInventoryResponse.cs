using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Response_
{
    public class DrugInventoryResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public List<DrugInventory>? Drugs { get; set; }

    }
}
