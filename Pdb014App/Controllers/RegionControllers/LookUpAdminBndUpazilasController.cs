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
    public class LookUpAdminBndUpazilasController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpAdminBndUpazilasController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpAdminBndUpazilas
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpAdminBndUpazila.Include(l => l.District);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpAdminBndUpazilas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndUpazila = await _context.LookUpAdminBndUpazila
                .Include(l => l.District)
                .FirstOrDefaultAsync(m => m.UpazilaGeoCode == id);
            if (lookUpAdminBndUpazila == null)
            {
                return NotFound();
            }

            return View(lookUpAdminBndUpazila);
        }

        // GET: LookUpAdminBndUpazilas/Create
        public IActionResult Create()
        {
            ViewData["DistrictGeoCode"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictGeoCode");
            return View();
        }

        // POST: LookUpAdminBndUpazilas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UpazilaGeoCode,UpazilaName,DistrictGeoCode")] LookUpAdminBndUpazila lookUpAdminBndUpazila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpAdminBndUpazila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictGeoCode"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictGeoCode", lookUpAdminBndUpazila.DistrictGeoCode);
            return View(lookUpAdminBndUpazila);
        }

        // GET: LookUpAdminBndUpazilas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndUpazila = await _context.LookUpAdminBndUpazila.FindAsync(id);
            if (lookUpAdminBndUpazila == null)
            {
                return NotFound();
            }
            ViewData["DistrictGeoCode"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictGeoCode", lookUpAdminBndUpazila.DistrictGeoCode);
            return View(lookUpAdminBndUpazila);
        }

        // POST: LookUpAdminBndUpazilas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UpazilaGeoCode,UpazilaName,DistrictGeoCode")] LookUpAdminBndUpazila lookUpAdminBndUpazila)
        {
            if (id != lookUpAdminBndUpazila.UpazilaGeoCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpAdminBndUpazila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpAdminBndUpazilaExists(lookUpAdminBndUpazila.UpazilaGeoCode))
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
            ViewData["DistrictGeoCode"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictGeoCode", lookUpAdminBndUpazila.DistrictGeoCode);
            return View(lookUpAdminBndUpazila);
        }

        // GET: LookUpAdminBndUpazilas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndUpazila = await _context.LookUpAdminBndUpazila
                .Include(l => l.District)
                .FirstOrDefaultAsync(m => m.UpazilaGeoCode == id);
            if (lookUpAdminBndUpazila == null)
            {
                return NotFound();
            }

            return View(lookUpAdminBndUpazila);
        }

        // POST: LookUpAdminBndUpazilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpAdminBndUpazila = await _context.LookUpAdminBndUpazila.FindAsync(id);
            _context.LookUpAdminBndUpazila.Remove(lookUpAdminBndUpazila);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpAdminBndUpazilaExists(string id)
        {
            return _context.LookUpAdminBndUpazila.Any(e => e.UpazilaGeoCode == id);
        }
    }
}
