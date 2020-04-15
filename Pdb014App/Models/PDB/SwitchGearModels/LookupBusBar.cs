using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SwitchGearModels
{
    public class LookupBusBar
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BusBarId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Bus Bar Id")]
        public int BusBarId { get; set; }

        [Column("BusBarType", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Bus bar type")]
        public string BusBarType { get; set; }

        [Column("Material", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Material")]
        public string Material { get; set; }

        [Column("CrossSection", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Cross Section")]
        public string CrossSection { get; set; }

        [Column("NominalCurrent", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Current")]
        public string NominalCurrent { get; set; }

        [Column("Accessories", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Accessories")]
        public string Accessories { get; set; }

        [Column("CableConnection", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Cable Connection")]
        public string CableConnection { get; set; }

        [Column("VoltageTransformer", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Voltage Transformer")]
        public string VoltageTransformer { get; set; }

        [Column("SurgeArrester", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Surge Arrester")]
        public string SurgeArrester { get; set; }


    }
}
