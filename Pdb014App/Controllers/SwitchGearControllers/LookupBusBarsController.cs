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
    public class LookupBusBarsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookupBusBarsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookupBusBars
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookupBusBar.ToListAsync());
        }

        // GET: LookupBusBars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupBusBar = await _context.LookupBusBar
                .FirstOrDefaultAsync(m => m.BusBarId == id);
            if (lookupBusBar == null)
            {
                return NotFound();
            }

            return View(lookupBusBar);
        }

        // GET: LookupBusBars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookupBusBars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusBarId,BusBarType,Material,CrossSection,NominalCurrent,Accessories,CableConnection,VoltageTransformer,SurgeArrester")] LookupBusBar lookupBusBar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookupBusBar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookupBusBar);
        }

        // GET: LookupBusBars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupBusBar = await _context.LookupBusBar.FindAsync(id);
            if (lookupBusBar == null)
            {
                return NotFound();
            }
            return View(lookupBusBar);
        }

        // POST: LookupBusBars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusBarId,BusBarType,Material,CrossSection,NominalCurrent,Accessories,CableConnection,VoltageTransformer,SurgeArrester")] LookupBusBar lookupBusBar)
        {
            if (id != lookupBusBar.BusBarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookupBusBar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookupBusBarExists(lookupBusBar.BusBarId))
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
            return View(lookupBusBar);
        }

        // GET: LookupBusBars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupBusBar = await _context.LookupBusBar
                .FirstOrDefaultAsync(m => m.BusBarId == id);
            if (lookupBusBar == null)
            {
                return NotFound();
            }

            return View(lookupBusBar);
        }

        // POST: LookupBusBars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookupBusBar = await _context.LookupBusBar.FindAsync(id);
            _context.LookupBusBar.Remove(lookupBusBar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookupBusBarExists(int id)
        {
            return _context.LookupBusBar.Any(e => e.BusBarId == id);
        }
    }
}
