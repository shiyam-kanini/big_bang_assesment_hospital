using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.ProfileDto;

namespace Hospital_Management_API.Models_Response_.ProfileResponses
{
    public class PatientProfileResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public PatientProfileGetDTO PatientProfile { get; set; }
    }
}
