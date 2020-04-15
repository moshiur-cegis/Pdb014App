using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.InsulatorModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.InsulatorControllers
{
    public class LookUpInsulatorDiskTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpInsulatorDiskTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpInsulatorDiskTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpInsulatorDiskType.ToListAsync());
        }

        // GET: LookUpInsulatorDiskTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorDiskType = await _context.LookUpInsulatorDiskType
                .FirstOrDefaultAsync(m => m.InsulatorDiskTypeId == id);
            if (lookUpInsulatorDiskType == null)
            {
                return NotFound();
            }

            return View(lookUpInsulatorDiskType);
        }

        // GET: LookUpInsulatorDiskTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpInsulatorDiskTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsulatorDiskTypeId,InsulatorDiskTypeName")] LookUpInsulatorDiskType lookUpInsulatorDiskType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpInsulatorDiskType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpInsulatorDiskType);
        }

        // GET: LookUpInsulatorDiskTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorDiskType = await _context.LookUpInsulatorDiskType.FindAsync(id);
            if (lookUpInsulatorDiskType == null)
            {
                return NotFound();
            }
            return View(lookUpInsulatorDiskType);
        }

        // POST: LookUpInsulatorDiskTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsulatorDiskTypeId,InsulatorDiskTypeName")] LookUpInsulatorDiskType lookUpInsulatorDiskType)
        {
            if (id != lookUpInsulatorDiskType.InsulatorDiskTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpInsulatorDiskType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpInsulatorDiskTypeExists(lookUpInsulatorDiskType.InsulatorDiskTypeId))
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
            return View(lookUpInsulatorDiskType);
        }

        // GET: LookUpInsulatorDiskTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorDiskType = await _context.LookUpInsulatorDiskType
                .FirstOrDefaultAsync(m => m.InsulatorDiskTypeId == id);
            if (lookUpInsulatorDiskType == null)
            {
                return NotFound();
            }

            return View(lookUpInsulatorDiskType);
        }

        // POST: LookUpInsulatorDiskTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpInsulatorDiskType = await _context.LookUpInsulatorDiskType.FindAsync(id);
            _context.LookUpInsulatorDiskType.Remove(lookUpInsulatorDiskType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpInsulatorDiskTypeExists(int id)
        {
            return _context.LookUpInsulatorDiskType.Any(e => e.InsulatorDiskTypeId == id);
        }
    }
}
