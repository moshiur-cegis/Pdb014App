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
    public class LookUpDifferentTypesOfMetersController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpDifferentTypesOfMetersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpDifferentTypesOfMeters
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpDifferentTypesOfMeter.ToListAsync());
        }

        // GET: LookUpDifferentTypesOfMeters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentTypesOfMeter = await _context.LookUpDifferentTypesOfMeter
                .FirstOrDefaultAsync(m => m.MeterTypeId == id);
            if (lookUpDifferentTypesOfMeter == null)
            {
                return NotFound();
            }

            return View(lookUpDifferentTypesOfMeter);
        }

        // GET: LookUpDifferentTypesOfMeters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpDifferentTypesOfMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeterTypeId,MeterTypeName")] LookUpDifferentTypesOfMeter lookUpDifferentTypesOfMeter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpDifferentTypesOfMeter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpDifferentTypesOfMeter);
        }

        // GET: LookUpDifferentTypesOfMeters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentTypesOfMeter = await _context.LookUpDifferentTypesOfMeter.FindAsync(id);
            if (lookUpDifferentTypesOfMeter == null)
            {
                return NotFound();
            }
            return View(lookUpDifferentTypesOfMeter);
        }

        // POST: LookUpDifferentTypesOfMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeterTypeId,MeterTypeName")] LookUpDifferentTypesOfMeter lookUpDifferentTypesOfMeter)
        {
            if (id != lookUpDifferentTypesOfMeter.MeterTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpDifferentTypesOfMeter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpDifferentTypesOfMeterExists(lookUpDifferentTypesOfMeter.MeterTypeId))
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
            return View(lookUpDifferentTypesOfMeter);
        }

        // GET: LookUpDifferentTypesOfMeters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDifferentTypesOfMeter = await _context.LookUpDifferentTypesOfMeter
                .FirstOrDefaultAsync(m => m.MeterTypeId == id);
            if (lookUpDifferentTypesOfMeter == null)
            {
                return NotFound();
            }

            return View(lookUpDifferentTypesOfMeter);
        }

        // POST: LookUpDifferentTypesOfMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpDifferentTypesOfMeter = await _context.LookUpDifferentTypesOfMeter.FindAsync(id);
            _context.LookUpDifferentTypesOfMeter.Remove(lookUpDifferentTypesOfMeter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpDifferentTypesOfMeterExists(int id)
        {
            return _context.LookUpDifferentTypesOfMeter.Any(e => e.MeterTypeId == id);
        }
    }
}
