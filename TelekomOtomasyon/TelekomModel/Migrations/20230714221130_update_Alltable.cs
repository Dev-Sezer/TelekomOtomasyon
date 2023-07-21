using Microsoft.EntityFrameworkCore.Migrations;

namespace TelekomModel.Migrations
{
    public partial class update_Alltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PackageName",
                table: "AllTables",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageName",
                table: "AllTables");
        }
    }
}
