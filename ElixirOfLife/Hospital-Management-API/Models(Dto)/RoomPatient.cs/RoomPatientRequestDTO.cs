using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Dto_.RoomPatient.cs
{
    public class RoomPatientRequestDTO
    {
        public string? Room { get; set; }
        public string? Patient { get; set; }
    }
}
