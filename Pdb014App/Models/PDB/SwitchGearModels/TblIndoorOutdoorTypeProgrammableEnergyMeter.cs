using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class TblIndoorOutdoorTypeProgrammableEnergyMeter
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EnergyMeterId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Energy MeterId Id")]
        public int EnergyMeterId { get; set; }


        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Switch Gear ID")]
        public string SwitchGearID { get; set; }
        [ForeignKey("SwitchGearID")]
        public virtual TblSwitchGear IndoorOutdoorTypeProgrammableEnergyMeterToSwitchGear { get; set; }



        [Column("ManufacturersNameAddress", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Address")]
        public string ManufacturersNameAddress { get; set; }

        [Column("ManufacturersTypeAndModel", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers type & model")]
        public string ManufacturersTypeAndModel { get; set; }

        [Column("ConstructionConnection", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Construction/connection")]
        public string ConstructionConnection { get; set; }

        [Column("Installation", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installation")]
        public string Installation { get; set; }

        [Column("RatedVoltage", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }

        [Column("MinimumBiasingVoltage", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Minimum Biasing Voltage")]
        public string MinimumBiasingVoltage { get; set; }

        [Column("VariationOfFrequency", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Variation of Frequency")]
        public string VariationOfFrequency { get; set; }

        [Column("VariationOfVoltage", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Variation of Voltage")]
        public string VariationOfVoltage { get; set; }

        [Column("AccuracyClass", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Accuracy class")]
        public string AccuracyClass { get; set; }

        [Column("RatedCurrent", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Current")]
        public string RatedCurrent { get; set; }

        [Column("NominalCurrent", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "i)   Nominal Current")]
        public string NominalCurrent { get; set; }

        [Column("MaximumCurrent", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "ii)  Maximum Current")]
        public string MaximumCurrent { get; set; }

        [Column("MeterConstant", Order = 12, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Meter Constant")]
        public string MeterConstant { get; set; }

        [Column("NoOfTerminal", Order = 13, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No. of Terminal")]
        public string NoOfTerminal { get; set; }

        [Column("YearOfManufacture", Order = 14, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Year of manufacture")]
        public string YearOfManufacture { get; set; }

        [Column("MeterSealingCondition", Order = 15, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Meter sealing Condition")]
        public string MeterSealingCondition { get; set; }

    }
}
