using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB
{
    public class LookUpPoleCondition
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(6)")]
        [StringLength(6, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Pole Condition Id")]
        public string PoleConditionId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
