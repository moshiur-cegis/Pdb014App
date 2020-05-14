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
    public class LookUpAdminBndUnionsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpAdminBndUnionsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpAdminBndUnions
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpAdminBndUnion.Include(l => l.District).Include(l => l.Upazila);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpAdminBndUnions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndUnion = await _context.LookUpAdminBndUnion
                .Include(l => l.District)
                .Include(l => l.Upazila)
                .FirstOrDefaultAsync(m => m.UnionGeoCode == id);
            if (lookUpAdminBndUnion == null)
            {
                return NotFound();
            }

            return View(lookUpAdminBndUnion);
        }

        // GET: LookUpAdminBndUnions/Create
        public IActionResult Create()
        {
            ViewData["DistrictGeoCode"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictGeoCode");
            ViewData["UpazilaGeoCode"] = new SelectList(_context.LookUpAdminBndUpazila, "UpazilaGeoCode", "UpazilaGeoCode");
            return View();
        }

        // POST: LookUpAdminBndUnions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnionGeoCode,UnionName,DistrictGeoCode,UpazilaGeoCode")] LookUpAdminBndUnion lookUpAdminBndUnion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpAdminBndUnion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictGeoCode"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictGeoCode", lookUpAdminBndUnion.DistrictGeoCode);
            ViewData["UpazilaGeoCode"] = new SelectList(_context.LookUpAdminBndUpazila, "UpazilaGeoCode", "UpazilaGeoCode", lookUpAdminBndUnion.UpazilaGeoCode);
            return View(lookUpAdminBndUnion);
        }

        // GET: LookUpAdminBndUnions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndUnion = await _context.LookUpAdminBndUnion.FindAsync(id);
            if (lookUpAdminBndUnion == null)
            {
                return NotFound();
            }
            ViewData["DistrictGeoCode"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictGeoCode", lookUpAdminBndUnion.DistrictGeoCode);
            ViewData["UpazilaGeoCode"] = new SelectList(_context.LookUpAdminBndUpazila, "UpazilaGeoCode", "UpazilaGeoCode", lookUpAdminBndUnion.UpazilaGeoCode);
            return View(lookUpAdminBndUnion);
        }

        // POST: LookUpAdminBndUnions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UnionGeoCode,UnionName,DistrictGeoCode,UpazilaGeoCode")] LookUpAdminBndUnion lookUpAdminBndUnion)
        {
            if (id != lookUpAdminBndUnion.UnionGeoCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpAdminBndUnion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpAdminBndUnionExists(lookUpAdminBndUnion.UnionGeoCode))
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
            ViewData["DistrictGeoCode"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictGeoCode", lookUpAdminBndUnion.DistrictGeoCode);
            ViewData["UpazilaGeoCode"] = new SelectList(_context.LookUpAdminBndUpazila, "UpazilaGeoCode", "UpazilaGeoCode", lookUpAdminBndUnion.UpazilaGeoCode);
            return View(lookUpAdminBndUnion);
        }

        // GET: LookUpAdminBndUnions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndUnion = await _context.LookUpAdminBndUnion
                .Include(l => l.District)
                .Include(l => l.Upazila)
                .FirstOrDefaultAsync(m => m.UnionGeoCode == id);
            if (lookUpAdminBndUnion == null)
            {
                return NotFound();
            }

            return View(lookUpAdminBndUnion);
        }

        // POST: LookUpAdminBndUnions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpAdminBndUnion = await _context.LookUpAdminBndUnion.FindAsync(id);
            _context.LookUpAdminBndUnion.Remove(lookUpAdminBndUnion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpAdminBndUnionExists(string id)
        {
            return _context.LookUpAdminBndUnion.Any(e => e.UnionGeoCode == id);
        }
    }
}
