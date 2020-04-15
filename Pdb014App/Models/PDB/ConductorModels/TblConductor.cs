using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Pdb014App.Models.PDB.SubstationModels;

namespace Pdb014App.Models.PDB.ConductorModels
{
    public class TblConductor
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //[Column(Order = 0, TypeName = "varchar(50)")]
        //[StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        //[Display(Name = "Conductor Id")]
        //public string ConductorId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Id")]
        public int Id { get; set; }



        [Column(Order = 28, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Conductor Type Id")]
        public string ConductorTypeId { get; set; }
        [ForeignKey("ConductorTypeId")]
        public virtual LookUpConductorType ConductorType { get; set; }


        [Column("ConductorName", Order = 3, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Conductor Name")]
        public string ConductorName { get; set; }

        [Column("Standard", Order = 4, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Standard")]
        public string Standard { get; set; }


        [Column("Installation", Order = 5, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }



        [Column("Material", Order = 6, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Material")]
        public string Material { get; set; }


        [Column("OverallDiameter", Order = 7, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Overall Diameter")]
        public string OverallDiameter { get; set; }


        [Column("NumberOrDiameterOfAluminum", Order = 8, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Number/Diameter of Aluminum")]
        public string NumberOrDiameterOfAluminum { get; set; }


        [Column("CrossSectionalAreaOfConducto", Order = 9, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Cross Sectional Area of Conductor")]
        public string CrossSectionalAreaOfConducto { get; set; }


        [Column("NominalAluminumCrossSectionalArea", Order = 10, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Nominal Aluminum Cross Sectional Area")]
        public string NominalAluminumCrossSectionalArea { get; set; }


        [Column("NumberOrdiameterOfSteel", Order = 11, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Number/Diameter of Steel")]
        public string NumberOrdiameterOfSteel { get; set; }


        [Column("NominalSteelCrossSectionalArea", Order = 12, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Nominal Steel Cross Sectional Area")]
        public string NominalSteelCrossSectionalArea { get; set; }


        [Column("WeightOfConductor", Order = 13, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Weight of Conductor")]
        public string WeightOfConductor { get; set; }


        [Column("CodeName", Order = 14, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Code Name")]
        public string CodeName { get; set; }


        [Column("MaximumDcResistanceOfConductorAt20DegC", Order = 15, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Maximum Dc Resistance Of Conductor At 20°C")]
        public string MaximumDcResistanceOfConductorAt20DegC { get; set; }

        [Column("MinimumBreakingLoadOfConductor", Order = 16, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Breaking Load Of Conductor")]
        public string MinimumBreakingLoadOfConductor { get; set; }

        [Column("PhasingCode", Order = 17, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Phasing Code")]
        public string PhasingCode { get; set; }


        //[Column(Order = 3, TypeName = "varchar(50)")]
        //[StringLength(50)]
        //[Display(Name = "FeederLineId")]
        //public string FeederLineId { get; set; }
        //[ForeignKey("FeederLineId")]
        //public virtual TblFeederLine ConductorToFeederLine { get; set; }



        [Column("OperatingVoltage", Order = 18, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Operating Voltage")]
        public string OperatingVoltage { get; set; }

        [Column("NeutralMaterial", Order = 19, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Neutral Material")]
        public string NeutralMaterial { get; set; }

        [Column("NeutralSize", Order = 20, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Neutral Size")]
        public string NeutralSize { get; set; }

        [Column("AssemblyCode", Order = 21, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Assembly Code")]
        public string AssemblyCode { get; set; }

        [Column("NominalVoltage", Order = 22, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Nominal Voltage")]
        public string NominalVoltage { get; set; }

        [Column("PhaseOrientation", Order = 23, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Phase Orientation")]
        public string PhaseOrientation { get; set; }

        [Column("InstallDate", Order = 24, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Install Date")]
        public string InstallDate { get; set; }

        [Column("ConductorCrossSection", Order = 25, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Conductor Cross Section")]
        public string ConductorCrossSection { get; set; }

        [Column("ConductorCapacityAmp", Order = 26, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Conductor Capacity Amp")]
        public string ConductorCapacityAmp { get; set; }

        [Column("TotalSanctionedLoadFromTheFeeder", Order = 27, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Total Sanctioned Load from the Feeder")]
        public string TotalSanctionedLoadFromTheFeeder { get; set; }


        [Column(Order = 28, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole ConductorToPole { get; set; }
    }
}
