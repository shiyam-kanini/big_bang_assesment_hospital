using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablePrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SessionActive",
                table: "Prescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionActive",
                table: "Prescriptions");
        }
    }
}
