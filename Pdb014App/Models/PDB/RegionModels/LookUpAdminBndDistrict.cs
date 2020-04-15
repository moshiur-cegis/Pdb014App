using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.RegionModels
{
    public class LookUpAdminBndDistrict
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(4)")]        
        [Display(Name = "District Geo-Code")]
        public string DistrictGeoCode { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        [StringLength(50)]
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }        
    }
}
