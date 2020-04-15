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
    public class TblXLPEaluminiumCopperGalvanize11KVController : Controller
    {
        private readonly PdbDbContext _context;

        public TblXLPEaluminiumCopperGalvanize11KVController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblXLPEaluminiumCopperGalvanize11KV
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblXLPEaluminiumCopperGalvanize11KV.Include(t => t.CopperGalvanize11KVTo132or33kVSubStation).Include(t => t.CopperGalvanize11KVTo33or11kVSubStationID).Include(t => t.TblSwitchGear);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblXLPEaluminiumCopperGalvanize11KV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblXLPEaluminiumCopperGalvanize11KV = await _context.TblXLPEaluminiumCopperGalvanize11KV
                .Include(t => t.CopperGalvanize11KVTo132or33kVSubStation)
                .Include(t => t.CopperGalvanize11KVTo33or11kVSubStationID)
                .Include(t => t.TblSwitchGear)
                .FirstOrDefaultAsync(m => m.XLPEaluminiumCopperGalvanize11KVId == id);
            if (tblXLPEaluminiumCopperGalvanize11KV == null)
            {
                return NotFound();
            }

            return View(tblXLPEaluminiumCopperGalvanize11KV);
        }

        // GET: TblXLPEaluminiumCopperGalvanize11KV/Create
        public IActionResult Create()
        {
            ViewData["Source132or33kVSubStationID"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId");
            ViewData["Source33or11kVSubStationID"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId");
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID");
            return View();
        }

        // POST: TblXLPEaluminiumCopperGalvanize11KV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("XLPEaluminiumCopperGalvanize11KVId,SwitchGearID,NominalCrossSectionalAreaofPhaseConductor,DiameterofPhaseConductor,SingleCoreStranding,ThicknessofInsulation,DiameterOverInsulationApproximately,NominalCrossSectionalAreaofScreen,ThicknessofOverSheath,OverallDiameterApproximately,GalvanizedSteelRopeNominalCrossSectionalAreaofRope,Stranding,ThicknessofCovering,OverallDiameterofRope,ThreeCoresStrandedAroundSuspensionUnitDiameterof,StrandedBundleApproximately,TotalWeightApproximately,NominalVoltageratingUOorU,MaximumAdmissibleContinuousWorkingVoltage,MaximumDCResistanceAt20C,WorkingInductance,WorkingCapacitance,EarthLeakageCurrent,ShortCircuitCurrentOfConductor,OfScreen,CurrentRatingatAmbienttempof40C,ACTestVoltage,Source33or11kVSubStationID,Source132or33kVSubStationID,CurrentCarryingCapacity")] TblXLPEaluminiumCopperGalvanize11KV tblXLPEaluminiumCopperGalvanize11KV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblXLPEaluminiumCopperGalvanize11KV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Source132or33kVSubStationID"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblXLPEaluminiumCopperGalvanize11KV.Source132or33kVSubStationID);
            ViewData["Source33or11kVSubStationID"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblXLPEaluminiumCopperGalvanize11KV.Source33or11kVSubStationID);
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", tblXLPEaluminiumCopperGalvanize11KV.SwitchGearID);
            return View(tblXLPEaluminiumCopperGalvanize11KV);
        }

        // GET: TblXLPEaluminiumCopperGalvanize11KV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblXLPEaluminiumCopperGalvanize11KV = await _context.TblXLPEaluminiumCopperGalvanize11KV.FindAsync(id);
            if (tblXLPEaluminiumCopperGalvanize11KV == null)
            {
                return NotFound();
            }
            ViewData["Source132or33kVSubStationID"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblXLPEaluminiumCopperGalvanize11KV.Source132or33kVSubStationID);
            ViewData["Source33or11kVSubStationID"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblXLPEaluminiumCopperGalvanize11KV.Source33or11kVSubStationID);
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", tblXLPEaluminiumCopperGalvanize11KV.SwitchGearID);
            return View(tblXLPEaluminiumCopperGalvanize11KV);
        }

        // POST: TblXLPEaluminiumCopperGalvanize11KV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("XLPEaluminiumCopperGalvanize11KVId,SwitchGearID,NominalCrossSectionalAreaofPhaseConductor,DiameterofPhaseConductor,SingleCoreStranding,ThicknessofInsulation,DiameterOverInsulationApproximately,NominalCrossSectionalAreaofScreen,ThicknessofOverSheath,OverallDiameterApproximately,GalvanizedSteelRopeNominalCrossSectionalAreaofRope,Stranding,ThicknessofCovering,OverallDiameterofRope,ThreeCoresStrandedAroundSuspensionUnitDiameterof,StrandedBundleApproximately,TotalWeightApproximately,NominalVoltageratingUOorU,MaximumAdmissibleContinuousWorkingVoltage,MaximumDCResistanceAt20C,WorkingInductance,WorkingCapacitance,EarthLeakageCurrent,ShortCircuitCurrentOfConductor,OfScreen,CurrentRatingatAmbienttempof40C,ACTestVoltage,Source33or11kVSubStationID,Source132or33kVSubStationID,CurrentCarryingCapacity")] TblXLPEaluminiumCopperGalvanize11KV tblXLPEaluminiumCopperGalvanize11KV)
        {
            if (id != tblXLPEaluminiumCopperGalvanize11KV.XLPEaluminiumCopperGalvanize11KVId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblXLPEaluminiumCopperGalvanize11KV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblXLPEaluminiumCopperGalvanize11KVExists(tblXLPEaluminiumCopperGalvanize11KV.XLPEaluminiumCopperGalvanize11KVId))
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
            ViewData["Source132or33kVSubStationID"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblXLPEaluminiumCopperGalvanize11KV.Source132or33kVSubStationID);
            ViewData["Source33or11kVSubStationID"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblXLPEaluminiumCopperGalvanize11KV.Source33or11kVSubStationID);
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", tblXLPEaluminiumCopperGalvanize11KV.SwitchGearID);
            return View(tblXLPEaluminiumCopperGalvanize11KV);
        }

        // GET: TblXLPEaluminiumCopperGalvanize11KV/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblXLPEaluminiumCopperGalvanize11KV = await _context.TblXLPEaluminiumCopperGalvanize11KV
                .Include(t => t.CopperGalvanize11KVTo132or33kVSubStation)
                .Include(t => t.CopperGalvanize11KVTo33or11kVSubStationID)
                .Include(t => t.TblSwitchGear)
                .FirstOrDefaultAsync(m => m.XLPEaluminiumCopperGalvanize11KVId == id);
            if (tblXLPEaluminiumCopperGalvanize11KV == null)
            {
                return NotFound();
            }

            return View(tblXLPEaluminiumCopperGalvanize11KV);
        }

        // POST: TblXLPEaluminiumCopperGalvanize11KV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblXLPEaluminiumCopperGalvanize11KV = await _context.TblXLPEaluminiumCopperGalvanize11KV.FindAsync(id);
            _context.TblXLPEaluminiumCopperGalvanize11KV.Remove(tblXLPEaluminiumCopperGalvanize11KV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblXLPEaluminiumCopperGalvanize11KVExists(int id)
        {
            return _context.TblXLPEaluminiumCopperGalvanize11KV.Any(e => e.XLPEaluminiumCopperGalvanize11KVId == id);
        }
    }
}
