using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUpAacInsulatorType",
                columns: table => new
                {
                    AacInsulatorTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AacInsulatorTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpAacInsulatorType", x => x.AacInsulatorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookupAnnuciator",
                columns: table => new
                {
                    LookupAnnuciatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Annunciator = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturesName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CountryofOrigin = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturesModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupAnnuciator", x => x.LookupAnnuciatorId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpAutoCircuitReCloserType",
                columns: table => new
                {
                    AutoCircuitReCloserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoCircuitReCloserTypeIdName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpAutoCircuitReCloserType", x => x.AutoCircuitReCloserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookupBusBar",
                columns: table => new
                {
                    BusBarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusBarType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CrossSection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Accessories = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CableConnection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    VoltageTransformer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SurgeArrester = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupBusBar", x => x.BusBarId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCircuitBreaker",
                columns: table => new
                {
                    CircuitBreakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OperatingCycle = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedShortCktBreakingCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedShortCktMakingCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedBreakingTime = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OpeningTime = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ClosingTime = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedOperatingSequence = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ControlVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MotorVoltageForSpringCharge = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ThreePositionDisconnectorSwitch = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Type2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltage2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedCurrent2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SwitchPositions = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ElectricalAndMechanicalInterlock = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpCircuitBreaker", x => x.CircuitBreakerId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpConductorType",
                columns: table => new
                {
                    ConductorTypeId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ConductorTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpConductorType", x => x.ConductorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookupControlSwitch",
                columns: table => new
                {
                    ControlSwitchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControlSwitch = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturesNameCountry = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturesModelTypeNo = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupControlSwitch", x => x.ControlSwitchId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCopperCablesType",
                columns: table => new
                {
                    CopperCablesTypeId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CopperCablesTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpCopperCablesType", x => x.CopperCablesTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCurrentTransformer",
                columns: table => new
                {
                    CurrentTransformerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AccuracyClassMetering = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AccuracyClassOCEFProtection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AccuracyClassDifferentialProtection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedCurrentRatio = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Burden = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpCurrentTransformer", x => x.CurrentTransformerId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpDifferentTypesOfMeter",
                columns: table => new
                {
                    MeterTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeterTypeName = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpDifferentTypesOfMeter", x => x.MeterTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpDifferentTypesOfRelay",
                columns: table => new
                {
                    RelayTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelayTypeName = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpDifferentTypesOfRelay", x => x.RelayTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpDimensionAndWeight",
                columns: table => new
                {
                    DimensionAndWeightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Height = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Width = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Depth = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WeightIncludingCircuitBreaker = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpDimensionAndWeight", x => x.DimensionAndWeightId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpFeederLineType",
                columns: table => new
                {
                    FeederLineTypeId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FeederLineTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpFeederLineType", x => x.FeederLineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpInsulatorDiskType",
                columns: table => new
                {
                    InsulatorDiskTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsulatorDiskTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpInsulatorDiskType", x => x.InsulatorDiskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpInsulatorPinAndPostType",
                columns: table => new
                {
                    InsulatorPinAndPostTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsulatorPinAndPostTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpInsulatorPinAndPostType", x => x.InsulatorPinAndPostTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpInsulatorShackleOrGuyType",
                columns: table => new
                {
                    InsulatorShackleOrGuyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsulatorShackleOrGuyTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpInsulatorShackleOrGuyType", x => x.InsulatorShackleOrGuyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpPoleCondition",
                columns: table => new
                {
                    PoleConditionId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpPoleCondition", x => x.PoleConditionId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpPoleType",
                columns: table => new
                {
                    PoleTypeId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpPoleType", x => x.PoleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSagCondition",
                columns: table => new
                {
                    SagConditionId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSagCondition", x => x.SagConditionId);
                });

            migrationBuilder.CreateTable(
                name: "LookupSf6SafetyAndLife",
                columns: table => new
                {
                    Sf6SafetyAndLifeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SF6Pressure = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedPressureAt20C = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MinimumfunctionalpressureAt20C = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BurstingPressure = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    GasLeakageRate = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SafetyIndication = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CapacitiveVoltageIndicatorEUJapanUSAOrigin = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    GasPressureManometer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BusBarGasPressureManometer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LifeEnduranceOfSwitchgear = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CircuitBreakers = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DisconnectorsAndEarthingSwitches = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupSf6SafetyAndLife", x => x.Sf6SafetyAndLifeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSpecificationsOfMountBracketType",
                columns: table => new
                {
                    SpecificationsOfMountBracketTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecificationsOfMountBracketTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSpecificationsOfMountBracketType", x => x.SpecificationsOfMountBracketTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSubstationType",
                columns: table => new
                {
                    SubstationTypeId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SubstationTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSubstationType", x => x.SubstationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSwitchGearType",
                columns: table => new
                {
                    SwitchGearTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SwitchGearTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSwitchGearType", x => x.SwitchGearTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSwitchGearUnit",
                columns: table => new
                {
                    SwitchGearUnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManufacturersNameAndAddress = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AppliedStandard = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedNominalVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedCurrentForMainBus = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedShortTimeCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ShortTimeCurrentRatedDuration = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSwitchGearUnit", x => x.SwitchGearUnitId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSwitchPosition",
                columns: table => new
                {
                    SwitchPositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElectricalAndMechanicalInterlock = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CurrentTransformer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AccuracyClassMetering = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AccuracyClassOCEFProtection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedCurrentRatio = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Burden = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSwitchPosition", x => x.SwitchPositionId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpZoneInfo",
                columns: table => new
                {
                    ZoneCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ZoneName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SortingNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpZoneInfo", x => x.ZoneCode);
                });

            migrationBuilder.CreateTable(
                name: "TblPoleStructureMountedSurgearrestor",
                columns: table => new
                {
                    PoleStructureMountedSurgeArrestorId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Standard = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Installation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeorModel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Construction = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Application = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalRatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumSystemVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SystemFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeofSystem = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedArresterVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedArresterCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HighCurrentWithstand = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PressureReliefClass = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BasicInsulationlevelBILat12or50MicroSecImpulses = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LightningImpulseResidualVoltageAt8or20MicrosecCurrentWave = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CreepageDistance = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPoleStructureMountedSurgearrestor", x => x.PoleStructureMountedSurgeArrestorId);
                });

            migrationBuilder.CreateTable(
                name: "TblRelay",
                columns: table => new
                {
                    RelayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelayName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NominalVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ManufactureName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModelNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RatedCurrent = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RatedVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ConnectionStatus = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FeederLineId = table.Column<int>(type: "int", nullable: false),
                    SubstationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRelay", x => x.RelayId);
                });

            migrationBuilder.CreateTable(
                name: "TblSurgeArrestor",
                columns: table => new
                {
                    SurgeArrestorId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ManufacturersNameAndAddress = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ClassOfDiverterToIEC99To4 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltageRMSkV30 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NeutralConnection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PowerFreqWithstandVoltageOfHousing = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Dry = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Wet = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Impulse = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LightingImpulseResidualVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SteepCurrentImpulseResidualVoltageAt10kAOr1MicrosFrontTime = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HighCurrentImpulseWithStandValue4Or10MicroS = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SwitchingImpulseResidentialVoltage50Or100MicroS = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PressureReliefDeviceFitted = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TemporaryOverVoltageCapability = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PointOneSeconds = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OneSecond = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TenSeconds = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HunderdSeconds = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LeakageCurrentatRatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MinimumResetVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TotalCreepageDistance = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SurgeMonitor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConnectingLeadfromLATerminaltoSurgeMonitor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OverallDimensionandWeight = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Diameter = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TotalWeightofArrester = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSurgeArrestor", x => x.SurgeArrestorId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpTerminationKits",
                columns: table => new
                {
                    TerminationKitsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusBarId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_LookUpTerminationKits", x => x.TerminationKitsId);
                    table.ForeignKey(
                        name: "FK_LookUpTerminationKits_LookupBusBar_BusBarId",
                        column: x => x.BusBarId,
                        principalTable: "LookupBusBar",
                        principalColumn: "BusBarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookUpDifferentMeter",
                columns: table => new
                {
                    DifferentMeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeterName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersNameandCountry = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturesModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeOfMeter = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ClassOfAccuracy = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SeparateAmeterforEachPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MeterTypeId = table.Column<int>(type: "int", nullable: false),
                    RelayTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpDifferentMeter", x => x.DifferentMeterId);
                    table.ForeignKey(
                        name: "FK_LookUpDifferentMeter_LookUpDifferentTypesOfMeter_RelayTypeId",
                        column: x => x.RelayTypeId,
                        principalTable: "LookUpDifferentTypesOfMeter",
                        principalColumn: "MeterTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpDifferentRelay",
                columns: table => new
                {
                    DifferentRelayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManufacturersName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RelayTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpDifferentRelay", x => x.DifferentRelayId);
                    table.ForeignKey(
                        name: "FK_LookUpDifferentRelay_LookUpDifferentTypesOfRelay_RelayTypeId",
                        column: x => x.RelayTypeId,
                        principalTable: "LookUpDifferentTypesOfRelay",
                        principalColumn: "RelayTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookUpCircleInfo",
                columns: table => new
                {
                    CircleCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CircleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SortingNo = table.Column<int>(type: "int", nullable: true),
                    ZoneCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpCircleInfo", x => x.CircleCode);
                    table.ForeignKey(
                        name: "FK_LookUpCircleInfo_LookUpZoneInfo_ZoneCode",
                        column: x => x.ZoneCode,
                        principalTable: "LookUpZoneInfo",
                        principalColumn: "ZoneCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSnDInfo",
                columns: table => new
                {
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SnDName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SortingNo = table.Column<int>(type: "int", nullable: true),
                    CircleCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSnDInfo", x => x.SnDCode);
                    table.ForeignKey(
                        name: "FK_LookUpSnDInfo_LookUpCircleInfo_CircleCode",
                        column: x => x.CircleCode,
                        principalTable: "LookUpCircleInfo",
                        principalColumn: "CircleCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblSubstation",
                columns: table => new
                {
                    SubstationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SubstationTypeId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SubstrationName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    NominalVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstalledCapacity = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MaximumDemand = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PeakLoad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AreaOfSubstation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    YearOfComissioning = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSubstation", x => x.SubstationId);
                    table.ForeignKey(
                        name: "FK_TblSubstation_LookUpSnDInfo_SnDCode",
                        column: x => x.SnDCode,
                        principalTable: "LookUpSnDInfo",
                        principalColumn: "SnDCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblSubstation_LookUpSubstationType_SubstationTypeId",
                        column: x => x.SubstationTypeId,
                        principalTable: "LookUpSubstationType",
                        principalColumn: "SubstationTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpAuxiliaryTransformer",
                columns: table => new
                {
                    AuxiliaryTransformerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubstationId = table.Column<int>(type: "int", nullable: true),
                    LookUpAuxiliaryTransformer_SubstationId = table.Column<string>(nullable: true),
                    ManufacturersNameAndAddress = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersTypeAndModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    KVARating = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NumberOfPhases = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedFrequencyHz = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedPrimaryvoltageKV = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedNoloadsecVoltageV = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    VectorGroup = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HighestSystemVoltageof = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PrimaryWindingKV = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SecondaryWindingKv = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BasicInsulationLevelKV = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PowerFrequencyWithstandVoltageKV = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HTSide = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LTSide = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeOfCooling = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaxTempRiseover40CofambientSupportedByCalculation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WindingdegC = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TopOildegC = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeofPrimaryTappingOffload = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PercentageImpedanceAt75C = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoloadLossWatts = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LoadLossesAtRatedFullLoadAt75CWatts = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TotalWeightOfOilKg = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpAuxiliaryTransformer", x => x.AuxiliaryTransformerId);
                    table.ForeignKey(
                        name: "FK_LookUpAuxiliaryTransformer_TblSubstation_LookUpAuxiliaryTransformer_SubstationId",
                        column: x => x.LookUpAuxiliaryTransformer_SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpBatteryCharger",
                columns: table => new
                {
                    BatteryChargerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubstationId = table.Column<int>(type: "int", nullable: true),
                    LookUpBatteryCharger_SubstationId = table.Column<string>(nullable: true),
                    ManufacturersNameAndCompany = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedInputVoltageRange = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoOfPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalOutputVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ChargingOperatingControl = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OutputCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ContinuousCurrentRating = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Efficiency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    VoltageRegulation = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpBatteryCharger", x => x.BatteryChargerId);
                    table.ForeignKey(
                        name: "FK_LookUpBatteryCharger_TblSubstation_LookUpBatteryCharger_SubstationId",
                        column: x => x.LookUpBatteryCharger_SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpNiCdBattery110vDc",
                columns: table => new
                {
                    NiCdBattery110vDcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubstationId = table.Column<int>(type: "int", nullable: true),
                    LookUpNiCdBattery110vDc_SubstationId = table.Column<string>(nullable: true),
                    ManufacturersNameAndAddress = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OperatingVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NumberOfCells = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    VoltagePerCell = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpNiCdBattery110vDc", x => x.NiCdBattery110vDcId);
                    table.ForeignKey(
                        name: "FK_LookUpNiCdBattery110vDc_TblSubstation_LookUpNiCdBattery110vDc_SubstationId",
                        column: x => x.LookUpNiCdBattery110vDc_SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpRouteInfo",
                columns: table => new
                {
                    RouteCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    RouteName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SortingNo = table.Column<int>(type: "int", nullable: true),
                    SubstationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpRouteInfo", x => x.RouteCode);
                    table.ForeignKey(
                        name: "FK_LookUpRouteInfo_TblSubstation_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblAutoCircuitReCloser",
                columns: table => new
                {
                    AutoCircuitReCloserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoCircuitReCloserTypeId = table.Column<int>(type: "int", nullable: true),
                    SubstationId = table.Column<int>(type: "int", nullable: true),
                    TblAutoCircuitReCloser_SubstationId = table.Column<string>(nullable: true),
                    ManufacturersNameAddress = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeOfModel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InterruptingMedium = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HermeticallySealed = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ControlSystemforACR = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InsulatingMedium = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalSystemVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InsulationLevel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImpulseWithstandVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PowerFrequencyWithstandVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedContinuousCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumRatedCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedShortCircuitCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SymmetricalInterruptingCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AsymmetricalInterrupting = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SymmetricalMakinoCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ShortTimewithstandCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ProtectionAndMeterningCTration = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    GasPressureIndicator = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAutoCircuitReCloser", x => x.AutoCircuitReCloserId);
                    table.ForeignKey(
                        name: "FK_TblAutoCircuitReCloser_LookUpAutoCircuitReCloserType_AutoCircuitReCloserTypeId",
                        column: x => x.AutoCircuitReCloserTypeId,
                        principalTable: "LookUpAutoCircuitReCloserType",
                        principalColumn: "AutoCircuitReCloserTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblAutoCircuitReCloser_TblSubstation_TblAutoCircuitReCloser_SubstationId",
                        column: x => x.TblAutoCircuitReCloser_SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblMeteringPanel",
                columns: table => new
                {
                    MeteringPanelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubstationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ManufacturersNameCountryOfOrigin = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SystemNominalVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumSystemVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DifferentialRelayIdForTransformer = table.Column<int>(type: "int", nullable: true),
                    RestrictedEarthFaultRelayIdForTransformer = table.Column<int>(type: "int", nullable: true),
                    IdmtOverCurrentAndEarthFaultRelayIdForTransformer = table.Column<int>(type: "int", nullable: true),
                    AuxiliaryFlagRelayIdForTransformer = table.Column<int>(type: "int", nullable: true),
                    TripCircuitSupervisionRelayIdForTransformer = table.Column<int>(type: "int", nullable: true),
                    TripRelayIdForTransformer = table.Column<int>(type: "int", nullable: true),
                    AnnuciatorIdForTransformer = table.Column<int>(type: "int", nullable: true),
                    ControlSwitchIdForTransformer = table.Column<int>(type: "int", nullable: true),
                    IdmtOverCurrentAndEarthFaultRelayIdForFeeder = table.Column<int>(type: "int", nullable: true),
                    IdmtOverCurrentAndEarthFaultRelayId = table.Column<int>(nullable: true),
                    TripCircuitSupervisionRelayIdForFeeder = table.Column<int>(type: "int", nullable: true),
                    TripCircuitSupervisionRelayId = table.Column<int>(nullable: true),
                    TripRelayIdForFeeder = table.Column<int>(type: "int", nullable: true),
                    TripRelayId = table.Column<int>(nullable: true),
                    AnnuciatorIdForFeeder = table.Column<int>(type: "int", nullable: true),
                    ControlSwitchIdForFeeder = table.Column<int>(type: "int", nullable: true),
                    ControlSwitchId = table.Column<int>(nullable: true),
                    KWHandkVARHMeterId = table.Column<int>(type: "int", nullable: true),
                    VoltMeterId = table.Column<int>(type: "int", nullable: true),
                    AmpereMeterId = table.Column<int>(type: "int", nullable: true),
                    MegaWattMeterId = table.Column<int>(type: "int", nullable: true),
                    MegaVarMeterId = table.Column<int>(type: "int", nullable: true),
                    DimensionAndWeightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMeteringPanel", x => x.MeteringPanelId);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentMeter_AmpereMeterId",
                        column: x => x.AmpereMeterId,
                        principalTable: "LookUpDifferentMeter",
                        principalColumn: "DifferentMeterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookupAnnuciator_AnnuciatorIdForFeeder",
                        column: x => x.AnnuciatorIdForFeeder,
                        principalTable: "LookupAnnuciator",
                        principalColumn: "LookupAnnuciatorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookupAnnuciator_AnnuciatorIdForTransformer",
                        column: x => x.AnnuciatorIdForTransformer,
                        principalTable: "LookupAnnuciator",
                        principalColumn: "LookupAnnuciatorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_AuxiliaryFlagRelayIdForTransformer",
                        column: x => x.AuxiliaryFlagRelayIdForTransformer,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookupControlSwitch_ControlSwitchId",
                        column: x => x.ControlSwitchId,
                        principalTable: "LookupControlSwitch",
                        principalColumn: "ControlSwitchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookupControlSwitch_ControlSwitchIdForTransformer",
                        column: x => x.ControlSwitchIdForTransformer,
                        principalTable: "LookupControlSwitch",
                        principalColumn: "ControlSwitchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_DifferentialRelayIdForTransformer",
                        column: x => x.DifferentialRelayIdForTransformer,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDimensionAndWeight_DimensionAndWeightId",
                        column: x => x.DimensionAndWeightId,
                        principalTable: "LookUpDimensionAndWeight",
                        principalColumn: "DimensionAndWeightId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_IdmtOverCurrentAndEarthFaultRelayId",
                        column: x => x.IdmtOverCurrentAndEarthFaultRelayId,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_IdmtOverCurrentAndEarthFaultRelayIdForTransformer",
                        column: x => x.IdmtOverCurrentAndEarthFaultRelayIdForTransformer,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentMeter_KWHandkVARHMeterId",
                        column: x => x.KWHandkVARHMeterId,
                        principalTable: "LookUpDifferentMeter",
                        principalColumn: "DifferentMeterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentMeter_MegaVarMeterId",
                        column: x => x.MegaVarMeterId,
                        principalTable: "LookUpDifferentMeter",
                        principalColumn: "DifferentMeterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentMeter_MegaWattMeterId",
                        column: x => x.MegaWattMeterId,
                        principalTable: "LookUpDifferentMeter",
                        principalColumn: "DifferentMeterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_RestrictedEarthFaultRelayIdForTransformer",
                        column: x => x.RestrictedEarthFaultRelayIdForTransformer,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_TblSubstation_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripCircuitSupervisionRelayId",
                        column: x => x.TripCircuitSupervisionRelayId,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripCircuitSupervisionRelayIdForTransformer",
                        column: x => x.TripCircuitSupervisionRelayIdForTransformer,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripRelayId",
                        column: x => x.TripRelayId,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripRelayIdForTransformer",
                        column: x => x.TripRelayIdForTransformer,
                        principalTable: "LookUpDifferentRelay",
                        principalColumn: "DifferentRelayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblMeteringPanel_LookUpDifferentMeter_VoltMeterId",
                        column: x => x.VoltMeterId,
                        principalTable: "LookUpDifferentMeter",
                        principalColumn: "DifferentMeterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblOutDoorTypeVacumnCircuitBreaker",
                columns: table => new
                {
                    OutDoorTypeVacumnCircuitBreakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubstationId = table.Column<int>(type: "int", nullable: true),
                    TblOutDoorTypeVacumnCircuitBreaker_SubstationId = table.Column<string>(nullable: true),
                    ManufacturersNameCountry = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumRatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedNormalCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoOfPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoOfBreakPerPhrase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InterruptingMedium = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImpulseWithstandOn1250MsWave = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PowerFrequencyTestVoltageDryAt50Hz1Min = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ShortTimeWithstandCurrent3SecondRms = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SymmetricalRms = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AsymmetricalRms = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ShortCircuitMakingCurrentPeak = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TripCoilCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TripCoilVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OpeningTimeWithoutCurrentAt100OfRatedBreakingcurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BreakingTime = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ClosingTime = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltageofSpringWindingMotorforClosing = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SpringWindingMotorCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ClosingReleaseCoilCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ClosingReleaseCoilVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoOfTrippingCoil = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CircuitBreakerTerminalConnectors = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PressureInVacuumTubeforVCB = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AtRatedCurrentSwitching = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AtShortCircuitCurrentSwitching = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedOperatingSequence = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOutDoorTypeVacumnCircuitBreaker", x => x.OutDoorTypeVacumnCircuitBreakerId);
                    table.ForeignKey(
                        name: "FK_TblOutDoorTypeVacumnCircuitBreaker_TblSubstation_TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                        column: x => x.TblOutDoorTypeVacumnCircuitBreaker_SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblSubstationPicture",
                columns: table => new
                {
                    SubstrationPictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubstationId = table.Column<int>(type: "int", nullable: true),
                    TblSubstationPicture_SubstationId = table.Column<string>(nullable: true),
                    PictureName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PictureLocation = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSubstationPicture", x => x.SubstrationPictureId);
                    table.ForeignKey(
                        name: "FK_TblSubstationPicture_TblSubstation_TblSubstationPicture_SubstationId",
                        column: x => x.TblSubstationPicture_SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblSwitch33KvIsolator",
                columns: table => new
                {
                    Switch33KvIsolatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubstationId = table.Column<int>(type: "int", nullable: true),
                    TblSwitch33KvIsolator_SubstationId = table.Column<string>(nullable: true),
                    TypeIsolatorSwitch = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SwitchID = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BreakingType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufactureMonthAndYear = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InstallationDate = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NormalStatus = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConnectionStatus = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SwitchNo = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSwitch33KvIsolator", x => x.Switch33KvIsolatorId);
                    table.ForeignKey(
                        name: "FK_TblSwitch33KvIsolator_TblSubstation_TblSwitch33KvIsolator_SubstationId",
                        column: x => x.TblSwitch33KvIsolator_SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblFeederLine",
                columns: table => new
                {
                    FeederLineId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FeederLineUId = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FeederLineTypeId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RouteCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FeederName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FeederLocation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FeedermeterNumber = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MeterCurrentRating = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MeterVoltageRating = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumDemand = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PeakDemand = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumLoad = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SanctionedLoad = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFeederLine", x => x.FeederLineId);
                    table.ForeignKey(
                        name: "FK_TblFeederLine_LookUpFeederLineType_FeederLineTypeId",
                        column: x => x.FeederLineTypeId,
                        principalTable: "LookUpFeederLineType",
                        principalColumn: "FeederLineTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblFeederLine_LookUpRouteInfo_RouteCode",
                        column: x => x.RouteCode,
                        principalTable: "LookUpRouteInfo",
                        principalColumn: "RouteCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblPhasePowerTransformer",
                columns: table => new
                {
                    PhasePowerTransformerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SurgeArrestorId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SubstationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FeederLineId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ManufacturersName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersAddress = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AppliedStandard = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DescriptionType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedPower = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NumberOfPhase = table.Column<int>(type: "int", nullable: false),
                    RatedVoltagePhaseToPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HighVoltageWindingPhaseToPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LowVoltageWindingPhaseToPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedInsulationLevel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImpulseWithStandFullWave = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImpulseHighVoltageWinding = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImpulseLowVoltageWinding = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ACWithStandVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ACHighVoltageWinding = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ACLowVoltageWinding = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeOfCooling28or35MVA = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OnLoadTapChanger = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeTap = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TappingRangeHT = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LocationOfTap = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OilVolume = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OneStepChange = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MotorRating = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImpedanceVoltageAt75CAndAtNominalRatio = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TemperatureRiseAtRatedPowerMaxAmbientTemperature40C = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FiveMva = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SixPointSixMva = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OilByThermometer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WindingByResistanceMeasurement = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TemperatureGradientBetweenWindingsAndOil = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ShortCircuitlevelAtTerminal = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ThirtyThreeKv = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EleventKv = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TransformerCore = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeOfCoreAndFluxEnsityAtNominalVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TransformerBushings = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HVBushing = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HVBushingType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LVBushing = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LVBushingType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NeutralBushing = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NeutralBushingType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConservatorWithAirSealedBagForConstantOilPressurYesNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BreatherSilicagel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AuxiliaryCircuitVoltageForFanetc3P4W = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ControlVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SoundLevelIEC551 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ONAN = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ONAF = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BushingCTParticulars = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HVside = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LVside = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NeutralSide = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NumberOfCoolingFan = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatingOfFanMotors = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CoolingFanLossesAtFullOnafCapacityOperation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CoreLossAtRatedFrequencyAndRatedVoltageAtNominalTapNoLoadLoss = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CopperLossAtfullloadAtRatedFrequencyAndAt75CFullLoadLoss = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AtMaximumTap = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AtNominalTap = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AtMinimumTap = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RadiatorsYesNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OverallDimensions = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoOfRadiators = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SupervisoryAlarmAndTripContactsYesNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TemperatureIndicatorsYesNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MakeAndType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AlarmAndTripRange = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoOfContacts = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CurrentRatingOfContacts = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SupervisoryAlarmContact = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DimensionsAndWeightMaximumSizeForTransport = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LMulWMulH = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WeightOFoil = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WeightofCore = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TotalWeight = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FeederID33KvId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SanctionedLoad = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumLoad = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Source132or33kVSubstationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPhasePowerTransformer", x => x.PhasePowerTransformerId);
                    table.ForeignKey(
                        name: "FK_TblPhasePowerTransformer_TblFeederLine_FeederID33KvId",
                        column: x => x.FeederID33KvId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPhasePowerTransformer_TblFeederLine_FeederLineId",
                        column: x => x.FeederLineId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPhasePowerTransformer_TblSubstation_Source132or33kVSubstationId",
                        column: x => x.Source132or33kVSubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPhasePowerTransformer_TblSubstation_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "TblSubstation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPhasePowerTransformer_TblSurgeArrestor_SurgeArrestorId",
                        column: x => x.SurgeArrestorId,
                        principalTable: "TblSurgeArrestor",
                        principalColumn: "SurgeArrestorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblPole",
                columns: table => new
                {
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PoleUid = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FeederLineUid = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SurveyDate = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RouteCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FeederLineId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SurveyorName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PoleNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PreviousPoleNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PoleTypeId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    PoleConditionId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    BackSpan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MSJNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SleeveNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TwistNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhaseAId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    PhaseBId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    PhaseCId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true),
                    Neutral = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StreetLight = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SourceCableId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TargetCableId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPole", x => x.PoleId);
                    table.ForeignKey(
                        name: "FK_TblPole_TblFeederLine_FeederLineId",
                        column: x => x.FeederLineId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_LookUpSagCondition_PhaseAId",
                        column: x => x.PhaseAId,
                        principalTable: "LookUpSagCondition",
                        principalColumn: "SagConditionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_LookUpSagCondition_PhaseBId",
                        column: x => x.PhaseBId,
                        principalTable: "LookUpSagCondition",
                        principalColumn: "SagConditionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_LookUpSagCondition_PhaseCId",
                        column: x => x.PhaseCId,
                        principalTable: "LookUpSagCondition",
                        principalColumn: "SagConditionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_LookUpPoleCondition_PoleConditionId",
                        column: x => x.PoleConditionId,
                        principalTable: "LookUpPoleCondition",
                        principalColumn: "PoleConditionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_LookUpPoleType_PoleTypeId",
                        column: x => x.PoleTypeId,
                        principalTable: "LookUpPoleType",
                        principalColumn: "PoleTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_TblPole_PreviousPoleNo",
                        column: x => x.PreviousPoleNo,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_LookUpRouteInfo_RouteCode",
                        column: x => x.RouteCode,
                        principalTable: "LookUpRouteInfo",
                        principalColumn: "RouteCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_TblFeederLine_SourceCableId",
                        column: x => x.SourceCableId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPole_TblFeederLine_TargetCableId",
                        column: x => x.TargetCableId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblSwitchGear",
                columns: table => new
                {
                    SwitchGearID = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SwitchGearUnitId = table.Column<int>(type: "int", nullable: false),
                    SwitchGearTypeId = table.Column<int>(type: "int", nullable: false),
                    RelayId = table.Column<int>(type: "int", nullable: false),
                    CurrentTransformerId = table.Column<int>(type: "int", nullable: false),
                    Sf6SafetyAndLifeId = table.Column<int>(type: "int", nullable: false),
                    CircuitBreakerId = table.Column<int>(type: "int", nullable: false),
                    SwitchPositionId = table.Column<int>(type: "int", nullable: false),
                    BusBarId = table.Column<int>(type: "int", nullable: false),
                    PhasePowerTransformerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSwitchGear", x => x.SwitchGearID);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_LookupBusBar_BusBarId",
                        column: x => x.BusBarId,
                        principalTable: "LookupBusBar",
                        principalColumn: "BusBarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_LookUpCircuitBreaker_CircuitBreakerId",
                        column: x => x.CircuitBreakerId,
                        principalTable: "LookUpCircuitBreaker",
                        principalColumn: "CircuitBreakerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_LookUpCurrentTransformer_CurrentTransformerId",
                        column: x => x.CurrentTransformerId,
                        principalTable: "LookUpCurrentTransformer",
                        principalColumn: "CurrentTransformerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_TblPhasePowerTransformer_PhasePowerTransformerId",
                        column: x => x.PhasePowerTransformerId,
                        principalTable: "TblPhasePowerTransformer",
                        principalColumn: "PhasePowerTransformerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_TblRelay_RelayId",
                        column: x => x.RelayId,
                        principalTable: "TblRelay",
                        principalColumn: "RelayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_LookupSf6SafetyAndLife_Sf6SafetyAndLifeId",
                        column: x => x.Sf6SafetyAndLifeId,
                        principalTable: "LookupSf6SafetyAndLife",
                        principalColumn: "Sf6SafetyAndLifeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_LookUpSwitchGearType_SwitchGearTypeId",
                        column: x => x.SwitchGearTypeId,
                        principalTable: "LookUpSwitchGearType",
                        principalColumn: "SwitchGearTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_LookUpSwitchGearUnit_SwitchGearUnitId",
                        column: x => x.SwitchGearUnitId,
                        principalTable: "LookUpSwitchGearUnit",
                        principalColumn: "SwitchGearUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblSwitchGear_LookUpSwitchPosition_SwitchPositionId",
                        column: x => x.SwitchPositionId,
                        principalTable: "LookUpSwitchPosition",
                        principalColumn: "SwitchPositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblCrossArm",
                columns: table => new
                {
                    CrossArmId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Materials = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UltimateTensileStrength = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCrossArm", x => x.CrossArmId);
                    table.ForeignKey(
                        name: "FK_TblCrossArm_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpSideLockTieTerminalClampMerlin",
                columns: table => new
                {
                    SideLockTieTerminalClampMerlinId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    SideLockTieTerminalClampMerlinType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Materials = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UltimateTensileStrength = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpSideLockTieTerminalClampMerlin", x => x.SideLockTieTerminalClampMerlinId);
                    table.ForeignKey(
                        name: "FK_LookUpSideLockTieTerminalClampMerlin_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblAacInsulator",
                columns: table => new
                {
                    AacInsulatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AacInsulatorTypeId = table.Column<int>(type: "int", nullable: false),
                    NameoftheConductor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Installation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OverallDiameter = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NumberorDiameterofAluminum = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CrossSectionalAreaofConductors = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalAluminumCrossSectionalArea = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NumberorDiameterofSteel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalSteelCrossSectionalArea = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WeightofConductor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumDCResistanceofConductorAt20deC = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MinimumbreakingLoadofConductor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MinimumbreakingLoadofConductorType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PhasingCode = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FeederID = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OperatingVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NeutralMaterial = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NeutralSize = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AssemblyCode = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PhaseOrientation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InstallDate = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConductorCrossSection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConductorCapacityAmp = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TotalSanctionedLoadfromtheFeeder = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAacInsulator", x => x.AacInsulatorId);
                    table.ForeignKey(
                        name: "FK_TblAacInsulator_LookUpAacInsulatorType_AacInsulatorTypeId",
                        column: x => x.AacInsulatorTypeId,
                        principalTable: "LookUpAacInsulatorType",
                        principalColumn: "AacInsulatorTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblAacInsulator_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblConductor",
                columns: table => new
                {
                    ConductorId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ConductorTypeId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ConductorName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Installation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Material = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OverallDiameter = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NumberOrDiameterOfAluminum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CrossSectionalAreaOfConducto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NominalAluminumCrossSectionalArea = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NumberOrdiameterOfSteel = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NominalSteelCrossSectionalArea = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WeightOfConductor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MaximumDcResistanceOfConductorAt20DegC = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumBreakingLoadOfConductor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhasingCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OperatingVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NeutralMaterial = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NeutralSize = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AssemblyCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NominalVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhaseOrientation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstallDate = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ConductorCrossSection = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ConductorCapacityAmp = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TotalSanctionedLoadFromTheFeeder = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblConductor", x => x.ConductorId);
                    table.ForeignKey(
                        name: "FK_TblConductor_LookUpConductorType_ConductorTypeId",
                        column: x => x.ConductorTypeId,
                        principalTable: "LookUpConductorType",
                        principalColumn: "ConductorTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblConductor_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblCopperCables",
                columns: table => new
                {
                    CopperCablesId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CopperCablesTypeId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CableSize = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NumbersAndDiameterofWires = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumResistanceat30degC = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalThicknessofInsulation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalThicknessofSheath = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ColorofSheath = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ApproximateOuterDiameter = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ApproximateWeight = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ContinuousPermissibleServiceVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CurrentRatingAt30degCambientTemperatureUorG = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CurrentRatingat35degCambientinAir = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCopperCables", x => x.CopperCablesId);
                    table.ForeignKey(
                        name: "FK_TblCopperCables_LookUpCopperCablesType_CopperCablesTypeId",
                        column: x => x.CopperCablesTypeId,
                        principalTable: "LookUpCopperCablesType",
                        principalColumn: "CopperCablesTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCopperCables_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblDistributionTransformer",
                columns: table => new
                {
                    DistributionTransformerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PoleStructureMountedSurgearrestorId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FeederLineId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    NameOf33bs11kVSubStation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Nameof11kVFeeder = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SNDIdentificationNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NearestHoldingOrHouseNoOrShop = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ExistingPoleNumberingifAny = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InstalledConditionPadbsPoleMounted = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InstalledPlaceIndorOrOutdoor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ContractNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OwneroftheTransformerBPDBbsConsumer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TransformerKVARating = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    YearOfManufacturing = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NameofManufacturer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TransformerSerialNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedHTVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedLTVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedHTCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedLTCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ControlVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MotorVoltageForSpringCharge = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CurrentTransformerRatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BodyColourCondition = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NameoBodyColour = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OilLeakageYesbsNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PlaceofOilLeakageMark = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PlatformMaterialAnglbsChannel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PlatformStandardbsNonStandardbsGoodbBad = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeofTransformerSupportPoleLeft = table.Column<string>(name: "TypeofTransformerSupportPoleLeft ", type: "nvarchar(250)", nullable: true),
                    ConditionofTransformerSupportPoleLeft = table.Column<string>(name: "ConditionofTransformerSupportPoleLeft ", type: "nvarchar(250)", nullable: true),
                    TypeofTransformerSupportPoleRight = table.Column<string>(name: "TypeofTransformerSupportPoleRight ", type: "nvarchar(250)", nullable: true),
                    ConditionofTransformerSupportPoleRight = table.Column<string>(name: "ConditionofTransformerSupportPoleRight ", type: "nvarchar(250)", nullable: true),
                    BushingRPhaseOilLeakage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BushingRPhaseBushing = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BushingRPhaseBushingColor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HTBushingYPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HTBushingBPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HTBushingNPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LTBushingRPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    LTBushingYPhase = table.Column<string>(name: "LTBushingY Phase", type: "nvarchar(250)", nullable: true),
                    LTBushingBPhase = table.Column<string>(name: "LTBushingB Phase", type: "nvarchar(250)", nullable: true),
                    LTBushingNPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WireSizeofHTDrop = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConditionofHTDropGoodbsBad = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WirebsCableSizeofLTDropCKT1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConditionofLTDropGoodbsBadCKT1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WirebsCableSizeofLTDropCKT2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConditionofLTDropGoodbsBadCKT2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EarthingLead1 = table.Column<string>(name: "EarthingLead1 ", type: "nvarchar(250)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConditionStandardbsNonStandardbsGoodbsBad = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeak = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DateAndtime = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakRYVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakYBVoltageVolt = table.Column<string>(name: "DayPeak YBVoltageVolt", type: "nvarchar(250)", nullable: true),
                    DayPeakRBVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakRNVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakYNVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakBNVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakLeakageVoltageBodyEarthVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakCurrentsAmpsCkt1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakCurrentsAmpsCkt2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakCurrentsAmpsCkt3 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakRPhaseCurrentAmps = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakYPhaseCurrentAmps = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakBPhaseCurrentAmps = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakNeutralCurrentAmps = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DayPeakCalculatedDayPeakkVA = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeak = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakDateAndTime = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakVoltage = table.Column<string>(name: "EveningPeakVoltage ", type: "nvarchar(250)", nullable: true),
                    EveningPeakRYVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakYBVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakRBVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakRNVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakYNVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakBNVoltageVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakLeakageVoltageBodyEarthVolt = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakCurrentsAmpsCkt1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakCurrentsAmpsCkt2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakCurrentsAmpsCkt3 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakRPhaseCurrentAmps = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakYPhaseCurrentAmps = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakBPhaseCurrentAmps = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakNeutralCurrentAmps = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EveningPeakCalculatedEveningPeakkVA = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DropOutFuseExistOrNotExistInRPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DropOutFuseExistOrNotExistInYPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DropOutFuseExistOrNotExistInBPhase = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConditionofDropOutFuse = table.Column<string>(name: "ConditionofDropOutFuse ", type: "nvarchar(250)", nullable: true),
                    LightningArrestor = table.Column<string>(name: "LightningArrestor ", type: "nvarchar(250)", nullable: true),
                    ConditionofLightingArrestor = table.Column<string>(name: "ConditionofLightingArrestor ", type: "nvarchar(250)", nullable: true),
                    DistributionBoxExistbsnotExist = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConditionofDistributionBox = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoOfMCCB = table.Column<string>(name: "NoOf MCCB", type: "nvarchar(250)", nullable: true),
                    ManufacturerTypeOriginofMCCBforCircuit1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturerTypeOriginofMCCBforCircuit2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AmpereRatingasPerNamePlateofMCCBforCKT1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AmpereRatingpernameplateofMCCBforCKT2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConditionofMCCBforCircuit1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConditionofMCCBforCircuit2 = table.Column<string>(name: "ConditionofMCCBforCircuit2 ", type: "nvarchar(250)", nullable: true),
                    RecommenDation = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDistributionTransformer", x => x.DistributionTransformerId);
                    table.ForeignKey(
                        name: "FK_TblDistributionTransformer_TblFeederLine_FeederLineId",
                        column: x => x.FeederLineId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblDistributionTransformer_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblDistributionTransformer_TblPoleStructureMountedSurgearrestor_PoleStructureMountedSurgearrestorId",
                        column: x => x.PoleStructureMountedSurgearrestorId,
                        principalTable: "TblPoleStructureMountedSurgearrestor",
                        principalColumn: "PoleStructureMountedSurgeArrestorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblInsulatorDisk",
                columns: table => new
                {
                    InsulatorDisktId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Installation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NominalSystemVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InsulatorDiskTypeId = table.Column<int>(type: "int", nullable: false),
                    MaximumSystemVoltage = table.Column<string>(name: "MaximumSystemVoltage ", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeOfSystem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NumberOfDiskPerString = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    MinimumElectromechanicalStrength = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumMechanicalFailingLoad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LookUpTypeOfInsulator = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DiameterOfInsulator = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumUnitSpacing = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CouplingSize = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInsulatorDisk", x => x.InsulatorDisktId);
                    table.ForeignKey(
                        name: "FK_TblInsulatorDisk_LookUpInsulatorDiskType_InsulatorDiskTypeId",
                        column: x => x.InsulatorDiskTypeId,
                        principalTable: "LookUpInsulatorDiskType",
                        principalColumn: "InsulatorDiskTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblInsulatorDisk_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblInsulatorPinAndPost",
                columns: table => new
                {
                    InsulatorPinAndPostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Installation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NominalSystemVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InsulatorPinAndPostTypeId = table.Column<int>(type: "int", nullable: false),
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
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInsulatorPinAndPost", x => x.InsulatorPinAndPostId);
                    table.ForeignKey(
                        name: "FK_TblInsulatorPinAndPost_LookUpInsulatorPinAndPostType_InsulatorPinAndPostTypeId",
                        column: x => x.InsulatorPinAndPostTypeId,
                        principalTable: "LookUpInsulatorPinAndPostType",
                        principalColumn: "InsulatorPinAndPostTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblInsulatorPinAndPost_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblInsulatorShackleOrGuy",
                columns: table => new
                {
                    InsulatorShackleOrGuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsulatorShackleOrGuyTypeId = table.Column<int>(type: "int", nullable: false),
                    Installation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NominalSystemVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MaximumSystemVoltage = table.Column<string>(name: "MaximumSystemVoltage ", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeOfSystem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumDiameterOfInsulator = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumHeightOfTheInsulator = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MinimumMechanicalFailingLoadTransverse = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DryFlashover = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WetFlashoverVertical = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WetFlashoverHorizontal = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InsulationClass = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AtmosphericCondition = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FlashOverVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PowerFrequencyPunctureVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MechanicalStrength = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInsulatorShackleOrGuy", x => x.InsulatorShackleOrGuyId);
                    table.ForeignKey(
                        name: "FK_TblInsulatorShackleOrGuy_LookUpInsulatorShackleOrGuyType_InsulatorShackleOrGuyTypeId",
                        column: x => x.InsulatorShackleOrGuyTypeId,
                        principalTable: "LookUpInsulatorShackleOrGuyType",
                        principalColumn: "InsulatorShackleOrGuyTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblInsulatorShackleOrGuy_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblPoleMountedDofCutOutFuseLink",
                columns: table => new
                {
                    PoleMountedDofCutOutFuseLinkId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Standard = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    General = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Installation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeorModel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Construction = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Application = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalRatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumSystemVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SystemFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeofSystem = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ContinuousCurrentRating = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    InterruptingCapacityoftheCutOutMin = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FuseHolderType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FuseLinkRatedCurrentContinuous = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BasicInsulationLevelBIL = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    FuseLinkType = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPoleMountedDofCutOutFuseLink", x => x.PoleMountedDofCutOutFuseLinkId);
                    table.ForeignKey(
                        name: "FK_TblPoleMountedDofCutOutFuseLink_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblPolePicture",
                columns: table => new
                {
                    PolePictureId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PictureLocation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPolePicture", x => x.PolePictureId);
                    table.ForeignKey(
                        name: "FK_TblPolePicture_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblServicePoint",
                columns: table => new
                {
                    ServicePointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    VoltageCategory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ServicePointType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FeederLineId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    AggregateLoadkw = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NoOFConsumersR = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NoOFConsumersY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NoOFConsumersB = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NoOfConsumersRyb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BuildingId = table.Column<int>(nullable: false),
                    BuildingType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PlotNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BuildingApptNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PremiseName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RoadName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CityTown = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PrimaryLandmark = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblServicePoint", x => x.ServicePointId);
                    table.ForeignKey(
                        name: "FK_TblServicePoint_TblFeederLine_FeederLineId",
                        column: x => x.FeederLineId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblServicePoint_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblSpecificationsOfMountBracket",
                columns: table => new
                {
                    SpecificationsOfMountBracketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecificationsOfMountBracketTypeId = table.Column<int>(type: "int", nullable: false),
                    MountBrackeType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Materials = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UltimateTensileStrength = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Galvanization = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Standard = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSpecificationsOfMountBracket", x => x.SpecificationsOfMountBracketId);
                    table.ForeignKey(
                        name: "FK_TblSpecificationsOfMountBracket_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblSpecificationsOfMountBracket_LookUpSpecificationsOfMountBracketType_SpecificationsOfMountBracketTypeId",
                        column: x => x.SpecificationsOfMountBracketTypeId,
                        principalTable: "LookUpSpecificationsOfMountBracketType",
                        principalColumn: "SpecificationsOfMountBracketTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookUpPotentialTrans33KV",
                columns: table => new
                {
                    PotentialTransformerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SwitchGearID = table.Column<string>(type: "varchar(50)", nullable: true),
                    NameoftheManufacturer = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeAndModelNo = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalSystemVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    HeightsSystemVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedPrimaryVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedSecondaryVoltageandTertiaryVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ImpulseWithstAndVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MicroSec12or50 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PowerFrequencyWithstandVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    BurdenOrClass = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MeteringWinding = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ProtectionWinding = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpPotentialTrans33KV", x => x.PotentialTransformerId);
                    table.ForeignKey(
                        name: "FK_LookUpPotentialTrans33KV_TblSwitchGear_SwitchGearID",
                        column: x => x.SwitchGearID,
                        principalTable: "TblSwitchGear",
                        principalColumn: "SwitchGearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblIndoorOutdoorTypeProgrammableEnergyMeter",
                columns: table => new
                {
                    EnergyMeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SwitchGearID = table.Column<string>(nullable: true),
                    ManufacturersNameAddress = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ManufacturersTypeAndModel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ConstructionConnection = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Installation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MinimumBiasingVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    VariationOfFrequency = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    VariationOfVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    AccuracyClass = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    RatedCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MeterConstant = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NoOfTerminal = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    YearOfManufacture = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MeterSealingCondition = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblIndoorOutdoorTypeProgrammableEnergyMeter", x => x.EnergyMeterId);
                    table.ForeignKey(
                        name: "FK_TblIndoorOutdoorTypeProgrammableEnergyMeter_TblSwitchGear_SwitchGearID",
                        column: x => x.SwitchGearID,
                        principalTable: "TblSwitchGear",
                        principalColumn: "SwitchGearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblXLPEaluminiumCopperGalvanize11KV",
                columns: table => new
                {
                    XLPEaluminiumCopperGalvanize11KVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SwitchGearID = table.Column<string>(type: "varchar(50)", nullable: true),
                    NominalCrossSectionalAreaofPhaseConductor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DiameterofPhaseConductor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    SingleCoreStranding = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ThicknessofInsulation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DiameterOverInsulationApproximately = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalCrossSectionalAreaofScreen = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ThicknessofOverSheath = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OverallDiameterApproximately = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    GalvanizedSteelRopeNominalCrossSectionalAreaofRope = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Stranding = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ThicknessofCovering = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OverallDiameterofRope = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ThreeCoresStrandedAroundSuspensionUnitDiameterof = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    StrandedBundleApproximately = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TotalWeightApproximately = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    NominalVoltageratingUOorU = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumAdmissibleContinuousWorkingVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MaximumDCResistanceAt20C = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WorkingInductance = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    WorkingCapacitance = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    EarthLeakageCurrent = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ShortCircuitCurrentOfConductor = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OfScreen = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CurrentRatingatAmbienttempof40C = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ACTestVoltage = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Source33or11kVSubStationID = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Source132or33kVSubStationID = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CurrentCarryingCapacity = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblXLPEaluminiumCopperGalvanize11KV", x => x.XLPEaluminiumCopperGalvanize11KVId);
                    table.ForeignKey(
                        name: "FK_TblXLPEaluminiumCopperGalvanize11KV_TblSwitchGear_SwitchGearID",
                        column: x => x.SwitchGearID,
                        principalTable: "TblSwitchGear",
                        principalColumn: "SwitchGearID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblDistributionTransformerPicture",
                columns: table => new
                {
                    DistributionTransformerPictureId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DistributionTransformerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PictureName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PictureLocation = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDistributionTransformerPicture", x => x.DistributionTransformerPictureId);
                    table.ForeignKey(
                        name: "FK_TblDistributionTransformerPicture_TblDistributionTransformer_DistributionTransformerId",
                        column: x => x.DistributionTransformerId,
                        principalTable: "TblDistributionTransformer",
                        principalColumn: "DistributionTransformerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblConsumerData",
                columns: table => new
                {
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServicePointId = table.Column<int>(type: "int", nullable: true),
                    FeederLineId = table.Column<string>(type: "varchar(50)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tariff = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhasingCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OperatingVoltage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CriticalCustomer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MeterNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SanctionedLoad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ConnectedLoad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BusinessType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ConnectionStatus = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SpecialCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SpecialType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BillGroup = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BookNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BcCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Ws = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OmfKwh = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MeterReading = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastReadingDate = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblConsumerData", x => x.ConsumerId);
                    table.ForeignKey(
                        name: "FK_TblConsumerData_TblFeederLine_FeederLineId",
                        column: x => x.FeederLineId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblConsumerData_TblServicePoint_ServicePointId",
                        column: x => x.ServicePointId,
                        principalTable: "TblServicePoint",
                        principalColumn: "ServicePointId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUpAuxiliaryTransformer_LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer",
                column: "LookUpAuxiliaryTransformer_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpBatteryCharger_LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger",
                column: "LookUpBatteryCharger_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpCircleInfo_ZoneCode",
                table: "LookUpCircleInfo",
                column: "ZoneCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblCrossArm_PoleId",
                table: "TblCrossArm",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpDifferentMeter_RelayTypeId",
                table: "LookUpDifferentMeter",
                column: "RelayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpDifferentRelay_RelayTypeId",
                table: "LookUpDifferentRelay",
                column: "RelayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpNiCdBattery110vDc_LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc",
                column: "LookUpNiCdBattery110vDc_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpPotentialTrans33KV_SwitchGearID",
                table: "LookUpPotentialTrans33KV",
                column: "SwitchGearID");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpRouteInfo_SubstationId",
                table: "LookUpRouteInfo",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpSideLockTieTerminalClampMerlin_PoleId",
                table: "LookUpSideLockTieTerminalClampMerlin",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpSnDInfo_CircleCode",
                table: "LookUpSnDInfo",
                column: "CircleCode");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpTerminationKits_BusBarId",
                table: "LookUpTerminationKits",
                column: "BusBarId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAacInsulator_AacInsulatorTypeId",
                table: "TblAacInsulator",
                column: "AacInsulatorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAacInsulator_PoleId",
                table: "TblAacInsulator",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAutoCircuitReCloser_AutoCircuitReCloserTypeId",
                table: "TblAutoCircuitReCloser",
                column: "AutoCircuitReCloserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAutoCircuitReCloser_TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser",
                column: "TblAutoCircuitReCloser_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConductor_ConductorTypeId",
                table: "TblConductor",
                column: "ConductorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConductor_PoleId",
                table: "TblConductor",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_FeederLineId",
                table: "TblConsumerData",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_ServicePointId",
                table: "TblConsumerData",
                column: "ServicePointId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCopperCables_CopperCablesTypeId",
                table: "TblCopperCables",
                column: "CopperCablesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCopperCables_PoleId",
                table: "TblCopperCables",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_FeederLineId",
                table: "TblDistributionTransformer",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_PoleId",
                table: "TblDistributionTransformer",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_PoleStructureMountedSurgearrestorId",
                table: "TblDistributionTransformer",
                column: "PoleStructureMountedSurgearrestorId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformerPicture_DistributionTransformerId",
                table: "TblDistributionTransformerPicture",
                column: "DistributionTransformerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblFeederLine_FeederLineTypeId",
                table: "TblFeederLine",
                column: "FeederLineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblFeederLine_RouteCode",
                table: "TblFeederLine",
                column: "RouteCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblIndoorOutdoorTypeProgrammableEnergyMeter_SwitchGearID",
                table: "TblIndoorOutdoorTypeProgrammableEnergyMeter",
                column: "SwitchGearID");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorDisk_InsulatorDiskTypeId",
                table: "TblInsulatorDisk",
                column: "InsulatorDiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorDisk_PoleId",
                table: "TblInsulatorDisk",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorPinAndPost_InsulatorPinAndPostTypeId",
                table: "TblInsulatorPinAndPost",
                column: "InsulatorPinAndPostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorPinAndPost_PoleId",
                table: "TblInsulatorPinAndPost",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorShackleOrGuy_InsulatorShackleOrGuyTypeId",
                table: "TblInsulatorShackleOrGuy",
                column: "InsulatorShackleOrGuyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInsulatorShackleOrGuy_PoleId",
                table: "TblInsulatorShackleOrGuy",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_AmpereMeterId",
                table: "TblMeteringPanel",
                column: "AmpereMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_AnnuciatorIdForFeeder",
                table: "TblMeteringPanel",
                column: "AnnuciatorIdForFeeder");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_AnnuciatorIdForTransformer",
                table: "TblMeteringPanel",
                column: "AnnuciatorIdForTransformer");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_AuxiliaryFlagRelayIdForTransformer",
                table: "TblMeteringPanel",
                column: "AuxiliaryFlagRelayIdForTransformer");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_ControlSwitchId",
                table: "TblMeteringPanel",
                column: "ControlSwitchId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_ControlSwitchIdForTransformer",
                table: "TblMeteringPanel",
                column: "ControlSwitchIdForTransformer");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_DifferentialRelayIdForTransformer",
                table: "TblMeteringPanel",
                column: "DifferentialRelayIdForTransformer");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_DimensionAndWeightId",
                table: "TblMeteringPanel",
                column: "DimensionAndWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_IdmtOverCurrentAndEarthFaultRelayId",
                table: "TblMeteringPanel",
                column: "IdmtOverCurrentAndEarthFaultRelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_IdmtOverCurrentAndEarthFaultRelayIdForTransformer",
                table: "TblMeteringPanel",
                column: "IdmtOverCurrentAndEarthFaultRelayIdForTransformer");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_KWHandkVARHMeterId",
                table: "TblMeteringPanel",
                column: "KWHandkVARHMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_MegaVarMeterId",
                table: "TblMeteringPanel",
                column: "MegaVarMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_MegaWattMeterId",
                table: "TblMeteringPanel",
                column: "MegaWattMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_RestrictedEarthFaultRelayIdForTransformer",
                table: "TblMeteringPanel",
                column: "RestrictedEarthFaultRelayIdForTransformer");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_SubstationId",
                table: "TblMeteringPanel",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_TripCircuitSupervisionRelayId",
                table: "TblMeteringPanel",
                column: "TripCircuitSupervisionRelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_TripCircuitSupervisionRelayIdForTransformer",
                table: "TblMeteringPanel",
                column: "TripCircuitSupervisionRelayIdForTransformer");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_TripRelayId",
                table: "TblMeteringPanel",
                column: "TripRelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_TripRelayIdForTransformer",
                table: "TblMeteringPanel",
                column: "TripRelayIdForTransformer");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_VoltMeterId",
                table: "TblMeteringPanel",
                column: "VoltMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOutDoorTypeVacumnCircuitBreaker_TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                column: "TblOutDoorTypeVacumnCircuitBreaker_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPhasePowerTransformer_FeederID33KvId",
                table: "TblPhasePowerTransformer",
                column: "FeederID33KvId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPhasePowerTransformer_FeederLineId",
                table: "TblPhasePowerTransformer",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPhasePowerTransformer_Source132or33kVSubstationId",
                table: "TblPhasePowerTransformer",
                column: "Source132or33kVSubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPhasePowerTransformer_SubstationId",
                table: "TblPhasePowerTransformer",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPhasePowerTransformer_SurgeArrestorId",
                table: "TblPhasePowerTransformer",
                column: "SurgeArrestorId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_FeederLineId",
                table: "TblPole",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_PhaseAId",
                table: "TblPole",
                column: "PhaseAId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_PhaseBId",
                table: "TblPole",
                column: "PhaseBId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_PhaseCId",
                table: "TblPole",
                column: "PhaseCId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_PoleConditionId",
                table: "TblPole",
                column: "PoleConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_PoleTypeId",
                table: "TblPole",
                column: "PoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_PreviousPoleNo",
                table: "TblPole",
                column: "PreviousPoleNo");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_RouteCode",
                table: "TblPole",
                column: "RouteCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_SourceCableId",
                table: "TblPole",
                column: "SourceCableId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_TargetCableId",
                table: "TblPole",
                column: "TargetCableId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPoleMountedDofCutOutFuseLink_PoleId",
                table: "TblPoleMountedDofCutOutFuseLink",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPolePicture_PoleId",
                table: "TblPolePicture",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblServicePoint_FeederLineId",
                table: "TblServicePoint",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblServicePoint_PoleId",
                table: "TblServicePoint",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSpecificationsOfMountBracket_PoleId",
                table: "TblSpecificationsOfMountBracket",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSpecificationsOfMountBracket_SpecificationsOfMountBracketTypeId",
                table: "TblSpecificationsOfMountBracket",
                column: "SpecificationsOfMountBracketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSubstation_SnDCode",
                table: "TblSubstation",
                column: "SnDCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblSubstation_SubstationTypeId",
                table: "TblSubstation",
                column: "SubstationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSubstationPicture_TblSubstationPicture_SubstationId",
                table: "TblSubstationPicture",
                column: "TblSubstationPicture_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitch33KvIsolator_TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator",
                column: "TblSwitch33KvIsolator_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_BusBarId",
                table: "TblSwitchGear",
                column: "BusBarId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_CircuitBreakerId",
                table: "TblSwitchGear",
                column: "CircuitBreakerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_CurrentTransformerId",
                table: "TblSwitchGear",
                column: "CurrentTransformerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_PhasePowerTransformerId",
                table: "TblSwitchGear",
                column: "PhasePowerTransformerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_RelayId",
                table: "TblSwitchGear",
                column: "RelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_Sf6SafetyAndLifeId",
                table: "TblSwitchGear",
                column: "Sf6SafetyAndLifeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_SwitchGearTypeId",
                table: "TblSwitchGear",
                column: "SwitchGearTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_SwitchGearUnitId",
                table: "TblSwitchGear",
                column: "SwitchGearUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitchGear_SwitchPositionId",
                table: "TblSwitchGear",
                column: "SwitchPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblXLPEaluminiumCopperGalvanize11KV_SwitchGearID",
                table: "TblXLPEaluminiumCopperGalvanize11KV",
                column: "SwitchGearID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUpAuxiliaryTransformer");

            migrationBuilder.DropTable(
                name: "LookUpBatteryCharger");

            migrationBuilder.DropTable(
                name: "TblCrossArm");

            migrationBuilder.DropTable(
                name: "LookUpNiCdBattery110vDc");

            migrationBuilder.DropTable(
                name: "LookUpPotentialTrans33KV");

            migrationBuilder.DropTable(
                name: "LookUpSideLockTieTerminalClampMerlin");

            migrationBuilder.DropTable(
                name: "LookUpTerminationKits");

            migrationBuilder.DropTable(
                name: "TblAacInsulator");

            migrationBuilder.DropTable(
                name: "TblAutoCircuitReCloser");

            migrationBuilder.DropTable(
                name: "TblConductor");

            migrationBuilder.DropTable(
                name: "TblConsumerData");

            migrationBuilder.DropTable(
                name: "TblCopperCables");

            migrationBuilder.DropTable(
                name: "TblDistributionTransformerPicture");

            migrationBuilder.DropTable(
                name: "TblIndoorOutdoorTypeProgrammableEnergyMeter");

            migrationBuilder.DropTable(
                name: "TblInsulatorDisk");

            migrationBuilder.DropTable(
                name: "TblInsulatorPinAndPost");

            migrationBuilder.DropTable(
                name: "TblInsulatorShackleOrGuy");

            migrationBuilder.DropTable(
                name: "TblMeteringPanel");

            migrationBuilder.DropTable(
                name: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.DropTable(
                name: "TblPoleMountedDofCutOutFuseLink");

            migrationBuilder.DropTable(
                name: "TblPolePicture");

            migrationBuilder.DropTable(
                name: "TblSpecificationsOfMountBracket");

            migrationBuilder.DropTable(
                name: "TblSubstationPicture");

            migrationBuilder.DropTable(
                name: "TblSwitch33KvIsolator");

            migrationBuilder.DropTable(
                name: "TblXLPEaluminiumCopperGalvanize11KV");

            migrationBuilder.DropTable(
                name: "LookUpAacInsulatorType");

            migrationBuilder.DropTable(
                name: "LookUpAutoCircuitReCloserType");

            migrationBuilder.DropTable(
                name: "LookUpConductorType");

            migrationBuilder.DropTable(
                name: "TblServicePoint");

            migrationBuilder.DropTable(
                name: "LookUpCopperCablesType");

            migrationBuilder.DropTable(
                name: "TblDistributionTransformer");

            migrationBuilder.DropTable(
                name: "LookUpInsulatorDiskType");

            migrationBuilder.DropTable(
                name: "LookUpInsulatorPinAndPostType");

            migrationBuilder.DropTable(
                name: "LookUpInsulatorShackleOrGuyType");

            migrationBuilder.DropTable(
                name: "LookUpDifferentMeter");

            migrationBuilder.DropTable(
                name: "LookupAnnuciator");

            migrationBuilder.DropTable(
                name: "LookUpDifferentRelay");

            migrationBuilder.DropTable(
                name: "LookupControlSwitch");

            migrationBuilder.DropTable(
                name: "LookUpDimensionAndWeight");

            migrationBuilder.DropTable(
                name: "LookUpSpecificationsOfMountBracketType");

            migrationBuilder.DropTable(
                name: "TblSwitchGear");

            migrationBuilder.DropTable(
                name: "TblPole");

            migrationBuilder.DropTable(
                name: "TblPoleStructureMountedSurgearrestor");

            migrationBuilder.DropTable(
                name: "LookUpDifferentTypesOfMeter");

            migrationBuilder.DropTable(
                name: "LookUpDifferentTypesOfRelay");

            migrationBuilder.DropTable(
                name: "LookupBusBar");

            migrationBuilder.DropTable(
                name: "LookUpCircuitBreaker");

            migrationBuilder.DropTable(
                name: "LookUpCurrentTransformer");

            migrationBuilder.DropTable(
                name: "TblPhasePowerTransformer");

            migrationBuilder.DropTable(
                name: "TblRelay");

            migrationBuilder.DropTable(
                name: "LookupSf6SafetyAndLife");

            migrationBuilder.DropTable(
                name: "LookUpSwitchGearType");

            migrationBuilder.DropTable(
                name: "LookUpSwitchGearUnit");

            migrationBuilder.DropTable(
                name: "LookUpSwitchPosition");

            migrationBuilder.DropTable(
                name: "LookUpSagCondition");

            migrationBuilder.DropTable(
                name: "LookUpPoleCondition");

            migrationBuilder.DropTable(
                name: "LookUpPoleType");

            migrationBuilder.DropTable(
                name: "TblFeederLine");

            migrationBuilder.DropTable(
                name: "TblSurgeArrestor");

            migrationBuilder.DropTable(
                name: "LookUpFeederLineType");

            migrationBuilder.DropTable(
                name: "LookUpRouteInfo");

            migrationBuilder.DropTable(
                name: "TblSubstation");

            migrationBuilder.DropTable(
                name: "LookUpSnDInfo");

            migrationBuilder.DropTable(
                name: "LookUpSubstationType");

            migrationBuilder.DropTable(
                name: "LookUpCircleInfo");

            migrationBuilder.DropTable(
                name: "LookUpZoneInfo");
        }
    }
}
