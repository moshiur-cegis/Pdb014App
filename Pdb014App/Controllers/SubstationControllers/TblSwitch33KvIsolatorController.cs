using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.SubstationControllers
{
    public class TblSwitch33KvIsolatorController : Controller
    {
        private readonly PdbDbContext _context;

        public TblSwitch33KvIsolatorController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblSwitch33KvIsolator
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblSwitch33KvIsolator.Include(t => t.Switch33KvIsolatorToSubstation).Include(t => t.SwitchToFeederLine);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblSwitch33KvIsolator/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSwitch33KvIsolator = await _context.TblSwitch33KvIsolator
                .Include(t => t.Switch33KvIsolatorToSubstation)
                .Include(t => t.SwitchToFeederLine)
                .FirstOrDefaultAsync(m => m.Switch33KvIsolatorId == id);
            if (tblSwitch33KvIsolator == null)
            {
                return NotFound();
            }

            return View(tblSwitch33KvIsolator);
        }

        // GET: TblSwitch33KvIsolator/Create
        public IActionResult Create()
        {
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId");
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId");
            return View();
        }

        // POST: TblSwitch33KvIsolator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Switch33KvIsolatorId,TypeIsolatorSwitch,SwitchID,NominalVoltage,BreakingType,ManufactureMonthAndYear,InstallationDate,NormalStatus,RatedCurrent,RatedVoltage,ConnectionStatus,SwitchNo,FeederLineId,SubstationId")] TblSwitch33KvIsolator tblSwitch33KvIsolator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSwitch33KvIsolator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblSwitch33KvIsolator.SubstationId);
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblSwitch33KvIsolator.FeederLineId);
            return View(tblSwitch33KvIsolator);
        }

        // GET: TblSwitch33KvIsolator/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSwitch33KvIsolator = await _context.TblSwitch33KvIsolator.FindAsync(id);
            if (tblSwitch33KvIsolator == null)
            {
                return NotFound();
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblSwitch33KvIsolator.SubstationId);
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblSwitch33KvIsolator.FeederLineId);
            return View(tblSwitch33KvIsolator);
        }

        // POST: TblSwitch33KvIsolator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Switch33KvIsolatorId,TypeIsolatorSwitch,SwitchID,NominalVoltage,BreakingType,ManufactureMonthAndYear,InstallationDate,NormalStatus,RatedCurrent,RatedVoltage,ConnectionStatus,SwitchNo,FeederLineId,SubstationId")] TblSwitch33KvIsolator tblSwitch33KvIsolator)
        {
            if (id != tblSwitch33KvIsolator.Switch33KvIsolatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSwitch33KvIsolator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSwitch33KvIsolatorExists(tblSwitch33KvIsolator.Switch33KvIsolatorId))
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
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblSwitch33KvIsolator.SubstationId);
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblSwitch33KvIsolator.FeederLineId);
            return View(tblSwitch33KvIsolator);
        }

        // GET: TblSwitch33KvIsolator/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSwitch33KvIsolator = await _context.TblSwitch33KvIsolator
                .Include(t => t.Switch33KvIsolatorToSubstation)
                .Include(t => t.SwitchToFeederLine)
                .FirstOrDefaultAsync(m => m.Switch33KvIsolatorId == id);
            if (tblSwitch33KvIsolator == null)
            {
                return NotFound();
            }

            return View(tblSwitch33KvIsolator);
        }

        // POST: TblSwitch33KvIsolator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSwitch33KvIsolator = await _context.TblSwitch33KvIsolator.FindAsync(id);
            _context.TblSwitch33KvIsolator.Remove(tblSwitch33KvIsolator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSwitch33KvIsolatorExists(int id)
        {
            return _context.TblSwitch33KvIsolator.Any(e => e.Switch33KvIsolatorId == id);
        }
    }
}
