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
using Pdb014App.Models.Report;


namespace Pdb014App.Controllers.AdvancedReport
{
    public partial class SummaryReportController : Controller
    {
        private readonly PdbDbContext _context;

        public SummaryReportController(PdbDbContext context)
        {
            _context = context;
        }

    }


    public partial class SummaryReportController
    {

        #region Summary-Report

        public IActionResult SummaryReport([FromQuery] string cai)
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


            ViewBag.ReportName = "Summary";
            ViewBag.ReportAction = "GetFeederLineData";
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
        public IActionResult SummaryReport([FromQuery] string cai, List<ReportField> fieldList, List<string> regionList)
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

            ViewBag.ReportName = "Summary";
            ViewBag.ReportAction = "GetFeederLineData";
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
        public JsonResult GetFeederLineData(List<string> regionList = null)
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

                    f11kInfo = k.Where(d => d.NominalVoltage == 11)
                        .Select(f => new
                        {
                            length = Math.Round(f.FeederLength / 1000, 0),
                            type = f.FeederConductorTypeId.HasValue ? f.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = f.FeederName
                        }).ToList(),

                    f33kInInfo = k.Where(d => d.NominalVoltage == 11)
                        .Select(f => new
                        {
                            length = Math.Round(f.FeederLength / 1000, 0),
                            type = f.FeederConductorTypeId.HasValue ? f.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = f.FeederName
                        }).ToList(),

                    f33kOutInfo = k.Where(d => d.NominalVoltage == 33)
                        .Select(f => new
                        {
                            length = Math.Round(f.FeederLength / 1000, 0),
                            type = f.FeederConductorTypeId.HasValue ? f.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = f.FeederName
                        }).ToList(),

                }).ToList();

            return Json(data);
        }

        #endregion

        

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
            Expression<Func<TblSubstation, bool>> searchExp = null;
            Expression<Func<TblFeederLine, bool>> searchExp1 = null;

            string zoneCode, circleCode, snDCode, substationCode;

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;
                searchExp1 = model =>
                    model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblSubstation, bool>> tempExp = model => model.SubstationToLookUpSnD.CircleCode == circleCode;
                    Expression<Func<TblFeederLine, bool>> tempExp1 = model => model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;

                    searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                    searchExp1 = ExpressionExtension<TblFeederLine>.AndAlso(searchExp1, tempExp1);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.SnDCode == snDCode;
                        tempExp1 = model => model.FeederLineToRoute.RouteToSubstation.SnDCode == snDCode;

                        searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                        searchExp1 = ExpressionExtension<TblFeederLine>.AndAlso(searchExp1, tempExp1);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.SubstationId == substationCode;
                            tempExp1 = model => model.FeederLineToRoute.RouteToSubstation.SubstationId == substationCode;

                            searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                            searchExp1 = ExpressionExtension<TblFeederLine>.AndAlso(searchExp1, tempExp1);
                        }
                    }
                }
            }


            var qry1 = searchExp1 != null
                ? _context.TblFeederLine
                    .AsNoTracking()
                    .Where(searchExp1)
                : _context.TblFeederLine
                    .AsNoTracking();

            var flInfo = qry1
                .Include(pl => pl.Poles)
                .GroupBy(g => g.FeederLineToRoute.SubstationId)
                .Select(k => new
                {
                    substationCode = k.Key,

                    //f11kInfo = k.Where(d => d.FeederLineType.FeederLineTypeName.Contains("11"))
                    f11kInfo = k.Where(d => d.NominalVoltage == 11)
                        .Select(fl => new
                        {
                            length = Math.Round(fl.FeederLength / 1000, 0),
                            type = fl.FeederConductorTypeId.HasValue ? fl.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = fl.FeederName
                        }).ToList(),

                    f33kInInfo = k.Where(d => d.NominalVoltage == 11)
                        .Select(fl => new
                        {
                            length = Math.Round(fl.FeederLength / 1000, 0),
                            type = fl.FeederConductorTypeId.HasValue ? fl.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = fl.FeederName
                        }).ToList(),

                    f33kOutInfo = k.Where(d => d.NominalVoltage == 33)
                        .Select(fl => new
                        {
                            length = Math.Round(fl.FeederLength / 1000, 0),
                            type = fl.FeederConductorTypeId.HasValue ? fl.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = fl.FeederName
                        }).ToList(),

                }).ToList();


            var qry = searchExp != null
                ? _context.TblSubstation
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblSubstation
                    .AsNoTracking();

            var ssInfo = qry
                .Include(di => di.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .Select(st => new
                {
                    zoneName = st.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                    circleName = st.SubstationToLookUpSnD.CircleInfo.CircleName,
                    isCity = st.SubstationToLookUpSnD.IsInCity != null
                             && st.SubstationToLookUpSnD.IsInCity == 1
                        ? "City"
                        : "Except City",
                    ////isCity = k.SubstationToLookUpSnD.IsInCity == 1,
                    distName = st.SubstationToLookUpSnD.LookUpAdminBndDistrict.DistrictName,
                    sndName = st.SubstationToLookUpSnD.SnDName,
                    substationCode = st.SubstationId,

                    substation = new
                    {
                        name = st.SubstationName,
                        capacity = st.InstalledCapacity
                    }
                }).ToList();

            List<object> data = new List<object>();

            foreach (var si in ssInfo)
            {
                data.Add(new
                {
                    si.zoneName,
                    si.circleName,
                    si.isCity,
                    si.distName,
                    si.sndName,
                    si.substation,
                    f11kInfo = flInfo.FirstOrDefault(f => f.substationCode.Equals(si.substationCode))?.f11kInfo,
                    f33kInInfo = flInfo.FirstOrDefault(f => f.substationCode.Equals(si.substationCode))?.f33kInInfo,
                    f33kOutInfo = flInfo.FirstOrDefault(f => f.substationCode.Equals(si.substationCode))?.f33kOutInfo
                });
            }

            return Json(data);

        }



        [HttpPost]
        public JsonResult GetSubstationData_bk(List<string> regionList = null)
        {
            Expression<Func<TblSubstation, bool>> searchExp = null;
            Expression<Func<TblFeederLine, bool>> searchExp1 = null;

            string zoneCode, circleCode, snDCode, substationCode;

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;
                searchExp1 = model =>
                    model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblSubstation, bool>> tempExp = model => model.SubstationToLookUpSnD.CircleCode == circleCode;
                    Expression<Func<TblFeederLine, bool>> tempExp1 = model => model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;

                    searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                    searchExp1 = ExpressionExtension<TblFeederLine>.AndAlso(searchExp1, tempExp1);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.SnDCode == snDCode;
                        tempExp1 = model => model.FeederLineToRoute.RouteToSubstation.SnDCode == snDCode;

                        searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                        searchExp1 = ExpressionExtension<TblFeederLine>.AndAlso(searchExp1, tempExp1);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.SubstationId == substationCode;
                            tempExp1 = model => model.FeederLineToRoute.RouteToSubstation.SubstationId == substationCode;

                            searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                            searchExp1 = ExpressionExtension<TblFeederLine>.AndAlso(searchExp1, tempExp1);
                        }
                    }
                }
            }


            var qry1 = searchExp1 != null
                ? _context.TblFeederLine
                    .AsNoTracking()
                    .Where(searchExp1)
                : _context.TblFeederLine
                    .AsNoTracking();

            var flInfo = qry1
                .Include(pl => pl.Poles)
                .GroupBy(g => g.FeederLineToRoute.SubstationId)
                .Select(k => new
                {
                    substationCode = k.Key,

                    //f11kInfo = k.Where(d => d.FeederLineType.FeederLineTypeName.Contains("11"))
                    f11kInfo = k.Where(d => d.NominalVoltage == 11)
                        .Select(fl => new
                        {
                            length = Math.Round(fl.FeederLength / 1000, 0),
                            type = fl.FeederConductorTypeId.HasValue ? fl.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = fl.FeederName
                        }).ToList(),

                    f33kInInfo = k.Where(d => d.NominalVoltage == 11)
                        .Select(fl => new
                        {
                            length = Math.Round(fl.FeederLength / 1000, 0),
                            type = fl.FeederConductorTypeId.HasValue ? fl.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = fl.FeederName
                        }).ToList(),

                    f33kOutInfo = k.Where(d => d.NominalVoltage == 33)
                        .Select(fl => new
                        {
                            length = Math.Round(fl.FeederLength / 1000, 0),
                            type = fl.FeederConductorTypeId.HasValue ? fl.FeederConductorType.FeederConductorType : "",
                            //type = f.FeederLineType.FeederLineTypeName,
                            name = fl.FeederName
                        }).ToList(),

                }).ToList();


            var qry = searchExp != null
                ? _context.TblSubstation
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblSubstation
                    .AsNoTracking();

            var ssInfo = qry
                .Include(di => di.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .Select(st => new
                {
                    zoneName = st.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                    circleName = st.SubstationToLookUpSnD.CircleInfo.CircleName,
                    isCity = st.SubstationToLookUpSnD.IsInCity != null
                             && st.SubstationToLookUpSnD.IsInCity == 1
                        ? "City"
                        : "Except City",
                    ////isCity = k.SubstationToLookUpSnD.IsInCity == 1,
                    distName = st.SubstationToLookUpSnD.LookUpAdminBndDistrict.DistrictName,
                    sndName = st.SubstationToLookUpSnD.SnDName,
                    substationCode = st.SubstationId,

                    substation = new
                    {
                        name = st.SubstationName,
                        capacity = st.InstalledCapacity
                    }
                }).ToList();


            var data = from si in ssInfo
                       join fi in flInfo on si.substationCode equals fi.substationCode
                       select new
                       {
                           si.zoneName,
                           si.circleName,
                           si.isCity,
                           si.distName,
                           si.sndName,
                           si.substation,
                           fi.f11kInfo,
                           fi.f33kInInfo,
                           fi.f33kOutInfo
                       };

            return Json(data);

        }

        #endregion

    }

}