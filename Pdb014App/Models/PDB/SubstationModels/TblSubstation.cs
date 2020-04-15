using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

using Pdb014App.Models.PDB.LookUpModels;
using Pdb014App.Models.PDB.Report;


namespace Pdb014App.Models.PDB.SubstationModels
{
    public class TblSubstation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order = 0, TypeName = "varchar(50)")]
        [StringLength(50, ErrorMessage = "The {0} must be {1} characters.")]
        [Display(Name = "Substation Id")]
        public string SubstationId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "Substation Type")]
        public string SubstationTypeId { get; set; }
        [ForeignKey("SubstationTypeId")]
        public virtual LookUpSubstationType SubstationType { get; set; }

        [Required]
        [Column("SubstationName", Order = 2, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Substation Name")]
        public string SubstationName { get; set; }

        //[Required]
        [Column(Order = 3, TypeName = "varchar(50)")]
        [StringLength(50)]
        [Display(Name = "SnD Code")]
        public string SnDCode { get; set; }
        [ForeignKey("SnDCode")]
        public virtual LookUpSnDInfo SubstationToLookUpSnD { get; set; }


        [Column("NominalVoltage", Order = 4, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Nominal Voltage (KV)")]
        public string NominalVoltage { get; set; }


        [Column("InstalledCapacity", Order = 5, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Installed Capacity (MVA)")]
        public string InstalledCapacity{ get; set; }

        [Column("MaximumDemand", Order = 7, TypeName = "decimal(7, 2)")]
        [DataType(DataType.Text)]
        [Range(0, 99999.99, ErrorMessage = "Invalid {0}; Max 7 digits")]
        [Display(Name = "Maximum Demand (MW)")]
        public decimal? MaximumDemand { get; set; }

        [Column("PeakLoad", Order = 7, TypeName = "decimal(7, 2)")]
        [DataType(DataType.Text)]
        [Range(0, 99999.99, ErrorMessage = "Invalid {0}; Max 7 digits")]
        [Display(Name = "Peak Load (MW)")]
        public decimal? PeakLoad { get; set; }

       

        [Column("Location", Order = 8, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Column("AreaOfSubstation", Order = 9, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Area of Substation")]
        public string AreaOfSubstation { get; set; }

        
        [Column("Latitude", Order = 10, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Latitude")]
        public decimal? Latitude { get; set; }

        [Column("Longitude", Order = 11, TypeName = "decimal(10, 8)")]
        [DataType(DataType.Text)]
        [Range(0, 99.99999999, ErrorMessage = "Invalid {0}; Max 10 digits")]
        [Display(Name = "Longitude")]
        public decimal? Longitude { get; set; }


        //Added By Anisur Rahman
        [Column("DefaultZoomLevel", Order = 12, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Default Zoom Level")]
        public int? DefaultZoomLevel { get; set; }


        [Column("YearOfComissioning", Order = 13, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Year of Commissioning")]
        public string YearOfComissioning { get; set; }



        private double _totalCapacity = 0, _totalMaxCapacity = 0;
        [NotMapped]
        public ssctype TotalCapacity
        {
            get
            {
                _totalCapacity = 0;
                _totalMaxCapacity = 0;

                if (string.IsNullOrEmpty(InstalledCapacity))
                    return new ssctype(0, 0);

                char[] delimiterChars = { '+' };
                char[] delimiterChars1 = { '*', 'x', '×' };
                char[] delimiterChars2 = { '/' };

                InstalledCapacity = Regex.Replace(InstalledCapacity, @"\s+", "");
                string[] capacities = InstalledCapacity.Split(delimiterChars);

                foreach (var capacity in capacities)
                {
                    int count;
                    double valMin = 0, valMax = 0;
                    string strVal;

                    string[] capacityOptions = capacity.Split(delimiterChars1);

                    if (capacityOptions.Length > 1)
                    {
                        if (!int.TryParse(capacityOptions[0], out count))
                        {
                            count = 1;
                        }

                        strVal = capacityOptions[1];
                    }
                    else
                    {
                        count = 1;
                        strVal = capacityOptions[0];
                    }

                    if (!string.IsNullOrEmpty(strVal))
                    {
                        string[] vals = strVal.Split(delimiterChars2);

                        if (vals.Length > 1)
                        {
                            if (!double.TryParse(vals[0], out valMin))
                            {
                                valMin = 0;
                            }

                            if (!double.TryParse(vals[1], out valMax))
                            {
                                valMax = 0;
                            }
                        }
                        else
                        {
                            if (double.TryParse(vals[0], out valMin))
                            {
                                valMax = valMin;
                            }
                            else
                            {
                                valMin = valMax = 0;
                            }
                        }
                    }

                    _totalCapacity += count * valMin;
                    _totalMaxCapacity += count * valMax;
                }

                return new ssctype(Math.Round(_totalCapacity, 2), Math.Round(_totalMaxCapacity, 2));
            }

            set => (_totalCapacity, _totalMaxCapacity) = (value.Min, value.Max);
        }

    }
}
