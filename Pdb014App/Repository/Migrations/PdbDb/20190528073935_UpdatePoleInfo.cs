using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePoleInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseAId",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseBId",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseCId",
                table: "TblPole");

            migrationBuilder.RenameColumn(
                name: "TypeOfCooling28or35MVA",
                table: "TblPhasePowerTransformer",
                newName: "TypeOfCooling28Or35MVA");

            migrationBuilder.RenameColumn(
                name: "ShortCircuitlevelAtTerminal",
                table: "TblPhasePowerTransformer",
                newName: "ShortCircuitLevelAtTerminal");

            migrationBuilder.RenameColumn(
                name: "NumberofPhase",
                table: "TblPhasePowerTransformer",
                newName: "NumberOfPhase");

            migrationBuilder.AlterColumn<string>(
                name: "PhaseCId",
                table: "TblPole",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "PhaseBId",
                table: "TblPole",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "PhaseAId",
                table: "TblPole",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddColumn<string>(
                name: "CommonPole",
                table: "TblPole",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineTypeId",
                table: "TblPole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfWireHt",
                table: "TblPole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfWireLt",
                table: "TblPole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tap",
                table: "TblPole",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransformerExist",
                table: "TblPole",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type Of Wire",
                table: "TblPole",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfWireId",
                table: "TblPole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WireConditionId",
                table: "TblPole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WireLength",
                table: "TblPole",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfSet",
                table: "TblInsulatorShackleOrGuy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShackleOrGuyConditionId",
                table: "TblInsulatorShackleOrGuy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PinPostConditionId",
                table: "TblInsulatorPinAndPost",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TblInsulatorPinAndPost",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsulatorDiskConditionId",
                table: "TblInsulatorDisk",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FittingsConditionId",
                table: "TblCrossArm",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfSetFittings",
                table: "TblCrossArm",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfFittingsId",
                table: "TblCrossArm",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LookUpCondition",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpCondition", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LookUpLineType",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpLineType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LookUpTypeOfFittings",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpTypeOfFittings", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LookUpTypeOfWire",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpTypeOfWire", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_LineTypeId",
                table: "TblPole",
                column: "LineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_Type Of Wire",
                table: "TblPole",
                column: "Type Of Wire");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_WireConditionId",
                table: "TblPole",
                column: "WireConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorShackleOrGuy_ShackleOrGuyConditionId",
                table: "TblInsulatorShackleOrGuy",
                column: "ShackleOrGuyConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorPinAndPost_PinPostConditionId",
                table: "TblInsulatorPinAndPost",
                column: "PinPostConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorDisk_InsulatorDiskConditionId",
                table: "TblInsulatorDisk",
                column: "InsulatorDiskConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArm_FittingsConditionId",
                table: "TblCrossArm",
                column: "FittingsConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArm_TypeOfFittingsId",
                table: "TblCrossArm",
                column: "TypeOfFittingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCrossArm_LookUpCondition_FittingsConditionId",
                table: "TblCrossArm",
                column: "FittingsConditionId",
                principalTable: "LookUpCondition",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblCrossArm_LookUpTypeOfFittings_TypeOfFittingsId",
                table: "TblCrossArm",
                column: "TypeOfFittingsId",
                principalTable: "LookUpTypeOfFittings",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblInsulatorDisk_LookUpCondition_InsulatorDiskConditionId",
                table: "TblInsulatorDisk",
                column: "InsulatorDiskConditionId",
                principalTable: "LookUpCondition",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblInsulatorPinAndPost_LookUpCondition_PinPostConditionId",
                table: "TblInsulatorPinAndPost",
                column: "PinPostConditionId",
                principalTable: "LookUpCondition",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblInsulatorShackleOrGuy_LookUpCondition_ShackleOrGuyConditionId",
                table: "TblInsulatorShackleOrGuy",
                column: "ShackleOrGuyConditionId",
                principalTable: "LookUpCondition",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpLineType_LineTypeId",
                table: "TblPole",
                column: "LineTypeId",
                principalTable: "LookUpLineType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseAId",
                table: "TblPole",
                column: "PhaseAId",
                principalTable: "LookUpSagCondition",
                principalColumn: "SagConditionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseBId",
                table: "TblPole",
                column: "PhaseBId",
                principalTable: "LookUpSagCondition",
                principalColumn: "SagConditionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseCId",
                table: "TblPole",
                column: "PhaseCId",
                principalTable: "LookUpSagCondition",
                principalColumn: "SagConditionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpTypeOfWire_Type Of Wire",
                table: "TblPole",
                column: "Type Of Wire",
                principalTable: "LookUpTypeOfWire",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpCondition_WireConditionId",
                table: "TblPole",
                column: "WireConditionId",
                principalTable: "LookUpCondition",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCrossArm_LookUpCondition_FittingsConditionId",
                table: "TblCrossArm");

            migrationBuilder.DropForeignKey(
                name: "FK_TblCrossArm_LookUpTypeOfFittings_TypeOfFittingsId",
                table: "TblCrossArm");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInsulatorDisk_LookUpCondition_InsulatorDiskConditionId",
                table: "TblInsulatorDisk");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInsulatorPinAndPost_LookUpCondition_PinPostConditionId",
                table: "TblInsulatorPinAndPost");

            migrationBuilder.DropForeignKey(
                name: "FK_TblInsulatorShackleOrGuy_LookUpCondition_ShackleOrGuyConditionId",
                table: "TblInsulatorShackleOrGuy");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpLineType_LineTypeId",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseAId",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseBId",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseCId",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpTypeOfWire_Type Of Wire",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpCondition_WireConditionId",
                table: "TblPole");

            migrationBuilder.DropTable(
                name: "LookUpCondition");

            migrationBuilder.DropTable(
                name: "LookUpLineType");

            migrationBuilder.DropTable(
                name: "LookUpTypeOfFittings");

            migrationBuilder.DropTable(
                name: "LookUpTypeOfWire");

            migrationBuilder.DropIndex(
                name: "IX_TblPole_LineTypeId",
                table: "TblPole");

            migrationBuilder.DropIndex(
                name: "IX_TblPole_Type Of Wire",
                table: "TblPole");

            migrationBuilder.DropIndex(
                name: "IX_TblPole_WireConditionId",
                table: "TblPole");

            migrationBuilder.DropIndex(
                name: "IX_TblInsulatorShackleOrGuy_ShackleOrGuyConditionId",
                table: "TblInsulatorShackleOrGuy");

            migrationBuilder.DropIndex(
                name: "IX_TblInsulatorPinAndPost_PinPostConditionId",
                table: "TblInsulatorPinAndPost");

            migrationBuilder.DropIndex(
                name: "IX_TblInsulatorDisk_InsulatorDiskConditionId",
                table: "TblInsulatorDisk");

            migrationBuilder.DropIndex(
                name: "IX_TblCrossArm_FittingsConditionId",
                table: "TblCrossArm");

            migrationBuilder.DropIndex(
                name: "IX_TblCrossArm_TypeOfFittingsId",
                table: "TblCrossArm");

            migrationBuilder.DropColumn(
                name: "CommonPole",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "LineTypeId",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "NoOfWireHt",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "NoOfWireLt",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "Tap",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "TransformerExist",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "Type Of Wire",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "TypeOfWireId",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "WireConditionId",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "WireLength",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "NoOfSet",
                table: "TblInsulatorShackleOrGuy");

            migrationBuilder.DropColumn(
                name: "ShackleOrGuyConditionId",
                table: "TblInsulatorShackleOrGuy");

            migrationBuilder.DropColumn(
                name: "PinPostConditionId",
                table: "TblInsulatorPinAndPost");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TblInsulatorPinAndPost");

            migrationBuilder.DropColumn(
                name: "InsulatorDiskConditionId",
                table: "TblInsulatorDisk");

            migrationBuilder.DropColumn(
                name: "FittingsConditionId",
                table: "TblCrossArm");

            migrationBuilder.DropColumn(
                name: "NoOfSetFittings",
                table: "TblCrossArm");

            migrationBuilder.DropColumn(
                name: "TypeOfFittingsId",
                table: "TblCrossArm");

            migrationBuilder.RenameColumn(
                name: "TypeOfCooling28Or35MVA",
                table: "TblPhasePowerTransformer",
                newName: "TypeOfCooling28or35MVA");

            migrationBuilder.RenameColumn(
                name: "ShortCircuitLevelAtTerminal",
                table: "TblPhasePowerTransformer",
                newName: "ShortCircuitlevelAtTerminal");

            migrationBuilder.RenameColumn(
                name: "NumberOfPhase",
                table: "TblPhasePowerTransformer",
                newName: "NumberofPhase");

            migrationBuilder.AlterColumn<string>(
                name: "PhaseCId",
                table: "TblPole",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhaseBId",
                table: "TblPole",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhaseAId",
                table: "TblPole",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseAId",
                table: "TblPole",
                column: "PhaseAId",
                principalTable: "LookUpSagCondition",
                principalColumn: "SagConditionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseBId",
                table: "TblPole",
                column: "PhaseBId",
                principalTable: "LookUpSagCondition",
                principalColumn: "SagConditionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpSagCondition_PhaseCId",
                table: "TblPole",
                column: "PhaseCId",
                principalTable: "LookUpSagCondition",
                principalColumn: "SagConditionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
