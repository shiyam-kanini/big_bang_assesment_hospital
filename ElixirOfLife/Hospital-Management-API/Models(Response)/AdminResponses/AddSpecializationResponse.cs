using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Response_.AdminResponses
{
    public class AddSpecializationResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public EmployeeSpecialization? EmployeeSpecialization { get; set; }
    }
}
