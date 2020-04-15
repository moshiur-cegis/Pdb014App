using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.MeteringPanelModels
{
    public class LookupControlSwitch
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ControlSwitchId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Control Switch ID")]
        public int ControlSwitchId { get; set; }

        [Column("ControlSwitch", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Control Switch")]
        public string ControlSwitch { get; set; }

        [Column("ManufacturesNameCountry", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufactures Name & Country")]
        public string ManufacturesNameCountry { get; set; }

        [Column("ManufacturesModelTypeNo", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufactures Model/Type No.")]
        public string ManufacturesModelTypeNo { get; set; }
    }
}
