using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.InsulatorModels
{
    public class TblGuy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("GuyId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "GuyId")]
        public int GuyId { get; set; }


        [Column("GuyTypeId", Order = 3, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Insulator Type")]
        /*FK*/
        public int? GuyTypeId { get; set; }
        [ForeignKey("GuyTypeId")]
        public virtual LookUpGuyType GuyType { get; set; }


        [Column("ConditionId", Order = 32, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = " Condition")]
        public int? ConditionId { get; set; }
        [ForeignKey("ConditionId")]
        public virtual LookUpCondition GuyToLookUpCondition { get; set; }

        [Column("NoOfSet", Order = 20, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "NoOfSet")]
        public int? NoOfSet { get; set; }


        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Id")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole GuyToPole { get; set; }
    }
}
