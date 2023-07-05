using Hospital_Management_API.Models;

namespace Hospital_Management_API.Models_Response_
{
    public class LoginResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public string? Role { get; set; }
        public LoginLog? LoginLog { get; set; }
    }
}
