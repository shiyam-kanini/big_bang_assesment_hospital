﻿using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Response_;
using Hospital_Management_API.Repositories.RoleRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    [Authorize(Roles = "ROLEID001")]
    public class RoleController : ControllerBase
    {
        private readonly IRepoRole repoContext;
        public RoleController(IRepoRole repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpGet]
        [Route("getroles")]
        public async Task<RoleResponse> GetRoles()
        {
            return await repoContext.GetRoles();
        }
        [HttpGet]
        [Route("getrolebyid")]
        public async Task<RoleResponse> GetRoleById(string id)
        {
            return await repoContext.GetRoleById(id);
        }
        [HttpPost]
        [Route("postrole")]
        public async Task<RoleResponse> PostRole(RoleDTO roleData)
        {
            return await repoContext.SetRole(roleData);
        }
        [HttpPut]
        [Route("putrole")]
        public async Task<RoleResponse> PutRole(string id, RoleDTO roleData)
        {
            return await repoContext.UpdateRole(id, roleData);
        }
        [HttpDelete]
        [Route("deleterole")]
        public async Task<RoleResponse> DeleteRole(string id)
        {
            return await repoContext.DeleteRole(id);
        }
    }
}
