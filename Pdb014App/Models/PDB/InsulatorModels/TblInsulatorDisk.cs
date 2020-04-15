using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pdb014App.Models.PDB.InsulatorModels
{
    public class TblInsulatorDisk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("InsulatorDisktId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Insulator Diskt Id")]
        public int InsulatorDisktId { get; set; }

        //[Required]
        [Column("Installation", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }

        [Column("NominalSystemVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Nominal System Voltage")]
        public string NominalSystemVoltage { get; set; }

        //[Column("", Order = 2, TypeName = "nvarchar(250)")]
        //[StringLength(250)]
        //[Display(Name = "")]
        //public string  { get; set; }

        [Column("InsulatorDiskTypeId", Order = 3, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Insulator Disk Type")]
        /*FK*/
        public int InsulatorDiskTypeId { get; set; }
        [ForeignKey("InsulatorDiskTypeId")]
        public virtual LookUpInsulatorDiskType LookUpInsulatorDiskType { get; set; }

        [Column("MaximumSystemVoltage ", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Maximum System Voltage ")]
        public string MaximumSystemVoltage { get; set; }

        [Column("TypeOfSystem", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Type Of System")]
        public string TypeOfSystem { get; set; }

        [Column("NumberOfDiskPerString", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Number Of Disk Per String")]
        public string NumberOfDiskPerString { get; set; }


        [Column("MinimumCreepageDistance", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Creepage Distance")]
        public string MinimumCreepageDistance { get; set; }

        [Column("MinimumWithstandVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum With stand Voltage")]
        public string MinimumWithstandVoltage { get; set; }

        [Column("PowerFrequencyDry", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Power Frequency Dry")]
        public string PowerFrequencyDry { get; set; }

        [Column("PowerFrequencyWet", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Power Frequency Wet")]
        public string PowerFrequencyWet { get; set; }

        [Column("ImpulseWithstandVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Impulse With stand Voltage")]
        public string ImpulseWithstandVoltage { get; set; }

        [Column("MinimumPowerFrequencyFlashoverDry", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Power Frequency Flash over Dry")]
        public string MinimumPowerFrequencyFlashoverDry { get; set; }

        [Column("MinimumPowerFrequencyFlashoverWet", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Power Frequency Flash over Wet")]
        public string MinimumPowerFrequencyFlashoverWet { get; set; }

        [Column("FiftyPctImpulseFlashoverWavePositive", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "50% Impulse Flash over Wave Positive")]
        public string FiftyPctImpulseFlashoverWavePositive { get; set; }

        [Column("FiftyPctImpulseFlashoverWaveNegative", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "50% Impulse Flash over Wave Negative")]
        public string FiftyPctImpulseFlashoverWaveNegative { get; set; }

        [Column("PowerFrequencyPuncherVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Power Frequency Puncher Voltage")]
        public string PowerFrequencyPuncherVoltage { get; set; }

        [Column("MinimumDryArchingDistance", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Dry Arching Distance")]
        public string MinimumDryArchingDistance { get; set; }

        [Column("PowerFrequencyTestVoltageRmsToGround", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Power Frequency Test Voltage Rms To Ground")]
        public string PowerFrequencyTestVoltageRmsToGround { get; set; }

        [Column("MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Radio Influence Voltage (RIV) At 1000Kc in Microvolt")]
        public string MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt { get; set; }
        
        [Column("MinimumElectromechanicalStrength", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Electromechanical Strength")]
        public string MinimumElectromechanicalStrength { get; set; }

        [Column("MinimumMechanicalFailingLoad", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Mechanical Failing Load")]
        public string MinimumMechanicalFailingLoad { get; set; }

        [Column("LookUpTypeOfInsulator", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "TypeOfInsulator")]
        public string TypeOfInsulator { get; set; }

        [Column("DiameterOfInsulator", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Diameter Of Insulator")]
        public string DiameterOfInsulator { get; set; }

        [Column("MinimumUnitSpacing", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Unit Spacing")]
        public string MinimumUnitSpacing { get; set; }

        [Column("CouplingSize", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Coupling Size")]
        public string CouplingSize { get; set; }

        [Column("InsulatorDiskConditionId", Order = 32, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = " Condition")]
        public int? InsulatorDiskConditionId { get; set; }
        [ForeignKey("InsulatorDiskConditionId")]
        public virtual LookUpCondition InsulatorDiskToLookUpCondition { get; set; }

        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Id")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole InsulatorDiskToPole { get; set; }


    }
}
