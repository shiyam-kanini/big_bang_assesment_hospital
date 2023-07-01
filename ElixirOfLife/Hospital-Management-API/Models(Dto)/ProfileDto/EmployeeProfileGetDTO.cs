using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Dto_.ProfileDto
{
    public class EmployeeProfileGetDTO
    {
        public string? SessionId { get; set; }
        public string? EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }
        public string? EmployeeQualification { get; set; }
        public string? Gender { get; set; }
        public string? EmployeeImgURL { get; set; }
        public string? Role { get; set; }
        public List<string>? Specializations { get; set; }
    }
}
