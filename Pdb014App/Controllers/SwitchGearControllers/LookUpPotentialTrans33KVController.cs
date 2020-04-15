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
    public class LookUpPotentialTrans33KVController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpPotentialTrans33KVController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpPotentialTrans33KV
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpPotentialTrans33KV.Include(l => l.PotentialTransformerToSwitchGear);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpPotentialTrans33KV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpPotentialTrans33KV = await _context.LookUpPotentialTrans33KV
                .Include(l => l.PotentialTransformerToSwitchGear)
                .FirstOrDefaultAsync(m => m.PotentialTransformerId == id);
            if (lookUpPotentialTrans33KV == null)
            {
                return NotFound();
            }

            return View(lookUpPotentialTrans33KV);
        }

        // GET: LookUpPotentialTrans33KV/Create
        public IActionResult Create()
        {
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID");
            return View();
        }

        // POST: LookUpPotentialTrans33KV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PotentialTransformerId,SwitchGearID,NameoftheManufacturer,TypeAndModelNo,NominalSystemVoltage,HeightsSystemVoltage,RatedPrimaryVoltage,RatedSecondaryVoltageandTertiaryVoltage,ImpulseWithstAndVoltage,MicroSec12or50,PowerFrequencyWithstandVoltage,BurdenOrClass,MeteringWinding,ProtectionWinding")] LookUpPotentialTrans33KV lookUpPotentialTrans33KV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpPotentialTrans33KV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", lookUpPotentialTrans33KV.SwitchGearID);
            return View(lookUpPotentialTrans33KV);
        }

        // GET: LookUpPotentialTrans33KV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpPotentialTrans33KV = await _context.LookUpPotentialTrans33KV.FindAsync(id);
            if (lookUpPotentialTrans33KV == null)
            {
                return NotFound();
            }
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", lookUpPotentialTrans33KV.SwitchGearID);
            return View(lookUpPotentialTrans33KV);
        }

        // POST: LookUpPotentialTrans33KV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PotentialTransformerId,SwitchGearID,NameoftheManufacturer,TypeAndModelNo,NominalSystemVoltage,HeightsSystemVoltage,RatedPrimaryVoltage,RatedSecondaryVoltageandTertiaryVoltage,ImpulseWithstAndVoltage,MicroSec12or50,PowerFrequencyWithstandVoltage,BurdenOrClass,MeteringWinding,ProtectionWinding")] LookUpPotentialTrans33KV lookUpPotentialTrans33KV)
        {
            if (id != lookUpPotentialTrans33KV.PotentialTransformerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpPotentialTrans33KV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpPotentialTrans33KVExists(lookUpPotentialTrans33KV.PotentialTransformerId))
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
            ViewData["SwitchGearID"] = new SelectList(_context.TblSwitchGear, "SwitchGearID", "SwitchGearID", lookUpPotentialTrans33KV.SwitchGearID);
            return View(lookUpPotentialTrans33KV);
        }

        // GET: LookUpPotentialTrans33KV/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpPotentialTrans33KV = await _context.LookUpPotentialTrans33KV
                .Include(l => l.PotentialTransformerToSwitchGear)
                .FirstOrDefaultAsync(m => m.PotentialTransformerId == id);
            if (lookUpPotentialTrans33KV == null)
            {
                return NotFound();
            }

            return View(lookUpPotentialTrans33KV);
        }

        // POST: LookUpPotentialTrans33KV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpPotentialTrans33KV = await _context.LookUpPotentialTrans33KV.FindAsync(id);
            _context.LookUpPotentialTrans33KV.Remove(lookUpPotentialTrans33KV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpPotentialTrans33KVExists(int id)
        {
            return _context.LookUpPotentialTrans33KV.Any(e => e.PotentialTransformerId == id);
        }
    }
}
