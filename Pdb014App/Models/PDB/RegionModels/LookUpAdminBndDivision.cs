using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pdb014App.Models.PDB.RegionModels
{
    public class LookUpAdminBndDivision
    {
        public LookUpAdminBndDivision()
        {
            DistrictList = new HashSet<LookUpAdminBndDistrict>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(2)")]
        [StringLength(2, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Division Geo-Code")]
        public string DivisionGeoCode { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Division Name")]
        public string DivisionName { get; set; }
        

        //[Column("SortingOrder", Order = 3, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Sorting Order")]
        //public int SortingOrder { get; set; }


        public ICollection<LookUpAdminBndDistrict> DistrictList { get; set; }
    }


}
