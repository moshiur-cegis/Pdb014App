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
    public class LookUpSubstationTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpSubstationTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpSubstationTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpSubstationType.ToListAsync());
        }

        // GET: LookUpSubstationTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSubstationType = await _context.LookUpSubstationType
                .FirstOrDefaultAsync(m => m.SubstationTypeId == id);
            if (lookUpSubstationType == null)
            {
                return NotFound();
            }

            return View(lookUpSubstationType);
        }

        // GET: LookUpSubstationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpSubstationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubstationTypeId,SubstationTypeName")] LookUpSubstationType lookUpSubstationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpSubstationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpSubstationType);
        }

        // GET: LookUpSubstationTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSubstationType = await _context.LookUpSubstationType.FindAsync(id);
            if (lookUpSubstationType == null)
            {
                return NotFound();
            }
            return View(lookUpSubstationType);
        }

        // POST: LookUpSubstationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SubstationTypeId,SubstationTypeName")] LookUpSubstationType lookUpSubstationType)
        {
            if (id != lookUpSubstationType.SubstationTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpSubstationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpSubstationTypeExists(lookUpSubstationType.SubstationTypeId))
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
            return View(lookUpSubstationType);
        }

        // GET: LookUpSubstationTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSubstationType = await _context.LookUpSubstationType
                .FirstOrDefaultAsync(m => m.SubstationTypeId == id);
            if (lookUpSubstationType == null)
            {
                return NotFound();
            }

            return View(lookUpSubstationType);
        }

        // POST: LookUpSubstationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpSubstationType = await _context.LookUpSubstationType.FindAsync(id);
            _context.LookUpSubstationType.Remove(lookUpSubstationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpSubstationTypeExists(string id)
        {
            return _context.LookUpSubstationType.Any(e => e.SubstationTypeId == id);
        }
    }
}
