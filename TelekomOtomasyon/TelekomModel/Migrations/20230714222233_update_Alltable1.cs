using Microsoft.EntityFrameworkCore.Migrations;

namespace TelekomModel.Migrations
{
    public partial class update_Alltable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "AllTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerSurname",
                table: "AllTables",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "AllTables");

            migrationBuilder.DropColumn(
                name: "CustomerSurname",
                table: "AllTables");
        }
    }
}
