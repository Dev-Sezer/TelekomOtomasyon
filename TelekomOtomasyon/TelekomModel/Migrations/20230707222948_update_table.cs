using Microsoft.EntityFrameworkCore.Migrations;

namespace TelekomModel.Migrations
{
    public partial class update_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackageID",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PackageID",
                table: "Customers",
                column: "PackageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Packages_PackageID",
                table: "Customers",
                column: "PackageID",
                principalTable: "Packages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Packages_PackageID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PackageID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PackageID",
                table: "Customers");
        }
    }
}
