using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.PhasePowerTransformerModel;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.PtControllers
{
    public class TblSurgeArrestorsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblSurgeArrestorsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblSurgeArrestors
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblSurgeArrestor.Include(t => t.SurgeArrestorToPhasePowerTransformer);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblSurgeArrestors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSurgeArrestor = await _context.TblSurgeArrestor
                .Include(t => t.SurgeArrestorToPhasePowerTransformer)
                .FirstOrDefaultAsync(m => m.SurgeArrestorId == id);
            if (tblSurgeArrestor == null)
            {
                return NotFound();
            }

            return View(tblSurgeArrestor);
        }

        // GET: TblSurgeArrestors/Create
        public IActionResult Create()
        {
            ViewData["PhasePowerTransformerId"] = new SelectList(_context.TblPhasePowerTransformer, "PhasePowerTransformerId", "PhasePowerTransformerId");
            return View();
        }

        // POST: TblSurgeArrestors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurgeArrestorId,ManufacturersNameAndAddress,ClassOfDiverterToIEC99To4,RatedVoltage,RatedVoltageRMSkV30,RatedCurrent,NeutralConnection,PowerFreqWithstandVoltageOfHousing,Dry,Wet,Impulse,LightingImpulseResidualVoltage,SteepCurrentImpulseResidualVoltageAt10kAOr1MicrosFrontTime,HighCurrentImpulseWithStandValue4Or10MicroS,SwitchingImpulseResidentialVoltage50Or100MicroS,PressureReliefDeviceFitted,TemporaryOverVoltageCapability,PointOneSeconds,OneSecond,TenSeconds,HunderdSeconds,LeakageCurrentatRatedVoltage,MinimumResetVoltage,TotalCreepageDistance,SurgeMonitor,ConnectingLeadfromLATerminaltoSurgeMonitor,OverallDimensionandWeight,Height,Diameter,TotalWeightofArrester,PhasePowerTransformerId")] TblSurgeArrestor tblSurgeArrestor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSurgeArrestor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhasePowerTransformerId"] = new SelectList(_context.TblPhasePowerTransformer, "PhasePowerTransformerId", "PhasePowerTransformerId", tblSurgeArrestor.PhasePowerTransformerId);
            return View(tblSurgeArrestor);
        }

        // GET: TblSurgeArrestors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSurgeArrestor = await _context.TblSurgeArrestor.FindAsync(id);
            if (tblSurgeArrestor == null)
            {
                return NotFound();
            }
            ViewData["PhasePowerTransformerId"] = new SelectList(_context.TblPhasePowerTransformer, "PhasePowerTransformerId", "PhasePowerTransformerId", tblSurgeArrestor.PhasePowerTransformerId);
            return View(tblSurgeArrestor);
        }

        // POST: TblSurgeArrestors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SurgeArrestorId,ManufacturersNameAndAddress,ClassOfDiverterToIEC99To4,RatedVoltage,RatedVoltageRMSkV30,RatedCurrent,NeutralConnection,PowerFreqWithstandVoltageOfHousing,Dry,Wet,Impulse,LightingImpulseResidualVoltage,SteepCurrentImpulseResidualVoltageAt10kAOr1MicrosFrontTime,HighCurrentImpulseWithStandValue4Or10MicroS,SwitchingImpulseResidentialVoltage50Or100MicroS,PressureReliefDeviceFitted,TemporaryOverVoltageCapability,PointOneSeconds,OneSecond,TenSeconds,HunderdSeconds,LeakageCurrentatRatedVoltage,MinimumResetVoltage,TotalCreepageDistance,SurgeMonitor,ConnectingLeadfromLATerminaltoSurgeMonitor,OverallDimensionandWeight,Height,Diameter,TotalWeightofArrester,PhasePowerTransformerId")] TblSurgeArrestor tblSurgeArrestor)
        {
            if (id != tblSurgeArrestor.SurgeArrestorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSurgeArrestor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSurgeArrestorExists(tblSurgeArrestor.SurgeArrestorId))
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
            ViewData["PhasePowerTransformerId"] = new SelectList(_context.TblPhasePowerTransformer, "PhasePowerTransformerId", "PhasePowerTransformerId", tblSurgeArrestor.PhasePowerTransformerId);
            return View(tblSurgeArrestor);
        }

        // GET: TblSurgeArrestors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSurgeArrestor = await _context.TblSurgeArrestor
                .Include(t => t.SurgeArrestorToPhasePowerTransformer)
                .FirstOrDefaultAsync(m => m.SurgeArrestorId == id);
            if (tblSurgeArrestor == null)
            {
                return NotFound();
            }

            return View(tblSurgeArrestor);
        }

        // POST: TblSurgeArrestors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblSurgeArrestor = await _context.TblSurgeArrestor.FindAsync(id);
            _context.TblSurgeArrestor.Remove(tblSurgeArrestor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSurgeArrestorExists(string id)
        {
            return _context.TblSurgeArrestor.Any(e => e.SurgeArrestorId == id);
        }
    }
}
