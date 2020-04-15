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
    public class LookUpInsulatorShackleOrGuyTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpInsulatorShackleOrGuyTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpInsulatorShackleOrGuyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpInsulatorShackleOrGuyType.ToListAsync());
        }

        // GET: LookUpInsulatorShackleOrGuyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorShackleOrGuyType = await _context.LookUpInsulatorShackleOrGuyType
                .FirstOrDefaultAsync(m => m.InsulatorShackleOrGuyTypeId == id);
            if (lookUpInsulatorShackleOrGuyType == null)
            {
                return NotFound();
            }

            return View(lookUpInsulatorShackleOrGuyType);
        }

        // GET: LookUpInsulatorShackleOrGuyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpInsulatorShackleOrGuyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsulatorShackleOrGuyTypeId,InsulatorShackleOrGuyTypeName")] LookUpInsulatorShackleOrGuyType lookUpInsulatorShackleOrGuyType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpInsulatorShackleOrGuyType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpInsulatorShackleOrGuyType);
        }

        // GET: LookUpInsulatorShackleOrGuyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorShackleOrGuyType = await _context.LookUpInsulatorShackleOrGuyType.FindAsync(id);
            if (lookUpInsulatorShackleOrGuyType == null)
            {
                return NotFound();
            }
            return View(lookUpInsulatorShackleOrGuyType);
        }

        // POST: LookUpInsulatorShackleOrGuyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsulatorShackleOrGuyTypeId,InsulatorShackleOrGuyTypeName")] LookUpInsulatorShackleOrGuyType lookUpInsulatorShackleOrGuyType)
        {
            if (id != lookUpInsulatorShackleOrGuyType.InsulatorShackleOrGuyTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpInsulatorShackleOrGuyType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpInsulatorShackleOrGuyTypeExists(lookUpInsulatorShackleOrGuyType.InsulatorShackleOrGuyTypeId))
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
            return View(lookUpInsulatorShackleOrGuyType);
        }

        // GET: LookUpInsulatorShackleOrGuyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorShackleOrGuyType = await _context.LookUpInsulatorShackleOrGuyType
                .FirstOrDefaultAsync(m => m.InsulatorShackleOrGuyTypeId == id);
            if (lookUpInsulatorShackleOrGuyType == null)
            {
                return NotFound();
            }

            return View(lookUpInsulatorShackleOrGuyType);
        }

        // POST: LookUpInsulatorShackleOrGuyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpInsulatorShackleOrGuyType = await _context.LookUpInsulatorShackleOrGuyType.FindAsync(id);
            _context.LookUpInsulatorShackleOrGuyType.Remove(lookUpInsulatorShackleOrGuyType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpInsulatorShackleOrGuyTypeExists(int id)
        {
            return _context.LookUpInsulatorShackleOrGuyType.Any(e => e.InsulatorShackleOrGuyTypeId == id);
        }
    }
}
