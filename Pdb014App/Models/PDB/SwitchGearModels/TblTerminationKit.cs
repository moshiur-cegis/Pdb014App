using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class TblTerminationKit
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TerminationKitId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "TerminationKitId")]
        public int TerminationKitId { get; set; }


        [Column("BusBarId", Order = 2, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "BusBarId")]
        public int? BusBarId { get; set; }   //FK
        [ForeignKey("BusBarId")]
        public virtual LookupBusBar TerminationKitToBusBar { get; set; }


        [Column("LineCapacity", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Line Capacity ")]
        public string LineCapacity { get; set; }
        [Column("TypeofTerminationKit", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Termination Kit")]
        public string TypeofTerminationKit { get; set; }
        [Column("Application", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Application")]
        public string Application { get; set; }
        [Column("Installation", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }
        [Column("NominalSystemVoltage", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal System voltage")]
        public string NominalSystemVoltage { get; set; }
        [Column("MaximumSystemVoltage", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum System voltage")]
        public string MaximumSystemVoltage { get; set; }
        [Column("PowerFrequencyWithstandVoltage", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Power frequency withstand Voltage")]
        public string PowerFrequencyWithstandVoltage { get; set; }
        [Column("NumberofCore", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Number of core")]
        public string NumberofCore { get; set; }
        [Column("TypeofInsulation", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of insulation")]
        public string TypeofInsulation { get; set; }
        [Column("TypeofScreening", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of screening")]
        public string TypeofScreening { get; set; }
        [Column("TypeofCableBox", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Cable box")]
        public string TypeofCableBox { get; set; }
        [Column("SystemNeutralEarthing", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "System neutral Earthing")]
        public string SystemNeutralEarthing { get; set; }
        [Column("ConductorCrossSection", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Conductor cross section")]
        public string ConductorCrossSection { get; set; }
        [Column("ImpulseWithstandVoltage", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse withstand voltage")]
        public string ImpulseWithstandVoltage { get; set; }

    }
}
