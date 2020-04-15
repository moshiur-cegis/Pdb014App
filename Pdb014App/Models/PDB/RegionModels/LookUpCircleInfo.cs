using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pdb014App.Models.PDB.RegionModels;

namespace Pdb014App.Models.PDB.LookUpModels
{
    public class LookUpCircleInfo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Circle Code")]
        public string CircleCode { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Circle Name")]
        public string CircleName { get; set; }
        
        
        [Column("SortingNo", Order = 2, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Sorting No")]
        public int? SortingNo { get; set; }


        [Column("CenterLatitude", Order = 3, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Center Latitude")]
        public decimal? CenterLatitude { get; set; }


        [Column("CenterLongitude", Order = 4, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Center Longitude")]
        public decimal? CenterLongitude { get; set; }

        [Column("MinScale", Order = 5, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "MinScale")]
        public int? MinScale { get; set; }

        [Column("MaxScale", Order = 6, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Scale")]
        public int? MaxScale { get; set; }

        [Column("DefaultZoomLevel", Order = 7, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Default Zoom Level")]
        public int? DefaultZoomLevel { get; set; }

        [Column("ZoneCode", Order = 8, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Zone")]
        public string ZoneCode { get; set; }
        [ForeignKey("ZoneCode")]
        public virtual LookUpZoneInfo ZoneInfo { get; set; }
    }
}
