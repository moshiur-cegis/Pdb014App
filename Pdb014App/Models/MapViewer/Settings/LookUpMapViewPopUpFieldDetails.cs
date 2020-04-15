using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.MapViewer.Settings
{
    public class LookUpMapViewPopUpFieldDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PopupFieldId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Popup Field Id")]
        public int PopupFieldId { get; set; }

        [Column(Order = 1, TypeName = "int")]       
        [Display(Name = "Data Source")]
        public int DataSourceId { get; set; }
        [ForeignKey("DataSourceId")]
        public virtual LookUpMapViewDataSource LookUpDataSource { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Popup Field Name")]
        public string PopupFieldName { get; set; }
                
        [Column(Order = 3, TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Popup Field Title")]
        public string PopupFieldTitle { get; set; }
                
        [Column(Order = 3, TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Popup Content Type")]
        public string PopupContentType { get; set; }
                
        [Column(Order = 4, TypeName = "nvarchar(10)")]
        [StringLength(10)]
        [Display(Name = "Popup Field Visibility")]
        public string PopupFieldVisibility { get; set; }

        [Column(Order = 5, TypeName = "int")]
        [Display(Name = "Field Status")]
        public int? FieldActivationStatus { get; set; }
    }
}