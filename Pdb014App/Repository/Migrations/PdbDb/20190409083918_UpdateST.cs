using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSubstation_LookUpSnDInfo_SnDCode",
                table: "TblSubstation");

            migrationBuilder.AlterColumn<string>(
                name: "SnDCode",
                table: "TblSubstation",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "TblSubstation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "TblSubstation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubstation_LookUpSnDInfo_SnDCode",
                table: "TblSubstation",
                column: "SnDCode",
                principalTable: "LookUpSnDInfo",
                principalColumn: "SnDCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSubstation_LookUpSnDInfo_SnDCode",
                table: "TblSubstation");

            migrationBuilder.AlterColumn<string>(
                name: "SnDCode",
                table: "TblSubstation",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "TblSubstation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "TblSubstation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubstation_LookUpSnDInfo_SnDCode",
                table: "TblSubstation",
                column: "SnDCode",
                principalTable: "LookUpSnDInfo",
                principalColumn: "SnDCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
