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
    public class LookUpDifferentTypesOfRelaysController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpDifferentTypesOfRelaysController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpDifferentTypesOfRelays
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpDifferentTypesOfRelay.ToListAsync());
        }

        // GET: LookUpDifferentTypesOfRelays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentTypesOfRelay = await _context.LookUpDifferentTypesOfRelay
                .FirstOrDefaultAsync(m => m.RelayTypeId == id);
            if (lookUpDifferentTypesOfRelay == null)
            {
                return NotFound();
            }

            return View(lookUpDifferentTypesOfRelay);
        }

        // GET: LookUpDifferentTypesOfRelays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpDifferentTypesOfRelays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelayTypeId,RelayTypeName")] LookUpDifferentTypesOfRelay lookUpDifferentTypesOfRelay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpDifferentTypesOfRelay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpDifferentTypesOfRelay);
        }

        // GET: LookUpDifferentTypesOfRelays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentTypesOfRelay = await _context.LookUpDifferentTypesOfRelay.FindAsync(id);
            if (lookUpDifferentTypesOfRelay == null)
            {
                return NotFound();
            }
            return View(lookUpDifferentTypesOfRelay);
        }

        // POST: LookUpDifferentTypesOfRelays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelayTypeId,RelayTypeName")] LookUpDifferentTypesOfRelay lookUpDifferentTypesOfRelay)
        {
            if (id != lookUpDifferentTypesOfRelay.RelayTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpDifferentTypesOfRelay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpDifferentTypesOfRelayExists(lookUpDifferentTypesOfRelay.RelayTypeId))
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
            return View(lookUpDifferentTypesOfRelay);
        }

        // GET: LookUpDifferentTypesOfRelays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentTypesOfRelay = await _context.LookUpDifferentTypesOfRelay
                .FirstOrDefaultAsync(m => m.RelayTypeId == id);
            if (lookUpDifferentTypesOfRelay == null)
            {
                return NotFound();
            }

            return View(lookUpDifferentTypesOfRelay);
        }

        // POST: LookUpDifferentTypesOfRelays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpDifferentTypesOfRelay = await _context.LookUpDifferentTypesOfRelay.FindAsync(id);
            _context.LookUpDifferentTypesOfRelay.Remove(lookUpDifferentTypesOfRelay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpDifferentTypesOfRelayExists(int id)
        {
            return _context.LookUpDifferentTypesOfRelay.Any(e => e.RelayTypeId == id);
        }
    }
}
