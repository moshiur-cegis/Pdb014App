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
                    //new ReportField {Name = "total33kCount", Title = "33KV Pole", Selected = true},
                    //new ReportField {Name = "total11kCount", Title = "11KV Pole", Selected = true},
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

                    //new ReportField {Name = "total33kFeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                    //new ReportField {Name = "total11kFeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
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
                    //new ReportField {Name = "total33kCount", Title = "33KV Pole", Selected = true},
                    //new ReportField {Name = "total11kCount", Title = "11KV Pole", Selected = true},
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

                    //new ReportField {Name = "total33kFeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                    //new ReportField {Name = "total11kFeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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

        public IActionResult Pole([FromQuery] string cai, string regionLevel)
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

                new ReportField {Name = "groupPoleType", Title = "Pole Type", Selected = true},
                new ReportField {Name = "totalSpcCount", Title = "SPC", Selected = true, Visible = false, GroupName = "groupPoleType"},
                new ReportField {Name = "totalSpCount", Title = "SP", Selected = true, Visible = false, GroupName = "groupPoleType"},
                new ReportField {Name = "totalTowerCount", Title = "Tower", Selected = true, Visible = false, GroupName = "groupPoleType"},
                new ReportField {Name = "totalOthersCount", Title = "Others", Selected = true, Visible = false, GroupName = "groupPoleType"},

                new ReportField {Name = "groupPoleCondition", Title = "Pole Condition", Selected = true},
                new ReportField {Name = "totalAgedCount", Title = "Aged", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                new ReportField {Name = "totalBadCount", Title = "Bad", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                new ReportField {Name = "totalBrokenCount", Title = "Broken", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                new ReportField {Name = "totalGoodCount", Title = "Good", Selected = true, Visible = false, GroupName = "groupPoleCondition"},

                new ReportField {Name = "totalNeutralPole", Title = "Has Neutral Cable", Selected = true},
                new ReportField {Name = "totalStreetLight", Title = "Has Street Light", Selected = true},

                new ReportField {Name = "totalWireLength", Title = "Wire Length (Km)", Selected = true},
            };


            ViewBag.ReportName = "Pole";
            ViewBag.ReportAction = "GetPoleData";
            ViewBag.ReportController = "AdvancedReport";

            var regionList = new List<string>(5);

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("AdvancedReport");
            //return View("Pole");
        }

        public IActionResult PoleChart([FromQuery] string cai, string chartType, string regionLevel)
        {
            var fieldList = new List<ReportField>(13)
            {
                new ReportField {Name = "totalCount", Title = "Total Pole", Selected = true},

                new ReportField {Name = "totalSpcCount", Title = "SPC Pole", Selected = true},
                new ReportField {Name = "totalSpCount", Title = "SP Pole", Selected = true},
                new ReportField {Name = "totalTowerCount", Title = "Tower", Selected = true},
                new ReportField {Name = "totalOthersCount", Title = "Others Pole", Selected = true},

                new ReportField {Name = "totalAgedCount", Title = "Aged Pole", Selected = true},
                new ReportField {Name = "totalBadCount", Title = "Bad Pole", Selected = true},
                new ReportField {Name = "totalBrokenCount", Title = "Broken Pole", Selected = true},
                new ReportField {Name = "totalGoodCount", Title = "Good Pole", Selected = true},

                new ReportField {Name = "totalNeutralPole", Title = "Has Neutral Cable", Selected = true},
                new ReportField {Name = "totalStreetLight", Title = "Has Street Light", Selected = true},

                new ReportField {Name = "totalWireLength", Title = "Wire Length (Km)", Selected = true},
            };


            ViewBag.ReportName = "Pole";
            ViewBag.ReportAction = "GetPoleData";
            ViewBag.ReportController = "AdvancedReport";

            ViewBag.ChartType = chartType ?? "bar";
            ViewBag.RegionLevel = regionLevel ?? "zone";
            ViewBag.FieldList = fieldList;

            return View("AdvancedReportChart");
        }



        [HttpPost]
        public IActionResult Pole([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
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

                new ReportField {Name = "groupPoleType", Title = "Pole Type", Selected = true},
                new ReportField {Name = "totalSpcCount", Title = "SPC", Selected = true, Visible = false, GroupName = "groupPoleType"},
                new ReportField {Name = "totalSpCount", Title = "SP", Selected = true, Visible = false, GroupName = "groupPoleType"},
                new ReportField {Name = "totalTowerCount", Title = "Tower", Selected = true, Visible = false, GroupName = "groupPoleType"},
                new ReportField {Name = "totalOthersCount", Title = "Others", Selected = true, Visible = false, GroupName = "groupPoleType"},

                new ReportField {Name = "groupPoleCondition", Title = "Pole Condition", Selected = true},
                new ReportField {Name = "totalAgedCount", Title = "Aged", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                new ReportField {Name = "totalBadCount", Title = "Bad", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                new ReportField {Name = "totalBrokenCount", Title = "Broken", Selected = true, Visible = false, GroupName = "groupPoleCondition"},
                new ReportField {Name = "totalGoodCount", Title = "Good", Selected = true, Visible = false, GroupName = "groupPoleCondition"},

                new ReportField {Name = "totalNeutralPole", Title = "Has Neutral Cable", Selected = true},
                new ReportField {Name = "totalStreetLight", Title = "Has Street Light", Selected = true},

                new ReportField {Name = "totalWireLength", Title = "Wire Length (Km)", Selected = true},

                //new ReportField {Name = "total33kFeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                //new ReportField {Name = "total11kFeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
                };
            }

            ViewBag.ReportName = "Pole";
            ViewBag.ReportAction = "GetPoleData";
            ViewBag.ReportController = "AdvancedReport";

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionInfo = regionInfo;
            ViewBag.RegionLevel = regionLevel;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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
            //return View("Pole");
        }

        [HttpPost]
        public JsonResult GetPoleData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            Expression<Func<TblPole, bool>> searchExp = null;

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblPole, bool>> tempExp = model =>
                        model.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.PoleToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.PoleToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);
                            }
                        }
                    }
                }
            }

            var qry = searchExp != null
                ? _context.TblPole
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblPole
                    .AsNoTracking();


            object data;

            switch (regionLevel)
            {
                case "zone":

                    var plInfo = qry
                        .Select(pl => new
                        {
                            RegionCode = pl.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            PoleType = pl.PoleTypeId != null ? pl.PoleTypeId.ToLower() : "",
                            PoleCondition = pl.PoleTypeId != null ? pl.PoleConditionId.ToLower() : "",
                            Neutral = pl.Neutral != null ? pl.Neutral.ToLower() : "",
                            StreetLight = pl.StreetLight != null ? pl.StreetLight.ToLower() : "",
                            WireLength = pl.WireLength ?? 0,
                            //WireCondition = pl.WireConditionId ?? 0,
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pl => pl.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSpcCount = k.Count(p => p.PoleType.Equals("1")),
                            totalSpCount = k.Count(p => p.PoleType.Equals("2")),
                            totalTowerCount = k.Count(p => p.PoleType.Equals("3")),
                            totalOthersCount = k.Count(p => p.PoleType.Equals("4")),

                            totalAgedCount = k.Count(p => p.PoleCondition.Equals("ag")),
                            totalBadCount = k.Count(p => p.PoleCondition.Equals("b")),
                            totalBrokenCount = k.Count(p => p.PoleCondition.Equals("br")),
                            totalGoodCount = k.Count(p => p.PoleCondition.Equals("g")),

                            totalNeutralPole = k.Count(p => p.Neutral.Equals("y")),
                            totalStreetLight = k.Count(p => p.StreetLight.Equals("y")),

                            totalWireLength = Math.Round(k.Sum(d => d.WireLength) / 1000, 0),
                        })
                        .ToList();


                    var regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join pl in plInfo on rg.regionCode equals pl.regionCode into rpl
                            from pl in rpl.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                pl?.totalCount,

                                pl?.totalSpcCount,
                                pl?.totalSpCount,
                                pl?.totalTowerCount,
                                pl?.totalOthersCount,

                                pl?.totalAgedCount,
                                pl?.totalBadCount,
                                pl?.totalBrokenCount,
                                pl?.totalGoodCount,

                                pl?.totalNeutralPole,
                                pl?.totalStreetLight,

                                pl?.totalWireLength
                            })
                            .ToList();

                    break;


                case "circle":

                    plInfo = qry
                        .Select(pl => new
                        {
                            RegionCode = pl.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode,
                            PoleType = pl.PoleTypeId != null ? pl.PoleTypeId.ToLower() : "",
                            PoleCondition = pl.PoleTypeId != null ? pl.PoleConditionId.ToLower() : "",
                            Neutral = pl.Neutral != null ? pl.Neutral.ToLower() : "",
                            StreetLight = pl.StreetLight != null ? pl.StreetLight.ToLower() : "",
                            WireLength = pl.WireLength ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pl => pl.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSpcCount = k.Count(p => p.PoleType.Equals("1")),
                            totalSpCount = k.Count(p => p.PoleType.Equals("2")),
                            totalTowerCount = k.Count(p => p.PoleType.Equals("3")),
                            totalOthersCount = k.Count(p => p.PoleType.Equals("4")),

                            totalAgedCount = k.Count(p => p.PoleCondition.Equals("ag")),
                            totalBadCount = k.Count(p => p.PoleCondition.Equals("b")),
                            totalBrokenCount = k.Count(p => p.PoleCondition.Equals("br")),
                            totalGoodCount = k.Count(p => p.PoleCondition.Equals("g")),

                            totalNeutralPole = k.Count(p => p.Neutral.Equals("y")),
                            totalStreetLight = k.Count(p => p.StreetLight.Equals("y")),

                            totalWireLength = Math.Round(k.Sum(d => d.WireLength) / 1000, 0),
                        })
                        .ToList();


                    regions = _context.LookUpCircleInfo
                        .Where(c => (zoneCode.Equals("") || c.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || c.CircleCode.Equals(circleCode)))
                        .Include(z => z.ZoneInfo)
                        .Select(c => new
                        {
                            regionCode = c.CircleCode,
                            zoneName = c.ZoneInfo.ZoneName,
                            circleName = c.CircleName,
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join pl in plInfo on rg.regionCode equals pl.regionCode into rpl
                            from pl in rpl.DefaultIfEmpty()
                            select new
                            {
                                circleCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,

                                pl?.totalCount,

                                pl?.totalSpcCount,
                                pl?.totalSpCount,
                                pl?.totalTowerCount,
                                pl?.totalOthersCount,

                                pl?.totalAgedCount,
                                pl?.totalBadCount,
                                pl?.totalBrokenCount,
                                pl?.totalGoodCount,

                                pl?.totalNeutralPole,
                                pl?.totalStreetLight,

                                pl?.totalWireLength
                            })
                        .ToList();

                    break;


                case "snd":

                    plInfo = qry
                        .Select(pl => new
                        {
                            RegionCode = pl.PoleToRoute.RouteToSubstation.SnDCode,
                            PoleType = pl.PoleTypeId != null ? pl.PoleTypeId.ToLower() : "",
                            PoleCondition = pl.PoleTypeId != null ? pl.PoleConditionId.ToLower() : "",
                            Neutral = pl.Neutral != null ? pl.Neutral.ToLower() : "",
                            StreetLight = pl.StreetLight != null ? pl.StreetLight.ToLower() : "",
                            WireLength = pl.WireLength ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pl => pl.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSpcCount = k.Count(p => p.PoleType.Equals("1")),
                            totalSpCount = k.Count(p => p.PoleType.Equals("2")),
                            totalTowerCount = k.Count(p => p.PoleType.Equals("3")),
                            totalOthersCount = k.Count(p => p.PoleType.Equals("4")),

                            totalAgedCount = k.Count(p => p.PoleCondition.Equals("ag")),
                            totalBadCount = k.Count(p => p.PoleCondition.Equals("b")),
                            totalBrokenCount = k.Count(p => p.PoleCondition.Equals("br")),
                            totalGoodCount = k.Count(p => p.PoleCondition.Equals("g")),

                            totalNeutralPole = k.Count(p => p.Neutral.Equals("y")),
                            totalStreetLight = k.Count(p => p.StreetLight.Equals("y")),

                            totalWireLength = Math.Round(k.Sum(d => d.WireLength) / 1000, 0),
                        })
                        .ToList();


                    regions = _context.LookUpSnDInfo
                        .Where(d => (zoneCode.Equals("") || d.CircleInfo.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || d.CircleCode.Equals(circleCode))
                                    && (snDCode.Equals("") || d.SnDCode.Equals(snDCode)))
                        .Include(z => z.CircleInfo.ZoneInfo)
                        .Select(d => new
                        {
                            regionCode = d.SnDCode,
                            zoneName = d.CircleInfo.ZoneInfo.ZoneName,
                            circleName = d.CircleInfo.CircleName,
                            sndName = d.SnDName,
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join pl in plInfo on rg.regionCode equals pl.regionCode into rpl
                            from pl in rpl.DefaultIfEmpty()
                            select new
                            {
                                sndCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,

                                pl?.totalCount,

                                pl?.totalSpcCount,
                                pl?.totalSpCount,
                                pl?.totalTowerCount,
                                pl?.totalOthersCount,

                                pl?.totalAgedCount,
                                pl?.totalBadCount,
                                pl?.totalBrokenCount,
                                pl?.totalGoodCount,

                                pl?.totalNeutralPole,
                                pl?.totalStreetLight,

                                pl?.totalWireLength
                            })
                        .ToList();

                    break;


                case "substation":

                    plInfo = qry
                        .Select(pl => new
                        {
                            RegionCode = pl.PoleToRoute.SubstationId,
                            PoleType = pl.PoleTypeId != null ? pl.PoleTypeId.ToLower() : "",
                            PoleCondition = pl.PoleTypeId != null ? pl.PoleConditionId.ToLower() : "",
                            Neutral = pl.Neutral != null ? pl.Neutral.ToLower() : "",
                            StreetLight = pl.StreetLight != null ? pl.StreetLight.ToLower() : "",
                            WireLength = pl.WireLength ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pl => pl.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSpcCount = k.Count(p => p.PoleType.Equals("1")),
                            totalSpCount = k.Count(p => p.PoleType.Equals("2")),
                            totalTowerCount = k.Count(p => p.PoleType.Equals("3")),
                            totalOthersCount = k.Count(p => p.PoleType.Equals("4")),

                            totalAgedCount = k.Count(p => p.PoleCondition.Equals("ag")),
                            totalBadCount = k.Count(p => p.PoleCondition.Equals("b")),
                            totalBrokenCount = k.Count(p => p.PoleCondition.Equals("br")),
                            totalGoodCount = k.Count(p => p.PoleCondition.Equals("g")),

                            totalNeutralPole = k.Count(p => p.Neutral.Equals("y")),
                            totalStreetLight = k.Count(p => p.StreetLight.Equals("y")),

                            totalWireLength = Math.Round(k.Sum(d => d.WireLength) / 1000, 0),
                        })
                        .ToList();


                    regions = _context.TblSubstation
                        .Where(s =>
                            (zoneCode.Equals("") || s.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                            && (circleCode.Equals("") || s.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                            && (snDCode.Equals("") || s.SnDCode.Equals(snDCode))
                            && (substationCode.Equals("") || s.SubstationId.Equals(substationCode)))
                        .Include(z => z.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .Select(s => new
                        {
                            regionCode = s.SubstationId,
                            zoneName = s.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = s.SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndName = s.SubstationToLookUpSnD.SnDName,
                            substationName = s.SubstationName,
                        })
                        .ToList();

                    data = (from rg in regions
                            join pl in plInfo on rg.regionCode equals pl.regionCode into rpl
                            from pl in rpl.DefaultIfEmpty()
                            select new
                            {
                                substationCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,
                                rg.substationName,

                                pl?.totalCount,

                                pl?.totalSpcCount,
                                pl?.totalSpCount,
                                pl?.totalTowerCount,
                                pl?.totalOthersCount,

                                pl?.totalAgedCount,
                                pl?.totalBadCount,
                                pl?.totalBrokenCount,
                                pl?.totalGoodCount,

                                pl?.totalNeutralPole,
                                pl?.totalStreetLight,

                                pl?.totalWireLength
                            })
                        .ToList();

                    break;


                default:

                    plInfo = qry
                        .Select(pl => new
                        {
                            RegionCode = pl.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            PoleType = pl.PoleTypeId != null ? pl.PoleTypeId.ToLower() : "",
                            PoleCondition = pl.PoleTypeId != null ? pl.PoleConditionId.ToLower() : "",
                            Neutral = pl.Neutral != null ? pl.Neutral.ToLower() : "",
                            StreetLight = pl.StreetLight != null ? pl.StreetLight.ToLower() : "",
                            WireLength = pl.WireLength ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pl => pl.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSpcCount = k.Count(p => p.PoleType.Equals("1")),
                            totalSpCount = k.Count(p => p.PoleType.Equals("2")),
                            totalTowerCount = k.Count(p => p.PoleType.Equals("3")),
                            totalOthersCount = k.Count(p => p.PoleType.Equals("4")),

                            totalAgedCount = k.Count(p => p.PoleCondition.Equals("ag")),
                            totalBadCount = k.Count(p => p.PoleCondition.Equals("b")),
                            totalBrokenCount = k.Count(p => p.PoleCondition.Equals("br")),
                            totalGoodCount = k.Count(p => p.PoleCondition.Equals("g")),

                            totalNeutralPole = k.Count(p => p.Neutral.Equals("y")),
                            totalStreetLight = k.Count(p => p.StreetLight.Equals("y")),

                            totalWireLength = Math.Round(k.Sum(d => d.WireLength) / 1000, 0),
                        })
                        .ToList();


                    regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join pl in plInfo on rg.regionCode equals pl.regionCode into rpl
                            from pl in rpl.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                pl?.totalCount,

                                pl?.totalSpcCount,
                                pl?.totalSpCount,
                                pl?.totalTowerCount,
                                pl?.totalOthersCount,

                                pl?.totalAgedCount,
                                pl?.totalBadCount,
                                pl?.totalBrokenCount,
                                pl?.totalGoodCount,

                                pl?.totalNeutralPole,
                                pl?.totalStreetLight,

                                pl?.totalWireLength
                            })
                        .ToList();

                    break;
            }

            return Json(data);
        }

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
                new ReportField {Name = "total33kCount", Title = "33KV Feeder Line", Selected = true},
                new ReportField {Name = "total11kCount", Title = "11KV Feeder Line", Selected = true},
                //new ReportField {Name = "totalP4Count", Title = ".4KV Feeder Line", Selected = true},

                new ReportField {Name = "totalFeederLength", Title = "Feeder Length (Km)", Selected = true},
                new ReportField {Name = "total33kFeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                new ReportField {Name = "total11kFeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
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
                    new ReportField {Name = "total33kCount", Title = "33KV Feeder Line", Selected = true},
                    new ReportField {Name = "total11kCount", Title = "11KV Feeder Line", Selected = true},
                    //new ReportField {Name = "totalP4Count", Title = ".4KV Feeder Line", Selected = true},

                    new ReportField {Name = "totalFeederLength", Title = "Feeder Length (Km)", Selected = true},
                    new ReportField {Name = "total33kFeederLength", Title = "33KV Feeder Length (Km)", Selected = true},
                    new ReportField {Name = "total11kFeederLength", Title = "11KV Feeder Length (Km)", Selected = true},
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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);
                            }
                        }
                    }
                }
            }

            var qry = searchExp != null
                ? _context.TblFeederLine
                    .Include(fl => fl.Poles)
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblFeederLine
                    .Include(fl => fl.Poles)
                    .AsNoTracking();


            object data;

            switch (regionLevel)
            {
                case "zone":

                    var flInfo = qry
                        .Select(f => new
                        {
                            RegionCode = f.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            FeederType = f.FeederLineTypeId != null ? f.FeederLineType.FeederLineTypeName : "",
                            //FeederType = f.NominalVoltage.ToString(),
                            FeederLength = f.Poles.Sum(p => p.WireLength ?? 0),
                            //FeederLength = f.Poles.Where(p => p.FeederLineId == f.FeederLineId).Sum(p => p.WireLength ?? 0),
                            //FeederLength = f.FeederLength,
                            MaximumDemand = f.MaximumDemand ?? 0,
                            PeakDemand = f.PeakDemand ?? 0,
                            MaximumLoad = f.MaximumLoad ?? 0,
                            SanctionedLoad = f.SanctionedLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            total11kCount = k.Count(f => f.FeederType.Contains("11")),
                            total33kCount = k.Count(f => f.FeederType.Contains("33")),

                            totalFeederLength = Math.Round(k.Sum(f => f.FeederLength) / 1000, 0),
                            total11kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("11") ? f.FeederLength : 0) / 1000, 0),
                            total33kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("33") ? f.FeederLength : 0) / 1000, 0),

                            totalMaxDemand = k.Sum(f => f.MaximumDemand),
                            totalPeakDemand = k.Sum(f => f.PeakDemand),
                            totalMaxLoad = k.Sum(f => f.MaximumLoad),
                            totalSanctionedLoad = k.Sum(f => f.SanctionedLoad)
                        })
                        .ToList();


                    var regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join fl in flInfo on rg.regionCode equals fl.regionCode into rfl
                            from fl in rfl.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                fl?.totalCount,
                                fl?.total11kCount,
                                fl?.total33kCount,

                                fl?.totalFeederLength,
                                fl?.total11kFeederLength,
                                fl?.total33kFeederLength,

                                fl?.totalMaxDemand,
                                fl?.totalPeakDemand,
                                fl?.totalMaxLoad,
                                fl?.totalSanctionedLoad
                            })
                        .ToList();

                    break;


                case "circle":

                    flInfo = qry
                        .Select(f => new
                        {
                            RegionCode = f.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode,
                            FeederType = f.FeederLineTypeId != null ? f.FeederLineType.FeederLineTypeName : "",
                            //FeederType = f.NominalVoltage.ToString(),
                            FeederLength = f.Poles.Sum(p => p.WireLength ?? 0),
                            //FeederLength = f.FeederLength,
                            MaximumDemand = f.MaximumDemand ?? 0,
                            PeakDemand = f.PeakDemand ?? 0,
                            MaximumLoad = f.MaximumLoad ?? 0,
                            SanctionedLoad = f.SanctionedLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            total11kCount = k.Count(f => f.FeederType.Contains("11")),
                            total33kCount = k.Count(f => f.FeederType.Contains("33")),

                            totalFeederLength = Math.Round(k.Sum(f => f.FeederLength) / 1000, 0),
                            total11kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("11") ? f.FeederLength : 0) / 1000, 0),
                            total33kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("33") ? f.FeederLength : 0) / 1000, 0),

                            totalMaxDemand = k.Sum(f => f.MaximumDemand),
                            totalPeakDemand = k.Sum(f => f.PeakDemand),
                            totalMaxLoad = k.Sum(f => f.MaximumLoad),
                            totalSanctionedLoad = k.Sum(f => f.SanctionedLoad)
                        })
                        .ToList();


                    regions = _context.LookUpCircleInfo
                        .Where(c => (zoneCode.Equals("") || c.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || c.CircleCode.Equals(circleCode)))
                        .Include(z => z.ZoneInfo)
                        .Select(c => new
                        {
                            regionCode = c.CircleCode,
                            zoneName = c.ZoneInfo.ZoneName,
                            circleName = c.CircleName,
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join fl in flInfo on rg.regionCode equals fl.regionCode into rfl
                            from fl in rfl.DefaultIfEmpty()
                            select new
                            {
                                circleCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,

                                fl?.totalCount,
                                fl?.total11kCount,
                                fl?.total33kCount,

                                fl?.totalFeederLength,
                                fl?.total11kFeederLength,
                                fl?.total33kFeederLength,

                                fl?.totalMaxDemand,
                                fl?.totalPeakDemand,
                                fl?.totalMaxLoad,
                                fl?.totalSanctionedLoad
                            })
                        .ToList();

                    break;


                case "snd":

                    flInfo = qry
                        .Select(f => new
                        {
                            RegionCode = f.FeederLineToRoute.RouteToSubstation.SnDCode,
                            FeederType = f.FeederLineTypeId != null ? f.FeederLineType.FeederLineTypeName : "",
                            //FeederType = f.NominalVoltage.ToString(),
                            FeederLength = f.Poles.Sum(p => p.WireLength ?? 0),
                            //FeederLength = f.FeederLength,
                            MaximumDemand = f.MaximumDemand ?? 0,
                            PeakDemand = f.PeakDemand ?? 0,
                            MaximumLoad = f.MaximumLoad ?? 0,
                            SanctionedLoad = f.SanctionedLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            total11kCount = k.Count(f => f.FeederType.Contains("11")),
                            total33kCount = k.Count(f => f.FeederType.Contains("33")),

                            totalFeederLength = Math.Round(k.Sum(f => f.FeederLength) / 1000, 0),
                            total11kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("11") ? f.FeederLength : 0) / 1000, 0),
                            total33kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("33") ? f.FeederLength : 0) / 1000, 0),

                            totalMaxDemand = k.Sum(f => f.MaximumDemand),
                            totalPeakDemand = k.Sum(f => f.PeakDemand),
                            totalMaxLoad = k.Sum(f => f.MaximumLoad),
                            totalSanctionedLoad = k.Sum(f => f.SanctionedLoad)
                        })
                        .ToList();


                    regions = _context.LookUpSnDInfo
                        .Where(d => (zoneCode.Equals("") || d.CircleInfo.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || d.CircleCode.Equals(circleCode))
                                    && (snDCode.Equals("") || d.SnDCode.Equals(snDCode)))
                        .Include(z => z.CircleInfo.ZoneInfo)
                        .Select(d => new
                        {
                            regionCode = d.SnDCode,
                            zoneName = d.CircleInfo.ZoneInfo.ZoneName,
                            circleName = d.CircleInfo.CircleName,
                            sndName = d.SnDName,
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join fl in flInfo on rg.regionCode equals fl.regionCode into rfl
                            from fl in rfl.DefaultIfEmpty()
                            select new
                            {
                                sndCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,

                                fl?.totalCount,
                                fl?.total11kCount,
                                fl?.total33kCount,

                                fl?.totalFeederLength,
                                fl?.total11kFeederLength,
                                fl?.total33kFeederLength,

                                fl?.totalMaxDemand,
                                fl?.totalPeakDemand,
                                fl?.totalMaxLoad,
                                fl?.totalSanctionedLoad
                            })
                        .ToList();

                    break;


                case "substation":

                    flInfo = qry
                        .Select(f => new
                        {
                            RegionCode = f.FeederLineToRoute.SubstationId,
                            FeederType = f.FeederLineTypeId != null ? f.FeederLineType.FeederLineTypeName : "",
                            //FeederType = f.NominalVoltage.ToString(),
                            FeederLength = f.Poles.Sum(p => p.WireLength ?? 0),
                            //FeederLength = f.FeederLength,
                            MaximumDemand = f.MaximumDemand ?? 0,
                            PeakDemand = f.PeakDemand ?? 0,
                            MaximumLoad = f.MaximumLoad ?? 0,
                            SanctionedLoad = f.SanctionedLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            total11kCount = k.Count(f => f.FeederType.Contains("11")),
                            total33kCount = k.Count(f => f.FeederType.Contains("33")),

                            totalFeederLength = Math.Round(k.Sum(f => f.FeederLength) / 1000, 0),
                            total11kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("11") ? f.FeederLength : 0) / 1000, 0),
                            total33kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("33") ? f.FeederLength : 0) / 1000, 0),

                            totalMaxDemand = k.Sum(f => f.MaximumDemand),
                            totalPeakDemand = k.Sum(f => f.PeakDemand),
                            totalMaxLoad = k.Sum(f => f.MaximumLoad),
                            totalSanctionedLoad = k.Sum(f => f.SanctionedLoad)
                        })
                        .ToList();


                    regions = _context.TblSubstation
                        .Where(s =>
                            (zoneCode.Equals("") || s.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                            && (circleCode.Equals("") || s.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                            && (snDCode.Equals("") || s.SnDCode.Equals(snDCode))
                            && (substationCode.Equals("") || s.SubstationId.Equals(substationCode)))
                        .Include(z => z.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .Select(s => new
                        {
                            regionCode = s.SubstationId,
                            zoneName = s.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = s.SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndName = s.SubstationToLookUpSnD.SnDName,
                            substationName = s.SubstationName,
                        })
                        .ToList();

                    data = (from rg in regions
                            join fl in flInfo on rg.regionCode equals fl.regionCode into rfl
                            from fl in rfl.DefaultIfEmpty()
                            select new
                            {
                                substationCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,
                                rg.substationName,

                                fl?.totalCount,
                                fl?.total11kCount,
                                fl?.total33kCount,

                                fl?.totalFeederLength,
                                fl?.total11kFeederLength,
                                fl?.total33kFeederLength,

                                fl?.totalMaxDemand,
                                fl?.totalPeakDemand,
                                fl?.totalMaxLoad,
                                fl?.totalSanctionedLoad
                            })
                        .ToList();

                    break;


                default:

                    flInfo = qry
                        .Select(f => new
                        {
                            RegionCode = f.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            FeederType = f.FeederLineTypeId != null ? f.FeederLineType.FeederLineTypeName : "",
                            //FeederType = f.NominalVoltage.ToString(),
                            FeederLength = f.Poles.Sum(p => p.WireLength ?? 0),
                            //FeederLength = f.FeederLength,
                            MaximumDemand = f.MaximumDemand ?? 0,
                            PeakDemand = f.PeakDemand ?? 0,
                            MaximumLoad = f.MaximumLoad ?? 0,
                            SanctionedLoad = f.SanctionedLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            total11kCount = k.Count(f => f.FeederType.Contains("11")),
                            total33kCount = k.Count(f => f.FeederType.Contains("33")),

                            totalFeederLength = Math.Round(k.Sum(f => f.FeederLength) / 1000, 0),
                            total11kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("11") ? f.FeederLength : 0) / 1000, 0),
                            total33kFeederLength =
                                Math.Round(k.Sum(f => f.FeederType.Contains("33") ? f.FeederLength : 0) / 1000, 0),

                            totalMaxDemand = k.Sum(f => f.MaximumDemand),
                            totalPeakDemand = k.Sum(f => f.PeakDemand),
                            totalMaxLoad = k.Sum(f => f.MaximumLoad),
                            totalSanctionedLoad = k.Sum(f => f.SanctionedLoad)
                        })
                        .ToList();


                    regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join fl in flInfo on rg.regionCode equals fl.regionCode into rfl
                            from fl in rfl.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                fl?.totalCount,
                                fl?.total11kCount,
                                fl?.total33kCount,

                                fl?.totalFeederLength,
                                fl?.total11kFeederLength,
                                fl?.total33kFeederLength,

                                fl?.totalMaxDemand,
                                fl?.totalPeakDemand,
                                fl?.totalMaxLoad,
                                fl?.totalSanctionedLoad
                            })
                        .ToList();

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
                new ReportField {Name = "total11kCount", Title = "33/11 kV Substation", Selected = true},
                new ReportField {Name = "total33kCount", Title = "132/33 kV Substation", Selected = true},
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
                    new ReportField {Name = "total11kCount", Title = "33/11 kV Substation", Selected = true},
                    new ReportField {Name = "total33kCount", Title = "132/33 kV Substation", Selected = true},
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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "";

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

                            //if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            //{
                            //    routeCode = regionList[4];

                            //    tempExp = model => model.RouteCode == routeCode;
                            //    searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                            //}
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

                    var ssInfo = qry
                        .Select(s => new
                        {
                            RegionCode = s.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            SubstationType = s.SubstationTypeId != null ? s.SubstationType.SubstationTypeName : "",
                            CapacityMin = s.TotalCapacity.Min,
                            CapacityMax = s.TotalCapacity.Max,
                            MaximumDemand = s.MaximumDemand ?? 0,
                            PeakLoad = s.PeakLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(s => s.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,
                            totalCount = k.Count(),

                            total11kCount = k.Count(s => s.SubstationType.Contains("/11")),
                            total33kCount = k.Count(s => s.SubstationType.Contains("/33")),

                            totalCapacity = k.Sum(s => s.CapacityMin).ToString("0.##") + "/" +
                                            k.Sum(s => s.CapacityMax).ToString("0.##"),

                            totalDemand = k.Sum(s => s.MaximumDemand),
                            totalPeakLoad = k.Sum(s => s.PeakLoad),
                            maxPeakLoad = k.Max(s => s.PeakLoad),
                            minPeakLoad = k.Min(s => s.PeakLoad),
                        })
                        .ToList();


                    var regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join ss in ssInfo on rg.regionCode equals ss.regionCode into rss
                            from ss in rss.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                ss?.totalCount,
                                ss?.total11kCount,
                                ss?.total33kCount,

                                ss?.totalCapacity,

                                ss?.totalDemand,
                                ss?.totalPeakLoad,
                                ss?.maxPeakLoad,
                                ss?.minPeakLoad
                            })
                        .ToList();

                    break;


                case "circle":

                    ssInfo = qry
                        .Select(s => new
                        {
                            RegionCode = s.SubstationToLookUpSnD.CircleCode,
                            SubstationType = s.SubstationTypeId != null ? s.SubstationType.SubstationTypeName : "",
                            CapacityMin = s.TotalCapacity.Min,
                            CapacityMax = s.TotalCapacity.Max,
                            MaximumDemand = s.MaximumDemand ?? 0,
                            PeakLoad = s.PeakLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(s => s.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,
                            totalCount = k.Count(),

                            total11kCount = k.Count(s => s.SubstationType.Contains("/11")),
                            total33kCount = k.Count(s => s.SubstationType.Contains("/33")),

                            totalCapacity = k.Sum(s => s.CapacityMin).ToString("0.##") + "/" +
                                            k.Sum(s => s.CapacityMax).ToString("0.##"),

                            totalDemand = k.Sum(s => s.MaximumDemand),
                            totalPeakLoad = k.Sum(s => s.PeakLoad),
                            maxPeakLoad = k.Max(s => s.PeakLoad),
                            minPeakLoad = k.Min(s => s.PeakLoad),
                        })
                        .ToList();


                    regions = _context.LookUpCircleInfo
                        .Where(c => (zoneCode.Equals("") || c.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || c.CircleCode.Equals(circleCode)))
                        .Include(z => z.ZoneInfo)
                        .Select(c => new
                        {
                            regionCode = c.CircleCode,
                            zoneName = c.ZoneInfo.ZoneName,
                            circleName = c.CircleName,
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join ss in ssInfo on rg.regionCode equals ss.regionCode into rss
                            from ss in rss.DefaultIfEmpty()
                            select new
                            {
                                circleCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,

                                ss?.totalCount,
                                ss?.total11kCount,
                                ss?.total33kCount,

                                ss?.totalCapacity,

                                ss?.totalDemand,
                                ss?.totalPeakLoad,
                                ss?.maxPeakLoad,
                                ss?.minPeakLoad
                            })
                        .ToList();

                    break;


                case "snd":

                    ssInfo = qry
                        .Select(s => new
                        {
                            RegionCode = s.SnDCode,
                            SubstationType = s.SubstationTypeId != null ? s.SubstationType.SubstationTypeName : "",
                            CapacityMin = s.TotalCapacity.Min,
                            CapacityMax = s.TotalCapacity.Max,
                            MaximumDemand = s.MaximumDemand ?? 0,
                            PeakLoad = s.PeakLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(s => s.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,
                            totalCount = k.Count(),

                            total11kCount = k.Count(s => s.SubstationType.Contains("/11")),
                            total33kCount = k.Count(s => s.SubstationType.Contains("/33")),

                            totalCapacity = k.Sum(s => s.CapacityMin).ToString("0.##") + "/" +
                                            k.Sum(s => s.CapacityMax).ToString("0.##"),

                            totalDemand = k.Sum(s => s.MaximumDemand),
                            totalPeakLoad = k.Sum(s => s.PeakLoad),
                            maxPeakLoad = k.Max(s => s.PeakLoad),
                            minPeakLoad = k.Min(s => s.PeakLoad),
                        })
                        .ToList();


                    regions = _context.LookUpSnDInfo
                        .Where(d => (zoneCode.Equals("") || d.CircleInfo.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || d.CircleCode.Equals(circleCode))
                                    && (snDCode.Equals("") || d.SnDCode.Equals(snDCode)))
                        .Include(z => z.CircleInfo.ZoneInfo)
                        .Select(d => new
                        {
                            regionCode = d.SnDCode,
                            zoneName = d.CircleInfo.ZoneInfo.ZoneName,
                            circleName = d.CircleInfo.CircleName,
                            sndName = d.SnDName,
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join ss in ssInfo on rg.regionCode equals ss.regionCode into rss
                            from ss in rss.DefaultIfEmpty()
                            select new
                            {
                                sndCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,

                                ss?.totalCount,
                                ss?.total11kCount,
                                ss?.total33kCount,

                                ss?.totalCapacity,

                                ss?.totalDemand,
                                ss?.totalPeakLoad,
                                ss?.maxPeakLoad,
                                ss?.minPeakLoad
                            })
                        .ToList();

                    break;


                case "substation":

                    ssInfo = qry
                        .Select(s => new
                        {
                            RegionCode = s.SubstationId,
                            SubstationType = s.SubstationTypeId != null ? s.SubstationType.SubstationTypeName : "",
                            CapacityMin = s.TotalCapacity.Min,
                            CapacityMax = s.TotalCapacity.Max,
                            MaximumDemand = s.MaximumDemand ?? 0,
                            PeakLoad = s.PeakLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(s => s.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,
                            totalCount = k.Count(),

                            total11kCount = k.Count(s => s.SubstationType.Contains("/11")),
                            total33kCount = k.Count(s => s.SubstationType.Contains("/33")),

                            totalCapacity = k.Sum(s => s.CapacityMin).ToString("0.##") + "/" +
                                            k.Sum(s => s.CapacityMax).ToString("0.##"),

                            totalDemand = k.Sum(s => s.MaximumDemand),
                            totalPeakLoad = k.Sum(s => s.PeakLoad),
                            maxPeakLoad = k.Max(s => s.PeakLoad),
                            minPeakLoad = k.Min(s => s.PeakLoad),
                        })
                        .ToList();


                    regions = _context.TblSubstation
                        .Where(s =>
                            (zoneCode.Equals("") || s.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                            && (circleCode.Equals("") || s.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                            && (snDCode.Equals("") || s.SnDCode.Equals(snDCode))
                            && (substationCode.Equals("") || s.SubstationId.Equals(substationCode)))
                        .Include(z => z.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .Select(s => new
                        {
                            regionCode = s.SubstationId,
                            zoneName = s.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = s.SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndName = s.SubstationToLookUpSnD.SnDName,
                            substationName = s.SubstationName,
                        })
                        .ToList();

                    data = (from rg in regions
                            join ss in ssInfo on rg.regionCode equals ss.regionCode into rss
                            from ss in rss.DefaultIfEmpty()
                            select new
                            {
                                substationCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,
                                rg.substationName,

                                ss?.totalCount,
                                ss?.total11kCount,
                                ss?.total33kCount,

                                ss?.totalCapacity,

                                ss?.totalDemand,
                                ss?.totalPeakLoad,
                                ss?.maxPeakLoad,
                                ss?.minPeakLoad
                            })
                        .ToList();

                    break;

                default:

                    ssInfo = qry
                        .Select(s => new
                        {
                            RegionCode = s.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            SubstationType = s.SubstationTypeId != null ? s.SubstationType.SubstationTypeName : "",
                            CapacityMin = s.TotalCapacity.Min,
                            CapacityMax = s.TotalCapacity.Max,
                            MaximumDemand = s.MaximumDemand ?? 0,
                            PeakLoad = s.PeakLoad ?? 0
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(s => s.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,
                            totalCount = k.Count(),

                            total11kCount = k.Count(s => s.SubstationType.Contains("/11")),
                            total33kCount = k.Count(s => s.SubstationType.Contains("/33")),

                            totalCapacity = k.Sum(s => s.CapacityMin).ToString("0.##") + "/" +
                                            k.Sum(s => s.CapacityMax).ToString("0.##"),

                            totalDemand = k.Sum(s => s.MaximumDemand),
                            totalPeakLoad = k.Sum(s => s.PeakLoad),
                            maxPeakLoad = k.Max(s => s.PeakLoad),
                            minPeakLoad = k.Min(s => s.PeakLoad),
                        })
                        .ToList();


                    regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join ss in ssInfo on rg.regionCode equals ss.regionCode into rss
                            from ss in rss.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                ss?.totalCount,
                                ss?.total11kCount,
                                ss?.total33kCount,

                                ss?.totalCapacity,

                                ss?.totalDemand,
                                ss?.totalPeakLoad,
                                ss?.maxPeakLoad,
                                ss?.minPeakLoad
                            })
                        .ToList();

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

            var fieldList = new List<ReportField>(16)
            {
                new ReportField {Name = "totalCount", Title = "Total DT", Selected = true},
                //new ReportField {Name = "total33kCount", Title = "33KV DT", Selected = true},
                //new ReportField {Name = "total11kCount", Title = "11KV DT", Selected = true},
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
                    //new ReportField {Name = "total33kCount", Title = "33KV DT", Selected = true},
                    //new ReportField {Name = "total11kCount", Title = "11KV DT", Selected = true},
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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.DtToFeederLine.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);
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

                    var dtInfo = qry
                        .Select(dt => new
                        {
                            RegionCode = dt.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            InstalledCondition = dt.InstalledConditionPadbsPoleMounted != null ? dt.InstalledConditionPadbsPoleMounted.ToLower() : "",
                            InstalledPlace = dt.InstalledPlaceIndoorbsOutdoor != null ? dt.InstalledPlaceIndoorbsOutdoor.ToLower() : "",
                            Owner = dt.OwneroftheTransformerBPDBbsConsumer != null ? dt.OwneroftheTransformerBPDBbsConsumer.ToLower() : "",
                            OilLeakage = dt.OilLeakageYesOrNo != null ? dt.OilLeakageYesOrNo.ToLower() : "",
                            PlatformMaterial = dt.PlatformMaterialAnglbsChannel != null ? dt.PlatformMaterialAnglbsChannel.ToLower() : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(dt => dt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(dt => dt.InstalledCondition.Contains("pad")),
                            totalIcPoleMountCount = k.Count(dt => dt.InstalledCondition.Contains("pole")),

                            totalIpIndoorCount = k.Count(dt => dt.InstalledPlace.Contains("indoor")),
                            totalIpOutdoorCount = k.Count(dt => dt.InstalledPlace.Contains("outdoor")),

                            totalBpdbDtCount = k.Count(dt => dt.Owner.Contains("bpdb")),
                            totalConsumerDtCount = k.Count(dt => dt.Owner.Contains("consumer")),

                            totalOlYesCount = k.Count(dt => dt.OilLeakage.Contains("yes")),
                            totalOlNoCount = k.Count(dt => dt.OilLeakage.Contains("no")),

                            totalPmAngleCount = k.Count(dt => dt.PlatformMaterial.Contains("angle")),
                            totalPmChannelCount = k.Count(dt => dt.PlatformMaterial.Contains("channel")),
                        })
                        .ToList();


                    var regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join dt in dtInfo on rg.regionCode equals dt.regionCode into rdt
                            from dt in rdt.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                dt?.totalCount,
                                dt?.totalIcPadCount,
                                dt?.totalIcPoleMountCount,

                                dt?.totalIpIndoorCount,
                                dt?.totalIpOutdoorCount,

                                dt?.totalBpdbDtCount,
                                dt?.totalConsumerDtCount,

                                dt?.totalOlYesCount,
                                dt?.totalOlNoCount,

                                dt?.totalPmAngleCount,
                                dt?.totalPmChannelCount,
                            })
                        .ToList();

                    break;


                case "circle":

                    dtInfo = qry
                        .Select(dt => new
                        {
                            RegionCode = dt.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode,
                            InstalledCondition = dt.InstalledConditionPadbsPoleMounted != null ? dt.InstalledConditionPadbsPoleMounted.ToLower() : "",
                            InstalledPlace = dt.InstalledPlaceIndoorbsOutdoor != null ? dt.InstalledPlaceIndoorbsOutdoor.ToLower() : "",
                            Owner = dt.OwneroftheTransformerBPDBbsConsumer != null ? dt.OwneroftheTransformerBPDBbsConsumer.ToLower() : "",
                            OilLeakage = dt.OilLeakageYesOrNo != null ? dt.OilLeakageYesOrNo.ToLower() : "",
                            PlatformMaterial = dt.PlatformMaterialAnglbsChannel != null ? dt.PlatformMaterialAnglbsChannel.ToLower() : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(dt => dt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(dt => dt.InstalledCondition.Contains("pad")),
                            totalIcPoleMountCount = k.Count(dt => dt.InstalledCondition.Contains("pole")),

                            totalIpIndoorCount = k.Count(dt => dt.InstalledPlace.Contains("indoor")),
                            totalIpOutdoorCount = k.Count(dt => dt.InstalledPlace.Contains("outdoor")),

                            totalBpdbDtCount = k.Count(dt => dt.Owner.Contains("bpdb")),
                            totalConsumerDtCount = k.Count(dt => dt.Owner.Contains("consumer")),

                            totalOlYesCount = k.Count(dt => dt.OilLeakage.Contains("yes")),
                            totalOlNoCount = k.Count(dt => dt.OilLeakage.Contains("no")),

                            totalPmAngleCount = k.Count(dt => dt.PlatformMaterial.Contains("angle")),
                            totalPmChannelCount = k.Count(dt => dt.PlatformMaterial.Contains("channel")),
                        })
                        .ToList();


                    regions = _context.LookUpCircleInfo
                        .Where(c => (zoneCode.Equals("") || c.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || c.CircleCode.Equals(circleCode)))
                        .Include(z => z.ZoneInfo)
                        .Select(c => new
                        {
                            regionCode = c.CircleCode,
                            zoneName = c.ZoneInfo.ZoneName,
                            circleName = c.CircleName,
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join dt in dtInfo on rg.regionCode equals dt.regionCode into rdt
                            from dt in rdt.DefaultIfEmpty()
                            select new
                            {
                                circleCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,

                                dt?.totalCount,
                                dt?.totalIcPadCount,
                                dt?.totalIcPoleMountCount,

                                dt?.totalIpIndoorCount,
                                dt?.totalIpOutdoorCount,

                                dt?.totalBpdbDtCount,
                                dt?.totalConsumerDtCount,

                                dt?.totalOlYesCount,
                                dt?.totalOlNoCount,

                                dt?.totalPmAngleCount,
                                dt?.totalPmChannelCount,
                            })
                        .ToList();

                    break;

                case "snd":

                    dtInfo = qry
                        .Select(dt => new
                        {
                            RegionCode = dt.DtToPole.PoleToRoute.RouteToSubstation.SnDCode,
                            InstalledCondition = dt.InstalledConditionPadbsPoleMounted != null ? dt.InstalledConditionPadbsPoleMounted.ToLower() : "",
                            InstalledPlace = dt.InstalledPlaceIndoorbsOutdoor != null ? dt.InstalledPlaceIndoorbsOutdoor.ToLower() : "",
                            Owner = dt.OwneroftheTransformerBPDBbsConsumer != null ? dt.OwneroftheTransformerBPDBbsConsumer.ToLower() : "",
                            OilLeakage = dt.OilLeakageYesOrNo != null ? dt.OilLeakageYesOrNo.ToLower() : "",
                            PlatformMaterial = dt.PlatformMaterialAnglbsChannel != null ? dt.PlatformMaterialAnglbsChannel.ToLower() : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(dt => dt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(dt => dt.InstalledCondition.Contains("pad")),
                            totalIcPoleMountCount = k.Count(dt => dt.InstalledCondition.Contains("pole")),

                            totalIpIndoorCount = k.Count(dt => dt.InstalledPlace.Contains("indoor")),
                            totalIpOutdoorCount = k.Count(dt => dt.InstalledPlace.Contains("outdoor")),

                            totalBpdbDtCount = k.Count(dt => dt.Owner.Contains("bpdb")),
                            totalConsumerDtCount = k.Count(dt => dt.Owner.Contains("consumer")),

                            totalOlYesCount = k.Count(dt => dt.OilLeakage.Contains("yes")),
                            totalOlNoCount = k.Count(dt => dt.OilLeakage.Contains("no")),

                            totalPmAngleCount = k.Count(dt => dt.PlatformMaterial.Contains("angle")),
                            totalPmChannelCount = k.Count(dt => dt.PlatformMaterial.Contains("channel")),
                        })
                        .ToList();


                    regions = _context.LookUpSnDInfo
                        .Where(d => (zoneCode.Equals("") || d.CircleInfo.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || d.CircleCode.Equals(circleCode))
                                    && (snDCode.Equals("") || d.SnDCode.Equals(snDCode)))
                        .Include(z => z.CircleInfo.ZoneInfo)
                        .Select(d => new
                        {
                            regionCode = d.SnDCode,
                            zoneName = d.CircleInfo.ZoneInfo.ZoneName,
                            circleName = d.CircleInfo.CircleName,
                            sndName = d.SnDName,
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join dt in dtInfo on rg.regionCode equals dt.regionCode into rdt
                            from dt in rdt.DefaultIfEmpty()
                            select new
                            {
                                sndCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,

                                dt?.totalCount,
                                dt?.totalIcPadCount,
                                dt?.totalIcPoleMountCount,

                                dt?.totalIpIndoorCount,
                                dt?.totalIpOutdoorCount,

                                dt?.totalBpdbDtCount,
                                dt?.totalConsumerDtCount,

                                dt?.totalOlYesCount,
                                dt?.totalOlNoCount,

                                dt?.totalPmAngleCount,
                                dt?.totalPmChannelCount,
                            })
                            .ToList();

                    break;

                case "substation":
                    dtInfo = qry
                        .Select(dt => new
                        {
                            RegionCode = dt.DtToPole.PoleToRoute.SubstationId,
                            InstalledCondition = dt.InstalledConditionPadbsPoleMounted != null ? dt.InstalledConditionPadbsPoleMounted.ToLower() : "",
                            InstalledPlace = dt.InstalledPlaceIndoorbsOutdoor != null ? dt.InstalledPlaceIndoorbsOutdoor.ToLower() : "",
                            Owner = dt.OwneroftheTransformerBPDBbsConsumer != null ? dt.OwneroftheTransformerBPDBbsConsumer.ToLower() : "",
                            OilLeakage = dt.OilLeakageYesOrNo != null ? dt.OilLeakageYesOrNo.ToLower() : "",
                            PlatformMaterial = dt.PlatformMaterialAnglbsChannel != null ? dt.PlatformMaterialAnglbsChannel.ToLower() : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(dt => dt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(dt => dt.InstalledCondition.Contains("pad")),
                            totalIcPoleMountCount = k.Count(dt => dt.InstalledCondition.Contains("pole")),

                            totalIpIndoorCount = k.Count(dt => dt.InstalledPlace.Contains("indoor")),
                            totalIpOutdoorCount = k.Count(dt => dt.InstalledPlace.Contains("outdoor")),

                            totalBpdbDtCount = k.Count(dt => dt.Owner.Contains("bpdb")),
                            totalConsumerDtCount = k.Count(dt => dt.Owner.Contains("consumer")),

                            totalOlYesCount = k.Count(dt => dt.OilLeakage.Contains("yes")),
                            totalOlNoCount = k.Count(dt => dt.OilLeakage.Contains("no")),

                            totalPmAngleCount = k.Count(dt => dt.PlatformMaterial.Contains("angle")),
                            totalPmChannelCount = k.Count(dt => dt.PlatformMaterial.Contains("channel")),
                        })
                        .ToList();


                    regions = _context.TblSubstation
                        .Where(s =>
                            (zoneCode.Equals("") || s.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                            && (circleCode.Equals("") || s.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                            && (snDCode.Equals("") || s.SnDCode.Equals(snDCode))
                            && (substationCode.Equals("") || s.SubstationId.Equals(substationCode)))
                        .Include(z => z.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .Select(s => new
                        {
                            regionCode = s.SubstationId,
                            zoneName = s.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = s.SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndName = s.SubstationToLookUpSnD.SnDName,
                            substationName = s.SubstationName,
                        })
                        .ToList();

                    data = (from rg in regions
                            join dt in dtInfo on rg.regionCode equals dt.regionCode into rdt
                            from dt in rdt.DefaultIfEmpty()
                            select new
                            {
                                substationCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,
                                rg.substationName,

                                dt?.totalCount,
                                dt?.totalIcPadCount,
                                dt?.totalIcPoleMountCount,

                                dt?.totalIpIndoorCount,
                                dt?.totalIpOutdoorCount,

                                dt?.totalBpdbDtCount,
                                dt?.totalConsumerDtCount,

                                dt?.totalOlYesCount,
                                dt?.totalOlNoCount,

                                dt?.totalPmAngleCount,
                                dt?.totalPmChannelCount,
                            })
                            .ToList();
                    break;

                default:

                    dtInfo = qry
                        .Select(dt => new
                        {
                            RegionCode = dt.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            InstalledCondition = dt.InstalledConditionPadbsPoleMounted != null ? dt.InstalledConditionPadbsPoleMounted.ToLower() : "",
                            InstalledPlace = dt.InstalledPlaceIndoorbsOutdoor != null ? dt.InstalledPlaceIndoorbsOutdoor.ToLower() : "",
                            Owner = dt.OwneroftheTransformerBPDBbsConsumer != null ? dt.OwneroftheTransformerBPDBbsConsumer.ToLower() : "",
                            OilLeakage = dt.OilLeakageYesOrNo != null ? dt.OilLeakageYesOrNo.ToLower() : "",
                            PlatformMaterial = dt.PlatformMaterialAnglbsChannel != null ? dt.PlatformMaterialAnglbsChannel.ToLower() : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(dt => dt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),
                            totalIcPadCount = k.Count(dt => dt.InstalledCondition.Contains("pad")),
                            totalIcPoleMountCount = k.Count(dt => dt.InstalledCondition.Contains("pole")),

                            totalIpIndoorCount = k.Count(dt => dt.InstalledPlace.Contains("indoor")),
                            totalIpOutdoorCount = k.Count(dt => dt.InstalledPlace.Contains("outdoor")),

                            totalBpdbDtCount = k.Count(dt => dt.Owner.Contains("bpdb")),
                            totalConsumerDtCount = k.Count(dt => dt.Owner.Contains("consumer")),

                            totalOlYesCount = k.Count(dt => dt.OilLeakage.Contains("yes")),
                            totalOlNoCount = k.Count(dt => dt.OilLeakage.Contains("no")),

                            totalPmAngleCount = k.Count(dt => dt.PlatformMaterial.Contains("angle")),
                            totalPmChannelCount = k.Count(dt => dt.PlatformMaterial.Contains("channel")),
                        })
                        .ToList();


                    regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join dt in dtInfo on rg.regionCode equals dt.regionCode into rdt
                            from dt in rdt.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                dt?.totalCount,
                                dt?.totalIcPadCount,
                                dt?.totalIcPoleMountCount,

                                dt?.totalIpIndoorCount,
                                dt?.totalIpOutdoorCount,

                                dt?.totalBpdbDtCount,
                                dt?.totalConsumerDtCount,

                                dt?.totalOlYesCount,
                                dt?.totalOlNoCount,

                                dt?.totalPmAngleCount,
                                dt?.totalPmChannelCount,
                            })
                            .ToList();

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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

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

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.PhasePowerTransformerTo33KvFeederLine.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);
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


            object data;

            switch (regionLevel)
            {
                case "zone":

                    var ptInfo = qry
                        .Select(pt => new
                        {
                            RegionCode = pt.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            SourceSubstationType = pt.PhasePowerTransformerToSourceSubstation.NominalVoltage ?? "",
                            RatedVoltage = pt.RatedVoltagePhaseToPhase ?? "",
                            Radiator = pt.RadiatorsYesNo != null ? pt.RadiatorsYesNo.ToLower() : "",
                            SupervisoryAlarm = pt.SupervisoryAlarmAndTripContactsYesNo != null ? pt.SupervisoryAlarmAndTripContactsYesNo.ToLower() : "",
                            TemperatureIndicator = pt.TemperatureIndicatorsYesNo != null ? pt.TemperatureIndicatorsYesNo.ToLower() : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pt => pt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            total132SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("132")),
                            total33SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("33")),

                            total132RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("132")),
                            total33RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("33")),

                            totalRadiatorsYes = k.Count(pt => pt.Radiator.Contains("yes")),
                            totalRadiatorsNo = k.Count(pt => pt.Radiator.Contains("no")),

                            totalSATCYes = k.Count(pt => pt.SupervisoryAlarm.Contains("yes")),
                            totalSATCNo = k.Count(pt => pt.SupervisoryAlarm.Contains("no")),

                            totalTIYes = k.Count(pt => pt.TemperatureIndicator.Contains("yes")),
                            totalTINo = k.Count(pt => pt.TemperatureIndicator.Contains("no")),
                        })
                        .ToList();


                    var regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join pt in ptInfo on rg.regionCode equals pt.regionCode into rpt
                            from pt in rpt.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                pt?.totalCount,
                                pt?.total132SrcCount,
                                pt?.total33SrcCount,

                                pt?.total132RatVolCount,
                                pt?.total33RatVolCount,

                                pt?.totalRadiatorsYes,
                                pt?.totalRadiatorsNo,

                                pt?.totalSATCYes,
                                pt?.totalSATCNo,

                                pt?.totalTIYes,
                                pt?.totalTINo,
                            })
                        .ToList();

                    break;


                case "circle":
                    ptInfo = qry
                        .Select(pt => new
                        {
                            RegionCode = pt.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleCode,
                            SourceSubstationType = pt.PhasePowerTransformerToSourceSubstation.NominalVoltage ?? "",
                            RatedVoltage = pt.RatedVoltagePhaseToPhase ?? "",
                            Radiator = pt.RadiatorsYesNo != null ? pt.RadiatorsYesNo.ToLower() : "",
                            SupervisoryAlarm = pt.SupervisoryAlarmAndTripContactsYesNo != null
                                ? pt.SupervisoryAlarmAndTripContactsYesNo.ToLower()
                                : "",
                            TemperatureIndicator = pt.TemperatureIndicatorsYesNo != null
                                ? pt.TemperatureIndicatorsYesNo.ToLower()
                                : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pt => pt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            total132SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("132")),
                            total33SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("33")),

                            total132RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("132")),
                            total33RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("33")),

                            totalRadiatorsYes = k.Count(pt => pt.Radiator.Contains("yes")),
                            totalRadiatorsNo = k.Count(pt => pt.Radiator.Contains("no")),

                            totalSATCYes = k.Count(pt => pt.SupervisoryAlarm.Contains("yes")),
                            totalSATCNo = k.Count(pt => pt.SupervisoryAlarm.Contains("no")),

                            totalTIYes = k.Count(pt => pt.TemperatureIndicator.Contains("yes")),
                            totalTINo = k.Count(pt => pt.TemperatureIndicator.Contains("no")),
                        })
                        .ToList();


                    regions = _context.LookUpCircleInfo
                        .Where(c => (zoneCode.Equals("") || c.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || c.CircleCode.Equals(circleCode)))
                        .Include(z => z.ZoneInfo)
                        .Select(c => new
                        {
                            regionCode = c.CircleCode,
                            zoneName = c.ZoneInfo.ZoneName,
                            circleName = c.CircleName,
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join pt in ptInfo on rg.regionCode equals pt.regionCode into rpt
                            from pt in rpt.DefaultIfEmpty()
                            select new
                            {
                                circleCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,

                                pt?.totalCount,
                                pt?.total132SrcCount,
                                pt?.total33SrcCount,

                                pt?.total132RatVolCount,
                                pt?.total33RatVolCount,

                                pt?.totalRadiatorsYes,
                                pt?.totalRadiatorsNo,

                                pt?.totalSATCYes,
                                pt?.totalSATCNo,

                                pt?.totalTIYes,
                                pt?.totalTINo,
                            })
                        .ToList();

                    break;


                case "snd":

                    ptInfo = qry
                        .Select(pt => new
                        {
                            RegionCode = pt.PhasePowerTransformerToTblSubstation.SnDCode,
                            SourceSubstationType = pt.PhasePowerTransformerToSourceSubstation.NominalVoltage ?? "",
                            RatedVoltage = pt.RatedVoltagePhaseToPhase ?? "",
                            Radiator = pt.RadiatorsYesNo != null ? pt.RadiatorsYesNo.ToLower() : "",
                            SupervisoryAlarm = pt.SupervisoryAlarmAndTripContactsYesNo != null
                                ? pt.SupervisoryAlarmAndTripContactsYesNo.ToLower()
                                : "",
                            TemperatureIndicator = pt.TemperatureIndicatorsYesNo != null
                                ? pt.TemperatureIndicatorsYesNo.ToLower()
                                : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pt => pt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            total132SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("132")),
                            total33SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("33")),

                            total132RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("132")),
                            total33RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("33")),

                            totalRadiatorsYes = k.Count(pt => pt.Radiator.Contains("yes")),
                            totalRadiatorsNo = k.Count(pt => pt.Radiator.Contains("no")),

                            totalSATCYes = k.Count(pt => pt.SupervisoryAlarm.Contains("yes")),
                            totalSATCNo = k.Count(pt => pt.SupervisoryAlarm.Contains("no")),

                            totalTIYes = k.Count(pt => pt.TemperatureIndicator.Contains("yes")),
                            totalTINo = k.Count(pt => pt.TemperatureIndicator.Contains("no")),
                        })
                        .ToList();


                    regions = _context.LookUpSnDInfo
                        .Where(d => (zoneCode.Equals("") || d.CircleInfo.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || d.CircleCode.Equals(circleCode))
                                    && (snDCode.Equals("") || d.SnDCode.Equals(snDCode)))
                        .Include(z => z.CircleInfo.ZoneInfo)
                        .Select(d => new
                        {
                            regionCode = d.SnDCode,
                            zoneName = d.CircleInfo.ZoneInfo.ZoneName,
                            circleName = d.CircleInfo.CircleName,
                            sndName = d.SnDName,
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join pt in ptInfo on rg.regionCode equals pt.regionCode into rpt
                            from pt in rpt.DefaultIfEmpty()
                            select new
                            {
                                sndCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,

                                pt?.totalCount,
                                pt?.total132SrcCount,
                                pt?.total33SrcCount,

                                pt?.total132RatVolCount,
                                pt?.total33RatVolCount,

                                pt?.totalRadiatorsYes,
                                pt?.totalRadiatorsNo,

                                pt?.totalSATCYes,
                                pt?.totalSATCNo,

                                pt?.totalTIYes,
                                pt?.totalTINo,
                            })
                        .ToList();

                    break;


                case "substation":

                    ptInfo = qry
                        .Select(pt => new
                        {
                            RegionCode = pt.SubstationId,
                            SourceSubstationType = pt.PhasePowerTransformerToSourceSubstation.NominalVoltage ?? "",
                            RatedVoltage = pt.RatedVoltagePhaseToPhase ?? "",
                            Radiator = pt.RadiatorsYesNo != null ? pt.RadiatorsYesNo.ToLower() : "",
                            SupervisoryAlarm = pt.SupervisoryAlarmAndTripContactsYesNo != null
                                ? pt.SupervisoryAlarmAndTripContactsYesNo.ToLower()
                                : "",
                            TemperatureIndicator = pt.TemperatureIndicatorsYesNo != null
                                ? pt.TemperatureIndicatorsYesNo.ToLower()
                                : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pt => pt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            total132SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("132")),
                            total33SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("33")),

                            total132RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("132")),
                            total33RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("33")),

                            totalRadiatorsYes = k.Count(pt => pt.Radiator.Contains("yes")),
                            totalRadiatorsNo = k.Count(pt => pt.Radiator.Contains("no")),

                            totalSATCYes = k.Count(pt => pt.SupervisoryAlarm.Contains("yes")),
                            totalSATCNo = k.Count(pt => pt.SupervisoryAlarm.Contains("no")),

                            totalTIYes = k.Count(pt => pt.TemperatureIndicator.Contains("yes")),
                            totalTINo = k.Count(pt => pt.TemperatureIndicator.Contains("no")),
                        })
                        .ToList();


                    regions = _context.TblSubstation
                        .Where(s =>
                            (zoneCode.Equals("") || s.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                            && (circleCode.Equals("") || s.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                            && (snDCode.Equals("") || s.SnDCode.Equals(snDCode))
                            && (substationCode.Equals("") || s.SubstationId.Equals(substationCode)))
                        .Include(z => z.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .Select(s => new
                        {
                            regionCode = s.SubstationId,
                            zoneName = s.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = s.SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndName = s.SubstationToLookUpSnD.SnDName,
                            substationName = s.SubstationName,
                        })
                        .ToList();

                    data = (from rg in regions
                            join pt in ptInfo on rg.regionCode equals pt.regionCode into rpt
                            from pt in rpt.DefaultIfEmpty()
                            select new
                            {
                                substationCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,
                                rg.substationName,

                                pt?.totalCount,
                                pt?.total132SrcCount,
                                pt?.total33SrcCount,

                                pt?.total132RatVolCount,
                                pt?.total33RatVolCount,

                                pt?.totalRadiatorsYes,
                                pt?.totalRadiatorsNo,

                                pt?.totalSATCYes,
                                pt?.totalSATCNo,

                                pt?.totalTIYes,
                                pt?.totalTINo,
                            })
                        .ToList();

                    break;


                default:

                    ptInfo = qry
                        .Select(pt => new
                        {
                            RegionCode = pt.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,
                            SourceSubstationType = pt.PhasePowerTransformerToSourceSubstation.NominalVoltage ?? "",
                            RatedVoltage = pt.RatedVoltagePhaseToPhase ?? "",
                            Radiator = pt.RadiatorsYesNo != null ? pt.RadiatorsYesNo.ToLower() : "",
                            SupervisoryAlarm = pt.SupervisoryAlarmAndTripContactsYesNo != null
                                ? pt.SupervisoryAlarmAndTripContactsYesNo.ToLower()
                                : "",
                            TemperatureIndicator = pt.TemperatureIndicatorsYesNo != null
                                ? pt.TemperatureIndicatorsYesNo.ToLower()
                                : ""
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(pt => pt.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            total132SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("132")),
                            total33SrcCount = k.Count(pt => pt.SourceSubstationType.Contains("33")),

                            total132RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("132")),
                            total33RatVolCount = k.Count(pt => pt.RatedVoltage.Contains("33")),

                            totalRadiatorsYes = k.Count(pt => pt.Radiator.Contains("yes")),
                            totalRadiatorsNo = k.Count(pt => pt.Radiator.Contains("no")),

                            totalSATCYes = k.Count(pt => pt.SupervisoryAlarm.Contains("yes")),
                            totalSATCNo = k.Count(pt => pt.SupervisoryAlarm.Contains("no")),

                            totalTIYes = k.Count(pt => pt.TemperatureIndicator.Contains("yes")),
                            totalTINo = k.Count(pt => pt.TemperatureIndicator.Contains("no")),
                        })
                        .ToList();


                    regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join pt in ptInfo on rg.regionCode equals pt.regionCode into rpt
                            from pt in rpt.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                pt?.totalCount,
                                pt?.total132SrcCount,
                                pt?.total33SrcCount,

                                pt?.total132RatVolCount,
                                pt?.total33RatVolCount,

                                pt?.totalRadiatorsYes,
                                pt?.totalRadiatorsNo,

                                pt?.totalSATCYes,
                                pt?.totalSATCNo,

                                pt?.totalTIYes,
                                pt?.totalTINo,
                            })
                        .ToList();

                    break;
            }

            return Json(data);
        }

        #endregion

    }


}