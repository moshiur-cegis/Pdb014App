using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Pdb014App.Models.Basic;
//using Pdb014App.Models.PDB.Report;
using Pdb014App.Models.PDB.LookUpModels;
using Pdb014App.Models.PDB.SubstationModels;


namespace Pdb014App.Models.PDB
{
    public class TblFeederLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Feeder Line Id")]
        public string FeederLineId { get; set; }

        [Column("FeederLineUId", Order = 0, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Feeder Line UId")]
        public string FeederLineUId { get; set; }
        //KPA

        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Feeder Line Type")]
        public string FeederLineTypeId { get; set; }

        [ForeignKey("FeederLineTypeId")] public virtual LookUpFeederLineType FeederLineType { get; set; }


        [Column(Order = 2, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Route Code")]
        public string RouteCode { get; set; }

        [ForeignKey("RouteCode")] public virtual LookUpRouteInfo FeederLineToRoute { get; set; }


        [Column("FeederName", Order = 3, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Feeder Name")]
        public string FeederName { get; set; }

        [Column("NominalVoltage", Order = 4, TypeName = "decimal(5, 0)")]
        [DataType(DataType.Text)]
        [Display(Name = "Nominal Voltage")]
        [Range(0, 99999, ErrorMessage = "Invalid {0}; Max 5 digits")]
        public decimal? NominalVoltage { get; set; }

        //[Column("FeederSource132KVSubstationName", Order = 5, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Feeder source (132 KV substation name)")]
        //public string FeederSource132KVSubstationName { get; set; }

        [Column("FeederLocation", Order = 6, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Feeder Location")]
        public string FeederLocation { get; set; }

        [Column("FeederMeterNumber", Order = 7, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Feeder Meter No.")]
        public string FeederMeterNumber { get; set; }

        [Column("MeterCurrentRating", Order = 8, TypeName = "decimal(12, 5)")]
        [DataType(DataType.Text)]
        [Range(0, 9999999.99999, ErrorMessage = "Invalid {0}; Max 12 digits")]
        [Display(Name = "Meter Current Rating")]
        public decimal? MeterCurrentRating { get; set; }

        [Column("MeterVoltageRating", Order = 9, TypeName = "decimal(12, 5)")]
        [DataType(DataType.Text)]
        [Display(Name = "Meter Voltage Rating")]
        [Range(0, 9999999.99999, ErrorMessage = "Invalid {0}; Max 12 digits")]
        public decimal? MeterVoltageRating { get; set; }

        [Column("MaximumDemand", Order = 10, TypeName = "decimal(12, 5)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Demand")]
        [Range(0, 9999999.99999, ErrorMessage = "Invalid {0}; Max 12 digits")]
        public decimal? MaximumDemand { get; set; }

        [Column("PeakDemand", Order = 11, TypeName = "decimal(12, 5)")]
        [DataType(DataType.Text)]
        [Display(Name = "Peak Demand")]
        [Range(0, 9999999.99999, ErrorMessage = "Invalid {0}; Max 12 digits")]
        public decimal? PeakDemand { get; set; }

        [Column("MaximumLoad", Order = 12, TypeName = "decimal(12, 5)")]
        [DataType(DataType.Text)]
        [Display(Name = "Maximum Load")]
        [Range(0, 9999999.99999, ErrorMessage = "Invalid {0}; Max 12 digits")]
        public decimal? MaximumLoad { get; set; }

        [Column("SanctionedLoad", Order = 13, TypeName = "decimal(12, 5)")]
        [DataType(DataType.Text)]
        [Display(Name = "Sanctioned Load")]
        [Range(0, 9999999.99999, ErrorMessage = "Invalid {0}; Max 12 digits")]
        public decimal? SanctionedLoad { get; set; }

        //[Column("Source33or11kVTransformer", Order = 14, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Source 33/11 kV Transformer ")]
        //public string Source33or11kVTransformer { get; set; }

        //[Column("FeederName11KV", Order = 15, TypeName = "nvarchar(250)")]
        //[DataType(DataType.Text)]
        //[Display(Name = "11 kV Feeder Name")]
        //public string FeederName11KV { get; set; }
        
        public ICollection<TblPole> Poles { get; set; }
        

        private double _feederLength;
        [NotMapped]
        public double FeederLength
        {
            get
            {
                _feederLength = 0;

                if (Poles == null || Poles.Count < 2)
                    return _feederLength;

                var poleList = Poles
                    .OrderBy(pi => pi.FeederWiseSerialNo)
                    .Select(pi => new {pi.PoleNo, pi.PreviousPoleNo, pi.Latitude, pi.Longitude})
                    .ToList();

                if (poleList.Count < 2)
                    return _feederLength;
                
                for (int pc = 1; pc < poleList.Count; pc++)
                {
                    var curPole = poleList[pc];
                    if (string.IsNullOrEmpty(curPole.PreviousPoleNo) || curPole.PreviousPoleNo == "0" ||
                        curPole.Latitude == null || curPole.Longitude == null)
                        continue;

                    var prePole = poleList.FirstOrDefault(p => p.PoleNo == curPole.PreviousPoleNo);

                    if (prePole == null || prePole.Latitude == null || prePole.Longitude == null)
                        continue;

                    var pPoleCrd = new GeoCoordinate((double) prePole.Latitude, (double) prePole.Longitude);
                    var cPoleCrd = new GeoCoordinate((double) curPole.Latitude, (double) curPole.Longitude);

                    _feederLength += cPoleCrd.GetDistanceTo(pPoleCrd);
                    //_feederLength += cPoleCrd.DistanceTo(pPoleCrd);
                }

                return _feederLength;
                //Distance in Km
                //return Math.Round(_feederLength / 1000, 0);
            }

            set => _feederLength = value;
        }

    }

}
