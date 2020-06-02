using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Pdb014App.Models.PDB.LookUpModels;


namespace Pdb014App.Models.PDB
{
    public class TblPole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("PoleId", Order = 0, TypeName = "varchar(50)")]
        //[StringLength(50, ErrorMessage = "The {0} must be at least {15} and at max {15} characters long.", MinimumLength = 15)]
        [Display(Name = "Pole Id")]
        public string PoleId { get; set; }

        [Column("PoleUid", Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Uid")]
        public string PoleUid { get; set; }

        //[Column(Order = 1)]
        //[StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        //[Display(Name = "Survey Date")]
        //public DateTime SurveyDate { get; set; }

        [Column("SurveyDate", Order = 2, TypeName = "date")]
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Survey Date")]
        public DateTime? SurveyDate { get; set; }

        //FeederName
        [Required]
        [Column("FeederLineId", Order = 3, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Feeder Line")]
        public string FeederLineId { get; set; }
        [ForeignKey("FeederLineId")] public virtual TblFeederLine PoleToFeederLine { get; set; }


        [Column("FeederLineUid", Order = 4, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Feeder Line Uid")]
        public string FeederLineUid { get; set; }


        //[Required]
        [Column("FeederWiseSerialNo", Order = 5, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Feeder wise Serial No.")]
        public int? FeederWiseSerialNo { get; set; }

        //DetailsOfPoles&33/11KvLine
        //[Required]
        //[Column("DetailsOfPolesAnd33By11KvLine", Order = 4, TypeName = "nvarchar(250)")]
        //[StringLength(250)]
        //[Display(Name = "Details of Poles & 33/11 Kv Line")]
        //public string DetailsOfPolesAnd33By11KvLine { get; set; }


        [Required]
        [Column("RouteCode", Order = 6, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Route Code")]
        public string RouteCode { get; set; }

        [ForeignKey("RouteCode")] public virtual LookUpRouteInfo PoleToRoute { get; set; }

        //SurveyorName
        [Column("SurveyorName", Order = 7, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Surveyor's Name")]
        public string SurveyorName { get; set; }


        //[Required]
        [Column("PoleNo", Order = 8, TypeName = "nvarchar(50)")]
        [StringLength(250)]
        [Display(Name = "Pole No.")]
        public string PoleNo { get; set; }

        [Column("PreviousPoleNo", Order = 9, TypeName = "nvarchar(50)")]
        [StringLength(250)]
        [Display(Name = "Previous Pole No.")]
        public string PreviousPoleNo { get; set; }


        [Column("Latitude", Order = 10, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; }


        [Column("Longitude", Order = 11, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; }

        [Required]
        [Column("PoleTypeId", Order = 12, TypeName = "varchar(6)")]
        [StringLength(6)]
        [Display(Name = "Pole Type")]
        public string PoleTypeId { get; set; }
        [ForeignKey("PoleTypeId")] 
        public virtual LookUpPoleType PoleType { get; set; }


        [Required]
        [Column("PoleConditionId", Order = 13, TypeName = "varchar(6)")]
        [StringLength(6)]
        [Display(Name = "Pole Condition")]
        public string PoleConditionId { get; set; }

        [ForeignKey("PoleConditionId")] public virtual LookUpPoleCondition PoleCondition { get; set; }

        //9       //LookUpLineType
        [Column("LineTypeId", Order = 14, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Line Type")]
        public int? LineTypeId { get; set; }

        [ForeignKey("LineTypeId")] public virtual LookUpLineType LookUpLineType { get; set; }

        //BackSpan(m)
        [Column("BackSpan", Order = 15, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Back Span(m)")]
        public string BackSpan { get; set; }


        #region

        //NoOfPole
        //[Column("NoOfPoleId", Order = 16, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "No of Pole")]
        //public int? NoOfPoleId { get; set; }
        //[ForeignKey("NoOfPoleId")]
        //public virtual NoOfPole NoOfPole { get; set; }

        //LookUpGuyCondition
        //[Column("TypeOfConductorId", Order = 17, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Type of TblConductor")]
        //public int? TypeOfConductorId { get; set; }
        //[ForeignKey("TypeOfConductorId")]
        //public virtual LookUpGuyCondition LookUpGuyCondition { get; set; }

        //11        //LookUpTypeOfWire
        [Column("TypeOfWireId", Order = 13, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Wire")]
        public int? TypeOfWireId { get; set; }

        [ForeignKey("TypeOfWireId")] public virtual LookUpTypeOfWire LookUpTypeOfWire { get; set; }

        //NoOfWire
        [Column("NoOfWireHt", Order = 14, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "No of Wire HT")]
        public int? NoOfWireHt { get; set; }

        [Column("NoOfWireLt", Order = 15, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "No of Wire LT")]
        public int? NoOfWireLt { get; set; }


        //WireLength(m)       

        [Column("WireLength", Order = 16, TypeName = "decimal(10, 2)")]
        [DataType(DataType.Text)]
        [Range(0, 9999999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "WireL ength")]
        public decimal? WireLength { get; set; }


        //14       //WireLookUpCondition
        [Column("WireConditionId", Order = 17, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Wire Condition")]
        public int? WireConditionId { get; set; }
        [ForeignKey("WireConditionId")] public virtual LookUpCondition WireLookUpCondition { get; set; }

        #endregion
        
        //MSJ(No)
        [Column("MSJNo", Order = 18, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "MSJ (No.)")]
        public string MSJNo { get; set; }

        //Sleeve(No)
        [Column("SleeveNo", Order = 19, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Sleeve (No.)")]
        public string SleeveNo { get; set; }

        //Twist(No)
        [Column("TwistNo", Order = 20, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Twist (No.)")]
        public string TwistNo { get; set; }


        //[Required]
        [Column("PhaseAId", Order = 21, TypeName = "varchar(6)")]
        [StringLength(6)]
        [Display(Name = "Phase A (R)")]
        public string PhaseAId { get; set; }
        [Display(Name = "Phase A (R)")]
        [ForeignKey("PhaseAId")] public virtual LookUpSagCondition PhaseACondition { get; set; }


        //[Required]
        [Column("PhaseBId", Order = 22, TypeName = "varchar(6)")]
        [StringLength(6)]
        [Display(Name = "Phase B (Y)")]
        public string PhaseBId { get; set; }
        [ForeignKey("PhaseBId")] public virtual LookUpSagCondition PhaseBCondition { get; set; }


        //[Required]
        [Column("PhaseCId", Order = 23, TypeName = "varchar(6)")]
        [StringLength(6)]
        [Display(Name = "Phase C (B)")]
        public string PhaseCId { get; set; }
        [ForeignKey("PhaseCId")] public virtual LookUpSagCondition PhaseCCondition { get; set; }

        //Neutral
        [Column("Neutral", Order = 24, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Neutral")]
        public string Neutral { get; set; }

        //StreetLight
        [Column("StreetLight", Order = 25, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Street Light")]
        public string StreetLight { get; set; }

        #region FittingsLookUpCondition

        //23       //TypeOfFitting
        //        [Column("TypeOfFittingsId", Order = 30, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "Type of Fittings")]
        //        public int? TypeOfFittingsId { get; set; }
        //        [ForeignKey("TypeOfFittingsId")]
        //        public virtual LookUpTypeOfFittings LookUpTypeOfFittings { get; set; }

        //        //NoOfSetFittings
        //        [Column("NoOfSetFittings", Order = 31, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "No of Set Fittings")]
        //        public int? NoOfSetFittings { get; set; }

        ////25        //FittingsLookUpCondition
        //        [Column("FittingsConditionId", Order = 32, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "Fittings Condition")]
        //        public int? FittingsConditionId { get; set; }
        //        [ForeignKey("FittingsConditionId")]
        //        public virtual LookUpCondition FittingsLookUpCondition { get; set; }

        #endregion

        #region TblCrossArm

        //[Column("CrossArmId", Order = 23, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Cross Arm")]
        //public int? CrossArmId { get; set; }
        //[ForeignKey("CrossArmId")]
        //public virtual TblCrossArm PoleToCrossArm { get; set; }

        //[Column("SideLockTieTerminalClampMerlinId", Order = 24, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Side Lock Tie Terminal Clamp Merlin")]
        //public int? SideLockTieTerminalClampMerlinId { get; set; }
        //[ForeignKey("SideLockTieTerminalClampMerlinId")]
        //public virtual LookUpSideLockTieTerminalClampMerlin PoleToSideLockTieTerminalClampMerlin { get; set; }

        //[Column("AacInsulatorId", Order = 25, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Aac Insulator")]
        //public int? AacInsulatorId { get; set; }
        //[ForeignKey("AacInsulatorId")]
        //public virtual TblAacInsulator PoleToAacInsulator { get; set; }

        //[Column("InsulatorDisktId", Order = 26, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Insulator Disk")]
        //public int? InsulatorDisktId { get; set; }
        //[ForeignKey("InsulatorDisktId")]
        //public virtual TblInsulatorDisk PoleToInsulatorDisk { get; set; }

        //[Column("InsulatorPinId", Order = 27, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Insulator Pin")]
        //public int? InsulatorPinId { get; set; }
        //[ForeignKey("InsulatorPinId")]
        //public virtual TblInsulatorPinAndPost PoleToInsulatorPin { get; set; }

        //[Column("InsulatorPostId", Order = 28, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Insulator Post")]
        //public int? InsulatorPostId { get; set; }
        //[ForeignKey("InsulatorPostId")]
        //public virtual TblInsulatorPinAndPost PoleToInsulatorPost { get; set; }

        //[Column("InsulatorShackleId", Order = 29, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Insulator Shackle")]
        //public int? InsulatorShackleId { get; set; }
        //[ForeignKey("InsulatorShackleId")]
        //public virtual TblInsulatorShackleOrGuy PoleToInsulatorShackle { get; set; }

        //[Column("InsulatorGuyId", Order = 30, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Insulator Guy")]
        //public int? InsulatorGuyId { get; set; }
        //[ForeignKey("InsulatorGuyId")]
        //public virtual TblInsulatorShackleOrGuy PoleToInsulatorGuy { get; set; }

        #endregion


        //[Column(Order = 26, TypeName = "varchar(50)")]
        //[StringLength(50)]
        //[Display(Name = "Source Cable")]
        //public string SourceCableId { get; set; }
        //[ForeignKey("SourceCableId")]
        //public virtual TblFeederLine PoleToSourceFeederLine { get; set; }


        //[Column(Order = 27, TypeName = "varchar(50)")]
        //[StringLength(50)]
        //[Display(Name = "Target Cable")]
        //public string TargetCableId { get; set; }
        //[ForeignKey("TargetCableId")]
        //public virtual TblFeederLine PoleToTargetFeederLine { get; set; }


        #region LookUpTypeOfInsulator


        //        //26       //LookUpTypeOfInsulator
        //        [Column("TypeOfInsulatorId", Order = 33, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "Type of Insulator")]
        //        public int? TypeOfInsulatorId { get; set; }
        //        [ForeignKey("TypeOfInsulatorId")]
        //        public virtual LookUpTypeOfInsulator LookUpTypeOfInsulator { get; set; }

        //        //Quantity(No)
        //        [Column("Quantity", Order = 34, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "Quantity (No)")]
        //        public int? Quantity { get; set; }

        // //28       //InsulatorLookUpCondition
        //        [Column("InsulatorConditionId", Order = 35, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "Insulator Condition")]
        //        public int? InsulatorConditionId { get; set; }
        //        [ForeignKey("InsulatorConditionId")]
        //        public virtual LookUpCondition InsulatorLookUpCondition { get; set; }

        ////29        //LookUpGuyType
        //        [Column("GuyTypeId", Order = 36, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "Guy Type")]
        //        public int? GuyTypeId { get; set; }
        //        [ForeignKey("GuyTypeId")]
        //        public virtual LookUpGuyType LookUpGuyType { get; set; }

        //        //GuyNoOfSet
        //        [Column("GuyNoOfSet", Order = 37, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "No of Set")]
        //        public int? GuyNoOfSet { get; set; }

        ////31        //LookUpGuyType
        //        [Column("GuyConditionId", Order = 38, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "Guy Condition")]
        //        public int? GuyConditionId { get; set; }
        //        [ForeignKey("GuyConditionId")]
        //        public virtual LookUpGuyCondition LookUpGuyCondition { get; set; }

        #endregion

        [Column("TransformerExist", Order = 28, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Transformer Exist")]
        public string TransformerExist { get; set; }

        [Column("CommonPole", Order = 29, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Common Pole")]
        public string CommonPole { get; set; }

        [Column("Tap", Order = 30, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Tap")]
        public string Tap { get; set; }

    }

}
