using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Pdb014App.Models.PDB.MeteringPanelModels;
using Pdb014App.Models.PDB.PhasePowerTransformerModel;


namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class TblSwitchGear
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Switch Gear ID")]
        public string SwitchGearID { get; set; }

        [Column("SwitchGearTypeId", Order = 2, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch Gear Type")]
        public int SwitchGearTypeId { get; set; }
        [ForeignKey("SwitchGearTypeId")]
        public virtual LookUpSwitchGearType SwitchGearType { get; set; }
        

        //[Column("SwitchGearUnitId", Order = 1, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Switch Gear Unit")]
        //public int SwitchGearUnitId { get; set; }
        //[ForeignKey("SwitchGearUnitId")]
        //public virtual LookUpSwitchGearUnit SwitchGearToSwitchGearUnit { get; set; }

        //Switch Gear Unit

        [Column("ManufacturersNameAndAddress", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Address")]
        public string ManufacturersNameAndAddress { get; set; }

        [Column("AppliedStandard", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Applied Standard")]
        public string AppliedStandard { get; set; }

        [Column("RatedNominalVoltage", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Nominal Voltage")]
        public string RatedNominalVoltage { get; set; }

        [Column("RatedVoltage", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }

        [Column("RatedCurrentForMainBus", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Current for Main Bus")]
        public string RatedCurrentForMainBus { get; set; }

        [Column("RatedShortTimeCurrent", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Short Time Current")]
        public string RatedShortTimeCurrent { get; set; }

        [Column("ShortTimeCurrentRatedDuration", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short Time Current Rated Duration")]
        public string ShortTimeCurrentRatedDuration { get; set; }
        //Switch Gear Unit

        [Column("CircuitBreakerId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Circuit Breaker")]
        public int? CircuitBreakerId { get; set; }
        [ForeignKey("CircuitBreakerId")]
        public virtual LookUpCircuitBreaker SwitchGearToCircuitBreaker { get; set; }

        //Relay
        [Column("IdmtRelayId", Order = 9, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "IDMT and Instantaneous Feature Relay")]
        /*FK*/
        public int? IdmtRelayId { get; set; }

        [ForeignKey("IdmtRelayId")]
        public virtual LookUpDifferentRelay SwitchGearToIdmtRelay { get; set; }


        [Column("TripRelayId", Order = 12, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Trip Relay")]
        public int? TripRelayId { get; set; }

        [ForeignKey("TripRelayId")]
        public virtual LookUpDifferentRelay SwitchGearToTripRelay { get; set; }


        [Column("TripCircuitSupervisionRelayId", Order = 11, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Trip Circuit Supervision Relay")]
        public int? TripCircuitSupervisionRelayId { get; set; }

        [ForeignKey("TripCircuitSupervisionRelayId")]
        public virtual LookUpDifferentRelay SwitchGearToTripCircuitSupervisionRelay { get; set; }

        //Relay
        [Column("CurrentTransformerId", Order = 4, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Current Trans Former")]
        public int? CurrentTransformerId { get; set; }
        [ForeignKey("CurrentTransformerId")]
        public virtual LookUpCurrentTransformer SwitchGearToCurrentTransformer { get; set; }

        [Column("SwitchPositionId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch Position")]
        public int? SwitchPositionId { get; set; }
        [ForeignKey("SwitchPositionId")]
        public virtual LookUpSwitchPosition SwitchGearToSwitchPosition { get; set; }

        //Insulation Level
        [Column("AcWithStandVoltageDry", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Ac Withstand Voltage 1min. Dry")]
        public string AcWithStandVoltageDry { get; set; }

        [Column("ImpulseWithStandFullWave", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse Withstand Full Wave")]
        public string ImpulseWithStandFullWave { get; set; }

        //Insulation Level

        //Degree Of Protection
        [Column("Enclosure", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Enclosure")]
        public string Enclosure { get; set; }

        [Column("HvCompartment", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "HV Compartment")]
        public string HvCompartment { get; set; }

        [Column("LvCompartment", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "LV Compartment")]
        public string LvCompartment { get; set; }

        //Degree Of Protection


        [Column("Sf6SafetyAndLifeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "SF6 Safety and Life")]
        public int? Sf6SafetyAndLifeId { get; set; }
        [ForeignKey("Sf6SafetyAndLifeId")]
        public virtual LookupSf6SafetyAndLife SwitchGearToSf6SafetyAndLife { get; set; }


       
        //Meter
        [Column("VoltMeterId", Order = 21, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Volt Meter")]
        public int? VoltMeterId { get; set; }
        [ForeignKey("VoltMeterId")]
        public virtual LookUpDifferentMeter SwitchGearToVoltMeter { get; set; }

        [Column("AmpereMeterId", Order = 22, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Ampere Meter")]
        public int? AmpereMeterId { get; set; }
        [ForeignKey("AmpereMeterId")]
        public virtual LookUpDifferentMeter SwitchGearToAmpereMeter { get; set; }
        //Meter

        [Column("BusBarId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bus Bar")]
        public int? BusBarId { get; set; }
        [ForeignKey("BusBarId")]
        public virtual LookupBusBar SwitchGearToBusBar { get; set; }


        //Power Fuse

        [Column("ReatedVoltage", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Reated Voltage for Fuse")]
        public string ReatedVoltage { get; set; }

        [Column("ReatedCurrent", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Reated Current for Fuse")]
        public string ReatedCurrent { get; set; }

        [Column("ReatedShortCircuitBreakerCurrent", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Reated Short Circuit Breaker Current for Fuse")]
        public string ReatedShortCircuitBreakerCurrent { get; set; }
        //Power Fuse

        [Column("PhasePowerTransformerId", Order = 0, TypeName = "varchar(50)")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Power Transformer")]
        public string PhasePowerTransformerId { get; set; }
        [ForeignKey("PhasePowerTransformerId")]
        public virtual TblPhasePowerTransformer SwitchGearToPhasePowerTransformer { get; set; }
        

        [Column("DimensionAndWeightId", Order = 25, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Dimension and Weight")]
        public int? DimensionAndWeightId { get; set; }

        [ForeignKey("DimensionAndWeightId")]
        public virtual LookUpDimensionAndWeight SwitchGearToDimensionAndWeight { get; set; }


    }
}
