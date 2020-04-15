using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.DistributionTransformerModel
{
    public class TblDistributionTransformerPicture
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "DistributionTransformerPictureId")]
        public string DistributionTransformerPictureId { get; set; }

   

        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Distribution Transformer")]
        public string DistributionTransformerId { get; set; }
        [ForeignKey("DistributionTransformerId")]
        public virtual TblDistributionTransformer DistributionTransformer { get; set; }




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
