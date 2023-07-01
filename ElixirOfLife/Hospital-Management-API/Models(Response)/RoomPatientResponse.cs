using Hospital_Management_API.Models_Dto_.RoomPatient.cs;

namespace Hospital_Management_API.Models_Response_
{
    public class RoomPatientResponse
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public RoomPatientRequestDTO? PatientResponse { get; set; }
        public RoomPatientResponseDTO? AdminResponse { get; set; }


    }
}
