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
    public class LookUpServicePointTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpServicePointTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpServicePointTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpServicePointType.ToListAsync());
        }

        // GET: LookUpServicePointTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpServicePointType = await _context.LookUpServicePointType
                .FirstOrDefaultAsync(m => m.ServicePointTypeId == id);
            if (lookUpServicePointType == null)
            {
                return NotFound();
            }

            return View(lookUpServicePointType);
        }

        // GET: LookUpServicePointTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpServicePointTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicePointTypeId,ServicePointTypeName")] LookUpServicePointType lookUpServicePointType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpServicePointType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpServicePointType);
        }

        // GET: LookUpServicePointTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpServicePointType = await _context.LookUpServicePointType.FindAsync(id);
            if (lookUpServicePointType == null)
            {
                return NotFound();
            }
            return View(lookUpServicePointType);
        }

        // POST: LookUpServicePointTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicePointTypeId,ServicePointTypeName")] LookUpServicePointType lookUpServicePointType)
        {
            if (id != lookUpServicePointType.ServicePointTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpServicePointType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpServicePointTypeExists(lookUpServicePointType.ServicePointTypeId))
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
            return View(lookUpServicePointType);
        }

        // GET: LookUpServicePointTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpServicePointType = await _context.LookUpServicePointType
                .FirstOrDefaultAsync(m => m.ServicePointTypeId == id);
            if (lookUpServicePointType == null)
            {
                return NotFound();
            }

            return View(lookUpServicePointType);
        }

        // POST: LookUpServicePointTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpServicePointType = await _context.LookUpServicePointType.FindAsync(id);
            _context.LookUpServicePointType.Remove(lookUpServicePointType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpServicePointTypeExists(int id)
        {
            return _context.LookUpServicePointType.Any(e => e.ServicePointTypeId == id);
        }
    }
}
