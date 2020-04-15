using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.PoleModels
{
    public class TblPolePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("PolePictureId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Pole Picture Id")]
        public int Id { get; set; }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //[Column(Order = 0, TypeName = "varchar(50)")]
        //[StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        //[Display(Name = "Pole Picture Id")]
        //public string PolePictureId { get; set; }
        
        [Column("PictureName", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Picture Name")]
        public string PictureName { get; set; }


        [Column("PictureLocation", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Picture Location")]
        public string PictureLocation { get; set; }

        [Column("FeederLineId", Order = 3, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "FeederlineId")]
        public string FeederLineId { get; set; }

        [Column(Order = 4, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole PolePictureToPole { get; set; }

        [Column("PoleNo", Order = 5, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "PoleNo")]
        public string PoleNo { get; set; }

        [Column("ResizedPictureName", Order = 6, TypeName = "varchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "ResizedPictureName")]
        public string ResizedPictureName { get; set; }

    }
}
