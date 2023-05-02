using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_SuperPoli.Migrations
{
    public partial class intialUpdate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFile_Files_FileId",
                table: "ProductFile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFile_Products_ProductId",
                table: "ProductFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFile",
                table: "ProductFile");

            migrationBuilder.RenameTable(
                name: "ProductFile",
                newName: "ProductFiles");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFile_FileId",
                table: "ProductFiles",
                newName: "IX_ProductFiles_FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFiles",
                table: "ProductFiles",
                columns: new[] { "ProductId", "FileId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFiles_Files_FileId",
                table: "ProductFiles",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFiles_Products_ProductId",
                table: "ProductFiles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFiles_Files_FileId",
                table: "ProductFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFiles_Products_ProductId",
                table: "ProductFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFiles",
                table: "ProductFiles");

            migrationBuilder.RenameTable(
                name: "ProductFiles",
                newName: "ProductFile");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFiles_FileId",
                table: "ProductFile",
                newName: "IX_ProductFile_FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFile",
                table: "ProductFile",
                columns: new[] { "ProductId", "FileId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFile_Files_FileId",
                table: "ProductFile",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFile_Products_ProductId",
                table: "ProductFile",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
