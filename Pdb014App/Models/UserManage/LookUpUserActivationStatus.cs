using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class LookUpUserActivationStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserActivationStatusId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "User Activation Status Id")]
        public int UserActivationStatusId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "User Activation Status")]
        public string UserActivationStatus { get; set; }

    }
}
