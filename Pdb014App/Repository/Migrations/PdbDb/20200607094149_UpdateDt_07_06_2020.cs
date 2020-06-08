using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateDt_07_06_2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_TblPoleStructureMountedSurgearrestor_PoleStructureMountedSurgearrestorId",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_PoleStructureMountedSurgearrestorId",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "PoleStructureMountedSurgearrestorId",
                table: "TblDistributionTransformer");

            migrationBuilder.AlterColumn<string>(
                name: "TypeofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlatformStandardbsNonStandardGoodBad",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlatformMaterialAnglbsChannel",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwneroftheTransformerBPDBbsConsumer",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstalledConditionPadbsPoleMounted",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EarthingLead2ConditionStandard",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EarthingLead1ConditionStandard",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofMCCBforCircuit2",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofMCCBforCircuit1",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLightingArrestorYphase",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLightingArrestorRphase",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLightingArrestorBphase",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLTDropGoodbsBadCKT2",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofHTDropGoodbsBad",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofDropOutFuseRphase",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofDistributionBox",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BodyColourCondition",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LookUpBodyColourCondition",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpBodyColourCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpDtCondition",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpDtCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpInstalledCondition",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpInstalledCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpInstalledPlace",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpInstalledPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpPlatformMaterial",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpPlatformMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSupportPoleLeftRightCondition",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSupportPoleLeftRightCondition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSupportPoleLeftRightType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSupportPoleLeftRightType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookUpTransformerOwner",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpTransformerOwner", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_BodyColourCondition",
                table: "TblDistributionTransformer",
                column: "BodyColourCondition");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofDistributionBox",
                table: "TblDistributionTransformer",
                column: "ConditionofDistributionBox");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer",
                column: "ConditionofDropOutFuseBphase");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofDropOutFuseRphase",
                table: "TblDistributionTransformer",
                column: "ConditionofDropOutFuseRphase");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer",
                column: "ConditionofDropOutFuseYphase");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofHTDropGoodbsBad",
                table: "TblDistributionTransformer",
                column: "ConditionofHTDropGoodbsBad");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer",
                column: "ConditionofLTDropGoodbsBadCKT1");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofLTDropGoodbsBadCKT2",
                table: "TblDistributionTransformer",
                column: "ConditionofLTDropGoodbsBadCKT2");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofLightingArrestorBphase",
                table: "TblDistributionTransformer",
                column: "ConditionofLightingArrestorBphase");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofLightingArrestorRphase",
                table: "TblDistributionTransformer",
                column: "ConditionofLightingArrestorRphase");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofLightingArrestorYphase",
                table: "TblDistributionTransformer",
                column: "ConditionofLightingArrestorYphase");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofMCCBforCircuit1",
                table: "TblDistributionTransformer",
                column: "ConditionofMCCBforCircuit1");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofMCCBforCircuit2",
                table: "TblDistributionTransformer",
                column: "ConditionofMCCBforCircuit2");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                column: "ConditionofTransformerSupportPoleLeft");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_ConditionofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                column: "ConditionofTransformerSupportPoleRight");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_EarthingLead1ConditionStandard",
                table: "TblDistributionTransformer",
                column: "EarthingLead1ConditionStandard");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_EarthingLead2ConditionStandard",
                table: "TblDistributionTransformer",
                column: "EarthingLead2ConditionStandard");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_HTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                column: "HTBushingNPhaseGood");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_HTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                column: "HTBushingRPhaseGood");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_HTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                column: "HTBushingYPhaseGood");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_InstalledConditionPadbsPoleMounted",
                table: "TblDistributionTransformer",
                column: "InstalledConditionPadbsPoleMounted");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer",
                column: "InstalledPlaceIndoorbsOutdoor");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_LTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                column: "LTBushingBPhaseGood");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_LTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                column: "LTBushingNPhaseGood");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_LTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                column: "LTBushingRPhaseGood");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_LTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                column: "LTBushingYPhaseGood");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_OwneroftheTransformerBPDBbsConsumer",
                table: "TblDistributionTransformer",
                column: "OwneroftheTransformerBPDBbsConsumer");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_PlatformMaterialAnglbsChannel",
                table: "TblDistributionTransformer",
                column: "PlatformMaterialAnglbsChannel");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_PlatformStandardbsNonStandardGoodBad",
                table: "TblDistributionTransformer",
                column: "PlatformStandardbsNonStandardGoodBad");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_TypeofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                column: "TypeofTransformerSupportPoleLeft");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_TypeofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                column: "TypeofTransformerSupportPoleRight");

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpBodyColourCondition_BodyColourCondition",
                table: "TblDistributionTransformer",
                column: "BodyColourCondition",
                principalTable: "LookUpBodyColourCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofDistributionBox",
                table: "TblDistributionTransformer",
                column: "ConditionofDistributionBox",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer",
                column: "ConditionofDropOutFuseBphase",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofDropOutFuseRphase",
                table: "TblDistributionTransformer",
                column: "ConditionofDropOutFuseRphase",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer",
                column: "ConditionofDropOutFuseYphase",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofHTDropGoodbsBad",
                table: "TblDistributionTransformer",
                column: "ConditionofHTDropGoodbsBad",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer",
                column: "ConditionofLTDropGoodbsBadCKT1",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLTDropGoodbsBadCKT2",
                table: "TblDistributionTransformer",
                column: "ConditionofLTDropGoodbsBadCKT2",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLightingArrestorBphase",
                table: "TblDistributionTransformer",
                column: "ConditionofLightingArrestorBphase",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLightingArrestorRphase",
                table: "TblDistributionTransformer",
                column: "ConditionofLightingArrestorRphase",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLightingArrestorYphase",
                table: "TblDistributionTransformer",
                column: "ConditionofLightingArrestorYphase",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofMCCBforCircuit1",
                table: "TblDistributionTransformer",
                column: "ConditionofMCCBforCircuit1",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofMCCBforCircuit2",
                table: "TblDistributionTransformer",
                column: "ConditionofMCCBforCircuit2",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpSupportPoleLeftRightCondition_ConditionofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                column: "ConditionofTransformerSupportPoleLeft",
                principalTable: "LookUpSupportPoleLeftRightCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpSupportPoleLeftRightCondition_ConditionofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                column: "ConditionofTransformerSupportPoleRight",
                principalTable: "LookUpSupportPoleLeftRightCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_EarthingLead1ConditionStandard",
                table: "TblDistributionTransformer",
                column: "EarthingLead1ConditionStandard",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_EarthingLead2ConditionStandard",
                table: "TblDistributionTransformer",
                column: "EarthingLead2ConditionStandard",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_HTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                column: "HTBushingNPhaseGood",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_HTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                column: "HTBushingRPhaseGood",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_HTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                column: "HTBushingYPhaseGood",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpInstalledCondition_InstalledConditionPadbsPoleMounted",
                table: "TblDistributionTransformer",
                column: "InstalledConditionPadbsPoleMounted",
                principalTable: "LookUpInstalledCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpInstalledPlace_InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer",
                column: "InstalledPlaceIndoorbsOutdoor",
                principalTable: "LookUpInstalledPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_LTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                column: "LTBushingBPhaseGood",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_LTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                column: "LTBushingNPhaseGood",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_LTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                column: "LTBushingRPhaseGood",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_LTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                column: "LTBushingYPhaseGood",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpTransformerOwner_OwneroftheTransformerBPDBbsConsumer",
                table: "TblDistributionTransformer",
                column: "OwneroftheTransformerBPDBbsConsumer",
                principalTable: "LookUpTransformerOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpPlatformMaterial_PlatformMaterialAnglbsChannel",
                table: "TblDistributionTransformer",
                column: "PlatformMaterialAnglbsChannel",
                principalTable: "LookUpPlatformMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_PlatformStandardbsNonStandardGoodBad",
                table: "TblDistributionTransformer",
                column: "PlatformStandardbsNonStandardGoodBad",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpSupportPoleLeftRightType_TypeofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                column: "TypeofTransformerSupportPoleLeft",
                principalTable: "LookUpSupportPoleLeftRightType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpSupportPoleLeftRightType_TypeofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                column: "TypeofTransformerSupportPoleRight",
                principalTable: "LookUpSupportPoleLeftRightType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpBodyColourCondition_BodyColourCondition",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofDistributionBox",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofDropOutFuseRphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofHTDropGoodbsBad",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLTDropGoodbsBadCKT2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLightingArrestorBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLightingArrestorRphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofLightingArrestorYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofMCCBforCircuit1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_ConditionofMCCBforCircuit2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpSupportPoleLeftRightCondition_ConditionofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpSupportPoleLeftRightCondition_ConditionofTransformerSupportPoleRight",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_EarthingLead1ConditionStandard",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_EarthingLead2ConditionStandard",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_HTBushingNPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_HTBushingRPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_HTBushingYPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpInstalledCondition_InstalledConditionPadbsPoleMounted",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpInstalledPlace_InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_LTBushingBPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_LTBushingNPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_LTBushingRPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_LTBushingYPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpTransformerOwner_OwneroftheTransformerBPDBbsConsumer",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpPlatformMaterial_PlatformMaterialAnglbsChannel",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_PlatformStandardbsNonStandardGoodBad",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpSupportPoleLeftRightType_TypeofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpSupportPoleLeftRightType_TypeofTransformerSupportPoleRight",
                table: "TblDistributionTransformer");

            migrationBuilder.DropTable(
                name: "LookUpBodyColourCondition");

            migrationBuilder.DropTable(
                name: "LookUpDtCondition");

            migrationBuilder.DropTable(
                name: "LookUpInstalledCondition");

            migrationBuilder.DropTable(
                name: "LookUpInstalledPlace");

            migrationBuilder.DropTable(
                name: "LookUpPlatformMaterial");

            migrationBuilder.DropTable(
                name: "LookUpSupportPoleLeftRightCondition");

            migrationBuilder.DropTable(
                name: "LookUpSupportPoleLeftRightType");

            migrationBuilder.DropTable(
                name: "LookUpTransformerOwner");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_BodyColourCondition",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofDistributionBox",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofDropOutFuseRphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofHTDropGoodbsBad",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofLTDropGoodbsBadCKT2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofLightingArrestorBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofLightingArrestorRphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofLightingArrestorYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofMCCBforCircuit1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofMCCBforCircuit2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_ConditionofTransformerSupportPoleRight",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_EarthingLead1ConditionStandard",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_EarthingLead2ConditionStandard",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_HTBushingNPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_HTBushingRPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_HTBushingYPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_InstalledConditionPadbsPoleMounted",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_LTBushingBPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_LTBushingNPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_LTBushingRPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_LTBushingYPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_OwneroftheTransformerBPDBbsConsumer",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_PlatformMaterialAnglbsChannel",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_PlatformStandardbsNonStandardGoodBad",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_TypeofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_TypeofTransformerSupportPoleRight",
                table: "TblDistributionTransformer");

            migrationBuilder.AlterColumn<string>(
                name: "TypeofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlatformStandardbsNonStandardGoodBad",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlatformMaterialAnglbsChannel",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwneroftheTransformerBPDBbsConsumer",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstalledConditionPadbsPoleMounted",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EarthingLead2ConditionStandard",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EarthingLead1ConditionStandard",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofMCCBforCircuit2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofMCCBforCircuit1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLightingArrestorYphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLightingArrestorRphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLightingArrestorBphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLTDropGoodbsBadCKT2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofHTDropGoodbsBad",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofDropOutFuseRphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConditionofDistributionBox",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BodyColourCondition",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoleStructureMountedSurgearrestorId",
                table: "TblDistributionTransformer",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_PoleStructureMountedSurgearrestorId",
                table: "TblDistributionTransformer",
                column: "PoleStructureMountedSurgearrestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_TblPoleStructureMountedSurgearrestor_PoleStructureMountedSurgearrestorId",
                table: "TblDistributionTransformer",
                column: "PoleStructureMountedSurgearrestorId",
                principalTable: "TblPoleStructureMountedSurgearrestor",
                principalColumn: "PoleStructureMountedSurgeArrestorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
