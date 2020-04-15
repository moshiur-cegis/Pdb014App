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
    public class LookUpVoltageCategoriesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpVoltageCategoriesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpVoltageCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpVoltageCategory.ToListAsync());
        }

        // GET: LookUpVoltageCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpVoltageCategory = await _context.LookUpVoltageCategory
                .FirstOrDefaultAsync(m => m.VoltageCategoryId == id);
            if (lookUpVoltageCategory == null)
            {
                return NotFound();
            }

            return View(lookUpVoltageCategory);
        }

        // GET: LookUpVoltageCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpVoltageCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoltageCategoryId,VoltageCategoryName")] LookUpVoltageCategory lookUpVoltageCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpVoltageCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpVoltageCategory);
        }

        // GET: LookUpVoltageCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpVoltageCategory = await _context.LookUpVoltageCategory.FindAsync(id);
            if (lookUpVoltageCategory == null)
            {
                return NotFound();
            }
            return View(lookUpVoltageCategory);
        }

        // POST: LookUpVoltageCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoltageCategoryId,VoltageCategoryName")] LookUpVoltageCategory lookUpVoltageCategory)
        {
            if (id != lookUpVoltageCategory.VoltageCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpVoltageCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpVoltageCategoryExists(lookUpVoltageCategory.VoltageCategoryId))
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
            return View(lookUpVoltageCategory);
        }

        // GET: LookUpVoltageCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpVoltageCategory = await _context.LookUpVoltageCategory
                .FirstOrDefaultAsync(m => m.VoltageCategoryId == id);
            if (lookUpVoltageCategory == null)
            {
                return NotFound();
            }

            return View(lookUpVoltageCategory);
        }

        // POST: LookUpVoltageCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpVoltageCategory = await _context.LookUpVoltageCategory.FindAsync(id);
            _context.LookUpVoltageCategory.Remove(lookUpVoltageCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpVoltageCategoryExists(int id)
        {
            return _context.LookUpVoltageCategory.Any(e => e.VoltageCategoryId == id);
        }
    }
}
