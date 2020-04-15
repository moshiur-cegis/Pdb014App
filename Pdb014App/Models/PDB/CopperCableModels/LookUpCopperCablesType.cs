using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.CopperCableModels
{
    public class LookUpCopperCablesType
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Copper Cables Type Id")]
        public string CopperCablesTypeId { get; set; }


        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Copper Cables Type Name")]
        public string CopperCablesTypeName { get; set; }
    }
}
