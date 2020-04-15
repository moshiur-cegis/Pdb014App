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
    public class TblRelaysController : Controller
    {
        private readonly PdbDbContext _context;

        public TblRelaysController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblRelays
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblRelay
                .Include(t => t.RelayToFeederLine)
                .Include(t => t.RelayToSubstation);

            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblRelays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRelay = await _context.TblRelay
                .Include(t => t.RelayToFeederLine)
                .Include(t => t.RelayToSubstation)
                .FirstOrDefaultAsync(m => m.RelayId == id);
            if (tblRelay == null)
            {
                return NotFound();
            }

            return View(tblRelay);
        }

        // GET: TblRelays/Create
        public IActionResult Create()
        {
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId");
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId");
            return View();
        }

        // POST: TblRelays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelayId,RelayName,NominalVoltage,ManufactureName,ModelNumber,RatedCurrent,RatedVoltage,ConnectionStatus,FeederLineId,SubstationId")] TblRelay tblRelay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblRelay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblRelay.FeederLineId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblRelay.SubstationId);
            return View(tblRelay);
        }

        // GET: TblRelays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRelay = await _context.TblRelay.FindAsync(id);
            if (tblRelay == null)
            {
                return NotFound();
            }
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblRelay.FeederLineId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblRelay.SubstationId);
            return View(tblRelay);
        }

        // POST: TblRelays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelayId,RelayName,NominalVoltage,ManufactureName,ModelNumber,RatedCurrent,RatedVoltage,ConnectionStatus,FeederLineId,SubstationId")] TblRelay tblRelay)
        {
            if (id != tblRelay.RelayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRelay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRelayExists(tblRelay.RelayId))
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
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblRelay.FeederLineId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblRelay.SubstationId);
            return View(tblRelay);
        }

        // GET: TblRelays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRelay = await _context.TblRelay
                .Include(t => t.RelayToFeederLine)
                .Include(t => t.RelayToSubstation)
                .FirstOrDefaultAsync(m => m.RelayId == id);
            if (tblRelay == null)
            {
                return NotFound();
            }

            return View(tblRelay);
        }

        // POST: TblRelays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRelay = await _context.TblRelay.FindAsync(id);
            _context.TblRelay.Remove(tblRelay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRelayExists(int id)
        {
            return _context.TblRelay.Any(e => e.RelayId == id);
        }
    }
}
