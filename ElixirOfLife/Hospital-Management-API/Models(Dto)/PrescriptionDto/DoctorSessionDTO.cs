using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Dto_.PrescriptionDto
{
    public class DoctorSessionDTO
    {
        public bool SessionActive { get; set; }
        public string? PrescriptionIssuer { get; set; }
        public string? Patient { get; set; }
    }
}
