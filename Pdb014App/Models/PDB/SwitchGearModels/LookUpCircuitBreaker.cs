using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class LookUpCircuitBreaker
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CircuitBreakerId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Circuit Breaker Id")]
        public int CircuitBreakerId { get; set; }

        [Column("Type", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Column("RatedVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }

        [Column("RatedCurrent", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Current")]
        public string RatedCurrent { get; set; }

        [Column("OperatingCycle", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Operating Cycle")]
        public string OperatingCycle { get; set; }

        [Column("RatedShortCktBreakingCurrent", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated short Ckt. breaking current")]
        public string RatedShortCktBreakingCurrent { get; set; }

        [Column("RatedShortCktMakingCurrent", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated short Ckt. making current")]
        public string RatedShortCktMakingCurrent { get; set; }

        [Column("RatedBreakingTime", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated breaking time")]
        public string RatedBreakingTime { get; set; }

        [Column("OpeningTime", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Opening time")]
        public string OpeningTime { get; set; }

        [Column("ClosingTime", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Closing time")]
        public string ClosingTime { get; set; }

        [Column("RatedOperatingSequence", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated operating sequence")]
        public string RatedOperatingSequence { get; set; }

        [Column("ControlVoltage", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Control voltage")]
        public string ControlVoltage { get; set; }

        [Column("MotorVoltageForSpringCharge", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Motor voltage for spring charge")]
        public string MotorVoltageForSpringCharge { get; set; }

        [Column("ThreePositionDisconnectorSwitch", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Three Position Disconnector Switch")]
        public string ThreePositionDisconnectorSwitch { get; set; }

        [Column("Type2", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string Type2 { get; set; }

        [Column("RatedVoltage2", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage2 { get; set; }

        [Column("RatedCurrent2", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated current")]
        public string RatedCurrent2 { get; set; }

        [Column("SwitchPositions", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch positions")]
        public string SwitchPositions { get; set; }

        [Column("ElectricalAndMechanicalInterlock", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Electrical and Mechanical interlock")]
        public string ElectricalAndMechanicalInterlock { get; set; }
    }
}
