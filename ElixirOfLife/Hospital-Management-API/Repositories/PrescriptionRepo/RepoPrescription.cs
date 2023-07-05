using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_.PrescriptionDto;
using Hospital_Management_API.Models_Response_.PrescriptionResponses;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_API.Repositories.PrescriptionRepo
{
    public class RepoPrescription : IRepoPrescription
    {
        private readonly HospitalDbContext _context;
        private readonly Random random = new Random();
        public RepoPrescription(HospitalDbContext context)
        {
            _context = context;
        }
        public Patient patient = new Patient();
        public Employee doctor = new Employee();
        public PrescriptionResponse response = new PrescriptionResponse();
        public DiagnoseResponse diagnose = new DiagnoseResponse();
        public Prescription prescriptionSession = new Prescription();
        public async Task<PrescriptionResponse> BuyDrugs(BuyDrugsDTO medicationDTO)
        {
            try
            {
                prescriptionSession = await _context.Prescriptions.FindAsync(medicationDTO.PrescriptionId);
                if(prescriptionSession == null)
                {
                    AddPrescriptionResponse(false, $"No session with id{medicationDTO.PrescriptionId}");return response;
                }
                prescriptionSession.Bought = medicationDTO.buy;
                _context.Prescriptions.Update(prescriptionSession);
                await _context.SaveChangesAsync();
                AddPrescriptionResponse(true, "Payment successfull");
                return response;
            }
            catch(Exception ex)
            {
                AddPrescriptionResponse(false, ex.Message); return response;
            }
        }
        public async Task<DiagnoseResponse> DiagnoseSymptoms(DiagnoseDTO diagnoseData)
        {
            try
            {
                prescriptionSession = await _context.Prescriptions.FindAsync(diagnoseData.PrescriptionId);
                if (diagnoseData.Symptoms.Count <= 0)
                {
                    diagnose.Status = false; diagnose.Message = $"No Session found with id : {diagnoseData.PrescriptionId}"; return diagnose;
                }
                if (diagnoseData.Symptoms.Count <= 0)
                {
                    diagnose.Status = false; diagnose.Message = "Enter Symptoms";return diagnose;
                }
                string? drugsStr = "";
                int price = 0;
                DrugInventory[] drugs = await _context.DrugInventory.ToArrayAsync();
                List<DrugInventory> medication = new List<DrugInventory>();
                foreach (string symptom in diagnoseData.Symptoms)
                {
                    int r = random.Next(0, drugs.Length - 1);
                    drugsStr += drugs[r].DrugId + ", ";
                    medication.Add(drugs[r]);
                    price += drugs[r].DrugPrice;
                }
                UpdateMedication(drugsStr, price);
                _context.Prescriptions.Update(prescriptionSession);
                await _context.SaveChangesAsync();
                diagnose.Status = true;diagnose.Message = $"{medication.Count} medications found";diagnose.Medication = medication;
                return diagnose;

            }
            catch(Exception ex)
            {
                diagnose.Status = false; diagnose.Message = ex.Message; return diagnose;
            }
        }

        public async Task<PrescriptionResponse> InitiateSession(DoctorSessionDTO sessionData)
        {
            try
            {
                patient = await _context.Patients.FindAsync(sessionData.Patient);
                if(patient == null)
                {
                    AddPrescriptionResponse(false, $"patient with {sessionData.Patient} not found");return response;
                }
                doctor = await _context.Employees.FindAsync(sessionData.PrescriptionIssuer);
                if(doctor == null)
                {
                    AddPrescriptionResponse(false, $"doctor with {sessionData.PrescriptionIssuer} not found"); return response;
                }
                prescriptionSession = await _context.Prescriptions.Where(x => x.PrescriptionIssuer.EmployeeId.Equals(sessionData.PrescriptionIssuer) && x.Patient.PatientId.Equals(sessionData.Patient)).Select( y => new Prescription
                {
                    PrescriptionId= y.PrescriptionId,
                    PrescriptionIssuer = y.PrescriptionIssuer,
                    Patient = y.Patient,
                    SessionActive = y.SessionActive

                }).FirstOrDefaultAsync();
                if(prescriptionSession != null) 
                {
                    AddPrescriptionResponse(false, prescriptionSession.SessionActive ? $"Session is active under {prescriptionSession.PrescriptionId}" : "session is pennding ");
                    return response;
                }
                AddPrescription($"PRESID{random.Next(1000, 9999)}", patient, doctor, sessionData.SessionActive);
                await _context.Prescriptions.AddAsync(prescriptionSession);
                await _context.SaveChangesAsync();
                AddPrescriptionResponse(true, sessionData.SessionActive ? $"Session {prescriptionSession.PrescriptionId} has been created" : $"Session {prescriptionSession.PrescriptionId} has been cancelled");
                return response;
            }
            catch(Exception ex)
            {
                AddPrescriptionResponse(false, ex.Message); return response;
            }
        }
        public void UpdateMedication(string drugs, int price)
        {
            prescriptionSession.Medication = drugs;
            prescriptionSession.MedicationPrice = price;
        }
        public void AddPrescription(string id, Patient patient, Employee Doctor, bool isactive)
        {
            prescriptionSession = new Prescription()
            {
                PrescriptionId= id,
                Patient = patient,
                PrescriptionIssuer = doctor,
                SessionActive = isactive,
            };
        }
        public void AddPrescriptionResponse(bool status, string message)
        {
            response.Status= status;
            response.Message= message;
        }

        public async Task<List<Prescription>> GetAllPrescriptions()
        {
            return await _context.Prescriptions.Include(x => x.Patient).Include(y => y.PrescriptionIssuer).ToListAsync();
        }
        public async Task<List<Employee>> GetDoctors()
        {
            return await _context.Employees.Include(a => a.Role).Include(b => b.DoctorSpecializations).Where(x => x.Role.RoleId.Equals("ROLEID002")).ToListAsync();
        }
        public async Task<Prescription> GetPrescriptionById(string Id)
        {
            return await _context.Prescriptions.Where(x => x.PrescriptionId.Equals(Id) && x.SessionActive).FirstOrDefaultAsync();
        }
        public async Task<List<Prescription>> GetPrescriptionByDoctor(string doctorId)
        {
            return await _context.Prescriptions.Where(x => x.PrescriptionIssuer.EmployeeId.Equals(doctorId)).Include(y => y.Patient).Include(z => z.PrescriptionIssuer).ToListAsync();
        }
        public async Task<Prescription> GetPrescriptionByPatient(string prescriptionId)
        {
            return await _context.Prescriptions.Include(y => y.Patient).Include(z => z.PrescriptionIssuer).Where(a => a.PrescriptionId.Equals(prescriptionId)).FirstOrDefaultAsync();
        }
    }
}
