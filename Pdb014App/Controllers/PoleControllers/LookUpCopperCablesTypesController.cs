using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.CopperCableModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.PoleControllers
{
    public class LookUpCopperCablesTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpCopperCablesTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpCopperCablesTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpCopperCablesType.ToListAsync());
        }

        // GET: LookUpCopperCablesTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCopperCablesType = await _context.LookUpCopperCablesType
                .FirstOrDefaultAsync(m => m.CopperCablesTypeId == id);
            if (lookUpCopperCablesType == null)
            {
                return NotFound();
            }

            return View(lookUpCopperCablesType);
        }

        // GET: LookUpCopperCablesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpCopperCablesTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CopperCablesTypeId,CopperCablesTypeName")] LookUpCopperCablesType lookUpCopperCablesType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpCopperCablesType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpCopperCablesType);
        }

        // GET: LookUpCopperCablesTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCopperCablesType = await _context.LookUpCopperCablesType.FindAsync(id);
            if (lookUpCopperCablesType == null)
            {
                return NotFound();
            }
            return View(lookUpCopperCablesType);
        }

        // POST: LookUpCopperCablesTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CopperCablesTypeId,CopperCablesTypeName")] LookUpCopperCablesType lookUpCopperCablesType)
        {
            if (id != lookUpCopperCablesType.CopperCablesTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpCopperCablesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpCopperCablesTypeExists(lookUpCopperCablesType.CopperCablesTypeId))
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
            return View(lookUpCopperCablesType);
        }

        // GET: LookUpCopperCablesTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCopperCablesType = await _context.LookUpCopperCablesType
                .FirstOrDefaultAsync(m => m.CopperCablesTypeId == id);
            if (lookUpCopperCablesType == null)
            {
                return NotFound();
            }

            return View(lookUpCopperCablesType);
        }

        // POST: LookUpCopperCablesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpCopperCablesType = await _context.LookUpCopperCablesType.FindAsync(id);
            _context.LookUpCopperCablesType.Remove(lookUpCopperCablesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpCopperCablesTypeExists(string id)
        {
            return _context.LookUpCopperCablesType.Any(e => e.CopperCablesTypeId == id);
        }
    }
}
