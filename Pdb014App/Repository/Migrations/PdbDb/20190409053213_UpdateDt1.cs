using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateDt1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AmpereRatingasPerNamePlateofMCCBforCKT1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AmpereRatingasPerNameplateOfMCCBForCKT2",
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
                name: "BodyColourCondition",
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
                name: "ConditionofDistributionBox",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofDropOutFuseRphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofHTDropGoodbsBad",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofLTDropGoodbsBadCKT2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofLightingArrestorBphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofLightingArrestorRphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofLightingArrestorYphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofMCCBforCircuit1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofMCCBforCircuit2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConditionofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractNo",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControlVoltage",
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
                name: "DayPeak",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistributionBoxExistbsnotExist",
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
                name: "EarthingLead1",
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
                name: "EarthingLead2",
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
                name: "EveningPeak",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExistingPoleNumberingifAny",
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

            migrationBuilder.AddColumn<string>(
                name: "HTBushingNPhaseOil",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingRPhaseColor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingRPhaseOil",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingYPhaseColor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTBushingYPhaseOil",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstalledConditionPadbsPoleMounted",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingBPhaseColor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingBPhaseOil",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingNPhaseColor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingNPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingNPhaseOil",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingRPhaseColor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingRPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingRPhaseOil",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingYPhaseColor",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingYPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LTBushingYPhaseOil",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeakageVoltageBodyEarthVolt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeakageVoltageBodyEarthVolt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LightningArrestorBphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LightningArrestorRphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LightningArrestorYphase",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerTypeOriginofMCCBforCircuit1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerTypeOriginofMCCBforCircuit2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorVoltageforspringcharge",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOf33bs11kVSubdsstation",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameoBodyColour",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nameof11kVFeeder",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameofManufacturer",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NearestHoldingbsHouseNobsShop",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeutralCurrentAmps1Ckt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeutralCurrentAmps1Ckt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeutralCurrentAmps1Ckt3",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeutralCurrentAmps2Ckt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeutralCurrentAmps2Ckt3",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeutralCurrentAmpsCkt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoOfMCCB",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OilLeakageYesOrNo",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwneroftheTransformerBPDBbsConsumer",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceofOilLeakageMark",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlatformMaterialAnglbsChannel",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlatformStandardbsNonStandardGoodBad",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RBVoltageVolt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RBVoltageVolt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RNVoltageVolt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RNVoltageVolt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RPhaseCurrentAmps1Ckt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RPhaseCurrentAmps1Ckt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RPhaseCurrentAmps1Ckt3",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RPhaseCurrentAmps2Ckt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RPhaseCurrentAmps2Ckt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RPhaseCurrentAmps2Ckt3",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RYVoltageVolt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RYVoltageVolt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedHTCurrent",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedHTVoltage",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedLTCurrent",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedLTVoltage",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RatedVoltage",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SNDIdentificationNo",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransformerKVARating",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransformerSerialNo",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeofTransformerSupportPoleRight",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voltage1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Voltage2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WireSizeofHTDrop",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WirebsCableSizeofLTDropCKT1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WirebsCableSizeofLTDropCKT2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YBVoltageVolt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YBVoltageVolt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YNVoltageVolt",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YNVoltageVolt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YPhaseCurrentAmps1Ckt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YPhaseCurrentAmps1Ckt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YPhaseCurrentAmps1Ckt3",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YPhaseCurrentAmps2Ckt1",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YPhaseCurrentAmps2Ckt2",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YPhaseCurrentAmps2Ckt3",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearOfManufacturing",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmpereRatingasPerNamePlateofMCCBforCKT1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "AmpereRatingasPerNameplateOfMCCBForCKT2",
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
                name: "BodyColourCondition",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "CalculatedDayPeakkVA",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "CalculatedEveningPeakkVA",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofDistributionBox",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofDropOutFuseBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofDropOutFuseRphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofDropOutFuseYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofHTDropGoodbsBad",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofLTDropGoodbsBadCKT1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofLTDropGoodbsBadCKT2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofLightingArrestorBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofLightingArrestorRphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofLightingArrestorYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofMCCBforCircuit1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofMCCBforCircuit2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ConditionofTransformerSupportPoleRight",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ContractNo",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ControlVoltage",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DateAndTime2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DateAndtime1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DayPeak",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "DistributionBoxExistbsnotExist",
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
                name: "EarthingLead1",
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
                name: "EarthingLead2",
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
                name: "EveningPeak",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ExistingPoleNumberingifAny",
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

            migrationBuilder.DropColumn(
                name: "HTBushingNPhaseOil",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingRPhaseColor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingRPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingRPhaseOil",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingYPhaseColor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingYPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "HTBushingYPhaseOil",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "InstalledConditionPadbsPoleMounted",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "InstalledPlaceIndoorbsOutdoor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingBPhaseColor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingBPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingBPhaseOil",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingNPhaseColor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingNPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingNPhaseOil",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingRPhaseColor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingRPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingRPhaseOil",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingYPhaseColor",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingYPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LTBushingYPhaseOil",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LeakageVoltageBodyEarthVolt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LeakageVoltageBodyEarthVolt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LightningArrestorBphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LightningArrestorRphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "LightningArrestorYphase",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ManufacturerTypeOriginofMCCBforCircuit1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "ManufacturerTypeOriginofMCCBforCircuit2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "MotorVoltageforspringcharge",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NameOf33bs11kVSubdsstation",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NameoBodyColour",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "Nameof11kVFeeder",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NameofManufacturer",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NearestHoldingbsHouseNobsShop",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NeutralCurrentAmps1Ckt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NeutralCurrentAmps1Ckt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NeutralCurrentAmps1Ckt3",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NeutralCurrentAmps2Ckt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NeutralCurrentAmps2Ckt3",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NeutralCurrentAmpsCkt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "NoOfMCCB",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "OilLeakageYesOrNo",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "OwneroftheTransformerBPDBbsConsumer",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "PlaceofOilLeakageMark",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "PlatformMaterialAnglbsChannel",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "PlatformStandardbsNonStandardGoodBad",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RBVoltageVolt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RBVoltageVolt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RNVoltageVolt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RNVoltageVolt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RPhaseCurrentAmps1Ckt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RPhaseCurrentAmps1Ckt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RPhaseCurrentAmps1Ckt3",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RPhaseCurrentAmps2Ckt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RPhaseCurrentAmps2Ckt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RPhaseCurrentAmps2Ckt3",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RYVoltageVolt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RYVoltageVolt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RatedHTCurrent",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RatedHTVoltage",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RatedLTCurrent",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RatedLTVoltage",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "RatedVoltage",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "SNDIdentificationNo",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "TransformerKVARating",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "TransformerSerialNo",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "TypeofTransformerSupportPoleLeft",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "TypeofTransformerSupportPoleRight",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "Voltage1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "Voltage2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "WireSizeofHTDrop",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "WirebsCableSizeofLTDropCKT1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "WirebsCableSizeofLTDropCKT2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YBVoltageVolt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YBVoltageVolt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YNVoltageVolt",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YNVoltageVolt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YPhaseCurrentAmps1Ckt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YPhaseCurrentAmps1Ckt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YPhaseCurrentAmps1Ckt3",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YPhaseCurrentAmps2Ckt1",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YPhaseCurrentAmps2Ckt2",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YPhaseCurrentAmps2Ckt3",
                table: "TblDistributionTransformer");

            migrationBuilder.DropColumn(
                name: "YearOfManufacturing",
                table: "TblDistributionTransformer");
        }
    }
}
