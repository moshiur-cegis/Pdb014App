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
    public class LookUpMeterTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpMeterTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpMeterTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpMeterType.ToListAsync());
        }

        // GET: LookUpMeterTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpMeterType = await _context.LookUpMeterType
                .FirstOrDefaultAsync(m => m.MeterTypeId == id);
            if (lookUpMeterType == null)
            {
                return NotFound();
            }

            return View(lookUpMeterType);
        }

        // GET: LookUpMeterTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpMeterTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeterTypeId,MeterTypeName")] LookUpMeterType lookUpMeterType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpMeterType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpMeterType);
        }

        // GET: LookUpMeterTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpMeterType = await _context.LookUpMeterType.FindAsync(id);
            if (lookUpMeterType == null)
            {
                return NotFound();
            }
            return View(lookUpMeterType);
        }

        // POST: LookUpMeterTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeterTypeId,MeterTypeName")] LookUpMeterType lookUpMeterType)
        {
            if (id != lookUpMeterType.MeterTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpMeterType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpMeterTypeExists(lookUpMeterType.MeterTypeId))
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
            return View(lookUpMeterType);
        }

        // GET: LookUpMeterTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpMeterType = await _context.LookUpMeterType
                .FirstOrDefaultAsync(m => m.MeterTypeId == id);
            if (lookUpMeterType == null)
            {
                return NotFound();
            }

            return View(lookUpMeterType);
        }

        // POST: LookUpMeterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpMeterType = await _context.LookUpMeterType.FindAsync(id);
            _context.LookUpMeterType.Remove(lookUpMeterType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpMeterTypeExists(int id)
        {
            return _context.LookUpMeterType.Any(e => e.MeterTypeId == id);
        }
    }
}
