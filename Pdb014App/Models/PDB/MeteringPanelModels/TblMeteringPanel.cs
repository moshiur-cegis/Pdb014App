using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Pdb014App.Models.PDB.SubstationModels;


namespace Pdb014App.Models.PDB.MeteringPanelModels
{
    public class TblMeteringPanel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MeteringPanelId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Metering Panel Id")] 
        public int MeteringPanelId { get; set; }


        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Substation")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation MeteringPanelToSubstation { get; set; }


        [Column("ManufacturersNameCountryOfOrigin", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Country of Origin")]
        public string ManufacturersNameCountryOfOrigin { get; set; }

        [Column("ManufacturersModelNo", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Model No.")]
        public string ManufacturersModelNo { get; set; }

        [Column("SystemNominalVoltage", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "System Nominal Voltage")]
        public string SystemNominalVoltage { get; set; }

        [Column("MaximumSystemVoltage", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum System Voltage")]
        public string MaximumSystemVoltage { get; set; }

        [Column("RatedFrequency", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Frequency")]
        public string RatedFrequency { get; set; }

        [Column("DifferentialRelayIdForTransformer", Order = 7, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Differential Relay for Transformer")]
        public int? DifferentialRelayIdForTransformer { get; set; }         /*FK*/
        [ForeignKey("DifferentialRelayIdForTransformer")]
        public virtual LookUpDifferentRelay DifferentialRelayForTransformer { get; set; }


        [Column("RestrictedEarthFaultRelayIdForTransformer", Order = 8, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Restricted Earth Fault Relay for Transformer")]
        public int? RestrictedEarthFaultRelayIdForTransformer { get; set; }          /*FK*/
        [ForeignKey("RestrictedEarthFaultRelayIdForTransformer")]
        public virtual LookUpDifferentRelay RestrictedEarthFaultRelayForTransformer { get; set; }


        [Column("IdmtOverCurrentAndEarthFaultRelayIdForTransformer", Order = 9, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "IDMT Over Current and Earth Fault Relay for Transformer")]
        /*FK*/
        public int? IdmtOverCurrentAndEarthFaultRelayIdForTransformer { get; set; }

        [ForeignKey("IdmtOverCurrentAndEarthFaultRelayIdForTransformer")]
        public virtual LookUpDifferentRelay IdmtOverCurrentAndEarthFaultRelayForTransformer { get; set; }


        [Column("AuxiliaryFlagRelayIdForTransformer", Order = 10, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Auxiliary Flag Relay for Transformer")]
        /*FK*/
        public int? AuxiliaryFlagRelayIdForTransformer { get; set; }

        [ForeignKey("AuxiliaryFlagRelayIdForTransformer")]
        public virtual LookUpDifferentRelay AuxiliaryFlagRelayForTransformer { get; set; }



        [Column("TripCircuitSupervisionRelayIdForTransformer", Order = 11, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Trip Circuit Supervision Relay for Transformer")]
        /*FK*/
        public int? TripCircuitSupervisionRelayIdForTransformer { get; set; }

        [ForeignKey("TripCircuitSupervisionRelayIdForTransformer")]
        public virtual LookUpDifferentRelay TripCircuitSupervisionRelayForTransformer { get; set; }


        [Column("TripRelayIdForTransformer", Order = 12, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Trip Relay for Transformer")]
        /*FK*/
        public int? TripRelayIdForTransformer { get; set; }

        [ForeignKey("TripRelayIdForTransformer")]
        public virtual LookUpDifferentRelay TripRelayForTransformer { get; set; }


        [Column("AnnuciatorIdForTransformer", Order = 13, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Annunciator for Transformer")]
        /*FK*/
        public int? AnnuciatorIdForTransformer { get; set; }

        [ForeignKey("AnnuciatorIdForTransformer")]
        public virtual LookupAnnuciator AnnuciatorForTransformer { get; set; }


        [Column("ControlSwitchIdForTransformer", Order = 14, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Control Switch for Transformer")]
        /*FK*/
        public int? ControlSwitchIdForTransformer { get; set; }

        [ForeignKey("ControlSwitchIdForTransformer")]
        public virtual LookupControlSwitch ControlSwitchForTransformer { get; set; }


        [Column("IdmtOverCurrentAndEarthFaultRelayIdForFeeder", Order = 15, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "IDMT Over Current and Earth Fault Relay for Feeder")]
        /*FK*/
        public int? IdmtOverCurrentAndEarthFaultRelayIdForFeeder { get; set; }

        [ForeignKey("IdmtOverCurrentAndEarthFaultRelayIdForFeeder")]
        public virtual LookUpDifferentRelay IdmtOverCurrentAndEarthFaultRelayForFeeder { get; set; }

        [Column("TripCircuitSupervisionRelayIdForFeeder", Order = 16, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Trip Circuit Supervision Relay for Feeder")]
        /*FK*/
        public int? TripCircuitSupervisionRelayIdForFeeder { get; set; }

        [ForeignKey("TripCircuitSupervisionRelayIdForFeeder")]
        public virtual LookUpDifferentRelay TripCircuitSupervisionRelayForFeeder { get; set; }


        [Column("TripRelayIdForFeeder", Order = 17, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Trip Relay for Feeder")]
        /*FK*/
        public int? TripRelayIdForFeeder { get; set; }

        [ForeignKey("TripRelayIdForFeeder")]
        public virtual LookUpDifferentRelay TripRelayForFeeder { get; set; }


        [Column("AnnuciatorIdForFeeder", Order = 18, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Annunciator for Feeder")]
        /*FK*/
        public int? AnnuciatorIdForFeeder { get; set; }

        [ForeignKey("AnnuciatorIdForFeeder")]
        public virtual LookupAnnuciator AnnuciatorForFeeder { get; set; }


        [Column("ControlSwitchIdForFeeder", Order = 19, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Control Switch for Feeder")]
        /*FK*/
        public int? ControlSwitchIdForFeeder { get; set; }

        [ForeignKey("ControlSwitchIdForFeeder")]
        public virtual LookupControlSwitch ControlSwitchForFeeder { get; set; }


        [Column("KWHandkVARHMeterId", Order = 20, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "KWH and kV ARH Meter")]
        /*FK*/
        public int? KWHandkVARHMeterId { get; set; }

        [ForeignKey("KWHandkVARHMeterId")]
        public virtual LookUpDifferentMeter KWHandkVARHMeter { get; set; }


        [Column("VoltMeterId", Order = 21, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Volt Meter")]
        /*FK*/
        public int? VoltMeterId { get; set; }

        [ForeignKey("VoltMeterId")]
        public virtual LookUpDifferentMeter VoltMeterWithSelectorSwitch { get; set; }
        

        [Column("AmpereMeterId", Order = 22, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Ampere Meter")]
        /*FK*/
        public int? AmpereMeterId { get; set; }

        [ForeignKey("AmpereMeterId")]
        public virtual LookUpDifferentMeter AmpereMeter { get; set; }


        [Column("MegaWattMeterId", Order = 23, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Mega Watt Meter")]
        /*FK*/
        public int? MegaWattMeterId { get; set; }

        [ForeignKey("MegaWattMeterId")]
        public virtual LookUpDifferentMeter MegaWattMeter { get; set; }


        [Column("MegaVarMeterId", Order = 24, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Mega Var Meter")]
        /*FK*/
        public int? MegaVarMeterId { get; set; }

        [ForeignKey("MegaVarMeterId")]
        public virtual LookUpDifferentMeter MegaVarMeter { get; set; }


        [Column("DimensionAndWeightId", Order = 25, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Dimension and Weight")]
        public int? DimensionAndWeightId { get; set; }

        [ForeignKey("DimensionAndWeightId")]
        public virtual LookUpDimensionAndWeight MeteringPanelToDimensionAndWeight { get; set; }



    }
}
