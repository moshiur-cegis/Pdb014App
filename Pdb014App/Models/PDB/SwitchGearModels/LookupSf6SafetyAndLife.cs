using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class LookupSf6SafetyAndLife
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Sf6SafetyAndLifeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Sf6 Safety And Life Id")]
        public int Sf6SafetyAndLifeId { get; set; }


        [Column("SF6Pressure", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "SF6 Pressure")]
        public string SF6Pressure { get; set; }

        [Column("RatedPressureAt20C", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated pressure at 20°C")]
        public string RatedPressureAt20C { get; set; }

        [Column("MinimumfunctionalpressureAt20C", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Minimum functional pressure at 20°C")]
        public string MinimumfunctionalpressureAt20C { get; set; }

        [Column("BurstingPressure", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Bursting Pressure")]
        public string BurstingPressure { get; set; }

        [Column("GasLeakageRate", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Gas Leakage Rate")]
        public string GasLeakageRate { get; set; }

        [Column("SafetyIndication", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Safety Indication:")]
        public string SafetyIndication { get; set; }

        [Column("CapacitiveVoltageIndicatorEUJapanUSAOrigin", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Capacitive Voltage Indicator (EU/Japan/USA origin)")]
        public string CapacitiveVoltageIndicatorEUJapanUSAOrigin { get; set; }

        [Column("GasPressureManometer", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Gas pressure Manometer")]
        public string GasPressureManometer { get; set; }

        [Column("BusBarGasPressureManometer", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Bus Bar Gas pressure Manometer")]
        public string BusBarGasPressureManometer { get; set; }

        [Column("LifeEnduranceOfSwitchgear", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Life / Endurance of Switchgear:")]
        public string LifeEnduranceOfSwitchgear { get; set; }

        [Column("CircuitBreakers", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Circuit Breakers")]
        public string CircuitBreakers { get; set; }

        [Column("DisconnectorsAndEarthingSwitches", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Disconnectors and Earthing Switches")]
        public string DisconnectorsAndEarthingSwitches { get; set; }
    }
}
