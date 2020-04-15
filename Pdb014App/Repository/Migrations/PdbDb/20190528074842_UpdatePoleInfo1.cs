using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePoleInfo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpTypeOfWire_Type Of Wire",
                table: "TblPole");

            migrationBuilder.DropIndex(
                name: "IX_TblPole_Type Of Wire",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "Type Of Wire",
                table: "TblPole");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_TypeOfWireId",
                table: "TblPole",
                column: "TypeOfWireId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpTypeOfWire_TypeOfWireId",
                table: "TblPole",
                column: "TypeOfWireId",
                principalTable: "LookUpTypeOfWire",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpTypeOfWire_TypeOfWireId",
                table: "TblPole");

            migrationBuilder.DropIndex(
                name: "IX_TblPole_TypeOfWireId",
                table: "TblPole");

            migrationBuilder.AddColumn<int>(
                name: "Type Of Wire",
                table: "TblPole",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_Type Of Wire",
                table: "TblPole",
                column: "Type Of Wire");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpTypeOfWire_Type Of Wire",
                table: "TblPole",
                column: "Type Of Wire",
                principalTable: "LookUpTypeOfWire",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
