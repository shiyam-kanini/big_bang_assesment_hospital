using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Dto_.RoomPatient.cs
{
    public class RoomPatientResponseDTO
    {
        public string? RDPID { get; set; }
        public bool isActive { get; set; }
    }
}
