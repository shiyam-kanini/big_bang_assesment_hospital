using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.ProfileDto;
using Hospital_Management_API.Models_Response_.ProfileResponses;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Hospital_Management_API.Repositories.PatientProfileRepo
{
    public class RepoPatientProfile : IRepoPatientProfile
    {
        private readonly HospitalDbContext _context;
        public RepoPatientProfile(HospitalDbContext context)
        {
            _context = context;
        }
        public PatientProfileResponse patientProfileResponse= new();
        public PatientProfileGetDTO patientProfile = new PatientProfileGetDTO();
        public async Task<PatientProfileResponse> GetPatientProfile(string sessionId)
        {
            try
            {
                LoginLog log = await _context.LoginLogs.FindAsync(sessionId);
                if (log == null)
                {
                    AddPatientProfileResponse(false, "Session Not found", patientProfile);
                    return patientProfileResponse ;
                }
                if (!log.IsLoggedIn)
                {
                    AddPatientProfileResponse(false, "Session Expired", patientProfile);
                    return patientProfileResponse;
                }
                else
                {
                    Patient isPatientExists = await _context.Patients.FindAsync(log.LoginId);
                    AddPatientProfile(isPatientExists, sessionId);
                    AddPatientProfileResponse(true, $"Welcome {isPatientExists.PatientName}", patientProfile);
                    return patientProfileResponse;
                }
            }
            catch (Exception ex)
            {
                AddPatientProfileResponse(false, ex.Message, patientProfile);
                return patientProfileResponse;
            }
        }
        public void AddPatientProfile(Patient patient, string sessionId)
        {
            patientProfile = new PatientProfileGetDTO()
            {
                PatientId = patient.PatientId,
                SessionId = sessionId,
                PatientName = patient.PatientName,
                Gender = patient.Gender,
            };
        }
        public void AddPatientProfileResponse(bool status, string message,  PatientProfileGetDTO patientProfile)
        {
            patientProfileResponse = new PatientProfileResponse()
            {
                Status = status,
                Message = message,
                PatientProfile = patientProfile
            };
        }
    }
}
