﻿// <auto-generated />
using Hospital_Management_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital_Management_API.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital_Management_API.Models.DrugInventory", b =>
                {
                    b.Property<string>("DrugId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DrugDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrugPrice")
                        .HasColumnType("int");

                    b.Property<string>("DrugType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrugId");

                    b.ToTable("DrugInventory");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeQualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<byte[]>("passwordKey")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.EmployeeSpecialization", b =>
                {
                    b.Property<string>("DSID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DoctorEmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SpecializationId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DSID");

                    b.HasIndex("DoctorEmployeeId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("EmployeeSpecialization");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.HealthSymptoms", b =>
                {
                    b.Property<string>("SymptomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SymptomDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SymptomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SymptomId");

                    b.ToTable("HealthSymptoms");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.LabReport", b =>
                {
                    b.Property<string>("LabReportId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagnosedImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Issued")
                        .HasColumnType("bit");

                    b.Property<string>("IssuerEmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LabReportId");

                    b.HasIndex("IssuerEmployeeId");

                    b.HasIndex("PatientId");

                    b.ToTable("LabReports");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.LoginLog", b =>
                {
                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("LoginId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionId");

                    b.ToTable("LoginLogs");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Patient", b =>
                {
                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("passwordKey")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.PatientBill", b =>
                {
                    b.Property<string>("BillId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BillPrice")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BillId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientBills");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Prescription", b =>
                {
                    b.Property<string>("PrescriptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Bought")
                        .HasColumnType("bit");

                    b.Property<string>("Medication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicationPrice")
                        .HasColumnType("int");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PrescriptionIssuerEmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("SessionActive")
                        .HasColumnType("bit");

                    b.HasKey("PrescriptionId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PrescriptionIssuerEmployeeId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roleame")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.RoleRoom", b =>
                {
                    b.Property<string>("RRID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RRID");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoleRoom");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Room", b =>
                {
                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DefaultDoctorEmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IsAvailable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoomCount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("DefaultDoctorEmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.RoomPatient", b =>
                {
                    b.Property<string>("RDPID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RDPID");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomsPatients");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Specialization", b =>
                {
                    b.Property<string>("SpecializationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SpecializationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SpecializationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecializationId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SpecializationId1");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.SymptomsDrugs", b =>
                {
                    b.Property<string>("SDID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DrugId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SymptomsSymptomId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SDID");

                    b.HasIndex("DrugId");

                    b.HasIndex("SymptomsSymptomId");

                    b.ToTable("SymptomsDrugs");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Employee", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.EmployeeSpecialization", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Employee", "Doctor")
                        .WithMany("DoctorSpecializations")
                        .HasForeignKey("DoctorEmployeeId");

                    b.HasOne("Hospital_Management_API.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId");

                    b.Navigation("Doctor");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.LabReport", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Employee", "Issuer")
                        .WithMany("LabReports")
                        .HasForeignKey("IssuerEmployeeId");

                    b.HasOne("Hospital_Management_API.Models.Patient", "Patient")
                        .WithMany("LabReport")
                        .HasForeignKey("PatientId");

                    b.Navigation("Issuer");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.PatientBill", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Patient", "Patient")
                        .WithMany("PatientBill")
                        .HasForeignKey("PatientId");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Prescription", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PatientId");

                    b.HasOne("Hospital_Management_API.Models.Employee", "PrescriptionIssuer")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PrescriptionIssuerEmployeeId");

                    b.Navigation("Patient");

                    b.Navigation("PrescriptionIssuer");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.RoleRoom", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Hospital_Management_API.Models.Room", "Room")
                        .WithMany("RolesRooms")
                        .HasForeignKey("RoomId");

                    b.Navigation("Role");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Room", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Employee", "DefaultDoctor")
                        .WithMany("Rooms")
                        .HasForeignKey("DefaultDoctorEmployeeId");

                    b.HasOne("Hospital_Management_API.Models.Role", null)
                        .WithMany("RoleRoom")
                        .HasForeignKey("RoleId");

                    b.Navigation("DefaultDoctor");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.RoomPatient", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("Hospital_Management_API.Models.Room", "Room")
                        .WithMany("Patients")
                        .HasForeignKey("RoomId");

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Specialization", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.Role", "Role")
                        .WithMany("Specializations")
                        .HasForeignKey("RoleId");

                    b.HasOne("Hospital_Management_API.Models.Specialization", null)
                        .WithMany("Specializations")
                        .HasForeignKey("SpecializationId1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.SymptomsDrugs", b =>
                {
                    b.HasOne("Hospital_Management_API.Models.DrugInventory", "Drug")
                        .WithMany("SymptomsDrugs")
                        .HasForeignKey("DrugId");

                    b.HasOne("Hospital_Management_API.Models.HealthSymptoms", "Symptoms")
                        .WithMany("SymptomsDrugs")
                        .HasForeignKey("SymptomsSymptomId");

                    b.Navigation("Drug");

                    b.Navigation("Symptoms");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.DrugInventory", b =>
                {
                    b.Navigation("SymptomsDrugs");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Employee", b =>
                {
                    b.Navigation("DoctorSpecializations");

                    b.Navigation("LabReports");

                    b.Navigation("Prescriptions");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.HealthSymptoms", b =>
                {
                    b.Navigation("SymptomsDrugs");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Patient", b =>
                {
                    b.Navigation("LabReport");

                    b.Navigation("PatientBill");

                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Role", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("RoleRoom");

                    b.Navigation("Specializations");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Room", b =>
                {
                    b.Navigation("Patients");

                    b.Navigation("RolesRooms");
                });

            modelBuilder.Entity("Hospital_Management_API.Models.Specialization", b =>
                {
                    b.Navigation("Specializations");
                });
#pragma warning restore 612, 618
        }
    }
}
