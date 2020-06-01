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
    public class TblGuysController : Controller
    {
        private readonly PdbDbContext _context;

        public TblGuysController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblGuys
        public async Task<IActionResult> Index(string id)
        {           
            var pdbDbContext = _context.TblGuy.Include(t => t.GuyToLookUpCondition).Include(t => t.GuyToPole).Include(t => t.GuyType);
            if (id != null)
            {
                pdbDbContext = _context.TblGuy.Where(i => i.PoleId == id).Include(t => t.GuyToLookUpCondition).Include(t => t.GuyToPole).Include(t => t.GuyType);
            }
            return PartialView(await pdbDbContext.ToListAsync());
        }

        // GET: TblGuys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuy = await _context.TblGuy
                .Include(t => t.GuyToLookUpCondition)
                .Include(t => t.GuyToPole)
                .Include(t => t.GuyType)
                .FirstOrDefaultAsync(m => m.GuyId == id);
            if (tblGuy == null)
            {
                return NotFound();
            }

            return View(tblGuy);
        }

        // GET: TblGuys/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["GuyTypeId"] = new SelectList(_context.LookUpGuyType, "GuyTypeId", "GuyTypeName");
            return View();
        }

        // POST: TblGuys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuyId,GuyTypeId,ConditionId,NoOfSet,PoleId")] TblGuy tblGuy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblGuy);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                TempData["statuMessageSuccess"] = "Guy has been Added Successfully under pole id: " + tblGuy.PoleId;
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "TblPoles");
            }
            ViewData["ConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblGuy.ConditionId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblGuy.PoleId);
            ViewData["GuyTypeId"] = new SelectList(_context.LookUpGuyType, "GuyTypeId", "GuyTypeName", tblGuy.GuyTypeId);
            return View(tblGuy);
        }

        // GET: TblGuys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuy = await _context.TblGuy.FindAsync(id);
            if (tblGuy == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblGuy.ConditionId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblGuy.PoleId);
            ViewData["GuyTypeId"] = new SelectList(_context.LookUpGuyType, "GuyTypeId", "GuyTypeName", tblGuy.GuyTypeId);
            return View(tblGuy);
        }

        // POST: TblGuys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuyId,GuyTypeId,ConditionId,NoOfSet,PoleId")] TblGuy tblGuy)
        {
            if (id != tblGuy.GuyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGuy);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblGuyExists(tblGuy.GuyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["statuMessageSuccess"] = "Guy has been Updated Successfully under pole id: " + tblGuy.PoleId;
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "TblPoles");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblGuy.ConditionId);
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblGuy.PoleId);
            ViewData["GuyTypeId"] = new SelectList(_context.LookUpGuyType, "GuyTypeId", "GuyTypeName", tblGuy.GuyTypeId);
            return View(tblGuy);
        }

        // GET: TblGuys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuy = await _context.TblGuy
                .Include(t => t.GuyToLookUpCondition)
                .Include(t => t.GuyToPole)
                .Include(t => t.GuyType)
                .FirstOrDefaultAsync(m => m.GuyId == id);
            if (tblGuy == null)
            {
                return NotFound();
            }

            return View(tblGuy);
        }

        // POST: TblGuys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblGuy = await _context.TblGuy.FindAsync(id);
            _context.TblGuy.Remove(tblGuy);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            TempData["statuMessageSuccess"] = "Guy has been Deleted Successfully under pole id: " + tblGuy.PoleId;
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "TblPoles");
        }

        private bool TblGuyExists(int id)
        {
            return _context.TblGuy.Any(e => e.GuyId == id);
        }
    }
}
