using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pdb014App.Models.PDB
{
    public class LookUpComplaintType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "int")]
        [Display(Name = "Complaint Type Id")]
        public int ComplaintTypeId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Complaint Type")]
        public string ComplaintType { get; set; }
    }
}
