using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class TblUserGrpWisePermissionDetail
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PermissionTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Permission Type Id")]
        public int PermissionTypeId { get; set; }


        [Required]
        [Column("UsersPermittedContentId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Users Permitted ContentId")]
        public int UsersPermittedContentId { get; set; }
        [ForeignKey("UsersPermittedContentId")]
        public virtual LookUpUsersPermittedContent UsersPermittedContent { get; set; }


        [Required]
        [Column("UserGroupId", Order = 2, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Group Id")]
        public int UserGroupId { get; set; }
        [ForeignKey("UserGroupId")]
        public virtual LookUpUserGroup UserGroup { get; set; }



        


    }
}
