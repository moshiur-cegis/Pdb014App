using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Extensions;

using Pdb014App.Repository;
using Pdb014App.Models.PDB;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Models.PDB.DistributionTransformerModel;
using Pdb014App.Models.PDB.PhasePowerTransformerModel;
using Pdb014App.Models.Report;


namespace Pdb014App.Controllers.SummaryReport
{
    public partial class SummaryReportController : Controller
    {
        private readonly PdbDbContext _context;

        public SummaryReportController(PdbDbContext context)
        {
            _context = context;
        }


        public IActionResult SummaryReport([FromQuery] string cai, string regionLevel)
        {
            var regionInfo = new List<ReportField>
                {
                    new ReportField {Name = "zone", Title = "Zone"},
                    new ReportField {Name = "circle", Title = "Circle"},
                    new ReportField {Name = "snd", Title = "S&D"},
                    new ReportField {Name = "substation", Title = "Substation"},
                };

            var fieldList = new List<ReportField>(13)
                {
                    new ReportField {Name = "totalCount", Title = "Total Pole", Selected = true},
                    //new ReportField {Name = "total33Count", Title = "33KV Pole", Selected = true},
                    //new ReportField {Name = "total11Count", Title = "11KV Pole", Selected = true},
                    ////new ReportField {Name = "totalP4Count", Title = ".4KV Pole", Selected = true},

                    new ReportField {Name = "groupPoleType", Title = "Pole Type", Selected = true},
                    new ReportField {Name = "totalSpcCount", Title = "SPC", Selected = true, Visible = false, GroupName = "groupPoleType"},
                    new ReportField {Name = "totalSpCount", Title = "SP", Selected = true, Visible = false, GroupName = "groupPoleType"},
                    new ReportField {Name = "totalTowerCount", Title = "Tower", Selected = true, Visible = false, GroupName = "groupPoleType"},
                    new ReportField {Name = "totalOthersCount", Title = "Others", Selected = true, Visible = false, GroupName = "groupPoleType"},

                    //new ReportField {Name = "totalSpcCount", Title = "SPC Pole", Selected = true},
                    //new ReportField {Name = "totalSpCount", Title = "SP Pole", Selected = true},
                    //new ReportField {Name = "totalOthersCount", Title = "Others Pole", Selected = true},

                    new ReportField {Name = "groupPoleCondition", Title = "Pole Condition", Selected = true},
                    new ReportField {Name = "totalAgedCount", Title = "Aged", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                    new ReportField {Name = "totalBadCount", Title = "Bad", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                    new ReportField {Name = "totalBrokenCount", Title = "Broken", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                    new ReportField {Name = "totalGoodCount", Title = "Good", Selected = true, Visible = false, GroupName = "groupPoleCondition"},

                    //new ReportField {Name = "totalAgedCount", Title = "Aged Pole", Selected = true},
                    //new ReportField {Name = "totalBadCount", Title = "Bad Pole", Selected = true},
                    //new ReportField {Name = "totalBrokenCount", Title = "Broken Pole", Selected = true},
                    //new ReportField {Name = "totalGoodCount", Title = "Good Pole", Selected = true},

                    new ReportField {Name = "totalNeutralPole", Title = "Has Neutral Cable", Selected = true},
                    new ReportField {Name = "totalStreetLight", Title = "Has Street Light", Selected = true},

                    new ReportField {Name = "totalWireLength", Title = "Wire Length (Km)", Selected = true},

                    //new ReportField {Name = "total33FeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                    //new ReportField {Name = "total11FeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
                };

            ViewBag.ReportName = "Summary";
            ViewBag.ReportAction = "GetSummaryData";
            ViewBag.ReportController = "SummaryReport";

            ViewBag.BasicColumns = "zoneName=>Zone Name;isCity=>City/Except City;circleName=>Circle Name;distName=>District Name;sndName=>S&D Name;";

            var regionList = new List<string>(4);

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("~/Views/AdvancedReport/SummaryReport.cshtml");
            //return View("SummaryReport");
        }

        [HttpPost]
        public IActionResult SummaryReport([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
        {
            var regionInfo = new List<ReportField>
                {
                    new ReportField {Name = "zone", Title = "Zone"},
                    new ReportField {Name = "circle", Title = "Circle"},
                    new ReportField {Name = "snd", Title = "S&D"},
                    new ReportField {Name = "substation", Title = "Substation"},
                };

            if (fieldList == null || fieldList.Count < 1)
            {
                fieldList = new List<ReportField>(13)
                    {
                    new ReportField {Name = "totalCount", Title = "Total Pole", Selected = true},
                    //new ReportField {Name = "total33Count", Title = "33KV Pole", Selected = true},
                    //new ReportField {Name = "total11Count", Title = "11KV Pole", Selected = true},
                    ////new ReportField {Name = "totalP4Count", Title = ".4KV Pole", Selected = true},

                    new ReportField {Name = "groupPoleType", Title = "Pole Type", Selected = true},
                    new ReportField {Name = "totalSpcCount", Title = "SPC", Selected = true, Visible = false, GroupName = "groupPoleType"},
                    new ReportField {Name = "totalSpCount", Title = "SP", Selected = true, Visible = false, GroupName = "groupPoleType"},
                    new ReportField {Name = "totalTowerCount", Title = "Tower", Selected = true, Visible = false, GroupName = "groupPoleType"},
                    new ReportField {Name = "totalOthersCount", Title = "Others", Selected = true, Visible = false, GroupName = "groupPoleType"},

                    //new ReportField {Name = "totalSpcCount", Title = "SPC Pole", Selected = true},
                    //new ReportField {Name = "totalSpCount", Title = "SP Pole", Selected = true},
                    //new ReportField {Name = "totalOthersCount", Title = "Others Pole", Selected = true},

                    new ReportField {Name = "groupPoleCondition", Title = "Pole Condition", Selected = true},
                    new ReportField {Name = "totalAgedCount", Title = "Aged", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                    new ReportField {Name = "totalBadCount", Title = "Bad", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                    new ReportField {Name = "totalBrokenCount", Title = "Broken", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                    new ReportField {Name = "totalGoodCount", Title = "Good", Selected = true, Visible = false, GroupName = "groupPoleCondition"},

                    //new ReportField {Name = "totalAgedCount", Title = "Aged Pole", Selected = true},
                    //new ReportField {Name = "totalBadCount", Title = "Bad Pole", Selected = true},
                    //new ReportField {Name = "totalBrokenCount", Title = "Broken Pole", Selected = true},
                    //new ReportField {Name = "totalGoodCount", Title = "Good Pole", Selected = true},

                    new ReportField {Name = "totalNeutralPole", Title = "Has Neutral Cable", Selected = true},
                    new ReportField {Name = "totalStreetLight", Title = "Has Street Light", Selected = true},

                    new ReportField {Name = "totalWireLength", Title = "Wire Length (Km)", Selected = true},

                    //new ReportField {Name = "total33FeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                    //new ReportField {Name = "total11FeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
                    };
            }


            ViewBag.ReportName = "Summary";
            ViewBag.ReportAction = "GetSummaryData";
            ViewBag.ReportController = "SummaryReport";

            ViewBag.BasicColumns = "zoneName=>Zone Name;isCity=>City/Except City;circleName=>Circle Name;distName=>District Name;sndName=>S&D Name;";

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionInfo = regionInfo;
            ViewBag.RegionLevel = regionLevel;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList.Count > 0)
            {
                zoneCode = regionList[0];

                if (regionList.Count > 1)
                {
                    circleCode = regionList[1];

                    if (regionList.Count > 2)
                    {
                        snDCode = regionList[2];

                        if (regionList.Count > 3)
                        {
                            substationCode = regionList[3];
                        }
                    }
                }
            }

            ViewBag.ZoneCode = zoneCode;
            ViewBag.CircleCode = circleCode;
            ViewBag.SnDCode = snDCode;
            ViewBag.SubstationCode = substationCode;
            ViewBag.RouteCode = routeCode;


            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode).ToList(), "ZoneCode",
                "ZoneName");

            if (!string.IsNullOrEmpty(zoneCode))
            {
                ViewData["CircleList"] = new SelectList(_context.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName");

                if (!string.IsNullOrEmpty(circleCode))
                {
                    ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName");
                }
                else
                {
                    ViewData["SnDList"] = ViewData["SubstationList"] = null;
                }
            }
            else
            {
                ViewData["CircleList"] = ViewData["SnDList"] = ViewData["SubstationList"] = null;
            }

            return View("~/Views/AdvancedReport/SummaryReport.cshtml");
            //return View("SummaryReport");
        }

    }


    public partial class SummaryReportController
    {

        #region Summary-Substation

        public IActionResult Substation([FromQuery] string cai)
        {
            var fieldList = new List<ReportField>(22)
            {
                //new ReportField {Name = "substationCode", Title = "Substation Code", Selected = true, Visible = false},

                new ReportField {Name = "groupInLineFeeder33kIn", Title = "Incoming Line (33kV)", Selected = true},
                new ReportField {Name = "f33kInInfo.name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},

                new ReportField {Name = "groupSubstation", Title = "Substation", Selected = true},
                new ReportField {Name = "substation.name", Title = "Name of Substation", GroupName = "groupSubstation", Selected = true, Visible = false},
                new ReportField {Name = "substation.capacity", Title = "Capacity (MVA)", GroupName = "groupSubstation", Selected = true, Visible = false},

                new ReportField {Name = "groupInLineFeeder33kOut", Title = "Outgoing Line (33kV)", Selected = true},
                new ReportField {Name = "f33kOutInfo.name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},

                new ReportField {Name = "groupInTableFeeder11k", Title = "Feeder Line (11kV)", Selected = true},
                new ReportField {Name = "f11kInfo.name", Title = "Feeder Name", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.type", Title = "Conductor Type", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.length", Title = "Length (Km)", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
            };


            ViewBag.ReportName = "Substation";
            ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "SummaryReport";

            var regionList = new List<string>(4);

            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("~/Views/AdvancedReport/SummaryReport.cshtml");
            //return View("~/Views/AdvancedReport/SummaryReport");
            //return View("SummaryReport");
            //return View("Substation");
        }

        [HttpPost]
        public IActionResult Substation([FromQuery] string cai, List<ReportField> fieldList, List<string> regionList)
        {
            if (fieldList == null || fieldList.Count < 1)
            {
                fieldList = new List<ReportField>(22)
                {
                    //new ReportField {Name = "substationCode", Title = "Substation Code", Selected = true, Visible = false},

                    new ReportField {Name = "groupInLineFeeder33kIn", Title = "Incoming Line (33kV)", Selected = true},
                    new ReportField {Name = "f33kInInfo.name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                    new ReportField {Name = "f33kInInfo.type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                    new ReportField {Name = "f33kInInfo.length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},

                    new ReportField {Name = "groupSubstation", Title = "Substation", Selected = true},
                    new ReportField {Name = "substation.name", Title = "Name of Substation", GroupName = "groupSubstation", Selected = true, Visible = false},
                    new ReportField {Name = "substation.capacity", Title = "Capacity (MVA)", GroupName = "groupSubstation", Selected = true, Visible = false},

                    new ReportField {Name = "groupInLineFeeder33kOut", Title = "Outgoing Line (33kV)", Selected = true},
                    new ReportField {Name = "f33kOutInfo.name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                    new ReportField {Name = "f33kOutInfo.type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                    new ReportField {Name = "f33kOutInfo.length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},

                    new ReportField {Name = "groupInTableFeeder11k", Title = "Feeder Line (11kV)", Selected = true},
                    new ReportField {Name = "f11kInfo.name", Title = "Feeder Name", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                    new ReportField {Name = "f11kInfo.type", Title = "Conductor Type", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                    new ReportField {Name = "f11kInfo.length", Title = "Length (Km)", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                };
            }

            ViewBag.ReportName = "Substation";
            ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "SummaryReport";

            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList.Count > 0)
            {
                zoneCode = regionList[0];

                if (regionList.Count > 1)
                {
                    circleCode = regionList[1];

                    if (regionList.Count > 2)
                    {
                        snDCode = regionList[2];

                        if (regionList.Count > 3)
                        {
                            substationCode = regionList[3];
                        }
                    }
                }
            }

            ViewBag.ZoneCode = zoneCode;
            ViewBag.CircleCode = circleCode;
            ViewBag.SnDCode = snDCode;
            ViewBag.SubstationCode = substationCode;
            ViewBag.RouteCode = routeCode;


            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode).ToList(), "ZoneCode",
                "ZoneName");

            if (!string.IsNullOrEmpty(zoneCode))
            {
                ViewData["CircleList"] = new SelectList(_context.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName");

                if (!string.IsNullOrEmpty(circleCode))
                {
                    ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName");


                    if (!string.IsNullOrEmpty(snDCode))
                    {
                        ViewData["SubstationList"] = new SelectList(_context.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
                    }
                    else
                    {
                        ViewData["SubstationList"] = null;
                    }
                }
                else
                {
                    ViewData["SnDList"] = ViewData["SubstationList"] = null;
                }
            }
            else
            {
                ViewData["CircleList"] = ViewData["SnDList"] = ViewData["SubstationList"] = null;
            }

            return View("~/Views/AdvancedReport/SummaryReport.cshtml");
            //return View("SummaryReport");
            //return View("Substation");
        }

        [HttpPost]
        public JsonResult GetSubstationData(List<string> regionList = null)
        {
            Expression<Func<TblFeederLine, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode;

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblFeederLine, bool>> tempExp = model =>
                        model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.FeederLineToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.FeederLineToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);
                        }
                    }
                }
            }

            var qry = searchExp != null
                ? _context.TblFeederLine
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblFeederLine
                    .AsNoTracking();

            object data = qry
                .Include(pl => pl.Poles)
                .Include(di => di.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .GroupBy(i => i.FeederLineToRoute.SubstationId)
                .Select(k => new
                {
                    zoneName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                    circleName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.CircleName,
                    isCity = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.IsInCity != null
                             && k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.IsInCity == 1 ? "City" : "Except City",
                    ////isCity = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.IsInCity == 1,
                    distName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict.DistrictName,
                    sndName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,
                    substationCode = k.Key,
                    substation = new
                    {
                        name = k.First().FeederLineToRoute.RouteToSubstation.SubstationName,
                        capacity = k.First().FeederLineToRoute.RouteToSubstation.InstalledCapacity
                    },

                    //substationName = k.First().FeederLineToRoute.RouteToSubstation.SubstationName,

                    //substationCapacity = k.First().FeederLineToRoute.RouteToSubstation.InstalledCapacity,
                    ////k.Sum(d => d.TotalCapacity.Min) + "/" + k.Sum(d => d.TotalCapacity.Max),

                    //totalFeederCount = k.Count(),
                    //total11kFeederCount = k.Count(d => d.NominalVoltage == 11),
                    //total33kFeederCount = k.Count(d => d.NominalVoltage == 33),

                    //totalFeederLength = Math.Round(k.Sum(d => d.FeederLength) / 1000, 0),
                    //total33kFeederLength = Math.Round(k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength) / 1000, 0),
                    //total11kFeederLength = Math.Round(k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength) / 1000, 0),

                    f11kInfo = k.Where(d => d.NominalVoltage == 11)
                        .Select(f => new
                        {
                            length = Math.Round(f.FeederLength / 1000, 0),
                            type = f.FeederLineType.FeederLineTypeName,
                            name = f.FeederName
                        }).ToList(),

                    f33kInInfo = k.Where(d => d.NominalVoltage == 11)
                        .Select(f => new
                        {
                            length = Math.Round(f.FeederLength / 1000, 0),
                            type = f.FeederLineType.FeederLineTypeName,
                            name = f.FeederName
                        }).ToList(),

                    f33kOutInfo = k.Where(d => d.NominalVoltage == 33)
                        .Select(f => new
                        {
                            length = Math.Round(f.FeederLength / 1000, 0),
                            type = f.FeederLineType.FeederLineTypeName,
                            name = f.FeederName
                        }).ToList(),

                }).ToList();

            return Json(data);
        }


        #endregion







        public IActionResult SubstationBk([FromQuery] string cai, string regionLevel)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };

            var fieldList = new List<ReportField>(22)
            {
                //new ReportField {Name = "totalCount", Title = "Total Substation", Selected = true},
                //new ReportField {Name = "total11Count", Title = "33/11 kV Substation", Selected = true},
                //new ReportField {Name = "total33Count", Title = "132/33 kV Substation", Selected = true},
                //new ReportField {Name = "totalDemand", Title = "Demand (Max) (MW)", Selected = true},
                //new ReportField {Name = "totalPeakLoad", Title = "Peak Load (MW)", Selected = true},
                //new ReportField {Name = "maxPeakLoad", Title = "Max Peak Load (MW)", Selected = true},
                //new ReportField {Name = "minPeakLoad", Title = "Min Peak Load (MW)", Selected = true}


                //new ReportField {Name = "totalFeederCount", Title = "Total Feeder", Selected = true},
                //new ReportField {Name = "total11kFeederCount", Title = "33/11 kV Feeder", Selected = true},
                //new ReportField {Name = "total33kFeederCount", Title = "132/33 kV Feeder", Selected = true},

                //new ReportField {Name = "totalFeederLength", Title = "Total Feeder Length", Selected = true},
                //new ReportField {Name = "total33kFeederLength", Title = "33/11 kV Feeder Length", Selected = true},
                //new ReportField {Name = "total33kFeederLength", Title = "132/33 kV Feeder Length", Selected = true},


                new ReportField {Name = "groupFeeder33kIn", Title = "Incoming Line (33kV)", Selected = true},
                new ReportField {Name = "f33kInInfo.name", Title = "Feeder Name", GroupName = "groupFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.type", Title = "Conductor Type", GroupName = "groupFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.length", Title = "Length (Km)", GroupName = "groupFeeder33kIn", Selected = true, Visible = false},


                new ReportField {Name = "groupSubstation", Title = "Substation", Selected = true},
                new ReportField {Name = "substationName", Title = "Name of Substation", GroupName = "groupSubstation", Selected = true, Visible = false},
                new ReportField {Name = "substationCapacity", Title = "Capacity (MVA)", GroupName = "groupSubstation", Selected = true, Visible = false},


                new ReportField {Name = "groupFeeder33kOut", Title = "Outgoing Line (33kV)", Selected = true},
                new ReportField {Name = "f33kOutInfo.name", Title = "Feeder Name", GroupName = "groupFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.type", Title = "Conductor Type", GroupName = "groupFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.length", Title = "Length (Km)", GroupName = "groupFeeder33kOut", Selected = true, Visible = false},

                new ReportField {Name = "groupFeeder11k", Title = "Feeder Line (11kV)", Selected = true},
                new ReportField {Name = "f11kInfo.name", Title = "Feeder Name", GroupName = "groupFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.type", Title = "Conductor Type", GroupName = "groupFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.length", Title = "Length (Km)", GroupName = "groupFeeder11k", Selected = true, Visible = false},

            };


            ViewBag.ReportName = "Substation";
            ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "SummaryReport";

            var regionList = new List<string>(5);


            regionLevel = regionLevel ?? "substation";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("~/Views/AdvancedReport/SummaryReport.cshtml");
            //return View("~/Views/AdvancedReport/SummaryReport");
            //return View("SummaryReport");
            //return View("Substation");
        }

        [HttpPost]
        public IActionResult SubstationBk([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };

            if (fieldList == null || fieldList.Count < 1)
            {
                fieldList = new List<ReportField>(22)
                {

                //new ReportField {Name = "totalFeederCount", Title = "Total Feeder", Selected = true},
                //new ReportField {Name = "total11kFeederCount", Title = "33/11 kV Feeder", Selected = true},
                //new ReportField {Name = "total33kFeederCount", Title = "132/33 kV Feeder", Selected = true},

                //new ReportField {Name = "totalFeederLength", Title = "Total Feeder Length", Selected = true},
                //new ReportField {Name = "total33kFeederLength", Title = "33/11 kV Feeder Length", Selected = true},
                //new ReportField {Name = "total33kFeederLength", Title = "132/33 kV Feeder Length", Selected = true},


                new ReportField {Name = "groupFeeder33kIn", Title = "Incoming Line (33kV)", Selected = true},
                new ReportField {Name = "f33kInInfo.name", Title = "Feeder Name", GroupName = "groupFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.type", Title = "Conductor Type", GroupName = "groupFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.length", Title = "Length (Km)", GroupName = "groupFeeder33kIn", Selected = true, Visible = false},


                new ReportField {Name = "groupSubstation", Title = "Substation", Selected = true},
                new ReportField {Name = "substationName", Title = "Name of Substation", GroupName = "groupSubstation", Selected = true, Visible = false},
                new ReportField {Name = "substationCapacity", Title = "Capacity (MVA)", GroupName = "groupSubstation", Selected = true, Visible = false},


                new ReportField {Name = "groupFeeder33kOut", Title = "Outgoing Line (33kV)", Selected = true},
                new ReportField {Name = "f33kOutInfo.name", Title = "Feeder Name", GroupName = "groupFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.type", Title = "Conductor Type", GroupName = "groupFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.length", Title = "Length (Km)", GroupName = "groupFeeder33kOut", Selected = true, Visible = false},

                new ReportField {Name = "groupFeeder11k", Title = "Feeder Line (11kV)", Selected = true},
                new ReportField {Name = "f11kInfo.name", Title = "Feeder Name", GroupName = "groupFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.type", Title = "Conductor Type", GroupName = "groupFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.length", Title = "Length (Km)", GroupName = "groupFeeder11k", Selected = true, Visible = false},

                };
            }

            ViewBag.ReportName = "Substation";
            ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "SummaryReport";

            regionLevel = regionLevel ?? "substation";

            ViewBag.RegionInfo = regionInfo;
            ViewBag.RegionLevel = regionLevel;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList.Count > 0)
            {
                zoneCode = regionList[0];

                if (regionList.Count > 1)
                {
                    circleCode = regionList[1];

                    if (regionList.Count > 2)
                    {
                        snDCode = regionList[2];

                        if (regionList.Count > 3)
                        {
                            substationCode = regionList[3];

                            if (regionList.Count > 4)
                            {
                                routeCode = regionList[4];
                            }
                        }
                    }
                }
            }

            ViewBag.ZoneCode = zoneCode;
            ViewBag.CircleCode = circleCode;
            ViewBag.SnDCode = snDCode;
            ViewBag.SubstationCode = substationCode;
            ViewBag.RouteCode = routeCode;


            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode).ToList(), "ZoneCode",
                "ZoneName");

            if (!string.IsNullOrEmpty(zoneCode))
            {
                ViewData["CircleList"] = new SelectList(_context.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName");

                if (!string.IsNullOrEmpty(circleCode))
                {
                    ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName");


                    if (!string.IsNullOrEmpty(snDCode))
                    {
                        ViewData["SubstationList"] = new SelectList(_context.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
                    }
                    else
                    {
                        ViewData["SubstationList"] = null;
                    }
                }
                else
                {
                    ViewData["SnDList"] = ViewData["SubstationList"] = null;
                }
            }
            else
            {
                ViewData["CircleList"] = ViewData["SnDList"] = ViewData["SubstationList"] = null;
            }

            return View("~/Views/AdvancedReport/SummaryReport.cshtml");
            //return View("SummaryReport");
            //return View("Substation");
        }

        [HttpPost]
        public JsonResult GetSubstationDataPreBk(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "substation" : regionLevel;

            Expression<Func<TblSubstation, bool>> searchExp = null;

            //searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model => model.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblSubstation, bool>> tempExp = model =>
                        model.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4)
                            {
                                routeCode = regionList[4];
                                //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                                //tempExp = model => model. == substationCode;
                                //searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                            }
                        }
                    }
                }
            }


            var qry = searchExp != null
                ? _context.TblSubstation
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblSubstation
                    .AsNoTracking();

            if (qry == null || !qry.Any())
                return Json(null);


            object data = null;

            switch (regionLevel)
            {
                case "zone":
                    data = qry
                        .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            totalCount = k.Count(),
                            total11Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/11")),
                            total33Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/33")),
                            totalCapacity = k.Sum(d => d.TotalCapacity.Min) + "/" + k.Sum(d => d.TotalCapacity.Max),
                            totalDemand = k.Sum(d => d.MaximumDemand),
                            totalPeakLoad = k.Sum(d => d.PeakLoad),
                            maxPeakLoad = k.Max(d => d.PeakLoad),
                            minPeakLoad = k.Min(d => d.PeakLoad)
                        }).ToList();
                    break;

                case "circle":
                    data = qry
                        .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            zoneName = k.First().SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleCode = k.Key,
                            circleName = k.First().SubstationToLookUpSnD.CircleInfo.CircleName,
                            totalCount = k.Count(),
                            total11Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/11")),
                            total33Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/33")),
                            totalCapacity = k.Sum(d => d.TotalCapacity.Min) + "/" + k.Sum(d => d.TotalCapacity.Max),
                            totalDemand = k.Sum(d => d.MaximumDemand),
                            totalPeakLoad = k.Sum(d => d.PeakLoad),
                            maxPeakLoad = k.Max(d => d.PeakLoad),
                            minPeakLoad = k.Min(d => d.PeakLoad)
                        })
                        .ToList();
                    break;

                case "snd":
                    data = qry
                        .Include(st => st.SubstationToLookUpSnD)
                        .Include(st => st.SubstationToLookUpSnD.CircleInfo)
                        .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.SnDCode)
                        .Select(k => new
                        {
                            zoneName = k.First().SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = k.First().SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndCode = k.Key,
                            sndName = k.First().SubstationToLookUpSnD.SnDName,
                            totalCount = k.Count(),
                            total11Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/11")),
                            total33Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/33")),
                            totalCapacity = k.Sum(d => d.TotalCapacity.Min) + "/" + k.Sum(d => d.TotalCapacity.Max),
                            totalDemand = k.Sum(d => d.MaximumDemand),
                            totalPeakLoad = k.Sum(d => d.PeakLoad),
                            maxPeakLoad = k.Max(d => d.PeakLoad),
                            minPeakLoad = k.Min(d => d.PeakLoad)
                        }).ToList();
                    break;

                case "substation":
                    data = qry
                        .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.SubstationId)
                        .Select(k => new
                        {
                            zoneName = k.First().SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = k.First().SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndName = k.First().SubstationToLookUpSnD.SnDName,
                            substationCode = k.Key,
                            substationName = k.First().SubstationName,
                            totalCount = k.Count(),
                            total11Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/11")),
                            total33Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/33")),
                            totalCapacity = k.Sum(d => d.TotalCapacity.Min) + "/" + k.Sum(d => d.TotalCapacity.Max),
                            totalDemand = k.Sum(d => d.MaximumDemand),
                            totalPeakLoad = k.Sum(d => d.PeakLoad),
                            maxPeakLoad = k.Max(d => d.PeakLoad),
                            minPeakLoad = k.Min(d => d.PeakLoad)
                        }).ToList();
                    break;

                default:
                    data = qry
                        .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            totalCount = k.Count(),
                            total11Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/11")),
                            total33Count = k.Count(d => d.SubstationType.SubstationTypeName.Contains("/33")),
                            totalCapacity = k.Sum(d => d.TotalCapacity.Min) + "/" + k.Sum(d => d.TotalCapacity.Max),
                            totalDemand = k.Sum(d => d.MaximumDemand),
                            totalPeakLoad = k.Sum(d => d.PeakLoad),
                            maxPeakLoad = k.Max(d => d.PeakLoad),
                            minPeakLoad = k.Min(d => d.PeakLoad)
                        }).ToList();
                    break;
            }

            return Json(data);
        }


        [HttpPost]
        public JsonResult GetSubstationDataBk(string regionLevel = "substation", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "substation" : regionLevel;

            Expression<Func<TblFeederLine, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode;

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblFeederLine, bool>> tempExp = model =>
                        model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.FeederLineToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.FeederLineToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4)
                            {
                                //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                                //tempExp = model => model. == substationCode;
                                //searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);
                            }
                        }
                    }
                }
            }

            var qry = searchExp != null
                ? _context.TblFeederLine
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblFeederLine
                    .AsNoTracking();

            qry = qry.Include(fl => fl.Poles);

            object data;

            switch (regionLevel)
            {

                case "substation":
                    data = qry
                        .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.FeederLineToRoute.SubstationId)
                        .Select(k => new
                        {
                            zoneName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,
                            substationCode = k.Key,
                            substationName = k.First().FeederLineToRoute.RouteToSubstation.SubstationName,

                            substationCapacity = k.First().FeederLineToRoute.RouteToSubstation.InstalledCapacity,
                            //k.Sum(d => d.TotalCapacity.Min) + "/" + k.Sum(d => d.TotalCapacity.Max),

                            totalFeederCount = k.Count(),
                            total11kFeederCount = k.Count(d => d.NominalVoltage == 11),
                            total33kFeederCount = k.Count(d => d.NominalVoltage == 33),

                            totalFeederLength = Math.Round(k.Sum(d => d.FeederLength) / 1000, 0),
                            total33kFeederLength =
                                Math.Round(k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength) / 1000, 0),
                            total11kFeederLength =
                                Math.Round(k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength) / 1000, 0),

                            f11kInfo = k.Where(d => d.NominalVoltage == 11)
                                .Select(f => new
                                {
                                    length = Math.Round(f.FeederLength / 1000, 0),
                                    type = f.FeederLineType.FeederLineTypeName,
                                    name = f.FeederName
                                }).ToList(),

                            f33kInInfo = k.Where(d => d.NominalVoltage == 11)
                                .Select(f => new
                                {
                                    length = Math.Round(f.FeederLength / 1000, 0),
                                    type = f.FeederLineType.FeederLineTypeName,
                                    name = f.FeederName
                                }).ToList(),

                            f33kOutInfo = k.Where(d => d.NominalVoltage == 33)
                                .Select(f => new
                                {
                                    length = Math.Round(f.FeederLength / 1000, 0),
                                    type = f.FeederLineType.FeederLineTypeName,
                                    name = f.FeederName
                                }).ToList(),

                        }).ToList();
                    break;

                default:
                    data = qry
                        .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.FeederLineToRoute.SubstationId)
                        .Select(k => new
                        {
                            zoneName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,
                            substationCode = k.Key,
                            substationName = k.First().FeederLineToRoute.RouteToSubstation.SubstationName,

                            substationCapacity = k.First().FeederLineToRoute.RouteToSubstation.InstalledCapacity,
                            //k.Sum(d => d.TotalCapacity.Min) + "/" + k.Sum(d => d.TotalCapacity.Max),

                            totalFeederCount = k.Count(),
                            total11kFeederCount = k.Count(d => d.NominalVoltage == 11),
                            total33kFeederCount = k.Count(d => d.NominalVoltage == 33),

                            totalFeederLength = Math.Round(k.Sum(d => d.FeederLength) / 1000, 0),
                            total33kFeederLength =
                                Math.Round(k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength) / 1000, 0),
                            total11kFeederLength =
                                Math.Round(k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength) / 1000, 0),

                            f11kInfo = k.Where(d => d.NominalVoltage == 11)
                                .Select(f => new
                                {
                                    length = Math.Round(f.FeederLength / 1000, 0),
                                    type = f.FeederLineType.FeederLineTypeName,
                                    name = f.FeederName
                                }).ToList(),

                            f33kInInfo = k.Where(d => d.NominalVoltage == 11)
                                .Select(f => new
                                {
                                    length = Math.Round(f.FeederLength / 1000, 0),
                                    type = f.FeederLineType.FeederLineTypeName,
                                    name = f.FeederName
                                }).ToList(),

                            f33kOutInfo = k.Where(d => d.NominalVoltage == 33)
                                .Select(f => new
                                {
                                    length = Math.Round(f.FeederLength / 1000, 0),
                                    type = f.FeederLineType.FeederLineTypeName,
                                    name = f.FeederName
                                }).ToList(),

                        }).ToList();
                    break;
            }

            return Json(data);
        }


    }

}