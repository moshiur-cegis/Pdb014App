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
    public class LookUpAdminBndDistrictsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpAdminBndDistrictsController(PdbDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult GetDistrictList(string divCode)
        {
            var distList = _context.LookUpAdminBndDistrict
                .Where(d => d.DivisionGeoCode.Equals(divCode))
                .Select(d => new { d.DistrictGeoCode, d.DistrictName })
                .OrderBy(d => d.DistrictName)
                .ToList();

            return Json(new SelectList(distList, "DistrictGeoCode", "DistrictName"));
        }

        // GET: LookUpAdminBndDistricts
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpAdminBndDistrict.Include(l => l.Division);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpAdminBndDistricts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndDistrict = await _context.LookUpAdminBndDistrict
                .Include(l => l.Division)
                .FirstOrDefaultAsync(m => m.DistrictGeoCode == id);
            if (lookUpAdminBndDistrict == null)
            {
                return NotFound();
            }

            return View(lookUpAdminBndDistrict);
        }

        // GET: LookUpAdminBndDistricts/Create
        public IActionResult Create()
        {
            ViewData["DivisionGeoCode"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionGeoCode");
            return View();
        }

        // POST: LookUpAdminBndDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistrictGeoCode,DistrictName,DivisionGeoCode")] LookUpAdminBndDistrict lookUpAdminBndDistrict)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpAdminBndDistrict);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivisionGeoCode"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionGeoCode", lookUpAdminBndDistrict.DivisionGeoCode);
            return View(lookUpAdminBndDistrict);
        }

        // GET: LookUpAdminBndDistricts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndDistrict = await _context.LookUpAdminBndDistrict.FindAsync(id);
            if (lookUpAdminBndDistrict == null)
            {
                return NotFound();
            }
            ViewData["DivisionGeoCode"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionGeoCode", lookUpAdminBndDistrict.DivisionGeoCode);
            return View(lookUpAdminBndDistrict);
        }

        // POST: LookUpAdminBndDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DistrictGeoCode,DistrictName,DivisionGeoCode")] LookUpAdminBndDistrict lookUpAdminBndDistrict)
        {
            if (id != lookUpAdminBndDistrict.DistrictGeoCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpAdminBndDistrict);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpAdminBndDistrictExists(lookUpAdminBndDistrict.DistrictGeoCode))
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
            ViewData["DivisionGeoCode"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionGeoCode", lookUpAdminBndDistrict.DivisionGeoCode);
            return View(lookUpAdminBndDistrict);
        }

        // GET: LookUpAdminBndDistricts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndDistrict = await _context.LookUpAdminBndDistrict
                .Include(l => l.Division)
                .FirstOrDefaultAsync(m => m.DistrictGeoCode == id);
            if (lookUpAdminBndDistrict == null)
            {
                return NotFound();
            }

            return View(lookUpAdminBndDistrict);
        }

        // POST: LookUpAdminBndDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpAdminBndDistrict = await _context.LookUpAdminBndDistrict.FindAsync(id);
            _context.LookUpAdminBndDistrict.Remove(lookUpAdminBndDistrict);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpAdminBndDistrictExists(string id)
        {
            return _context.LookUpAdminBndDistrict.Any(e => e.DistrictGeoCode == id);
        }
    }
}
