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
    public class LookUpServiceCableTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpServiceCableTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpServiceCableTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpServiceCableType.ToListAsync());
        }

        // GET: LookUpServiceCableTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpServiceCableType = await _context.LookUpServiceCableType
                .FirstOrDefaultAsync(m => m.ServiceCableTypeId == id);
            if (lookUpServiceCableType == null)
            {
                return NotFound();
            }

            return View(lookUpServiceCableType);
        }

        // GET: LookUpServiceCableTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpServiceCableTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceCableTypeId,ServiceCableTypeName")] LookUpServiceCableType lookUpServiceCableType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpServiceCableType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpServiceCableType);
        }

        // GET: LookUpServiceCableTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpServiceCableType = await _context.LookUpServiceCableType.FindAsync(id);
            if (lookUpServiceCableType == null)
            {
                return NotFound();
            }
            return View(lookUpServiceCableType);
        }

        // POST: LookUpServiceCableTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceCableTypeId,ServiceCableTypeName")] LookUpServiceCableType lookUpServiceCableType)
        {
            if (id != lookUpServiceCableType.ServiceCableTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpServiceCableType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpServiceCableTypeExists(lookUpServiceCableType.ServiceCableTypeId))
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
            return View(lookUpServiceCableType);
        }

        // GET: LookUpServiceCableTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpServiceCableType = await _context.LookUpServiceCableType
                .FirstOrDefaultAsync(m => m.ServiceCableTypeId == id);
            if (lookUpServiceCableType == null)
            {
                return NotFound();
            }

            return View(lookUpServiceCableType);
        }

        // POST: LookUpServiceCableTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpServiceCableType = await _context.LookUpServiceCableType.FindAsync(id);
            _context.LookUpServiceCableType.Remove(lookUpServiceCableType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpServiceCableTypeExists(int id)
        {
            return _context.LookUpServiceCableType.Any(e => e.ServiceCableTypeId == id);
        }
    }
}
