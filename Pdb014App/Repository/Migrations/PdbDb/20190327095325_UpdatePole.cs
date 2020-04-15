using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_TblPole_PreviousPoleNo",
                table: "TblPole");

            migrationBuilder.DropIndex(
                name: "IX_TblPole_PreviousPoleNo",
                table: "TblPole");

            migrationBuilder.AlterColumn<string>(
                name: "PreviousPoleNo",
                table: "TblPole",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PreviousPoleNo",
                table: "TblPole",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_PreviousPoleNo",
                table: "TblPole",
                column: "PreviousPoleNo");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_TblPole_PreviousPoleNo",
                table: "TblPole",
                column: "PreviousPoleNo",
                principalTable: "TblPole",
                principalColumn: "PoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
