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
    public class LookUpCurrentTransformersController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpCurrentTransformersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpCurrentTransformers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpCurrentTransformer.ToListAsync());
        }

        // GET: LookUpCurrentTransformers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCurrentTransformer = await _context.LookUpCurrentTransformer
                .FirstOrDefaultAsync(m => m.CurrentTransformerId == id);
            if (lookUpCurrentTransformer == null)
            {
                return NotFound();
            }

            return View(lookUpCurrentTransformer);
        }

        // GET: LookUpCurrentTransformers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpCurrentTransformers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurrentTransformerId,RatedVoltage,AccuracyClassMetering,AccuracyClassOCEFProtection,AccuracyClassDifferentialProtection,RatedCurrentRatio,Burden,RatedFrequency")] LookUpCurrentTransformer lookUpCurrentTransformer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpCurrentTransformer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpCurrentTransformer);
        }

        // GET: LookUpCurrentTransformers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCurrentTransformer = await _context.LookUpCurrentTransformer.FindAsync(id);
            if (lookUpCurrentTransformer == null)
            {
                return NotFound();
            }
            return View(lookUpCurrentTransformer);
        }

        // POST: LookUpCurrentTransformers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurrentTransformerId,RatedVoltage,AccuracyClassMetering,AccuracyClassOCEFProtection,AccuracyClassDifferentialProtection,RatedCurrentRatio,Burden,RatedFrequency")] LookUpCurrentTransformer lookUpCurrentTransformer)
        {
            if (id != lookUpCurrentTransformer.CurrentTransformerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpCurrentTransformer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpCurrentTransformerExists(lookUpCurrentTransformer.CurrentTransformerId))
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
            return View(lookUpCurrentTransformer);
        }

        // GET: LookUpCurrentTransformers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCurrentTransformer = await _context.LookUpCurrentTransformer
                .FirstOrDefaultAsync(m => m.CurrentTransformerId == id);
            if (lookUpCurrentTransformer == null)
            {
                return NotFound();
            }

            return View(lookUpCurrentTransformer);
        }

        // POST: LookUpCurrentTransformers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpCurrentTransformer = await _context.LookUpCurrentTransformer.FindAsync(id);
            _context.LookUpCurrentTransformer.Remove(lookUpCurrentTransformer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpCurrentTransformerExists(int id)
        {
            return _context.LookUpCurrentTransformer.Any(e => e.CurrentTransformerId == id);
        }
    }
}
