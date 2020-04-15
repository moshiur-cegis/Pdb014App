using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.LookUpModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.RegionControllers
{
    public class LookUpZoneInfoesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpZoneInfoesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpZoneInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpZoneInfo.ToListAsync());
        }

        // GET: LookUpZoneInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpZoneInfo = await _context.LookUpZoneInfo
                .FirstOrDefaultAsync(m => m.ZoneCode == id);
            if (lookUpZoneInfo == null)
            {
                return NotFound();
            }

            return View(lookUpZoneInfo);
        }


        [HttpPost]
        public JsonResult GetZoneList()
        {
            var sndList = _context.LookUpZoneInfo
                .Select(z => new { z.ZoneCode, z.ZoneName })
                .OrderBy(z => z.ZoneName).ToList();

            return Json(new SelectList(sndList, "ZoneCode", "ZoneName"));
        }


        [HttpPost]
        public JsonResult GetSubStationList(string sndCode)
        {
            var substationList = _context.TblSubstation
                .Where(ss => string.IsNullOrEmpty(sndCode) || ss.SnDCode.Equals(sndCode))
                .Select(ss => new { ss.SubstationId, ss.SubstationName })
                .OrderBy(ss => ss.SubstationId).ToList();

            return Json(new SelectList(substationList, "SubstationId", "SubstationName"));
        }

        [HttpPost]
        public JsonResult GetFeederLineList(string routeCode)
        {
            var sndList = _context.TblFeederLine
                .Where(fl => string.IsNullOrEmpty(routeCode) || fl.RouteCode.Equals(routeCode))
                .Select(fl => new { fl.FeederLineId, FeederName = fl.FeederName })
                .OrderBy(fl => fl.FeederLineId).ToList();

            return Json(new SelectList(sndList, "FeederLineId", "FeederName"));
        }

        


        // GET: LookUpZoneInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpZoneInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoneCode,ZoneName,SortingNo")] LookUpZoneInfo lookUpZoneInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpZoneInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpZoneInfo);
        }

        // GET: LookUpZoneInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpZoneInfo = await _context.LookUpZoneInfo.FindAsync(id);
            if (lookUpZoneInfo == null)
            {
                return NotFound();
            }
            return View(lookUpZoneInfo);
        }

        // POST: LookUpZoneInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ZoneCode,ZoneName,SortingNo")] LookUpZoneInfo lookUpZoneInfo)
        {
            if (id != lookUpZoneInfo.ZoneCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpZoneInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpZoneInfoExists(lookUpZoneInfo.ZoneCode))
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
            return View(lookUpZoneInfo);
        }

        // GET: LookUpZoneInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpZoneInfo = await _context.LookUpZoneInfo
                .FirstOrDefaultAsync(m => m.ZoneCode == id);
            if (lookUpZoneInfo == null)
            {
                return NotFound();
            }

            return View(lookUpZoneInfo);
        }

        // POST: LookUpZoneInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpZoneInfo = await _context.LookUpZoneInfo.FindAsync(id);
            _context.LookUpZoneInfo.Remove(lookUpZoneInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpZoneInfoExists(string id)
        {
            return _context.LookUpZoneInfo.Any(e => e.ZoneCode == id);
        }
    }
}
