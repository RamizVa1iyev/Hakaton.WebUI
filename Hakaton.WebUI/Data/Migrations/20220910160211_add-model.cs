using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hakaton.WebUI.Data.Migrations
{
    public partial class addmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BateryCapacity",
                table: "Bateries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BateryCapacity",
                table: "Bateries");
        }
    }
}
