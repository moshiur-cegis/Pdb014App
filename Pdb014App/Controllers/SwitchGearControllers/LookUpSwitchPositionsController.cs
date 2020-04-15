using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.SwitchGearModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.SwitchGearControllers
{
    public class LookUpSwitchPositionsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpSwitchPositionsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpSwitchPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpSwitchPosition.ToListAsync());
        }

        // GET: LookUpSwitchPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSwitchPosition = await _context.LookUpSwitchPosition
                .FirstOrDefaultAsync(m => m.SwitchPositionId == id);
            if (lookUpSwitchPosition == null)
            {
                return NotFound();
            }

            return View(lookUpSwitchPosition);
        }

        // GET: LookUpSwitchPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpSwitchPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SwitchPositionId,ElectricalAndMechanicalInterlock,CurrentTransformer,RatedVoltage,AccuracyClassMetering,AccuracyClassOCEFProtection,RatedCurrentRatio,Burden,RatedFrequency")] LookUpSwitchPosition lookUpSwitchPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpSwitchPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpSwitchPosition);
        }

        // GET: LookUpSwitchPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSwitchPosition = await _context.LookUpSwitchPosition.FindAsync(id);
            if (lookUpSwitchPosition == null)
            {
                return NotFound();
            }
            return View(lookUpSwitchPosition);
        }

        // POST: LookUpSwitchPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SwitchPositionId,ElectricalAndMechanicalInterlock,CurrentTransformer,RatedVoltage,AccuracyClassMetering,AccuracyClassOCEFProtection,RatedCurrentRatio,Burden,RatedFrequency")] LookUpSwitchPosition lookUpSwitchPosition)
        {
            if (id != lookUpSwitchPosition.SwitchPositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpSwitchPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpSwitchPositionExists(lookUpSwitchPosition.SwitchPositionId))
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
            return View(lookUpSwitchPosition);
        }

        // GET: LookUpSwitchPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSwitchPosition = await _context.LookUpSwitchPosition
                .FirstOrDefaultAsync(m => m.SwitchPositionId == id);
            if (lookUpSwitchPosition == null)
            {
                return NotFound();
            }

            return View(lookUpSwitchPosition);
        }

        // POST: LookUpSwitchPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpSwitchPosition = await _context.LookUpSwitchPosition.FindAsync(id);
            _context.LookUpSwitchPosition.Remove(lookUpSwitchPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpSwitchPositionExists(int id)
        {
            return _context.LookUpSwitchPosition.Any(e => e.SwitchPositionId == id);
        }
    }
}
