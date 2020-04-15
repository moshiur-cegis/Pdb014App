using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.Mount_BracketModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.PoleControllers
{
    public class TblSpecificationsOfMountBracketsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblSpecificationsOfMountBracketsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblSpecificationsOfMountBrackets
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblSpecificationsOfMountBracket.Include(t => t.LookUpSpecificationsOfMountBracketType).Include(t => t.SpecificationsOfMountBracketToPole);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblSpecificationsOfMountBrackets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSpecificationsOfMountBracket = await _context.TblSpecificationsOfMountBracket
                .Include(t => t.LookUpSpecificationsOfMountBracketType)
                .Include(t => t.SpecificationsOfMountBracketToPole)
                .FirstOrDefaultAsync(m => m.SpecificationsOfMountBracketId == id);
            if (tblSpecificationsOfMountBracket == null)
            {
                return NotFound();
            }

            return View(tblSpecificationsOfMountBracket);
        }

        // GET: TblSpecificationsOfMountBrackets/Create
        public IActionResult Create()
        {
            ViewData["SpecificationsOfMountBracketTypeId"] = new SelectList(_context.LookUpSpecificationsOfMountBracketType, "SpecificationsOfMountBracketTypeId", "SpecificationsOfMountBracketTypeName");
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            return View();
        }

        // POST: TblSpecificationsOfMountBrackets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecificationsOfMountBracketId,SpecificationsOfMountBracketTypeId,MountBrackeType,Materials,UltimateTensileStrength,Galvanization,Standard,PoleId")] TblSpecificationsOfMountBracket tblSpecificationsOfMountBracket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSpecificationsOfMountBracket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecificationsOfMountBracketTypeId"] = new SelectList(_context.LookUpSpecificationsOfMountBracketType, "SpecificationsOfMountBracketTypeId", "SpecificationsOfMountBracketTypeName", tblSpecificationsOfMountBracket.SpecificationsOfMountBracketTypeId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblSpecificationsOfMountBracket.PoleId);
            return View(tblSpecificationsOfMountBracket);
        }

        // GET: TblSpecificationsOfMountBrackets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSpecificationsOfMountBracket = await _context.TblSpecificationsOfMountBracket.FindAsync(id);
            if (tblSpecificationsOfMountBracket == null)
            {
                return NotFound();
            }
            ViewData["SpecificationsOfMountBracketTypeId"] = new SelectList(_context.LookUpSpecificationsOfMountBracketType, "SpecificationsOfMountBracketTypeId", "SpecificationsOfMountBracketTypeName", tblSpecificationsOfMountBracket.SpecificationsOfMountBracketTypeId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblSpecificationsOfMountBracket.PoleId);
            return View(tblSpecificationsOfMountBracket);
        }

        // POST: TblSpecificationsOfMountBrackets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecificationsOfMountBracketId,SpecificationsOfMountBracketTypeId,MountBrackeType,Materials,UltimateTensileStrength,Galvanization,Standard,PoleId")] TblSpecificationsOfMountBracket tblSpecificationsOfMountBracket)
        {
            if (id != tblSpecificationsOfMountBracket.SpecificationsOfMountBracketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSpecificationsOfMountBracket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSpecificationsOfMountBracketExists(tblSpecificationsOfMountBracket.SpecificationsOfMountBracketId))
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
            ViewData["SpecificationsOfMountBracketTypeId"] = new SelectList(_context.LookUpSpecificationsOfMountBracketType, "SpecificationsOfMountBracketTypeId", "SpecificationsOfMountBracketTypeName", tblSpecificationsOfMountBracket.SpecificationsOfMountBracketTypeId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblSpecificationsOfMountBracket.PoleId);
            return View(tblSpecificationsOfMountBracket);
        }

        // GET: TblSpecificationsOfMountBrackets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSpecificationsOfMountBracket = await _context.TblSpecificationsOfMountBracket
                .Include(t => t.LookUpSpecificationsOfMountBracketType)
                .Include(t => t.SpecificationsOfMountBracketToPole)
                .FirstOrDefaultAsync(m => m.SpecificationsOfMountBracketId == id);
            if (tblSpecificationsOfMountBracket == null)
            {
                return NotFound();
            }

            return View(tblSpecificationsOfMountBracket);
        }

        // POST: TblSpecificationsOfMountBrackets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSpecificationsOfMountBracket = await _context.TblSpecificationsOfMountBracket.FindAsync(id);
            _context.TblSpecificationsOfMountBracket.Remove(tblSpecificationsOfMountBracket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSpecificationsOfMountBracketExists(int id)
        {
            return _context.TblSpecificationsOfMountBracket.Any(e => e.SpecificationsOfMountBracketId == id);
        }
    }
}
