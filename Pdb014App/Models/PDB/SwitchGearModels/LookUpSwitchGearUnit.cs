using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class LookUpSwitchGearUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SwitchGearUnitId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch Gear Unit Id")]
        public int SwitchGearUnitId { get; set; }


        [Column("ManufacturersNameAndAddress", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Address")]
        public string ManufacturersNameAndAddress { get; set; }

        [Column("AppliedStandard", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Applied standard")]
        public string AppliedStandard { get; set; }

        [Column("RatedNominalVoltage", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated nominal Voltage")]
        public string RatedNominalVoltage { get; set; }

        [Column("RatedVoltage", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }

        [Column("RatedCurrentForMainBus", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated current for main bus")]
        public string RatedCurrentForMainBus { get; set; }

        [Column("RatedShortTimeCurrent", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated short time current")]
        public string RatedShortTimeCurrent { get; set; }

        [Column("ShortTimeCurrentRatedDuration", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short time current rated duration")]
        public string ShortTimeCurrentRatedDuration { get; set; }

    }
}
