using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateSwitchGear2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookupBusBar_BusBarId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpCurrentTransformer_CurrentTransformerId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_TblRelay_RelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookupSf6SafetyAndLife_Sf6SafetyAndLifeId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpSwitchGearUnit_SwitchGearUnitId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpSwitchPosition_SwitchPositionId",
                table: "TblSwitchGear");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitchGear_RelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitchGear_SwitchGearUnitId",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "RelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "SwitchGearUnitId",
                table: "TblSwitchGear");

            migrationBuilder.AlterColumn<int>(
                name: "SwitchPositionId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Sf6SafetyAndLifeId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentTransformerId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BusBarId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AcWithStandVoltageDry",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmpereMeterId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppliedStandard",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DimensionAndWeightId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Enclosure",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HvCompartment",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdmtRelayId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImpulseWithStandFullWave",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LvCompartment",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturersNameAndAddress",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedCurrentForMainBus",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedNominalVoltage",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedShortTimeCurrent",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedVoltage",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReatedCurrent",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReatedShortCircuitBreakerCurrent",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReatedVoltage",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortTimeCurrentRatedDuration",
                table: "TblSwitchGear",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripCircuitSupervisionRelayId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripRelayId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoltMeterId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_AmpereMeterId",
                table: "TblSwitchGear",
                column: "AmpereMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_DimensionAndWeightId",
                table: "TblSwitchGear",
                column: "DimensionAndWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_IdmtRelayId",
                table: "TblSwitchGear",
                column: "IdmtRelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_TripCircuitSupervisionRelayId",
                table: "TblSwitchGear",
                column: "TripCircuitSupervisionRelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_TripRelayId",
                table: "TblSwitchGear",
                column: "TripRelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_VoltMeterId",
                table: "TblSwitchGear",
                column: "VoltMeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentMeter_AmpereMeterId",
                table: "TblSwitchGear",
                column: "AmpereMeterId",
                principalTable: "LookUpDifferentMeter",
                principalColumn: "DifferentMeterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookupBusBar_BusBarId",
                table: "TblSwitchGear",
                column: "BusBarId",
                principalTable: "LookupBusBar",
                principalColumn: "BusBarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpCurrentTransformer_CurrentTransformerId",
                table: "TblSwitchGear",
                column: "CurrentTransformerId",
                principalTable: "LookUpCurrentTransformer",
                principalColumn: "CurrentTransformerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpDimensionAndWeight_DimensionAndWeightId",
                table: "TblSwitchGear",
                column: "DimensionAndWeightId",
                principalTable: "LookUpDimensionAndWeight",
                principalColumn: "DimensionAndWeightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentRelay_IdmtRelayId",
                table: "TblSwitchGear",
                column: "IdmtRelayId",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookupSf6SafetyAndLife_Sf6SafetyAndLifeId",
                table: "TblSwitchGear",
                column: "Sf6SafetyAndLifeId",
                principalTable: "LookupSf6SafetyAndLife",
                principalColumn: "Sf6SafetyAndLifeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpSwitchPosition_SwitchPositionId",
                table: "TblSwitchGear",
                column: "SwitchPositionId",
                principalTable: "LookUpSwitchPosition",
                principalColumn: "SwitchPositionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentRelay_TripCircuitSupervisionRelayId",
                table: "TblSwitchGear",
                column: "TripCircuitSupervisionRelayId",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentRelay_TripRelayId",
                table: "TblSwitchGear",
                column: "TripRelayId",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentMeter_VoltMeterId",
                table: "TblSwitchGear",
                column: "VoltMeterId",
                principalTable: "LookUpDifferentMeter",
                principalColumn: "DifferentMeterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentMeter_AmpereMeterId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookupBusBar_BusBarId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpCurrentTransformer_CurrentTransformerId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpDimensionAndWeight_DimensionAndWeightId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentRelay_IdmtRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookupSf6SafetyAndLife_Sf6SafetyAndLifeId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpSwitchPosition_SwitchPositionId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentRelay_TripCircuitSupervisionRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentRelay_TripRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpDifferentMeter_VoltMeterId",
                table: "TblSwitchGear");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitchGear_AmpereMeterId",
                table: "TblSwitchGear");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitchGear_DimensionAndWeightId",
                table: "TblSwitchGear");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitchGear_IdmtRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitchGear_TripCircuitSupervisionRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitchGear_TripRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitchGear_VoltMeterId",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "AcWithStandVoltageDry",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "AmpereMeterId",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "AppliedStandard",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "DimensionAndWeightId",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "Enclosure",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "HvCompartment",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "IdmtRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "ImpulseWithStandFullWave",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "LvCompartment",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "ManufacturersNameAndAddress",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "RatedCurrentForMainBus",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "RatedNominalVoltage",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "RatedShortTimeCurrent",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "RatedVoltage",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "ReatedCurrent",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "ReatedShortCircuitBreakerCurrent",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "ReatedVoltage",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "ShortTimeCurrentRatedDuration",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "TripCircuitSupervisionRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "TripRelayId",
                table: "TblSwitchGear");

            migrationBuilder.DropColumn(
                name: "VoltMeterId",
                table: "TblSwitchGear");

            migrationBuilder.AlterColumn<int>(
                name: "SwitchPositionId",
                table: "TblSwitchGear",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Sf6SafetyAndLifeId",
                table: "TblSwitchGear",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentTransformerId",
                table: "TblSwitchGear",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BusBarId",
                table: "TblSwitchGear",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelayId",
                table: "TblSwitchGear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SwitchGearUnitId",
                table: "TblSwitchGear",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_RelayId",
                table: "TblSwitchGear",
                column: "RelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_SwitchGearUnitId",
                table: "TblSwitchGear",
                column: "SwitchGearUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookupBusBar_BusBarId",
                table: "TblSwitchGear",
                column: "BusBarId",
                principalTable: "LookupBusBar",
                principalColumn: "BusBarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpCurrentTransformer_CurrentTransformerId",
                table: "TblSwitchGear",
                column: "CurrentTransformerId",
                principalTable: "LookUpCurrentTransformer",
                principalColumn: "CurrentTransformerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_TblRelay_RelayId",
                table: "TblSwitchGear",
                column: "RelayId",
                principalTable: "TblRelay",
                principalColumn: "RelayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookupSf6SafetyAndLife_Sf6SafetyAndLifeId",
                table: "TblSwitchGear",
                column: "Sf6SafetyAndLifeId",
                principalTable: "LookupSf6SafetyAndLife",
                principalColumn: "Sf6SafetyAndLifeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpSwitchGearUnit_SwitchGearUnitId",
                table: "TblSwitchGear",
                column: "SwitchGearUnitId",
                principalTable: "LookUpSwitchGearUnit",
                principalColumn: "SwitchGearUnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpSwitchPosition_SwitchPositionId",
                table: "TblSwitchGear",
                column: "SwitchPositionId",
                principalTable: "LookUpSwitchPosition",
                principalColumn: "SwitchPositionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
