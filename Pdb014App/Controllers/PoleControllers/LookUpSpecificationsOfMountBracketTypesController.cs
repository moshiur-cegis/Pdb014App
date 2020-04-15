using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.Mount_BracketModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.PoleControllers
{
    public class LookUpSpecificationsOfMountBracketTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpSpecificationsOfMountBracketTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpSpecificationsOfMountBracketTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpSpecificationsOfMountBracketType.ToListAsync());
        }

        // GET: LookUpSpecificationsOfMountBracketTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSpecificationsOfMountBracketType = await _context.LookUpSpecificationsOfMountBracketType
                .FirstOrDefaultAsync(m => m.SpecificationsOfMountBracketTypeId == id);
            if (lookUpSpecificationsOfMountBracketType == null)
            {
                return NotFound();
            }

            return View(lookUpSpecificationsOfMountBracketType);
        }

        // GET: LookUpSpecificationsOfMountBracketTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpSpecificationsOfMountBracketTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecificationsOfMountBracketTypeId,SpecificationsOfMountBracketTypeName")] LookUpSpecificationsOfMountBracketType lookUpSpecificationsOfMountBracketType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpSpecificationsOfMountBracketType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpSpecificationsOfMountBracketType);
        }

        // GET: LookUpSpecificationsOfMountBracketTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSpecificationsOfMountBracketType = await _context.LookUpSpecificationsOfMountBracketType.FindAsync(id);
            if (lookUpSpecificationsOfMountBracketType == null)
            {
                return NotFound();
            }
            return View(lookUpSpecificationsOfMountBracketType);
        }

        // POST: LookUpSpecificationsOfMountBracketTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecificationsOfMountBracketTypeId,SpecificationsOfMountBracketTypeName")] LookUpSpecificationsOfMountBracketType lookUpSpecificationsOfMountBracketType)
        {
            if (id != lookUpSpecificationsOfMountBracketType.SpecificationsOfMountBracketTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpSpecificationsOfMountBracketType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpSpecificationsOfMountBracketTypeExists(lookUpSpecificationsOfMountBracketType.SpecificationsOfMountBracketTypeId))
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
            return View(lookUpSpecificationsOfMountBracketType);
        }

        // GET: LookUpSpecificationsOfMountBracketTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSpecificationsOfMountBracketType = await _context.LookUpSpecificationsOfMountBracketType
                .FirstOrDefaultAsync(m => m.SpecificationsOfMountBracketTypeId == id);
            if (lookUpSpecificationsOfMountBracketType == null)
            {
                return NotFound();
            }

            return View(lookUpSpecificationsOfMountBracketType);
        }

        // POST: LookUpSpecificationsOfMountBracketTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpSpecificationsOfMountBracketType = await _context.LookUpSpecificationsOfMountBracketType.FindAsync(id);
            _context.LookUpSpecificationsOfMountBracketType.Remove(lookUpSpecificationsOfMountBracketType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpSpecificationsOfMountBracketTypeExists(int id)
        {
            return _context.LookUpSpecificationsOfMountBracketType.Any(e => e.SpecificationsOfMountBracketTypeId == id);
        }
    }
}
