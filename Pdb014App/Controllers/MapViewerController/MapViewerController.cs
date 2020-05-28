using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models;
using Pdb014App.Models.MapViewer.Settings;
using Pdb014App.Models.PDB.LookUpModels;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Repository;
using ReflectionIT.Mvc.Paging;

namespace Pdb014App.Controllers
{
    public class MapViewerController : Controller
    {
        private readonly PdbDbContext _context;

        public MapViewerController(PdbDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult MeasureDistance()
        {            
            return View();
        }

        [HttpGet]
        public IActionResult MapView()
        {
            ViewData["GisServer"] = _context.LookUpMapViewGisServer.Where(x => x.GisServerActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewGisServer
                                                                   {
                                                                       GisServerFullUrl = s.GisServerFullUrl,
                                                                       GisServerIPAddress = s.GisServerIPAddress
                                                                   }).FirstOrDefault();

            ViewData["ApplicationServer"] = _context.LookUpMapViewApplicationServer.Where(x => x.AppServerActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewApplicationServer
                                                                   {
                                                                       AppServerFullUrl = s.AppServerFullUrl
                                                                   }).FirstOrDefault();

            ViewData["BaseMap"] = _context.LookUpMapViewBaseMapDetail.Where(x => x.BaseMapActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewBaseMapDetail
                                                                   {
                                                                       BaseMapName = s.BaseMapName,
                                                                       DefaultZoomLevel = s.DefaultZoomLevel,
                                                                       BaseMapCenterLat = s.BaseMapCenterLat,
                                                                       BaseMapCenterLong = s.BaseMapCenterLong,
                                                                       MinScale = s.MinScale
                                                                   }).FirstOrDefault();

            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View();
        }
        
        [HttpGet]
        public IActionResult MapViewDev()
        {
            ViewData["GisServer"] = _context.LookUpMapViewGisServer.Where(x => x.GisServerActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewGisServer
                                                                   {
                                                                       GisServerFullUrl = s.GisServerFullUrl,
                                                                       GisServerIPAddress = s.GisServerIPAddress
                                                                   }).FirstOrDefault();

            ViewData["ApplicationServer"] = _context.LookUpMapViewApplicationServer.Where(x => x.AppServerActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewApplicationServer
                                                                   {
                                                                       AppServerFullUrl = s.AppServerFullUrl
                                                                   }).FirstOrDefault();

            ViewData["BaseMap"] = _context.LookUpMapViewBaseMapDetail.Where(x => x.BaseMapActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewBaseMapDetail
                                                                   {
                                                                       BaseMapName = s.BaseMapName,
                                                                       DefaultZoomLevel = s.DefaultZoomLevel,
                                                                       BaseMapCenterLat = s.BaseMapCenterLat,
                                                                       BaseMapCenterLong = s.BaseMapCenterLong,
                                                                       MinScale = s.MinScale
                                                                   }).FirstOrDefault();

            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View();
        }

        [HttpPost]
        public IActionResult MapViewDev(bool chkAllLayers, string zoneId, string circleId, string snDDivId, string subStationId, string routeId, string feederLineId)
        {
            var queryExpression = "";

            if (zoneId != null)
            {
                queryExpression = "ZoneId = " + zoneId;
                ViewBag.ExprZone = queryExpression;

                ViewData["ZoneBasicInfo"] = _context.LookUpZoneInfo.Where(w => w.ZoneCode == zoneId)
                                                                   .Select(s => new LookUpZoneInfo
                                                                   {
                                                                       CenterLatitude = s.CenterLatitude,
                                                                       CenterLongitude = s.CenterLongitude,
                                                                       MinScale = s.MinScale,
                                                                       DefaultZoomLevel = s.DefaultZoomLevel
                                                                   }).FirstOrDefault();
            }

            if (circleId != null)
            {
                queryExpression = queryExpression + " AND CircleId = " + circleId;
                ViewBag.ExprCircle = queryExpression;

                ViewData["CircleBasicInfo"] = _context.LookUpCircleInfo.Where(w => w.CircleCode == circleId)
                                                                   .Select(s => new LookUpCircleInfo
                                                                   {
                                                                       CenterLatitude = s.CenterLatitude,
                                                                       CenterLongitude = s.CenterLongitude,
                                                                       MinScale = s.MinScale,
                                                                       DefaultZoomLevel = s.DefaultZoomLevel
                                                                   }).FirstOrDefault();
            }

            if (snDDivId != null)
            {
                queryExpression = queryExpression + " AND SnDDivId = " + snDDivId;
                ViewBag.ExprSnDDiv = queryExpression;

                ViewData["SnDBasicInfo"] = _context.LookUpSnDInfo.Where(w => w.SnDCode == snDDivId)
                                                                   .Select(s => new LookUpSnDInfo
                                                                   {
                                                                       CenterLatitude = s.CenterLatitude,
                                                                       CenterLongitude = s.CenterLongitude,
                                                                       MinScale = s.MinScale,
                                                                       DefaultZoomLevel = s.DefaultZoomLevel
                                                                   }).FirstOrDefault();
            }

            if (subStationId != null)
            {
                queryExpression = queryExpression + " AND SubStationId = " + subStationId;
                ViewBag.ExprSubStation = queryExpression;

                ViewData["SubStationBasicInfo"] = _context.TblSubstation.Where(w => w.SubstationId == subStationId)
                                                                   .Select(s => new TblSubstation
                                                                   {
                                                                       Latitude = s.Latitude,
                                                                       Longitude = s.Longitude,                                                                       
                                                                       DefaultZoomLevel = s.DefaultZoomLevel
                                                                   }).FirstOrDefault();
            }

            if (routeId != null)
            {
                queryExpression = queryExpression + " AND RouteId = " + routeId;
                ViewBag.ExprRoute = queryExpression;
            }

            if (feederLineId != null)
            {
                queryExpression = queryExpression + " AND FeederLineId = " + feederLineId;
                ViewBag.ExprFeederLine = queryExpression;
            }

            ViewData["GisServer"] = _context.LookUpMapViewGisServer.Where(x => x.GisServerActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewGisServer
                                                                   {
                                                                       GisServerFullUrl = s.GisServerFullUrl,
                                                                       GisServerIPAddress = s.GisServerIPAddress
                                                                   }).FirstOrDefault();

            ViewData["ApplicationServer"] = _context.LookUpMapViewApplicationServer.Where(x => x.AppServerActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewApplicationServer
                                                                   {
                                                                       AppServerFullUrl = s.AppServerFullUrl
                                                                   }).FirstOrDefault();

            ViewData["BaseMap"] = _context.LookUpMapViewBaseMapDetail.Where(x => x.BaseMapActivationStatus == 1)
                                                                   .Select(s => new LookUpMapViewBaseMapDetail
                                                                   {
                                                                       BaseMapName = s.BaseMapName,
                                                                       DefaultZoomLevel = s.DefaultZoomLevel,
                                                                       BaseMapCenterLat = s.BaseMapCenterLat,
                                                                       BaseMapCenterLong = s.BaseMapCenterLong,
                                                                       MinScale = s.MinScale
                                                                   }).FirstOrDefault();

            ViewBag.DefExpression = queryExpression;
            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            if (chkAllLayers)
            {
                ViewBag.ExprZone = ViewBag.ExprCircle = ViewBag.ExprSnDDiv = ViewBag.ExprSubStation = ViewBag.ExprRoute = ViewBag.ExprFeederLine = null;
                ViewBag.IsAllLayersSelected = true;
            }

            return View();
        }
        
        public JsonResult GetDefaultBasicInfo()
        {
            var basicInfo = _context.LookUpMapViewBaseMapDetail.Where(w => w.BaseMapActivationStatus == 1)
                                                                   .Select(s => new
                                                                   {  
                                                                       CenterLatitude = s.BaseMapCenterLat,
                                                                       CenterLongitude = s.BaseMapCenterLong,
                                                                       MinScale = s.MinScale,
                                                                       DefaultZoomLevel = s.DefaultZoomLevel,
                                                                   }).FirstOrDefault();            
            return Json(basicInfo);
        }
        
        public JsonResult GetZoneBasicInfo(string zoneCode)
        {
            var basicInfo = _context.LookUpZoneInfo.Where(w => w.ZoneCode == zoneCode)
                                                                    .Select(s => new
                                                                    {
                                                                        CenterLatitude = s.CenterLatitude,
                                                                        CenterLongitude = s.CenterLongitude,
                                                                        MinScale = s.MinScale,
                                                                        DefaultZoomLevel = s.DefaultZoomLevel
                                                                    }).FirstOrDefault();
            return Json(basicInfo);
        }
        
        public JsonResult GetCircleBasicInfo(string circleCode)
        {
            var basicInfo = _context.LookUpCircleInfo.Where(w => w.CircleCode == circleCode)
                                                                    .Select(s => new
                                                                    {
                                                                        CenterLatitude = s.CenterLatitude,
                                                                        CenterLongitude = s.CenterLongitude,
                                                                        MinScale = s.MinScale,
                                                                        DefaultZoomLevel = s.DefaultZoomLevel
                                                                    }).FirstOrDefault();
            return Json(basicInfo);
        }
        
        public JsonResult GetSnDBasicInfo(string snDCode)
        {
            var basicInfo = _context.LookUpSnDInfo.Where(w => w.SnDCode == snDCode)
                                                                    .Select(s => new
                                                                    {
                                                                        CenterLatitude = s.CenterLatitude,
                                                                        CenterLongitude = s.CenterLongitude,
                                                                        MinScale = s.MinScale,
                                                                        DefaultZoomLevel = s.DefaultZoomLevel
                                                                    }).FirstOrDefault();
            return Json(basicInfo);
        }
        
        public JsonResult GetSubstationBasicInfo(string substationId)
        {
            var basicInfo = _context.TblSubstation.Where(w => w.SubstationId == substationId)
                                                                    .Select(s => new
                                                                    {
                                                                        CenterLatitude = s.Latitude,
                                                                        CenterLongitude = s.Longitude,                                                                        
                                                                        DefaultZoomLevel = s.DefaultZoomLevel
                                                                    }).FirstOrDefault();
            return Json(basicInfo);
        }

        public JsonResult GetCircleList(string zoneCode)
        {
            var circleList = _context.LookUpCircleInfo
                .Where(u => u.ZoneCode.Equals(zoneCode))
                .Select(u => new { u.CircleCode, u.CircleName })
                .OrderBy(u => u.CircleCode).ToList();

            return Json(new SelectList(circleList, "CircleCode", "CircleName"));
        }

        public JsonResult GetSnDList(string circleCode)
        {
            var sndList = _context.LookUpSnDInfo
                .Where(u => u.CircleCode.Equals(circleCode))
                .Select(u => new { u.SnDCode, u.SnDName })
                .OrderBy(u => u.SnDCode).ToList();

            return Json(new SelectList(sndList, "SnDCode", "SnDName"));
        }

        public JsonResult GetSubStationList(string sndCode)
        {
            var substationList = _context.TblSubstation
                .Where(u => u.SnDCode.Equals(sndCode))
                .Select(u => new { u.SubstationId, u.SubstationName })
                .OrderBy(u => u.SubstationId).ToList();

            return Json(new SelectList(substationList, "SubstationId", "SubstationName"));
        }

        public JsonResult GetRouteList(string substationId)
        {
            var sndList = _context.LookUpRouteInfo
                .Where(u => u.SubstationId.Equals(substationId))
                .Select(u => new { u.RouteCode, u.RouteName })
                .OrderBy(u => u.RouteCode).ToList();

            return Json(new SelectList(sndList, "RouteCode", "RouteName"));
        }

        public JsonResult GetFeederLineList(string routeCode)
        {
            var feederLineList = _context.TblFeederLine
                .Where(u => u.RouteCode.Equals(routeCode))
                .Select(u => new { u.FeederLineId, FeederName = u.FeederName })
                .OrderBy(u => u.FeederLineId).ToList();

            return Json(new SelectList(feederLineList, "FeederLineId", "FeederName"));
        }

        public JsonResult AddLayer(string zone)
        {            
            return Json(zone);
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
    }
}