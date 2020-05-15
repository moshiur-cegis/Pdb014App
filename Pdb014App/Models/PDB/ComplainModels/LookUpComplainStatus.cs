using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pdb014App.Models.PDB
{
    [Table("LookUpComplainStatus")]
    public class LookUpComplainStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "int")]
        [Display(Name = "Complain Status Id")]
        public int ComplainStatusId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Complain Status")]
        public string ComplainStatus { get; set; }
    }

}
