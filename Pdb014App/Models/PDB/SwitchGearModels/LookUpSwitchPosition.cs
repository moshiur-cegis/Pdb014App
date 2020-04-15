using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class LookUpSwitchPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SwitchPositionId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch Position Id")]
        public int SwitchPositionId { get; set; }

        [Column("ElectricalAndMechanicalInterlock", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Electrical and Mechanical Interlock")]
        public string ElectricalAndMechanicalInterlock { get; set; }

        [Column("CurrentTransformer", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Current Transformer:")]
        public string CurrentTransformer { get; set; }

        [Column("RatedVoltage", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }

        [Column("AccuracyClassMetering", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Accuracy class, Metering")]
        public string AccuracyClassMetering { get; set; }

        [Column("AccuracyClassOCEFProtection", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Accuracy class, O/C & E/F Protection")]
        public string AccuracyClassOCEFProtection { get; set; }

        [Column("RatedCurrentRatio", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated current ratio")]
        public string RatedCurrentRatio { get; set; }

        [Column("Burden", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Burden")]
        public string Burden { get; set; }

        [Column("RatedFrequency", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Frequency")]
        public string RatedFrequency { get; set; }
    }
}
