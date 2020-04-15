using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateCopperCables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCopperCables",
                table: "TblCopperCables");

            migrationBuilder.DropColumn(
                name: "CopperCablesId",
                table: "TblCopperCables");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TblCopperCables",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCopperCables",
                table: "TblCopperCables",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCopperCables",
                table: "TblCopperCables");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblCopperCables");

            migrationBuilder.AddColumn<string>(
                name: "CopperCablesId",
                table: "TblCopperCables",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCopperCables",
                table: "TblCopperCables",
                column: "CopperCablesId");
        }
    }
}
