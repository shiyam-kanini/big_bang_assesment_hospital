using Hospital_Management_API.Models;
using Hospital_Management_API.Models_Dto_;
using Hospital_Management_API.Models_Dto_.LabReportDto;
using Hospital_Management_API.Models_Response_.LabReportResponses;

namespace Hospital_Management_API.Repositories.LabReportRepo
{
    public class RepoLabReport : IRepoLabReport
    {
        private readonly Random random= new Random();
        private readonly HospitalDbContext _context;
        public RepoLabReport(HospitalDbContext context)
        {
            _context = context;
        }
        public LabReportPatientResponse patientReport = new LabReportPatientResponse();
        public LabReportIssuerResponse issuerResponse = new LabReportIssuerResponse();
        LabReport report = new LabReport();

        public async Task<LabReportPatientResponse> LabReportPatient(LabReportPatientDTO labReport)
        {
            try
            {
                Patient isPatientExist = await _context.Patients.FindAsync(labReport.PatientId);
                if (isPatientExist == null)
                {
                    AddPatientResponse(false, $" No Patient found with id : {labReport.PatientId}", labReport); return patientReport;
                }
                AddLabReport($"LRID{random.Next(100, 999)}", isPatientExist);
                await _context.LabReports.AddAsync(report);
                await _context.SaveChangesAsync();
                AddPatientResponse(true, $"Lab report request has been sent to Lab Technician, ReportId : {report.LabReportId}", labReport);
                return patientReport;
            }
            catch(Exception ex) 
            {
                AddPatientResponse(false, ex.Message,labReport); return patientReport;
            }
        }
        public async Task<LabReportIssuerResponse> LabReportIssuer(LabReportIssuerDTO labReport)
        {
            try
            {
                Employee isIssuerExist = await _context.Employees.FindAsync(labReport.Issuer);
                if (isIssuerExist == null)
                {
                    AddIssuerResponse(false, $" No Employee with id : {labReport.Issuer}", labReport); 
                    return issuerResponse;
                }
                report = await _context.LabReports.FindAsync(labReport.ReportId);
                if(report == null)
                {
                    AddIssuerResponse(false, $" No Report with id : {labReport.ReportId}", labReport); return issuerResponse;
                }
                UpdateLabReport(labReport, isIssuerExist);
                _context.LabReports.Update(report);
                await _context.SaveChangesAsync();
                AddIssuerResponse(true, $"Report succesfully Generated", labReport);
                return issuerResponse;
            }
            catch (Exception ex)
            {
                AddIssuerResponse(false, ex.Message, labReport); return issuerResponse;
            }
        }
        public void AddLabReport(string id, Patient patient)
        {
            report = new LabReport()
            {
                LabReportId = id,
                Patient = patient,
            };
        }
        public void UpdateLabReport(LabReportIssuerDTO labReport, Employee issuer)
        {
            report.Description = labReport.Description;
            report.DiagnosedImgURL= labReport.DiagnosedImgURL;
            report.Issuer= issuer;
            report.Issued = true;
        }
        public void AddPatientResponse(bool status, string message, LabReportPatientDTO labReportPatient)
        {
            patientReport = new LabReportPatientResponse()
            {
                Status = status,
                Message = message,
                labReport = labReportPatient
            };
        }
        public void AddIssuerResponse(bool status, string message, LabReportIssuerDTO labReportIssuer)
        {
            issuerResponse = new LabReportIssuerResponse()
            {
                Status = status,
                Message = message,
                labReport = labReportIssuer
            };
        }
    }
}
