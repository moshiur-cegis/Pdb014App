using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Extensions;

using Pdb014App.Models.PDB;
using Pdb014App.Models.Report;


namespace Pdb014App.Controllers.AdvancedReport
{
    //Pole
    public partial class AdvancedReportController
    {
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
                //new ReportField {Name = "total33Count", Title = "33KV Pole", Selected = true},
                //new ReportField {Name = "total11Count", Title = "11KV Pole", Selected = true},
                ////new ReportField {Name = "totalP4Count", Title = ".4KV Pole", Selected = true},
                
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

            ViewBag.ReportName = "Pole";
            ViewBag.ReportAction = "GetPoleData";
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
            //return View("Pole");
        }

        [HttpPost]
        public JsonResult GetPoleData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            Expression<Func<TblPole, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

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

                            if (regionList.Count > 4)
                            {
                                routeCode = regionList[4];
                                //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                                //tempExp = model => model. == substationCode;
                                //searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);
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
                    data = qry
                        .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),
                            totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
                            totalSpCount = k.Count(d => d.PoleTypeId == "2"),
                            totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
                            totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

                            totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
                            totalBadCount = k.Count(d => d.PoleConditionId == "B"),
                            totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
                            totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

                            totalNeutralPole = k.Count(d => d.Neutral == "Y"),
                            totalStreetLight = k.Count(d => d.StreetLight == "Y"),

                            totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
                            //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
                        }).ToList();
                    break;


                case "circle":
                    data = qry
                        .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            //wl = k.Sum(d => d.Poles.Sum(pi => pi.WireLength)),
                            zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo.ZoneInfo.ZoneName,
                            circleCode = k.Key,
                            circleName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,


                            totalCount = k.Count(),
                            totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
                            totalSpCount = k.Count(d => d.PoleTypeId == "2"),
                            totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
                            totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

                            totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
                            totalBadCount = k.Count(d => d.PoleConditionId == "B"),
                            totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
                            totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

                            totalNeutralPole = k.Count(d => d.Neutral == "Y"),
                            totalStreetLight = k.Count(d => d.StreetLight == "Y"),

                            totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
                            //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
                        })
                        .ToList();
                    break;

                case "snd":
                    data = qry
                        .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD)
                        .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo)
                        .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PoleToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndCode = k.Key,
                            sndName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,


                            totalCount = k.Count(),
                            totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
                            totalSpCount = k.Count(d => d.PoleTypeId == "2"),
                            totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
                            totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

                            totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
                            totalBadCount = k.Count(d => d.PoleConditionId == "B"),
                            totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
                            totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

                            totalNeutralPole = k.Count(d => d.Neutral == "Y"),
                            totalStreetLight = k.Count(d => d.StreetLight == "Y"),

                            totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
                            //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
                        }).ToList();
                    break;

                case "substation":
                    data = qry
                        .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PoleToRoute.SubstationId)
                        .Select(k => new
                        {
                            zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDName,
                            substationCode = k.Key,
                            substationName = k.First().PoleToRoute.RouteToSubstation.SubstationName,


                            totalCount = k.Count(),
                            totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
                            totalSpCount = k.Count(d => d.PoleTypeId == "2"),
                            totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
                            totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

                            totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
                            totalBadCount = k.Count(d => d.PoleConditionId == "B"),
                            totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
                            totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

                            totalNeutralPole = k.Count(d => d.Neutral == "Y"),
                            totalStreetLight = k.Count(d => d.StreetLight == "Y"),

                            totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
                            //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
                        }).ToList();
                    break;

                default:
                    data = qry
                        .Include(st => st.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,


                            totalCount = k.Count(),
                            totalSpcCount = k.Count(d => d.PoleTypeId == "1"),
                            totalSpCount = k.Count(d => d.PoleTypeId == "2"),
                            totalTowerCount = k.Count(d => d.PoleTypeId == "3"),
                            totalOthersCount = k.Count(d => d.PoleTypeId == "4"),

                            totalAgedCount = k.Count(d => d.PoleConditionId == "Ag"),
                            totalBadCount = k.Count(d => d.PoleConditionId == "B"),
                            totalBrokenCount = k.Count(d => d.PoleConditionId == "Br"),
                            totalGoodCount = k.Count(d => d.PoleConditionId == "G"),

                            totalNeutralPole = k.Count(d => d.Neutral == "Y"),
                            totalStreetLight = k.Count(d => d.StreetLight == "Y"),

                            totalWireLength = Math.Round((double)k.Sum(d => d.WireLength) / 1000, 0),
                            //totalWireLength = k.Where(d => d.WireLength != null).Sum(d => d.WireLength),
                        }).ToList();
                    break;
            }

            return Json(data);
        }

    }
    
}