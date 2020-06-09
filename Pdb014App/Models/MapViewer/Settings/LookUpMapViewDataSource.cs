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
                
        [Column("LayerTypeId", Order = 2, TypeName = "int")]
        [Display(Name = "Layer Type")]
        public int? LayerTypeId { get; set; }
        [ForeignKey("LayerTypeId")]
        public virtual LookUpMapViewLayerType LookUpLayerType { get; set; }

        [Column("LayerOrder", Order = 3, TypeName = "int")]
        [Display(Name = "Layer Order")]
        public int? LayerOrder { get; set; }

        [Column("LayerTitle", Order = 4, TypeName = "nvarchar(100)")]
        [StringLength(50)]
        [Display(Name = "Layer Title")]
        public string LayerTitle { get; set; }

        [Column("LayerVisibility", Order = 5)]
        [Display(Name = "Layer Visibility")]
        public bool LayerVisibility { get; set; }

        [Column("PopupTemplateName", Order = 6, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Popup Template Name")]
        public string PopupTemplateName { get; set; }

        [Column("RendererType", Order = 7, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Renderer Type")]
        public string RendererType { get; set; }

        [Column("RendererSymbolType", Order = 8, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Renderer Symbol Type")]
        public string RendererSymbolType { get; set; }

        [Column("RendererSymbolColorR", Order = 9, TypeName = "int")]
        [Display(Name = "Renderer Symbol Fill Color")]
        public int? RendererSymbolColorR { get; set; }

        [Column("RendererSymbolColorG", Order = 10, TypeName = "int")]
        [Display(Name = "Renderer Symbol Fill Color")]
        public int? RendererSymbolColorG { get; set; }

        [Column("RendererSymbolColorB", Order = 11, TypeName = "int")]
        [Display(Name = "Renderer Symbol Fill Color")]
        public int? RendererSymbolColorB { get; set; }

        [Column("RendererSymbolColorOpacity", Order = 12)]
        [Display(Name = "Renderer Symbol Fill Color")]
        public decimal? RendererSymbolColorOpacity { get; set; }

        [Column("RendererSymbolStyle", Order = 13, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "Renderer Symbol Style")]
        public string RendererSymbolStyle { get; set; }

        [Column("RendererSymbolOutLineColorR", Order = 14, TypeName = "int")]
        [Display(Name = "Renderer Symbol Outline Color")]
        public int? RendererSymbolOutLineColorR { get; set; }

        [Column("RendererSymbolOutLineColorG", Order = 15, TypeName = "int")]
        [Display(Name = "Renderer Symbol Outline Color")]
        public int? RendererSymbolOutLineColorG { get; set; }

        [Column("RendererSymbolOutLineColorB", Order = 16, TypeName = "int")]
        [Display(Name = "Renderer Symbol Outline Color")]
        public int? RendererSymbolOutLineColorB { get; set; }

        [Column("RendererSymbolOutLineColorOpacity", Order = 17)]
        [Display(Name = "Renderer Symbol Fill Color")]
        public decimal? RendererSymbolOutLineColorOpacity { get; set; }

        [Column("RendererSymbolOutLineWidth", Order = 18, TypeName = "int")]
        [Display(Name = "Renderer Symbol Outline Width")]
        public int? RendererSymbolOutLineWidth { get; set; }
    }
}