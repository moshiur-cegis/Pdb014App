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
            var stInfo = _context.TblSubstation
                .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    StCount = k.Count(),
                    //StCount11 = k.Count(ss => ss.NominalVoltage.Contains("11")),
                    //StCount33 = k.Count(ss => ss.NominalVoltage.Contains("33")),
                    StCount11 = k.Count(s => s.SubstationType.SubstationTypeName.Contains("/11")),
                    StCount33 = k.Count(s => s.SubstationType.SubstationTypeName.Contains("/33"))
                }).ToList();


            var flInfo = _context.TblFeederLine
                .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    FlCount = k.Count(),
                    FlCount11 = k.Count(dt => dt.NominalVoltage == 11),
                    FlCount33 = k.Count(dt => dt.NominalVoltage == 33)
                }).ToList();


            var dtInfo = _context.TblDistributionTransformer
                .GroupBy(z => z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    DtCount = k.Count(),
                    DtCount11 = k.Count(dt => dt.DtToFeederLine.NominalVoltage == 11),
                    DtCount33 = k.Count(dt => dt.DtToFeederLine.NominalVoltage == 33)
                }).ToList();


            var plInfo = _context.TblPole
                .GroupBy(z => z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    PlCount = k.Count()
                }).ToList();


            var ptInfo = _context.TblPhasePowerTransformer
                .GroupBy(z => z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    PtCount = k.Count()
                }).ToList();


            var zoneList = _context.LookUpZoneInfo.Select(z => new { z.ZoneCode, z.ZoneName }).ToList();


            List<ZoneWiseData> aData = new List<ZoneWiseData>();
            var dtRow = new ZoneWiseData();

            foreach (var zone in zoneList)
            {
                dtRow = new ZoneWiseData
                {
                    Name = zone.ZoneName,
                    St = stInfo.FirstOrDefault(ss => ss.ZoneCode == zone.ZoneCode && ss.StCount > 0)?.StCount,
                    St11 = stInfo.FirstOrDefault(ss => ss.ZoneCode == zone.ZoneCode && ss.StCount11 > 0)?.StCount11,
                    St33 = stInfo.FirstOrDefault(ss => ss.ZoneCode == zone.ZoneCode && ss.StCount33 > 0)?.StCount33,
                    Fl = flInfo.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.FlCount > 0)?.FlCount,
                    Fl11 = flInfo.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.FlCount11 > 0)?.FlCount11,
                    Fl33 = flInfo.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.FlCount33 > 0)?.FlCount33,
                    Pt = ptInfo.FirstOrDefault(pt => pt.ZoneCode == zone.ZoneCode && pt.PtCount > 0)?.PtCount,
                    Dt = dtInfo.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.DtCount > 0)?.DtCount,
                    Dt11 = dtInfo.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.DtCount11 > 0)?.DtCount11,
                    Dt33 = dtInfo.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.DtCount33 > 0)?.DtCount33,
                    Pl = plInfo.FirstOrDefault(pl => pl.ZoneCode == zone.ZoneCode && pl.PlCount > 0)?.PlCount
                };

                aData.Add(dtRow);
            }


            dtRow = new ZoneWiseData
            {
                Name = "Total",
                St = stInfo.Sum(ss => ss.StCount),
                St11 = stInfo.Sum(ss => ss.StCount11),
                St33 = stInfo.Sum(ss => ss.StCount33),
                Fl = flInfo.Sum(dt => dt.FlCount),
                Fl11 = flInfo.Sum(dt => dt.FlCount11),
                Fl33 = flInfo.Sum(dt => dt.FlCount33),
                Pt = ptInfo.Sum(pt => pt.PtCount),
                Dt = dtInfo.Sum(dt => dt.DtCount),
                Dt11 = dtInfo.Sum(dt => dt.DtCount11),
                Dt33 = dtInfo.Sum(dt => dt.DtCount33),
                Pl = plInfo.Sum(pl => pl.PlCount)
            };

            aData.Add(dtRow);


            ViewBag.SsCount = stInfo.Sum(ss => ss.StCount);
            ViewBag.DtCount = dtInfo.Sum(dt => dt.DtCount);
            ViewBag.FlCount = flInfo.Sum(fl => fl.FlCount);
            ViewBag.PtCount = ptInfo.Sum(pt => pt.PtCount);
            ViewBag.PlCount = plInfo.Sum(pl => pl.PlCount);


            return View(aData);

        }



        public IActionResult Index_ok()
        {
            ViewBag.SubstationCount = _context.TblSubstation.Count();

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
