using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.MeteringPanelModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.MeteringPanelController
{
    public class LookUpDimensionAndWeightsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpDimensionAndWeightsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpDimensionAndWeights
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpDimensionAndWeight.ToListAsync());
        }

        // GET: LookUpDimensionAndWeights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDimensionAndWeight = await _context.LookUpDimensionAndWeight
                .FirstOrDefaultAsync(m => m.DimensionAndWeightId == id);
            if (lookUpDimensionAndWeight == null)
            {
                return NotFound();
            }

            return View(lookUpDimensionAndWeight);
        }

        // GET: LookUpDimensionAndWeights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpDimensionAndWeights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DimensionAndWeightId,Height,Width,Depth,WeightIncludingCircuitBreaker")] LookUpDimensionAndWeight lookUpDimensionAndWeight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpDimensionAndWeight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpDimensionAndWeight);
        }

        // GET: LookUpDimensionAndWeights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDimensionAndWeight = await _context.LookUpDimensionAndWeight.FindAsync(id);
            if (lookUpDimensionAndWeight == null)
            {
                return NotFound();
            }
            return View(lookUpDimensionAndWeight);
        }

        // POST: LookUpDimensionAndWeights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DimensionAndWeightId,Height,Width,Depth,WeightIncludingCircuitBreaker")] LookUpDimensionAndWeight lookUpDimensionAndWeight)
        {
            if (id != lookUpDimensionAndWeight.DimensionAndWeightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpDimensionAndWeight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpDimensionAndWeightExists(lookUpDimensionAndWeight.DimensionAndWeightId))
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
            return View(lookUpDimensionAndWeight);
        }

        // GET: LookUpDimensionAndWeights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpDimensionAndWeight = await _context.LookUpDimensionAndWeight
                .FirstOrDefaultAsync(m => m.DimensionAndWeightId == id);
            if (lookUpDimensionAndWeight == null)
            {
                return NotFound();
            }

            return View(lookUpDimensionAndWeight);
        }

        // POST: LookUpDimensionAndWeights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpDimensionAndWeight = await _context.LookUpDimensionAndWeight.FindAsync(id);
            _context.LookUpDimensionAndWeight.Remove(lookUpDimensionAndWeight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpDimensionAndWeightExists(int id)
        {
            return _context.LookUpDimensionAndWeight.Any(e => e.DimensionAndWeightId == id);
        }
    }
}
