using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class LookUpPotentialTrans33KV
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PotentialTransformerId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Potential Transformer Id")]
        public int PotentialTransformerId { get; set; }


        [Column("SwitchGearID", Order = 1, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch Gear ID")]
        public string SwitchGearID { get; set; }
        [ForeignKey("SwitchGearID")]
        public virtual TblSwitchGear PotentialTransformerToSwitchGear { get; set; }


        [Column("NameoftheManufacturer", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Name of the Manufacturer")]
        public string NameoftheManufacturer { get; set; }

        [Column("TypeAndModelNo", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type & Model No")]
        public string TypeAndModelNo { get; set; }

        [Column("NominalSystemVoltage", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal System Voltage")]
        public string NominalSystemVoltage { get; set; }

        [Column("HeightsSystemVoltage", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Heights System Voltage")]
        public string HeightsSystemVoltage { get; set; }

        [Column("RatedPrimaryVoltage", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Primary Voltage")]
        public string RatedPrimaryVoltage { get; set; }

        [Column("RatedSecondaryVoltageandTertiaryVoltage", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated secondary Voltage and Tertiary voltage")]
        public string RatedSecondaryVoltageandTertiaryVoltage { get; set; }

        [Column("ImpulseWithstAndVoltage", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse withstand voltage")]
        public string ImpulseWithstAndVoltage { get; set; }

        [Column("MicroSec12or50", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "(1.2/50 micro sec.)")]
        public string MicroSec12or50 { get; set; }

        [Column("PowerFrequencyWithstandVoltage", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Power frequency withstand voltage")]
        public string PowerFrequencyWithstandVoltage { get; set; }

        [Column("BurdenOrClass", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Burden/Class")]
        public string BurdenOrClass { get; set; }

        [Column("MeteringWinding", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "a) Metering winding")]
        public string MeteringWinding { get; set; }

        [Column("ProtectionWinding", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "b) Protection winding")]
        public string ProtectionWinding { get; set; }


    }
}
