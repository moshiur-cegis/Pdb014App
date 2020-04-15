using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.PhasePowerTransformerModel
{
    public class TblSurgeArrestor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Surge Arrestor Id")]
        public string SurgeArrestorId { get; set; }


        [Column("ManufacturersNameAndAddress", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Address")]
        public string ManufacturersNameAndAddress { get; set; }

        [Column("ClassOfDiverterToIEC99To4", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Class of Diverter to IEC 99-4")]
        public string ClassOfDiverterToIEC99To4 { get; set; }

        [Column("RatedVoltage", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }

        [Column("RatedVoltageRMSkV30", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage RMS kV 30")]
        public string RatedVoltageRMSkV30 { get; set; }

        [Column("RatedCurrent", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Current")]
        public string RatedCurrent { get; set; }

        [Column("NeutralConnection", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Neutral Connection")]
        public string NeutralConnection { get; set; }

        [Column("PowerFreqWithstandVoltageOfHousing", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Power freq. Withstand Voltage of Housing")]
        public string PowerFreqWithstandVoltageOfHousing { get; set; }

        [Column("Dry", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Dry")]
        public string Dry { get; set; }

        [Column("Wet", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Wet")]
        public string Wet { get; set; }

        [Column("Impulse", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Impulse")]
        public string Impulse { get; set; }

        [Column("LightingImpulseResidualVoltage", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Lighting Impulse Residual Voltage")]
        public string LightingImpulseResidualVoltage { get; set; }

        [Column("SteepCurrentImpulseResidualVoltageAt10kAOr1MicrosFrontTime", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Steep Current Impulse Residual Voltage at 10kA or 1μS Front Time")]
        public string SteepCurrentImpulseResidualVoltageAt10kAOr1MicrosFrontTime { get; set; }

        [Column("HighCurrentImpulseWithStandValue4Or10MicroS", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "High Current Impulse Withstand Value (4/10 μS)")]
        public string HighCurrentImpulseWithStandValue4Or10MicroS { get; set; }

        [Column("SwitchingImpulseResidentialVoltage50Or100MicroS", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Switching Impulse Residential Voltage (50/100 μS)")]
        public string SwitchingImpulseResidentialVoltage50Or100MicroS { get; set; }

        [Column("PressureReliefDeviceFitted", Order = 16, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Pressure Relief Device Fitted ?")]
        public string PressureReliefDeviceFitted { get; set; }

        [Column("TemporaryOverVoltageCapability", Order = 17, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Temporary over voltage capability")]
        public string TemporaryOverVoltageCapability { get; set; }

        [Column("PointOneSeconds", Order = 18, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "0.1 Second")]
        public string PointOneSeconds { get; set; }

        [Column("OneSecond", Order = 19, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "1.0 Second")]
        public string OneSecond { get; set; }

        [Column("TenSeconds", Order = 20, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "10.0 Seconds")]
        public string TenSeconds { get; set; }

        [Column("HunderdSeconds", Order = 21, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "100.0 Seconds")]
        public string HunderdSeconds { get; set; }

        [Column("LeakageCurrentatRatedVoltage", Order = 22, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Leakage Current at Rated Voltage")]
        public string LeakageCurrentatRatedVoltage { get; set; }

        [Column("MinimumResetVoltage", Order = 23, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Minimum Reset Voltage")]
        public string MinimumResetVoltage { get; set; }

        [Column("TotalCreepageDistance", Order = 24, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Total Creepage Distance")]
        public string TotalCreepageDistance { get; set; }

        [Column("SurgeMonitor", Order = 25, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Surge Monitor")]
        public string SurgeMonitor { get; set; }

        [Column("ConnectingLeadfromLATerminaltoSurgeMonitor", Order = 26, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Connecting Lead from LA Terminal to Surge Monitor")]
        public string ConnectingLeadfromLATerminaltoSurgeMonitor { get; set; }

        [Column("OverallDimensionandWeight", Order = 27, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Overall Dimension and Weight")]
        public string OverallDimensionandWeight { get; set; }

        [Column("Height", Order = 28, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Height")]
        public string Height { get; set; }

        [Column("Diameter", Order = 29, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Diameter")]
        public string Diameter { get; set; }

        [Column("TotalWeightofArrester", Order = 30, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Total Weight of Arrester")]
        public string TotalWeightofArrester { get; set; }


        [Column(Order = 31, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Phase Power Transformer")]
        public string PhasePowerTransformerId { get; set; }
        [ForeignKey("PhasePowerTransformerId")]
        public virtual TblPhasePowerTransformer SurgeArrestorToPhasePowerTransformer { get; set; }

    }
}
