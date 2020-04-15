using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.CopperCableModels
{
    public class TblCopperCables
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //[Column(Order = 0, TypeName = "varchar(50)")]
        //[StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        //[Display(Name = "CopperCablesId")]
        //public string CopperCablesId { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Id")]
        public int Id { get; set; }




        [Column(Order = 28, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "CopperCablesTypeId")]
        public string CopperCablesTypeId { get; set; }
        [ForeignKey("CopperCablesTypeId")]
        public virtual LookUpCopperCablesType CopperCablesType { get; set; }


        [Column("CableSize", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Cable Size")]
        public string CableSize { get; set; }
        [Column("Material", Order = 1, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Material")]
        public string Material { get; set; }
        [Column("NumbersAndDiameterofWires", Order = 2, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Numbers & Diameter of wires")]
        public string NumbersAndDiameterofWires { get; set; }
        [Column("MaximumResistanceat30degC", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum resistance at 30 deg.C")]
        public string MaximumResistanceat30degC { get; set; }
        [Column("NominalThicknessofInsulation", Order = 4, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal thickness of insulation")]
        public string NominalThicknessofInsulation { get; set; }
        [Column("NominalThicknessofSheath", Order = 5, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal thickness of sheath")]
        public string NominalThicknessofSheath { get; set; }
        [Column("ColorofSheath", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Color of sheath")]
        public string ColorofSheath { get; set; }
        [Column("ApproximateOuterDiameter", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Approximate outer diameter")]
        public string ApproximateOuterDiameter { get; set; }
        [Column("ApproximateWeight", Order = 8, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Approximate weight")]
        public string ApproximateWeight { get; set; }
        [Column("ContinuousPermissibleServiceVoltage", Order = 9, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Continuous permissible service voltage")]
        public string ContinuousPermissibleServiceVoltage { get; set; }
        [Column("CurrentRatingAt30degCambientTemperatureUorG", Order = 10, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Current rating at 30 deg.C ambient temperature U/G")]
        public string CurrentRatingAt30degCambientTemperatureUorG { get; set; }
        [Column("CurrentRatingat35degCambientinAir", Order = 11, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Current rating at 35 deg.C ambient in air")]
        public string CurrentRatingat35degCambientinAir { get; set; }


        /*FK*/
        [Column(Order = 12, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "PoleId")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole ConductorToPole { get; set; }

    }
}
