﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class TblUserProfileDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required]
        [Column("UserRegistrationId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Registration Id")]
        public int UserRegistrationId { get; set; }
        [ForeignKey("UserRegistrationId")]
        public virtual TblUserRegistrationDetail UserRegistrationDetail { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "User Full Name")]
        public string UserFullName { get; set; }

        [Display(Name = "User Date Of Birth")]
        public DateTime UserDateOfBirth { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 13)]
        [Display(Name = "Use rNID")]
        public string UserNID { get; set; }

        [Display(Name = "Is BpdbEmployee")]
        public bool IsBpdbEmployee { get; set; }

        [Column("BpdbEmployeeId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bpdb Employee Id")]
        public int? BpdbEmployeeId { get; set; }
        [ForeignKey("BpdbEmployeeId")]
        public virtual LookUpUserBpdbEmployee UserBpdbEmployee { get; set; }

        //[Required]
        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "User Profession")]
        public string UserProfession { get; set; }

        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "User Designation")]
        public string UserDesignation { get; set; }


        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "User Address")]
        public string UserAddress { get; set; }


        [EmailAddress]
        [Display(Name = "User Alternate Email")]
        public string UserAlternateEmail { get; set; }


        [Phone]
        [Display(Name = "User Alternate Mobile")]
        public string UserAlternateMobile { get; set; }


        [Column("UserSecurityQuestionId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Security Question Id")]
        public int? UserSecurityQuestionId { get; set; }
        [ForeignKey("UserSecurityQuestionId")]
        public virtual LookUpUserSecurityQuestion UserSecurityQuestion { get; set; }


        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Security Question Answer")]
        public string SecurityQuestionAnswer { get; set; }


        [Display(Name = "Is ProfileSubmitted")]
        public bool IsProfileSubmitted { get; set; }


        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Signature FileName")]
        public string SignatureFileName { get; set; }

    }
}