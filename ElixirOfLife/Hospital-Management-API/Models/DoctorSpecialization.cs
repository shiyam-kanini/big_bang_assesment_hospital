using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class DoctorSpecialization
    {
        [Key]
        public string? DSID { get; set; }
        public Employee? Doctor { get; set; }
        public Specialization? Specialization { get; set; }
    }
}
