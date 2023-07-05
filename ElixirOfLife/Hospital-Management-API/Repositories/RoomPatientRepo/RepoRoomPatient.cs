using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.RoomPatient.cs;
using Hospital_Management_API.Models_Response_;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace Hospital_Management_API.Repositories.RoomRepo
{
    public class RepoRoomPatient : IRepoRoomPatient
    {
        private readonly HospitalDbContext _context;
        private readonly Random random= new Random();
        public RepoRoomPatient(HospitalDbContext context)
        {
            _context = context;
        }
        public RoomPatientResponse response = new RoomPatientResponse();
        public RoomPatient roomPatient = new RoomPatient();
        public async Task<RoomPatientResponse> PatientRequestRP(RoomPatientRequestDTO roomRequest)
        {
            try
            {
                Room isRoom = await _context.Rooms.FindAsync(roomRequest.Room);
                if(isRoom == null)
                {
                    AddRoomPatientResponse(false, $"No Room Found with id : {roomRequest.Room}", roomRequest);return response;
                }
                Patient isPatient = await _context.Patients.FindAsync(roomRequest.Patient);
                if (isPatient == null)
                {
                    AddRoomPatientResponse(false, $"No Patient Found with id : {roomRequest.Patient}", roomRequest); return response;
                }
                RoomPatient isRequest = await _context.RoomsPatients
                .Where(x => x.Patient.PatientId == roomRequest.Patient && x.Room.RoomId == roomRequest.Room)
                .Select(x => new RoomPatient
                {
                    Room = x.Room,
                    Patient= x.Patient,
                    RDPID = x.RDPID,
                    IsActive= x.IsActive,
                })
                .FirstOrDefaultAsync();
                if(isRequest != null)
                {
                    AddRoomPatientResponse(false, isRequest.IsActive ? $"Room is active under id : {isRequest.RDPID}" : $"Room request is already pending under id : {isRequest.RDPID}", roomRequest); return response;
                }
                AddRoom($"RPID{random.Next(1000, 9999)}", isPatient, isRoom);
                await _context.RoomsPatients.AddAsync(roomPatient);
                await _context.SaveChangesAsync();
                AddRoomPatientResponse(true, "Patient request has been sent to admin", roomRequest);
                return response;
            }
            catch(Exception ex)
            {
                AddRoomPatientResponse(false,ex.StackTrace, roomRequest); return response;
            }
        }

        public async Task<RoomPatientResponse> AuthorizeRoom(RoomPatientResponseDTO roomRequest)
        {
            try
            {
                roomPatient = await _context.RoomsPatients.Include(x => x.Room).Include(y => y.Patient).Where(z => z.RDPID.Equals(roomRequest.RDPID)).FirstOrDefaultAsync();
                if(roomPatient == null)
                {
                    AddRoomAdminResponse(false, $"No Room has been requested with id : {roomRequest.RDPID}", roomRequest);return response;
                }
                UpdateRoom(roomRequest.isActive);
                _context.RoomsPatients.Update(roomPatient);
                await _context.SaveChangesAsync();
                AddRoomAdminResponse(true, roomRequest.isActive ? $"Room {roomPatient?.Room?.RoomType} has been authorized to {roomPatient?.Patient?.PatientName}" : $"Room Authorization has been revoked for id {roomRequest.RDPID}",roomRequest);
                return response;
            }
            catch(Exception ex)
            {
                AddRoomAdminResponse(false, ex.Message, roomRequest); return response;
            }
        }
        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public void AddRoom(string id, Patient patient, Room room)
        {
            roomPatient = new RoomPatient()
            {
                RDPID= id,
                Patient= patient,
                Room = room,
                IsActive = false,
            };
        }
        public void UpdateRoom(bool isactive)
        {
            roomPatient.IsActive = isactive;
        }

        public void AddRoomPatientResponse(bool status, string message, RoomPatientRequestDTO request)
        {
            response.Status = status;
            response.Message = message;
            response.PatientResponse = request;
            response.AdminResponse = null;
        }
        public void AddRoomAdminResponse(bool status, string message, RoomPatientResponseDTO request)
        {
            response.Status = status;
            response.Message = message;
            response.PatientResponse = null;
            response.AdminResponse = request;
        }

        public async Task<List<RoomPatient>> GetAllRoomPatient()
        {
            return await _context.RoomsPatients.Include(x => x.Patient).Include(y => y.Room).ToListAsync();
        }
    }
}
