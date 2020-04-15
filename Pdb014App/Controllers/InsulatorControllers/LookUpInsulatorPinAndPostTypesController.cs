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
    public class LookUpInsulatorPinAndPostTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpInsulatorPinAndPostTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpInsulatorPinAndPostTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpInsulatorPinAndPostType.ToListAsync());
        }

        // GET: LookUpInsulatorPinAndPostTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorPinAndPostType = await _context.LookUpInsulatorPinAndPostType
                .FirstOrDefaultAsync(m => m.InsulatorPinAndPostTypeId == id);
            if (lookUpInsulatorPinAndPostType == null)
            {
                return NotFound();
            }

            return View(lookUpInsulatorPinAndPostType);
        }

        // GET: LookUpInsulatorPinAndPostTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpInsulatorPinAndPostTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsulatorPinAndPostTypeId,InsulatorPinAndPostTypeName")] LookUpInsulatorPinAndPostType lookUpInsulatorPinAndPostType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpInsulatorPinAndPostType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpInsulatorPinAndPostType);
        }

        // GET: LookUpInsulatorPinAndPostTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorPinAndPostType = await _context.LookUpInsulatorPinAndPostType.FindAsync(id);
            if (lookUpInsulatorPinAndPostType == null)
            {
                return NotFound();
            }
            return View(lookUpInsulatorPinAndPostType);
        }

        // POST: LookUpInsulatorPinAndPostTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsulatorPinAndPostTypeId,InsulatorPinAndPostTypeName")] LookUpInsulatorPinAndPostType lookUpInsulatorPinAndPostType)
        {
            if (id != lookUpInsulatorPinAndPostType.InsulatorPinAndPostTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpInsulatorPinAndPostType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpInsulatorPinAndPostTypeExists(lookUpInsulatorPinAndPostType.InsulatorPinAndPostTypeId))
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
            return View(lookUpInsulatorPinAndPostType);
        }

        // GET: LookUpInsulatorPinAndPostTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpInsulatorPinAndPostType = await _context.LookUpInsulatorPinAndPostType
                .FirstOrDefaultAsync(m => m.InsulatorPinAndPostTypeId == id);
            if (lookUpInsulatorPinAndPostType == null)
            {
                return NotFound();
            }

            return View(lookUpInsulatorPinAndPostType);
        }

        // POST: LookUpInsulatorPinAndPostTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpInsulatorPinAndPostType = await _context.LookUpInsulatorPinAndPostType.FindAsync(id);
            _context.LookUpInsulatorPinAndPostType.Remove(lookUpInsulatorPinAndPostType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpInsulatorPinAndPostTypeExists(int id)
        {
            return _context.LookUpInsulatorPinAndPostType.Any(e => e.InsulatorPinAndPostTypeId == id);
        }
    }
}
