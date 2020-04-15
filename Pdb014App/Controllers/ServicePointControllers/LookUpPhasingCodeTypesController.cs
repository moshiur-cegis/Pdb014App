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
    public class LookUpPhasingCodeTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpPhasingCodeTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpPhasingCodeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpPhasingCodeType.ToListAsync());
        }

        // GET: LookUpPhasingCodeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpPhasingCodeType = await _context.LookUpPhasingCodeType
                .FirstOrDefaultAsync(m => m.PhasingCodeId == id);
            if (lookUpPhasingCodeType == null)
            {
                return NotFound();
            }

            return View(lookUpPhasingCodeType);
        }

        // GET: LookUpPhasingCodeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpPhasingCodeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhasingCodeId,PhasingCodeName")] LookUpPhasingCodeType lookUpPhasingCodeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpPhasingCodeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpPhasingCodeType);
        }

        // GET: LookUpPhasingCodeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpPhasingCodeType = await _context.LookUpPhasingCodeType.FindAsync(id);
            if (lookUpPhasingCodeType == null)
            {
                return NotFound();
            }
            return View(lookUpPhasingCodeType);
        }

        // POST: LookUpPhasingCodeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhasingCodeId,PhasingCodeName")] LookUpPhasingCodeType lookUpPhasingCodeType)
        {
            if (id != lookUpPhasingCodeType.PhasingCodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpPhasingCodeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpPhasingCodeTypeExists(lookUpPhasingCodeType.PhasingCodeId))
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
            return View(lookUpPhasingCodeType);
        }

        // GET: LookUpPhasingCodeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpPhasingCodeType = await _context.LookUpPhasingCodeType
                .FirstOrDefaultAsync(m => m.PhasingCodeId == id);
            if (lookUpPhasingCodeType == null)
            {
                return NotFound();
            }

            return View(lookUpPhasingCodeType);
        }

        // POST: LookUpPhasingCodeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpPhasingCodeType = await _context.LookUpPhasingCodeType.FindAsync(id);
            _context.LookUpPhasingCodeType.Remove(lookUpPhasingCodeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpPhasingCodeTypeExists(int id)
        {
            return _context.LookUpPhasingCodeType.Any(e => e.PhasingCodeId == id);
        }
    }
}
