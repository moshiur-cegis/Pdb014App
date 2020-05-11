using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.ServicePointModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.ServicePointControllers
{
    public class TblServicePointsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblServicePointsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblServicePoints
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblServicePoint.Include(t => t.ServicePointToPole).Include(t => t.ServicePointType).Include(t => t.VoltageCategory);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblServicePoints/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServicePoint = await _context.TblServicePoint
                .Include(sp => sp.ServicePointType)
                .Include(sp => sp.VoltageCategory)
                .Include(sp => sp.ServicePointToPole)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .FirstOrDefaultAsync(m => m.ServicesPointId == id);


            if (tblServicePoint == null)
            {
                return NotFound();
            }

            return View(tblServicePoint);
        }

        // GET: TblServicePoints/Create
        public IActionResult Create()
        {
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["ServicePointTypeId"] = new SelectList(_context.LookUpServicePointType, "ServicePointTypeId", "ServicePointTypeName");
            ViewData["VoltageCategoryId"] = new SelectList(_context.LookUpVoltageCategory, "VoltageCategoryId", "VoltageCategoryName");
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View();
        }

        // POST: TblServicePoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicesPointId,PoleId,VoltageCategoryId,TransformerNumber,ServicePointTypeId,AggregateLoadkw,NoOFConsumersR,NoOFConsumersY,NoOFConsumersB,NoOfConsumersRyb,RoadName,VillageOrAreaName,Ward,CityTown,PrimaryLandmark")] TblServicePoint tblServicePoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblServicePoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblServicePoint.PoleId);
            ViewData["ServicePointTypeId"] = new SelectList(_context.LookUpServicePointType, "ServicePointTypeId", "ServicePointTypeName", tblServicePoint.ServicePointTypeId);
            ViewData["VoltageCategoryId"] = new SelectList(_context.LookUpVoltageCategory, "VoltageCategoryId", "VoltageCategoryName", tblServicePoint.VoltageCategoryId);
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View(tblServicePoint);
        }

        // GET: TblServicePoints/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServicePoint = await _context.TblServicePoint.FindAsync(id);
            if (tblServicePoint == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblServicePoint.PoleId);
            ViewData["ServicePointTypeId"] = new SelectList(_context.LookUpServicePointType, "ServicePointTypeId", "ServicePointTypeName", tblServicePoint.ServicePointTypeId);
            ViewData["VoltageCategoryId"] = new SelectList(_context.LookUpVoltageCategory, "VoltageCategoryId", "VoltageCategoryName", tblServicePoint.VoltageCategoryId);
            return View(tblServicePoint);
        }

        // POST: TblServicePoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ServicesPointId,PoleId,VoltageCategoryId,TransformerNumber,ServicePointTypeId,AggregateLoadkw,NoOFConsumersR,NoOFConsumersY,NoOFConsumersB,NoOfConsumersRyb,RoadName,VillageOrAreaName,Ward,CityTown,PrimaryLandmark")] TblServicePoint tblServicePoint)
        {
            if (id != tblServicePoint.ServicesPointId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblServicePoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblServicePointExists(tblServicePoint.ServicesPointId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblServicePoint.PoleId);
            ViewData["ServicePointTypeId"] = new SelectList(_context.LookUpServicePointType, "ServicePointTypeId", "ServicePointTypeName", tblServicePoint.ServicePointTypeId);
            ViewData["VoltageCategoryId"] = new SelectList(_context.LookUpVoltageCategory, "VoltageCategoryId", "VoltageCategoryName", tblServicePoint.VoltageCategoryId);
            return View(tblServicePoint);
        }

        // GET: TblServicePoints/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServicePoint = await _context.TblServicePoint
                .Include(t => t.ServicePointToPole)
                .Include(t => t.ServicePointType)
                .Include(t => t.VoltageCategory)
                .FirstOrDefaultAsync(m => m.ServicesPointId == id);
            if (tblServicePoint == null)
            {
                return NotFound();
            }

            return View(tblServicePoint);
        }

        // POST: TblServicePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblServicePoint = await _context.TblServicePoint.FindAsync(id);
            _context.TblServicePoint.Remove(tblServicePoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblServicePointExists(string id)
        {
            return _context.TblServicePoint.Any(e => e.ServicesPointId == id);
        }

        [HttpPost]
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
            var sndList = _context.TblFeederLine
                .Where(u => u.RouteCode.Equals(routeCode))
                .Select(u => new { u.FeederLineId, FeederName = u.FeederName })
                .OrderBy(u => u.FeederLineId).ToList();

            return Json(new SelectList(sndList, "FeederLineId", "FeederName"));
        }

        public JsonResult GetPoleList(string feederLineId)
        {

            var sndList = _context.TblPole
               .Where(u => u.FeederLineId.Equals(feederLineId))
               .Select(u => new { u.PoleId, PoleIds = u.PoleId })
               .OrderBy(u => u.PoleId).ToList();

            return Json(new SelectList(sndList, "PoleId", "PoleIds"));


        }

    }
}
