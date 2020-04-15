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
    public class LookUpBusinessTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpBusinessTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpBusinessTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpBusinessType.ToListAsync());
        }

        // GET: LookUpBusinessTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpBusinessType = await _context.LookUpBusinessType
                .FirstOrDefaultAsync(m => m.BusinessTypeId == id);
            if (lookUpBusinessType == null)
            {
                return NotFound();
            }

            return View(lookUpBusinessType);
        }

        // GET: LookUpBusinessTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpBusinessTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessTypeId,BusinessTypeName")] LookUpBusinessType lookUpBusinessType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpBusinessType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpBusinessType);
        }

        // GET: LookUpBusinessTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpBusinessType = await _context.LookUpBusinessType.FindAsync(id);
            if (lookUpBusinessType == null)
            {
                return NotFound();
            }
            return View(lookUpBusinessType);
        }

        // POST: LookUpBusinessTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessTypeId,BusinessTypeName")] LookUpBusinessType lookUpBusinessType)
        {
            if (id != lookUpBusinessType.BusinessTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpBusinessType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpBusinessTypeExists(lookUpBusinessType.BusinessTypeId))
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
            return View(lookUpBusinessType);
        }

        // GET: LookUpBusinessTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpBusinessType = await _context.LookUpBusinessType
                .FirstOrDefaultAsync(m => m.BusinessTypeId == id);
            if (lookUpBusinessType == null)
            {
                return NotFound();
            }

            return View(lookUpBusinessType);
        }

        // POST: LookUpBusinessTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpBusinessType = await _context.LookUpBusinessType.FindAsync(id);
            _context.LookUpBusinessType.Remove(lookUpBusinessType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpBusinessTypeExists(int id)
        {
            return _context.LookUpBusinessType.Any(e => e.BusinessTypeId == id);
        }
    }
}
