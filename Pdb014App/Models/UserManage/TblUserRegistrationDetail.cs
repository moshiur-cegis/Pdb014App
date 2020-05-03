using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class TblUserRegistrationDetail: IdentityUser
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("UserRegistrationId", Order = 0, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "User Registration Id")]
        //public int UserRegistrationId { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "User Name")]
        public string UserNames { get; set; }


        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        //[Required]
        //[Phone]
        //[Display(Name = "Phone")]
        //public string Phone { get; set; }

        //[Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Activation Status Id")]
        public int? UserActivationStatusId { get; set; }
        [ForeignKey("UserActivationStatusId")]
        public virtual LookUpUserActivationStatus UserRegistrationDetailToUserActivationStatus { get; set; }

      
        [Display(Name = "Date Of Creation")]
        public DateTime? DateOfCreation { get; set; }

        [Display(Name = "Last Modified Date")]
        public DateTime? LastModifiedDate { get; set; }

        [Display(Name = "Is Verified")]
        public bool IsVerified { get; set; }

        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "Verification Code")]
        public string VerificationCode { get; set; }


        //[PersonalData]
        ////[Required]
        //[Column(Order = 1, TypeName = "nvarchar(100)")]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        //[DataType(DataType.Text)]
        //[Display(Name = "User Type")]
        //public string UserType { get; set; }


    }
}
