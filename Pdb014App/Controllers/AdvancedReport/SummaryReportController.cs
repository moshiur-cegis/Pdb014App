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
    public class SummaryReportController : Controller
    {
        private readonly PdbDbContext _context;

        public SummaryReportController(PdbDbContext context)
        {
            _context = context;
        }


        #region Summary-Report

        public IActionResult SummaryReport([FromQuery] string cai)
        {
            var fieldList = new List<ReportField>(22)
            {
                //new ReportField {Name = "substationCode", Title = "Substation Code", Selected = true, Visible = false},

                new ReportField {Name = "groupInLineFeeder33kIn", Title = "Incoming Line (33kV)", Selected = true},
                new ReportField {Name = "f33kInInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},

                new ReportField {Name = "groupSubstation", Title = "Substation", Selected = true},
                new ReportField {Name = "substation.ss_name", Title = "Name of Substation", GroupName = "groupSubstation", Selected = true, Visible = false},
                new ReportField {Name = "substation.ss_capacity", Title = "Capacity (MVA)", GroupName = "groupSubstation", Selected = true, Visible = false},

                new ReportField {Name = "groupInLineFeeder33kOut", Title = "Outgoing Line (33kV)", Selected = true},
                new ReportField {Name = "f33kOutInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},

                new ReportField {Name = "groupInTableFeeder11k", Title = "Feeder Line (11kV)", Selected = true},
                new ReportField {Name = "f11kInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
            };


            ViewBag.ReportName = "Summary";
            ViewBag.ReportAction = "GetSummaryData";
            //ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "SummaryReport";

            var regionList = new List<string>(4);

            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("~/Views/AdvancedReport/SummaryReport.cshtml");
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
                    new ReportField {Name = "f33kInInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                    new ReportField {Name = "f33kInInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                    new ReportField {Name = "f33kInInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},

                    new ReportField {Name = "groupSubstation", Title = "Substation", Selected = true},
                    new ReportField {Name = "substation.ss_name", Title = "Name of Substation", GroupName = "groupSubstation", Selected = true, Visible = false},
                    new ReportField {Name = "substation.ss_capacity", Title = "Capacity (MVA)", GroupName = "groupSubstation", Selected = true, Visible = false},

                    new ReportField {Name = "groupInLineFeeder33kOut", Title = "Outgoing Line (33kV)", Selected = true},
                    new ReportField {Name = "f33kOutInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                    new ReportField {Name = "f33kOutInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                    new ReportField {Name = "f33kOutInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},

                    new ReportField {Name = "groupInTableFeeder11k", Title = "Feeder Line (11kV)", Selected = true},
                    new ReportField {Name = "f11kInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                    new ReportField {Name = "f11kInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                    new ReportField {Name = "f11kInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                };
            }

            ViewBag.ReportName = "Summary";
            ViewBag.ReportAction = "GetSummaryData";
            //ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "SummaryReport";

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
        }



        [HttpPost]
        public JsonResult GetSummaryData(List<string> regionList = null)
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


            var qryFeeder = searchExp1 != null
                ? _context.TblFeederLine
                    .Include(fl => fl.Poles)
                    .AsNoTracking()
                    .Where(searchExp1)
                : _context.TblFeederLine
                    .Include(fl => fl.Poles)
                    .AsNoTracking();


            var flInfo = qryFeeder
                .Select(f => new
                {
                    RegionCode = f.FeederLineToRoute.SubstationId,
                    FeederName = f.FeederName,
                    FeederType = f.FeederLineTypeId != null ? f.FeederLineType.FeederLineTypeName : "",
                    ConductorType = f.FeederConductorTypeId.HasValue ? f.FeederConductorType.FeederConductorType : "",
                    //FeederType = f.NominalVoltage.ToString(),
                    //FeederLength = f.Poles.Sum(p => p.WireLength ?? 0),
                    FeederLength = f.Poles.Where(p => p.FeederLineId == f.FeederLineId).Sum(p => p.WireLength ?? 0),
                    //FeederLength = f.FeederLength,
                })
                .ToList()
                .AsQueryable()
                .GroupBy(f => f.RegionCode)
                .Select(k => new
                {
                    substationCode = k.Key,

                    f11kInfo = k.Where(f => f.FeederType.Contains("11"))
                        .Select(fl => new
                        {
                            feeder_length = Math.Round(fl.FeederLength / 1000, 0),
                            feeder_type = fl.ConductorType,
                            feeder_name = fl.FeederName
                        }).ToList(),

                    f33kInInfo = k.Where(f => f.FeederType.Contains("11"))
                        .Select(fl => new
                        {
                            feeder_length = Math.Round(fl.FeederLength / 1000, 0),
                            feeder_type = fl.ConductorType,
                            feeder_name = fl.FeederName
                        }).ToList(),

                    f33kOutInfo = k.Where(f => f.FeederType.Contains("33"))
                        .Select(fl => new
                        {
                            feeder_length = Math.Round(fl.FeederLength / 1000, 0),
                            feeder_type = fl.ConductorType,
                            feeder_name = fl.FeederName
                        }).ToList()

                })
                .ToList();


            var qrySubstation = searchExp != null
                ? _context.TblSubstation
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblSubstation
                    .AsNoTracking();

            var ssInfo = qrySubstation
                .Include(di => di.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .Select(st => new
                {
                    zoneName = st.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                    circleName = st.SubstationToLookUpSnD.CircleInfo.CircleName,
                    isCity = st.SubstationToLookUpSnD.IsInCity != null
                             && st.SubstationToLookUpSnD.IsInCity == 1 ? "City" : "Except City",
                    distName = st.SubstationToLookUpSnD.LookUpAdminBndDistrict.DistrictName,
                    sndName = st.SubstationToLookUpSnD.SnDName,
                    substationCode = st.SubstationId,
                    substation = new
                    {
                        ss_name = st.SubstationName,
                        ss_capacity = st.InstalledCapacity
                    }
                }).ToList();



            var data = (from si in ssInfo
                        join fl in flInfo on si.substationCode equals fl.substationCode into sfl
                        from fl in sfl.DefaultIfEmpty()
                        select new
                        {
                            si.zoneName,
                            si.circleName,
                            si.isCity,
                            si.distName,
                            si.sndName,
                            si.substationCode,
                            si.substation,
                            fl?.f11kInfo,
                            fl?.f33kInInfo,
                            fl?.f33kOutInfo
                        })
                .ToList();

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
                new ReportField {Name = "f33kInInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                new ReportField {Name = "f33kInInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},

                new ReportField {Name = "groupSubstation", Title = "Substation", Selected = true},
                new ReportField {Name = "substation.ss_name", Title = "Name of Substation", GroupName = "groupSubstation", Selected = true, Visible = false},
                new ReportField {Name = "substation.ss_capacity", Title = "Capacity (MVA)", GroupName = "groupSubstation", Selected = true, Visible = false},

                new ReportField {Name = "groupInLineFeeder33kOut", Title = "Outgoing Line (33kV)", Selected = true},
                new ReportField {Name = "f33kOutInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                new ReportField {Name = "f33kOutInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},

                new ReportField {Name = "groupInTableFeeder11k", Title = "Feeder Line (11kV)", Selected = true},
                new ReportField {Name = "f11kInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                new ReportField {Name = "f11kInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
            };


            ViewBag.ReportName = "Substation";
            ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "SummaryReport";

            var regionList = new List<string>(4);

            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("~/Views/AdvancedReport/SummaryReportOk.cshtml");
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
                    new ReportField {Name = "f33kInInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                    new ReportField {Name = "f33kInInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},
                    new ReportField {Name = "f33kInInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kIn", Selected = true, Visible = false},

                    new ReportField {Name = "groupSubstation", Title = "Substation", Selected = true},
                    new ReportField {Name = "substation.ss_name", Title = "Name of Substation", GroupName = "groupSubstation", Selected = true, Visible = false},
                    new ReportField {Name = "substation.ss_capacity", Title = "Capacity (MVA)", GroupName = "groupSubstation", Selected = true, Visible = false},

                    new ReportField {Name = "groupInLineFeeder33kOut", Title = "Outgoing Line (33kV)", Selected = true},
                    new ReportField {Name = "f33kOutInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                    new ReportField {Name = "f33kOutInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},
                    new ReportField {Name = "f33kOutInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInLineFeeder33kOut", Selected = true, Visible = false},

                    new ReportField {Name = "groupInTableFeeder11k", Title = "Feeder Line (11kV)", Selected = true},
                    new ReportField {Name = "f11kInfo.feeder_name", Title = "Feeder Name", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                    new ReportField {Name = "f11kInfo.feeder_type", Title = "Conductor Type", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                    new ReportField {Name = "f11kInfo.feeder_length", Title = "Length (Km)", GroupName = "groupInTableFeeder11k", Selected = true, Visible = false},
                };
            }

            ViewBag.ReportName = "Substation";
            ViewBag.ReportAction = "GetSubstationData";
            ViewBag.ReportController = "SummaryReport";

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

            return View("~/Views/AdvancedReport/SummaryReportOk.cshtml");
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


            var qryFeeder = searchExp1 != null
                ? _context.TblFeederLine
                    .Include(fl => fl.Poles)
                    .AsNoTracking()
                    .Where(searchExp1)
                : _context.TblFeederLine
                    .Include(fl => fl.Poles)
                    .AsNoTracking();


            var flInfo = qryFeeder
                .Select(f => new
                {
                    RegionCode = f.FeederLineToRoute.SubstationId,
                    FeederName = f.FeederName,
                    FeederType = f.FeederLineType.FeederLineTypeName,
                    ConductorType = f.FeederConductorTypeId.HasValue ? f.FeederConductorType.FeederConductorType : "",
                    //FeederType = f.NominalVoltage.ToString(),
                    FeederLength = f.Poles.Where(p => p.FeederLineId == f.FeederLineId).Sum(p => p.WireLength ?? 0),
                    //FeederLength = f.FeederLength,
                })
                .ToList()
                .AsQueryable()
                .GroupBy(f => f.RegionCode)
                .Select(k => new
                {
                    substationCode = k.Key,

                    f11kInfo = k.Where(f => f.FeederType.Contains("11"))
                        .Select(fl => new
                        {
                            feeder_length = Math.Round(fl.FeederLength / 1000, 0),
                            feeder_type = fl.ConductorType,
                            feeder_name = fl.FeederName
                        }).ToList(),

                    f33kInInfo = k.Where(f => f.FeederType.Contains("11"))
                        .Select(fl => new
                        {
                            feeder_length = Math.Round(fl.FeederLength / 1000, 0),
                            feeder_type = fl.ConductorType,
                            feeder_name = fl.FeederName
                        }).ToList(),

                    f33kOutInfo = k.Where(f => f.FeederType.Contains("33"))
                        .Select(fl => new
                        {
                            feeder_length = Math.Round(fl.FeederLength / 1000, 0),
                            feeder_type = fl.ConductorType,
                            feeder_name = fl.FeederName
                        }).ToList()

                })
                .ToList();


            var qrySubstation = searchExp != null
                ? _context.TblSubstation
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblSubstation
                    .AsNoTracking();

            var ssInfo = qrySubstation
                .Include(di => di.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .Select(st => new
                {
                    zoneName = st.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                    circleName = st.SubstationToLookUpSnD.CircleInfo.CircleName,
                    isCity = st.SubstationToLookUpSnD.IsInCity != null
                             && st.SubstationToLookUpSnD.IsInCity == 1 ? "City" : "Except City",
                    distName = st.SubstationToLookUpSnD.LookUpAdminBndDistrict.DistrictName,
                    sndName = st.SubstationToLookUpSnD.SnDName,
                    substationCode = st.SubstationId,
                    substation = new
                    {
                        ss_name = st.SubstationName,
                        ss_capacity = st.InstalledCapacity
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
                    si.substationCode,
                    si.substation,
                    flInfo.FirstOrDefault(f => f.substationCode.Equals(si.substationCode))?.f11kInfo,
                    flInfo.FirstOrDefault(f => f.substationCode.Equals(si.substationCode))?.f33kInInfo,
                    flInfo.FirstOrDefault(f => f.substationCode.Equals(si.substationCode))?.f33kOutInfo
                });
            }

            return Json(data);
        }


        #endregion


    }

}