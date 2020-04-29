using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Pdb014App.Models.PDB.PoleModels
{
    public class TblCrossArmInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CrossArmId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Cross Arm Id")]
        public int CrossArmId { get; set; }

        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Materials")]
        public string Materials { get; set; }

        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Column(Order = 3, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Standard")]
        public string Standard { get; set; }

        [Column(Order = 4, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Ultimate Tensile Strength")]
        public string UltimateTensileStrength { get; set; }


        #region FittingsLookUpCondition
        //23       //TypeOfFitting
        [Column("TypeOfFittingsId", Order = 30, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Type Of Fittings")]
        public int? TypeOfFittingsId { get; set; }
        [ForeignKey("TypeOfFittingsId")]
        public virtual LookUpTypeOfFittings LookUpTypeOfFittings { get; set; }

        //        //NoOfSetFittings
        [Column("NoOfSetFittings", Order = 31, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "No of Set Fittings")]
        public int? NoOfSetFittings { get; set; }

        ////25        //FittingsLookUpCondition
        [Column("FittingsConditionId", Order = 32, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Fittings Condition")]
        public int? FittingsConditionId { get; set; }
        [ForeignKey("FittingsConditionId")]
        public virtual LookUpCondition FittingsLookUpCondition { get; set; }
        #endregion


        [Column(Order = 5, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole CrossArmToPole { get; set; }
    }
}
