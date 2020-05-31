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
    public class TblInsulatorsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblInsulatorsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblInsulators
        public async Task<IActionResult> Index(string id)
        {
            var pdbDbContext = _context.TblInsulator.Include(t => t.InsulatorToLookUpCondition).Include(t => t.InsulatorToPole).Include(t => t.InsulatorType);

            if (id!= null)
            {
                 pdbDbContext = _context.TblInsulator.Where(i => i.PoleId == id).Include(t => t.InsulatorToLookUpCondition).Include(t => t.InsulatorToPole).Include(t => t.InsulatorType);
            }
           
            
            return PartialView(await pdbDbContext.ToListAsync());
        }

        // GET: TblInsulators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulator = await _context.TblInsulator
                .Include(t => t.InsulatorToLookUpCondition)
                .Include(t => t.InsulatorToPole)
                .Include(t => t.InsulatorType)
                .FirstOrDefaultAsync(m => m.InsulatorId == id);
            if (tblInsulator == null)
            {
                return NotFound();
            }

            return View(tblInsulator);
        }

        // GET: TblInsulators/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");

                //ViewBag.PoleId = RouteData.

                //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            
            ViewData["InsulatorTypeId"] = new SelectList(_context.LookUpInsulatorType, "InsulatorTypeId", "InsulatorTypeName");
            return View();
        }

        // POST: TblInsulators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsulatorId,Installation,NominalSystemVoltage,InsulatorTypeId,MaximumSystemVoltage,TypeOfSystem,InsulatorVoltageClass,InsulatorMaterials,MinimumCreepageDistance,MinimumWithstandVoltage,PowerFrequencyDry,PowerFrequencyWet,ImpulseWithstandVoltage,MinimumPowerFrequencyFlashoverDry,MinimumPowerFrequencyFlashoverWet,FiftyPctImpulseFlashoverWavePositive,FiftyPctImpulseFlashoverWaveNegative,PowerFrequencyPuncherVoltage,MinimumDryArchingDistance,PowerFrequencyTestVoltageRmsToGround,MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt,MinimumNeckDiameter,MinimumDiameterOfInsulator,MinimumHeightOfTheInsulator,MinimumGroveDiameter,MinimumMechanicalFailingLoad,ConditionId,Quantity,PoleId")] TblInsulator tblInsulator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblInsulator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblInsulator.ConditionId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulator.PoleId);
            ViewData["InsulatorTypeId"] = new SelectList(_context.LookUpInsulatorType, "InsulatorTypeId", "InsulatorTypeName", tblInsulator.InsulatorTypeId);
            return View(tblInsulator);
        }

        // GET: TblInsulators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulator = await _context.TblInsulator.FindAsync(id);
            if (tblInsulator == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblInsulator.ConditionId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulator.PoleId);
            ViewData["InsulatorTypeId"] = new SelectList(_context.LookUpInsulatorType, "InsulatorTypeId", "InsulatorTypeName", tblInsulator.InsulatorTypeId);
            return View(tblInsulator);
        }

        // POST: TblInsulators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsulatorId,Installation,NominalSystemVoltage,InsulatorTypeId,MaximumSystemVoltage,TypeOfSystem,InsulatorVoltageClass,InsulatorMaterials,MinimumCreepageDistance,MinimumWithstandVoltage,PowerFrequencyDry,PowerFrequencyWet,ImpulseWithstandVoltage,MinimumPowerFrequencyFlashoverDry,MinimumPowerFrequencyFlashoverWet,FiftyPctImpulseFlashoverWavePositive,FiftyPctImpulseFlashoverWaveNegative,PowerFrequencyPuncherVoltage,MinimumDryArchingDistance,PowerFrequencyTestVoltageRmsToGround,MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt,MinimumNeckDiameter,MinimumDiameterOfInsulator,MinimumHeightOfTheInsulator,MinimumGroveDiameter,MinimumMechanicalFailingLoad,ConditionId,Quantity,PoleId")] TblInsulator tblInsulator)
        {
            if (id != tblInsulator.InsulatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblInsulator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblInsulatorExists(tblInsulator.InsulatorId))
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
            ViewData["ConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblInsulator.ConditionId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulator.PoleId);
            ViewData["InsulatorTypeId"] = new SelectList(_context.LookUpInsulatorType, "InsulatorTypeId", "InsulatorTypeName", tblInsulator.InsulatorTypeId);
            return View(tblInsulator);
        }

        // GET: TblInsulators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulator = await _context.TblInsulator
                .Include(t => t.InsulatorToLookUpCondition)
                .Include(t => t.InsulatorToPole)
                .Include(t => t.InsulatorType)
                .FirstOrDefaultAsync(m => m.InsulatorId == id);
            if (tblInsulator == null)
            {
                return NotFound();
            }

            return View(tblInsulator);
        }

        // POST: TblInsulators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblInsulator = await _context.TblInsulator.FindAsync(id);
            _context.TblInsulator.Remove(tblInsulator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblInsulatorExists(int id)
        {
            return _context.TblInsulator.Any(e => e.InsulatorId == id);
        }
    }
}
