using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Pdb014App.Models.PDB.MeteringPanelModels
{
    public class LookUpDifferentTypesOfRelay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RelayTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Relay Type Id")]
        public int RelayTypeId { get; set; }


        [Column("RelayTypeName", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Relay Type Name")]
        public string RelayTypeName { get; set; }

    }
}
