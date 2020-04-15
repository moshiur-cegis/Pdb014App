using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.DistributionTransformerModel;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.DtControllers
{
    public class TblPoleStructureMountedSurgeArrestorsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblPoleStructureMountedSurgeArrestorsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblPoleStructureMountedSurgeArrestors
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblPoleStructureMountedSurgearrestor.Include(t => t.SurgeArrestorToDistributionTransformer);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblPoleStructureMountedSurgeArrestors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleStructureMountedSurgeArrestor = await _context.TblPoleStructureMountedSurgearrestor
                .Include(t => t.SurgeArrestorToDistributionTransformer)
                .FirstOrDefaultAsync(m => m.PoleStructureMountedSurgeArrestorId == id);
            if (tblPoleStructureMountedSurgeArrestor == null)
            {
                return NotFound();
            }

            return View(tblPoleStructureMountedSurgeArrestor);
        }

        // GET: TblPoleStructureMountedSurgeArrestors/Create
        public IActionResult Create()
        {
            ViewData["DistributionTransformerId"] = new SelectList(_context.TblDistributionTransformer, "DistributionTransformerId", "DistributionTransformerId");
            return View();
        }

        // POST: TblPoleStructureMountedSurgeArrestors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoleStructureMountedSurgeArrestorId,Standard,Installation,TypeorModel,Construction,Application,NominalRatedVoltage,MaximumSystemVoltage,SystemFrequency,TypeofSystem,RatedArresterVoltage,Class,RatedArresterCurrent,HighCurrentWithstand,PressureReliefClass,BasicInsulationlevelBILat12or50MicroSecImpulses,LightningImpulseResidualVoltageAt8or20MicrosecCurrentWave,CreepageDistance,DistributionTransformerId")] TblPoleStructureMountedSurgeArrestor tblPoleStructureMountedSurgeArrestor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPoleStructureMountedSurgeArrestor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistributionTransformerId"] = new SelectList(_context.TblDistributionTransformer, "DistributionTransformerId", "DistributionTransformerId", tblPoleStructureMountedSurgeArrestor.DistributionTransformerId);
            return View(tblPoleStructureMountedSurgeArrestor);
        }

        // GET: TblPoleStructureMountedSurgeArrestors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleStructureMountedSurgeArrestor = await _context.TblPoleStructureMountedSurgearrestor.FindAsync(id);
            if (tblPoleStructureMountedSurgeArrestor == null)
            {
                return NotFound();
            }
            ViewData["DistributionTransformerId"] = new SelectList(_context.TblDistributionTransformer, "DistributionTransformerId", "DistributionTransformerId", tblPoleStructureMountedSurgeArrestor.DistributionTransformerId);
            return View(tblPoleStructureMountedSurgeArrestor);
        }

        // POST: TblPoleStructureMountedSurgeArrestors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PoleStructureMountedSurgeArrestorId,Standard,Installation,TypeorModel,Construction,Application,NominalRatedVoltage,MaximumSystemVoltage,SystemFrequency,TypeofSystem,RatedArresterVoltage,Class,RatedArresterCurrent,HighCurrentWithstand,PressureReliefClass,BasicInsulationlevelBILat12or50MicroSecImpulses,LightningImpulseResidualVoltageAt8or20MicrosecCurrentWave,CreepageDistance,DistributionTransformerId")] TblPoleStructureMountedSurgeArrestor tblPoleStructureMountedSurgeArrestor)
        {
            if (id != tblPoleStructureMountedSurgeArrestor.PoleStructureMountedSurgeArrestorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPoleStructureMountedSurgeArrestor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPoleStructureMountedSurgeArrestorExists(tblPoleStructureMountedSurgeArrestor.PoleStructureMountedSurgeArrestorId))
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
            ViewData["DistributionTransformerId"] = new SelectList(_context.TblDistributionTransformer, "DistributionTransformerId", "DistributionTransformerId", tblPoleStructureMountedSurgeArrestor.DistributionTransformerId);
            return View(tblPoleStructureMountedSurgeArrestor);
        }

        // GET: TblPoleStructureMountedSurgeArrestors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleStructureMountedSurgeArrestor = await _context.TblPoleStructureMountedSurgearrestor
                .Include(t => t.SurgeArrestorToDistributionTransformer)
                .FirstOrDefaultAsync(m => m.PoleStructureMountedSurgeArrestorId == id);
            if (tblPoleStructureMountedSurgeArrestor == null)
            {
                return NotFound();
            }

            return View(tblPoleStructureMountedSurgeArrestor);
        }

        // POST: TblPoleStructureMountedSurgeArrestors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblPoleStructureMountedSurgeArrestor = await _context.TblPoleStructureMountedSurgearrestor.FindAsync(id);
            _context.TblPoleStructureMountedSurgearrestor.Remove(tblPoleStructureMountedSurgeArrestor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPoleStructureMountedSurgeArrestorExists(string id)
        {
            return _context.TblPoleStructureMountedSurgearrestor.Any(e => e.PoleStructureMountedSurgeArrestorId == id);
        }
    }
}
