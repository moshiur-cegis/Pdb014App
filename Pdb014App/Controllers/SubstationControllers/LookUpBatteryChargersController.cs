using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.SubstationControllers
{
    public class LookUpBatteryChargersController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpBatteryChargersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpBatteryChargers
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpBatteryCharger.Include(l => l.BatteryChargerToSubstation);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpBatteryChargers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpBatteryCharger = await _context.LookUpBatteryCharger
                .Include(l => l.BatteryChargerToSubstation)
                .FirstOrDefaultAsync(m => m.BatteryChargerId == id);
            if (lookUpBatteryCharger == null)
            {
                return NotFound();
            }

            return View(lookUpBatteryCharger);
        }

        // GET: LookUpBatteryChargers/Create
        public IActionResult Create()
        {
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId");
            return View();
        }

        // POST: LookUpBatteryChargers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatteryChargerId,SubstationId,ManufacturersNameAndCompany,ManufacturersModelNo,Rating,RatedInputVoltageRange,RatedFrequency,NoOfPhase,NominalOutputVoltage,ChargingOperatingControl,OutputCurrent,ContinuousCurrentRating,Efficiency,VoltageRegulation")] LookUpBatteryCharger lookUpBatteryCharger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpBatteryCharger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", lookUpBatteryCharger.SubstationId);
            return View(lookUpBatteryCharger);
        }

        // GET: LookUpBatteryChargers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpBatteryCharger = await _context.LookUpBatteryCharger.FindAsync(id);
            if (lookUpBatteryCharger == null)
            {
                return NotFound();
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", lookUpBatteryCharger.SubstationId);
            return View(lookUpBatteryCharger);
        }

        // POST: LookUpBatteryChargers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatteryChargerId,SubstationId,ManufacturersNameAndCompany,ManufacturersModelNo,Rating,RatedInputVoltageRange,RatedFrequency,NoOfPhase,NominalOutputVoltage,ChargingOperatingControl,OutputCurrent,ContinuousCurrentRating,Efficiency,VoltageRegulation")] LookUpBatteryCharger lookUpBatteryCharger)
        {
            if (id != lookUpBatteryCharger.BatteryChargerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpBatteryCharger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpBatteryChargerExists(lookUpBatteryCharger.BatteryChargerId))
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
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", lookUpBatteryCharger.SubstationId);
            return View(lookUpBatteryCharger);
        }

        // GET: LookUpBatteryChargers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpBatteryCharger = await _context.LookUpBatteryCharger
                .Include(l => l.BatteryChargerToSubstation)
                .FirstOrDefaultAsync(m => m.BatteryChargerId == id);
            if (lookUpBatteryCharger == null)
            {
                return NotFound();
            }

            return View(lookUpBatteryCharger);
        }

        // POST: LookUpBatteryChargers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpBatteryCharger = await _context.LookUpBatteryCharger.FindAsync(id);
            _context.LookUpBatteryCharger.Remove(lookUpBatteryCharger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpBatteryChargerExists(int id)
        {
            return _context.LookUpBatteryCharger.Any(e => e.BatteryChargerId == id);
        }
    }
}
