using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Pdb014App.Models.PDB.DistributionTransformerModel
{
    public class TblPoleStructureMountedSurgeArrestor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Pole Structure Mounted Surge Arrestor Id")]
        public string PoleStructureMountedSurgeArrestorId { get; set; }


        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("Id", Order = 0, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Id")]
        //public int Id { get; set; }


        [Column("Standard", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Standard")]
        public string Standard { get; set; }

        [Column("Installation", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }

        [Column("TypeorModel", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type/Model")]
        public string TypeorModel { get; set; }

        [Column("Construction", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Construction")]
        public string Construction { get; set; }

        [Column("Application", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Application")]
        public string Application { get; set; }

        [Column("NominalRatedVoltage", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Rated Voltage")]
        public string NominalRatedVoltage { get; set; }

        [Column("MaximumSystemVoltage", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum System Voltage")]
        public string MaximumSystemVoltage { get; set; }
        [Column("SystemFrequency", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "System Frequency")]
        public string SystemFrequency { get; set; }

        [Column("TypeofSystem", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of System")]
        public string TypeofSystem { get; set; }

        [Column("RatedArresterVoltage", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Arrester Voltage")]
        public string RatedArresterVoltage { get; set; }

        [Column("Class", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Class")]
        public string Class { get; set; }

        [Column("RatedArresterCurrent", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Arrester Current")]
        public string RatedArresterCurrent { get; set; }

        [Column("HighCurrentWithstand", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "High Current Withstand")]
        public string HighCurrentWithstand { get; set; }

        [Column("PressureReliefClass", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Pressure Relief Class")]
        public string PressureReliefClass { get; set; }

        [Column("BasicInsulationlevelBILat12or50MicroSecImpulses", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Basic Insulation Level (BIL) at 1.2/50 Micro sec. Impulses")]
        public string BasicInsulationlevelBILat12or50MicroSecImpulses { get; set; }
        [Column("LightningImpulseResidualVoltageAt8or20MicrosecCurrentWave", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Lightning Impulse Residual Voltage at 8/20 Micro sec. Current Wave")]
        public string LightningImpulseResidualVoltageAt8or20MicrosecCurrentWave { get; set; }

        [Column("CreepageDistance", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Creepage Distance")]
        public string CreepageDistance { get; set; }


        [Column(Order = 17, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Distribution Transformer")]
        public string DistributionTransformerId { get; set; }
        [ForeignKey("DistributionTransformerId")]
        public virtual TblDistributionTransformer SurgeArrestorToDistributionTransformer { get; set; }


    }
}
