using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Pdb014App.Repository;


namespace Pdb014App.Controllers
{
    public class ReportTestController : Controller
    {
        //private readonly PdbDbContext _context;

        public ActionResult Default()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            StiReport report=new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/ReportUpazila.mrt"));
            return StiNetCoreViewer.GetReportResult(this, report);
        }
        public IActionResult ViewerEvent()
        {

            return StiNetCoreViewer.ViewerEventResult(this);
        }
        public ActionResult Map()
        {
            return View();
        }

    }
}