using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.MapViewer.Settings
{
    public class LookUpMapViewBaseMapDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BaseMapId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Data Source")]
        public int BaseMapId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Base Map Name")]
        public string BaseMapName { get; set; }                
                
        [Column(Order = 2, TypeName = "int")]
        [Display(Name = "Default Zoom Level")]
        public int? DefaultZoomLevel { get; set; }

        [Column("BaseMapCenterLat", Order = 3, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Center Latitude")]
        public decimal? BaseMapCenterLat { get; set; }

        [Column("BaseMapCenterLong", Order = 4, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Center Longitude")]
        public decimal? BaseMapCenterLong { get; set; }

        [Column("MinScale", Order = 5, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Minimum Scale")]
        public int? MinScale { get; set; }

        [Column(Order = 6, TypeName = "int")]
        [Display(Name = "Base Map Status")]
        public int? BaseMapActivationStatus { get; set; }
    }
}