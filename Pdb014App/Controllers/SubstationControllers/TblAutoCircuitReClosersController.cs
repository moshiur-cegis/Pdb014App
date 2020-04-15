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
    public class TblAutoCircuitReClosersController : Controller
    {
        private readonly PdbDbContext _context;

        public TblAutoCircuitReClosersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblAutoCircuitReClosers
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblAutoCircuitReCloser.Include(t => t.AutoCircuitReCloserIdToSubstation).Include(t => t.AutoCircuitReCloserType);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblAutoCircuitReClosers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAutoCircuitReCloser = await _context.TblAutoCircuitReCloser
                .Include(t => t.AutoCircuitReCloserIdToSubstation)
                .Include(t => t.AutoCircuitReCloserType)
                .FirstOrDefaultAsync(m => m.AutoCircuitReCloserId == id);
            if (tblAutoCircuitReCloser == null)
            {
                return NotFound();
            }

            return View(tblAutoCircuitReCloser);
        }

        // GET: TblAutoCircuitReClosers/Create
        public IActionResult Create()
        {
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName");
            ViewData["AutoCircuitReCloserTypeId"] = new SelectList(_context.LookUpAutoCircuitReCloserType, "AutoCircuitReCloserTypeId", "AutoCircuitReCloserTypeIdName");
            return View();
        }

        // POST: TblAutoCircuitReClosers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoCircuitReCloserId,AutoCircuitReCloserTypeId,SubstationId,ManufacturersNameAddress,CountryOfOrigin,TypeOfModel,InterruptingMedium,HermeticallySealed,ControlSystemforACR,InsulatingMedium,NominalSystemVoltage,MaximumVoltage,RatedFrequency,InsulationLevel,ImpulseWithstandVoltage,PowerFrequencyWithstandVoltage,RatedContinuousCurrent,MaximumRatedCurrent,RatedShortCircuitCurrent,SymmetricalInterruptingCurrent,AsymmetricalInterrupting,SymmetricalMakinoCurrent,ShortTimewithstandCurrent,ProtectionAndMeterningCTration,GasPressureIndicator")] TblAutoCircuitReCloser tblAutoCircuitReCloser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAutoCircuitReCloser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblAutoCircuitReCloser.SubstationId);
            ViewData["AutoCircuitReCloserTypeId"] = new SelectList(_context.LookUpAutoCircuitReCloserType, "AutoCircuitReCloserTypeId", "AutoCircuitReCloserTypeIdName", tblAutoCircuitReCloser.AutoCircuitReCloserTypeId);
            return View(tblAutoCircuitReCloser);
        }

        // GET: TblAutoCircuitReClosers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAutoCircuitReCloser = await _context.TblAutoCircuitReCloser.FindAsync(id);
            if (tblAutoCircuitReCloser == null)
            {
                return NotFound();
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblAutoCircuitReCloser.SubstationId);
            ViewData["AutoCircuitReCloserTypeId"] = new SelectList(_context.LookUpAutoCircuitReCloserType, "AutoCircuitReCloserTypeId", "AutoCircuitReCloserTypeIdName", tblAutoCircuitReCloser.AutoCircuitReCloserTypeId);
            return View(tblAutoCircuitReCloser);
        }

        // POST: TblAutoCircuitReClosers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoCircuitReCloserId,AutoCircuitReCloserTypeId,SubstationId,ManufacturersNameAddress,CountryOfOrigin,TypeOfModel,InterruptingMedium,HermeticallySealed,ControlSystemforACR,InsulatingMedium,NominalSystemVoltage,MaximumVoltage,RatedFrequency,InsulationLevel,ImpulseWithstandVoltage,PowerFrequencyWithstandVoltage,RatedContinuousCurrent,MaximumRatedCurrent,RatedShortCircuitCurrent,SymmetricalInterruptingCurrent,AsymmetricalInterrupting,SymmetricalMakinoCurrent,ShortTimewithstandCurrent,ProtectionAndMeterningCTration,GasPressureIndicator")] TblAutoCircuitReCloser tblAutoCircuitReCloser)
        {
            if (id != tblAutoCircuitReCloser.AutoCircuitReCloserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAutoCircuitReCloser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAutoCircuitReCloserExists(tblAutoCircuitReCloser.AutoCircuitReCloserId))
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
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblAutoCircuitReCloser.SubstationId);
            ViewData["AutoCircuitReCloserTypeId"] = new SelectList(_context.LookUpAutoCircuitReCloserType, "AutoCircuitReCloserTypeId", "AutoCircuitReCloserTypeIdName", tblAutoCircuitReCloser.AutoCircuitReCloserTypeId);
            return View(tblAutoCircuitReCloser);
        }

        // GET: TblAutoCircuitReClosers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAutoCircuitReCloser = await _context.TblAutoCircuitReCloser
                .Include(t => t.AutoCircuitReCloserIdToSubstation)
                .Include(t => t.AutoCircuitReCloserType)
                .FirstOrDefaultAsync(m => m.AutoCircuitReCloserId == id);
            if (tblAutoCircuitReCloser == null)
            {
                return NotFound();
            }

            return View(tblAutoCircuitReCloser);
        }

        // POST: TblAutoCircuitReClosers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAutoCircuitReCloser = await _context.TblAutoCircuitReCloser.FindAsync(id);
            _context.TblAutoCircuitReCloser.Remove(tblAutoCircuitReCloser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAutoCircuitReCloserExists(int id)
        {
            return _context.TblAutoCircuitReCloser.Any(e => e.AutoCircuitReCloserId == id);
        }
    }
}
