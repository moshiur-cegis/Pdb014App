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


namespace Pdb014App.Controllers.AdvancedReport
{
    public partial class AdvancedReportController : Controller
    {
        private readonly PdbDbContext _context;

        public AdvancedReportController(PdbDbContext context)
        {
            _context = context;
        }


        public IActionResult AdvancedReport([FromQuery] string cai, string regionLevel)
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

            ViewBag.ReportName = "Advanced";
            ViewBag.ReportAction = "GetAdvancedData";
            ViewBag.ReportController = "AdvancedReport";

            var regionList = new List<string>(5);

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("AdvancedReport");
        }

        [HttpPost]
        public IActionResult AdvancedReport([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
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


            ViewBag.ReportName = "Advanced";
            ViewBag.ReportAction = "GetAdvancedData";
            ViewBag.ReportController = "AdvancedReport";

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

                    //if (!string.IsNullOrEmpty(snDCode))
                    //{
                    //    ViewData["PoleList"] = new SelectList(_context.TblPole
                    //        //.Where(ss => ss.PoleId..SnDCode.Equals(snDCode))
                    //        .Select(ss => new { ss.SubstationId, ss.SubstationName })
                    //        .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
                    //}
                    //else
                    //{
                    //    ViewData["SubstationList"] = null;
                    //}
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


            return View("AdvancedReport");
        }

    }


    public partial class AdvancedReportController
    {

        #region PoleAdvancedReport

        //public IActionResult Pole([FromQuery] string cai, string regionLevel)
        //{
        //    var regionInfo = new List<ReportField>
        //    {
        //        new ReportField {Name = "zone", Title = "Zone"},
        //        new ReportField {Name = "circle", Title = "Circle"},
        //        new ReportField {Name = "snd", Title = "S&D"},
        //        new ReportField {Name = "substation", Title = "Substation"},
        //    };


        //    var fieldList = new List<ReportField>(13)
        //    {
        //        new ReportField {Name = "totalCount", Title = "Total Pole", Selected = true},
        //        //new ReportField {Name = "total33Count", Title = "33KV Pole", Selected = true},
        //        //new ReportField {Name = "total11Count", Title = "11KV Pole", Selected = true},
        //        ////new ReportField {Name = "totalP4Count", Title = ".4KV Pole", Selected = true},
                
        //        new ReportField {Name = "groupPoleType", Title = "Pole Type", Selected = true},
        //        new ReportField {Name = "totalSpcCount", Title = "SPC", Selected = true, Visible = false, GroupName = "groupPoleType"},
        //        new ReportField {Name = "totalSpCount", Title = "SP", Selected = true, Visible = false, GroupName = "groupPoleType"},
        //        new ReportField {Name = "totalTowerCount", Title = "Tower", Selected = true, Visible = false, GroupName = "groupPoleType"},
        //        new ReportField {Name = "totalOthersCount", Title = "Others", Selected = true, Visible = false, GroupName = "groupPoleType"},

        //        new ReportField {Name = "groupPoleCondition", Title = "Pole Condition", Selected = true},
        //        new ReportField {Name = "totalAgedCount", Title = "Aged", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
        //        new ReportField {Name = "totalBadCount", Title = "Bad", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
        //        new ReportField {Name = "totalBrokenCount", Title = "Broken", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
        //        new ReportField {Name = "totalGoodCount", Title = "Good", Selected = true, Visible = false, GroupName = "groupPoleCondition"},

        //        //new ReportField {Name = "totalAgedCount", Title = "Aged Pole", Selected = true},
        //        //new ReportField {Name = "totalBadCount", Title = "Bad Pole", Selected = true},
        //        //new ReportField {Name = "totalBrokenCount", Title = "Broken Pole", Selected = true},
        //        //new ReportField {Name = "totalGoodCount", Title = "Good Pole", Selected = true},

        //        new ReportField {Name = "totalNeutralPole", Title = "Has Neutral Cable", Selected = true},
        //        new ReportField {Name = "totalStreetLight", Title = "Has Street Light", Selected = true},

        //        new ReportField {Name = "totalWireLength", Title = "Wire Length (Km)", Selected = true},

        //        //new ReportField {Name = "total33FeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
        //        //new ReportField {Name = "total11FeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
        //    };


        //    ViewBag.ReportName = "Pole";
        //    ViewBag.ReportAction = "GetPoleData";
        //    ViewBag.ReportController = "AdvancedReport";

        //    var regionList = new List<string>(5);

        //    regionLevel = regionLevel ?? "zone";

        //    ViewBag.RegionLevel = regionLevel;
        //    ViewBag.RegionInfo = regionInfo;
        //    ViewBag.FieldList = fieldList;
        //    ViewBag.RegionList = regionList;

        //    ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

        //    return View("AdvancedReport");
        //    //return View("Pole");
        //}

        [HttpPost]
        //public IActionResult Pole([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
        //{
        //    var regionInfo = new List<ReportField>
        //    {
        //        new ReportField {Name = "zone", Title = "Zone"},
        //        new ReportField {Name = "circle", Title = "Circle"},
        //        new ReportField {Name = "snd", Title = "S&D"},
        //        new ReportField {Name = "substation", Title = "Substation"},
        //    };


        //    if (fieldList == null || fieldList.Count < 1)
        //    {
        //        fieldList = new List<ReportField>(13)
        //        {
        //        new ReportField {Name = "totalCount", Title = "Total Pole", Selected = true},
        //        //new ReportField {Name = "total33Count", Title = "33KV Pole", Selected = true},
        //        //new ReportField {Name = "total11Count", Title = "11KV Pole", Selected = true},
        //        ////new ReportField {Name = "totalP4Count", Title = ".4KV Pole", Selected = true},
                
        //        new ReportField {Name = "groupPoleType", Title = "Pole Type", Selected = true},
        //        new ReportField {Name = "totalSpcCount", Title = "SPC", Selected = true, Visible = false, GroupName = "groupPoleType"},
        //        new ReportField {Name = "totalSpCount", Title = "SP", Selected = true, Visible = false, GroupName = "groupPoleType"},
        //        new ReportField {Name = "totalTowerCount", Title = "Tower", Selected = true, Visible = false, GroupName = "groupPoleType"},
        //        new ReportField {Name = "totalOthersCount", Title = "Others", Selected = true, Visible = false, GroupName = "groupPoleType"},

        //        //new ReportField {Name = "totalSpcCount", Title = "SPC Pole", Selected = true},
        //        //new ReportField {Name = "totalSpCount", Title = "SP Pole", Selected = true},
        //        //new ReportField {Name = "totalOthersCount", Title = "Others Pole", Selected = true},

        //        new ReportField {Name = "groupPoleCondition", Title = "Pole Condition", Selected = true},
        //        new ReportField {Name = "totalAgedCount", Title = "Aged", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
        //        new ReportField {Name = "totalBadCount", Title = "Bad", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
        //        new ReportField {Name = "totalBrokenCount", Title = "Broken", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
        //        new ReportField {Name = "totalGoodCount", Title = "Good", Selected = true, Visible = false, GroupName = "groupPoleCondition"},

        //        //new ReportField {Name = "totalAgedCount", Title = "Aged Pole", Selected = true},
        //        //new ReportField {Name = "totalBadCount", Title = "Bad Pole", Selected = true},
        //        //new ReportField {Name = "totalBrokenCount", Title = "Broken Pole", Selected = true},
        //        //new ReportField {Name = "totalGoodCount", Title = "Good Pole", Selected = true},

        //        new ReportField {Name = "totalNeutralPole", Title = "Has Neutral Cable", Selected = true},
        //        new ReportField {Name = "totalStreetLight", Title = "Has Street Light", Selected = true},

        //        new ReportField {Name = "totalWireLength", Title = "Wire Length (Km)", Selected = true},

        //        //new ReportField {Name = "total33FeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
        //        //new ReportField {Name = "total11FeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
        //        };
        //    }

        //    ViewBag.ReportName = "Pole";
        //    ViewBag.ReportAction = "GetPoleData";
        //    ViewBag.ReportController = "AdvancedReport";

        //    regionLevel = regionLevel ?? "zone";

        //    ViewBag.RegionInfo = regionInfo;
        //    ViewBag.RegionLevel = regionLevel;
        //    ViewBag.FieldList = fieldList;
        //    ViewBag.RegionList = regionList;

        //    string zoneCode, circleCode, snDCode, substationCode, routeCode;

        //    zoneCode = circleCode = snDCode = substationCode = routeCode = "";

        //    if (regionList.Count > 0)
        //    {
        //        zoneCode = regionList[0];

        //        if (regionList.Count > 1)
        //        {
        //            circleCode = regionList[1];

        //            if (regionList.Count > 2)
        //            {
        //                snDCode = regionList[2];

        //                if (regionList.Count > 3)
        //                {
        //                    substationCode = regionList[3];

        //                    if (regionList.Count > 4)
        //                    {
        //                        routeCode = regionList[4];
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    ViewBag.ZoneCode = zoneCode;
        //    ViewBag.CircleCode = circleCode;
        //    ViewBag.SnDCode = snDCode;
        //    ViewBag.SubstationCode = substationCode;
        //    ViewBag.RouteCode = routeCode;


        //    ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode).ToList(), "ZoneCode",
        //        "ZoneName");

        //    if (!string.IsNullOrEmpty(zoneCode))
        //    {
        //        ViewData["CircleList"] = new SelectList(_context.LookUpCircleInfo
        //            .Where(c => c.ZoneCode.Equals(zoneCode))
        //            .Select(c => new { c.CircleCode, c.CircleName })
        //            .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName");

        //        if (!string.IsNullOrEmpty(circleCode))
        //        {
        //            ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo
        //                .Where(sd => sd.CircleCode.Equals(circleCode))
        //                .Select(sd => new { sd.SnDCode, sd.SnDName })
        //                .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName");

        //            //if (!string.IsNullOrEmpty(snDCode))
        //            //{
        //            //    ViewData["PoleList"] = new SelectList(_context.TblPole
        //            //        //.Where(ss => ss.PoleId..SnDCode.Equals(snDCode))
        //            //        .Select(ss => new { ss.SubstationId, ss.SubstationName })
        //            //        .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
        //            //}
        //            //else
        //            //{
        //            //    ViewData["SubstationList"] = null;
        //            //}
        //        }
        //        else
        //        {
        //            ViewData["SnDList"] = ViewData["SubstationList"] = null;
        //        }
        //    }
        //    else
        //    {
        //        ViewData["CircleList"] = ViewData["SnDList"] = ViewData["SubstationList"] = null;
        //    }

        //    return View("AdvancedReport");
        //    //return View("Pole");
        //}

        [HttpPost]
        //public JsonResult GetPoleData(string regionLevel = "zone", List<string> regionList = null)
        //{
        //    regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

        //    Expression<Func<TblPole, bool>> searchExp = null;

        //    string zoneCode, circleCode, snDCode, substationCode, routeCode;

        //    if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
        //    {
        //        zoneCode = regionList[0];

        //        searchExp = model =>
        //            model.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

        //        if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
        //        {
        //            circleCode = regionList[1];

        //            Expression<Func<TblPole, bool>> tempExp = model =>
        //                model.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
        //            searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

        //            if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
        //            {
        //                snDCode = regionList[2];

        //                tempExp = model => model.PoleToRoute.RouteToSubstation.SnDCode == snDCode;
        //                searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

        //                if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
        //                {
        //                    substationCode = regionList[3];

        //                    tempExp = model => model.PoleToRoute.RouteToSubstation.SubstationId == substationCode;
        //                    searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

        //                    if (regionList.Count > 4)
        //                    {
        //                        routeCode = regionList[4];
        //                        //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

        //                        //tempExp = model => model. == substationCode;
        //                        //searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    var qry = searchExp != null
        //        ? _context.TblPole
        //            .AsNoTracking()
        //            .Where(searchExp)
        //        : _context.TblPole
        //            .AsNoTracking();


        //    object data;

        //    switch (regionLevel)
        //    {
        //        case "zone":
        //            data = qry
        //                .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
        //                .GroupBy(i => i.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
        //                .Select(k => new
        //                {
        //                    zoneCode = k.Key,
        //                    zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
        //                        .ZoneInfo.ZoneName,

        //                    totalCount = k.Count(),
        //                    totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
        //                    totalSpCount = k.Count(d => d.PoleTypeId == "2"),
        //                    totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
        //                    totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

        //                    totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
        //                    totalBadCount = k.Count(d => d.PoleConditionId == "B"),
        //                    totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
        //                    totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

        //                    totalNeutralPole = k.Count(d => d.Neutral == "Y"),
        //                    totalStreetLight = k.Count(d => d.StreetLight == "Y"),

        //                    totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
        //                    //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
        //                }).ToList();
        //            break;


        //        case "circle":
        //            data = qry
        //                .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
        //                .GroupBy(i => i.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
        //                .Select(k => new
        //                {
        //                    //wl = k.Sum(d => d.Poles.Sum(pi => pi.WireLength)),
        //                    zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
        //                        .CircleInfo.ZoneInfo.ZoneName,
        //                    circleCode = k.Key,
        //                    circleName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
        //                        .CircleName,


        //                    totalCount = k.Count(),
        //                    totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
        //                    totalSpCount = k.Count(d => d.PoleTypeId == "2"),
        //                    totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
        //                    totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

        //                    totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
        //                    totalBadCount = k.Count(d => d.PoleConditionId == "B"),
        //                    totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
        //                    totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

        //                    totalNeutralPole = k.Count(d => d.Neutral == "Y"),
        //                    totalStreetLight = k.Count(d => d.StreetLight == "Y"),

        //                    totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
        //                    //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
        //                })
        //                .ToList();
        //            break;

        //        case "snd":
        //            data = qry
        //                .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD)
        //                .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo)
        //                .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
        //                .GroupBy(i => i.PoleToRoute.RouteToSubstation.SnDCode)
        //                .Select(k => new
        //                {
        //                    zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
        //                        .ZoneInfo.ZoneName,
        //                    circleName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
        //                        .CircleName,
        //                    sndCode = k.Key,
        //                    sndName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,


        //                    totalCount = k.Count(),
        //                    totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
        //                    totalSpCount = k.Count(d => d.PoleTypeId == "2"),
        //                    totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
        //                    totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

        //                    totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
        //                    totalBadCount = k.Count(d => d.PoleConditionId == "B"),
        //                    totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
        //                    totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

        //                    totalNeutralPole = k.Count(d => d.Neutral == "Y"),
        //                    totalStreetLight = k.Count(d => d.StreetLight == "Y"),

        //                    totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
        //                    //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
        //                }).ToList();
        //            break;

        //        case "substation":
        //            data = qry
        //                .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
        //                .GroupBy(i => i.PoleToRoute.SubstationId)
        //                .Select(k => new
        //                {
        //                    zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
        //                        .ZoneInfo.ZoneName,
        //                    circleName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
        //                        .CircleName,
        //                    sndName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,
        //                    substationCode = k.Key,
        //                    substationName = k.First().PoleToRoute.RouteToSubstation.SubstationName,


        //                    totalCount = k.Count(),
        //                    totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
        //                    totalSpCount = k.Count(d => d.PoleTypeId == "2"),
        //                    totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
        //                    totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

        //                    totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
        //                    totalBadCount = k.Count(d => d.PoleConditionId == "B"),
        //                    totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
        //                    totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

        //                    totalNeutralPole = k.Count(d => d.Neutral == "Y"),
        //                    totalStreetLight = k.Count(d => d.StreetLight == "Y"),

        //                    totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
        //                    //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
        //                }).ToList();
        //            break;

        //        default:
        //            data = qry
        //                .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
        //                .GroupBy(i => i.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
        //                .Select(k => new
        //                {
        //                    zoneCode = k.Key,
        //                    zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
        //                        .ZoneInfo.ZoneName,


        //                    totalCount = k.Count(),
        //                    totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
        //                    totalSpCount = k.Count(d => d.PoleTypeId == "2"),
        //                    totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
        //                    totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

        //                    totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
        //                    totalBadCount = k.Count(d => d.PoleConditionId == "B"),
        //                    totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
        //                    totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

        //                    totalNeutralPole = k.Count(d => d.Neutral == "Y"),
        //                    totalStreetLight = k.Count(d => d.StreetLight == "Y"),

        //                    totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
        //                    //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
        //                }).ToList();
        //            break;
        //    }

        //    return Json(data);
        //}

        #endregion



        #region FeederLineAdvancedReport
        public IActionResult FeederLine([FromQuery] string cai, string regionLevel)
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
                new ReportField {Name = "totalCount", Title = "Total Feeder Line", Selected = true},
                new ReportField {Name = "total33Count", Title = "33KV Feeder Line", Selected = true},
                new ReportField {Name = "total11Count", Title = "11KV Feeder Line", Selected = true},
                //new ReportField {Name = "totalP4Count", Title = ".4KV Feeder Line", Selected = true},

                new ReportField {Name = "totalFeederLength", Title = "Feeder Length (Km)", Selected = true},
                new ReportField {Name = "total33FeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                new ReportField {Name = "total11FeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
                //new ReportField {Name = "totalP4FeederLength", Title = ".4KV Feeder Length (Km)", Selected = true},

                //new ReportField {Name = "totalCurrentRating", Title = "Meter Current Rating", Selected = true},
                //new ReportField {Name = "totalVoltageRating", Title = "Meter Voltage Rating", Selected = true},

                new ReportField {Name = "totalMaxDemand", Title = "Maximum Demand (MW)", Selected = true},
                //new ReportField {Name = "maxMaxDemand", Title = "Max Maximum Demand (MW)", Selected = true},
                //new ReportField {Name = "minMaxDemand", Title = "Min Maximum Demand (MW)", Selected = true},

                new ReportField {Name = "totalPeakDemand", Title = "Peak Demand (MW)", Selected = true},
                //new ReportField {Name = "maxPeakDemand", Title = "Max Peak Demand (MW)", Selected = true},
                //new ReportField {Name = "minPeakDemand", Title = "Min Peak Demand (MW)", Selected = true},

                new ReportField {Name = "totalMaxLoad", Title = "Maximum Load (MW)", Selected = true},
                //new ReportField {Name = "maxMaxLoad", Title = "Max Maximum Load (MW)", Selected = true},
                //new ReportField {Name = "minMaxLoad", Title = "Min Maximum Load (MW)", Selected = true},

                new ReportField {Name = "totalSanctionedLoad", Title = "Sanctioned Load (MW)", Selected = true},
                //new ReportField {Name = "maxSanctionedLoad", Title = "Max Sanctioned Load (MW)", Selected = true},
                //new ReportField {Name = "minSanctionedLoad", Title = "Min Sanctioned Load (MW)", Selected = true}
            };

            ViewBag.ReportName = "Feeder Line";
            ViewBag.ReportAction = "GetFeederLineData";
            ViewBag.ReportController = "AdvancedReport";

            var regionList = new List<string>(5);

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("AdvancedReport");
            //return View("FeederLine");
        }

        [HttpPost]
        public IActionResult FeederLine([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
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
                    new ReportField {Name = "totalCount", Title = "Total Feeder Line", Selected = true},
                    new ReportField {Name = "total33Count", Title = "33KV Feeder Line", Selected = true},
                    new ReportField {Name = "total11Count", Title = "11KV Feeder Line", Selected = true},
                    //new ReportField {Name = "totalP4Count", Title = ".4KV Feeder Line", Selected = true},

                    new ReportField {Name = "totalFeederLength", Title = "Feeder Length (Km)", Selected = true},
                    new ReportField {Name = "total33FeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                    new ReportField {Name = "total11FeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
                    //new ReportField {Name = "totalP4FeederLength", Title = ".4KV Feeder Length (Km)", Selected = true},

                    //new ReportField {Name = "totalCurrentRating", Title = "Meter Current Rating", Selected = true},
                    //new ReportField {Name = "totalVoltageRating", Title = "Meter Voltage Rating", Selected = true},

                    new ReportField {Name = "totalMaxDemand", Title = "Maximum Demand (MW)", Selected = true},
                    //new ReportField {Name = "maxMaxDemand", Title = "Max Maximum Demand (MW)", Selected = true},
                    //new ReportField {Name = "minMaxDemand", Title = "Min Maximum Demand (MW)", Selected = true},

                    new ReportField {Name = "totalPeakDemand", Title = "Peak Demand (MW)", Selected = true},
                    //new ReportField {Name = "maxPeakDemand", Title = "Max Peak Demand (MW)", Selected = true},
                    //new ReportField {Name = "minPeakDemand", Title = "Min Peak Demand (MW)", Selected = true},

                    new ReportField {Name = "totalMaxLoad", Title = "Maximum Load (MW)", Selected = true},
                    //new ReportField {Name = "maxMaxLoad", Title = "Max Maximum Load (MW)", Selected = true},
                    //new ReportField {Name = "minMaxLoad", Title = "Min Maximum Load (MW)", Selected = true},

                    new ReportField {Name = "totalSanctionedLoad", Title = "Sanctioned Load (MW)", Selected = true},
                    //new ReportField {Name = "maxSanctionedLoad", Title = "Max Sanctioned Load (MW)", Selected = true},
                    //new ReportField {Name = "minSanctionedLoad", Title = "Min Sanctioned Load (MW)", Selected = true}
                };
            }

            ViewBag.ReportName = "Feeder Line";
            ViewBag.ReportAction = "GetFeederLineData";
            ViewBag.ReportController = "AdvancedReport";

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

                    //if (!string.IsNullOrEmpty(snDCode))
                    //{
                    //    ViewData["FeederLineList"] = new SelectList(_context.TblFeederLine
                    //        //.Where(ss => ss.FeederLineId..SnDCode.Equals(snDCode))
                    //        .Select(ss => new { ss.SubstationId, ss.SubstationName })
                    //        .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
                    //}
                    //else
                    //{
                    //    ViewData["SubstationList"] = null;
                    //}
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

            return View("AdvancedReport");
            //return View("FeederLine");
        }

        [HttpPost]
        public JsonResult GetFeederLineData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            Expression<Func<TblFeederLine, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

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
                                routeCode = regionList[4];
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
                case "zone":
                    data = qry
                        .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            //wl = k.Sum(d => d.Poles.Sum(pi => pi.WireLength)),
                            zoneCode = k.Key,
                            zoneName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),
                            total33Count = k.Count(d => d.NominalVoltage == 33),
                            total11Count = k.Count(d => d.NominalVoltage == 11),
                            //totalP4Count = k.Count(d => d.NominalVoltage == 0.4m),

                            totalFeederLength = Math.Round(k.Sum(d => d.FeederLength) / 1000, 0),
                            total33FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength) / 1000, 0),
                            total11FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength) / 1000, 0),
                            //totalFeederLength = k.Sum(d => d.FeederLength),
                            //total33FeederLength = k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength),
                            //total11FeederLength = k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength),
                            //totalP4FeederLength = k.Where(d => d.NominalVoltage == 0.4m).Sum(d => d.FeederLength),

                            //totalCurrentRating = k.Sum(d => d.MeterCurrentRating),
                            //totalVoltageRating = k.Sum(d => d.MeterVoltageRating),

                            totalMaxDemand = k.Sum(d => d.MaximumDemand),
                            //maxMaxDemand = k.Max(d => d.MaximumDemand),
                            //minMaxDemand = k.Min(d => d.MaximumDemand),

                            totalPeakDemand = k.Sum(d => d.PeakDemand),
                            //maxPeakDemand = k.Max(d => d.PeakDemand),
                            //minPeakDemand = k.Min(d => d.PeakDemand),

                            totalMaxLoad = k.Sum(d => d.MaximumLoad),
                            //maxMaxLoad = k.Max(d => d.MaximumLoad),
                            //minMaxLoad = k.Min(d => d.MaximumLoad),

                            totalSanctionedLoad = k.Sum(d => d.SanctionedLoad),
                            //maxSanctionedLoad = k.Max(d => d.SanctionedLoad),
                            //minSanctionedLoad = k.Min(d => d.SanctionedLoad),
                        }).ToList();
                    break;


                case "circle":
                    data = qry
                        .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            //wl = k.Sum(d => d.Poles.Sum(pi => pi.WireLength)),
                            zoneName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo.ZoneInfo.ZoneName,
                            circleCode = k.Key,
                            circleName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,

                            totalCount = k.Count(),
                            total33Count = k.Count(d => d.NominalVoltage == 33),
                            total11Count = k.Count(d => d.NominalVoltage == 11),
                            //totalP4Count = k.Count(d => d.NominalVoltage == 0.4m),

                            totalFeederLength = Math.Round(k.Sum(d => d.FeederLength) / 1000, 0),
                            total33FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength) / 1000, 0),
                            total11FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength) / 1000, 0),
                            //totalFeederLength = k.Sum(d => d.FeederLength),
                            //total33FeederLength = k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength),
                            //total11FeederLength = k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength),
                            //totalP4FeederLength = k.Where(d => d.NominalVoltage == 0.4m).Sum(d => d.FeederLength),

                            //totalCurrentRating = k.Sum(d => d.MeterCurrentRating),
                            //totalVoltageRating = k.Sum(d => d.MeterVoltageRating),

                            totalMaxDemand = k.Sum(d => d.MaximumDemand),
                            //maxMaxDemand = k.Max(d => d.MaximumDemand),
                            //minMaxDemand = k.Min(d => d.MaximumDemand),

                            totalPeakDemand = k.Sum(d => d.PeakDemand),
                            //maxPeakDemand = k.Max(d => d.PeakDemand),
                            //minPeakDemand = k.Min(d => d.PeakDemand),

                            totalMaxLoad = k.Sum(d => d.MaximumLoad),
                            //maxMaxLoad = k.Max(d => d.MaximumLoad),
                            //minMaxLoad = k.Min(d => d.MaximumLoad),

                            totalSanctionedLoad = k.Sum(d => d.SanctionedLoad),
                            //maxSanctionedLoad = k.Max(d => d.SanctionedLoad),
                            //minSanctionedLoad = k.Min(d => d.SanctionedLoad),
                        })
                        .ToList();
                    break;

                case "snd":
                    data = qry
                        .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD)
                        .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo)
                        .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.FeederLineToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            zoneName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndCode = k.Key,
                            sndName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,

                            totalCount = k.Count(),
                            total33Count = k.Count(d => d.NominalVoltage == 33),
                            total11Count = k.Count(d => d.NominalVoltage == 11),
                            //totalP4Count = k.Count(d => d.NominalVoltage == 0.4m),

                            totalFeederLength = Math.Round(k.Sum(d => d.FeederLength) / 1000, 0),
                            total33FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength) / 1000, 0),
                            total11FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength) / 1000, 0),
                            //totalFeederLength = k.Sum(d => d.FeederLength),
                            //total33FeederLength = k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength),
                            //total11FeederLength = k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength),
                            //totalP4FeederLength = k.Where(d => d.NominalVoltage == 0.4m).Sum(d => d.FeederLength),

                            //totalCurrentRating = k.Sum(d => d.MeterCurrentRating),
                            //totalVoltageRating = k.Sum(d => d.MeterVoltageRating),

                            totalMaxDemand = k.Sum(d => d.MaximumDemand),
                            //maxMaxDemand = k.Max(d => d.MaximumDemand),
                            //minMaxDemand = k.Min(d => d.MaximumDemand),

                            totalPeakDemand = k.Sum(d => d.PeakDemand),
                            //maxPeakDemand = k.Max(d => d.PeakDemand),
                            //minPeakDemand = k.Min(d => d.PeakDemand),

                            totalMaxLoad = k.Sum(d => d.MaximumLoad),
                            //maxMaxLoad = k.Max(d => d.MaximumLoad),
                            //minMaxLoad = k.Min(d => d.MaximumLoad),

                            totalSanctionedLoad = k.Sum(d => d.SanctionedLoad),
                            //maxSanctionedLoad = k.Max(d => d.SanctionedLoad),
                            //minSanctionedLoad = k.Min(d => d.SanctionedLoad),
                        }).ToList();
                    break;

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

                            totalCount = k.Count(),
                            total33Count = k.Count(d => d.NominalVoltage == 33),
                            total11Count = k.Count(d => d.NominalVoltage == 11),
                            //totalP4Count = k.Count(d => d.NominalVoltage == 0.4m),

                            totalFeederLength = Math.Round(k.Sum(d => d.FeederLength) / 1000, 0),
                            total33FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength) / 1000, 0),
                            total11FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength) / 1000, 0),
                            //totalFeederLength = k.Sum(d => d.FeederLength),
                            //total33FeederLength = k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength),
                            //total11FeederLength = k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength),
                            //totalP4FeederLength = k.Where(d => d.NominalVoltage == 0.4m).Sum(d => d.FeederLength),

                            //totalCurrentRating = k.Sum(d => d.MeterCurrentRating),
                            //totalVoltageRating = k.Sum(d => d.MeterVoltageRating),

                            totalMaxDemand = k.Sum(d => d.MaximumDemand),
                            //maxMaxDemand = k.Max(d => d.MaximumDemand),
                            //minMaxDemand = k.Min(d => d.MaximumDemand),

                            totalPeakDemand = k.Sum(d => d.PeakDemand),
                            //maxPeakDemand = k.Max(d => d.PeakDemand),
                            //minPeakDemand = k.Min(d => d.PeakDemand),

                            totalMaxLoad = k.Sum(d => d.MaximumLoad),
                            //maxMaxLoad = k.Max(d => d.MaximumLoad),
                            //minMaxLoad = k.Min(d => d.MaximumLoad),

                            totalSanctionedLoad = k.Sum(d => d.SanctionedLoad),
                            //maxSanctionedLoad = k.Max(d => d.SanctionedLoad),
                            //minSanctionedLoad = k.Min(d => d.SanctionedLoad),
                        }).ToList();
                    break;

                default:
                    data = qry
                        .Include(st => st.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),
                            total33Count = k.Count(d => d.NominalVoltage == 33),
                            total11Count = k.Count(d => d.NominalVoltage == 11),
                            //totalP4Count = k.Count(d => d.NominalVoltage == 0.4m),

                            totalFeederLength = Math.Round(k.Sum(d => d.FeederLength) / 1000, 0),
                            total33FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength) / 1000, 0),
                            total11FeederLength = Math.Round(k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength) / 1000, 0),
                            //totalFeederLength = k.Sum(d => d.FeederLength),
                            //total33FeederLength = k.Where(d => d.NominalVoltage == 33).Sum(d => d.FeederLength),
                            //total11FeederLength = k.Where(d => d.NominalVoltage == 11).Sum(d => d.FeederLength),
                            //totalP4FeederLength = k.Where(d => d.NominalVoltage == 0.4m).Sum(d => d.FeederLength),

                            //totalCurrentRating = k.Sum(d => d.MeterCurrentRating),
                            //totalVoltageRating = k.Sum(d => d.MeterVoltageRating),

                            totalMaxDemand = k.Sum(d => d.MaximumDemand),
                            //maxMaxDemand = k.Max(d => d.MaximumDemand),
                            //minMaxDemand = k.Min(d => d.MaximumDemand),

                            totalPeakDemand = k.Sum(d => d.PeakDemand),
                            //maxPeakDemand = k.Max(d => d.PeakDemand),
                            //minPeakDemand = k.Min(d => d.PeakDemand),

                            totalMaxLoad = k.Sum(d => d.MaximumLoad),
                            //maxMaxLoad = k.Max(d => d.MaximumLoad),
                            //minMaxLoad = k.Min(d => d.MaximumLoad),

                            totalSanctionedLoad = k.Sum(d => d.SanctionedLoad),
                            //maxSanctionedLoad = k.Max(d => d.SanctionedLoad),
                            //minSanctionedLoad = k.Min(d => d.SanctionedLoad),
                        }).ToList();
                    break;
            }

            return Json(data);
        }

        #endregion


        #region SubstationAdvancedReport

        public IActionResult Substation([FromQuery] string cai, string regionLevel)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };

            var fieldList = new List<ReportField>(8)
            {
                new ReportField {Name = "totalCount", Title = "Total Substation", Selected = true},
                new ReportField {Name = "total11Count", Title = "33/11 kV Substation", Selected = true},
                new ReportField {Name = "total33Count", Title = "132/33 kV Substation", Selected = true},
                new ReportField {Name = "totalCapacity", Title = "Capacity (MVA)", Selected = true},
                new ReportField {Name = "totalDemand", Title = "Demand (Max) (MW)", Selected = true},
                new ReportField {Name = "totalPeakLoad", Title = "Peak Load (MW)", Selected = true},
                new ReportField {Name = "maxPeakLoad", Title = "Max Peak Load (MW)", Selected = true},
                new ReportField {Name = "minPeakLoad", Title = "Min Peak Load (MW)", Selected = true}
            };


            ViewBag.ReportName = "Substation";
            ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "AdvancedReport";

            var regionList = new List<string>(5);


            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("AdvancedReport");
            //return View("Substation");
        }

        [HttpPost]
        public IActionResult Substation([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
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
                fieldList = new List<ReportField>(5)
                {
                    new ReportField {Name = "totalCount", Title = "Total Substation", Selected = true},
                    new ReportField {Name = "total11Count", Title = "33/11 kV Substation", Selected = true},
                    new ReportField {Name = "total33Count", Title = "132/33 kV Substation", Selected = true},
                    new ReportField {Name = "totalCapacity", Title = "Capacity (MVA)", Selected = true},
                    new ReportField {Name = "totalDemand", Title = "Demand (Max) (MW)", Selected = true},
                    new ReportField {Name = "totalPeakLoad", Title = "Peak Load (MW)", Selected = true},
                    new ReportField {Name = "maxPeakLoad", Title = "Max Peak Load (MW)", Selected = true},
                    new ReportField {Name = "minPeakLoad", Title = "Min Peak Load (MW)", Selected = true}
                };
            }

            ViewBag.ReportName = "Substation";
            ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "AdvancedReport";

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

            return View("AdvancedReport");
            //return View("Substation");
        }

        [HttpPost]
        public JsonResult GetSubstationData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

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


            object data;

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

        #endregion



        #region DistributionTransformerAdvancedReport

        public IActionResult DistributionTransformer([FromQuery] string cai, string regionLevel)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };


            //Installed Condition(Pad/ PoleMounted)
            //Installed Place(Indoor/ Outdoor)
            //Owner ofthe Transformer(BPDB/ Consumer)

            //Oil Leakage(Yes / No)
            //Platform Material(Angle/ Channel)

            var fieldList = new List<ReportField>(16)
            {
                new ReportField {Name = "totalCount", Title = "Total DT", Selected = true},
                //new ReportField {Name = "total33Count", Title = "33KV DT", Selected = true},
                //new ReportField {Name = "total11Count", Title = "11KV DT", Selected = true},
                ////new ReportField {Name = "totalP4Count", Title = ".4KV DT", Selected = true},
                
                new ReportField {Name = "groupIC", Title = "Installed Condition", Selected = true},
                new ReportField {Name = "totalIcPadCount", Title = "Pad", Selected = true, Visible = false, GroupName = "groupIC"},
                new ReportField {Name = "totalIcPoleMountCount", Title = "Pole Mounted", Selected = true, Visible = false, GroupName = "groupIC"},

                new ReportField {Name = "groupIP", Title = "Installed Place", Selected = true},
                new ReportField {Name = "totalIpIndoorCount", Title = "Indoor", Selected = true, Visible = false, GroupName = "groupIP"},
                new ReportField {Name = "totalIpOutdoorCount", Title = "Outdoor", Selected = true, Visible = false, GroupName = "groupIP"},

                new ReportField {Name = "groupOwner", Title = "Owner of the DT", Selected = true},
                new ReportField {Name = "totalBpdbDtCount", Title = "BPDB", Selected = true, Visible = false, GroupName = "groupOwner"},
                new ReportField {Name = "totalConsumerDtCount", Title = "Consumer", Selected = true, Visible = false, GroupName = "groupOwner"},

                new ReportField {Name = "groupOL", Title = "Oil Leakage", Selected = true},
                new ReportField {Name = "totalOlYesCount", Title = "Yes", Selected = true, Visible = false, GroupName = "groupOL"},
                new ReportField {Name = "totalOlNoCount", Title = "No", Selected = true, Visible = false, GroupName = "groupOL"},

                new ReportField {Name = "groupPM", Title = "Platform Material", Selected = true},
                new ReportField {Name = "totalPmAngleCount", Title = "Angle", Selected = true, Visible = false, GroupName = "groupPM"},
                new ReportField {Name = "totalPmChannelCount", Title = "Channel", Selected = true, Visible = false, GroupName = "groupPM"},


                //new ReportField {Name = "totalNeutralDt", Title = "Has Neutral Cable", Selected = true},
                //new ReportField {Name = "totalStreetLight", Title = "Has Street Light", Selected = true},
                //new ReportField {Name = "totalWireLength", Title = "Wire Length (Km)", Selected = true},
            };

            ViewBag.ReportName = "Distribution Transformer";
            ViewBag.ReportAction = "GetDistributionTransformerData";
            ViewBag.ReportController = "AdvancedReport";

            var regionList = new List<string>(5);

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("AdvancedReport");
            //return View("DistributionTransformer");
        }

        [HttpPost]
        public IActionResult DistributionTransformer([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
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
                fieldList = new List<ReportField>(16)
                {
                    new ReportField {Name = "totalCount", Title = "Total DT", Selected = true},
                    //new ReportField {Name = "total33Count", Title = "33KV DT", Selected = true},
                    //new ReportField {Name = "total11Count", Title = "11KV DT", Selected = true},
                    ////new ReportField {Name = "totalP4Count", Title = ".4KV DT", Selected = true},
                    
                    new ReportField {Name = "groupIC", Title = "Installed Condition", Selected = true},
                    new ReportField {Name = "totalIcPadCount", Title = "Pad", Selected = true, Visible = false, GroupName = "groupIC"},
                    new ReportField {Name = "totalIcPoleMountCount", Title = "Pole Mounted", Selected = true, Visible = false, GroupName = "groupIC"},

                    new ReportField {Name = "groupIP", Title = "Installed Place", Selected = true},
                    new ReportField {Name = "totalIpIndoorCount", Title = "Indoor", Selected = true, Visible = false, GroupName = "groupIP"},
                    new ReportField {Name = "totalIpOutdoorCount", Title = "Outdoor", Selected = true, Visible = false, GroupName = "groupIP"},

                    new ReportField {Name = "groupOwner", Title = "Owner of the DT", Selected = true},
                    new ReportField {Name = "totalBpdbDtCount", Title = "BPDB", Selected = true, Visible = false, GroupName = "groupOwner"},
                    new ReportField {Name = "totalConsumerDtCount", Title = "Consumer", Selected = true, Visible = false, GroupName = "groupOwner"},

                    new ReportField {Name = "groupOL", Title = "Oil Leakage", Selected = true},
                    new ReportField {Name = "totalOlYesCount", Title = "Yes", Selected = true, Visible = false, GroupName = "groupOL"},
                    new ReportField {Name = "totalOlNoCount", Title = "No", Selected = true, Visible = false, GroupName = "groupOL"},

                    new ReportField {Name = "groupPM", Title = "Platform Material", Selected = true},
                    new ReportField {Name = "totalPmAngleCount", Title = "Angle", Selected = true, Visible = false, GroupName = "groupPM"},
                    new ReportField {Name = "totalPmChannelCount", Title = "Channel", Selected = true, Visible = false, GroupName = "groupPM"},
                };
            }

            ViewBag.ReportName = "Distribution Transformer";
            ViewBag.ReportAction = "GetDistributionTransformerData";
            ViewBag.ReportController = "AdvancedReport";

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

                    //if (!string.IsNullOrEmpty(snDCode))
                    //{
                    //    ViewData["DtList"] = new SelectList(_context.TblDT
                    //        //.Where(ss => ss.DTId..SnDCode.Equals(snDCode))
                    //        .Select(ss => new { ss.SubstationId, ss.SubstationName })
                    //        .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
                    //}
                    //else
                    //{
                    //    ViewData["SubstationList"] = null;
                    //}
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

            return View("AdvancedReport");
            //return View("DistributionTransformer");
        }

        [HttpPost]
        public JsonResult GetDistributionTransformerData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            Expression<Func<TblDistributionTransformer, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblDistributionTransformer, bool>> tempExp = model =>
                        model.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.DtToPole.PoleToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.DtToPole.PoleToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4)
                            {
                                routeCode = regionList[4];
                                //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                                //tempExp = model => model. == substationCode;
                                //searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);
                            }
                        }
                    }
                }
            }

            var qry = searchExp != null
                ? _context.TblDistributionTransformer
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblDistributionTransformer
                    .AsNoTracking();


            object data;

            switch (regionLevel)
            {
                case "zone":
                    data = qry
                        .Include(st => st.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pad")),
                            totalIcPoleMountCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pole")),

                            totalIpIndoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("indoor")),
                            totalIpOutdoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("outdoor")),

                            totalBpdbDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("bpdb")),
                            totalConsumerDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("consumer")),

                            totalOlYesCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("yes")),
                            totalOlNoCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("no")),

                            totalPmAngleCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("angle")),
                            totalPmChannelCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("channel")),
                        }).ToList();
                    break;


                case "circle":
                    data = qry
                        .Include(st => st.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            //wl = k.Sum(d => d.Poles.Sum(pi => pi.WireLength)),
                            zoneName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo.ZoneInfo.ZoneName,
                            circleCode = k.Key,
                            circleName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,


                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pad")),
                            totalIcPoleMountCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pole")),

                            totalIpIndoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("indoor")),
                            totalIpOutdoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("outdoor")),

                            totalBpdbDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("bpdb")),
                            totalConsumerDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("consumer")),

                            totalOlYesCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("yes")),
                            totalOlNoCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("no")),

                            totalPmAngleCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("angle")),
                            totalPmChannelCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("channel")),
                        })
                        .ToList();
                    break;

                case "snd":
                    data = qry
                        .Include(st => st.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD)
                        .Include(st => st.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo)
                        .Include(st => st.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.DtToPole.PoleToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            zoneName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndCode = k.Key,
                            sndName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,


                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pad")),
                            totalIcPoleMountCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pole")),

                            totalIpIndoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("indoor")),
                            totalIpOutdoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("outdoor")),

                            totalBpdbDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("bpdb")),
                            totalConsumerDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("consumer")),

                            totalOlYesCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("yes")),
                            totalOlNoCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("no")),

                            totalPmAngleCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("angle")),
                            totalPmChannelCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("channel")),
                        }).ToList();
                    break;

                case "substation":
                    data = qry
                        .Include(st => st.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.DtToPole.PoleToRoute.SubstationId)
                        .Select(k => new
                        {
                            zoneName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,
                            substationCode = k.Key,
                            substationName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationName,


                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pad")),
                            totalIcPoleMountCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pole")),

                            totalIpIndoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("indoor")),
                            totalIpOutdoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("outdoor")),

                            totalBpdbDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("bpdb")),
                            totalConsumerDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("consumer")),

                            totalOlYesCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("yes")),
                            totalOlNoCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("no")),

                            totalPmAngleCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("angle")),
                            totalPmChannelCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("channel")),
                        }).ToList();
                    break;

                default:
                    data = qry
                        .Include(st => st.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,


                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pad")),
                            totalIcPoleMountCount = k.Count(d => d.InstalledConditionPadbsPoleMounted.ToLower().Contains("pole")),

                            totalIpIndoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("indoor")),
                            totalIpOutdoorCount = k.Count(d => d.InstalledPlaceIndoorbsOutdoor.ToLower().Contains("outdoor")),

                            totalBpdbDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("bpdb")),
                            totalConsumerDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("consumer")),

                            totalOlYesCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("yes")),
                            totalOlNoCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("no")),

                            totalPmAngleCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("angle")),
                            totalPmChannelCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("channel")),
                        }).ToList();
                    break;
            }

            return Json(data);
        }

        #endregion



        #region PowerTransformerAdvancedReport

        public IActionResult PowerTransformer([FromQuery] string cai, string regionLevel)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };


            var fieldList = new List<ReportField>(16)
            {
                new ReportField {Name = "totalCount", Title = "Total PT", Selected = true},
                //Source 132 Or 33kV Substation
                new ReportField {Name = "groupSS", Title = "Source Substation", Selected = true},
                new ReportField {Name = "total132SrcCount", Title = "132kV", Selected = true, Visible = false, GroupName = "groupSS"},
                new ReportField {Name = "total33SrcCount", Title = "33kV", Selected = true, Visible = false, GroupName = "groupSS"},

                //Rated Voltage 132 Or 33kV (Phase to Phase)
                new ReportField {Name = "groupRV", Title = "Rated Voltage", Selected = true},
                new ReportField {Name = "total132RatVolCount", Title = "132kV", Selected = true, Visible = false, GroupName = "groupRV"},
                new ReportField {Name = "total33RatVolCount", Title = "33kV", Selected = true, Visible = false, GroupName = "groupRV"},

                //Radiators (YES / NO)
                new ReportField {Name = "groupRadiators", Title = "Radiators", Selected = true},
                new ReportField {Name = "totalRadiatorsYes", Title = "Yes", Selected = true, Visible = false, GroupName = "groupRadiators"},
                new ReportField {Name = "totalRadiatorsNo", Title = "No", Selected = true, Visible = false, GroupName = "groupRadiators"},

                //Supervisory Alarm and Trip Contacts (YES / NO)
                new ReportField {Name = "groupSATC", Title = "Supervisory Alarm and Trip Contacts", Selected = true},
                new ReportField {Name = "totalSATCYes", Title = "Yes", Selected = true, Visible = false, GroupName = "groupSATC"},
                new ReportField {Name = "totalSATCNo", Title = "No", Selected = true, Visible = false, GroupName = "groupSATC"},

                //Temperature Indicators (YES / NO)
                new ReportField {Name = "groupTI", Title = "Temperature Indicators", Selected = true},
                new ReportField {Name = "totalTIYes", Title = "Yes", Selected = true, Visible = false, GroupName = "groupTI"},
                new ReportField {Name = "totalTINo", Title = "No", Selected = true, Visible = false, GroupName = "groupTI"},

            };

            ViewBag.ReportName = "Power Transformer";
            ViewBag.ReportAction = "GetPowerTransformerData";
            ViewBag.ReportController = "AdvancedReport";

            var regionList = new List<string>(5);

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("AdvancedReport");
            //return View("PowerTransformer");
        }

        [HttpPost]
        public IActionResult PowerTransformer([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
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
                fieldList = new List<ReportField>(16)
                {
                    new ReportField {Name = "totalCount", Title = "Total PT", Selected = true},
                    //Source 132 Or 33kV Substation
                    new ReportField {Name = "groupSS", Title = "Source Substation", Selected = true},
                    new ReportField {Name = "total132SrcCount", Title = "132kV", Selected = true, Visible = false, GroupName = "groupSS"},
                    new ReportField {Name = "total33SrcCount", Title = "33kV", Selected = true, Visible = false, GroupName = "groupSS"},

                    //Rated Voltage 132 Or 33kV (Phase to Phase)
                    new ReportField {Name = "groupRV", Title = "Rated Voltage", Selected = true},
                    new ReportField {Name = "total132RatVolCount", Title = "132kV", Selected = true, Visible = false, GroupName = "groupRV"},
                    new ReportField {Name = "total33RatVolCount", Title = "33kV", Selected = true, Visible = false, GroupName = "groupRV"},

                    //Radiators (YES / NO)
                    new ReportField {Name = "groupRadiators", Title = "Radiators", Selected = true},
                    new ReportField {Name = "totalRadiatorsYes", Title = "Yes", Selected = true, Visible = false, GroupName = "groupRadiators"},
                    new ReportField {Name = "totalRadiatorsNo", Title = "No", Selected = true, Visible = false, GroupName = "groupRadiators"},

                    //Supervisory Alarm and Trip Contacts (YES / NO)
                    new ReportField {Name = "groupSATC", Title = "Supervisory Alarm and Trip Contacts", Selected = true},
                    new ReportField {Name = "totalSATCYes", Title = "Yes", Selected = true, Visible = false, GroupName = "groupSATC"},
                    new ReportField {Name = "totalSATCNo", Title = "No", Selected = true, Visible = false, GroupName = "groupSATC"},

                    //Temperature Indicators (YES / NO)
                    new ReportField {Name = "groupTI", Title = "Temperature Indicators", Selected = true},
                    new ReportField {Name = "totalTIYes", Title = "Yes", Selected = true, Visible = false, GroupName = "groupTI"},
                    new ReportField {Name = "totalTINo", Title = "No", Selected = true, Visible = false, GroupName = "groupTI"},
                };
            }

            ViewBag.ReportName = "Power Transformer";
            ViewBag.ReportAction = "GetPowerTransformerData";
            ViewBag.ReportController = "AdvancedReport";

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

                    //if (!string.IsNullOrEmpty(snDCode))
                    //{
                    //    ViewData["DtList"] = new SelectList(_context.TblDT
                    //        //.Where(ss => ss.DTId..SnDCode.Equals(snDCode))
                    //        .Select(ss => new { ss.SubstationId, ss.SubstationName })
                    //        .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
                    //}
                    //else
                    //{
                    //    ViewData["SubstationList"] = null;
                    //}
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

            return View("AdvancedReport");
            //return View("PowerTransformer");
        }

        [HttpPost]
        public JsonResult GetPowerTransformerData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            Expression<Func<TblPhasePowerTransformer, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblPhasePowerTransformer, bool>> tempExp = model =>
                        model.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.PhasePowerTransformerToTblSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.PhasePowerTransformerToTblSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4)
                            {
                                routeCode = regionList[4];
                                //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                                //tempExp = model => model. == substationCode;
                                //searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);
                            }
                        }
                    }
                }
            }

            var qry = searchExp != null
                ? _context.TblPhasePowerTransformer
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblPhasePowerTransformer
                    .AsNoTracking();

            //data = qry
            //    .Include(st => st.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo);

            object data;


            switch (regionLevel)
            {
                case "zone":
                    data = qry
                        .Include(st => st.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),

                            total132SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "132"),
                            total33SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "33"),

                            total132RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("132")),
                            total33RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("33")),

                            totalRadiatorsYes = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("yes")),
                            totalRadiatorsNo = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("no")),

                            totalSATCYes = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("yes")),
                            totalSATCNo = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("no")),

                            totalTIYes = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("yes")),
                            totalTINo = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("no")),



                            //totalBpdbDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("bpdb")),
                            //totalConsumerDtCount = k.Count(d => d.OwneroftheTransformerBPDBbsConsumer.ToLower().Contains("consumer")),

                            //totalOlYesCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("yes")),
                            //totalOlNoCount = k.Count(d => d.OilLeakageYesOrNo.ToLower().Contains("no")),

                            //totalPmAngleCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("angle")),
                            //totalPmChannelCount = k.Count(d => d.PlatformMaterialAnglbsChannel.ToLower().Contains("channel")),
                        }).ToList();
                    break;


                case "circle":
                    data = qry
                        .Include(st => st.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            //wl = k.Sum(d => d.Poles.Sum(pi => pi.WireLength)),
                            zoneName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD
                                .CircleInfo.ZoneInfo.ZoneName,
                            circleCode = k.Key,
                            circleName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,

                            totalCount = k.Count(),

                            total132SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "132"),
                            total33SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "33"),

                            total132RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("132")),
                            total33RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("33")),

                            totalRadiatorsYes = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("yes")),
                            totalRadiatorsNo = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("no")),

                            totalSATCYes = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("yes")),
                            totalSATCNo = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("no")),

                            totalTIYes = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("yes")),
                            totalTINo = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("no")),

                        })
                        .ToList();
                    break;

                case "snd":
                    data = qry
                        .Include(st => st.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD)
                        .Include(st => st.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo)
                        .Include(st => st.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PhasePowerTransformerToTblSubstation.SnDCode)
                        .Select(k => new
                        {
                            zoneName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndCode = k.Key,
                            sndName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.SnDName,


                            totalCount = k.Count(),

                            total132SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "132"),
                            total33SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "33"),

                            total132RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("132")),
                            total33RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("33")),

                            totalRadiatorsYes = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("yes")),
                            totalRadiatorsNo = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("no")),

                            totalSATCYes = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("yes")),
                            totalSATCNo = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("no")),

                            totalTIYes = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("yes")),
                            totalTINo = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("no")),

                        }).ToList();
                    break;

                case "substation":
                    data = qry
                        .Include(st => st.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.SubstationId)
                        .Select(k => new
                        {
                            zoneName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.SnDName,
                            substationCode = k.Key,
                            substationName = k.First().PhasePowerTransformerToTblSubstation.SubstationName,


                            totalCount = k.Count(),

                            total132SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "132"),
                            total33SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "33"),

                            total132RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("132")),
                            total33RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("33")),

                            totalRadiatorsYes = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("yes")),
                            totalRadiatorsNo = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("no")),

                            totalSATCYes = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("yes")),
                            totalSATCNo = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("no")),

                            totalTIYes = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("yes")),
                            totalTINo = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("no")),

                        }).ToList();
                    break;

                default:
                    data = qry
                        .Include(st => st.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,


                            totalCount = k.Count(),

                            total132SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "132"),
                            total33SrcCount = k.Count(d => d.PhasePowerTransformerToSourceSubstation.NominalVoltage == "33"),

                            total132RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("132")),
                            total33RatVolCount = k.Count(d => d.RatedVoltagePhaseToPhase.Contains("33")),

                            totalRadiatorsYes = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("yes")),
                            totalRadiatorsNo = k.Count(d => d.RadiatorsYesNo.ToLower().Contains("no")),

                            totalSATCYes = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("yes")),
                            totalSATCNo = k.Count(d => d.SupervisoryAlarmAndTripContactsYesNo.ToLower().Contains("no")),

                            totalTIYes = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("yes")),
                            totalTINo = k.Count(d => d.TemperatureIndicatorsYesNo.ToLower().Contains("no")),

                        }).ToList();
                    break;
            }

            return Json(data);
        }

        #endregion
    }


}