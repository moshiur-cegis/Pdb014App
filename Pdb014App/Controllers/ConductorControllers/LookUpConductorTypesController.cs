using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.ConductorModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.ConductorControllers
{
    public class LookUpConductorTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpConductorTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpConductorTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpConductorType.ToListAsync());
        }

        // GET: LookUpConductorTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConductorType = await _context.LookUpConductorType
                .FirstOrDefaultAsync(m => m.ConductorTypeId == id);
            if (lookUpConductorType == null)
            {
                return NotFound();
            }

            return View(lookUpConductorType);
        }

        // GET: LookUpConductorTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpConductorTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConductorTypeId,ConductorTypeName")] LookUpConductorType lookUpConductorType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpConductorType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpConductorType);
        }

        // GET: LookUpConductorTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConductorType = await _context.LookUpConductorType.FindAsync(id);
            if (lookUpConductorType == null)
            {
                return NotFound();
            }
            return View(lookUpConductorType);
        }

        // POST: LookUpConductorTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConductorTypeId,ConductorTypeName")] LookUpConductorType lookUpConductorType)
        {
            if (id != lookUpConductorType.ConductorTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpConductorType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpConductorTypeExists(lookUpConductorType.ConductorTypeId))
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
            return View(lookUpConductorType);
        }

        // GET: LookUpConductorTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConductorType = await _context.LookUpConductorType
                .FirstOrDefaultAsync(m => m.ConductorTypeId == id);
            if (lookUpConductorType == null)
            {
                return NotFound();
            }

            return View(lookUpConductorType);
        }

        // POST: LookUpConductorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpConductorType = await _context.LookUpConductorType.FindAsync(id);
            _context.LookUpConductorType.Remove(lookUpConductorType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpConductorTypeExists(string id)
        {
            return _context.LookUpConductorType.Any(e => e.ConductorTypeId == id);
        }
    }
}
