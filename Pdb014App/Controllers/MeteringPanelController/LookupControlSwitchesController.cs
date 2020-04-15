using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.MeteringPanelModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.MeteringPanelController
{
    public class LookupControlSwitchesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookupControlSwitchesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookupControlSwitches
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookupControlSwitch.ToListAsync());
        }

        // GET: LookupControlSwitches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupControlSwitch = await _context.LookupControlSwitch
                .FirstOrDefaultAsync(m => m.ControlSwitchId == id);
            if (lookupControlSwitch == null)
            {
                return NotFound();
            }

            return View(lookupControlSwitch);
        }

        // GET: LookupControlSwitches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookupControlSwitches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ControlSwitchId,ControlSwitch,ManufacturesNameCountry,ManufacturesModelTypeNo")] LookupControlSwitch lookupControlSwitch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookupControlSwitch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookupControlSwitch);
        }

        // GET: LookupControlSwitches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupControlSwitch = await _context.LookupControlSwitch.FindAsync(id);
            if (lookupControlSwitch == null)
            {
                return NotFound();
            }
            return View(lookupControlSwitch);
        }

        // POST: LookupControlSwitches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ControlSwitchId,ControlSwitch,ManufacturesNameCountry,ManufacturesModelTypeNo")] LookupControlSwitch lookupControlSwitch)
        {
            if (id != lookupControlSwitch.ControlSwitchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookupControlSwitch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookupControlSwitchExists(lookupControlSwitch.ControlSwitchId))
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
            return View(lookupControlSwitch);
        }

        // GET: LookupControlSwitches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookupControlSwitch = await _context.LookupControlSwitch
                .FirstOrDefaultAsync(m => m.ControlSwitchId == id);
            if (lookupControlSwitch == null)
            {
                return NotFound();
            }

            return View(lookupControlSwitch);
        }

        // POST: LookupControlSwitches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookupControlSwitch = await _context.LookupControlSwitch.FindAsync(id);
            _context.LookupControlSwitch.Remove(lookupControlSwitch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookupControlSwitchExists(int id)
        {
            return _context.LookupControlSwitch.Any(e => e.ControlSwitchId == id);
        }
    }
}
