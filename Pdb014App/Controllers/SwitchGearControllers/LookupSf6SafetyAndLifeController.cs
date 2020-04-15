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
    public class LookupSf6SafetyAndLifeController : Controller
    {
        private readonly PdbDbContext _context;

        public LookupSf6SafetyAndLifeController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookupSf6SafetyAndLife
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookupSf6SafetyAndLife.ToListAsync());
        }

        // GET: LookupSf6SafetyAndLife/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupSf6SafetyAndLife = await _context.LookupSf6SafetyAndLife
                .FirstOrDefaultAsync(m => m.Sf6SafetyAndLifeId == id);
            if (lookupSf6SafetyAndLife == null)
            {
                return NotFound();
            }

            return View(lookupSf6SafetyAndLife);
        }

        // GET: LookupSf6SafetyAndLife/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookupSf6SafetyAndLife/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sf6SafetyAndLifeId,SF6Pressure,RatedPressureAt20C,MinimumfunctionalpressureAt20C,BurstingPressure,GasLeakageRate,SafetyIndication,CapacitiveVoltageIndicatorEUJapanUSAOrigin,GasPressureManometer,BusBarGasPressureManometer,LifeEnduranceOfSwitchgear,CircuitBreakers,DisconnectorsAndEarthingSwitches")] LookupSf6SafetyAndLife lookupSf6SafetyAndLife)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookupSf6SafetyAndLife);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookupSf6SafetyAndLife);
        }

        // GET: LookupSf6SafetyAndLife/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupSf6SafetyAndLife = await _context.LookupSf6SafetyAndLife.FindAsync(id);
            if (lookupSf6SafetyAndLife == null)
            {
                return NotFound();
            }
            return View(lookupSf6SafetyAndLife);
        }

        // POST: LookupSf6SafetyAndLife/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sf6SafetyAndLifeId,SF6Pressure,RatedPressureAt20C,MinimumfunctionalpressureAt20C,BurstingPressure,GasLeakageRate,SafetyIndication,CapacitiveVoltageIndicatorEUJapanUSAOrigin,GasPressureManometer,BusBarGasPressureManometer,LifeEnduranceOfSwitchgear,CircuitBreakers,DisconnectorsAndEarthingSwitches")] LookupSf6SafetyAndLife lookupSf6SafetyAndLife)
        {
            if (id != lookupSf6SafetyAndLife.Sf6SafetyAndLifeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookupSf6SafetyAndLife);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookupSf6SafetyAndLifeExists(lookupSf6SafetyAndLife.Sf6SafetyAndLifeId))
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
            return View(lookupSf6SafetyAndLife);
        }

        // GET: LookupSf6SafetyAndLife/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupSf6SafetyAndLife = await _context.LookupSf6SafetyAndLife
                .FirstOrDefaultAsync(m => m.Sf6SafetyAndLifeId == id);
            if (lookupSf6SafetyAndLife == null)
            {
                return NotFound();
            }

            return View(lookupSf6SafetyAndLife);
        }

        // POST: LookupSf6SafetyAndLife/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookupSf6SafetyAndLife = await _context.LookupSf6SafetyAndLife.FindAsync(id);
            _context.LookupSf6SafetyAndLife.Remove(lookupSf6SafetyAndLife);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookupSf6SafetyAndLifeExists(int id)
        {
            return _context.LookupSf6SafetyAndLife.Any(e => e.Sf6SafetyAndLifeId == id);
        }
    }
}
