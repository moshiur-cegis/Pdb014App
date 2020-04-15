using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.MapViewer.Settings
{
    public class LookUpMapViewLayerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("LayerTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Layer Type Id")]
        public int LayerTypeId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Layer Type")]
        public string LayerType { get; set; }

        [Column(Order = 2, TypeName = "int")]
        [Display(Name = "Layer Status")]
        public int? LayerTypeActivationStatus { get; set; }
    }
}
