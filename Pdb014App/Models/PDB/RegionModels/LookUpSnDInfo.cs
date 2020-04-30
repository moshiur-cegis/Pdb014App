using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pdb014App.Models.PDB.RegionModels;


namespace Pdb014App.Models.PDB.LookUpModels
{
    public class LookUpSnDInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "SnD Code")]
        public string SnDCode { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "S&D Name")]
        public string SnDName { get; set; }

        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Circle")]
        public string CircleCode { get; set; }
        [ForeignKey("CircleCode")]
        public virtual LookUpCircleInfo CircleInfo { get; set; }

        [Column("DistrictGeoCode", Order = 3, TypeName = "varchar(4)")]
        [StringLength(4)]
        [Display(Name = "District")]
        public string DistrictGeoCode { get; set; }
        [ForeignKey("DistrictGeoCode")]
        public virtual LookUpAdminBndDistrict LookUpAdminBndDistrict { get; set; }

        [Column("IsInCity", Order = 4, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Is in City?")]
        public int? IsInCity { get; set; }

        [Column("SortingNo", Order = 5, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Sorting No")]
        public int? SortingNo { get; set; }

        [Column("CenterLatitude", Order = 6, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Center Latitude")]
        public decimal? CenterLatitude { get; set; }


        [Column("CenterLongitude", Order = 7, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Center Longitude")]
        public decimal? CenterLongitude { get; set; }

        [Column("MinScale", Order = 8, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "MinScale")]
        public int? MinScale { get; set; }

        [Column("MaxScale", Order = 9, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Scale")]
        public int? MaxScale { get; set; }

        [Column("DefaultZoomLevel", Order = 10, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Default Zoom Level")]
        public int? DefaultZoomLevel { get; set; }       
    }
}
