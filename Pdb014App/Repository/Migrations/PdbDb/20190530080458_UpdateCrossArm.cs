using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateCrossArm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCrossArm");

            migrationBuilder.CreateTable(
                name: "TblCrossArmInfo",
                columns: table => new
                {
                    CrossArmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Materials = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UltimateTensileStrength = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeOfFittingsId = table.Column<int>(type: "int", nullable: true),
                    NoOfSetFittings = table.Column<int>(type: "int", nullable: true),
                    FittingsConditionId = table.Column<int>(type: "int", nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCrossArmInfo", x => x.CrossArmId);
                    table.ForeignKey(
                        name: "FK_TblCrossArmInfo_LookUpCondition_FittingsConditionId",
                        column: x => x.FittingsConditionId,
                        principalTable: "LookUpCondition",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCrossArmInfo_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCrossArmInfo_LookUpTypeOfFittings_TypeOfFittingsId",
                        column: x => x.TypeOfFittingsId,
                        principalTable: "LookUpTypeOfFittings",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArmInfo_FittingsConditionId",
                table: "TblCrossArmInfo",
                column: "FittingsConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArmInfo_PoleId",
                table: "TblCrossArmInfo",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArmInfo_TypeOfFittingsId",
                table: "TblCrossArmInfo",
                column: "TypeOfFittingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCrossArmInfo");

            migrationBuilder.CreateTable(
                name: "TblCrossArm",
                columns: table => new
                {
                    CrossArmId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FittingsConditionId = table.Column<int>(type: "int", nullable: true),
                    Materials = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NoOfSetFittings = table.Column<int>(type: "int", nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeOfFittingsId = table.Column<int>(type: "int", nullable: true),
                    UltimateTensileStrength = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCrossArm", x => x.CrossArmId);
                    table.ForeignKey(
                        name: "FK_TblCrossArm_LookUpCondition_FittingsConditionId",
                        column: x => x.FittingsConditionId,
                        principalTable: "LookUpCondition",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCrossArm_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCrossArm_LookUpTypeOfFittings_TypeOfFittingsId",
                        column: x => x.TypeOfFittingsId,
                        principalTable: "LookUpTypeOfFittings",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArm_FittingsConditionId",
                table: "TblCrossArm",
                column: "FittingsConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArm_PoleId",
                table: "TblCrossArm",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArm_TypeOfFittingsId",
                table: "TblCrossArm",
                column: "TypeOfFittingsId");
        }
    }
}
