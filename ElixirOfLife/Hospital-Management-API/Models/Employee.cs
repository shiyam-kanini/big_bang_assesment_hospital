using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class Employee
    {
        [Key]
        public string? EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set;}
        public string? EmployeeLastName { get; set; }
        public string? EmployeeQualification { get; set; }
        public string? Gender { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? passwordKey { get; set; }
        public string? EmployeeImgURL { get; set; }
        public Role? Role { get; set; }
        public bool isActive { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }
        public ICollection<LabReport>? LabReports { get; set; }
        public ICollection<EmployeeSpecialization>? DoctorSpecializations { get; set;}


    }
}
