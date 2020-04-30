using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace Pdb014App.Models.Basic
{
    public class AutoCompleteInfo
    {
        [Key]
        public int SlNo { get; set; }
        public string Term { get; set; }
    }
}
