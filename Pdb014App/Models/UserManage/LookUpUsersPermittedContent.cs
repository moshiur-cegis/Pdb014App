using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Pdb014App.Models.UserManage
{
    public class LookUpUsersPermittedContent
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UsersPermittedContentId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Users Permitted Content Id")]
        public int UsersPermittedContentId { get; set; }


        [Required]
        [Column("ContentTypeId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Content Type Id")]
        public int ContentTypeId { get; set; }
        [ForeignKey("ContentTypeId")] 
        public virtual LookUpUserContentType UserContentType { get; set; }


        //[Required]
        [Column(Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Content Name")]
        public string ContentName { get; set; }

        //[Required]
        [Column(Order = 3, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Content Title")]
        public string ContentTitle { get; set; }

        //[Required]
        [Column(Order = 4, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Content Description")]
        public string ContentDescription { get; set; }


        //[Required]
        [Column(Order = 5, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }

        //[Required]
        [Column(Order = 6, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Controller Name")]
        public string ControllerName { get; set; }


        //[Required]
        [Column(Order = 7, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Action Name")]
        public string ActionName { get; set; }


    }
}
