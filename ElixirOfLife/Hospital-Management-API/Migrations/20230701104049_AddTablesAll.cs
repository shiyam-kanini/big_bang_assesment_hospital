﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugInventory",
                columns: table => new
                {
                    DrugId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DrugType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugInventory", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "HealthSymptoms",
                columns: table => new
                {
                    SymptomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SymptomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SymptomDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthSymptoms", x => x.SymptomId);
                });

            migrationBuilder.CreateTable(
                name: "LoginLogs",
                columns: table => new
                {
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginLogs", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    passwordKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Roleame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SymptomsDrugs",
                columns: table => new
                {
                    SDID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SymptomsSymptomId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DrugId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomsDrugs", x => x.SDID);
                    table.ForeignKey(
                        name: "FK_SymptomsDrugs_DrugInventory_DrugId",
                        column: x => x.DrugId,
                        principalTable: "DrugInventory",
                        principalColumn: "DrugId");
                    table.ForeignKey(
                        name: "FK_SymptomsDrugs_HealthSymptoms_SymptomsSymptomId",
                        column: x => x.SymptomsSymptomId,
                        principalTable: "HealthSymptoms",
                        principalColumn: "SymptomId");
                });

            migrationBuilder.CreateTable(
                name: "PatientBills",
                columns: table => new
                {
                    BillId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BillPrice = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientBills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_PatientBills_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeQualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    passwordKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmployeeImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpecializationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SpecializationId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationId);
                    table.ForeignKey(
                        name: "FK_Specializations_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_Specializations_Specializations_SpecializationId1",
                        column: x => x.SpecializationId1,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId");
                });

            migrationBuilder.CreateTable(
                name: "LabReports",
                columns: table => new
                {
                    LabReportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IssuerEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DiagnosedImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issued = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabReports", x => x.LabReportId);
                    table.ForeignKey(
                        name: "FK_LabReports_Employees_IssuerEmployeeId",
                        column: x => x.IssuerEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_LabReports_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrescriptionIssuerEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DiagnosedWith = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationPrice = table.Column<int>(type: "int", nullable: false),
                    Bought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Employees_PrescriptionIssuerEmployeeId",
                        column: x => x.PrescriptionIssuerEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultDoctorEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Employees_DefaultDoctorEmployeeId",
                        column: x => x.DefaultDoctorEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Rooms_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSpecialization",
                columns: table => new
                {
                    DSID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SpecializationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSpecialization", x => x.DSID);
                    table.ForeignKey(
                        name: "FK_EmployeeSpecialization_Employees_DoctorEmployeeId",
                        column: x => x.DoctorEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_EmployeeSpecialization_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId");
                });

            migrationBuilder.CreateTable(
                name: "RoleRoom",
                columns: table => new
                {
                    RRID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRoom", x => x.RRID);
                    table.ForeignKey(
                        name: "FK_RoleRoom_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_RoleRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateTable(
                name: "RoomsPatients",
                columns: table => new
                {
                    RDPID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsPatients", x => x.RDPID);
                    table.ForeignKey(
                        name: "FK_RoomsPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_RoomsPatients_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSpecialization_DoctorEmployeeId",
                table: "EmployeeSpecialization",
                column: "DoctorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSpecialization_SpecializationId",
                table: "EmployeeSpecialization",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReports_IssuerEmployeeId",
                table: "LabReports",
                column: "IssuerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LabReports_PatientId",
                table: "LabReports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBills_PatientId",
                table: "PatientBills",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PrescriptionIssuerEmployeeId",
                table: "Prescriptions",
                column: "PrescriptionIssuerEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoom_RoleId",
                table: "RoleRoom",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoom_RoomId",
                table: "RoleRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DefaultDoctorEmployeeId",
                table: "Rooms",
                column: "DefaultDoctorEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoleId",
                table: "Rooms",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsPatients_PatientId",
                table: "RoomsPatients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsPatients_RoomId",
                table: "RoomsPatients",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_RoleId",
                table: "Specializations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SpecializationId1",
                table: "Specializations",
                column: "SpecializationId1");

            migrationBuilder.CreateIndex(
                name: "IX_SymptomsDrugs_DrugId",
                table: "SymptomsDrugs",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_SymptomsDrugs_SymptomsSymptomId",
                table: "SymptomsDrugs",
                column: "SymptomsSymptomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSpecialization");

            migrationBuilder.DropTable(
                name: "LabReports");

            migrationBuilder.DropTable(
                name: "LoginLogs");

            migrationBuilder.DropTable(
                name: "PatientBills");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "RoleRoom");

            migrationBuilder.DropTable(
                name: "RoomsPatients");

            migrationBuilder.DropTable(
                name: "SymptomsDrugs");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "DrugInventory");

            migrationBuilder.DropTable(
                name: "HealthSymptoms");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
