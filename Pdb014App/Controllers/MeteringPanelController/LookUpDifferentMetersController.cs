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
    public class LookUpDifferentMetersController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpDifferentMetersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpDifferentMeters
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpDifferentMeter.Include(l => l.DifferentTypesOfMeter);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpDifferentMeters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentMeter = await _context.LookUpDifferentMeter
                .Include(l => l.DifferentTypesOfMeter)
                .FirstOrDefaultAsync(m => m.DifferentMeterId == id);
            if (lookUpDifferentMeter == null)
            {
                return NotFound();
            }

            return View(lookUpDifferentMeter);
        }

        // GET: LookUpDifferentMeters/Create
        public IActionResult Create()
        {
            ViewData["MeterTypeId"] = new SelectList(_context.LookUpDifferentTypesOfMeter, "MeterTypeId", "MeterTypeName");
            return View();
        }

        // POST: LookUpDifferentMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DifferentMeterId,MeterName,ManufacturersNameandCountry,ManufacturesModelNo,TypeOfMeter,ClassOfAccuracy,SeparateAmeterforEachPhase,MeterTypeId")] LookUpDifferentMeter lookUpDifferentMeter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpDifferentMeter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeterTypeId"] = new SelectList(_context.LookUpDifferentTypesOfMeter, "MeterTypeId", "MeterTypeName", lookUpDifferentMeter.MeterTypeId);
            return View(lookUpDifferentMeter);
        }

        // GET: LookUpDifferentMeters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentMeter = await _context.LookUpDifferentMeter.FindAsync(id);
            if (lookUpDifferentMeter == null)
            {
                return NotFound();
            }
            ViewData["MeterTypeId"] = new SelectList(_context.LookUpDifferentTypesOfMeter, "MeterTypeId", "MeterTypeName", lookUpDifferentMeter.MeterTypeId);
            return View(lookUpDifferentMeter);
        }

        // POST: LookUpDifferentMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DifferentMeterId,MeterName,ManufacturersNameandCountry,ManufacturesModelNo,TypeOfMeter,ClassOfAccuracy,SeparateAmeterforEachPhase,MeterTypeId")] LookUpDifferentMeter lookUpDifferentMeter)
        {
            if (id != lookUpDifferentMeter.DifferentMeterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpDifferentMeter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpDifferentMeterExists(lookUpDifferentMeter.DifferentMeterId))
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
            ViewData["MeterTypeId"] = new SelectList(_context.LookUpDifferentTypesOfMeter, "MeterTypeId", "MeterTypeName", lookUpDifferentMeter.MeterTypeId);
            return View(lookUpDifferentMeter);
        }

        // GET: LookUpDifferentMeters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentMeter = await _context.LookUpDifferentMeter
                .Include(l => l.DifferentTypesOfMeter)
                .FirstOrDefaultAsync(m => m.DifferentMeterId == id);
            if (lookUpDifferentMeter == null)
            {
                return NotFound();
            }

            return View(lookUpDifferentMeter);
        }

        // POST: LookUpDifferentMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpDifferentMeter = await _context.LookUpDifferentMeter.FindAsync(id);
            _context.LookUpDifferentMeter.Remove(lookUpDifferentMeter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpDifferentMeterExists(int id)
        {
            return _context.LookUpDifferentMeter.Any(e => e.DifferentMeterId == id);
        }
    }
}
