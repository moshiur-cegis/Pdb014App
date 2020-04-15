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
    public class LookUpCircleInfoesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpCircleInfoesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpCircleInfoes
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpCircleInfo.Include(l => l.ZoneInfo);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpCircleInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCircleInfo = await _context.LookUpCircleInfo
                .Include(l => l.ZoneInfo)
                .FirstOrDefaultAsync(m => m.CircleCode == id);
            if (lookUpCircleInfo == null)
            {
                return NotFound();
            }

            return View(lookUpCircleInfo);
        }
        

        [HttpPost]
        public JsonResult GetCircleList(string zoneCode)
        {
            var circleList = _context.LookUpCircleInfo
                .Where(c => string.IsNullOrEmpty(zoneCode) || c.ZoneCode.Equals(zoneCode))
                .Select(c => new { c.CircleCode, c.CircleName })
                .OrderBy(c => c.CircleCode).ToList();

            return Json(new SelectList(circleList, "CircleCode", "CircleName"));
        }

        


        // GET: LookUpCircleInfoes/Create
        public IActionResult Create()
        {
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo, "ZoneCode", "ZoneName");
            return View();
        }

        // POST: LookUpCircleInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CircleCode,CircleName,SortingNo,ZoneCode")] LookUpCircleInfo lookUpCircleInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpCircleInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo, "ZoneCode", "ZoneCode", lookUpCircleInfo.ZoneCode);
            return View(lookUpCircleInfo);
        }

        // GET: LookUpCircleInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCircleInfo = await _context.LookUpCircleInfo.FindAsync(id);
            if (lookUpCircleInfo == null)
            {
                return NotFound();
            }
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo, "ZoneCode", "ZoneName", lookUpCircleInfo.ZoneCode);
            return View(lookUpCircleInfo);
        }

        // POST: LookUpCircleInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CircleCode,CircleName,SortingNo,ZoneCode")] LookUpCircleInfo lookUpCircleInfo)
        {
            if (id != lookUpCircleInfo.CircleCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpCircleInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpCircleInfoExists(lookUpCircleInfo.CircleCode))
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
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo, "ZoneCode", "ZoneCode", lookUpCircleInfo.ZoneCode);
            return View(lookUpCircleInfo);
        }

        // GET: LookUpCircleInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCircleInfo = await _context.LookUpCircleInfo
                .Include(l => l.ZoneInfo)
                .FirstOrDefaultAsync(m => m.CircleCode == id);
            if (lookUpCircleInfo == null)
            {
                return NotFound();
            }

            return View(lookUpCircleInfo);
        }

        // POST: LookUpCircleInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpCircleInfo = await _context.LookUpCircleInfo.FindAsync(id);
            _context.LookUpCircleInfo.Remove(lookUpCircleInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpCircleInfoExists(string id)
        {
            return _context.LookUpCircleInfo.Any(e => e.CircleCode == id);
        }
    }
}
