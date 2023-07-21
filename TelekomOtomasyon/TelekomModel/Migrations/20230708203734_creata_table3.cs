using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelekomModel.Migrations
{
    public partial class creata_table3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AllTables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllTables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AllTables_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllTables_Packages_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Packages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllTables_CustomerID",
                table: "AllTables",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_AllTables_PackageID",
                table: "AllTables",
                column: "PackageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllTables");

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
    }
}
