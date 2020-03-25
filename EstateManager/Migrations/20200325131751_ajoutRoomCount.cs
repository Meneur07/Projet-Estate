using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManager.Migrations
{
    public partial class ajoutRoomCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "roomCount",
                table: "Estates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roomCount",
                table: "Estates");
        }
    }
}
