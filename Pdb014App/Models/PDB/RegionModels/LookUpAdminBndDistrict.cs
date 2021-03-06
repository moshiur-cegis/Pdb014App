﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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


        [Column(Order = 2, TypeName = "varchar(2)")]
        [StringLength(2)]
        [Display(Name = "Division Geo-Code")]
        public string DivisionGeoCode { get; set; }
        [ForeignKey("DivisionGeoCode")]
        public virtual LookUpAdminBndDivision Division { get; set; }


        //[Column("SortingOrder", Order = 3, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Sorting Order")]
        //public int SortingOrder { get; set; }
    }
}
