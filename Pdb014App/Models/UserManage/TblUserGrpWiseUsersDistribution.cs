using Microsoft.AspNetCore.Identity;
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
        public virtual TblUserProfileDetail UserGrpWiseUsersDistributionToUserProfileDetail { get; set; }


        [Required]
        [Column("Id", Order = 2, TypeName = "nvarchar(450)")]
        //[Column("Id", Order = 1, TypeName = "int")]
        [StringLength(450)]
        [Display(Name = "User Group Id")]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual IdentityRole UserGrpWiseUsersDistributionToIdentityRole { get; set; }


    }
}
