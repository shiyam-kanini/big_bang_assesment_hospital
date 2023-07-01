using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_API.Repositories.RoleRepo
{
    public class RepoRole : IRepoRole
    {
        private readonly Random random = new();
        private readonly HospitalDbContext _context;
        public RepoRole(HospitalDbContext context)
        {
            _context = context;
        }
        List<Role> roles = new();
        Role? newRole = new();
        RoleResponse roleResponse = new();
        public async Task<RoleResponse> DeleteRole(string id)
        {
            try
            {
                newRole = await _context.Roles.FindAsync(id != null ? id : "");
                if (newRole == null)
                {
                    AddResponse(false, "No Room Found", roles);
                    return roleResponse;
                }
                await _context.Roles.Where(x => (x.RoleId != null ? x.RoleId : "").Equals(id)).ExecuteDeleteAsync();
                await _context.SaveChangesAsync();
                roles.Add(newRole);
                AddResponse(true, "1 Role Deleted", roles);
                return roleResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, roles);
                return roleResponse;
            }
        }

        public async Task<RoleResponse> GetRoleById(string id)
        {
            try
            {
                roles = await _context.Roles.Where(x => (x.RoleId ?? "").Equals(id)).ToListAsync();
                if (roles.Count <= 0)
                {
                    AddResponse(false, "No Data Found", roles);
                    return roleResponse;
                }
                AddResponse(true, $"{roles.Count} records Found", roles);
                return roleResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, roles);
                return roleResponse;
            }
        }

        public async Task<RoleResponse> GetRoles()
        {
            try
            {
                roles = await _context.Roles.ToListAsync();
                if (roles.Count <= 0)
                {
                    AddResponse(false, "No Data Found", roles);
                    return roleResponse;
                }
                AddResponse(true, $"{roles.Count} Records Found", roles);
                return roleResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, roles);
                return roleResponse;
            }
        }

        public async Task<RoleResponse> SetRole(RoleDTO role)
        {
            try
            {
                newRole = await _context.Roles.Where(x => (x.Roleame ?? "").Equals(role.RoleName)).FirstOrDefaultAsync();
                if (newRole != null)
                {
                    roles.Add(newRole);
                    AddResponse(false, "Role Already exists", roles);
                    return roleResponse;
                }
                AddRole($"RID{random.Next(0, 9)}{random.Next(0, 9)}{random.Next(0, 9)}", role);
                roles.Add(newRole);
                await _context.Roles.AddAsync(newRole);
                await _context.SaveChangesAsync();
                AddResponse(true, $"1 Record Added ({role.RoleName})", roles);
                return roleResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, roles);
                return roleResponse;
            }
        }

        public async Task<RoleResponse> UpdateRole(string id, RoleDTO role)
        {
            try
            {
                newRole = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
                if (newRole == null)
                {
                    AddResponse(true, "Role doesn't exist", roles);
                    return roleResponse;
                }
                _context.Entry(newRole).State = EntityState.Detached;
                AddRole(id, role);
                _context.Entry(newRole).State = EntityState.Modified;
                _context.Roles.Update(newRole);
                await _context.SaveChangesAsync(); 
                roles.Add(newRole);
                AddResponse(true, "1 Record Updated", roles);
                return roleResponse;
            }
            catch (Exception ex)
            {
                AddResponse(false, ex.Message, roles);
                return roleResponse;
            }
        }
        public void AddResponse(bool success, string message, List<Role> role)
        {
            roleResponse = new()
            {
                status = success,
                Message = message,
                Roles = role,
            };
        }
        public void AddRole(string roleId, RoleDTO role)
        {
            newRole = new()
            {
                RoleId = roleId,
                Roleame = role.RoleName,
                RoleDescription = role.RoleDescription,
            };
        }
    }
}
