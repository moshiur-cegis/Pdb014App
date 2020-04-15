using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.PDB.Report
{
    //Substation Capacity Type
    public class ssctype
    {
        public double Min { get; }
        public double Max { get; }
        public ssctype(double min, double max) => (Min, Max) = (min, max);
    }

    //Feeder Line Lengths
    public class flltype
    {
        public double Total { get; }
        public double Total33Kv { get; }
        public double Total11Kv { get; }
        public double TotalP4Kv { get; }

        public flltype(double total, double total33Kv = 0, double total11Kv = 0, double totalP4Kv = 0) =>
            (Total, Total33Kv, Total11Kv, TotalP4Kv) = (total, total33Kv, total11Kv, totalP4Kv);
    }

}
