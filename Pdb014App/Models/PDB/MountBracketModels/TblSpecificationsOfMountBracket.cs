using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.Mount_BracketModels
{
    public class TblSpecificationsOfMountBracket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SpecificationsOfMountBracketId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "SpecificationsOfMountBracketId")]
        public int SpecificationsOfMountBracketId { get; set; }

        [Column("SpecificationsOfMountBracketTypeId", Order = 3, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "SpecificationsOfMountBracketTypeId")]
        /*FK*/
        public int SpecificationsOfMountBracketTypeId { get; set; }
        [ForeignKey("SpecificationsOfMountBracketTypeId")]
        public virtual LookUpSpecificationsOfMountBracketType LookUpSpecificationsOfMountBracketType { get; set; }

        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Type of Side Mount Bracket ")]
        public string MountBrackeType { get; set; }

        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Materials")]
        public string Materials { get; set; }


        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Ultimate Tensile Strength")]
        public string UltimateTensileStrength { get; set; }

        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Galvanization")]
        public string Galvanization { get; set; }

        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Standard")]
        public string Standard { get; set; }

        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Id")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole SpecificationsOfMountBracketToPole { get; set; }
    }
}
