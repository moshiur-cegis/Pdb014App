using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Pdb014App.Models.PDB.DistributionTransformerModel;


namespace Pdb014App.Models.PDB.ServicePointModels
{
    public class TblConsumerData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ConsumerId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Consumer Id")]
        public int ConsumerId { get; set;}


        [Required]
        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Service Point")]
        public string ServicesPointId { get; set; }   //FK
        [ForeignKey("ServicesPointId")]
        public virtual TblServicePoint ConsumerDataToServicesPoint { get; set; }


        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Distribution Transformer Id")]
        public string DistributionTransformerId { get; set; }
        [ForeignKey("DistributionTransformerId")]
        public virtual TblDistributionTransformer ConsumerDataToDistributionTransformer { get; set; }



        [Column(Order = 3, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Column(Order = 4, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Customer Mobile No")]
        public string CustomerMobileNo { get; set; }

        [Column(Order = 5, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Customer No")]
        public string ConsumerNo { get; set; }

        [Column(Order = 6, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Tariff")]
        public string Tariff { get; set; }


        [Column( Order = 7, TypeName = "int")]
        [Display(Name = "Phasing Code")]
        public int? PhasingCodeId { get; set; }   //FK
        [ForeignKey("PhasingCodeId")]
        public virtual LookUpPhasingCodeType ConsumerToPhasingCode { get; set; }

        [Column(Order = 8, TypeName = "int")]
        [Display(Name = "Consumer Type")]
        public int? ConsumerTypeId { get; set; }   //FK
        [ForeignKey("ConsumerTypeId")]
        public virtual LookUpConsumerType ConsumerType { get; set; }

        [Column(Order = 9, TypeName = "int")]
        [Display(Name = "Operating Voltage")]
        public int? OperatingVoltageId { get; set; }   //FK
        [ForeignKey("OperatingVoltageId")]
        public virtual LookUpOperatingVoltage ConsumerToOperatingVoltage { get; set; }

        //[Column("InstallDate", Order = 10, TypeName = "date")]
        //[DataType(DataType.Text)]
        //[DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Install Date")]
        //public DateTime? InstallDate { get; set; }

        //[Column("InstallDate", Order = 10, TypeName = "date")]
        //[DataType(DataType.Text)]
        //[DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Install Date")]
        public string InstallDate { get; set; }

        [Column(Order = 11, TypeName = "int")]
        [Display(Name = "Connection Status")]
        public int? ConnectionStatusId { get; set; }   
        [ForeignKey("ConnectionStatusId")]
        public virtual LookUpConnectionStatus ConsumerToConnectionStatus { get; set; }

        [Column(Order = 12, TypeName = "int")]
        [Display(Name = "Connection Type")]
        public int? ConnectionTypeId { get; set; }
        [ForeignKey("ConnectionTypeId")]
        public virtual LookUpConnectionType ConsumerToConnectionType { get; set; }

        [Column(Order = 13, TypeName = "int")]
        [Display(Name = "Meter Type")]
        public int? MeterTypeId { get; set; }
        [ForeignKey("MeterTypeId")]
        public virtual LookUpMeterType ConsumerToMeterType { get; set; }


        [Column(Order = 14, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Meter Number")]
        public string MeterNumber { get; set; }

        [Column(Order = 15, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Meter Model")]
        public string MeterModel { get; set; }


        [Column(Order = 16, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Meter Manufacturer")]
        public string MeterManufacturer { get; set; }


        [Column(Order = 17, TypeName = "int")]
        [Display(Name = "Sanctioned Load")]
        public int? SanctionedLoad { get; set; }

        [Column(Order = 18, TypeName = "int")]
        [Display(Name = "Connected Load")]
        public int? ConnectedLoad { get; set; }

        
        [Column(Order = 19, TypeName = "int")]
        [Display(Name = "Business Type Id")]
        public int? BusinessTypeId { get; set; }
        [ForeignKey("BusinessTypeId")]
        public virtual LookUpBusinessType ConsumerToBusinessType { get; set; }


        [Column(Order = 20, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Other Business Name")]
        public string OthersBusiness { get; set; }  


        [Column(Order = 21, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Column(Order = 22, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Special Code")]
        public string SpecialCode { get; set; }

        [Column(Order = 22, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Special Type")]
        public string SpecialType { get; set; }


        [Column(Order = 23, TypeName = "int")]
        [Display(Name = "Location")]
        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual LookUpLocation ConsumerToLocation { get; set; }

        
        [Column(Order = 24, TypeName = "int")]
        [Display(Name = "Bill Group")]
        public int? BillGroup { get; set; }
        
        [Column(Order = 25, TypeName = "int")]
        [Display(Name = "Book Number")]
        public int? BookNumber { get; set; }


        [Column(Order = 26, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "OMF Kwh")]
        public string OmfKwh { get; set; }

        [Column(Order = 27, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Meter Reading")]
        public string MeterReading { get; set; }

        [Column(Order = 28, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Service Cable Size")]
        public string ServiceCableSize { get; set; }

        [Column(Order = 29, TypeName = "int")]
        [Display(Name = "Service Cable Type")]
        public int? ServiceCableTypeId { get; set; }
        [ForeignKey("ServiceCableTypeId")]
        public virtual LookUpServiceCableType ConsumerToServiceCableType { get; set; }


        [Column(Order = 30, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }


        [Column(Order = 31, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Plot No")]
        public string PlotNo { get; set; }


        [Column(Order = 32, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Building Appt. No")]
        public string BuildingApptNo { get; set; }

        [Column(Order = 33, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Premise Name")]
        public string PremiseName { get; set; }

        [Column("SurveyDate", Order = 34, TypeName = "date")]
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Survey Date")]
        public DateTime? SurveyDate { get; set; }


        /*FK*/
        //[Display(Name = "Building Id")]
        //public string BuildingId { get; set; }

        [Column("Latitude", Order = 35, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 9999999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; }


        [Column("Longitude", Order = 36, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 9999999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; }


        [Column(Order = 37, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Structure Id")]
        public string StructureId { get; set; }

        [Column(Order = 38, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Structure Map No")]
        public string StructureMapNo { get; set; }

        [Column(Order = 39, TypeName = "int")]
        [Display(Name = "Structure Type")]
        public int? StructureTypeId { get; set; }
        [ForeignKey("StructureTypeId")]
        public virtual LookUpStructureType ConsumerToStructureType { get; set; }


        [Column(Order = 40, TypeName = "int")]
        [Display(Name = "Number Of Floor")]
        public int? NumberOfFloor { get; set; }
        
    }
}

