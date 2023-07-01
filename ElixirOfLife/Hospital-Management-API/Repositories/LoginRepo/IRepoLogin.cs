using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;

namespace Hospital_Management_API.Repositories.LoginRepo
{
    public interface IRepoLogin
    {
        Task<LoginResponse> LoginEmployee(LoginDTO loginCredentials);
        Task<LoginResponse> LoginPatient(LoginDTO loginCredentials);
        Task<LoginResponse> Logout(string sessionId);
    }
}
