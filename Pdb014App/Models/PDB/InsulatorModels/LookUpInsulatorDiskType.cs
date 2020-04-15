using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pdb014App.Models.PDB.InsulatorModels
{
    public class LookUpInsulatorDiskType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("InsulatorDiskTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Insulator Disk Type")]
        public int InsulatorDiskTypeId { get; set; }

        //[Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "InsulatorDiskTypeName")]
        public string InsulatorDiskTypeName { get; set; }
    }
}
