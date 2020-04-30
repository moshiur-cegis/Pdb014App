using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class LookUpUserSecurityQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserSecurityQuestionId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Security Question Id")]
        public int UserSecurityQuestionId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "User Security Question")]
        public string UserSecurityQuestion { get; set; }

    }
    
}
