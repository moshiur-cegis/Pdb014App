using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB;
using Pdb014App.Repository;
using ReflectionIT.Mvc.Paging;

namespace Pdb014App.Controllers.SubstationControllers
{
    public class TblFeederLinesController : Controller
    {
        private readonly PdbDbContext _context;

        public TblFeederLinesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblFeederLines
        public async Task<IActionResult> Index(string filter, int pageIndex = 1, string sortExpression = "FeederLineId")
        {
            var qry = _context.TblFeederLine
                .Include(t => t.FeederLineToRoute)
                .Include(t => t.FeederLineType).AsQueryable();

            if (filter != null)
            {
                qry = qry.Where(p => p.FeederLineId == filter);
            }

            var model = await PagingList.CreateAsync(qry, 10, pageIndex, sortExpression, "FeederLineId");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        // GET: TblFeederLines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFeederLine = await _context.TblFeederLine
                .Include(fl => fl.FeederLineToRoute)
                .Include(fl => fl.FeederLineType)

                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                
                .FirstOrDefaultAsync(m => m.FeederLineId == id);

            if (tblFeederLine == null)
            {
                return NotFound();
            }

            return View(tblFeederLine);
        }

        // GET: TblFeederLines/Create
        public IActionResult Create()
        {
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteCode");
            ViewData["FeederLineTypeId"] = new SelectList(_context.LookUpFeederLineType, "FeederLineTypeId", "FeederLineTypeName");
            return View();
        }

        // POST: TblFeederLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeederLineId,FeederLineUId,FeederLineTypeId,RouteCode,FeederName,NominalVoltage,FeederLocation,FeedermeterNumber,MeterCurrentRating,MeterVoltageRating,MaximumDemand,PeakDemand,MaximumLoad,SanctionedLoad")] TblFeederLine tblFeederLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFeederLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteCode", tblFeederLine.RouteCode);
            ViewData["FeederLineTypeId"] = new SelectList(_context.LookUpFeederLineType, "FeederLineTypeId", "FeederLineTypeId", tblFeederLine.FeederLineTypeId);
            return View(tblFeederLine);
        }

        // GET: TblFeederLines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFeederLine = await _context.TblFeederLine.FindAsync(id);
            if (tblFeederLine == null)
            {
                return NotFound();
            }
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteName", tblFeederLine.RouteCode);
            ViewData["FeederLineTypeId"] = new SelectList(_context.LookUpFeederLineType, "FeederLineTypeId", "FeederLineTypeName", tblFeederLine.FeederLineTypeId);
            return View(tblFeederLine);
        }

        // POST: TblFeederLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FeederLineId,FeederLineUId,FeederLineTypeId,RouteCode,FeederName,NominalVoltage,FeederLocation,FeedermeterNumber,MeterCurrentRating,MeterVoltageRating,MaximumDemand,PeakDemand,MaximumLoad,SanctionedLoad")] TblFeederLine tblFeederLine)
        {
            if (id != tblFeederLine.FeederLineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFeederLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblFeederLineExists(tblFeederLine.FeederLineId))
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
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteCode", tblFeederLine.RouteCode);
            ViewData["FeederLineTypeId"] = new SelectList(_context.LookUpFeederLineType, "FeederLineTypeId", "FeederLineTypeId", tblFeederLine.FeederLineTypeId);
            return View(tblFeederLine);
        }

        // GET: TblFeederLines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFeederLine = await _context.TblFeederLine
                .Include(t => t.FeederLineToRoute)
                .Include(t => t.FeederLineType)
                .FirstOrDefaultAsync(m => m.FeederLineId == id);
            if (tblFeederLine == null)
            {
                return NotFound();
            }

            return View(tblFeederLine);
        }

        // POST: TblFeederLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblFeederLine = await _context.TblFeederLine.FindAsync(id);
            _context.TblFeederLine.Remove(tblFeederLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblFeederLineExists(string id)
        {
            return _context.TblFeederLine.Any(e => e.FeederLineId == id);
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
    }
}
