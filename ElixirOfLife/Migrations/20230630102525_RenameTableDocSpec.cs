using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableDocSpec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialization_Employees_DoctorEmployeeId",
                table: "DoctorSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialization_Specializations_SpecializationId",
                table: "DoctorSpecialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorSpecialization",
                table: "DoctorSpecialization");

            migrationBuilder.RenameTable(
                name: "DoctorSpecialization",
                newName: "EmployeeSpecialization");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSpecialization_SpecializationId",
                table: "EmployeeSpecialization",
                newName: "IX_EmployeeSpecialization_SpecializationId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSpecialization_DoctorEmployeeId",
                table: "EmployeeSpecialization",
                newName: "IX_EmployeeSpecialization_DoctorEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSpecialization",
                table: "EmployeeSpecialization",
                column: "DSID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSpecialization_Employees_DoctorEmployeeId",
                table: "EmployeeSpecialization",
                column: "DoctorEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSpecialization_Specializations_SpecializationId",
                table: "EmployeeSpecialization",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "SpecializationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSpecialization_Employees_DoctorEmployeeId",
                table: "EmployeeSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSpecialization_Specializations_SpecializationId",
                table: "EmployeeSpecialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSpecialization",
                table: "EmployeeSpecialization");

            migrationBuilder.RenameTable(
                name: "EmployeeSpecialization",
                newName: "DoctorSpecialization");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSpecialization_SpecializationId",
                table: "DoctorSpecialization",
                newName: "IX_DoctorSpecialization_SpecializationId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSpecialization_DoctorEmployeeId",
                table: "DoctorSpecialization",
                newName: "IX_DoctorSpecialization_DoctorEmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorSpecialization",
                table: "DoctorSpecialization",
                column: "DSID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialization_Employees_DoctorEmployeeId",
                table: "DoctorSpecialization",
                column: "DoctorEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialization_Specializations_SpecializationId",
                table: "DoctorSpecialization",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "SpecializationId");
        }
    }
}
