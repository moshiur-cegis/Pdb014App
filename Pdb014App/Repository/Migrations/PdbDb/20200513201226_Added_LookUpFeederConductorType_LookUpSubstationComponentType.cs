using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class Added_LookUpFeederConductorType_LookUpSubstationComponentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeederConductorTypeId",
                table: "TblFeederLine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LookUpFeederConductorType",
                columns: table => new
                {
                    FeederConductorTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FeederConductorType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpFeederConductorType", x => x.FeederConductorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSubstationComponentType",
                columns: table => new
                {
                    SubstationComponentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubstationComponentType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSubstationComponentType", x => x.SubstationComponentTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblFeederLine_FeederConductorTypeId",
                table: "TblFeederLine",
                column: "FeederConductorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblFeederLine_LookUpFeederConductorType_FeederConductorTypeId",
                table: "TblFeederLine",
                column: "FeederConductorTypeId",
                principalTable: "LookUpFeederConductorType",
                principalColumn: "FeederConductorTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblFeederLine_LookUpFeederConductorType_FeederConductorTypeId",
                table: "TblFeederLine");

            migrationBuilder.DropTable(
                name: "LookUpFeederConductorType");

            migrationBuilder.DropTable(
                name: "LookUpSubstationComponentType");

            migrationBuilder.DropIndex(
                name: "IX_TblFeederLine_FeederConductorTypeId",
                table: "TblFeederLine");

            migrationBuilder.DropColumn(
                name: "FeederConductorTypeId",
                table: "TblFeederLine");
        }
    }
}
