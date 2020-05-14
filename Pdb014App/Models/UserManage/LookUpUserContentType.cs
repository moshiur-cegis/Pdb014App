using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class LookUpUserContentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ContentTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Content Type Id")]
        public int ContentTypeId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Content Type Name")]
        public string ContentTypeName { get; set; }


    }
}
