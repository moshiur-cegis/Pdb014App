using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateConductor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblConductor",
                table: "TblConductor");

            migrationBuilder.DropColumn(
                name: "ConductorId",
                table: "TblConductor");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TblConductor",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblConductor",
                table: "TblConductor",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblConductor",
                table: "TblConductor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TblConductor");

            migrationBuilder.AddColumn<string>(
                name: "ConductorId",
                table: "TblConductor",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblConductor",
                table: "TblConductor",
                column: "ConductorId");
        }
    }
}
