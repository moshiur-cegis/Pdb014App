using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Pdb014App.Models.PDB.MeteringPanelModels
{
    public class LookUpDifferentTypesOfMeter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MeterTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Meter Type Id")]
        public int MeterTypeId { get; set; }


        [Column("MeterTypeName", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Meter Type Name")]
        public string MeterTypeName { get; set; }
    }
}
