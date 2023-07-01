using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.RoomPatient.cs;
using Hospital_Management_API.Models_Response_;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_API.Repositories.RoomRepo
{
    public interface IRepoRoomPatient
    {
        Task<RoomPatientResponse> AuthorizeRoom(RoomPatientResponseDTO roomRequest);
        Task<RoomPatientResponse> PatientRequestRP(RoomPatientRequestDTO roomRequest);
        Task<List<Room>> GetAllRooms();
    }
}
