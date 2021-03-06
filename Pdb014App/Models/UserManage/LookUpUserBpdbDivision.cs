﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class LookUpUserBpdbDivision
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BpdbDivisionId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bpdb Division Id")]
        public int BpdbDivisionId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Bpdb Division Name")]
        public string BpdbDivisionName { get; set; }



    }
}
