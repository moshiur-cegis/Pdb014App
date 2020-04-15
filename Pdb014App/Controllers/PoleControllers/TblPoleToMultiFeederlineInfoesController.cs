using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.PoleModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers
{
    public class TblPoleToMultiFeederlineInfoesController : Controller
    {
        private readonly PdbDbContext _context;

        public TblPoleToMultiFeederlineInfoesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblPoleToMultiFeederlineInfoes
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblPoleToMultiFeederlineInfo.Include(t => t.MultiFeederLineInfo).Include(t => t.NextPoleInfo).Include(t => t.PoleInfo).Include(t => t.PreviousPoleInfo);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblPoleToMultiFeederlineInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleToMultiFeederlineInfo = await _context.TblPoleToMultiFeederlineInfo
                .Include(t => t.MultiFeederLineInfo)
                .Include(t => t.NextPoleInfo)
                .Include(t => t.PoleInfo)
                .Include(t => t.PreviousPoleInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPoleToMultiFeederlineInfo == null)
            {
                return NotFound();
            }

            return View(tblPoleToMultiFeederlineInfo);
        }

        // GET: TblPoleToMultiFeederlineInfoes/Create
        public IActionResult Create()
        {
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["NextPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["PreviousPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            return View();
        }

        // POST: TblPoleToMultiFeederlineInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PoleId,FeederLineId,PreviousPoleId,NextPoleId")] TblPoleToMultiFeederlineInfo tblPoleToMultiFeederlineInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPoleToMultiFeederlineInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName", tblPoleToMultiFeederlineInfo.FeederLineId);
            ViewData["NextPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.NextPoleId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.PoleId);
            ViewData["PreviousPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.PreviousPoleId);
            return View(tblPoleToMultiFeederlineInfo);
        }

        // GET: TblPoleToMultiFeederlineInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleToMultiFeederlineInfo = await _context.TblPoleToMultiFeederlineInfo.FindAsync(id);
            if (tblPoleToMultiFeederlineInfo == null)
            {
                return NotFound();
            }
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblPoleToMultiFeederlineInfo.FeederLineId);
            ViewData["NextPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.NextPoleId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.PoleId);
            ViewData["PreviousPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.PreviousPoleId);
            return View(tblPoleToMultiFeederlineInfo);
        }

        // POST: TblPoleToMultiFeederlineInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PoleId,FeederLineId,PreviousPoleId,NextPoleId")] TblPoleToMultiFeederlineInfo tblPoleToMultiFeederlineInfo)
        {
            if (id != tblPoleToMultiFeederlineInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPoleToMultiFeederlineInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPoleToMultiFeederlineInfoExists(tblPoleToMultiFeederlineInfo.Id))
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
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblPoleToMultiFeederlineInfo.FeederLineId);
            ViewData["NextPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.NextPoleId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.PoleId);
            ViewData["PreviousPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleToMultiFeederlineInfo.PreviousPoleId);
            return View(tblPoleToMultiFeederlineInfo);
        }

        // GET: TblPoleToMultiFeederlineInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleToMultiFeederlineInfo = await _context.TblPoleToMultiFeederlineInfo
                .Include(t => t.MultiFeederLineInfo)
                .Include(t => t.NextPoleInfo)
                .Include(t => t.PoleInfo)
                .Include(t => t.PreviousPoleInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPoleToMultiFeederlineInfo == null)
            {
                return NotFound();
            }

            return View(tblPoleToMultiFeederlineInfo);
        }

        // POST: TblPoleToMultiFeederlineInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPoleToMultiFeederlineInfo = await _context.TblPoleToMultiFeederlineInfo.FindAsync(id);
            _context.TblPoleToMultiFeederlineInfo.Remove(tblPoleToMultiFeederlineInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPoleToMultiFeederlineInfoExists(int id)
        {
            return _context.TblPoleToMultiFeederlineInfo.Any(e => e.Id == id);
        }
    }
}
