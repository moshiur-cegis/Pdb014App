using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePolePictureId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblPolePicture",
                table: "TblPolePicture");

            migrationBuilder.DropColumn(
                name: "PolePictureId",
                table: "TblPolePicture");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TblPolePicture",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblPolePicture",
                table: "TblPolePicture",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblPolePicture",
                table: "TblPolePicture");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblPolePicture");

            migrationBuilder.AddColumn<string>(
                name: "PolePictureId",
                table: "TblPolePicture",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblPolePicture",
                table: "TblPolePicture",
                column: "PolePictureId");
        }
    }
}
