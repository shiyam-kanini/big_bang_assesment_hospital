using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomImgURL",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomImgURL",
                table: "Rooms");
        }
    }
}
