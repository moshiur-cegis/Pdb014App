using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePolePic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeederLineId",
                table: "TblPolePicture",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoleNo",
                table: "TblPolePicture",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResizedPictureName",
                table: "TblPolePicture",
                type: "varchar(250)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreviousPoleNo",
                table: "TblPole",
                type: "nvarchar(50)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PoleNo",
                table: "TblPole",
                type: "nvarchar(50)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeederLineId",
                table: "TblPolePicture");

            migrationBuilder.DropColumn(
                name: "PoleNo",
                table: "TblPolePicture");

            migrationBuilder.DropColumn(
                name: "ResizedPictureName",
                table: "TblPolePicture");

            migrationBuilder.AlterColumn<string>(
                name: "PreviousPoleNo",
                table: "TblPole",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PoleNo",
                table: "TblPole",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
