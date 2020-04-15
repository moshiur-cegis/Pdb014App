using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pdb014App.Models.MapViewer.Settings
{
    public class LookUpMapViewApplicationServer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("AppServerUrlId", Order = 0, TypeName = "int")]
        [DataType(DataType.Text)]
        [Display(Name = "Application Server URL")]
        public int AppServerUrlId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "nvarchar(100)")]
        [StringLength(100)]
        [Display(Name = "Name of Server")]
        public string AppServerName { get; set; }
               
        [Column(Order = 2, TypeName = "nvarchar(100)")]
        [StringLength(50)]
        [Display(Name = "IP Address")]
        public string AppServerIPAddress { get; set; }
               
        [Column(Order = 3, TypeName = "nvarchar(250)")]
        [StringLength(250)]
        [Display(Name = "Full URL")]
        public string AppServerFullUrl { get; set; }
                
        [Column(Order = 4, TypeName = "int")]        
        [Display(Name = "URL Status")]
        public int? AppServerActivationStatus { get; set; }
    }
}