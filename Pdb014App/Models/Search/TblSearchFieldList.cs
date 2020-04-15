using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.Search
{
    public class TblSearchFieldList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "SearchFieldId")]
        public string SearchFieldId { get; set; }

        public int TableGroupId { get; set; }
        public string TableGroupName { get; set; }
        public string PropertyName { get; set; }
        public string PropertyNameDetails { get; set; }
    }
}
