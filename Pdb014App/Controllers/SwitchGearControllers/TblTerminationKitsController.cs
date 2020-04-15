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
    public class TblTerminationKitsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblTerminationKitsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblTerminationKits
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblTerminationKit.Include(t => t.TerminationKitToBusBar);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblTerminationKits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTerminationKit = await _context.TblTerminationKit
                .Include(t => t.TerminationKitToBusBar)
                .FirstOrDefaultAsync(m => m.TerminationKitId == id);
            if (tblTerminationKit == null)
            {
                return NotFound();
            }

            return View(tblTerminationKit);
        }

        // GET: TblTerminationKits/Create
        public IActionResult Create()
        {
            ViewData["BusBarId"] = new SelectList(_context.LookupBusBar, "BusBarId", "BusBarId");
            return View();
        }

        // POST: TblTerminationKits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TerminationKitId,BusBarId,LineCapacity,TypeofTerminationKit,Application,Installation,NominalSystemVoltage,MaximumSystemVoltage,PowerFrequencyWithstandVoltage,NumberofCore,TypeofInsulation,TypeofScreening,TypeofCableBox,SystemNeutralEarthing,ConductorCrossSection,ImpulseWithstandVoltage")] TblTerminationKit tblTerminationKit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTerminationKit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusBarId"] = new SelectList(_context.LookupBusBar, "BusBarId", "BusBarId", tblTerminationKit.BusBarId);
            return View(tblTerminationKit);
        }

        // GET: TblTerminationKits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTerminationKit = await _context.TblTerminationKit.FindAsync(id);
            if (tblTerminationKit == null)
            {
                return NotFound();
            }
            ViewData["BusBarId"] = new SelectList(_context.LookupBusBar, "BusBarId", "BusBarId", tblTerminationKit.BusBarId);
            return View(tblTerminationKit);
        }

        // POST: TblTerminationKits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TerminationKitId,BusBarId,LineCapacity,TypeofTerminationKit,Application,Installation,NominalSystemVoltage,MaximumSystemVoltage,PowerFrequencyWithstandVoltage,NumberofCore,TypeofInsulation,TypeofScreening,TypeofCableBox,SystemNeutralEarthing,ConductorCrossSection,ImpulseWithstandVoltage")] TblTerminationKit tblTerminationKit)
        {
            if (id != tblTerminationKit.TerminationKitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTerminationKit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTerminationKitExists(tblTerminationKit.TerminationKitId))
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
            ViewData["BusBarId"] = new SelectList(_context.LookupBusBar, "BusBarId", "BusBarId", tblTerminationKit.BusBarId);
            return View(tblTerminationKit);
        }

        // GET: TblTerminationKits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTerminationKit = await _context.TblTerminationKit
                .Include(t => t.TerminationKitToBusBar)
                .FirstOrDefaultAsync(m => m.TerminationKitId == id);
            if (tblTerminationKit == null)
            {
                return NotFound();
            }

            return View(tblTerminationKit);
        }

        // POST: TblTerminationKits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTerminationKit = await _context.TblTerminationKit.FindAsync(id);
            _context.TblTerminationKit.Remove(tblTerminationKit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTerminationKitExists(int id)
        {
            return _context.TblTerminationKit.Any(e => e.TerminationKitId == id);
        }
    }
}
