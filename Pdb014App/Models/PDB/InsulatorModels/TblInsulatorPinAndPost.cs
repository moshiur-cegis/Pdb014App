using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.InsulatorModels
{
    public class TblInsulatorPinAndPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("InsulatorPinAndPostId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "InsulatorPinAndPostId")]
        public int InsulatorPinAndPostId { get; set; }

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

        [Column("InsulatorPinAndPostTypeId", Order = 3, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "InsulatorPinAndPostTypeId")]
        /*FK*/
        public int InsulatorPinAndPostTypeId { get; set; }
        [ForeignKey("InsulatorPinAndPostTypeId")]
        public virtual LookUpInsulatorPinAndPostType LookUpInsulatorPinAndPostType { get; set; }

        [Column("MaximumSystemVoltage ", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Maximum System Voltage ")]
        public string MaximumSystemVoltage { get; set; }

        [Column("TypeOfSystem", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Type Of System")]
        public string TypeOfSystem { get; set; }

        [Column("InsulatorVoltageClass", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Insulator Voltage Class")]
        public string InsulatorVoltageClass { get; set; }

        [Column("InsulatorMaterials", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Insulator Materials")]
        public string InsulatorMaterials { get; set; }

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
        [Display(Name = "Minimum Power Frequency Flashover Wet")]
        public string MinimumPowerFrequencyFlashoverWet { get; set; }

        [Column("FiftyPctImpulseFlashoverWavePositive", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Fifty Pct Impulse Flash over Wave Positive")]
        public string FiftyPctImpulseFlashoverWavePositive { get; set; }

        [Column("FiftyPctImpulseFlashoverWaveNegative", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Fifty Pct Impulse Flashover Wave Negative")]
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
        [Display(Name = "Minimum Radio Influence Voltage RIV At 1000Kc In MicroVolt")]
        public string MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt { get; set; }

        [Column("MinimumNeckDiameter", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Neck Diameter")]
        public string MinimumNeckDiameter { get; set; }

        [Column("MinimumDiameterOfInsulator", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Diameter Of Insulator")]
        public string MinimumDiameterOfInsulator { get; set; }

        [Column("MinimumHeightOfTheInsulator", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Height Of The Insulator")]
        public string MinimumHeightOfTheInsulator { get; set; }

        [Column("MinimumGroveDiameter", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Grove Diameter")]
        public string MinimumGroveDiameter { get; set; }

        [Column("MinimumMechanicalFailingLoad", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Mechanical Failing Load")]
        public string MinimumMechanicalFailingLoad { get; set; }

        [Column("PinPostConditionId", Order = 32, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = " Condition")]
        public int? PinPostConditionId { get; set; }
        [ForeignKey("PinPostConditionId")]
        public virtual LookUpCondition PinPostonditionToLookUpCondition { get; set; }

        [Column("Quantity", Order = 20, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }


        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Id")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole InsulatorPinAndPostToPole { get; set; }
    }
}
