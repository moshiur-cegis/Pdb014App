using Pdb014App.Models.PDB.LookUpModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.UserManage
{
    public class LookUpUserBpdbEmployee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BpdbEmployeeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bpdb Employee Id")]
        public int BpdbEmployeeId { get; set; }

        [StringLength(100)]
        [Display(Name = "Bpdb Employee Level")]
        public string BpdbEmployeeLevel { get; set; }


        [Required]
        [Column("BpdbDivisionId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bpdb Division Id")]
        public int BpdbDivisionId { get; set; }
        [ForeignKey("BpdbDivisionId")]
        public virtual LookUpUserBpdbDivision pUserBpdbDivision { get; set; }


        [StringLength(100)]
        [Display(Name = "Bpdb Emp Designation")]
        public string BpdbEmpDesignation { get; set; }


        [Column("ZoneCode", Order = 8, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Zone")]
        public string ZoneCode { get; set; }
        [ForeignKey("ZoneCode")]
        public virtual LookUpZoneInfo UserBpdbEmployeeToZoneInfo { get; set; }


        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Circle")]
        public string CircleCode { get; set; }
        [ForeignKey("CircleCode")]
        public virtual LookUpCircleInfo UserBpdbEmployeeToCircleInfo { get; set; }


        [Column(Order = 3, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "SnD Code")]
        public string SnDCode { get; set; }
        [ForeignKey("SnDCode")]
        public virtual LookUpSnDInfo UserBpdbEmployeeToLookUpSnD { get; set; }


        //Substation132kId
        //Substation33kId
        //Substation11kId

    }
}
