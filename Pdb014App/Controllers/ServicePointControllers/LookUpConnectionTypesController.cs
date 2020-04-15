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
    public class LookUpConnectionTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpConnectionTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpConnectionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpConnectionType.ToListAsync());
        }

        // GET: LookUpConnectionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConnectionType = await _context.LookUpConnectionType
                .FirstOrDefaultAsync(m => m.ConnectionTypeId == id);
            if (lookUpConnectionType == null)
            {
                return NotFound();
            }

            return View(lookUpConnectionType);
        }

        // GET: LookUpConnectionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpConnectionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConnectionTypeId,ConnectionTypeName")] LookUpConnectionType lookUpConnectionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpConnectionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpConnectionType);
        }

        // GET: LookUpConnectionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConnectionType = await _context.LookUpConnectionType.FindAsync(id);
            if (lookUpConnectionType == null)
            {
                return NotFound();
            }
            return View(lookUpConnectionType);
        }

        // POST: LookUpConnectionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConnectionTypeId,ConnectionTypeName")] LookUpConnectionType lookUpConnectionType)
        {
            if (id != lookUpConnectionType.ConnectionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpConnectionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpConnectionTypeExists(lookUpConnectionType.ConnectionTypeId))
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
            return View(lookUpConnectionType);
        }

        // GET: LookUpConnectionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConnectionType = await _context.LookUpConnectionType
                .FirstOrDefaultAsync(m => m.ConnectionTypeId == id);
            if (lookUpConnectionType == null)
            {
                return NotFound();
            }

            return View(lookUpConnectionType);
        }

        // POST: LookUpConnectionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpConnectionType = await _context.LookUpConnectionType.FindAsync(id);
            _context.LookUpConnectionType.Remove(lookUpConnectionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpConnectionTypeExists(int id)
        {
            return _context.LookUpConnectionType.Any(e => e.ConnectionTypeId == id);
        }
    }
}
