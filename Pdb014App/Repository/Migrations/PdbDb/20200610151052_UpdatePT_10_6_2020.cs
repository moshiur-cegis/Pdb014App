using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePT_10_6_2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPhasePowerTransformer_TblSubstation_Source132or33kVSubstationId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblPhasePowerTransformer_Source132or33kVSubstationId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "ACWithStandVoltage",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "AtMaximumTap",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "AtMinimumTap",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "AtNominalTap",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "BushingCTParticulars",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "ConservatorWithAirSealedBagForConstantOilPressurYesNo",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "CopperLossAtfullloadAtRatedFrequencyAndAt75CFullLoadLoss",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "DimensionsAndWeightMaximumSizeForTransport",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "EleventKv",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "HVBushing",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "HVBushingType",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "HVside",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "ImpulseWithStandFullWave",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "LMulWMulH",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "Source132or33kVSubstationId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.RenameColumn(
                name: "WeightofCore",
                table: "TblPhasePowerTransformer",
                newName: "TransformeNeutralBushingType");

            migrationBuilder.RenameColumn(
                name: "WeightOFoil",
                table: "TblPhasePowerTransformer",
                newName: "TransformeNeutralBushing");

            migrationBuilder.RenameColumn(
                name: "TransformerBushings",
                table: "TblPhasePowerTransformer",
                newName: "TransformeLVBushingType");

            migrationBuilder.RenameColumn(
                name: "TotalWeight",
                table: "TblPhasePowerTransformer",
                newName: "TransformeLVBushing");

            migrationBuilder.RenameColumn(
                name: "ThirtyThreeKv",
                table: "TblPhasePowerTransformer",
                newName: "TransformeHVBushingType");

            migrationBuilder.RenameColumn(
                name: "TemperatureIndicatorsYesNo",
                table: "TblPhasePowerTransformer",
                newName: "TransformeHVBushing");

            migrationBuilder.RenameColumn(
                name: "SupervisoryAlarmAndTripContactsYesNo",
                table: "TblPhasePowerTransformer",
                newName: "ShortCircuitLevelAtTerminalThirtyThreeKv");

            migrationBuilder.RenameColumn(
                name: "ShortCircuitLevelAtTerminal",
                table: "TblPhasePowerTransformer",
                newName: "ShortCircuitLevelAtTerminalEleventKv");

            migrationBuilder.RenameColumn(
                name: "RadiatorsYesNo",
                table: "TblPhasePowerTransformer",
                newName: "DimensionsAndWeightTransportLMulWMulH");

            migrationBuilder.RenameColumn(
                name: "NeutralSide",
                table: "TblPhasePowerTransformer",
                newName: "CopperLossAtNominalTap");

            migrationBuilder.RenameColumn(
                name: "NeutralBushingType",
                table: "TblPhasePowerTransformer",
                newName: "CopperLossAtMinimumTap");

            migrationBuilder.RenameColumn(
                name: "NeutralBushing",
                table: "TblPhasePowerTransformer",
                newName: "CopperLossAtMaximumTap");

            migrationBuilder.RenameColumn(
                name: "LVside",
                table: "TblPhasePowerTransformer",
                newName: "BushingCTParticularsNeutralSide");

            migrationBuilder.RenameColumn(
                name: "LVBushingType",
                table: "TblPhasePowerTransformer",
                newName: "BushingCTParticularsLVside");

            migrationBuilder.RenameColumn(
                name: "LVBushing",
                table: "TblPhasePowerTransformer",
                newName: "BushingCTParticularsHVside");

            migrationBuilder.AlterColumn<decimal>(
                name: "WindingByResistanceMeasurement",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TemperatureRiseAtRatedPowerMaxAmbientTemperature40C",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TemperatureGradientBetweenWindingsAndOil",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TappingRangeHT",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SixPointSixMva",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SanctionedLoad",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RatingOfFanMotors",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RatedInsulationLevel",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RatedFrequency",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OneStepChange",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OilVolume",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OilByThermometer",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPhase",
                table: "TblPhasePowerTransformer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfCoolingFan",
                table: "TblPhasePowerTransformer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NoOfRadiators",
                table: "TblPhasePowerTransformer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NoOfContacts",
                table: "TblPhasePowerTransformer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MotorRating",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumLoad",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ImpulseLowVoltageWinding",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ImpulseHighVoltageWinding",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ImpedanceVoltageAt75CAndAtNominalRatio",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FiveMva",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ControlVoltage",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AuxiliaryCircuitVoltageForFanetc3P4W",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ACLowVoltageWinding",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ACHighVoltageWinding",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ConservatorWithAirSealedBagForConstantOilPressur",
                table: "TblPhasePowerTransformer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "DimensionsAndWeightTransportTotalWeight",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DimensionsAndWeightTransportWeightOFoil",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DimensionsAndWeightTransportWeightofCore",
                table: "TblPhasePowerTransformer",
                type: "decimal(10, 2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Radiators",
                table: "TblPhasePowerTransformer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupervisoryAlarmAndTripContacts",
                table: "TblPhasePowerTransformer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TemperatureIndicators",
                table: "TblPhasePowerTransformer",
                nullable: false,
                defaultValue: false);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConservatorWithAirSealedBagForConstantOilPressur",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "DimensionsAndWeightTransportTotalWeight",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "DimensionsAndWeightTransportWeightOFoil",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "DimensionsAndWeightTransportWeightofCore",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "Radiators",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "SupervisoryAlarmAndTripContacts",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "TemperatureIndicators",
                table: "TblPhasePowerTransformer");

            migrationBuilder.RenameColumn(
                name: "TransformeNeutralBushingType",
                table: "TblPhasePowerTransformer",
                newName: "WeightofCore");

            migrationBuilder.RenameColumn(
                name: "TransformeNeutralBushing",
                table: "TblPhasePowerTransformer",
                newName: "WeightOFoil");

            migrationBuilder.RenameColumn(
                name: "TransformeLVBushingType",
                table: "TblPhasePowerTransformer",
                newName: "TransformerBushings");

            migrationBuilder.RenameColumn(
                name: "TransformeLVBushing",
                table: "TblPhasePowerTransformer",
                newName: "TotalWeight");

            migrationBuilder.RenameColumn(
                name: "TransformeHVBushingType",
                table: "TblPhasePowerTransformer",
                newName: "ThirtyThreeKv");

            migrationBuilder.RenameColumn(
                name: "TransformeHVBushing",
                table: "TblPhasePowerTransformer",
                newName: "TemperatureIndicatorsYesNo");

            migrationBuilder.RenameColumn(
                name: "ShortCircuitLevelAtTerminalThirtyThreeKv",
                table: "TblPhasePowerTransformer",
                newName: "SupervisoryAlarmAndTripContactsYesNo");

            migrationBuilder.RenameColumn(
                name: "ShortCircuitLevelAtTerminalEleventKv",
                table: "TblPhasePowerTransformer",
                newName: "ShortCircuitLevelAtTerminal");

            migrationBuilder.RenameColumn(
                name: "DimensionsAndWeightTransportLMulWMulH",
                table: "TblPhasePowerTransformer",
                newName: "RadiatorsYesNo");

            migrationBuilder.RenameColumn(
                name: "CopperLossAtNominalTap",
                table: "TblPhasePowerTransformer",
                newName: "NeutralSide");

            migrationBuilder.RenameColumn(
                name: "CopperLossAtMinimumTap",
                table: "TblPhasePowerTransformer",
                newName: "NeutralBushingType");

            migrationBuilder.RenameColumn(
                name: "CopperLossAtMaximumTap",
                table: "TblPhasePowerTransformer",
                newName: "NeutralBushing");

            migrationBuilder.RenameColumn(
                name: "BushingCTParticularsNeutralSide",
                table: "TblPhasePowerTransformer",
                newName: "LVside");

            migrationBuilder.RenameColumn(
                name: "BushingCTParticularsLVside",
                table: "TblPhasePowerTransformer",
                newName: "LVBushingType");

            migrationBuilder.RenameColumn(
                name: "BushingCTParticularsHVside",
                table: "TblPhasePowerTransformer",
                newName: "LVBushing");

            migrationBuilder.AlterColumn<string>(
                name: "WindingByResistanceMeasurement",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TemperatureRiseAtRatedPowerMaxAmbientTemperature40C",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TemperatureGradientBetweenWindingsAndOil",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TappingRangeHT",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SixPointSixMva",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SanctionedLoad",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RatingOfFanMotors",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RatedInsulationLevel",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RatedFrequency",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OneStepChange",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OilVolume",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OilByThermometer",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPhase",
                table: "TblPhasePowerTransformer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumberOfCoolingFan",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoOfRadiators",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoOfContacts",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MotorRating",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaximumLoad",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImpulseLowVoltageWinding",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImpulseHighVoltageWinding",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImpedanceVoltageAt75CAndAtNominalRatio",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FiveMva",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ControlVoltage",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuxiliaryCircuitVoltageForFanetc3P4W",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ACLowVoltageWinding",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ACHighVoltageWinding",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ACWithStandVoltage",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtMaximumTap",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtMinimumTap",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtNominalTap",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BushingCTParticulars",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConservatorWithAirSealedBagForConstantOilPressurYesNo",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopperLossAtfullloadAtRatedFrequencyAndAt75CFullLoadLoss",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DimensionsAndWeightMaximumSizeForTransport",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EleventKv",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HVBushing",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HVBushingType",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HVside",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImpulseWithStandFullWave",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LMulWMulH",
                table: "TblPhasePowerTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source132or33kVSubstationId",
                table: "TblPhasePowerTransformer",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPhasePowerTransformer_Source132or33kVSubstationId",
                table: "TblPhasePowerTransformer",
                column: "Source132or33kVSubstationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPhasePowerTransformer_TblSubstation_Source132or33kVSubstationId",
                table: "TblPhasePowerTransformer",
                column: "Source132or33kVSubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
