using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.PrescriptionDto;

namespace Hospital_Management_API.Models_Response_.PrescriptionResponses
{
    public class DiagnoseResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public List<DrugInventory>? Medication { get; set; }
    }
}
