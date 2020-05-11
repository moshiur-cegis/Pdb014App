using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class TblOutDoorTypeVacumnCircuitBreaker
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("OutDoorTypeVacumnCircuitBreakerId", Order = 0, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "OutDoorTypeVacumnCircuitBreakerId")]
        //public int OutDoorTypeVacumnCircuitBreakerId { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Vacumn Circuit Breaker Id")]
        public string VacumnCircuitBreakerId { get; set; }

        //[Column("SubstationId", Order = 1, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "SubstationId")]
        //public int? SubstationId { get; set; }
        //[ForeignKey("SubstationId")]
        //public virtual TblSubstation OutDoorTypeVacumnCircuitBreakerIdToSubstation { get; set; }

        [Column("SubstationId", Order = 2, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "SubstationId")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation OutDoorTypeVacumnCircuitBreakerIdToSubstation { get; set; }



        [Column("ManufacturersNameCountry", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Country")]
        public string ManufacturersNameCountry { get; set; }
        [Column("ManufacturersModelNo", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers model no.")]
        public string ManufacturersModelNo { get; set; }
        [Column("MaximumRatedVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Rated Voltage")]
        public string MaximumRatedVoltage { get; set; }
        [Column("Frequency", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Frequency")]
        public string Frequency { get; set; }
        [Column("RatedNormalCurrent", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Normal current")]
        public string RatedNormalCurrent { get; set; }
        [Column("NoOfPhase", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No. of phase")]
        public string NoOfPhase { get; set; }
        [Column("NoOfBreakPerPhrase", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No. of  break per phrase")]
        public string NoOfBreakPerPhrase { get; set; }
        [Column("InterruptingMedium", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Interrupting medium")]
        public string InterruptingMedium { get; set; }
        [Column("ImpulseWithstandOn1250MsWave", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse withstand on 1.2/50 ms wave")]
        public string ImpulseWithstandOn1250MsWave { get; set; }
        [Column("PowerFrequencyTestVoltageDryAt50Hz1Min", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Power Frequency Test Voltage (Dry), at 50Hz, 1 min.")]
        public string PowerFrequencyTestVoltageDryAt50Hz1Min { get; set; }
        [Column("ShortTimeWithstandCurrent3SecondRms", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short time withstand current, 3 second, rms")]
        public string ShortTimeWithstandCurrent3SecondRms { get; set; }
        [Column("SymmetricalRms", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Symmetrical, rms")]
        public string SymmetricalRms { get; set; }
        [Column("AsymmetricalRms", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Asymmetrical, rms")]
        public string AsymmetricalRms { get; set; }
        [Column("ShortCircuitMakingCurrentPeak", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short circuit making current, peak")]
        public string ShortCircuitMakingCurrentPeak { get; set; }
        [Column("TripCoilCurrent", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Trip coil current")]
        public string TripCoilCurrent { get; set; }
        [Column("TripCoilVoltage", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Trip coil voltage")]
        public string TripCoilVoltage { get; set; }
        [Column("OpeningTimeWithoutCurrentAt100OfRatedBreakingcurrent", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "a) Opening time:  without current at 100% of rated breaking current")]
        public string OpeningTimeWithoutCurrentAt100OfRatedBreakingcurrent { get; set; }
        [Column("BreakingTime", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "b)  Breaking time")]
        public string BreakingTime { get; set; }
        [Column("ClosingTime", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "c)  Closing time")]
        public string ClosingTime { get; set; }
        [Column("RatedVoltageofSpringWindingMotorforClosing", Order = 19, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated voltage of spring winding motor for closing")]
        public string RatedVoltageofSpringWindingMotorforClosing { get; set; }
        [Column("SpringWindingMotorCurrent", Order = 20, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Spring winding motor current")]
        public string SpringWindingMotorCurrent { get; set; }
        [Column("ClosingReleaseCoilCurrent", Order = 21, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Closing release coil current")]
        public string ClosingReleaseCoilCurrent { get; set; }
        [Column("ClosingReleaseCoilVoltage", Order = 22, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Closing release coil voltage")]
        public string ClosingReleaseCoilVoltage { get; set; }
        [Column("NoOfTrippingCoil", Order = 23, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No .of tripping coil")]
        public string NoOfTrippingCoil { get; set; }
        [Column("CircuitBreakerTerminalConnectors", Order = 24, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Circuit  breaker terminal connectors")]
        public string CircuitBreakerTerminalConnectors { get; set; }
        [Column("PressureInVacuumTubeforVCB", Order = 25, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Pressure in vacuum tube for VCB")]
        public string PressureInVacuumTubeforVCB { get; set; }
        [Column("AtRatedCurrentSwitching", Order = 26, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "a) at rated Current switching")]
        public string AtRatedCurrentSwitching { get; set; }
        [Column("AtShortCircuitCurrentSwitching", Order = 27, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "b) at Short circuit current switching")]
        public string AtShortCircuitCurrentSwitching { get; set; }
        [Column("RatedOperatingSequence", Order = 28, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated operating sequence")]
        public string RatedOperatingSequence { get; set; }

    }
}
