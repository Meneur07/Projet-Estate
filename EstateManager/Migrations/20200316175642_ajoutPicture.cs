using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstateManager.Migrations
{
    public partial class ajoutPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Estates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Estates");
        }
    }
}
