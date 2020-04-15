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
    public class LookUpFeederLineTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpFeederLineTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpFeederLineTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpFeederLineType.ToListAsync());
        }

        // GET: LookUpFeederLineTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpFeederLineType = await _context.LookUpFeederLineType
                .FirstOrDefaultAsync(m => m.FeederLineTypeId == id);
            if (lookUpFeederLineType == null)
            {
                return NotFound();
            }

            return View(lookUpFeederLineType);
        }

        // GET: LookUpFeederLineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpFeederLineTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeederLineTypeId,FeederLineTypeName")] LookUpFeederLineType lookUpFeederLineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpFeederLineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpFeederLineType);
        }

        // GET: LookUpFeederLineTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpFeederLineType = await _context.LookUpFeederLineType.FindAsync(id);
            if (lookUpFeederLineType == null)
            {
                return NotFound();
            }
            return View(lookUpFeederLineType);
        }

        // POST: LookUpFeederLineTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FeederLineTypeId,FeederLineTypeName")] LookUpFeederLineType lookUpFeederLineType)
        {
            if (id != lookUpFeederLineType.FeederLineTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpFeederLineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpFeederLineTypeExists(lookUpFeederLineType.FeederLineTypeId))
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
            return View(lookUpFeederLineType);
        }

        // GET: LookUpFeederLineTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpFeederLineType = await _context.LookUpFeederLineType
                .FirstOrDefaultAsync(m => m.FeederLineTypeId == id);
            if (lookUpFeederLineType == null)
            {
                return NotFound();
            }

            return View(lookUpFeederLineType);
        }

        // POST: LookUpFeederLineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpFeederLineType = await _context.LookUpFeederLineType.FindAsync(id);
            _context.LookUpFeederLineType.Remove(lookUpFeederLineType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpFeederLineTypeExists(string id)
        {
            return _context.LookUpFeederLineType.Any(e => e.FeederLineTypeId == id);
        }
    }
}
