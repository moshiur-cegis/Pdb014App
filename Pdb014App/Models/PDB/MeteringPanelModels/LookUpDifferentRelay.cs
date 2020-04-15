using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Pdb014App.Models.PDB.MeteringPanelModels
{
    public class LookUpDifferentRelay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DifferentRelayId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Different Relay Id")]
        public int DifferentRelayId { get; set; }


        [Column("ManufacturersName", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Name")]
        public string ManufacturersName { get; set; }

        [Column("CountryOfOrigin", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Country of Origin")]
        public string CountryOfOrigin { get; set; }

        [Column("ManufacturersModelNo", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacturers Model No.")]
        public string ManufacturersModelNo { get; set; }


        [Column("RelayTypeId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Relay Type")]
        /*FK*/
        public int RelayTypeId { get; set; }

        [ForeignKey("RelayTypeId")]
        public virtual LookUpDifferentTypesOfRelay DifferentTypesOfRelay { get; set; }

        //public virtual List<TblMeteringPanel> TblMeteringPanels { get; set; }

        //public virtual ICollection<TblMeteringPanel> TblMeteringPanels { get; set; }
    }
}
