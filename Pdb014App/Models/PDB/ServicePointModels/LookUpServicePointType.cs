﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.ServicePointModels
{
    public class LookUpServicePointType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //[Column(Order = 0, TypeName = "varchar(50)")]
        //[StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        public int ServicePointTypeId { get; set; }

        [Required]
        [Display(Name = "Service Point Type")]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        public string ServicePointTypeName { get; set; }
    }
}
