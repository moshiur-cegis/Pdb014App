using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateDistributionTransformer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MotorVoltageForSpringCharge",
                table: "TblDistributionTransformer",
                newName: "MotorVoltageforspringcharge");

            migrationBuilder.RenameColumn(
                name: "RatedLTCurrent",
                table: "TblDistributionTransformer",
                newName: "Rated LT Current");

            migrationBuilder.RenameColumn(
                name: "ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer",
                newName: "Condition of LT DropGoodbsBadCKT1");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "TblDistributionTransformer",
                newName: "YPhaseCurrentAmps2Ckt3");

            migrationBuilder.RenameColumn(
                name: "NearestHoldingOrHouseNoOrShop",
                table: "TblDistributionTransformer",
                newName: "YPhaseCurrentAmps2Ckt2");

            migrationBuilder.RenameColumn(
                name: "NameOf33bs11kVSubStation",
                table: "TblDistributionTransformer",
                newName: "YPhaseCurrentAmps2Ckt1");

            migrationBuilder.RenameColumn(
                name: "Material",
                table: "TblDistributionTransformer",
                newName: "YPhaseCurrentAmps1Ckt3");

            migrationBuilder.RenameColumn(
                name: "LightningArrestor ",
                table: "TblDistributionTransformer",
                newName: "YPhaseCurrentAmps1Ckt2");

            migrationBuilder.RenameColumn(
                name: "LTBushingY Phase",
                table: "TblDistributionTransformer",
                newName: "YPhaseCurrentAmps1Ckt1");

            migrationBuilder.RenameColumn(
                name: "LTBushingRPhase",
                table: "TblDistributionTransformer",
                newName: "YNVoltageVolt1");

            migrationBuilder.RenameColumn(
                name: "LTBushingNPhase",
                table: "TblDistributionTransformer",
                newName: "YNVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "LTBushingB Phase",
                table: "TblDistributionTransformer",
                newName: "YBVoltageVolt2");

            migrationBuilder.RenameColumn(
                name: "InstalledPlaceIndorOrOutdoor",
                table: "TblDistributionTransformer",
                newName: "YBVoltageVolt1");

            migrationBuilder.RenameColumn(
                name: "HTBushingYPhase",
                table: "TblDistributionTransformer",
                newName: "Voltage2 ");

            migrationBuilder.RenameColumn(
                name: "HTBushingNPhase",
                table: "TblDistributionTransformer",
                newName: "Voltage1 ");

            migrationBuilder.RenameColumn(
                name: "HTBushingBPhase",
                table: "TblDistributionTransformer",
                newName: "RatedVoltage");

            migrationBuilder.RenameColumn(
                name: "EveningPeakYPhaseCurrentAmps",
                table: "TblDistributionTransformer",
                newName: "RYVoltageVolt2");

            migrationBuilder.RenameColumn(
                name: "EveningPeakYNVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "RYVoltageVolt1");

            migrationBuilder.RenameColumn(
                name: "EveningPeakYBVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "RPhaseCurrentAmps2Ckt3");

            migrationBuilder.RenameColumn(
                name: "EveningPeakVoltage ",
                table: "TblDistributionTransformer",
                newName: "RPhaseCurrentAmps2Ckt2");

            migrationBuilder.RenameColumn(
                name: "EveningPeakRYVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "RPhaseCurrentAmps2Ckt1");

            migrationBuilder.RenameColumn(
                name: "EveningPeakRPhaseCurrentAmps",
                table: "TblDistributionTransformer",
                newName: "RPhaseCurrentAmps1Ckt3");

            migrationBuilder.RenameColumn(
                name: "EveningPeakRNVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "RPhaseCurrentAmps1Ckt2");

            migrationBuilder.RenameColumn(
                name: "EveningPeakRBVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "RPhaseCurrentAmps1Ckt1");

            migrationBuilder.RenameColumn(
                name: "EveningPeakNeutralCurrentAmps",
                table: "TblDistributionTransformer",
                newName: "RNVoltageVolt2");

            migrationBuilder.RenameColumn(
                name: "EveningPeakLeakageVoltageBodyEarthVolt",
                table: "TblDistributionTransformer",
                newName: "RNVoltageVolt1");

            migrationBuilder.RenameColumn(
                name: "EveningPeakDateAndTime",
                table: "TblDistributionTransformer",
                newName: "RBVoltageVolt2");

            migrationBuilder.RenameColumn(
                name: "EveningPeakCurrentsAmpsCkt3",
                table: "TblDistributionTransformer",
                newName: "RBVoltageVolt1");

            migrationBuilder.RenameColumn(
                name: "EveningPeakCurrentsAmpsCkt2",
                table: "TblDistributionTransformer",
                newName: "NeutralCurrentAmpsCkt1");

            migrationBuilder.RenameColumn(
                name: "EveningPeakCurrentsAmpsCkt1",
                table: "TblDistributionTransformer",
                newName: "NeutralCurrentAmps2Ckt3");

            migrationBuilder.RenameColumn(
                name: "EveningPeakCalculatedEveningPeakkVA",
                table: "TblDistributionTransformer",
                newName: "NeutralCurrentAmps2Ckt2");

            migrationBuilder.RenameColumn(
                name: "EveningPeakBPhaseCurrentAmps",
                table: "TblDistributionTransformer",
                newName: "NeutralCurrentAmps1Ckt3");

            migrationBuilder.RenameColumn(
                name: "DropOutFuseExistOrNotExistInYPhase",
                table: "TblDistributionTransformer",
                newName: "NeutralCurrentAmps1Ckt2");

            migrationBuilder.RenameColumn(
                name: "DropOutFuseExistOrNotExistInRPhase",
                table: "TblDistributionTransformer",
                newName: "NeutralCurrentAmps1Ckt1");

            migrationBuilder.RenameColumn(
                name: "DropOutFuseExistOrNotExistInBPhase",
                table: "TblDistributionTransformer",
                newName: "NearestHoldingbsHouseNobsShop");

            migrationBuilder.RenameColumn(
                name: "DayPeakYPhaseCurrentAmps",
                table: "TblDistributionTransformer",
                newName: "NameOf33bs11kVSubdsstation");

            migrationBuilder.RenameColumn(
                name: "DayPeakYNVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "LightningArrestorYphase ");

            migrationBuilder.RenameColumn(
                name: "DayPeak YBVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "LightningArrestorRphase ");

            migrationBuilder.RenameColumn(
                name: "DayPeakVoltage",
                table: "TblDistributionTransformer",
                newName: "LightningArrestorBphase ");

            migrationBuilder.RenameColumn(
                name: "DayPeakRYVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "LeakageVoltageBodyEarthVolt2");

            migrationBuilder.RenameColumn(
                name: "DayPeakRPhaseCurrentAmps",
                table: "TblDistributionTransformer",
                newName: "LeakageVoltageBodyEarthVolt1");

            migrationBuilder.RenameColumn(
                name: "DayPeakRNVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "LTBushingY PhaseOil");

            migrationBuilder.RenameColumn(
                name: "DayPeakRBVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "LTBushingY PhaseGood");

            migrationBuilder.RenameColumn(
                name: "DayPeakNeutralCurrentAmps",
                table: "TblDistributionTransformer",
                newName: "LTBushingY PhaseColor");

            migrationBuilder.RenameColumn(
                name: "DayPeakLeakageVoltageBodyEarthVolt",
                table: "TblDistributionTransformer",
                newName: "LTBushingRPhaseOil");

            migrationBuilder.RenameColumn(
                name: "DayPeakCurrentsAmpsCkt3",
                table: "TblDistributionTransformer",
                newName: "LTBushingRPhaseGood");

            migrationBuilder.RenameColumn(
                name: "DayPeakCurrentsAmpsCkt2",
                table: "TblDistributionTransformer",
                newName: "LTBushingRPhaseColor");

            migrationBuilder.RenameColumn(
                name: "DayPeakCurrentsAmpsCkt1",
                table: "TblDistributionTransformer",
                newName: "LTBushingNPhaseOil");

            migrationBuilder.RenameColumn(
                name: "DayPeakCalculatedDayPeakkVA",
                table: "TblDistributionTransformer",
                newName: "LTBushingNPhaseGood");

            migrationBuilder.RenameColumn(
                name: "DayPeakBPhaseCurrentAmps",
                table: "TblDistributionTransformer",
                newName: "LTBushingNPhaseColor");

            migrationBuilder.RenameColumn(
                name: "DayPeakBNVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "LTBushingB PhaseOil");

            migrationBuilder.RenameColumn(
                name: "DateAndtime",
                table: "TblDistributionTransformer",
                newName: "LTBushingB PhaseGood");

            migrationBuilder.RenameColumn(
                name: "CurrentTransformerRatedVoltage",
                table: "TblDistributionTransformer",
                newName: "LTBushingB PhaseColor");

            migrationBuilder.RenameColumn(
                name: "ConditionofLightingArrestor ",
                table: "TblDistributionTransformer",
                newName: "InstalledPlaceIndoorbsOutdoor");

            migrationBuilder.RenameColumn(
                name: "ConditionofDropOutFuse ",
                table: "TblDistributionTransformer",
                newName: "HTBushingYPhaseOil");

            migrationBuilder.RenameColumn(
                name: "ConditionStandardbsNonStandardbsGoodbsBad",
                table: "TblDistributionTransformer",
                newName: "HTBushingYPhaseGood");

            migrationBuilder.RenameColumn(
                name: "BushingRPhaseOilLeakage",
                table: "TblDistributionTransformer",
                newName: "HTBushingYPhaseColor");

            migrationBuilder.RenameColumn(
                name: "BushingRPhaseBushingColor",
                table: "TblDistributionTransformer",
                newName: "HTBushingRPhaseOil");

            migrationBuilder.RenameColumn(
                name: "BushingRPhaseBushing",
                table: "TblDistributionTransformer",
                newName: "HTBushingRPhaseGood");

            migrationBuilder.RenameColumn(
                name: "EveningPeakBNVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "HTBushingRPhaseColor");

            migrationBuilder.RenameColumn(
                name: "AmpereRatingpernameplateofMCCBforCKT2",
                table: "TblDistributionTransformer",
                newName: "HTBushingNPhaseOil");

            migrationBuilder.AddColumn<string>(
                name: "Ampere Rating as per name plate of MCCB forCKT2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BNVoltageVolt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BNVoltageVolt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BPhaseCurrentAmps1Ckt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BPhaseCurrentAmps1Ckt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BPhaseCurrentAmps1Ckt3",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BPhaseCurrentAmps2Ckt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BPhaseCurrentAmps2Ckt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BPhaseCurrentAmps2Ckt3",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalculatedDayPeakkVA",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalculatedEveningPeakkVA",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofDropOutFuse Rphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofLightingArrestorBphase ",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofLightingArrestorRphase ",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofLightingArrestorYphase ",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateAndTime2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateAndtime1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DropOutFuseExistbsNotExistBphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DropOutFuseExistbsNotExistRphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DropOutFuseExistbsNotExistYphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarthingLead1ConditionStandard",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarthingLead1Material",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarthingLead1Size",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarthingLead2 ",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarthingLead2ConditionStandard",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarthingLead2Material",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarthingLead2Size",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingBPhaseColor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingBPhaseOil",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingNPhaseColor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ampere Rating as per name plate of MCCB forCKT2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "BNVoltageVolt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "BNVoltageVolt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "BPhaseCurrentAmps1Ckt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "BPhaseCurrentAmps1Ckt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "BPhaseCurrentAmps1Ckt3",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "BPhaseCurrentAmps2Ckt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "BPhaseCurrentAmps2Ckt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "BPhaseCurrentAmps2Ckt3",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "CalculatedDayPeakkVA",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "CalculatedEveningPeakkVA",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofDropOutFuse Rphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofLightingArrestorBphase ",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofLightingArrestorRphase ",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofLightingArrestorYphase ",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DateAndTime2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DateAndtime1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DropOutFuseExistbsNotExistBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DropOutFuseExistbsNotExistRphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DropOutFuseExistbsNotExistYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "EarthingLead1ConditionStandard",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "EarthingLead1Material",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "EarthingLead1Size",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "EarthingLead2 ",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "EarthingLead2ConditionStandard",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "EarthingLead2Material",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "EarthingLead2Size",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingBPhaseColor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingBPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingBPhaseOil",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingNPhaseColor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingNPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.RenameColumn(
                name: "MotorVoltageforspringcharge",
                table: "TblDistributionTransformer",
                newName: "MotorVoltageForSpringCharge");

            migrationBuilder.RenameColumn(
                name: "Rated LT Current",
                table: "TblDistributionTransformer",
                newName: "RatedLTCurrent");

            migrationBuilder.RenameColumn(
                name: "Condition of LT DropGoodbsBadCKT1",
                table: "TblDistributionTransformer",
                newName: "ConditionofLTDropGoodbsBadCKT1");

            migrationBuilder.RenameColumn(
                name: "YPhaseCurrentAmps2Ckt3",
                table: "TblDistributionTransformer",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "YPhaseCurrentAmps2Ckt2",
                table: "TblDistributionTransformer",
                newName: "NearestHoldingOrHouseNoOrShop");

            migrationBuilder.RenameColumn(
                name: "YPhaseCurrentAmps2Ckt1",
                table: "TblDistributionTransformer",
                newName: "NameOf33bs11kVSubStation");

            migrationBuilder.RenameColumn(
                name: "YPhaseCurrentAmps1Ckt3",
                table: "TblDistributionTransformer",
                newName: "Material");

            migrationBuilder.RenameColumn(
                name: "YPhaseCurrentAmps1Ckt2",
                table: "TblDistributionTransformer",
                newName: "LightningArrestor ");

            migrationBuilder.RenameColumn(
                name: "YPhaseCurrentAmps1Ckt1",
                table: "TblDistributionTransformer",
                newName: "LTBushingY Phase");

            migrationBuilder.RenameColumn(
                name: "YNVoltageVolt1",
                table: "TblDistributionTransformer",
                newName: "LTBushingRPhase");

            migrationBuilder.RenameColumn(
                name: "YNVoltageVolt",
                table: "TblDistributionTransformer",
                newName: "LTBushingNPhase");

            migrationBuilder.RenameColumn(
                name: "YBVoltageVolt2",
                table: "TblDistributionTransformer",
                newName: "LTBushingB Phase");

            migrationBuilder.RenameColumn(
                name: "YBVoltageVolt1",
                table: "TblDistributionTransformer",
                newName: "InstalledPlaceIndorOrOutdoor");

            migrationBuilder.RenameColumn(
                name: "Voltage2 ",
                table: "TblDistributionTransformer",
                newName: "HTBushingYPhase");

            migrationBuilder.RenameColumn(
                name: "Voltage1 ",
                table: "TblDistributionTransformer",
                newName: "HTBushingNPhase");

            migrationBuilder.RenameColumn(
                name: "RatedVoltage",
                table: "TblDistributionTransformer",
                newName: "HTBushingBPhase");

            migrationBuilder.RenameColumn(
                name: "RYVoltageVolt2",
                table: "TblDistributionTransformer",
                newName: "EveningPeakYPhaseCurrentAmps");

            migrationBuilder.RenameColumn(
                name: "RYVoltageVolt1",
                table: "TblDistributionTransformer",
                newName: "EveningPeakYNVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "RPhaseCurrentAmps2Ckt3",
                table: "TblDistributionTransformer",
                newName: "EveningPeakYBVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "RPhaseCurrentAmps2Ckt2",
                table: "TblDistributionTransformer",
                newName: "EveningPeakVoltage ");

            migrationBuilder.RenameColumn(
                name: "RPhaseCurrentAmps2Ckt1",
                table: "TblDistributionTransformer",
                newName: "EveningPeakRYVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "RPhaseCurrentAmps1Ckt3",
                table: "TblDistributionTransformer",
                newName: "EveningPeakRPhaseCurrentAmps");

            migrationBuilder.RenameColumn(
                name: "RPhaseCurrentAmps1Ckt2",
                table: "TblDistributionTransformer",
                newName: "EveningPeakRNVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "RPhaseCurrentAmps1Ckt1",
                table: "TblDistributionTransformer",
                newName: "EveningPeakRBVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "RNVoltageVolt2",
                table: "TblDistributionTransformer",
                newName: "EveningPeakNeutralCurrentAmps");

            migrationBuilder.RenameColumn(
                name: "RNVoltageVolt1",
                table: "TblDistributionTransformer",
                newName: "EveningPeakLeakageVoltageBodyEarthVolt");

            migrationBuilder.RenameColumn(
                name: "RBVoltageVolt2",
                table: "TblDistributionTransformer",
                newName: "EveningPeakDateAndTime");

            migrationBuilder.RenameColumn(
                name: "RBVoltageVolt1",
                table: "TblDistributionTransformer",
                newName: "EveningPeakCurrentsAmpsCkt3");

            migrationBuilder.RenameColumn(
                name: "NeutralCurrentAmpsCkt1",
                table: "TblDistributionTransformer",
                newName: "EveningPeakCurrentsAmpsCkt2");

            migrationBuilder.RenameColumn(
                name: "NeutralCurrentAmps2Ckt3",
                table: "TblDistributionTransformer",
                newName: "EveningPeakCurrentsAmpsCkt1");

            migrationBuilder.RenameColumn(
                name: "NeutralCurrentAmps2Ckt2",
                table: "TblDistributionTransformer",
                newName: "EveningPeakCalculatedEveningPeakkVA");

            migrationBuilder.RenameColumn(
                name: "NeutralCurrentAmps1Ckt3",
                table: "TblDistributionTransformer",
                newName: "EveningPeakBPhaseCurrentAmps");

            migrationBuilder.RenameColumn(
                name: "NeutralCurrentAmps1Ckt2",
                table: "TblDistributionTransformer",
                newName: "DropOutFuseExistOrNotExistInYPhase");

            migrationBuilder.RenameColumn(
                name: "NeutralCurrentAmps1Ckt1",
                table: "TblDistributionTransformer",
                newName: "DropOutFuseExistOrNotExistInRPhase");

            migrationBuilder.RenameColumn(
                name: "NearestHoldingbsHouseNobsShop",
                table: "TblDistributionTransformer",
                newName: "DropOutFuseExistOrNotExistInBPhase");

            migrationBuilder.RenameColumn(
                name: "NameOf33bs11kVSubdsstation",
                table: "TblDistributionTransformer",
                newName: "DayPeakYPhaseCurrentAmps");

            migrationBuilder.RenameColumn(
                name: "LightningArrestorYphase ",
                table: "TblDistributionTransformer",
                newName: "DayPeakYNVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "LightningArrestorRphase ",
                table: "TblDistributionTransformer",
                newName: "DayPeak YBVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "LightningArrestorBphase ",
                table: "TblDistributionTransformer",
                newName: "DayPeakVoltage");

            migrationBuilder.RenameColumn(
                name: "LeakageVoltageBodyEarthVolt2",
                table: "TblDistributionTransformer",
                newName: "DayPeakRYVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "LeakageVoltageBodyEarthVolt1",
                table: "TblDistributionTransformer",
                newName: "DayPeakRPhaseCurrentAmps");

            migrationBuilder.RenameColumn(
                name: "LTBushingY PhaseOil",
                table: "TblDistributionTransformer",
                newName: "DayPeakRNVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "LTBushingY PhaseGood",
                table: "TblDistributionTransformer",
                newName: "DayPeakRBVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "LTBushingY PhaseColor",
                table: "TblDistributionTransformer",
                newName: "DayPeakNeutralCurrentAmps");

            migrationBuilder.RenameColumn(
                name: "LTBushingRPhaseOil",
                table: "TblDistributionTransformer",
                newName: "DayPeakLeakageVoltageBodyEarthVolt");

            migrationBuilder.RenameColumn(
                name: "LTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                newName: "DayPeakCurrentsAmpsCkt3");

            migrationBuilder.RenameColumn(
                name: "LTBushingRPhaseColor",
                table: "TblDistributionTransformer",
                newName: "DayPeakCurrentsAmpsCkt2");

            migrationBuilder.RenameColumn(
                name: "LTBushingNPhaseOil",
                table: "TblDistributionTransformer",
                newName: "DayPeakCurrentsAmpsCkt1");

            migrationBuilder.RenameColumn(
                name: "LTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                newName: "DayPeakCalculatedDayPeakkVA");

            migrationBuilder.RenameColumn(
                name: "LTBushingNPhaseColor",
                table: "TblDistributionTransformer",
                newName: "DayPeakBPhaseCurrentAmps");

            migrationBuilder.RenameColumn(
                name: "LTBushingB PhaseOil",
                table: "TblDistributionTransformer",
                newName: "DayPeakBNVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "LTBushingB PhaseGood",
                table: "TblDistributionTransformer",
                newName: "DateAndtime");

            migrationBuilder.RenameColumn(
                name: "LTBushingB PhaseColor",
                table: "TblDistributionTransformer",
                newName: "CurrentTransformerRatedVoltage");

            migrationBuilder.RenameColumn(
                name: "InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer",
                newName: "ConditionofLightingArrestor ");

            migrationBuilder.RenameColumn(
                name: "HTBushingYPhaseOil",
                table: "TblDistributionTransformer",
                newName: "ConditionofDropOutFuse ");

            migrationBuilder.RenameColumn(
                name: "HTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                newName: "ConditionStandardbsNonStandardbsGoodbsBad");

            migrationBuilder.RenameColumn(
                name: "HTBushingYPhaseColor",
                table: "TblDistributionTransformer",
                newName: "BushingRPhaseOilLeakage");

            migrationBuilder.RenameColumn(
                name: "HTBushingRPhaseOil",
                table: "TblDistributionTransformer",
                newName: "BushingRPhaseBushingColor");

            migrationBuilder.RenameColumn(
                name: "HTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                newName: "BushingRPhaseBushing");

            migrationBuilder.RenameColumn(
                name: "HTBushingRPhaseColor",
                table: "TblDistributionTransformer",
                newName: "EveningPeakBNVoltageVolt");

            migrationBuilder.RenameColumn(
                name: "HTBushingNPhaseOil",
                table: "TblDistributionTransformer",
                newName: "AmpereRatingpernameplateofMCCBforCKT2");
        }
    }
}
