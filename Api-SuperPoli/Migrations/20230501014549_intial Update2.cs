using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_SuperPoli.Migrations
{
    public partial class intialUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Files_IdFile",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdFile",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdFile",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FileId",
                table: "Products",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Files_FileId",
                table: "Products",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Files_FileId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FileId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "IdFile",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdFile",
                table: "Products",
                column: "IdFile");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Files_IdFile",
                table: "Products",
                column: "IdFile",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
