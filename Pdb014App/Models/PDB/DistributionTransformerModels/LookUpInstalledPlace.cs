using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.DistributionTransformerModels
{
    public class LookUpInstalledPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(6)")]
        [StringLength(6, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Place Id")]
        public string Id { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Place Name")]
        public string Name { get; set; }
    }
}
