using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class Role
    {
        [Key]
        public string? RoleId { get; set; }
        public string? Roleame { get; set; }
        public string? RoleDescription{ get; set;}
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Role>? Roles { get;set; }
    }
}
