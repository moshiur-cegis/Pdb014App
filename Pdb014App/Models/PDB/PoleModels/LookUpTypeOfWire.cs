using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Pdb014App.Models.PDB
{
    public class LookUpTypeOfWire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Code", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Code")]
        public int Code { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
