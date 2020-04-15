using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.PoleModels
{
    public class TblPoleToMultiFeederlineInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole PoleInfo { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Feeder Line")]
        public string FeederLineId { get; set; }
        [ForeignKey("FeederLineId")]
        public virtual TblFeederLine MultiFeederLineInfo { get; set; }


        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Previous Pole")]
        public string PreviousPoleId { get; set; }
        [ForeignKey("PreviousPoleId")]
        public virtual TblPole PreviousPoleInfo { get; set; }

        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Next Pole")]
        public string NextPoleId { get; set; }
        [ForeignKey("NextPoleId")]
        public virtual TblPole NextPoleInfo { get; set; }
    }
}
