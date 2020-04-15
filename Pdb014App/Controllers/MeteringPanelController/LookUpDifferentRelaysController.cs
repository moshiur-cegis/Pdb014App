using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.MeteringPanelModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.MeteringPanelController
{
    public class LookUpDifferentRelaysController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpDifferentRelaysController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpDifferentRelays
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpDifferentRelay
                .Include(l => l.DifferentTypesOfRelay);

            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpDifferentRelays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentRelay = await _context.LookUpDifferentRelay
                .Include(l => l.DifferentTypesOfRelay)
                .FirstOrDefaultAsync(m => m.DifferentRelayId == id);
            if (lookUpDifferentRelay == null)
            {
                return NotFound();
            }

            return View(lookUpDifferentRelay);
        }

        // GET: LookUpDifferentRelays/Create
        public IActionResult Create()
        {
            ViewData["RelayTypeId"] = new SelectList(_context.LookUpDifferentTypesOfRelay, "RelayTypeId", "RelayTypeName");
            return View();
        }

        // POST: LookUpDifferentRelays/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DifferentRelayId,ManufacturersName,CountryOfOrigin,ManufacturersModelNo,RelayTypeId")] LookUpDifferentRelay lookUpDifferentRelay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpDifferentRelay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RelayTypeId"] = new SelectList(_context.LookUpDifferentTypesOfRelay, "RelayTypeId", "RelayTypeName", lookUpDifferentRelay.RelayTypeId);
            return View(lookUpDifferentRelay);
        }

        // GET: LookUpDifferentRelays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentRelay = await _context.LookUpDifferentRelay.FindAsync(id);
            if (lookUpDifferentRelay == null)
            {
                return NotFound();
            }
            ViewData["RelayTypeId"] = new SelectList(_context.LookUpDifferentTypesOfRelay, "RelayTypeId", "RelayTypeName", lookUpDifferentRelay.RelayTypeId);
            return View(lookUpDifferentRelay);
        }

        // POST: LookUpDifferentRelays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DifferentRelayId,ManufacturersName,CountryOfOrigin,ManufacturersModelNo,RelayTypeId")] LookUpDifferentRelay lookUpDifferentRelay)
        {
            if (id != lookUpDifferentRelay.DifferentRelayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpDifferentRelay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpDifferentRelayExists(lookUpDifferentRelay.DifferentRelayId))
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
            ViewData["RelayTypeId"] = new SelectList(_context.LookUpDifferentTypesOfRelay, "RelayTypeId", "RelayTypeName", lookUpDifferentRelay.RelayTypeId);
            return View(lookUpDifferentRelay);
        }

        // GET: LookUpDifferentRelays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentRelay = await _context.LookUpDifferentRelay
                .Include(l => l.DifferentTypesOfRelay)
                .FirstOrDefaultAsync(m => m.DifferentRelayId == id);
            if (lookUpDifferentRelay == null)
            {
                return NotFound();
            }

            return View(lookUpDifferentRelay);
        }

        // POST: LookUpDifferentRelays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpDifferentRelay = await _context.LookUpDifferentRelay.FindAsync(id);
            _context.LookUpDifferentRelay.Remove(lookUpDifferentRelay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpDifferentRelayExists(int id)
        {
            return _context.LookUpDifferentRelay.Any(e => e.DifferentRelayId == id);
        }
    }
}
