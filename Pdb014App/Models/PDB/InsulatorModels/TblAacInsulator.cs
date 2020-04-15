using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.InsulatorModels
{
    public class TblAacInsulator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AacInsulatorId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "AAC Insulator Id")]
        public int AacInsulatorId { get; set; }

        [Column("AacInsulatorTypeId", Order = 3, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "AAC Insulator Type Id")]
        /*FK*/
        public int AacInsulatorTypeId { get; set; }
        [ForeignKey("AacInsulatorTypeId")]
        public virtual LookUpAacInsulatorType AacInsulatorType { get; set; }

        //[Column("PoleId", Order = 3, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "PoleId")]
        ///*FK*/
        //public int? PoleId { get; set; }
        //[ForeignKey("PoleId")]
        //public virtual TblPole AacInsulatorToPole { get; set; }


        [Column("NameoftheConductor", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Name of the conductor")]
        public string NameoftheConductor { get; set; }
        [Column("Standard", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Standard")]
        public string Standard { get; set; }
        [Column("Installation", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }
        [Column("Type", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Column("Material", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Material")]
        public string Material { get; set; }
        [Column("OverallDiameter", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Overall diameter")]
        public string OverallDiameter { get; set; }
        [Column("NumberorDiameterofAluminum", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Number/diameter of Aluminum")]
        public string NumberorDiameterofAluminum { get; set; }
        [Column("CrossSectionalAreaofConductors", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Cross sectional area of conductors")]
        public string CrossSectionalAreaofConductors { get; set; }
        [Column("NominalAluminumCrossSectionalArea", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Aluminum cross sectional area")]
        public string NominalAluminumCrossSectionalArea { get; set; }
        [Column("NumberorDiameterofSteel", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Number/diameter of Steel")]
        public string NumberorDiameterofSteel { get; set; }
        [Column("NominalSteelCrossSectionalArea", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Steel cross sectional area")]
        public string NominalSteelCrossSectionalArea { get; set; }
        [Column("WeightofConductor", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Weight of conductor")]
        public string WeightofConductor { get; set; }
        [Column("CodeName", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Code name")]
        public string CodeName { get; set; }
        [Column("MaximumDCResistanceofConductorAt20deC", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum DC Resistance of Conductor at 20 deg.C")]
        public string MaximumDCResistanceofConductorAt20deC { get; set; }
        [Column("MinimumbreakingLoadofConductor", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Minimum breaking Load of Conductor")]
        public string MinimumbreakingLoadofConductor { get; set; }
        [Column("MinimumbreakingLoadofConductorType", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Minimum breaking Load of Conductor Type")]
        public string MinimumbreakingLoadofConductorType { get; set; }
        [Column("PhasingCode", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Phasing Code")]
        public string PhasingCode { get; set; }
        [Column("FeederID", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Feeder ID")]
        public string FeederID { get; set; }
        [Column("OperatingVoltage", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Operating Voltage")]
        public string OperatingVoltage { get; set; }
        [Column("NeutralMaterial", Order = 19, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Material")]
        public string NeutralMaterial { get; set; }
        [Column("NeutralSize", Order = 20, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Size")]
        public string NeutralSize { get; set; }
        [Column("AssemblyCode", Order = 21, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Assembly Code")]
        public string AssemblyCode { get; set; }
        [Column("NominalVoltage", Order = 22, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Voltage")]
        public string NominalVoltage { get; set; }
        [Column("PhaseOrientation", Order = 23, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Phase Orientation")]
        public string PhaseOrientation { get; set; }
        [Column("InstallDate", Order = 24, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Install Date")]
        public string InstallDate { get; set; }
        [Column("ConductorCrossSection", Order = 25, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Conductor Cross Section")]
        public string ConductorCrossSection { get; set; }
        [Column("ConductorCapacityAmp", Order = 26, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Conductor Capacity (Amp)")]
        public string ConductorCapacityAmp { get; set; }
        [Column("TotalSanctionedLoadfromtheFeeder", Order = 27, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Total Sanctioned Load from the Feeder")]
        public string TotalSanctionedLoadfromtheFeeder { get; set; }



        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Id")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole AacInsulatorToPole { get; set; }

    }
}
