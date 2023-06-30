using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_API.Models
{
    public class LoginLog
    {
        [Key]
        public string? SessionId { get; set; }
        public string? LoginId { get; set; }
        public string? Token { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
