using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Pdb014App.Models.Search
{
    public class LookUpModelFieldInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ModeFieldId", Order = 0, TypeName = "int")]
        [Display(Name = "ModeFieldId")]
        public int ModeFieldId { get; set; }

        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual LookUpModelInfo ModelFieldInfoToModelInfo { get; set; }

        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldDataType { get; set; }
        public string FieldDisplayName { get; set; }
        public string FieldDisplayFormat { get; set; }
        public bool? IsUSeInSearch { get; set; }
        public int? SortingOrder { get; set; }
    }
}
