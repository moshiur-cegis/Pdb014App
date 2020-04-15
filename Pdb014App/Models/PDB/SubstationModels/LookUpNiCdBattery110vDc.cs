using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class LookUpNiCdBattery110vDc
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("NiCdBattery110vDcId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "NiCdBattery110vDcId")]
        public int NiCdBattery110vDcId { get; set; }

        //[Column("SubstationId", Order = 2, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "SubstationId")]
        //public int? SubstationId { get; set; }   //FK
        //[ForeignKey("SubstationId")]
        //public virtual TblSubstation NiCdBattery110VDcToSubstation { get; set; }

        [Column("SubstationId", Order = 2, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "SubstationId")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation NiCdBattery110VDcToSubstation { get; set; }


        [Column("ManufacturersNameAndAddress", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name & Address")]
        public string ManufacturersNameAndAddress { get; set; }
        [Column("ManufacturersModelNo", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers  model no.")]
        public string ManufacturersModelNo { get; set; }
        [Column("Type", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Column("OperatingVoltage", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Operating Voltage")]
        public string OperatingVoltage { get; set; }
        [Column("NumberOfCells", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Number of cells")]
        public string NumberOfCells { get; set; }
        [Column("VoltagePerCell", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Voltage per cell")]
        public string VoltagePerCell { get; set; }

    }
}
