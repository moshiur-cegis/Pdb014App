using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.PoleModels
{
    public class TblPoleMountedDofCutOutFuseLink
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Pole MountedDof Cut Out Fuse Link Id")]
        public string PoleMountedDofCutOutFuseLinkId { get; set; }


        [Column("Standard", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Standard")]
        public string Standard { get; set; }

        [Column("General", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "General")]
        public string General { get; set; }

        [Column("Installation", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }

        [Column("TypeorModel", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type/Model")]
        public string TypeorModel { get; set; }

        [Column("Construction", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Construction")]
        public string Construction { get; set; }
        [Column("Application", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Application")]
        public string Application { get; set; }

        [Column("NominalRatedVoltage", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Rated Voltage")]
        public string NominalRatedVoltage { get; set; }

        [Column("MaximumSystemVoltage", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum System Voltage")]
        public string MaximumSystemVoltage { get; set; }

        [Column("SystemFrequency", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "System Frequency")]
        public string SystemFrequency { get; set; }
        [Column("TypeofSystem", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of System")]
        public string TypeofSystem { get; set; }
        [Column("ContinuousCurrentRating", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Continuous Current Rating")]
        public string ContinuousCurrentRating { get; set; }
        [Column("InterruptingCapacityoftheCutOutMin", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Interrupting Capacity of the Cut-Out (Min)")]
        public string InterruptingCapacityoftheCutOutMin { get; set; }
        [Column("FuseHolderType", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Fuse Holder Type")]
        public string FuseHolderType { get; set; }
        [Column("FuseLinkRatedCurrentContinuous", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Fuse Link Rated Current (continuous)")]
        public string FuseLinkRatedCurrentContinuous { get; set; }
        [Column("BasicInsulationLevelBIL", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Basic Insulation Level (BIL)")]
        public string BasicInsulationLevelBIL { get; set; }
        [Column("FuseLinkType", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Fuse Link Type")]
        public string FuseLinkType { get; set; }

        /*FK*/

        [Column(Order = 16, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole PoleMountedDofCutOutFuseLinkToPole { get; set; }

    }
}
