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
    public class LookUpAuxiliaryTransformersController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpAuxiliaryTransformersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpAuxiliaryTransformers
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpAuxiliaryTransformer.Include(l => l.AuxiliaryTransformerToSubstation);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpAuxiliaryTransformers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAuxiliaryTransformer = await _context.LookUpAuxiliaryTransformer
                .Include(l => l.AuxiliaryTransformerToSubstation)
                .FirstOrDefaultAsync(m => m.AuxiliaryTransformerId == id);
            if (lookUpAuxiliaryTransformer == null)
            {
                return NotFound();
            }

            return View(lookUpAuxiliaryTransformer);
        }

        // GET: LookUpAuxiliaryTransformers/Create
        public IActionResult Create()
        {
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName");
            return View();
        }

        // POST: LookUpAuxiliaryTransformers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuxiliaryTransformerId,SubstationId,ManufacturersNameAndAddress,ManufacturersTypeAndModelNo,KVARating,NumberOfPhases,RatedFrequencyHz,RatedPrimaryvoltageKV,RatedNoloadsecVoltageV,VectorGroup,HighestSystemVoltageof,PrimaryWindingKV,SecondaryWindingKv,BasicInsulationLevelKV,PowerFrequencyWithstandVoltageKV,HTSide,LTSide,TypeOfCooling,MaxTempRiseover40CofambientSupportedByCalculation,WindingdegC,TopOildegC,TypeofPrimaryTappingOffload,PercentageImpedanceAt75C,NoloadLossWatts,LoadLossesAtRatedFullLoadAt75CWatts,TotalWeightOfOilKg")] LookUpAuxiliaryTransformer lookUpAuxiliaryTransformer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpAuxiliaryTransformer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName", lookUpAuxiliaryTransformer.SubstationId);
            return View(lookUpAuxiliaryTransformer);
        }

        // GET: LookUpAuxiliaryTransformers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAuxiliaryTransformer = await _context.LookUpAuxiliaryTransformer.FindAsync(id);
            if (lookUpAuxiliaryTransformer == null)
            {
                return NotFound();
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName", lookUpAuxiliaryTransformer.SubstationId);
            return View(lookUpAuxiliaryTransformer);
        }

        // POST: LookUpAuxiliaryTransformers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuxiliaryTransformerId,SubstationId,ManufacturersNameAndAddress,ManufacturersTypeAndModelNo,KVARating,NumberOfPhases,RatedFrequencyHz,RatedPrimaryvoltageKV,RatedNoloadsecVoltageV,VectorGroup,HighestSystemVoltageof,PrimaryWindingKV,SecondaryWindingKv,BasicInsulationLevelKV,PowerFrequencyWithstandVoltageKV,HTSide,LTSide,TypeOfCooling,MaxTempRiseover40CofambientSupportedByCalculation,WindingdegC,TopOildegC,TypeofPrimaryTappingOffload,PercentageImpedanceAt75C,NoloadLossWatts,LoadLossesAtRatedFullLoadAt75CWatts,TotalWeightOfOilKg")] LookUpAuxiliaryTransformer lookUpAuxiliaryTransformer)
        {
            if (id != lookUpAuxiliaryTransformer.AuxiliaryTransformerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpAuxiliaryTransformer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpAuxiliaryTransformerExists(lookUpAuxiliaryTransformer.AuxiliaryTransformerId))
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
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName", lookUpAuxiliaryTransformer.SubstationId);
            return View(lookUpAuxiliaryTransformer);
        }

        // GET: LookUpAuxiliaryTransformers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAuxiliaryTransformer = await _context.LookUpAuxiliaryTransformer
                .Include(l => l.AuxiliaryTransformerToSubstation)
                .FirstOrDefaultAsync(m => m.AuxiliaryTransformerId == id);
            if (lookUpAuxiliaryTransformer == null)
            {
                return NotFound();
            }

            return View(lookUpAuxiliaryTransformer);
        }

        // POST: LookUpAuxiliaryTransformers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpAuxiliaryTransformer = await _context.LookUpAuxiliaryTransformer.FindAsync(id);
            _context.LookUpAuxiliaryTransformer.Remove(lookUpAuxiliaryTransformer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpAuxiliaryTransformerExists(int id)
        {
            return _context.LookUpAuxiliaryTransformer.Any(e => e.AuxiliaryTransformerId == id);
        }
    }
}
