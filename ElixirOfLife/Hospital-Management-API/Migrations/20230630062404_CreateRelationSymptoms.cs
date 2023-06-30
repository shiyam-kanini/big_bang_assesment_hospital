using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationSymptoms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SymptomsDrugs");

            migrationBuilder.DropTable(
                name: "HealthSymptoms");
        }
    }
}
