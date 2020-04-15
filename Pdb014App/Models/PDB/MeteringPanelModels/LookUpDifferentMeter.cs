using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Pdb014App.Models.PDB.MeteringPanelModels
{
    public class LookUpDifferentMeter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DifferentMeterId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Different Meter Id")]
        public int DifferentMeterId { get; set; }

        [Column("MeterName", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Meter Name")]
        public string MeterName { get; set; }

        [Column("ManufacturersNameandCountry", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name and Country")]
        public string ManufacturersNameandCountry { get; set; }

        [Column("ManufacturesModelNo", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufactures Model No.")]
        public string ManufacturesModelNo { get; set; }

        [Column("TypeOfMeter", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type of Meter")]
        public string TypeOfMeter { get; set; }

        [Column("ClassOfAccuracy", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Class of Accuracy")]
        public string ClassOfAccuracy { get; set; }


        [Column("SeparateAmeterforEachPhase", Order = 78, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Separate A-meter for each Phase")]
        public string SeparateAmeterforEachPhase { get; set; }
        

        [Column("MeterTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Meter Type")]
        /*FK*/
        public int MeterTypeId { get; set; }

        [ForeignKey("MeterTypeId")]
        public virtual LookUpDifferentTypesOfMeter DifferentTypesOfMeter { get; set; }
    }
}
