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
    public class LookUpLocationsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpLocationsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpLocation.ToListAsync());
        }

        // GET: LookUpLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpLocation = await _context.LookUpLocation
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (lookUpLocation == null)
            {
                return NotFound();
            }

            return View(lookUpLocation);
        }

        // GET: LookUpLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,LocationName")] LookUpLocation lookUpLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpLocation);
        }

        // GET: LookUpLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpLocation = await _context.LookUpLocation.FindAsync(id);
            if (lookUpLocation == null)
            {
                return NotFound();
            }
            return View(lookUpLocation);
        }

        // POST: LookUpLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,LocationName")] LookUpLocation lookUpLocation)
        {
            if (id != lookUpLocation.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpLocationExists(lookUpLocation.LocationId))
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
            return View(lookUpLocation);
        }

        // GET: LookUpLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpLocation = await _context.LookUpLocation
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (lookUpLocation == null)
            {
                return NotFound();
            }

            return View(lookUpLocation);
        }

        // POST: LookUpLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpLocation = await _context.LookUpLocation.FindAsync(id);
            _context.LookUpLocation.Remove(lookUpLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpLocationExists(int id)
        {
            return _context.LookUpLocation.Any(e => e.LocationId == id);
        }
    }
}
