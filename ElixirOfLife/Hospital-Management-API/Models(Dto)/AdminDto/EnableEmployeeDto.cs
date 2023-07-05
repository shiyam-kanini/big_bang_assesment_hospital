using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Dto_.AdminDto
{
    public class EnableEmployeeDto
    {
        public string? EmployeeId { get; set; }
        public string? Role { get; set; }
        public bool SetActive { get; set; }
    }
}
