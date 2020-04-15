using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class LookUpCurrentTransformer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CurrentTransformerId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Current Trans former Id")]
        public int CurrentTransformerId { get; set; }


        [Column("RatedVoltage", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }

        [Column("AccuracyClassMetering", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Accuracy class, Metering")]
        public string AccuracyClassMetering { get; set; }

        [Column("AccuracyClassOCEFProtection", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Accuracy class, O/C& E/F Protection")]
        public string AccuracyClassOCEFProtection { get; set; }

        [Column("AccuracyClassDifferentialProtection", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Accuracy class, Differential Protection")]
        public string AccuracyClassDifferentialProtection { get; set; }

        [Column("RatedCurrentRatio", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Current Ratio")]
        public string RatedCurrentRatio { get; set; }

        [Column("Burden", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Burden")]
        public string Burden { get; set; }

        [Column("RatedFrequency", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Frequency")]
        public string RatedFrequency { get; set; }


    }
}
