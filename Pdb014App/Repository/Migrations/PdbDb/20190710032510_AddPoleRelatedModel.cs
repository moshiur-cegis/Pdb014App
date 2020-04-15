using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class AddPoleRelatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUpGuyType",
                columns: table => new
                {
                    GuyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuyTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpGuyType", x => x.GuyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpInsulatorType",
                columns: table => new
                {
                    InsulatorTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsulatorTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpInsulatorType", x => x.InsulatorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TblGuy",
                columns: table => new
                {
                    GuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuyTypeId = table.Column<int>(type: "int", nullable: true),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    NoOfSet = table.Column<int>(type: "int", nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGuy", x => x.GuyId);
                    table.ForeignKey(
                        name: "FK_TblGuy_LookUpCondition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "LookUpCondition",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblGuy_LookUpGuyType_GuyTypeId",
                        column: x => x.GuyTypeId,
                        principalTable: "LookUpGuyType",
                        principalColumn: "GuyTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblGuy_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblInsulator",
                columns: table => new
                {
                    InsulatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Installation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NominalSystemVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InsulatorTypeId = table.Column<int>(type: "int", nullable: true),
                    MaximumSystemVoltage = table.Column<string>(name: "MaximumSystemVoltage ", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeOfSystem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InsulatorVoltageClass = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InsulatorMaterials = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumCreepageDistance = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumWithstandVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PowerFrequencyDry = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PowerFrequencyWet = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImpulseWithstandVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumPowerFrequencyFlashoverDry = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumPowerFrequencyFlashoverWet = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FiftyPctImpulseFlashoverWavePositive = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FiftyPctImpulseFlashoverWaveNegative = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PowerFrequencyPuncherVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumDryArchingDistance = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PowerFrequencyTestVoltageRmsToGround = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumNeckDiameter = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumDiameterOfInsulator = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumHeightOfTheInsulator = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumGroveDiameter = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumMechanicalFailingLoad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ConditionId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInsulator", x => x.InsulatorId);
                    table.ForeignKey(
                        name: "FK_TblInsulator_LookUpCondition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "LookUpCondition",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblInsulator_LookUpInsulatorType_InsulatorTypeId",
                        column: x => x.InsulatorTypeId,
                        principalTable: "LookUpInsulatorType",
                        principalColumn: "InsulatorTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblInsulator_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblGuy_ConditionId",
                table: "TblGuy",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblGuy_GuyTypeId",
                table: "TblGuy",
                column: "GuyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblGuy_PoleId",
                table: "TblGuy",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulator_ConditionId",
                table: "TblInsulator",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulator_InsulatorTypeId",
                table: "TblInsulator",
                column: "InsulatorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulator_PoleId",
                table: "TblInsulator",
                column: "PoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblGuy");

            migrationBuilder.DropTable(
                name: "TblInsulator");

            migrationBuilder.DropTable(
                name: "LookUpGuyType");

            migrationBuilder.DropTable(
                name: "LookUpInsulatorType");
        }
    }
}
