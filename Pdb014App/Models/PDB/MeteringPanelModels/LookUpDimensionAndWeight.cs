using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Pdb014App.Models.PDB.MeteringPanelModels
{
    public class LookUpDimensionAndWeight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DimensionAndWeightId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Dimension And Weight Id")]
        public int DimensionAndWeightId { get; set; }

        [Column("Height", Order = 89, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Height")]
        public string Height { get; set; }

        [Column("Width", Order = 90, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Width")]
        public string Width { get; set; }

        [Column("Depth", Order = 91, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Depth")]
        public string Depth { get; set; }

        [Column("WeightIncludingCircuitBreaker", Order = 92, TypeName = "nvarchar(250)")]
        [DataType(DataType.Text)]
        [Display(Name = "Weight including Circuit Breaker")]
        public string WeightIncludingCircuitBreaker { get; set; }


        private string _dim = "";
        [NotMapped]
        [Display(Name = "Dimension (HxWxD)")]
        public string Dimension
        {
            get
            {
                _dim += string.IsNullOrEmpty(Height) ? "0" : Height + " x ";
                _dim += string.IsNullOrEmpty(Width) ? "0" : Width + " x ";
                _dim += string.IsNullOrEmpty(Depth) ? "0" : Depth;

                return _dim;
            }
            set => _dim = value;
        }

    }
}
