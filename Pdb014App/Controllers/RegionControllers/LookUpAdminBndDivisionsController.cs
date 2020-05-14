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
    public class LookUpAdminBndDivisionsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpAdminBndDivisionsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpAdminBndDivisions
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpAdminBndDivision.ToListAsync());
        }

        // GET: LookUpAdminBndDivisions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndDivision = await _context.LookUpAdminBndDivision
                .FirstOrDefaultAsync(m => m.DivisionGeoCode == id);
            if (lookUpAdminBndDivision == null)
            {
                return NotFound();
            }

            return View(lookUpAdminBndDivision);
        }

        // GET: LookUpAdminBndDivisions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpAdminBndDivisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DivisionGeoCode,DivisionName")] LookUpAdminBndDivision lookUpAdminBndDivision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpAdminBndDivision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpAdminBndDivision);
        }

        // GET: LookUpAdminBndDivisions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndDivision = await _context.LookUpAdminBndDivision.FindAsync(id);
            if (lookUpAdminBndDivision == null)
            {
                return NotFound();
            }
            return View(lookUpAdminBndDivision);
        }

        // POST: LookUpAdminBndDivisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DivisionGeoCode,DivisionName")] LookUpAdminBndDivision lookUpAdminBndDivision)
        {
            if (id != lookUpAdminBndDivision.DivisionGeoCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpAdminBndDivision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpAdminBndDivisionExists(lookUpAdminBndDivision.DivisionGeoCode))
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
            return View(lookUpAdminBndDivision);
        }

        // GET: LookUpAdminBndDivisions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAdminBndDivision = await _context.LookUpAdminBndDivision
                .FirstOrDefaultAsync(m => m.DivisionGeoCode == id);
            if (lookUpAdminBndDivision == null)
            {
                return NotFound();
            }

            return View(lookUpAdminBndDivision);
        }

        // POST: LookUpAdminBndDivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpAdminBndDivision = await _context.LookUpAdminBndDivision.FindAsync(id);
            _context.LookUpAdminBndDivision.Remove(lookUpAdminBndDivision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpAdminBndDivisionExists(string id)
        {
            return _context.LookUpAdminBndDivision.Any(e => e.DivisionGeoCode == id);
        }
    }
}
