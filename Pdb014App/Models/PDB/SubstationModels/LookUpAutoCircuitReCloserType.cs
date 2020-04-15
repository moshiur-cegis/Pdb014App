using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class LookUpAutoCircuitReCloserType
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AutoCircuitReCloserTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Auto Circuit Re-Closer Type Id")]
        public int AutoCircuitReCloserTypeId { get; set; }

        //[Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Auto Circuit Re-Closer Type Name")]
        public string AutoCircuitReCloserTypeIdName { get; set; }
    }
}
