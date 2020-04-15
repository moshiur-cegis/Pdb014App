using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class TblAutoCircuitReCloser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AutoCircuitReCloserId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "AutoCircuitReCloserId")]
        public int AutoCircuitReCloserId { get; set; }


        [Column("AutoCircuitReCloserTypeId", Order = 2, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Auto Circuit Re-Closer Type Id")]
        public int? AutoCircuitReCloserTypeId { get; set; }   //FK
        [ForeignKey("AutoCircuitReCloserTypeId")]
        public virtual LookUpAutoCircuitReCloserType AutoCircuitReCloserType { get; set; }



        //[Column("SubstationId", Order = 2, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "SubstationId")]
        //public int? SubstationId { get; set; }   //FK
        //[ForeignKey("SubstationId")]
        //public virtual TblSubstation AutoCircuitReCloserIdToSubstation { get; set; }

        [Column("SubstationId", Order = 2, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "SubstationId")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation AutoCircuitReCloserIdToSubstation { get; set; }



        [Column("ManufacturersNameAddress", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Address")]
        public string ManufacturersNameAddress { get; set; }
        [Column("CountryOfOrigin", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Country of Origin")]
        public string CountryOfOrigin { get; set; }
        [Column("TypeOfModel", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Model")]
        public string TypeOfModel { get; set; }
        [Column("InterruptingMedium", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Interrupting Medium")]
        public string InterruptingMedium { get; set; }
        [Column("HermeticallySealed", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Hermetically sealed")]
        public string HermeticallySealed { get; set; }
        [Column("ControlSystemforACR", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Control System for ACR")]
        public string ControlSystemforACR { get; set; }
        [Column("InsulatingMedium", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Insulating Medium")]
        public string InsulatingMedium { get; set; }
        [Column("NominalSystemVoltage", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal System Voltage")]
        public string NominalSystemVoltage { get; set; }
        [Column("MaximumVoltage", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Voltage")]
        public string MaximumVoltage { get; set; }
        [Column("RatedFrequency", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Frequency")]
        public string RatedFrequency { get; set; }
        [Column("InsulationLevel", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Insulation Level")]
        public string InsulationLevel { get; set; }
        [Column("ImpulseWithstandVoltage", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "i. Impulse withstand voltage")]
        public string ImpulseWithstandVoltage { get; set; }
        [Column("PowerFrequencyWithstandVoltage", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "i. Power Frequency Withstand Voltage")]
        public string PowerFrequencyWithstandVoltage { get; set; }
        [Column("RatedContinuousCurrent", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Continuous Current")]
        public string RatedContinuousCurrent { get; set; }
        [Column("MaximumRatedCurrent", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Rated  Current")]
        public string MaximumRatedCurrent { get; set; }
        [Column("RatedShortCircuitCurrent", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Short Circuit Current")]
        public string RatedShortCircuitCurrent { get; set; }
        [Column("SymmetricalInterruptingCurrent", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Symmetrical Interrupting Current")]
        public string SymmetricalInterruptingCurrent { get; set; }
        [Column("AsymmetricalInterrupting", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Asymmetrical Interrupting")]
        public string AsymmetricalInterrupting { get; set; }
        [Column("SymmetricalMakinoCurrent", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Symmetrical Makino Current")]
        public string SymmetricalMakinoCurrent { get; set; }
        [Column("ShortTimewithstandCurrent", Order = 19, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Short time withstand current")]
        public string ShortTimewithstandCurrent { get; set; }
        [Column("ProtectionAndMeterningCTration", Order = 20, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Protection & Meterning CT ration")]
        public string ProtectionAndMeterningCTration { get; set; }
        [Column("GasPressureIndicator", Order = 21, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Gas pressure indicator")]
        public string GasPressureIndicator { get; set; }
    }
}
