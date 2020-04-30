using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Pdb014App.Models.UserManage
{
    public class LookUpUserGroup: IdentityRole
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserGroupId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Group Id")]
        public int UserGroupId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "User Group Name")]
        public string UserGroupName { get; set; }
    }
}
