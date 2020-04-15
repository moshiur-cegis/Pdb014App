using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pdb014App.Models.Report
{
    public class ReportField
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Selected { get; set; }

        public string GroupName { get; set; }

        public bool Visible { get; set; } = true;
    }
}



