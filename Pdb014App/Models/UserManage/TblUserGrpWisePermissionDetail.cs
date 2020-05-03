using Microsoft.AspNetCore.Identity;
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
        public virtual LookUpUsersPermittedContent UserGrpWisePermissionDetailToUsersPermittedContent { get; set; }


        [Required]
        [Column("Id", Order = 2, TypeName = "nvarchar(450)")]
        //[Column("Id", Order = 1, TypeName = "int")]
        [StringLength(450)]
        [Display(Name = "User Group Id")]
        public string Id { get; set; }     
        [ForeignKey("Id")]
        public virtual IdentityRole UserGrpWisePermissionDetailToIdentityRole { get; set; }


      


    }
}
