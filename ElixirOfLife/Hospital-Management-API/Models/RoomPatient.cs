using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class RoomPatient
    {
        [Key]
        public string? RDPID { get; set; }
        public Room? Room { get; set; }
        public Patient? Patient { get; set; }
        public bool IsActive { get; set; }
    }
}

