using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_API.Models
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DrugInventory> DrugInventory { get; set; }
        public DbSet<LoginLog> LoginLogs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<DoctorSpecialization> DoctorSpecialization { get; set; }   
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomPatient> RoomsPatients { get;set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<LabReport> LabReports { get; set; }
        public DbSet<PatientBill> PatientBills { get; set; }
        public DbSet<HealthSymptoms> HealthSymptoms { get;set; }
        public DbSet<SymptomsDrugs> SymptomsDrugs { get; set; }
        
    }
}
