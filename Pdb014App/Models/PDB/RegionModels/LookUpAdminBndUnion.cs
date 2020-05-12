using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pdb014App.Models.PDB.RegionModels
{
    public class LookUpAdminBndUnion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(8)")]
        [StringLength(8, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Union Geo-Code")]
        public string UnionGeoCode { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Union Name")]
        public string UnionName { get; set; }

        [Column(Order = 2, TypeName = "varchar(4)")]
        [StringLength(4)]
        [Display(Name = "District Geo-Code")]
        public string DistrictGeoCode { get; set; }
        [ForeignKey("DistrictGeoCode")]
        public virtual LookUpAdminBndDistrict District { get; set; }

        [Column(Order = 3, TypeName = "varchar(6)")]
        [StringLength(6)]
        [Display(Name = "Upazila Geo-Code")]
        public string UpazilaGeoCode { get; set; }
        [ForeignKey("UpazilaGeoCode")]
        public virtual LookUpAdminBndUpazila Upazila { get; set; }

        
        //[Column("SortingOrder", Order = 4, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Sorting Order")]
        //public int SortingOrder { get; set; }

    }


}
