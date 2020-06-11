using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Pdb014App.Models.PDB.SubstationModels;


namespace Pdb014App.Models.PDB.PhasePowerTransformerModel
{
    public class TblPhasePowerTransformer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Power Transformer Id")]
        public string PhasePowerTransformerId { get; set; }

        [Column("ManufacturersName", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturer's Name")]
        public string ManufacturersName { get; set; }

        [Column("ManufacturersAddress", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturer's Address")]
        public string ManufacturersAddress { get; set; }

        [Column("AppliedStandard", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Applied Standard")]
        public string AppliedStandard { get; set; }

        [Column("DescriptionType", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Description Type")]
        public string DescriptionType { get; set; }

        [Column("SerialNumber", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Serial No.")]
        public string SerialNumber { get; set; }

        [Column("RatedPower", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Power")]
        public string RatedPower { get; set; }

        [Column("NumberOfPhase", Order = 8, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Number of Phase")]
        public int? NumberOfPhase { get; set; }

        [Column("RatedVoltagePhaseToPhase", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage (Phase to Phase)")]
        public string RatedVoltagePhaseToPhase { get; set; }

        [Column("HighVoltageWindingPhaseToPhase", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "High Voltage Winding (Phase to Phase)")]
        public string HighVoltageWindingPhaseToPhase { get; set; }

        [Column("LowVoltageWindingPhaseToPhase", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Low Voltage Winding (Phase to Phase)")]
        public string LowVoltageWindingPhaseToPhase { get; set; }

        [Column("RatedFrequency", Order = 12, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Frequency (Hz)")]
        public decimal? RatedFrequency { get; set; }

        [Column("RatedInsulationLevel", Order = 13, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Insulation Level")]
        public decimal? RatedInsulationLevel { get; set; }


        //[Column("ImpulseWithStandFullWave", Order = 14, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "(a) Impulse Withstand, full wave")]
        //public string ImpulseWithStandFullWave { get; set; }

        [Column("ImpulseHighVoltageWinding", Order = 15, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse High Voltage Winding (KV)")]
        public decimal? ImpulseHighVoltageWinding { get; set; }

        [Column("ImpulseLowVoltageWinding", Order = 16, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse Low Voltage Winding (KV)")]
        public decimal? ImpulseLowVoltageWinding { get; set; }

        //[Column("ACWithStandVoltage", Order = 17, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "(b) AC Withstand Voltage")]
        //public string ACWithStandVoltage { get; set; }

        [Column("ACHighVoltageWinding", Order = 18, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "AC High Voltage Winding (KA)")]
        public decimal? ACHighVoltageWinding { get; set; }

        [Column("ACLowVoltageWinding", Order = 19, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "AC Low Voltage Winding (KA)")]
        public decimal? ACLowVoltageWinding { get; set; }

        [Column("TypeOfCooling28Or35MVA", Order = 20, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Cooling, 28/35 MVA")]
        public string TypeOfCooling28Or35MVA { get; set; }

        [Column("OnLoadTapChanger", Order = 21, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "On Load Tap–changer (MR, Germany/ABB, Sweden/ATL, UK)")]
        public string OnLoadTapChanger { get; set; }

        [Column("TypeTap", Order = 22, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type Tap")]
        public string TypeTap { get; set; }

        [Column("TappingRangeHT", Order = 23, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Tapping Range :HT")]
        public decimal? TappingRangeHT { get; set; }

        [Column("LocationOfTap", Order = 24, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Location of Tap")]
        public string LocationOfTap { get; set; }

        [Column("OilVolume", Order = 25, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Oil Volume (L)")]
        public decimal? OilVolume { get; set; }

        [Column("OneStepChange", Order = 26, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "One Step Change (%)")]
        public decimal? OneStepChange { get; set; }

        [Column("MotorRating", Order = 27, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Motor Rating (KW)")]
        public decimal? MotorRating { get; set; }

        [Column("ImpedanceVoltageAt75CAndAtNominalRatio", Order = 28, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impedance Voltage at 75°C and at Nominal Ratio and 100% Rated Power (%)")]
        public decimal? ImpedanceVoltageAt75CAndAtNominalRatio { get; set; }

        [Column("TemperatureRiseAtRatedPowerMaxAmbientTemperature40C", Order = 29, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Temperature Rise at Rated Power °C (Max. Ambient Temperature: 40°C)")]
        public decimal? TemperatureRiseAtRatedPowerMaxAmbientTemperature40C { get; set; }


        [Column("FiveMva", Order = 30, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "5 MVA (%)")]
        public decimal? FiveMva { get; set; }

        [Column("SixPointSixMva", Order = 30, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "6.67 MVA (%)")]
        public decimal? SixPointSixMva { get; set; }


        [Column("OilByThermometer", Order = 30, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Oil by Thermometer °C ")]
        public decimal? OilByThermometer { get; set; }

        [Column("WindingByResistanceMeasurement", Order = 31, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Winding by Resistance Measurement °C")]
        public decimal? WindingByResistanceMeasurement { get; set; }

        //Missing 4 attribute


        [Column("TemperatureGradientBetweenWindingsAndOil", Order = 32, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Temperature Gradient between Windings and Oil °C")]
        public decimal? TemperatureGradientBetweenWindingsAndOil { get; set; }

        //[Column("ShortCircuitLevelAtTerminal", Order = 33, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Short Circuit Level at Terminal")]
        //public string ShortCircuitLevelAtTerminal { get; set; }

        [Column("ShortCircuitLevelAtTerminalThirtyThreeKv", Order = 33, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short Circuit Level at Terminal 33 KV")]
        public string ShortCircuitLevelAtTerminalThirtyThreeKv { get; set; }


        [Column("ShortCircuitLevelAtTerminalEleventKv", Order = 33, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short Circuit Level at Terminal 11 KV")]
        public string ShortCircuitLevelAtTerminalEleventKv { get; set; }


        [Column("TransformerCore", Order = 34, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Transformer Core")]
        public string TransformerCore { get; set; }

        [Column("TypeofCoreAndFluxEnsityAtNominalVoltage", Order = 35, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Core and Flux Ensity at Nominal Voltage")]
        public string TypeofCoreAndFluxEnsityAtNominalVoltage { get; set; }

        //[Column("TransformerBushings", Order = 36, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Transformer Bushings")]
        //public string TransformerBushings { get; set; }

        [Column("TransformeHVBushing", Order = 37, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(a) Transforme H.V. Bushing")]
        public string TransformeHVBushing { get; set; }

        [Column("TransformeHVBushingType", Order = 38, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = " Transforme H.V. Bushing Type")]
        public string TransformeHVBushingType { get; set; }

        [Column("TransformeLVBushing", Order = 39, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(b) Transforme L.V. Bushing")]
        public string TransformeLVBushing { get; set; }

        [Column("TransformeLVBushingType", Order = 40, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = " Transforme L.V. Bushing Type")]
        public string TransformeLVBushingType { get; set; }

        [Column("TransformeNeutralBushing", Order = 41, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(c) Transforme Neutral Bushing")]
        public string TransformeNeutralBushing { get; set; }

        [Column("TransformeNeutralBushingType", Order = 42, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Transforme Neutral Bushing Type")]
        public string TransformeNeutralBushingType { get; set; }

        //[Column("ConservatorWithAirSealedBagForConstantOilPressurYesNo", Order = 43, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        [Display(Name = "Conservator with Air Sealed Bag (for constant oil pressure) (YES / NO)")]
        public bool ConservatorWithAirSealedBagForConstantOilPressur { get; set; }

        [Column("BreatherSilicagel", Order = 44, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Breather (Silicagel)")]
        public string BreatherSilicagel { get; set; }

        [Column("AuxiliaryCircuitVoltageForFanetc3P4W", Order = 45, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Auxiliary Circuit Voltage for Fan, etc., 3P-4W")]
        public decimal? AuxiliaryCircuitVoltageForFanetc3P4W { get; set; }

        [Column("ControlVoltage", Order = 46, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Control Voltage (V)")]
        public decimal? ControlVoltage { get; set; }

        [Column("SoundLevelIEC551", Order = 47, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Sound Level (IEC 551)")]
        public string SoundLevelIEC551 { get; set; }

        [Column("ONAN", Order = 48, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "ONAN")]
        public string ONAN { get; set; }

        [Column("ONAF", Order = 49, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "ONAF")]
        public string ONAF { get; set; }

        //[Column("BushingCTParticulars", Order = 50, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Bushing CT Particulars")]
        //public string BushingCTParticulars { get; set; }

        [Column("BushingCTParticularsHVside", Order = 51, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Bushing CT Particulars HV Side")]
        public string BushingCTParticularsHVside { get; set; }

        [Column("BushingCTParticularsLVside", Order = 52, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Bushing CT Particulars LV Side")]
        public string BushingCTParticularsLVside { get; set; }

        [Column("BushingCTParticularsNeutralSide", Order = 53, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Bushing CT Particulars Neutral Side")]
        public string BushingCTParticularsNeutralSide { get; set; }

        //[Column("NumberOfCoolingFan", Order = 54, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        [Display(Name = "Number of Cooling Fan (no)")]
        public int? NumberOfCoolingFan { get; set; }

        [Column("RatingOfFanMotors", Order = 55, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rating of Fan Motors")]
        public decimal? RatingOfFanMotors { get; set; }

        [Column("CoolingFanLossesAtFullOnafCapacityOperation", Order = 56, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Cooling Fan Losses at full ONAF Capacity Operation")]
        public string CoolingFanLossesAtFullOnafCapacityOperation { get; set; }

        [Column("CoreLossAtRatedFrequencyAndRatedVoltageAtNominalTapNoLoadLoss", Order = 57, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Core Loss at Rated Frequency and Rated Voltage at Nominal Tap. (No Load Loss)")]
        public string CoreLossAtRatedFrequencyAndRatedVoltageAtNominalTapNoLoadLoss { get; set; }

        //[Column("CopperLossAtfullloadAtRatedFrequencyAndAt75CFullLoadLoss", Order = 58, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Copper Loss at full Load, at Rated Frequency and at 75°C (Full Load Loss)")]
        //public string CopperLossAtFullLoadAtRatedFrequencyAndAt75CFullLoadLoss { get; set; }

        [Column("CopperLossAtMaximumTap", Order = 59, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(a) Copper Loss At Maximum Tap")]
        public string CopperLossAtMaximumTap { get; set; }

        [Column("CopperLossAtNominalTap", Order = 60, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(b) Copper Loss At Nominal Tap")]
        public string CopperLossAtNominalTap { get; set; }

        [Column("CopperLossAtMinimumTap", Order = 61, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(c) Copper Loss At Minimum Tap")]
        public string CopperLossAtMinimumTap { get; set; }

        //[Column("RadiatorsYesNo", Order = 62, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        [Display(Name = "Radiators (YES / NO)")]
        public bool Radiators { get; set; }

        [Column("OverallDimensions", Order = 63, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Overall Dimensions")]
        public string OverallDimensions { get; set; }

        //[Column("NoOfRadiators", Order = 64, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        [Display(Name = "No. of Radiators (No.)")]
        public int? NoOfRadiators { get; set; }

        //[Column("SupervisoryAlarmAndTripContactsYesNo", Order = 65, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]

        [Display(Name = "Supervisory Alarm and Trip Contacts (YES / NO)")]
        public bool SupervisoryAlarmAndTripContacts { get; set; }

        //[Column("TemperatureIndicatorsYesNo", Order = 66, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        [Display(Name = "Temperature Indicators (YES / NO)")]
        public bool TemperatureIndicators { get; set; }

        [Column("MakeAndType", Order = 67, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Make and Type")]
        public string MakeAndType { get; set; }

        [Column("AlarmAndTripRange", Order = 68, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Alarm and Trip Range")]
        public string AlarmAndTripRange { get; set; }

        //[Column("NoOfContacts", Order = 69, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        [Display(Name = "No. of Contacts")]
        public int? NoOfContacts { get; set; }

        [Column("CurrentRatingOfContacts", Order = 70, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Current Rating of Contacts")]
        public string CurrentRatingOfContacts { get; set; }

        [Column("SupervisoryAlarmContact", Order = 70, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Supervisory Alarm Contact")]
        public string SupervisoryAlarmContact { get; set; }

        //[Column("DimensionsAndWeightMaximumSizeForTransport", Order = 71, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "DimensionsAndWeightTransport Maximum size for Transport")]
        //public string DimensionsAndWeightMaximumSizeForTransport { get; set; }

        [Column("DimensionsAndWeightTransportLMulWMulH", Order = 72, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "L × W × H")]
        public string DimensionsAndWeightTransportLMulWMulH { get; set; }

        [Column("DimensionsAndWeightTransportWeightOFoil", Order = 73, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Weight of Oil (Kg)")]
        public decimal? DimensionsAndWeightTransportWeightOFoil { get; set; }

        [Column("DimensionsAndWeightTransportWeightofCore", Order = 74, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Weight of Core (Kg)")]
        public decimal? DimensionsAndWeightTransportWeightofCore { get; set; }

        [Column("DimensionsAndWeightTransportTotalWeight", Order = 75, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Total Weight (Kg)")]
        public decimal? DimensionsAndWeightTransportTotalWeight { get; set; }


        [Column("SanctionedLoad", Order = 77, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Sanctioned Load")]
        public decimal? SanctionedLoad { get; set; }

        [Column("MaximumLoad", Order = 78, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Load")]
        public decimal? MaximumLoad { get; set; }


        [Column(Order = 78, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "33 kV Feeder Line")]
        public string FeederID33KvId { get; set; }
        [ForeignKey("FeederID33KvId")]
        public virtual TblFeederLine PhasePowerTransformerTo33KvFeederLine { get; set; }


        [Column(Order = 79, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Source 132 Or 33kV Substation")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation PhasePowerTransformerToTblSubstation { get; set; }


        //[Column(Order = 80, TypeName = "varchar(50)")]
        //[StringLength(50)]
        //[Display(Name = "Source 132 Or 33kV Substation")]
        //public string Source132or33kVSubstationId { get; set; }
        //[ForeignKey("Source132or33kVSubstationId")]
        //public virtual TblSubstation PhasePowerTransformerToSourceSubstation { get; set; }
    }
}
