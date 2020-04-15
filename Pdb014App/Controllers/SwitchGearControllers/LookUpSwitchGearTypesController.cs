using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.SwitchGearModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.SwitchGearControllers
{
    public class LookUpSwitchGearTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpSwitchGearTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpSwitchGearTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpSwitchGearType.ToListAsync());
        }

        // GET: LookUpSwitchGearTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSwitchGearType = await _context.LookUpSwitchGearType
                .FirstOrDefaultAsync(m => m.SwitchGearTypeId == id);
            if (lookUpSwitchGearType == null)
            {
                return NotFound();
            }

            return View(lookUpSwitchGearType);
        }

        // GET: LookUpSwitchGearTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpSwitchGearTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SwitchGearTypeId,SwitchGearTypeName")] LookUpSwitchGearType lookUpSwitchGearType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpSwitchGearType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpSwitchGearType);
        }

        // GET: LookUpSwitchGearTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSwitchGearType = await _context.LookUpSwitchGearType.FindAsync(id);
            if (lookUpSwitchGearType == null)
            {
                return NotFound();
            }
            return View(lookUpSwitchGearType);
        }

        // POST: LookUpSwitchGearTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SwitchGearTypeId,SwitchGearTypeName")] LookUpSwitchGearType lookUpSwitchGearType)
        {
            if (id != lookUpSwitchGearType.SwitchGearTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpSwitchGearType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpSwitchGearTypeExists(lookUpSwitchGearType.SwitchGearTypeId))
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
            return View(lookUpSwitchGearType);
        }

        // GET: LookUpSwitchGearTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSwitchGearType = await _context.LookUpSwitchGearType
                .FirstOrDefaultAsync(m => m.SwitchGearTypeId == id);
            if (lookUpSwitchGearType == null)
            {
                return NotFound();
            }

            return View(lookUpSwitchGearType);
        }

        // POST: LookUpSwitchGearTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpSwitchGearType = await _context.LookUpSwitchGearType.FindAsync(id);
            _context.LookUpSwitchGearType.Remove(lookUpSwitchGearType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpSwitchGearTypeExists(int id)
        {
            return _context.LookUpSwitchGearType.Any(e => e.SwitchGearTypeId == id);
        }
    }
}
