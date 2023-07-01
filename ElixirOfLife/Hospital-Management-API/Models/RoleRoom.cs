using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class RoleRoom
    {
        [Key]
        public string? RRID { get; set; }
        public Role? Role { get; set; }
        public Room? Room { get; set; }
    }
}
