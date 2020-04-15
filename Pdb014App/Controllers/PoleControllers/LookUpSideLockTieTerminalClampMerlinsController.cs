using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.PoleControllers
{
    public class LookUpSideLockTieTerminalClampMerlinsController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpSideLockTieTerminalClampMerlinsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpSideLockTieTerminalClampMerlins
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpSideLockTieTerminalClampMerlin.Include(l => l.SideLockTieTerminalClampMerlinToPole);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpSideLockTieTerminalClampMerlins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSideLockTieTerminalClampMerlin = await _context.LookUpSideLockTieTerminalClampMerlin
                .Include(l => l.SideLockTieTerminalClampMerlinToPole)
                .FirstOrDefaultAsync(m => m.SideLockTieTerminalClampMerlinId == id);
            if (lookUpSideLockTieTerminalClampMerlin == null)
            {
                return NotFound();
            }

            return View(lookUpSideLockTieTerminalClampMerlin);
        }

        // GET: LookUpSideLockTieTerminalClampMerlins/Create
        public IActionResult Create()
        {
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            return View();
        }

        // POST: LookUpSideLockTieTerminalClampMerlins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SideLockTieTerminalClampMerlinId,SideLockTieTerminalClampMerlinType,Materials,Standard,UltimateTensileStrength,PoleId")] LookUpSideLockTieTerminalClampMerlin lookUpSideLockTieTerminalClampMerlin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpSideLockTieTerminalClampMerlin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", lookUpSideLockTieTerminalClampMerlin.PoleId);
            return View(lookUpSideLockTieTerminalClampMerlin);
        }

        // GET: LookUpSideLockTieTerminalClampMerlins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSideLockTieTerminalClampMerlin = await _context.LookUpSideLockTieTerminalClampMerlin.FindAsync(id);
            if (lookUpSideLockTieTerminalClampMerlin == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", lookUpSideLockTieTerminalClampMerlin.PoleId);
            return View(lookUpSideLockTieTerminalClampMerlin);
        }

        // POST: LookUpSideLockTieTerminalClampMerlins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SideLockTieTerminalClampMerlinId,SideLockTieTerminalClampMerlinType,Materials,Standard,UltimateTensileStrength,PoleId")] LookUpSideLockTieTerminalClampMerlin lookUpSideLockTieTerminalClampMerlin)
        {
            if (id != lookUpSideLockTieTerminalClampMerlin.SideLockTieTerminalClampMerlinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpSideLockTieTerminalClampMerlin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpSideLockTieTerminalClampMerlinExists(lookUpSideLockTieTerminalClampMerlin.SideLockTieTerminalClampMerlinId))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", lookUpSideLockTieTerminalClampMerlin.PoleId);
            return View(lookUpSideLockTieTerminalClampMerlin);
        }

        // GET: LookUpSideLockTieTerminalClampMerlins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSideLockTieTerminalClampMerlin = await _context.LookUpSideLockTieTerminalClampMerlin
                .Include(l => l.SideLockTieTerminalClampMerlinToPole)
                .FirstOrDefaultAsync(m => m.SideLockTieTerminalClampMerlinId == id);
            if (lookUpSideLockTieTerminalClampMerlin == null)
            {
                return NotFound();
            }

            return View(lookUpSideLockTieTerminalClampMerlin);
        }

        // POST: LookUpSideLockTieTerminalClampMerlins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpSideLockTieTerminalClampMerlin = await _context.LookUpSideLockTieTerminalClampMerlin.FindAsync(id);
            _context.LookUpSideLockTieTerminalClampMerlin.Remove(lookUpSideLockTieTerminalClampMerlin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpSideLockTieTerminalClampMerlinExists(string id)
        {
            return _context.LookUpSideLockTieTerminalClampMerlin.Any(e => e.SideLockTieTerminalClampMerlinId == id);
        }
    }
}
