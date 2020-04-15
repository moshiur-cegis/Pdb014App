using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.InsulatorModels
{
    public class LookUpInsulatorShackleOrGuyType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("InsulatorShackleOrGuyTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "InsulatorShackleOrGuyTypeId")]
        public int InsulatorShackleOrGuyTypeId { get; set; }

        //[Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "InsulatorShackleOrGuyTypeName")]
        public string InsulatorShackleOrGuyTypeName { get; set; }
    }
}
