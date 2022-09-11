using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hakaton.WebUI.Data.Migrations
{
    public partial class addmodel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainStorages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StorageCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainStorages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainStorages");
        }
    }
}
