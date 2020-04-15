using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Pdb014App.Models.Search
{public class LookUpModelInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ModelId", Order = 0, TypeName = "int")]
        [Display(Name = "ModelId")]
        public int ModelId { get; set; }

        public string ModelName { get; set; }
        public string ModelType { get; set; }
        public string ModelTitle { get; set; }
        public int SortingOrder { get; set; }
    }
}
