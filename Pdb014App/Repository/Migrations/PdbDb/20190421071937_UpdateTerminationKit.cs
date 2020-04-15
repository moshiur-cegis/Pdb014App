using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateTerminationKit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblTerminationKit",
                columns: table => new
                {
                    TerminationKitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusBarId = table.Column<int>(type: "int", nullable: true),
                    LineCapacity = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeofTerminationKit = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Application = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Installation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalSystemVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumSystemVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PowerFrequencyWithstandVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NumberofCore = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeofInsulation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeofScreening = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeofCableBox = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SystemNeutralEarthing = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConductorCrossSection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImpulseWithstandVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTerminationKit", x => x.TerminationKitId);
                    table.ForeignKey(
                        name: "FK_TblTerminationKit_LookupBusBar_BusBarId",
                        column: x => x.BusBarId,
                        principalTable: "LookupBusBar",
                        principalColumn: "BusBarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblTerminationKit_BusBarId",
                table: "TblTerminationKit",
                column: "BusBarId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblTerminationKit");
        }
    }
}
