using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class TblUserGrpWiseUsersDistribution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserDistributionId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Distribution Id")]
        public int UserDistributionId { get; set; }


        [Required]
        [Column("UserId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual TblUserProfileDetail UserProfileDetail { get; set; }


        [Required]
        [Column("UserGroupId", Order = 2, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Group Id")]
        public int UserGroupId { get; set; }
        [ForeignKey("UserGroupId")]
        public virtual LookUpUserGroup UserGroup { get; set; }


    }
}
