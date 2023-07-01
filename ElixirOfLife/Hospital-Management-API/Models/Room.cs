using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class Room
    {
        [Key]
        public string? RoomId { get; set; }
        public string? RoomType { get; set; }
        public string? RoomDescription { get; set; }
        public string? RoomCount { get; set; }
        public string? IsAvailable { get; set; }
        public Employee? DefaultDoctor { get; set; }
        public int Price { get; set; }
        public ICollection<RoleRoom>? RolesRooms { get; set; }
        public ICollection<RoomPatient>? Patients { get; set; }
        

    }
}
