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
    public class LookUpRouteInfoesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpRouteInfoesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpRouteInfoes
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpRouteInfo.Include(l => l.RouteToSubstation);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpRouteInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpRouteInfo = await _context.LookUpRouteInfo
                .Include(l => l.RouteToSubstation)
                .FirstOrDefaultAsync(m => m.RouteCode == id);
            if (lookUpRouteInfo == null)
            {
                return NotFound();
            }

            return View(lookUpRouteInfo);
        }



        [HttpPost]
        public JsonResult GetRouteList(string substationId)
        {
            var sndList = _context.LookUpRouteInfo
                .Where(r => string.IsNullOrEmpty(substationId) || r.SubstationId.Equals(substationId))
                .Select(r => new { r.RouteCode, r.RouteName })
                .OrderBy(r => r.RouteCode).ToList();

            return Json(new SelectList(sndList, "RouteCode", "RouteName"));
        }



        // GET: LookUpRouteInfoes/Create
        public IActionResult Create()
        {
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName");
            return View();
        }

        // POST: LookUpRouteInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteCode,RouteName,SortingNo,SubstationId")] LookUpRouteInfo lookUpRouteInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpRouteInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", lookUpRouteInfo.SubstationId);
            return View(lookUpRouteInfo);
        }

        // GET: LookUpRouteInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpRouteInfo = await _context.LookUpRouteInfo.FindAsync(id);
            if (lookUpRouteInfo == null)
            {
                return NotFound();
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName", lookUpRouteInfo.SubstationId);
            return View(lookUpRouteInfo);
        }

        // POST: LookUpRouteInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RouteCode,RouteName,SortingNo,SubstationId")] LookUpRouteInfo lookUpRouteInfo)
        {
            if (id != lookUpRouteInfo.RouteCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpRouteInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpRouteInfoExists(lookUpRouteInfo.RouteCode))
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
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", lookUpRouteInfo.SubstationId);
            return View(lookUpRouteInfo);
        }

        // GET: LookUpRouteInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpRouteInfo = await _context.LookUpRouteInfo
                .Include(l => l.RouteToSubstation)
                .FirstOrDefaultAsync(m => m.RouteCode == id);
            if (lookUpRouteInfo == null)
            {
                return NotFound();
            }

            return View(lookUpRouteInfo);
        }

        // POST: LookUpRouteInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpRouteInfo = await _context.LookUpRouteInfo.FindAsync(id);
            _context.LookUpRouteInfo.Remove(lookUpRouteInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpRouteInfoExists(string id)
        {
            return _context.LookUpRouteInfo.Any(e => e.RouteCode == id);
        }
    }
}
