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
    public class LookUpAutoCircuitReCloserTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpAutoCircuitReCloserTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpAutoCircuitReCloserTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpAutoCircuitReCloserType.ToListAsync());
        }

        // GET: LookUpAutoCircuitReCloserTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAutoCircuitReCloserType = await _context.LookUpAutoCircuitReCloserType
                .FirstOrDefaultAsync(m => m.AutoCircuitReCloserTypeId == id);
            if (lookUpAutoCircuitReCloserType == null)
            {
                return NotFound();
            }

            return View(lookUpAutoCircuitReCloserType);
        }

        // GET: LookUpAutoCircuitReCloserTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpAutoCircuitReCloserTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoCircuitReCloserTypeId,AutoCircuitReCloserTypeIdName")] LookUpAutoCircuitReCloserType lookUpAutoCircuitReCloserType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpAutoCircuitReCloserType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpAutoCircuitReCloserType);
        }

        // GET: LookUpAutoCircuitReCloserTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAutoCircuitReCloserType = await _context.LookUpAutoCircuitReCloserType.FindAsync(id);
            if (lookUpAutoCircuitReCloserType == null)
            {
                return NotFound();
            }
            return View(lookUpAutoCircuitReCloserType);
        }

        // POST: LookUpAutoCircuitReCloserTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoCircuitReCloserTypeId,AutoCircuitReCloserTypeIdName")] LookUpAutoCircuitReCloserType lookUpAutoCircuitReCloserType)
        {
            if (id != lookUpAutoCircuitReCloserType.AutoCircuitReCloserTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpAutoCircuitReCloserType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpAutoCircuitReCloserTypeExists(lookUpAutoCircuitReCloserType.AutoCircuitReCloserTypeId))
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
            return View(lookUpAutoCircuitReCloserType);
        }

        // GET: LookUpAutoCircuitReCloserTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpAutoCircuitReCloserType = await _context.LookUpAutoCircuitReCloserType
                .FirstOrDefaultAsync(m => m.AutoCircuitReCloserTypeId == id);
            if (lookUpAutoCircuitReCloserType == null)
            {
                return NotFound();
            }

            return View(lookUpAutoCircuitReCloserType);
        }

        // POST: LookUpAutoCircuitReCloserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpAutoCircuitReCloserType = await _context.LookUpAutoCircuitReCloserType.FindAsync(id);
            _context.LookUpAutoCircuitReCloserType.Remove(lookUpAutoCircuitReCloserType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpAutoCircuitReCloserTypeExists(int id)
        {
            return _context.LookUpAutoCircuitReCloserType.Any(e => e.AutoCircuitReCloserTypeId == id);
        }
    }
}
