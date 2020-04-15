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
    public class LookUpOperatingVoltagesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpOperatingVoltagesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpOperatingVoltages
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpOperatingVoltage.ToListAsync());
        }

        // GET: LookUpOperatingVoltages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpOperatingVoltage = await _context.LookUpOperatingVoltage
                .FirstOrDefaultAsync(m => m.OperatingVoltageId == id);
            if (lookUpOperatingVoltage == null)
            {
                return NotFound();
            }

            return View(lookUpOperatingVoltage);
        }

        // GET: LookUpOperatingVoltages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpOperatingVoltages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperatingVoltageId,OperatingVoltageName")] LookUpOperatingVoltage lookUpOperatingVoltage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpOperatingVoltage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpOperatingVoltage);
        }

        // GET: LookUpOperatingVoltages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpOperatingVoltage = await _context.LookUpOperatingVoltage.FindAsync(id);
            if (lookUpOperatingVoltage == null)
            {
                return NotFound();
            }
            return View(lookUpOperatingVoltage);
        }

        // POST: LookUpOperatingVoltages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperatingVoltageId,OperatingVoltageName")] LookUpOperatingVoltage lookUpOperatingVoltage)
        {
            if (id != lookUpOperatingVoltage.OperatingVoltageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpOperatingVoltage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpOperatingVoltageExists(lookUpOperatingVoltage.OperatingVoltageId))
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
            return View(lookUpOperatingVoltage);
        }

        // GET: LookUpOperatingVoltages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpOperatingVoltage = await _context.LookUpOperatingVoltage
                .FirstOrDefaultAsync(m => m.OperatingVoltageId == id);
            if (lookUpOperatingVoltage == null)
            {
                return NotFound();
            }

            return View(lookUpOperatingVoltage);
        }

        // POST: LookUpOperatingVoltages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpOperatingVoltage = await _context.LookUpOperatingVoltage.FindAsync(id);
            _context.LookUpOperatingVoltage.Remove(lookUpOperatingVoltage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpOperatingVoltageExists(int id)
        {
            return _context.LookUpOperatingVoltage.Any(e => e.OperatingVoltageId == id);
        }
    }
}
