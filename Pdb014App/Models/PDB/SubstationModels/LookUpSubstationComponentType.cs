using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class LookUpSubstationComponentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]        
        [Column("SubstationComponentTypeId", Order = 0, TypeName = "int")]
        public int SubstationComponentTypeId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(200)")]
        [StringLength(200)]
        [Display(Name = "Substation Component Type")]
        public string SubstationComponentType { get; set; }
    }
}
