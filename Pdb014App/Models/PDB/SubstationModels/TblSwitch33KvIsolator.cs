using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.SubstationModels
{
    public class TblSwitch33KvIsolator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Switch33KvIsolatorId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch33KvIsolatorId")]
        public int Switch33KvIsolatorId { get; set; }

        //[Column("SubstationId", Order = 1, TypeName = "int")]
        //[DataType(DataType.Text)]
        //[Display(Name = "SubstationId")]
        //public int? SubstationId { get; set; }
        //[ForeignKey("SubstationId")]
        //public virtual TblSubstation Switch33KvIsolatorToSubstation { get; set; }

        [Column("TypeIsolatorSwitch", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Type (isolator, switch etc)")]
        public string TypeIsolatorSwitch { get; set; }
        [Column("SwitchID", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch ID")]
        public string SwitchID { get; set; }
        [Column("NominalVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Voltage")]
        public string NominalVoltage { get; set; }
        [Column("BreakingType", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Breaking type")]
        public string BreakingType { get; set; }
        [Column("ManufactureMonthAndYear", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Manufacture Month and year")]
        public string ManufactureMonthAndYear { get; set; }
        [Column("InstallationDate", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Installation date")]
        public string InstallationDate { get; set; }
        [Column("NormalStatus", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Normal status")]
        public string NormalStatus { get; set; }
        [Column("RatedCurrent", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated current")]
        public string RatedCurrent { get; set; }
        [Column("RatedVoltage", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }
        [Column("ConnectionStatus", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Connection status")]
        public string ConnectionStatus { get; set; }
        [Column("SwitchNo", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Switch no.")]
        public string SwitchNo { get; set; }


        [Column(Order = 3, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Feeder Line")]
        public string FeederLineId { get; set; }
        [ForeignKey("FeederLineId")]
        public virtual TblFeederLine SwitchToFeederLine { get; set; }

        [Column("SubstationId", Order = 1, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "SubstationId")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation Switch33KvIsolatorToSubstation { get; set; }


        //[Column("AssociatedFeederID", Order = 11, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Associated Feeder ID")]
        //public string AssociatedFeederID { get; set; }
        //[Column("AssociateSubstationNumber", Order = 12, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Associate Substation number")]
        //public string AssociateSubstationNumber { get; set; }
        //[Column("AssociatedPoleNumber", Order = 13, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Associated Pole number")]
        //public string AssociatedPoleNumber { get; set; }

    }
}
