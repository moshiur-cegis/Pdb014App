using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB
{
    public class LookUpSideLockTieTerminalClampMerlin
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(6)")]
        [StringLength(6, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Clamp Merlin Id")]
        public string SideLockTieTerminalClampMerlinId { get; set; }


        //[Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Side Lock Tie Terminal Clamp Merlin Type")]
        public string SideLockTieTerminalClampMerlinType { get; set; }

        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Materials")]
        public string Materials { get; set; }

        [Column(Order = 3, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Standard")]
        public string Standard { get; set; }

        [Column(Order = 4, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Ultimate Tensile Strength")]
        public string UltimateTensileStrength { get; set; }

        //FK

        [Column(Order = 5, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole SideLockTieTerminalClampMerlinToPole { get; set; }
    }
}





