using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.InsulatorModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.InsulatorControllers
{
    public class TblInsulatorShackleOrGuysController : Controller
    {
        private readonly PdbDbContext _context;

        public TblInsulatorShackleOrGuysController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblInsulatorShackleOrGuys
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblInsulatorShackleOrGuy.Include(t => t.InsulatorShackleOrGuyToPole).Include(t => t.LookUpInsulatorShackleOrGuyType);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblInsulatorShackleOrGuys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorShackleOrGuy = await _context.TblInsulatorShackleOrGuy
                .Include(t => t.InsulatorShackleOrGuyToPole)
                .Include(t => t.LookUpInsulatorShackleOrGuyType)
                .FirstOrDefaultAsync(m => m.InsulatorShackleOrGuyId == id);
            if (tblInsulatorShackleOrGuy == null)
            {
                return NotFound();
            }

            return View(tblInsulatorShackleOrGuy);
        }

        // GET: TblInsulatorShackleOrGuys/Create
        public IActionResult Create()
        {

            var poleIdList = _context.TblPole.AsNoTracking()
                .Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList();
            ViewData["PoleId"] = poleIdList;
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["InsulatorShackleOrGuyTypeId"] = new SelectList(_context.LookUpInsulatorShackleOrGuyType, "InsulatorShackleOrGuyTypeId", "InsulatorShackleOrGuyTypeName");
            return View();
        }

        // POST: TblInsulatorShackleOrGuys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsulatorShackleOrGuyId,InsulatorShackleOrGuyTypeId,Installation,NominalSystemVoltage,MaximumSystemVoltage,TypeOfSystem,MinimumDiameterOfInsulator,MinimumHeightOfTheInsulator,MinimumMechanicalFailingLoadTransverse,DryFlashover,WetFlashoverVertical,WetFlashoverHorizontal,InsulationClass,AtmosphericCondition,Dimension,FlashOverVoltage,PowerFrequencyPunctureVoltage,MechanicalStrength,PoleId")] TblInsulatorShackleOrGuy tblInsulatorShackleOrGuy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblInsulatorShackleOrGuy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorShackleOrGuy.PoleId);
            ViewData["InsulatorShackleOrGuyTypeId"] = new SelectList(_context.LookUpInsulatorShackleOrGuyType, "InsulatorShackleOrGuyTypeId", "InsulatorShackleOrGuyTypeId", tblInsulatorShackleOrGuy.InsulatorShackleOrGuyTypeId);
            return View(tblInsulatorShackleOrGuy);
        }

        // GET: TblInsulatorShackleOrGuys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorShackleOrGuy = await _context.TblInsulatorShackleOrGuy.FindAsync(id);
            if (tblInsulatorShackleOrGuy == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorShackleOrGuy.PoleId);
            ViewData["InsulatorShackleOrGuyTypeId"] = new SelectList(_context.LookUpInsulatorShackleOrGuyType, "InsulatorShackleOrGuyTypeId", "InsulatorShackleOrGuyTypeName", tblInsulatorShackleOrGuy.InsulatorShackleOrGuyTypeId);
            return View(tblInsulatorShackleOrGuy);
        }

        // POST: TblInsulatorShackleOrGuys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsulatorShackleOrGuyId,InsulatorShackleOrGuyTypeId,Installation,NominalSystemVoltage,MaximumSystemVoltage,TypeOfSystem,MinimumDiameterOfInsulator,MinimumHeightOfTheInsulator,MinimumMechanicalFailingLoadTransverse,DryFlashover,WetFlashoverVertical,WetFlashoverHorizontal,InsulationClass,AtmosphericCondition,Dimension,FlashOverVoltage,PowerFrequencyPunctureVoltage,MechanicalStrength,PoleId")] TblInsulatorShackleOrGuy tblInsulatorShackleOrGuy)
        {
            if (id != tblInsulatorShackleOrGuy.InsulatorShackleOrGuyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblInsulatorShackleOrGuy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblInsulatorShackleOrGuyExists(tblInsulatorShackleOrGuy.InsulatorShackleOrGuyId))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorShackleOrGuy.PoleId);
            ViewData["InsulatorShackleOrGuyTypeId"] = new SelectList(_context.LookUpInsulatorShackleOrGuyType, "InsulatorShackleOrGuyTypeId", "InsulatorShackleOrGuyTypeId", tblInsulatorShackleOrGuy.InsulatorShackleOrGuyTypeId);
            return View(tblInsulatorShackleOrGuy);
        }

        // GET: TblInsulatorShackleOrGuys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorShackleOrGuy = await _context.TblInsulatorShackleOrGuy
                .Include(t => t.InsulatorShackleOrGuyToPole)
                .Include(t => t.LookUpInsulatorShackleOrGuyType)
                .FirstOrDefaultAsync(m => m.InsulatorShackleOrGuyId == id);
            if (tblInsulatorShackleOrGuy == null)
            {
                return NotFound();
            }

            return View(tblInsulatorShackleOrGuy);
        }

        // POST: TblInsulatorShackleOrGuys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblInsulatorShackleOrGuy = await _context.TblInsulatorShackleOrGuy.FindAsync(id);
            _context.TblInsulatorShackleOrGuy.Remove(tblInsulatorShackleOrGuy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblInsulatorShackleOrGuyExists(int id)
        {
            return _context.TblInsulatorShackleOrGuy.Any(e => e.InsulatorShackleOrGuyId == id);
        }
    }
}
