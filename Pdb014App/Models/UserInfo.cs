using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models
{
    public class UserInfo: IdentityUser
    {

        //[PersonalData]
        //[Required]
        [DataType(DataType.Text)]
        [Column(Order = 3, TypeName = "nvarchar(250)")]
        [StringLength(150)]
        [Display(Name = "Designation")]
        public string Designation { get; set; }


        [Required]
        [Column(Order = 1, TypeName = "nvarchar(100)")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "User Type")]
        public string UserType { get; set; }

        //[PersonalData]
        [Column(Order = 6, TypeName = "nvarchar(150)")]
        [StringLength(150)]
        [DataType(DataType.Text)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

    }
}
