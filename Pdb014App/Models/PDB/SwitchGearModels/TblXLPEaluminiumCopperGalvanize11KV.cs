using Pdb014App.Models.PDB.SubstationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class TblXLPEaluminiumCopperGalvanize11KV
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("XLPEaluminiumCopperGalvanize11KVId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "XLPE aluminium Copper Galvanize 11KVId")]
        public int XLPEaluminiumCopperGalvanize11KVId { get; set; }


        [Column("SwitchGearID", Order = 1, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch Gear ID")]
        public string SwitchGearID { get; set; }
        [ForeignKey("SwitchGearID")]
        public virtual TblSwitchGear TblSwitchGear { get; set; }


        [Column("NominalCrossSectionalAreaofPhaseConductor", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal cross sectional area of phase conductor")]
        public string NominalCrossSectionalAreaofPhaseConductor { get; set; }


        [Column("DiameterofPhaseConductor", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Diameter of phase conductor")]
        public string DiameterofPhaseConductor { get; set; }

        [Column("SingleCoreStranding", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Single Core Stranding")]
        public string SingleCoreStranding { get; set; }

        [Column("ThicknessofInsulation", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Thickness of insulation")]
        public string ThicknessofInsulation { get; set; }

        [Column("DiameterOverInsulationApproximately", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Diameter over insulation, approximately")]
        public string DiameterOverInsulationApproximately { get; set; }

        [Column("NominalCrossSectionalAreaofScreen", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal cross sectional area of screen")]
        public string NominalCrossSectionalAreaofScreen { get; set; }

        [Column("ThicknessofOverSheath", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Thickness of over sheath")]
        public string ThicknessofOverSheath { get; set; }

        [Column("OverallDiameterApproximately", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Overall diameter, approximately")]
        public string OverallDiameterApproximately { get; set; }

        [Column("GalvanizedSteelRopeNominalCrossSectionalAreaofRope", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Galvanized Steel rope; Nominal cross sectional area of rope")]
        public string GalvanizedSteelRopeNominalCrossSectionalAreaofRope { get; set; }

        [Column("Stranding", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Stranding")]
        public string Stranding { get; set; }

        [Column("ThicknessofCovering", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Thickness of covering")]
        public string ThicknessofCovering { get; set; }

        [Column("OverallDiameterofRope", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Overall diameter of rope")]
        public string OverallDiameterofRope { get; set; }

        [Column("ThreeCoresStrandedAroundSuspensionUnitDiameterof", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Three cores stranded around suspension unit Diameter of")]
        public string ThreeCoresStrandedAroundSuspensionUnitDiameterof { get; set; }

        [Column("StrandedBundleApproximately", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "stranded bundle, approximately")]
        public string StrandedBundleApproximately { get; set; }

        [Column("TotalWeightApproximately", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Total weight approximately")]
        public string TotalWeightApproximately { get; set; }

        [Column("NominalVoltageratingUOorU", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Voltage rating, Uo/U")]
        public string NominalVoltageratingUOorU { get; set; }

        [Column("MaximumAdmissibleContinuousWorkingVoltage", Order = 19, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum admissible continuous working voltage")]
        public string MaximumAdmissibleContinuousWorkingVoltage { get; set; }

        [Column("MaximumDCResistanceAt20C", Order = 20, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum D.C resistance at 20ºC")]
        public string MaximumDCResistanceAt20C { get; set; }

        [Column("WorkingInductance", Order = 21, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Working inductance")]
        public string WorkingInductance { get; set; }

        [Column("WorkingCapacitance", Order = 22, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Working capacitance")]
        public string WorkingCapacitance { get; set; }

        [Column("EarthLeakageCurrent", Order = 23, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Earth leakage current")]
        public string EarthLeakageCurrent { get; set; }

        [Column("ShortCircuitCurrentOfConductor", Order = 24, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short Circuit Current Of TblConductor")]
        public string ShortCircuitCurrentOfConductor { get; set; }

        [Column("OfScreen", Order = 25, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Of screen")]
        public string OfScreen { get; set; }

        [Column("CurrentRatingatAmbienttempof40C", Order = 26, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Current rating at ambient temp. of 40ºC")]
        public string CurrentRatingatAmbienttempof40C { get; set; }

        [Column("ACTestVoltage", Order = 27, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "A.C Test Voltage")]
        public string ACTestVoltage { get; set; }

        //[Column("Source33or11kVSubStationID", Order = 28, TypeName = "varchar(50)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Source 33/11 kV Sub-station ID")]
        //public string Source33or11kVSubStationID { get; set; }

        //[ForeignKey("Source33or11kVSubStationID")]
        //public virtual TblSubstation CopperGalvanize11KVTo33or11kVSubStation { get; set; }

        [Column("Source33or11kVSubStationID", Order = 1, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "Source 33/11 kV Sub-station ID")]
        public string Source33or11kVSubStationID { get; set; }
        [ForeignKey("Source33or11kVSubStationID")]
        public virtual TblSubstation CopperGalvanize11KVTo33or11kVSubStationID { get; set; }



        //[Column("Source132or33kVSubStationID", Order = 29, TypeName = "varchar(50)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Source 132/33 kV Sub-station ID")]
        //public string Source132or33kVSubStationID { get; set; }

        //[ForeignKey("Source132or33kVSubStationID")]
        //public virtual TblSubstation CopperGalvanize11KVTo132or33kVSubStation { get; set; }

        [Column("Source132or33kVSubStationID", Order = 1, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "Source 132/33 kV Sub-station ID")]
        public string Source132or33kVSubStationID { get; set; }
        [ForeignKey("Source132or33kVSubStationID")]
        public virtual TblSubstation CopperGalvanize11KVTo132or33kVSubStation { get; set; }


        [Column("CurrentCarryingCapacity", Order = 30, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Current Carrying Capacity")]
        public string CurrentCarryingCapacity { get; set; }

    }
}
