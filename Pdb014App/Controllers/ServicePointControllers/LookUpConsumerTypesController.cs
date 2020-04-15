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
    public class LookUpConsumerTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpConsumerTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpConsumerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpConsumerType.ToListAsync());
        }

        // GET: LookUpConsumerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConsumerType = await _context.LookUpConsumerType
                .FirstOrDefaultAsync(m => m.ConsumerTypeId == id);
            if (lookUpConsumerType == null)
            {
                return NotFound();
            }

            return View(lookUpConsumerType);
        }

        // GET: LookUpConsumerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpConsumerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumerTypeId,ConsumerTypeName")] LookUpConsumerType lookUpConsumerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpConsumerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpConsumerType);
        }

        // GET: LookUpConsumerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConsumerType = await _context.LookUpConsumerType.FindAsync(id);
            if (lookUpConsumerType == null)
            {
                return NotFound();
            }
            return View(lookUpConsumerType);
        }

        // POST: LookUpConsumerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumerTypeId,ConsumerTypeName")] LookUpConsumerType lookUpConsumerType)
        {
            if (id != lookUpConsumerType.ConsumerTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpConsumerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpConsumerTypeExists(lookUpConsumerType.ConsumerTypeId))
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
            return View(lookUpConsumerType);
        }

        // GET: LookUpConsumerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConsumerType = await _context.LookUpConsumerType
                .FirstOrDefaultAsync(m => m.ConsumerTypeId == id);
            if (lookUpConsumerType == null)
            {
                return NotFound();
            }

            return View(lookUpConsumerType);
        }

        // POST: LookUpConsumerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpConsumerType = await _context.LookUpConsumerType.FindAsync(id);
            _context.LookUpConsumerType.Remove(lookUpConsumerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpConsumerTypeExists(int id)
        {
            return _context.LookUpConsumerType.Any(e => e.ConsumerTypeId == id);
        }
    }
}
