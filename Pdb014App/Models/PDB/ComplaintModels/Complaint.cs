using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Pdb014App.Models.PDB.LookUpModels;


namespace Pdb014App.Models.PDB
{
    public class Complaint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("ComplaintId", Order = 0, TypeName = "int")]
        [Display(Name = "Complaint Id")]
        public int ComplaintId { get; set; }


        [Column("ComplaintNo", Order = 1, TypeName = "varchar(10)")]
        [StringLength(10, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Complaint No")]
        public string ComplaintNo { get; set; }


        //[Column("PreviousComplaintNo", Order = 9, TypeName = "nvarchar(50)")]
        //[StringLength(250)]
        //[Display(Name = "Previous Complaint No.")]
        //public string PreviousComplaintNo { get; set; }

        [Required]
        [Column("ComplaintTypeId", Order = 2, TypeName = "int")]
        [Display(Name = "Complaint Type")]
        public int ComplaintTypeId { get; set; }

        [ForeignKey("ComplaintTypeId")]
        public virtual LookUpComplaintType ComplaintType { get; set; }


        [Required]
        [Column("ComplaintStatusId", Order = 3, TypeName = "int")]
        [Display(Name = "Complaint Status")]
        public int ComplaintStatusId { get; set; }

        [ForeignKey("ComplaintStatusId")]
        public virtual LookUpComplaintStatus ComplaintStatus { get; set; }



        //ComplainerName
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
        [Column("ComplainerDetails", Order = 6, TypeName = "nvarchar(2500)")]
        [StringLength(2500)]
        [Display(Name = "Complainer Details")]
        public string ComplainerDetails { get; set; }


        [Column("ComplaintDate", Order = 7, TypeName = "date")]
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Complaint Date")]
        public DateTime? ComplaintDate { get; set; }


        [Column("ResolveDate", Order = 8, TypeName = "date")]
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Resolve Date")]
        public DateTime? ResolveDate { get; set; }


        [Required]
        [Column("RouteCode", Order = 9, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Route Code")]
        public string RouteCode { get; set; }

        [ForeignKey("RouteCode")]
        public virtual LookUpRouteInfo ComplaintToRoute { get; set; }


        [Column("Latitude", Order = 10, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; }


        [Column("Longitude", Order = 11, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; }




        [Column("TransformerExist", Order = 28, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Transformer Exist")]
        public string TransformerExist { get; set; }

        [Column("CommonComplaint", Order = 29, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Common Complaint")]
        public string CommonComplaint { get; set; }

        [Column("Tap", Order = 30, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Tap")]
        public string Tap { get; set; }

    }

}
