using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB;
using Pdb014App.Repository;


namespace Pdb014App.Controllers.ComplainControllers
{
    public class LookUpComplainTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpComplainTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpComplainTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComplainTypes.ToListAsync());
        }

        // GET: LookUpComplainTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplainType = await _context.ComplainTypes
                .FirstOrDefaultAsync(m => m.ComplainTypeId == id);
            if (lookUpComplainType == null)
            {
                return NotFound();
            }

            return View(lookUpComplainType);
        }

        // GET: LookUpComplainTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpComplainTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplainTypeId,ComplainType")] LookUpComplainType lookUpComplainType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpComplainType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpComplainType);
        }

        // GET: LookUpComplainTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplainType = await _context.ComplainTypes.FindAsync(id);
            if (lookUpComplainType == null)
            {
                return NotFound();
            }
            return View(lookUpComplainType);
        }

        // POST: LookUpComplainTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComplainTypeId,ComplainType")] LookUpComplainType lookUpComplainType)
        {
            if (id != lookUpComplainType.ComplainTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpComplainType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpComplainTypeExists(lookUpComplainType.ComplainTypeId))
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
            return View(lookUpComplainType);
        }

        // GET: LookUpComplainTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplainType = await _context.ComplainTypes
                .FirstOrDefaultAsync(m => m.ComplainTypeId == id);
            if (lookUpComplainType == null)
            {
                return NotFound();
            }

            return View(lookUpComplainType);
        }

        // POST: LookUpComplainTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpComplainType = await _context.ComplainTypes.FindAsync(id);
            _context.ComplainTypes.Remove(lookUpComplainType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpComplainTypeExists(int id)
        {
            return _context.ComplainTypes.Any(e => e.ComplainTypeId == id);
        }
    }
}
