using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.MeteringPanelModels
{
    public class LookupAnnuciator
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("LookupAnnuciatorId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Annuciator ID")]
        public int AnnuciatorId { get; set; }

        [Column("Annunciator", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Annunciator")]
        public string Annunciator { get; set; }

        [Column("ManufacturesName", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufactures Name")]
        public string ManufacturesName { get; set; }

        [Column("CountryofOrigin", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Country of Origin")]
        public string CountryofOrigin { get; set; }

        [Column("ManufacturesModelNo", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufactures Model no.")]
        public string ManufacturesModelNo { get; set; }
    }
}
