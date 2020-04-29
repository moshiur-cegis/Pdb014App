using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Pdb014App.Models.PDB.SubstationModels
{
    public class TblRelay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RelayId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Relay Id")]
        public int RelayId { get; set; }

        //[Required]
        [Column("RelayName", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Relay Name")]
        public string RelayName { get; set; }

        [Column("NominalVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Nominal Voltage")]
        public string NominalVoltage { get; set; }

        //[Column("", Order = 2, TypeName = "nvarchar(250)")]
        //[StringLength(250)]
        //[Display(Name = "")]
        //public string  { get; set; }
        [Column("ManufactureName", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Manufacture Name")]
        public string ManufactureName { get; set; }

        [Column("ModelNumber", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }

        [Column("RatedCurrent", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Rated Current")]
        public string RatedCurrent { get; set; }

        [Column("RatedVoltage", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Rated Voltage")]
        public string RatedVoltage { get; set; }


        [Column("ConnectionStatus", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Connection Status")]
        public string ConnectionStatus { get; set; }


//        [Column("FeederLineId", Order = 3, TypeName = "int")]
//        [DataType(DataType.Text)]
//        [Display(Name = "Feeder Line Id")]
//        /FK/  public int FeederLineId { get; set; }

        //        [Column("SubstationId", Order = 3, TypeName = "int")]
        //        [DataType(DataType.Text)]
        //        [Display(Name = "TblSubstation Id")]
        ///*FK*/  public int SubstationId { get; set; }
        ///
        /// 


        [Column(Order = 3, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Feeder Line")]
        public string FeederLineId { get; set; }
        [ForeignKey("FeederLineId")]
        public virtual TblFeederLine RelayToFeederLine { get; set; }
        

        [Column("SubstationId", Order = 2, TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        [Display(Name = "Substation")]
        public string SubstationId { get; set; }
        [ForeignKey("SubstationId")]
        public virtual TblSubstation RelayToSubstation { get; set; }
    }
}
