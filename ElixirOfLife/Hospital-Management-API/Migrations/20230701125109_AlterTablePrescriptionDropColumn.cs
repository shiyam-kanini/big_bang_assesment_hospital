using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablePrescriptionDropColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiagnosedWith",
                table: "Prescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiagnosedWith",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
