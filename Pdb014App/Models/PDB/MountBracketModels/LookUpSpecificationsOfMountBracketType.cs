﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.Mount_BracketModels
{
    public class LookUpSpecificationsOfMountBracketType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SpecificationsOfMountBracketTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "SpecificationsOfMountBracketTypeId")]
        public int SpecificationsOfMountBracketTypeId { get; set; }

        //[Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Mount Bracket Type Name")]
        public string SpecificationsOfMountBracketTypeName { get; set; }
    }
}
