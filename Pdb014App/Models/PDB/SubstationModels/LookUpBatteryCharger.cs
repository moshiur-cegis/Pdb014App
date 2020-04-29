using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class LookUpBatteryCharger
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BatteryChargerId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "BatteryChargerId")]
        public int BatteryChargerId { get; set; }

        //[Column("SubstationId", Order = 2, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "SubstationId")]
        //public int? SubstationId { get; set; }   //FK
        //[ForeignKey("SubstationId")]
        //public virtual TblSubstation BatteryChargerToSubstation { get; set; }

        [Column("SubstationId", Order = 2, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "SubstationId")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation BatteryChargerToSubstation { get; set; }


        [Column("ManufacturersNameAndCompany", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers name & company")]
        public string ManufacturersNameAndCompany { get; set; }
        [Column("ManufacturersModelNo", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers model no.")]
        public string ManufacturersModelNo { get; set; }
        [Column("Rating", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rating")]
        public string Rating { get; set; }
        [Column("RatedInputVoltageRange", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Input voltage range")]
        public string RatedInputVoltageRange { get; set; }
        [Column("RatedFrequency", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Frequency")]
        public string RatedFrequency { get; set; }
        [Column("NoOfPhase", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "No of Phase")]
        public string NoOfPhase { get; set; }
        [Column("NominalOutputVoltage", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal output voltage")]
        public string NominalOutputVoltage { get; set; }
        [Column("ChargingOperatingControl", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Charging operating  control")]
        public string ChargingOperatingControl { get; set; }
        [Column("OutputCurrent", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Output current")]
        public string OutputCurrent { get; set; }
        [Column("ContinuousCurrentRating", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Continuous current rating")]
        public string ContinuousCurrentRating { get; set; }
        [Column("Efficiency", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Efficiency")]
        public string Efficiency { get; set; }
        [Column("VoltageRegulation", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Voltage regulation")]
        public string VoltageRegulation { get; set; }
        


    }
}
