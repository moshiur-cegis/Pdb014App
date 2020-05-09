using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Pdb014App.Models.PDB.DistributionTransformerModel;


namespace Pdb014App.Models.PDB.ServicePointModels
{
    public class TblServicePoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ServicePointId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "ServicePointId")]
        public int ServicePointId { get; set; }


        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Pole Id")]
        public string PoleId { get; set; }
        [ForeignKey("PoleId")]
        public virtual TblPole ServicePointToPole { get; set; }

        //[Required]
        //[Column(Order = 2, TypeName = "nvarchar(250)")]
        //[StringLength(250)]
        //[Display(Name = "Voltage Category")]
        //public string VoltageCategory { get; set; }


        [Column("VoltageCategoryId", Order = 2, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Voltage Category")]
        public int? VoltageCategoryId { get; set; }   //FK
        [ForeignKey("VoltageCategoryId")]
        public virtual LookUpVoltageCategory VoltageCategory { get; set; }

        [Column(Order = 3, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Transformer Number")]
        public string TransformerNumber { get; set; }



        [Column("ServicePointTypeId", Order = 4, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Service Point")]
        public int? ServicePointTypeId { get; set; }   //FK
        [ForeignKey("ServicePointTypeId")]
        public virtual LookUpServicePointType ServicePointType { get; set; }



        [Column("SpLatitude", Order = 35, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 9999999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Latitude")]
        public decimal? SpLatitude { get; set; }


        [Column("SpLongitude", Order = 36, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 9999999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Longitude")]
        public decimal? SpLongitude { get; set; }



        //[Column("FeederLineId", Order = 4, TypeName = "varchar(50)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "FeederLineId")]
        //public string FeederLineId { get; set; }   //FK
        //[ForeignKey("FeederLineId")]
        //public virtual TblFeederLine ConsumerDataToFeederLine { get; set; }

        [Column(Order = 5, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Aggregate Load kw")]
        public string AggregateLoadkw { get; set; }

        [Column(Order = 6, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "No OF Consumers R")]
        public string NoOFConsumersR { get; set; }


        [Column(Order =7, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "No OF Consumers Y")]
        public string NoOFConsumersY { get; set; }


        [Column(Order = 8, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "No OF Consumers B")]
        public string NoOFConsumersB { get; set; }


        [Column(Order = 9, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "No Of Consumers RYB")]
        public string NoOfConsumersRyb { get; set; }


        [Column(Order = 14, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Road Name")]
        public string RoadName { get; set; }

        [Column(Order = 15, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Village/Area Name")]
        public string VillageOrAreaName { get; set; }

        [Column(Order = 15, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Ward")]
        public string Ward { get; set; }

        [Column(Order = 16, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "City Town")]
        public string CityTown { get; set; }

        [Column(Order = 17, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Primary Landmark")]
        public string PrimaryLandmark { get; set; }
    }
}









