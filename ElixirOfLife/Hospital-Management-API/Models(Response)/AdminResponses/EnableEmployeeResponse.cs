using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Response_.AdminResponses
{
    public class EnableEmployeeResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public Employee? UpdatedEmployee { get; set; }
    }
}
