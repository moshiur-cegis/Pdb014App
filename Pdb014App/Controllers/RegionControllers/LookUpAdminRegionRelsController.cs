using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.RegionModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.RegionControllers
{
    public class LookUpAdminRegionRelsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpAdminRegionRelsController(PdbDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public JsonResult GetUnionList(string sndCode)
        {
            var distList = _context.LookUpAdminRegionRel
                .Where(d => d.SnDCode.Equals(sndCode))
                .Select(d => new { d.UnionGeoCode, d.Union.UnionName })
                .OrderBy(d => d.UnionName)
                .ToList();

            return Json(new SelectList(distList, "UnionGeoCode", "UnionName"));
        }

        [HttpPost]
        public JsonResult GetSnDList(string unionCode)
        {
            var distList = _context.LookUpAdminRegionRel
                .Where(d => d.UnionGeoCode.Equals(unionCode))
                .Select(d => new { d.SnDCode, d.SnD.SnDName })
                .OrderBy(d => d.SnDCode)
                .ToList();

            return Json(new SelectList(distList, "SnDCode", "SnDName"));
        }


        // GET: LookUpAdminRegionRels
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpAdminRegionRel.Include(l => l.SnD).Include(l => l.Union);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpAdminRegionRels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminRegionRel = await _context.LookUpAdminRegionRel
                .Include(l => l.SnD)
                .Include(l => l.Union)
                .FirstOrDefaultAsync(m => m.UnionGeoCode == id);
            if (lookUpAdminRegionRel == null)
            {
                return NotFound();
            }

            return View(lookUpAdminRegionRel);
        }

        // GET: LookUpAdminRegionRels/Create
        public IActionResult Create()
        {
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode");
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode");
            return View();
        }

        // POST: LookUpAdminRegionRels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnionGeoCode,SnDCode")] LookUpAdminRegionRel lookUpAdminRegionRel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpAdminRegionRel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", lookUpAdminRegionRel.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", lookUpAdminRegionRel.UnionGeoCode);
            return View(lookUpAdminRegionRel);
        }

        // GET: LookUpAdminRegionRels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminRegionRel = await _context.LookUpAdminRegionRel.FindAsync(id);
            if (lookUpAdminRegionRel == null)
            {
                return NotFound();
            }
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", lookUpAdminRegionRel.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", lookUpAdminRegionRel.UnionGeoCode);
            return View(lookUpAdminRegionRel);
        }

        // POST: LookUpAdminRegionRels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UnionGeoCode,SnDCode")] LookUpAdminRegionRel lookUpAdminRegionRel)
        {
            if (id != lookUpAdminRegionRel.UnionGeoCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpAdminRegionRel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpAdminRegionRelExists(lookUpAdminRegionRel.UnionGeoCode))
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
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", lookUpAdminRegionRel.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", lookUpAdminRegionRel.UnionGeoCode);
            return View(lookUpAdminRegionRel);
        }

        // GET: LookUpAdminRegionRels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminRegionRel = await _context.LookUpAdminRegionRel
                .Include(l => l.SnD)
                .Include(l => l.Union)
                .FirstOrDefaultAsync(m => m.UnionGeoCode == id);
            if (lookUpAdminRegionRel == null)
            {
                return NotFound();
            }

            return View(lookUpAdminRegionRel);
        }

        // POST: LookUpAdminRegionRels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpAdminRegionRel = await _context.LookUpAdminRegionRel.FindAsync(id);
            _context.LookUpAdminRegionRel.Remove(lookUpAdminRegionRel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpAdminRegionRelExists(string id)
        {
            return _context.LookUpAdminRegionRel.Any(e => e.UnionGeoCode == id);
        }
    }
}
