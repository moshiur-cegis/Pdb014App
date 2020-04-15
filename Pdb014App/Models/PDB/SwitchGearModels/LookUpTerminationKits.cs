using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class LookUpTerminationKits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TerminationKitsId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Termination Kits Id")]
        public int TerminationKitsId { get; set; }
       
        [Column("BusBarId", Order = 1, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bus Bar Id")]
        public int BusBarId { get; set; }
        [ForeignKey("BusBarId")]
        public virtual LookupBusBar LookupBusBar { get; set; }

        [Column("LineCapacity", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Line Capacity ")]
        public string LineCapacity { get; set; }

        [Column("TypeofTerminationKit", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Termination Kit")]
        public string TypeofTerminationKit { get; set; }

        [Column("Application", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Application")]
        public string Application { get; set; }

        [Column("Installation", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }

        [Column("NominalSystemVoltage", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal System voltage")]
        public string NominalSystemVoltage { get; set; }

        [Column("MaximumSystemVoltage", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum System voltage")]
        public string MaximumSystemVoltage { get; set; }

        [Column("PowerFrequencyWithstandVoltage", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Power frequency withstand Voltage")]
        public string PowerFrequencyWithstandVoltage { get; set; }

        [Column("NumberofCore", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Number of core")]
        public string NumberofCore { get; set; }

        [Column("TypeofInsulation", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of insulation")]
        public string TypeofInsulation { get; set; }

        [Column("TypeofScreening", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of screening")]
        public string TypeofScreening { get; set; }

        [Column("TypeofCableBox", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Cable box")]
        public string TypeofCableBox { get; set; }

        [Column("SystemNeutralEarthing", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "System neutral Earthing")]
        public string SystemNeutralEarthing { get; set; }

        [Column("ConductorCrossSection", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "TblConductor cross section")]
        public string ConductorCrossSection { get; set; }

        [Column("ImpulseWithstandVoltage", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse withstand voltage")]
        public string ImpulseWithstandVoltage { get; set; }

    }
}
