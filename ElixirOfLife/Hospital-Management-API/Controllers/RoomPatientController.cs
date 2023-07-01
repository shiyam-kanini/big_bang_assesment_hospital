using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.RoomPatient.cs;
using Hospital_Management_API.Models_Response_;
using Hospital_Management_API.Repositories.RoomRepo;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> RequestRoom(RoomPatientRequestDTO roomRequest)
        {
            RoomPatientResponse response = await repoContext.PatientRequestRP(roomRequest);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> AuthorizeRoom(RoomPatientResponseDTO roomRequest)
        {
            RoomPatientResponse response = await repoContext.AuthorizeRoom(roomRequest);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<List<Room>> GetRoom(){
            return await repoContext.GetAllRooms();
        }
    }
}
