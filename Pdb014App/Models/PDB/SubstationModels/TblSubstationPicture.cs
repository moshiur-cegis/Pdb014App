﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class TblSubstationPicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SubstationPictureId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "SubstationPictureId")]
        public int SubstationPictureId { get; set; }

        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Substation Id")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation SubstationPictureToSubstation { get; set; }


        [Column("PictureName", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Picture Name")]
        public string PictureName { get; set; }


        [Column("PictureLocation", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Picture Location")]
        public string PictureLocation { get; set; }
    }
}
