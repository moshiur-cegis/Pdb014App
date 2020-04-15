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
    public class TblIndoorOutdoorTypeProgrammableEnergyMetersController : Controller
    {
        private readonly PdbDbContext _context;

        public TblIndoorOutdoorTypeProgrammableEnergyMetersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblIndoorOutdoorTypeProgrammableEnergyMeters
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblIndoorOutdoorTypeProgrammableEnergyMeter.Include(t => t.IndoorOutdoorTypeProgrammableEnergyMeterToSwitchGear);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblIndoorOutdoorTypeProgrammableEnergyMeters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIndoorOutdoorTypeProgrammableEnergyMeter = await _context.TblIndoorOutdoorTypeProgrammableEnergyMeter
                .Include(t => t.IndoorOutdoorTypeProgrammableEnergyMeterToSwitchGear)
                .FirstOrDefaultAsync(m => m.EnergyMeterId == id);
            if (tblIndoorOutdoorTypeProgrammableEnergyMeter == null)
            {
                return NotFound();
            }

            return View(tblIndoorOutdoorTypeProgrammableEnergyMeter);
        }

        // GET: TblIndoorOutdoorTypeProgrammableEnergyMeters/Create
        public IActionResult Create()
        {
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID");
            return View();
        }

        // POST: TblIndoorOutdoorTypeProgrammableEnergyMeters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnergyMeterId,SwitchGearID,ManufacturersNameAddress,ManufacturersTypeAndModel,ConstructionConnection,Installation,RatedVoltage,MinimumBiasingVoltage,VariationOfFrequency,VariationOfVoltage,AccuracyClass,RatedCurrent,NominalCurrent,MaximumCurrent,MeterConstant,NoOfTerminal,YearOfManufacture,MeterSealingCondition")] TblIndoorOutdoorTypeProgrammableEnergyMeter tblIndoorOutdoorTypeProgrammableEnergyMeter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblIndoorOutdoorTypeProgrammableEnergyMeter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", tblIndoorOutdoorTypeProgrammableEnergyMeter.SwitchGearID);
            return View(tblIndoorOutdoorTypeProgrammableEnergyMeter);
        }

        // GET: TblIndoorOutdoorTypeProgrammableEnergyMeters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIndoorOutdoorTypeProgrammableEnergyMeter = await _context.TblIndoorOutdoorTypeProgrammableEnergyMeter.FindAsync(id);
            if (tblIndoorOutdoorTypeProgrammableEnergyMeter == null)
            {
                return NotFound();
            }
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", tblIndoorOutdoorTypeProgrammableEnergyMeter.SwitchGearID);
            return View(tblIndoorOutdoorTypeProgrammableEnergyMeter);
        }

        // POST: TblIndoorOutdoorTypeProgrammableEnergyMeters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnergyMeterId,SwitchGearID,ManufacturersNameAddress,ManufacturersTypeAndModel,ConstructionConnection,Installation,RatedVoltage,MinimumBiasingVoltage,VariationOfFrequency,VariationOfVoltage,AccuracyClass,RatedCurrent,NominalCurrent,MaximumCurrent,MeterConstant,NoOfTerminal,YearOfManufacture,MeterSealingCondition")] TblIndoorOutdoorTypeProgrammableEnergyMeter tblIndoorOutdoorTypeProgrammableEnergyMeter)
        {
            if (id != tblIndoorOutdoorTypeProgrammableEnergyMeter.EnergyMeterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblIndoorOutdoorTypeProgrammableEnergyMeter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblIndoorOutdoorTypeProgrammableEnergyMeterExists(tblIndoorOutdoorTypeProgrammableEnergyMeter.EnergyMeterId))
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
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", tblIndoorOutdoorTypeProgrammableEnergyMeter.SwitchGearID);
            return View(tblIndoorOutdoorTypeProgrammableEnergyMeter);
        }

        // GET: TblIndoorOutdoorTypeProgrammableEnergyMeters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblIndoorOutdoorTypeProgrammableEnergyMeter = await _context.TblIndoorOutdoorTypeProgrammableEnergyMeter
                .Include(t => t.IndoorOutdoorTypeProgrammableEnergyMeterToSwitchGear)
                .FirstOrDefaultAsync(m => m.EnergyMeterId == id);
            if (tblIndoorOutdoorTypeProgrammableEnergyMeter == null)
            {
                return NotFound();
            }

            return View(tblIndoorOutdoorTypeProgrammableEnergyMeter);
        }

        // POST: TblIndoorOutdoorTypeProgrammableEnergyMeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblIndoorOutdoorTypeProgrammableEnergyMeter = await _context.TblIndoorOutdoorTypeProgrammableEnergyMeter.FindAsync(id);
            _context.TblIndoorOutdoorTypeProgrammableEnergyMeter.Remove(tblIndoorOutdoorTypeProgrammableEnergyMeter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblIndoorOutdoorTypeProgrammableEnergyMeterExists(int id)
        {
            return _context.TblIndoorOutdoorTypeProgrammableEnergyMeter.Any(e => e.EnergyMeterId == id);
        }
    }
}
