using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pdb014App.Models.PDB.LookUpModels;


namespace Pdb014App.Models.PDB.RegionModels
{
    public class LookUpAdminRegionRel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("UnionGeoCode", Order = 0, TypeName = "varchar(8)")]
        [StringLength(8)]
        [Display(Name = "Union Geo-Code")]
        public string UnionGeoCode { get; set; }
        [ForeignKey("UnionGeoCode")]
        public virtual LookUpAdminBndUnion Union { get; set; }

        //[Column("UpazilaGeoCode", Order = 3, TypeName = "varchar(6)")]
        //[StringLength(6)]
        //[Display(Name = "Upazila Geo-Code")]
        //public string UpazilaGeoCode { get; set; }
        //[ForeignKey("UpazilaGeoCode")]
        //public virtual LookUpAdminBndUpazila Upazila { get; set; }

        //[Column("DistrictGeoCode", Order = 4, TypeName = "varchar(4)")]
        //[StringLength(4)]
        //[Display(Name = "District Geo-Code")]
        //public string DistrictGeoCode { get; set; }
        //[ForeignKey("DistrictGeoCode")]
        //public virtual LookUpAdminBndDistrict District { get; set; }


        [Key]
        [Required]
        [Column("SnDCode", Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "SnD Code")]
        public string SnDCode { get; set; }
        [ForeignKey("SnDCode")]
        public virtual LookUpSnDInfo SnD { get; set; }

        //[Column("CircleCode", Order = 7, TypeName = "varchar(50)")]
        //[StringLength(50)]
        //[Display(Name = "Circle")]
        //public string CircleCode { get; set; }
        //[ForeignKey("CircleCode")]
        //public virtual LookUpCircleInfo Circle { get; set; }

        //[Column("ZoneCode", Order = 8, TypeName = "varchar(50)")]
        //[StringLength(50)]
        //[Display(Name = "Zone")]
        //public string ZoneCode { get; set; }
        //[ForeignKey("ZoneCode")]
        //public virtual LookUpZoneInfo Zone { get; set; }

    }


}
