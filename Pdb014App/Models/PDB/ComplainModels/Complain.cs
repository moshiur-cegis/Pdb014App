using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Pdb014App.Models.PDB.LookUpModels;
using Pdb014App.Models.PDB.RegionModels;
using Pdb014App.Models.UserManage;


namespace Pdb014App.Models.PDB
{
    public class TblComplain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("ComplainId", Order = 0, TypeName = "int")]
        [Display(Name = "Complain Id")]
        public int ComplainId { get; set; }


        [Column("ComplainNo", Order = 1, TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Complain No")]
        public string ComplainNo { get; set; }


        //[Column("PreviousComplainNo", Order = 9, TypeName = "nvarchar(50)")]
        //[StringLength(250)]
        //[Display(Name = "Previous Complain No.")]
        //public string PreviousComplainNo { get; set; }

        [Required]
        [Column("ComplainTypeId", Order = 2, TypeName = "int")]
        [Display(Name = "Complain Type")]
        public int ComplainTypeId { get; set; }

        [ForeignKey("ComplainTypeId")]
        public virtual LookUpComplainType ComplainType { get; set; }


        [Required]
        [Column("ComplainStatusId", Order = 3, TypeName = "int")]
        [Display(Name = "Complain Status")]
        public int ComplainStatusId { get; set; }

        [ForeignKey("ComplainStatusId")]
        public virtual LookUpComplainStatus ComplainStatus { get; set; }


        //ComplainerName
        [Required]
        [Column("ComplainerName", Order = 4, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Complainer Name")]
        public string ComplainerName { get; set; }

        //ComplainerName
        [Column("Complainer Address", Order = 5, TypeName = "nvarchar(500)")]
        [StringLength(500)]
        [Display(Name = "Complainer Address")]
        public string ComplainerAddress { get; set; }

        //ComplainerName
        [Required]
        [Column("ComplainerDetails", Order = 6, TypeName = "nvarchar(2500)")]
        [StringLength(2500)]
        [Display(Name = "Complainer Details")]
        public string ComplainerDetails { get; set; }


        [Column("ComplainDate", Order = 7, TypeName = "date")]
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Complain Date")]
        public DateTime? ComplainDate { get; set; }



        [Column("ComplainPriority", Order = 8, TypeName = "int")]
        [Display(Name = "Priority")]
        public int? ComplainPriority { get; set; }
        //[ForeignKey("ComplainPriority")]
        //public virtual LookUpComplainPriority ComplainPriority { get; set; }

        [Column("ResponsibleOfficerId", Order = 9, TypeName = "int")]
        [Display(Name = "Responsible Officer")]
        public int? ResponsibleOfficerId { get; set; }
        [ForeignKey("ResponsibleOfficerId")]
        public virtual TblUserProfileDetail ResponsibleOfficer { get; set; }


        [Column("ResolveDate", Order = 10, TypeName = "date")]
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Resolve Date")]
        public DateTime? ResolveDate { get; set; }


        [Column("ResolvingOfficerId", Order = 11, TypeName = "int")]
        [Display(Name = "Resolving Officer")]
        public int? ResolvingOfficerId { get; set; }
        [ForeignKey("ResolvingOfficerId")]
        public virtual TblUserProfileDetail ResolvingOfficer { get; set; }


        [Column("UnionGeoCode", Order = 12, TypeName = "varchar(8)")]
        [StringLength(8, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Union Geo-Code")]
        public string UnionGeoCode { get; set; }
        [ForeignKey("UnionGeoCode")]
        public virtual LookUpAdminBndUnion ComplainToUnion { get; set; }


        [Column("SnDCode", Order = 13, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "SnD Code")]
        public string SnDCode { get; set; }
        [ForeignKey("SnDCode")]
        public virtual LookUpSnDInfo ComplainToSnD { get; set; }


        [Column("Latitude", Order = 14, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; }


        [Column("Longitude", Order = 15, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; }


        //ComplainerName
        [Column("Remark", Order = 16, TypeName = "nvarchar(2500)")]
        [StringLength(2500)]
        [Display(Name = "Remark")]
        public string Remark { get; set; }

    }

}
