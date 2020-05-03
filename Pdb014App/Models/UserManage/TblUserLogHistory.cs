using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Pdb014App.Models.UserManage
{
    public class TblUserLogHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserLogHistoryId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Log History Id")]
        public int UserLogHistoryId { get; set; }

        [Required]
        [Column("UserId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual TblUserProfileDetail UserLogHistoryToUserProfileDetail { get; set; }


        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 16)]
        [Display(Name = "Server Or IP Address")]
        public string ServerOrIPAddress { get; set; }

        [Display(Name = "Login DateTime")]
        public DateTime LoginDateTime { get; set; }


        [Display(Name = "LoOut DateTime")]
        public DateTime LogOutDateTime { get; set; }

        [StringLength(100)]
        [Display(Name = "Login Notes")]
        public string LoginNotes { get; set; }
    }
}
