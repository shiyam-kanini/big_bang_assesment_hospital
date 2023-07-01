using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;

namespace Hospital_Management_API.Repositories.RoleRepo
{
    public interface IRepoRole
    {
        Task<RoleResponse> GetRoles();
        Task<RoleResponse> GetRoleById(string roleId);
        Task<RoleResponse> UpdateRole(string id, RoleDTO roleData);
        Task<RoleResponse> DeleteRole(string roleId);
        Task<RoleResponse> SetRole(RoleDTO roleData);



    }
}
