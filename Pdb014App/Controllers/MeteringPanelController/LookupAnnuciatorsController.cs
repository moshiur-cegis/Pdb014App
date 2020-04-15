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
    public class LookupAnnuciatorsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookupAnnuciatorsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookupAnnuciators
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookupAnnuciator.ToListAsync());
        }

        // GET: LookupAnnuciators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupAnnuciator = await _context.LookupAnnuciator
                .FirstOrDefaultAsync(m => m.AnnuciatorId == id);
            if (lookupAnnuciator == null)
            {
                return NotFound();
            }

            return View(lookupAnnuciator);
        }

        // GET: LookupAnnuciators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookupAnnuciators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnnuciatorId,Annunciator,ManufacturesName,CountryofOrigin,ManufacturesModelNo")] LookupAnnuciator lookupAnnuciator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookupAnnuciator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookupAnnuciator);
        }

        // GET: LookupAnnuciators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupAnnuciator = await _context.LookupAnnuciator.FindAsync(id);
            if (lookupAnnuciator == null)
            {
                return NotFound();
            }
            return View(lookupAnnuciator);
        }

        // POST: LookupAnnuciators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnnuciatorId,Annunciator,ManufacturesName,CountryofOrigin,ManufacturesModelNo")] LookupAnnuciator lookupAnnuciator)
        {
            if (id != lookupAnnuciator.AnnuciatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookupAnnuciator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookupAnnuciatorExists(lookupAnnuciator.AnnuciatorId))
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
            return View(lookupAnnuciator);
        }

        // GET: LookupAnnuciators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupAnnuciator = await _context.LookupAnnuciator
                .FirstOrDefaultAsync(m => m.AnnuciatorId == id);
            if (lookupAnnuciator == null)
            {
                return NotFound();
            }

            return View(lookupAnnuciator);
        }

        // POST: LookupAnnuciators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookupAnnuciator = await _context.LookupAnnuciator.FindAsync(id);
            _context.LookupAnnuciator.Remove(lookupAnnuciator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookupAnnuciatorExists(int id)
        {
            return _context.LookupAnnuciator.Any(e => e.AnnuciatorId == id);
        }
    }
}
