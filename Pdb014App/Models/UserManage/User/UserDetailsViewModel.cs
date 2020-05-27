using Pdb014App.Models.PDB.SubstationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage.User
{
    public class UserDetailsViewModel : TblSubstation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required]
        [Column("Id", Order = 2, TypeName = "nvarchar(450)")]
        //[Column("Id", Order = 1, TypeName = "int")]
        [StringLength(450)]
        [Display(Name = "UserRegistrationId")]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual TblUserRegistrationDetail UserProfileDetailToUserRegistrationDetail { get; set; }



        //[Required]
        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "User Full Name")]
        public string UserFullName { get; set; }

        [Display(Name = "User Date Of Birth")]
        public DateTime? UserDateOfBirth { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 13)]
        [Display(Name = "Use NID")]
        public string UserNID { get; set; }




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


        [Display(Name = "Is Profile Submitted")]
        public bool IsProfileSubmitted { get; set; }


        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Signature FileName")]
        public string SignatureFileName { get; set; }



        [Display(Name = "Is Bpdb Employee")]
        public bool IsBpdbEmployee { get; set; }

        [Column("BpdbEmployeeId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bpdb Employee Id")]
        public int? BpdbEmployeeId { get; set; }
        [ForeignKey("BpdbEmployeeId")]
        public virtual LookUpUserBpdbEmployee UserProfileDetailToUserBpdbEmployee { get; set; }

        [StringLength(100)]
        [Display(Name = "Bpdb Employee Level")]
        public string BpdbEmployeeLevel { get; set; }


        //[Required]
        [Column("BpdbDivisionId", Order = 2, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bpdb Division Id")]
        public int? BpdbDivisionId { get; set; }
        [ForeignKey("BpdbDivisionId")]
        public virtual LookUpUserBpdbDivision UserBpdbEmployeeUserBpdbDivision { get; set; }


        [StringLength(100)]
        [Display(Name = "Bpdb Emp Designation")]
        public string BpdbEmpDesignation { get; set; }


        [Column("ZoneCode", Order = 4, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Zone")]
        public string ZoneCode { get; set; }
        //[ForeignKey("ZoneCode")]
        //public virtual LookUpZoneInfo UserBpdbEmployeeToZoneInfo { get; set; }


        [Column(Order = 5, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Circle")]
        public string CircleCode { get; set; }
        //[ForeignKey("CircleCode")]
        //public virtual LookUpCircleInfo UserBpdbEmployeeToCircleInfo { get; set; }


        [Column(Order = 6, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "SnD")]
        public string SnDCode { get; set; }
        //[ForeignKey("SnDCode")]
        //public virtual LookUpSnDInfo UserBpdbEmployeeToLookUpSnD { get; set; }


        [Column(Order = 7, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Substation")]
        public string SubstationId { get; set; }





        //[Display(Name = "User Id")]
        //public int UserId { get; set; }


        //[Display(Name = "UserRegistration Id")]
        //public string UserRegistrationId { get; set; }


        //[Display(Name = "User Full Name")]
        //public string UserFullName { get; set; }

        //[Display(Name = "User Date Of Birth")]
        //public DateTime? UserDateOfBirth { get; set; }


        //[Display(Name = "Use NID")]
        //public string UserNID { get; set; }



        //[Display(Name = "User Profession")]
        //public string UserProfession { get; set; }


        //[Display(Name = "User Designation")]
        //public string UserDesignation { get; set; }


        //[Display(Name = "User Address")]
        //public string UserAddress { get; set; }

        //[Display(Name = "User Alternate Email")]
        //public string UserAlternateEmail { get; set; }


        //[Display(Name = "User Alternate Mobile")]
        //public string UserAlternateMobile { get; set; }


        //[Display(Name = "User Security Question Id")]
        //public string UserSecurityQuestionI { get; set; }
        //[ForeignKey("UserSecurityQuestionId")]
        //public virtual LookUpUserSecurityQuestion UserSecurityQuestion { get; set; }


        //[Display(Name = "Security Question Answer")]
        //public string SecurityQuestionAnswer { get; set; }


        //[Display(Name = "Is Profile Submitted")]
        //public bool IsProfileSubmitted { get; set; }


        //[Display(Name = "Signature FileName")]
        //public string SignatureFileName { get; set; }



        //[Display(Name = "Is Bpdb Employee")]
        //public bool IsBpdbEmployee { get; set; }


        //[Display(Name = "Bpdb Employee Id")]
        //public int? BpdbEmployeeId { get; set; }
        //[ForeignKey("BpdbEmployeeId")]
        //public virtual LookUpUserBpdbEmployee UserProfileDetailToUserBpdbEmployee { get; set; }

        //[StringLength(100)]
        //[Display(Name = "Bpdb Employee Level")]
        //public string BpdbEmployeeLevel { get; set; }


        //[Display(Name = "Bpdb Division")]
        //public string BpdbDivision { get; set; }




        //[Display(Name = "Bpdb Emp Designation")]
        //public string BpdbEmpDesignation { get; set; }


        //[Display(Name = "Zone")]
        //public string ZoneName { get; set; }
        ////[ForeignKey("ZoneCode")]
        ////public virtual LookUpZoneInfo UserBpdbEmployeeToZoneInfo { get; set; }


        //[Display(Name = "Circle")]
        //public string CircleName { get; set; }
        ////[ForeignKey("CircleCode")]
        ////public virtual LookUpCircleInfo UserBpdbEmployeeToCircleInfo { get; set; }

        //[Display(Name = "SnD")]
        //public string SnDCodeName { get; set; }
        ////[ForeignKey("SnDCode")]
        ////public virtual LookUpSnDInfo UserBpdbEmployeeToLookUpSnD { get; set; }


        //[Display(Name = "Substation")]
        //public string SubstationName { get; set; }
    }
}
