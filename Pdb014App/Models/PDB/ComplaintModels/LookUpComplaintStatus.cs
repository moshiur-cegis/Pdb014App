using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pdb014App.Models.PDB
{
    public class LookUpComplaintStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "int")]
        [Display(Name = "Complaint Status Id")]
        public int ComplaintStatusId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Complaint Status")]
        public string ComplaintStatus { get; set; }
    }
}
