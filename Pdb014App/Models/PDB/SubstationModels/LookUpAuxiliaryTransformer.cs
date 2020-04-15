using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class LookUpAuxiliaryTransformer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AuxiliaryTransformerId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "AuxiliaryTransformerId")]
        public int AuxiliaryTransformerId { get; set; }

        //[Column("SubstationId", Order = 2, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "SubstationId")]
        //public int? SubstationId { get; set; }   //FK
        //[ForeignKey("SubstationId")]
        //public virtual TblSubstation AuxiliaryTransformerToSubstation { get; set; }

        [Column("SubstationId", Order = 2, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "SubstationId")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation AuxiliaryTransformerToSubstation { get; set; }


        [Column("ManufacturersNameAndAddress", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Address")]
        public string ManufacturersNameAndAddress { get; set; }
        [Column("ManufacturersTypeAndModelNo", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Type   & Model No.")]
        public string ManufacturersTypeAndModelNo { get; set; }
        [Column("KVARating", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "K V A Rating")]
        public string KVARating { get; set; }
        [Column("NumberOfPhases", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Number of Phases")]
        public string NumberOfPhases { get; set; }
        [Column("RatedFrequencyHz", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated frequency, Hz")]
        public string RatedFrequencyHz { get; set; }
        [Column("RatedPrimaryvoltageKV", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated primary voltage , K V")]
        public string RatedPrimaryvoltageKV { get; set; }
        [Column("RatedNoloadsecVoltageV", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated no load sec. voltage, V")]
        public string RatedNoloadsecVoltageV { get; set; }
        [Column("VectorGroup", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Vector group")]
        public string VectorGroup { get; set; }
        [Column("HighestSystemVoltageof", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Highest system voltage of:")]
        public string HighestSystemVoltageof { get; set; }
        [Column("PrimaryWindingKV", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "a) Primary Winding, KV")]
        public string PrimaryWindingKV { get; set; }
        [Column("SecondaryWindingKv", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "b) Secondary Winding, Kv")]
        public string SecondaryWindingKv { get; set; }
        [Column("BasicInsulationLevelKV", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Basic insulation level, KV")]
        public string BasicInsulationLevelKV { get; set; }
        [Column("PowerFrequencyWithstandVoltageKV", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Power frequency withstand voltage, KV")]
        public string PowerFrequencyWithstandVoltageKV { get; set; }
        [Column("HTSide", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "a) HT Side")]
        public string HTSide { get; set; }
        [Column("LTSide", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "b) LT Side")]
        public string LTSide { get; set; }

        [Column("TypeOfCooling", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of cooling")]
        public string TypeOfCooling { get; set; }


        [Column("MaxTempRiseover40CofambientSupportedByCalculation", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Max Temp. Riseover 40 C of ambient Supported By Calculation")]
        public string MaxTempRiseover40CofambientSupportedByCalculation { get; set; }

        [Column("WindingdegC", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "a) Winding deg.C")]
        public string WindingdegC { get; set; }
        [Column("TopOildegC", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "b) Top oil deg, C")]
        public string TopOildegC { get; set; }
        [Column("TypeofPrimaryTappingOffload", Order = 19, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of primary tapping off load, %")]
        public string TypeofPrimaryTappingOffload { get; set; }
        [Column("PercentageImpedanceAt75C", Order = 20, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Percentage Impedance at 75 ° C, %")]
        public string PercentageImpedanceAt75C { get; set; }
        [Column("NoloadLossWatts", Order = 21, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No-load loss, Watts")]
        public string NoloadLossWatts { get; set; }
        [Column("LoadLossesAtRatedFullLoadAt75CWatts", Order = 22, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Load losses at rated full load at 75° C, Watts")]
        public string LoadLossesAtRatedFullLoadAt75CWatts { get; set; }
        [Column("TotalWeightOfOilKg", Order = 23, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Total weight of oil, Kg")]
        public string TotalWeightOfOilKg { get; set; }
    }
}
