using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.InsulatorModels
{
    public class TblInsulatorShackleOrGuy
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("InsulatorShackleOrGuyId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "InsulatorShackleOrGuyId")]
        public int InsulatorShackleOrGuyId { get; set; }



        [Column("InsulatorShackleOrGuyTypeId", Order = 3, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "InsulatorShackleOrGuyTypeId")]
        /*FK*/
        public int InsulatorShackleOrGuyTypeId { get; set; }
        [ForeignKey("InsulatorShackleOrGuyTypeId")]
        public virtual LookUpInsulatorShackleOrGuyType LookUpInsulatorShackleOrGuyType { get; set; }

        //[Required]
        [Column("Installation", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }

        [Column("NominalSystemVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Nominal System Voltage")]
        public string NominalSystemVoltage { get; set; }

        [Column("MaximumSystemVoltage ", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Maximum System Voltage ")]
        public string MaximumSystemVoltage { get; set; }

        //[Column("", Order = 2, TypeName = "nvarchar(250)")]
        //[StringLength(250)]
        //[Display(Name = "")]
        //public string  { get; set; }


        [Column("TypeOfSystem", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Type Of System")]
        public string TypeOfSystem { get; set; }


        [Column("MinimumDiameterOfInsulator", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Diameter Of Insulator")]
        public string MinimumDiameterOfInsulator { get; set; }

        [Column("MinimumHeightOfTheInsulator", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Height Of The Insulator")]
        public string MinimumHeightOfTheInsulator { get; set; }

        [Column("MinimumMechanicalFailingLoadTransverse", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Minimum Mechanical Failing LoadT ransverse")]
        public string MinimumMechanicalFailingLoadTransverse { get; set; }


        [Column("DryFlashover", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Dry Flash over")]
        public string DryFlashover { get; set; }


        [Column("WetFlashoverVertical", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Wet Flash over Vertical")]
        public string WetFlashoverVertical { get; set; }


        [Column("WetFlashoverHorizontal", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Wet Flash over Horizontal")]
        public string WetFlashoverHorizontal { get; set; }


        [Column("InsulationClass", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Insulation Class")]
        public string InsulationClass { get; set; }


        [Column("AtmosphericCondition", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Atmospheric Condition")]
        public string AtmosphericCondition { get; set; }


        [Column("Dimension", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Dimension")]
        public string Dimension { get; set; }


        [Column("FlashOverVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Flash Over Voltage")]
        public string FlashOverVoltage { get; set; }

        [Column("PowerFrequencyPunctureVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Power Frequency Puncture Voltage")]
        public string PowerFrequencyPunctureVoltage { get; set; }


        [Column("MechanicalStrength", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Mechanical Strength")]
        public string MechanicalStrength { get; set; }



        [Column("ShackleOrGuyConditionId", Order = 32, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = " Condition")]
        public int? ShackleOrGuyConditionId { get; set; }
        [ForeignKey("ShackleOrGuyConditionId")]
        public virtual LookUpCondition ShackleOrGuyToLookUpCondition { get; set; }

        [Column("NoOfSet", Order = 20, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "No Of Set")]
        public int? NoOfSet { get; set; }


        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Id")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole InsulatorShackleOrGuyToPole { get; set; }

    }
}
