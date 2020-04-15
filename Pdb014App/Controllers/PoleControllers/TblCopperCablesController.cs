using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.CopperCableModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.PoleControllers
{
    public class TblCopperCablesController : Controller
    {
        private readonly PdbDbContext _context;

        public TblCopperCablesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblCopperCables
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblCopperCables.Include(t => t.ConductorToPole).Include(t => t.CopperCablesType);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblCopperCables/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var tblCopperCables = await _context.TblCopperCables
                .Include(t => t.ConductorToPole)
                .Include(t => t.CopperCablesType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCopperCables == null)
            {
                return NotFound();
            }

            return View(tblCopperCables);
        }

        // GET: TblCopperCables/Create
        public IActionResult Create()
        {
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["CopperCablesTypeId"] = new SelectList(_context.LookUpCopperCablesType, "CopperCablesTypeId", "CopperCablesTypeName");
            return View();
        }

        // POST: TblCopperCables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CopperCablesTypeId,CableSize,Material,NumbersAndDiameterofWires,MaximumResistanceat30degC,NominalThicknessofInsulation,NominalThicknessofSheath,ColorofSheath,ApproximateOuterDiameter,ApproximateWeight,ContinuousPermissibleServiceVoltage,CurrentRatingAt30degCambientTemperatureUorG,CurrentRatingat35degCambientinAir,PoleId")] TblCopperCables tblCopperCables)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCopperCables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblCopperCables.PoleId);
            ViewData["CopperCablesTypeId"] = new SelectList(_context.LookUpCopperCablesType, "CopperCablesTypeId", "CopperCablesTypeName", tblCopperCables.CopperCablesTypeId);
            return View(tblCopperCables);
        }

        // GET: TblCopperCables/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var tblCopperCables = await _context.TblCopperCables.FindAsync(id);
            if (tblCopperCables == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblCopperCables.PoleId);
            ViewData["CopperCablesTypeId"] = new SelectList(_context.LookUpCopperCablesType, "CopperCablesTypeId", "CopperCablesTypeName", tblCopperCables.CopperCablesTypeId);
            return View(tblCopperCables);
        }

        // POST: TblCopperCables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CopperCablesTypeId,CableSize,Material,NumbersAndDiameterofWires,MaximumResistanceat30degC,NominalThicknessofInsulation,NominalThicknessofSheath,ColorofSheath,ApproximateOuterDiameter,ApproximateWeight,ContinuousPermissibleServiceVoltage,CurrentRatingAt30degCambientTemperatureUorG,CurrentRatingat35degCambientinAir,PoleId")] TblCopperCables tblCopperCables)
        {
            if (id != tblCopperCables.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCopperCables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCopperCablesExists(tblCopperCables.Id))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblCopperCables.PoleId);
            ViewData["CopperCablesTypeId"] = new SelectList(_context.LookUpCopperCablesType, "CopperCablesTypeId", "CopperCablesTypeName", tblCopperCables.CopperCablesTypeId);
            return View(tblCopperCables);
        }

        // GET: TblCopperCables/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var tblCopperCables = await _context.TblCopperCables
                .Include(t => t.ConductorToPole)
                .Include(t => t.CopperCablesType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCopperCables == null)
            {
                return NotFound();
            }

            return View(tblCopperCables);
        }

        // POST: TblCopperCables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCopperCables = await _context.TblCopperCables.FindAsync(id);
            _context.TblCopperCables.Remove(tblCopperCables);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCopperCablesExists(int id)
        {
            return _context.TblCopperCables.Any(e => e.Id == id);
        }
    }
}
