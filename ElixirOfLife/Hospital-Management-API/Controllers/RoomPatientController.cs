using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.RoomPatient.cs;
using Hospital_Management_API.Models_Response_;
using Hospital_Management_API.Repositories.RoomRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;

namespace Hospital_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]/actions")]
    public class RoomPatientController : ControllerBase
    {
        private readonly IRepoRoomPatient repoContext;
        public RoomPatientController(IRepoRoomPatient repoContext)
        {
            this.repoContext = repoContext;
        }
        [HttpPost]
        [Route("requestroom")]
        [Authorize(Roles = "Patient")]
        public async Task<RoomPatientResponse> RequestRoom(RoomPatientRequestDTO roomRequest)
        {
            return await repoContext.PatientRequestRP(roomRequest);
        }
        [HttpPut]
        [Route("provideroom")]
        [Authorize(Roles = "ROLEID001")]
        public async Task<RoomPatientResponse> AuthorizeRoom(RoomPatientResponseDTO roomRequest)
        {
           return await repoContext.AuthorizeRoom(roomRequest);
        }
        [HttpGet]
        [Route("getallrooms")]
        [AllowAnonymous]

        public async Task<List<Room>> GetRoom(){
            return await repoContext.GetAllRooms();
        }
        [HttpGet]
        [Route("getallroompatients")]
        [Authorize(Roles = "ROLEID001")]
        public async Task<List<RoomPatient>> GetAllRoomPatient()
        {
            return await repoContext.GetAllRoomPatient();
        }
    }
}
