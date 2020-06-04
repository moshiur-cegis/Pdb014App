using Pdb014App.Models.PDB.DistributionTransformerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Pdb014App.Models.PDB.DistributionTransformerModel
{
    public class TblDistributionTransformer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Distribution Transformer Id")]
        public string DistributionTransformerId { get; set; }


        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Structure Mounted Surge Arrestor")]
        public string PoleStructureMountedSurgearrestorId { get; set; }
        [ForeignKey("PoleStructureMountedSurgearrestorId")]
        public virtual TblPoleStructureMountedSurgeArrestor PoleStructureMountedSurgeArrestor { get; set; }


        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole (No.)")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole DtToPole { get; set; }


        [Column(Order = 3, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Feeder Line")]
        public string FeederLineId { get; set; }
        [ForeignKey("FeederLineId")]
        public virtual TblFeederLine DtToFeederLine { get; set; }


        [Column("NameOf33bs11kVSubdsstation", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Name of 33/11 kV Sub-station")]
        public string NameOf33bs11kVSubdsstation { get; set; }

        [Column("Nameof11kVFeeder", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Name of 11 kV Feeder")]
        public string Nameof11kVFeeder { get; set; }

        [Column("SNDIdentificationNo", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "SND Identification No.")]
        public string SNDIdentificationNo { get; set; }

        [Column("NearestHoldingbsHouseNobsShop", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nearest Holding/House No./Shop")]
        public string NearestHoldingbsHouseNobsShop { get; set; }

        [Column("ExistingPoleNumberingifAny", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Existing Pole Numbering (if any)")]
        public string ExistingPoleNumberingifAny { get; set; }

        [Column("InstalledConditionPadbsPoleMounted", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installed Condition (Pad/Pole Mounted)")]
        public string InstalledConditionPadbsPoleMounted { get; set; }

        [Column("InstalledPlaceIndoorbsOutdoor", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installed Place (Indoor/Outdoor)")]
        public string InstalledPlaceIndoorbsOutdoor { get; set; }

        [Column("ContractNo", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Contract No.")]
        public string ContractNo { get; set; }

        [Column("OwneroftheTransformerBPDBbsConsumer", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Owner of the Transformer (BPDB/Consumer)")]
        public string OwneroftheTransformerBPDBbsConsumer { get; set; }

        [Column("TransformerKVARating", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Transformer KVA Rating")]
        public string TransformerKVARating { get; set; }

        [Column("YearOfManufacturing", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Year of Manufacturing")]
        public string YearofManufacturing { get; set; }

        [Column("NameofManufacturer", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Name of Manufacturer")]
        public string NameofManufacturer { get; set; }

        [Column("TransformerSerialNo", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Transformer Serial No.")]
        public string TransformerSerialNo { get; set; }

        [Column("RatedHTVoltage", Order = 19, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated HT Voltage")]
        public string RatedHTVoltage { get; set; }

        [Column("RatedLTVoltage", Order = 20, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated LT Voltage")]
        public string RatedLTVoltage { get; set; }

        [Column("RatedHTCurrent", Order = 21, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated HT Current")]
        public string RatedHTCurrent { get; set; }

        [Column("RatedLTCurrent", Order = 22, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated LT Current")]
        public string RatedLTCurrent { get; set; }

        [Column("ControlVoltage", Order = 23, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Control Voltage")]
        public string ControlVoltage { get; set; }

        [Column("MotorVoltageforspringcharge", Order = 24, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Motor Voltage for Spring Charge")]
        public string MotorVoltageforspringcharge { get; set; }

        [Column("RatedVoltage", Order = 25, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }

        [Column("BodyColourCondition", Order = 26, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Body Color Condition (if old) (Touch Painted/Newly Painted/FullyRusted/Partially Rusted)")]
        public string BodyColourCondition { get; set; }

        [Column("NameoBodyColour", Order = 27, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Name of Body Color")]
        public string NameoBodyColour { get; set; }

        [Column("OilLeakageYesOrNo", Order = 28, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Oil Leakage (Yes/No)")]
        public string OilLeakageYesOrNo { get; set; }

        [Column("PlaceofOilLeakageMark", Order = 29, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Place of Oil Leakage Mark")]
        public string PlaceofOilLeakageMark { get; set; }

        [Column("PlatformMaterialAnglbsChannel", Order = 30, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Platform Material (Angle/Channel)")]
        public string PlatformMaterialAnglbsChannel { get; set; }

        [Column("PlatformStandardbsNonStandardGoodBad", Order = 31, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Platform (Standard/Non Standard/Good/Bad)")]
        public string PlatformStandardbsNonStandardGoodBad { get; set; }

        [Column("TypeofTransformerSupportPoleLeft", Order = 32, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Transformer Support Pole (Left) (Steel/SPC/Concrete)")]
        public string TypeofTransformerSupportPoleLeft { get; set; }

        [Column("ConditionofTransformerSupportPoleLeft", Order = 33, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Transformer Support Pole (Left) (Good/Broken/Rusted/Corrosion Exist)")]
        public string ConditionofTransformerSupportPoleLeft { get; set; }

        [Column("TypeofTransformerSupportPoleRight", Order = 34, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Transformer Support Pole (Right) (Steel/SPC/Concrete)")]
        public string TypeofTransformerSupportPoleRight { get; set; }

        [Column("ConditionofTransformerSupportPoleRight", Order = 35, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Transformer Support Pole (Right) (Good/Broken/Rusted/Corrosion Exist)")]
        public string ConditionofTransformerSupportPoleRight { get; set; }

        [Column("HTBushingRPhaseOil", Order = 36, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T. Bushing-R Phase Oil Leakage (Yes/No)")]
        public string HTBushingRPhaseOil { get; set; }

        [Column("HTBushingRPhaseGood", Order = 37, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T. Bushing-R Phase Bushing (Good/Broken)")]
        public string HTBushingRPhaseGood { get; set; }

        [Column("HTBushingRPhaseColor", Order = 38, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T. Bushing-R Phase Bushing Color")]
        public string HTBushingRPhaseColor { get; set; }

        [Column("HTBushingYPhaseOil", Order = 39, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T Bushing-Y Phase  Oil Leakage (Yes/No)")]
        public string HTBushingYPhaseOil { get; set; }

        [Column("HTBushingYPhaseGood", Order = 40, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T Bushing-Y Phase  Bushing (Good/Broken)")]
        public string HTBushingYPhaseGood { get; set; }

        [Column("HTBushingYPhaseColor", Order = 41, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T Bushing-Y Phase  Bushing Color")]
        public string HTBushingYPhaseColor { get; set; }

        [Column("HTBushingBPhaseOil", Order = 42, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "HT Bushing-B Phase  Oil Leakage (Yes/No)")]
        public string HTBushingBPhaseOil { get; set; }

        [Column("HTBushingBPhaseGood", Order = 43, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T. Bushing-B Phase Bushing (Good/Broken)")]
        public string HTBushingBPhaseGood { get; set; }

        [Column("HTBushingBPhaseColor", Order = 44, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T. Bushing-B Phase Bushing Color")]
        public string HTBushingBPhaseColor { get; set; }

        [Column("HTBushingNPhaseOil", Order = 45, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "HT Bushing-N Phase  Oil Leakage (Yes/No)")]
        public string HTBushingNPhaseOil { get; set; }

        [Column("HTBushingNPhaseGood", Order = 46, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T. Bushing-N Phase Bushing (Good/Broken)")]
        public string HTBushingNPhaseGood { get; set; }

        [Column("HTBushingNPhaseColor", Order = 47, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "H.T. Bushing-N Phase Bushing Color")]
        public string HTBushingNPhaseColor { get; set; }

        [Column("LTBushingRPhaseOil", Order = 48, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT. Bushing-R Phase  Oil Leakage (Yes/No)")]
        public string LTBushingRPhaseOil { get; set; }

        [Column("LTBushingRPhaseGood", Order = 49, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT. Bushing-R Phase  Bushing (Good/Broken)")]
        public string LTBushingRPhaseGood { get; set; }

        [Column("LTBushingRPhaseColor", Order = 50, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT. Bushing-R Phase  Bushing Color")]
        public string LTBushingRPhaseColor { get; set; }

        [Column("LTBushingYPhaseOil", Order = 51, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-Y Phase  Oil Leakage (Yes/No)")]
        public string LTBushingYPhaseOil { get; set; }

        [Column("LTBushingYPhaseGood", Order = 52, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-Y Phase   Bushing (Good/Broken)")]
        public string LTBushingYPhaseGood { get; set; }

        [Column("LTBushingYPhaseColor", Order = 53, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-Y Phase  Bushing Color")]
        public string LTBushingYPhaseColor { get; set; }

        [Column("LTBushingBPhaseOil", Order = 54, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-B Phase  Oil Leakage (Yes/No)")]
        public string LTBushingBPhaseOil { get; set; }

        [Column("LTBushingBPhaseGood", Order = 55, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-B Phase   Bushing (Good/Broken)")]
        public string LTBushingBPhaseGood { get; set; }

        [Column("LTBushingBPhaseColor", Order = 56, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-B Phase   Bushing Color")]
        public string LTBushingBPhaseColor { get; set; }

        [Column("LTBushingNPhaseOil", Order = 57, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-N Phase  Oil Leakage (Yes/No)")]
        public string LTBushingNPhaseOil { get; set; }

        [Column("LTBushingNPhaseGood", Order = 58, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-N Phase  Bushing (Good/Broken)")]
        public string LTBushingNPhaseGood { get; set; }

        [Column("LTBushingNPhaseColor", Order = 59, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LT Bushing-N Phase Bushing Color")]
        public string LTBushingNPhaseColor { get; set; }

        [Column("WireSizeofHTDrop", Order = 60, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Wire Size of HT Drop")]
        public string WireSizeofHTDrop { get; set; }

        [Column("ConditionofHTDropGoodbsBad", Order = 61, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of HT Drop (Good/Bad)")]
        public string ConditionofHTDropGoodbsBad { get; set; }

        [Column("WirebsCableSizeofLTDropCKT1", Order = 62, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Wire/Cable Size of LT Drop-CKT-1")]
        public string WirebsCableSizeofLTDropCKT1 { get; set; }

        [Column("ConditionofLTDropGoodbsBadCKT1", Order = 63, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of LT Drop (Good/Bad)-CKT-1")]
        public string ConditionofLTDropGoodbsBadCKT1 { get; set; }

        [Column("WirebsCableSizeofLTDropCKT2", Order = 64, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Wire/Cable Size of LT Drop-CKT-2")]
        public string WirebsCableSizeofLTDropCKT2 { get; set; }

        [Column("ConditionofLTDropGoodbsBadCKT2", Order = 65, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of LT Drop (Good/Bad)-CKT-2")]
        public string ConditionofLTDropGoodbsBadCKT2 { get; set; }

        [Column("EarthingLead1", Order = 66, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earthing Lead-1")]
        public string EarthingLead1 { get; set; }

        [Column("EarthingLead1Size", Order = 67, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earthing Lead-1 : Size ")]
        public string EarthingLead1Size { get; set; }

        [Column("EarthingLead1Material", Order = 68, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earthing Lead-1 : Material ")]
        public string EarthingLead1Material { get; set; }

        [Column("EarthingLead1ConditionStandard", Order = 69, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earthing Lead-1 : Condition (Standard/Non Standard/Good/Bad)")]
        public string EarthingLead1ConditionStandard { get; set; }

        [Column("EarthingLead2", Order = 70, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earthing Lead-2 :")]
        public string EarthingLead2 { get; set; }

        [Column("EarthingLead2Size", Order = 71, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earthing Lead-2 : Size")]
        public string EarthingLead2Size { get; set; }

        [Column("EarthingLead2Material", Order = 72, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earthing Lead-2 : Material")]
        public string EarthingLead2Material { get; set; }

        [Column("EarthingLead2ConditionStandard", Order = 73, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earthing Lead-2 : Condition (Standard/Non Standard/Good/Bad)")]
        public string EarthingLead2ConditionStandard { get; set; }

        [Column("DayPeak", Order = 74, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Day Peak")]
        public string DayPeak { get; set; }

        [Column("DateAndtime1", Order = 75, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Date & Time")]
        public string DateAndtime1 { get; set; }

        [Column("Voltage1", Order = 76, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Voltage")]
        public string Voltage1 { get; set; }

        [Column("RYVoltageVolt1", Order = 77, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-Y-Voltage (Volt)")]
        public string RYVoltageVolt1 { get; set; }

        [Column("YBVoltageVolt1", Order = 78, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-B-Voltage (Volt)")]
        public string YBVoltageVolt1 { get; set; }

        [Column("RBVoltageVolt1", Order = 79, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-B-Voltage (Volt)")]
        public string RBVoltageVolt1 { get; set; }

        [Column("RNVoltageVolt1", Order = 80, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-N Voltage (Volt)")]
        public string RNVoltageVolt1 { get; set; }

        [Column("YNVoltageVolt1", Order = 81, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-N Voltage (Volt)")]
        public string YNVoltageVolt1 { get; set; }

        [Column("BNVoltageVolt1", Order = 82, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "B-N Voltage (Volt)")]
        public string BNVoltageVolt1 { get; set; }

        [Column("LeakageVoltageBodyEarthVolt1", Order = 83, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Leakage Voltage (Body-Earth) (Volt)")]
        public string LeakageVoltageBodyEarthVolt1 { get; set; }

        [Column("RPhaseCurrentAmps1Ckt1", Order = 84, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-Phase Current (Amps)1 Ckt1")]
        public string RPhaseCurrentAmps1Ckt1 { get; set; }

        [Column("RPhaseCurrentAmps1Ckt2", Order = 85, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-Phase Current (Amps)1 Ckt2")]
        public string RPhaseCurrentAmps1Ckt2 { get; set; }

        [Column("RPhaseCurrentAmps1Ckt3", Order = 86, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-Phase Current (Amps)1 Ckt3")]
        public string RPhaseCurrentAmps1Ckt3 { get; set; }

        [Column("YPhaseCurrentAmps1Ckt1", Order = 87, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-Phase Current (Amps)1 Ckt1")]
        public string YPhaseCurrentAmps1Ckt1 { get; set; }

        [Column("YPhaseCurrentAmps1Ckt2", Order = 88, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-Phase Current (Amps)1 Ckt2")]
        public string YPhaseCurrentAmps1Ckt2 { get; set; }

        [Column("YPhaseCurrentAmps1Ckt3", Order = 89, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-Phase Current (Amps)1 Ckt3")]
        public string YPhaseCurrentAmps1Ckt3 { get; set; }

        [Column("BPhaseCurrentAmps1Ckt1", Order = 90, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "B-Phase Current (Amps)1 Ckt1")]
        public string BPhaseCurrentAmps1Ckt1 { get; set; }

        [Column("BPhaseCurrentAmps1Ckt2", Order = 91, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "B-Phase Current (Amps)1 Ckt2")]
        public string BPhaseCurrentAmps1Ckt2 { get; set; }

        [Column("BPhaseCurrentAmps1Ckt3", Order = 92, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "B-Phase Current (Amps)1 Ckt3")]
        public string BPhaseCurrentAmps1Ckt3 { get; set; }

        [Column("NeutralCurrentAmps1Ckt1", Order = 93, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Current (Amps)1 Ckt1")]
        public string NeutralCurrentAmps1Ckt1 { get; set; }

        [Column("NeutralCurrentAmps1Ckt2", Order = 94, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Current (Amps)1 Ckt2")]
        public string NeutralCurrentAmps1Ckt2 { get; set; }

        [Column("NeutralCurrentAmps1Ckt3", Order = 95, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Current (Amps)1 Ckt3")]
        public string NeutralCurrentAmps1Ckt3 { get; set; }

        [Column("CalculatedDayPeakkVA", Order = 96, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Calculated Day Peak (kVA)")]
        public string CalculatedDayPeakkVA { get; set; }

        [Column("EveningPeak", Order = 97, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Evening Peak")]
        public string EveningPeak { get; set; }

        [Column("DateAndTime2", Order = 98, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Date & Time")]
        public string DateAndTime2 { get; set; }

        [Column("Voltage2", Order = 99, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Voltage")]
        public string Voltage2 { get; set; }

        [Column("RYVoltageVolt2", Order = 100, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-Y-Voltage (Volt)")]
        public string RYVoltageVolt2 { get; set; }

        [Column("YBVoltageVolt2", Order = 101, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-B-Voltage (Volt)")]
        public string YBVoltageVolt2 { get; set; }

        [Column("RBVoltageVolt2", Order = 102, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-B-Voltage (Volt)")]
        public string RBVoltageVolt2 { get; set; }

        [Column("RNVoltageVolt2", Order = 103, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-N Voltage (Volt)")]
        public string RNVoltageVolt2 { get; set; }

        [Column("YNVoltageVolt", Order = 104, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-N Voltage (Volt)")]
        public string YNVoltageVolt { get; set; }

        [Column("BNVoltageVolt2", Order = 105, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "B-N Voltage (Volt)")]
        public string BNVoltageVolt2 { get; set; }

        [Column("LeakageVoltageBodyEarthVolt2", Order = 106, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Leakage Voltage (Body-Earth) (Volt)")]
        public string LeakageVoltageBodyEarthVolt2 { get; set; }

        [Column("RPhaseCurrentAmps2Ckt1", Order = 107, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-Phase Current (Amps) 2Ckt1")]
        public string RPhaseCurrentAmps2Ckt1 { get; set; }

        [Column("RPhaseCurrentAmps2Ckt2", Order = 108, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-Phase Current (Amps) 2Ckt2")]
        public string RPhaseCurrentAmps2Ckt2 { get; set; }

        [Column("RPhaseCurrentAmps2Ckt3", Order = 109, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "R-Phase Current (Amps) 2Ckt3")]
        public string RPhaseCurrentAmps2Ckt3 { get; set; }

        [Column("YPhaseCurrentAmps2Ckt1", Order = 110, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-Phase Current (Amps) 2Ckt1")]
        public string YPhaseCurrentAmps2Ckt1 { get; set; }

        [Column("YPhaseCurrentAmps2Ckt2", Order = 111, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-Phase Current (Amps) 2Ckt2")]
        public string YPhaseCurrentAmps2Ckt2 { get; set; }

        [Column("YPhaseCurrentAmps2Ckt3", Order = 112, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Y-Phase Current (Amps) 2Ckt3")]
        public string YPhaseCurrentAmps2Ckt3 { get; set; }

        [Column("BPhaseCurrentAmps2Ckt1", Order = 113, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "B-Phase Current (Amps) 2Ckt1")]
        public string BPhaseCurrentAmps2Ckt1 { get; set; }

        [Column("BPhaseCurrentAmps2Ckt2", Order = 114, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "B-Phase Current (Amps) 2Ckt2")]
        public string BPhaseCurrentAmps2Ckt2 { get; set; }

        [Column("BPhaseCurrentAmps2Ckt3", Order = 115, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "B-Phase Current (Amps) 2Ckt3")]
        public string BPhaseCurrentAmps2Ckt3 { get; set; }

        [Column("NeutralCurrentAmpsCkt1", Order = 116, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Current (Amps) 2Ckt1")]
        public string NeutralCurrentAmpsCkt1 { get; set; }

        [Column("NeutralCurrentAmps2Ckt2", Order = 117, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Current (Amps) 2Ckt2")]
        public string NeutralCurrentAmps2Ckt2 { get; set; }

        [Column("NeutralCurrentAmps2Ckt3", Order = 118, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Current (Amps) 2Ckt3")]
        public string NeutralCurrentAmps2Ckt3 { get; set; }

        [Column("CalculatedEveningPeakkVA", Order = 119, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Calculated Evening Peak (kVA)")]
        public string CalculatedEveningPeakkVA { get; set; }

        [Column("DropOutFuseExistbsNotExistRphase", Order = 120, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Drop Out Fuse (Exist/Not Exist) R-phase")]
        public string DropOutFuseExistbsNotExistRphase { get; set; }

        [Column("DropOutFuseExistbsNotExistYphase", Order = 121, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Drop Out Fuse (Exist/Not Exist) Y-phase")]
        public string DropOutFuseExistbsNotExistYphase { get; set; }

        [Column("DropOutFuseExistbsNotExistBphase", Order = 122, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Drop Out Fuse (Exist/Not Exist) B-phase")]
        public string DropOutFuseExistbsNotExistBphase { get; set; }

        [Column("ConditionofDropOutFuseRphase", Order = 123, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Drop Out Fuse (Working/Not Working/Good/Bad) R-phase")]
        public string ConditionofDropOutFuseRphase { get; set; }

        [Column("ConditionofDropOutFuseYphase", Order = 124, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Drop Out Fuse (Working/Not Working/Good/Bad) Y-phase")]
        public string ConditionofDropOutFuseYphase { get; set; }

        [Column("ConditionofDropOutFuseBphase", Order = 125, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Drop Out Fuse (Working/Not Working/Good/Bad) B-phase")]
        public string ConditionofDropOutFuseBphase { get; set; }

        [Column("LightningArrestorRphase", Order = 126, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Lightning Arrestor (Exist/Not Exist) R-phase")]
        public string LightningArrestorRphase { get; set; }

        [Column("LightningArrestorYphase", Order = 127, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Lightning Arrestor (Exist/Not Exist) Y-phase")]
        public string LightningArrestorYphase { get; set; }

        [Column("LightningArrestorBphase", Order = 128, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Lightning Arrestor (Exist/Not Exist) B-phase")]
        public string LightningArrestorBphase { get; set; }

        [Column("ConditionofLightingArrestorRphase", Order = 129, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Lighting Arrestor (Working/Not Working/Good/Bad) R-phase ")]
        public string ConditionofLightingArrestorRphase { get; set; }

        [Column("ConditionofLightingArrestorYphase", Order = 130, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Lighting Arrestor (Working/Not Working/Good/Bad) Y-phase ")]
        public string ConditionofLightingArrestorYphase { get; set; }

        [Column("ConditionofLightingArrestorBphase", Order = 131, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Lighting Arrestor (Working/Not Working/Good/Bad) B-phase ")]
        public string ConditionofLightingArrestorBphase { get; set; }

        [Column("DistributionBoxExistbsnotExist", Order = 132, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Distribution Box (Exist/not exist)")]
        public string DistributionBoxExistbsnotExist { get; set; }

        [Column("ConditionofDistributionBox", Order = 133, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of Distribution Box (Working/Not Working/Good/Bad)")]
        public string ConditionofDistributionBox { get; set; }

        [Column("NoOfMCCB", Order = 134, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No. of MCCB")]
        public string NoOfMCCB { get; set; }

        [Column("ManufacturerTypeOriginofMCCBforCircuit1", Order = 135, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturer /Type/origin of MCCB for Circuit-1")]
        public string ManufacturerTypeOriginofMCCBforCircuit1 { get; set; }

        [Column("ManufacturerTypeOriginofMCCBforCircuit2", Order = 136, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturer /Type/origin of MCCB for Circuit-2")]
        public string ManufacturerTypeOriginofMCCBforCircuit2 { get; set; }

        [Column("AmpereRatingasPerNamePlateofMCCBforCKT1", Order = 137, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Ampere Rating (as per name plate) of MCCB for CKT-1")]
        public string AmpereRatingasPerNamePlateofMCCBforCKT1 { get; set; }

        [Column("AmpereRatingasPerNameplateOfMCCBForCKT2", Order = 138, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Ampere Rating (as per name plate) of MCCB for CKT-2")]
        public string AmpereRatingasPerNameplateOfMCCBForCKT2 { get; set; }

        [Column("ConditionofMCCBforCircuit1", Order = 139, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of MCCB for Circuit-1 (Working/Not Working/Good/Bad)")]
        public string ConditionofMCCBforCircuit1 { get; set; }
        //[ForeignKey("ConditionofMCCBforCircuit1")]
        //public virtual LookUpDtCondition ConditionofMCCBforCircuit1ToCondition { get; set; }

        [Column("ConditionofMCCBforCircuit2", Order = 140, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Condition of MCCB for Circuit-2 (Working/Not Working/Good/Bad)")]
        public string ConditionofMCCBforCircuit2 { get; set; }

        //[ForeignKey("ConditionofMCCBforCircuit2")]
        //public virtual LookUpDtCondition ConditionofMCCBforCircuit2ToCondition { get; set; }

        [Column("Recommendation", Order = 141, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Recommendation")]
        public string Recommendation { get; set; }

    }
}
