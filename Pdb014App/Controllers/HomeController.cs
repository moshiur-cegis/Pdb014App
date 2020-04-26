using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pdb014App.Models;
using Pdb014App.Models.Report;
using Pdb014App.Repository;


namespace Pdb014App.Controllers
{
    public class HomeController : Controller
    {
        private readonly PdbDbContext _context;

        public HomeController(PdbDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.SubstationCount =_context.TblSubstation.Count();

            ViewBag.DistributionTransformerCount = _context.TblDistributionTransformer.Count();
            ViewBag.FeederLineCount = _context.TblFeederLine.Count();

            ViewBag.PhasePowerTransformerCount = _context.TblPhasePowerTransformer.Count();

            ViewBag.PoleCount = _context.TblPole.Count();


            var stCount = _context.TblSubstation
                .GroupBy(i => i.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName)
                .Select(k => new
                {
                    ZoneName = k.Key,
                    StCount = k.Count()
                }).ToList();

            var stCount11 = _context.TblSubstation
                .Where(s => s.SubstationType.SubstationTypeName.Contains("/11"))
                .GroupBy(i => i.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName)
                .Select(k => new
                {
                    ZoneName = k.Key,
                    StCount = k.Count()
                }).ToList();
            var stCount33 = _context.TblSubstation
                .Where(s => s.SubstationType.SubstationTypeName.Contains("/33"))
                .GroupBy(i => i.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName)
                .Select(k => new
                {
                    ZoneName = k.Key,
                    StCount = k.Count()
                }).ToList();

            var plCount = _context.TblPole
                .GroupBy(i => i.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName)
                .Select(k => new
                {
                    ZoneName = k.Key,
                    PlCount = k.Count()
                }).ToList();


            var dtCount11 = _context.TblDistributionTransformer
                .Where(d => d.DtToFeederLine.NominalVoltage == 11)
                .GroupBy(i => i.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName)
                .Select(k => new
                {
                    ZoneName = k.Key,
                    DtCount = k.Count()
                }).ToList();

            var dtCount33 = _context.TblDistributionTransformer
                .Where(d => d.DtToFeederLine.NominalVoltage == 33)
                .GroupBy(i => i.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName)
                .Select(k => new
                {
                    ZoneName = k.Key,
                    DtCount = k.Count()
                }).ToList();

            var dtCount = _context.TblDistributionTransformer
                .GroupBy(i => i.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName)
                .Select(k => new
                {
                    ZoneName = k.Key,
                    DtCount = k.Count()
                }).ToList();

            var ptCount = _context.TblPhasePowerTransformer
                .GroupBy(i => i.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName)
                .Select(k => new
                {
                    ZoneName = k.Key,
                    PtCount = k.Count()
                }).ToList();



            var zoneList = _context.LookUpZoneInfo.Select(i => i.ZoneName).ToList();


            List<ZoneWiseData> aData = new List<ZoneWiseData>();

            foreach (var zone in zoneList)
            {
                var dtRow = new ZoneWiseData
                {
                    Name = zone,
                    St = stCount.FirstOrDefault(d => d.ZoneName == zone)?.StCount,
                    St11 = stCount11.FirstOrDefault(d => d.ZoneName == zone)?.StCount,
                    St33 = stCount33.FirstOrDefault(d => d.ZoneName == zone)?.StCount,
                    Pt = ptCount.FirstOrDefault(d => d.ZoneName == zone)?.PtCount,
                    Dt = dtCount.FirstOrDefault(d => d.ZoneName == zone)?.DtCount,
                    Dt11 = dtCount11.FirstOrDefault(d => d.ZoneName == zone)?.DtCount,
                    Dt33 = dtCount33.FirstOrDefault(d => d.ZoneName == zone)?.DtCount,
                    Pl = plCount.FirstOrDefault(d => d.ZoneName == zone)?.PlCount
                };

                aData.Add(dtRow);
            }


            ViewBag.SummaryData = aData;

            return View(aData);

            //List<object> data = new List<object>(zoneList.Count);
            ////List<ZoneWiseData> data = new List<ZoneWiseData>();

            //foreach (var zone in zoneList)
            //{
            //    var dtRow = new
            //    {
            //        Name = zone,
            //        St = stCount.FirstOrDefault(d => d.ZoneName == zone)?.StCount,// .Select(d => d.StCount),
            //        Pl = plCount.FirstOrDefault(d => d.ZoneName == zone)?.PlCount,
            //        Dt = dtCount.FirstOrDefault(d => d.ZoneName == zone)?.DtCount,
            //        Pt = ptCount.FirstOrDefault(d => d.ZoneName == zone)?.PtCount
            //    };

            //    data.Add(dtRow);
            //}
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PowerBI()
        {
            return View();
        }
    }
}
