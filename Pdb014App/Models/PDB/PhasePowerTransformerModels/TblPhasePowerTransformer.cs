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
        

        //[Column(Order = 2, TypeName = "varchar(50)")]
        //[StringLength(50)]
        //[Display(Name = "SwitchGear Id")]
        //public string SwitchGearId { get; set; }
        //[ForeignKey("SwitchGearId")]
        //public virtual TblSwitchGear PhasePowerTransformerToSwitchGear { get; set; }


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
        public int NumberOfPhase { get; set; }

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

        [Column("RatedFrequency", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Frequency")]
        public string RatedFrequency { get; set; }

        [Column("RatedInsulationLevel", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Insulation Level")]
        public string RatedInsulationLevel { get; set; }


        [Column("ImpulseWithStandFullWave", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(a) Impulse Withstand, full wave")]
        public string ImpulseWithStandFullWave { get; set; }

        [Column("ImpulseHighVoltageWinding", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse High Voltage Winding")]
        public string ImpulseHighVoltageWinding { get; set; }

        [Column("ImpulseLowVoltageWinding", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse Low Voltage Winding")]
        public string ImpulseLowVoltageWinding { get; set; }

        [Column("ACWithStandVoltage", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(b) AC Withstand Voltage")]
        public string ACWithStandVoltage { get; set; }

        [Column("ACHighVoltageWinding", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "AC High Voltage Winding")]
        public string ACHighVoltageWinding { get; set; }

        [Column("ACLowVoltageWinding", Order = 19, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "AC Low Voltage Winding")]
        public string ACLowVoltageWinding { get; set; }

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

        [Column("TappingRangeHT", Order = 23, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Tapping Range :HT")]
        public string TappingRangeHT { get; set; }

        [Column("LocationOfTap", Order = 24, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Location of Tap")]
        public string LocationOfTap { get; set; }

        [Column("OilVolume", Order = 25, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Oil Volume")]
        public string OilVolume { get; set; }

        [Column("OneStepChange", Order = 26, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "One Step Change")]
        public string OneStepChange { get; set; }

        [Column("MotorRating", Order = 27, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Motor Rating")]
        public string MotorRating { get; set; }

        [Column("ImpedanceVoltageAt75CAndAtNominalRatio", Order = 28, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impedance Voltage at 75°C and at Nominal Ratio and 100% Rated Power")]
        public string ImpedanceVoltageAt75CAndAtNominalRatio { get; set; }

        [Column("TemperatureRiseAtRatedPowerMaxAmbientTemperature40C", Order = 29, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Temperature Rise at Rated Power (Max. Ambient Temperature: 40°C)")]
        public string TemperatureRiseAtRatedPowerMaxAmbientTemperature40C { get; set; }


        [Column("FiveMva", Order = 30, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "5 MVA")]
        public string FiveMva { get; set; }

        [Column("SixPointSixMva", Order = 30, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "6.67 MVA")]
        public string SixPointSixMva { get; set; }
        

        [Column("OilByThermometer", Order = 30, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Oil by Thermometer")]
        public string OilByThermometer { get; set; }

        [Column("WindingByResistanceMeasurement", Order = 31, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Winding by Resistance Measurement")]
        public string WindingByResistanceMeasurement { get; set; }

        //Missing 4 attribute


        [Column("TemperatureGradientBetweenWindingsAndOil", Order = 32, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Temperature Gradient between Windings and Oil")]
        public string TemperatureGradientBetweenWindingsAndOil { get; set; }

        [Column("ShortCircuitLevelAtTerminal", Order = 33, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short Circuit Level at Terminal")]
        public string ShortCircuitLevelAtTerminal { get; set; }

        [Column("ThirtyThreeKv", Order = 33, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "33 KV")]
        public string ThirtyThreeKv { get; set; }


        [Column("EleventKv", Order = 33, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "11 KV")]
        public string EleventKv { get; set; }


        [Column("TransformerCore", Order = 34, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Transformer Core")]
        public string TransformerCore { get; set; }

        [Column("TypeofCoreAndFluxEnsityAtNominalVoltage", Order = 35, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Core and Flux Ensity at Nominal Voltage")]
        public string TypeofCoreAndFluxEnsityAtNominalVoltage { get; set; }

        [Column("TransformerBushings", Order = 36, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Transformer Bushings")]
        public string TransformerBushings { get; set; }

        [Column("HVBushing", Order = 37, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(a) H.V. Bushing")]
        public string HVBushing { get; set; }

        [Column("HVBushingType", Order = 38, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = " H.V. Bushing Type")]
        public string HVBushingType { get; set; }

        [Column("LVBushing", Order = 39, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(b) L.V. Bushing")]
        public string LVBushing { get; set; }

        [Column("LVBushingType", Order = 40, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = " L.V. Bushing Type")]
        public string LVBushingType { get; set; }

        [Column("NeutralBushing", Order = 41, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(c) Neutral Bushing")]
        public string NeutralBushing { get; set; }

        [Column("NeutralBushingType", Order = 42, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Bushing Type")]
        public string NeutralBushingType { get; set; }

        [Column("ConservatorWithAirSealedBagForConstantOilPressurYesNo", Order = 43, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Conservator with Air Sealed Bag (for constant oil pressure) (YES / NO)")]
        public string ConservatorWithAirSealedBagForConstantOilPressurYesNo { get; set; }

        [Column("BreatherSilicagel", Order = 44, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Breather (Silicagel)")]
        public string BreatherSilicagel { get; set; }

        [Column("AuxiliaryCircuitVoltageForFanetc3P4W", Order = 45, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Auxiliary Circuit Voltage for Fan, etc., 3P-4W")]
        public string AuxiliaryCircuitVoltageForFanetc3P4W { get; set; }

        [Column("ControlVoltage", Order = 46, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Control Voltage")]
        public string ControlVoltage { get; set; }

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

        [Column("BushingCTParticulars", Order = 50, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Bushing CT Particulars")]
        public string BushingCTParticulars { get; set; }

        [Column("HVside", Order = 51, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "HV Side")]
        public string HVside { get; set; }

        [Column("LVside", Order = 52, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LV Side")]
        public string LVside { get; set; }

        [Column("NeutralSide", Order = 53, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Side")]
        public string NeutralSide { get; set; }

        [Column("NumberOfCoolingFan", Order = 54, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Number of Cooling Fan")] 
        public string NumberOfCoolingFan { get; set; }

        [Column("RatingOfFanMotors", Order = 55, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rating of Fan Motors")]
        public string RatingOfFanMotors { get; set; }

        [Column("CoolingFanLossesAtFullOnafCapacityOperation", Order = 56, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Cooling Fan Losses at full ONAF Capacity Operation")]
        public string CoolingFanLossesAtFullOnafCapacityOperation { get; set; }

        [Column("CoreLossAtRatedFrequencyAndRatedVoltageAtNominalTapNoLoadLoss", Order = 57, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Core Loss at Rated Frequency and Rated Voltage at Nominal Tap. (No Load Loss)")]
        public string CoreLossAtRatedFrequencyAndRatedVoltageAtNominalTapNoLoadLoss { get; set; }

        [Column("CopperLossAtfullloadAtRatedFrequencyAndAt75CFullLoadLoss", Order = 58, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Copper Loss at full Load, at Rated Frequency and at 75°C (Full Load Loss)")]
        public string CopperLossAtFullLoadAtRatedFrequencyAndAt75CFullLoadLoss { get; set; }

        [Column("AtMaximumTap", Order = 59, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(a) At Maximum Tap")]
        public string AtMaximumTap { get; set; }

        [Column("AtNominalTap", Order = 60, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(b) At Nominal Tap")]
        public string AtNominalTap { get; set; }

        [Column("AtMinimumTap", Order = 61, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(c) At Minimum Tap")]
        public string AtMinimumTap { get; set; }

        [Column("RadiatorsYesNo", Order = 62, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Radiators (YES / NO)")]
        public string RadiatorsYesNo { get; set; }

        [Column("OverallDimensions", Order = 63, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Overall Dimensions")]
        public string OverallDimensions { get; set; }

        [Column("NoOfRadiators", Order = 64, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No. of Radiators")]
        public string NoOfRadiators { get; set; }

        [Column("SupervisoryAlarmAndTripContactsYesNo", Order = 65, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Supervisory Alarm and Trip Contacts (YES / NO)")]
        public string SupervisoryAlarmAndTripContactsYesNo { get; set; }

        [Column("TemperatureIndicatorsYesNo", Order = 66, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Temperature Indicators (YES / NO)")]
        public string TemperatureIndicatorsYesNo { get; set; }

        [Column("MakeAndType", Order = 67, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Make and Type")]
        public string MakeAndType { get; set; }

        [Column("AlarmAndTripRange", Order = 68, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Alarm and Trip Range")]
        public string AlarmAndTripRange { get; set; }

        [Column("NoOfContacts", Order = 69, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No. of Contacts")]
        public string NoOfContacts { get; set; }

        [Column("CurrentRatingOfContacts", Order = 70, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Current Rating of Contacts")]
        public string CurrentRatingOfContacts { get; set; }

        [Column("SupervisoryAlarmContact", Order = 70, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Supervisory Alarm Contact")]
        public string SupervisoryAlarmContact { get; set; }

        [Column("DimensionsAndWeightMaximumSizeForTransport", Order = 71, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Dimensions and Weight Maximum size for Transport")]
        public string DimensionsAndWeightMaximumSizeForTransport { get; set; }

        [Column("LMulWMulH", Order = 72, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "L × W × H")]
        public string LMulWMulH { get; set; }

        [Column("WeightOFoil", Order = 73, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Weight of Oil")]
        public string WeightOFoil { get; set; }

        [Column("WeightofCore", Order = 74, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Weight of Core")]
        public string WeightofCore { get; set; }

        [Column("TotalWeight", Order = 75, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Total Weight")]
        public string TotalWeight { get; set; }


        [Column("SanctionedLoad", Order = 77, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Sanctioned Load")]
        public string SanctionedLoad { get; set; }

        [Column("MaximumLoad", Order = 78, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Load")]
        public string MaximumLoad { get; set; }


        [Column(Order = 78, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "33 kV Feeder Line")]
        public string FeederID33KvId { get; set; }
        [ForeignKey("FeederID33KvId")]
        public virtual TblFeederLine PhasePowerTransformerTo33KvFeederLine { get; set; }


        [Column(Order = 79, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Substation")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation PhasePowerTransformerToTblSubstation { get; set; }


        [Column(Order = 80, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Source 132 Or 33kV Substation")]
        public string Source132or33kVSubstationId { get; set; }
        [ForeignKey("Source132or33kVSubstationId")]
        public virtual TblSubstation PhasePowerTransformerToSourceSubstation { get; set; }
    }
}
