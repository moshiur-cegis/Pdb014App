using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.MapViewer.Settings
{
    public class LookUpMapViewDataSource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DataSourceId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Data Source")]
        public int DataSourceId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Data Source Name")]
        public string DataSourceName { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "int")]
        [Display(Name = "Layer Type")]
        public int LayerTypeId { get; set; }
        [ForeignKey("LayerTypeId")]
        public virtual LookUpMapViewLayerType LookUpLayerType { get; set; }
                
        [Column(Order = 3, TypeName = "int")]
        [Display(Name = "Layer Order")]
        public int? LayerOrder { get; set; }
               
        [Column(Order = 4, TypeName = "nvarchar(100)")]
        [StringLength(50)]
        [Display(Name = "Layer Title")]
        public string LayerTitle { get; set; }
                
        [Column(Order = 5, TypeName = "nvarchar(10)")]
        [StringLength(10)]
        [Display(Name = "Layer Visibility")]
        public string LayerVisibility { get; set; }
                
        [Column(Order = 6, TypeName = "int")]
        [Display(Name = "Default Zoom Level")]
        public int? DefaultZoomLevel { get; set; }
                       
        [Column("CenterLatitude", Order = 7, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Center Latitude")]
        public decimal? CenterLatitude { get; set; }
        
        [Column("CenterLongitude", Order = 8, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Center Longitude")]
        public decimal? CenterLongitude { get; set; }

        [Column("MinScale", Order = 9, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "MinScale")]
        public int? MinScale { get; set; }

        [Column("MaxScale", Order = 10, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "MaxScale")]
        public int? MaxScale { get; set; }

        [Column(Order = 11, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Popup Template Title")]
        public string PopupTemplateTitle { get; set; }

        [Column(Order = 12, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Renderer Type")]
        public string RendererType { get; set; }

        [Column(Order = 13, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Renderer Symbol Type")]
        public string RendererSymbolType { get; set; }

        [Column(Order = 14, TypeName = "nvarchar(70)")]
        [StringLength(70)]
        [Display(Name = "Renderer Symbol Style")]
        public string RendererSymbolStyle { get; set; }

        [Column(Order = 15, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Renderer Symbol Color")]
        public string RendererSymbolColor { get; set; }

        [Column(Order = 16, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Renderer Symbol Outline Color")]
        public string RendererSymbolOutlineColor { get; set; }

        [Column(Order = 17, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Renderer Symbol Outline Width")]
        public string RendererSymbolOutlineWidth { get; set; }                
    }
}