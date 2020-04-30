using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.ServicePointModels
{
    public class LookUpVoltageCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //[Column(Order = 0, TypeName = "varchar(50)")]
        //[StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        public int VoltageCategoryId { get; set; }

        [Required]
        [Display(Name = "Voltage Category")]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        public string VoltageCategoryName { get; set; }
    }
}
