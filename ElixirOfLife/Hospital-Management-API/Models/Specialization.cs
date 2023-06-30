using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class Specialization
    {
        [Key]
        public string? SpecializationId { get; set; }
        public string? SpecializationName { get; set; }
        public string? SpecializationDescription { get; set; }
        public Role? Role { get; set; }
        public ICollection<Specialization>? Specializations { get;}
    }
}
