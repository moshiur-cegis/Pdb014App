using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.ServicePointModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.ServicePointControllers
{
    public class LookUpStructureTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpStructureTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpStructureTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpStructureType.ToListAsync());
        }

        // GET: LookUpStructureTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpStructureType = await _context.LookUpStructureType
                .FirstOrDefaultAsync(m => m.StructureTypeId == id);
            if (lookUpStructureType == null)
            {
                return NotFound();
            }

            return View(lookUpStructureType);
        }

        // GET: LookUpStructureTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpStructureTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StructureTypeId,StructureTypeName")] LookUpStructureType lookUpStructureType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpStructureType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpStructureType);
        }

        // GET: LookUpStructureTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpStructureType = await _context.LookUpStructureType.FindAsync(id);
            if (lookUpStructureType == null)
            {
                return NotFound();
            }
            return View(lookUpStructureType);
        }

        // POST: LookUpStructureTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StructureTypeId,StructureTypeName")] LookUpStructureType lookUpStructureType)
        {
            if (id != lookUpStructureType.StructureTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpStructureType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpStructureTypeExists(lookUpStructureType.StructureTypeId))
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
            return View(lookUpStructureType);
        }

        // GET: LookUpStructureTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpStructureType = await _context.LookUpStructureType
                .FirstOrDefaultAsync(m => m.StructureTypeId == id);
            if (lookUpStructureType == null)
            {
                return NotFound();
            }

            return View(lookUpStructureType);
        }

        // POST: LookUpStructureTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpStructureType = await _context.LookUpStructureType.FindAsync(id);
            _context.LookUpStructureType.Remove(lookUpStructureType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpStructureTypeExists(int id)
        {
            return _context.LookUpStructureType.Any(e => e.StructureTypeId == id);
        }
    }
}
