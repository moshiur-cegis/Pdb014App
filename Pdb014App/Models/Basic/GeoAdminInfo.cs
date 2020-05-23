using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using NetTopologySuite.Geometries;


namespace Pdb014App.Models.Basic
{
    public class GeoAdminInfo
    {
        [Key]
        public string GeoCode { get; set; }
        public string GeoName { get; set; }
        public string GeoType { get; set; }
        //public Geometry  Geometry { get; set; }
    }
}
