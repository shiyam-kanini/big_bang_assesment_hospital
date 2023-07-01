using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Response_
{
    public class RoleResponse
    {
        public bool status { get; set; }
        public string? Message { get; set; }
        public List<Role>? Roles { get; set; }
    }
}
