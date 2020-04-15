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
    public class TblInsulatorDisksController : Controller
    {
        private readonly PdbDbContext _context;

        public TblInsulatorDisksController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblInsulatorDisks
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblInsulatorDisk.Include(t => t.InsulatorDiskToPole).Include(t => t.LookUpInsulatorDiskType);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblInsulatorDisks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorDisk = await _context.TblInsulatorDisk
                .Include(t => t.InsulatorDiskToPole)
                .Include(t => t.LookUpInsulatorDiskType)
                .FirstOrDefaultAsync(m => m.InsulatorDisktId == id);
            if (tblInsulatorDisk == null)
            {
                return NotFound();
            }

            return View(tblInsulatorDisk);
        }

        // GET: TblInsulatorDisks/Create
        public IActionResult Create()
        {
            var poleIdList = _context.TblPole.AsNoTracking()
                .Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList();
            ViewData["PoleId"] = poleIdList;
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["InsulatorDiskTypeId"] = new SelectList(_context.LookUpInsulatorDiskType, "InsulatorDiskTypeId", "InsulatorDiskTypeName");
            return View();
        }

        // POST: TblInsulatorDisks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsulatorDisktId,Installation,NominalSystemVoltage,InsulatorDiskTypeId,MaximumSystemVoltage,TypeOfSystem,NumberOfDiskPerString,MinimumCreepageDistance,MinimumWithstandVoltage,PowerFrequencyDry,PowerFrequencyWet,ImpulseWithstandVoltage,MinimumPowerFrequencyFlashoverDry,MinimumPowerFrequencyFlashoverWet,FiftyPctImpulseFlashoverWavePositive,FiftyPctImpulseFlashoverWaveNegative,PowerFrequencyPuncherVoltage,MinimumDryArchingDistance,PowerFrequencyTestVoltageRmsToGround,MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt,MinimumElectromechanicalStrength,MinimumMechanicalFailingLoad,TypeOfInsulator,DiameterOfInsulator,MinimumUnitSpacing,CouplingSize,PoleId")] TblInsulatorDisk tblInsulatorDisk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblInsulatorDisk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorDisk.PoleId);
            ViewData["InsulatorDiskTypeId"] = new SelectList(_context.LookUpInsulatorDiskType, "InsulatorDiskTypeId", "InsulatorDiskTypeId", tblInsulatorDisk.InsulatorDiskTypeId);
            return View(tblInsulatorDisk);
        }

        // GET: TblInsulatorDisks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorDisk = await _context.TblInsulatorDisk.FindAsync(id);
            if (tblInsulatorDisk == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorDisk.PoleId);
            ViewData["InsulatorDiskTypeId"] = new SelectList(_context.LookUpInsulatorDiskType, "InsulatorDiskTypeId", "InsulatorDiskTypeId", tblInsulatorDisk.InsulatorDiskTypeId);
            return View(tblInsulatorDisk);
        }

        // POST: TblInsulatorDisks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsulatorDisktId,Installation,NominalSystemVoltage,InsulatorDiskTypeId,MaximumSystemVoltage,TypeOfSystem,NumberOfDiskPerString,MinimumCreepageDistance,MinimumWithstandVoltage,PowerFrequencyDry,PowerFrequencyWet,ImpulseWithstandVoltage,MinimumPowerFrequencyFlashoverDry,MinimumPowerFrequencyFlashoverWet,FiftyPctImpulseFlashoverWavePositive,FiftyPctImpulseFlashoverWaveNegative,PowerFrequencyPuncherVoltage,MinimumDryArchingDistance,PowerFrequencyTestVoltageRmsToGround,MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt,MinimumElectromechanicalStrength,MinimumMechanicalFailingLoad,TypeOfInsulator,DiameterOfInsulator,MinimumUnitSpacing,CouplingSize,PoleId")] TblInsulatorDisk tblInsulatorDisk)
        {
            if (id != tblInsulatorDisk.InsulatorDisktId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblInsulatorDisk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblInsulatorDiskExists(tblInsulatorDisk.InsulatorDisktId))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorDisk.PoleId);
            ViewData["InsulatorDiskTypeId"] = new SelectList(_context.LookUpInsulatorDiskType, "InsulatorDiskTypeId", "InsulatorDiskTypeId", tblInsulatorDisk.InsulatorDiskTypeId);
            return View(tblInsulatorDisk);
        }

        // GET: TblInsulatorDisks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorDisk = await _context.TblInsulatorDisk
                .Include(t => t.InsulatorDiskToPole)
                .Include(t => t.LookUpInsulatorDiskType)
                .FirstOrDefaultAsync(m => m.InsulatorDisktId == id);
            if (tblInsulatorDisk == null)
            {
                return NotFound();
            }

            return View(tblInsulatorDisk);
        }

        // POST: TblInsulatorDisks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblInsulatorDisk = await _context.TblInsulatorDisk.FindAsync(id);
            _context.TblInsulatorDisk.Remove(tblInsulatorDisk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblInsulatorDiskExists(int id)
        {
            return _context.TblInsulatorDisk.Any(e => e.InsulatorDisktId == id);
        }
    }
}
