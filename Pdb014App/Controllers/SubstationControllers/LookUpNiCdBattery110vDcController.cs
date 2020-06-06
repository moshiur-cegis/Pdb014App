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
    public class LookUpNiCdBattery110vDcController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpNiCdBattery110vDcController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpNiCdBattery110vDc
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpNiCdBattery110vDc.Include(l => l.NiCdBattery110VDcToSubstation);
            return View(await pdbDbContext.ToListAsync());
        }


        public async Task<IActionResult> NiCdBattery110vDcList(string substationId, int isShowLayout = 0, int isShowAction = 0)
        {
            ViewBag.IsShowLayout = isShowLayout;
            ViewBag.IsShowAction = isShowAction;

            var niCdBattery110vDcList = _context.LookUpNiCdBattery110vDc.Include(l => l.NiCdBattery110VDcToSubstation).AsNoTracking();


            if (substationId != null)
            {
                niCdBattery110vDcList = niCdBattery110vDcList.Where(p => p.SubstationId == substationId);
            }

            return View(await niCdBattery110vDcList.ToListAsync());
        }

        // GET: LookUpNiCdBattery110vDc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpNiCdBattery110vDc = await _context.LookUpNiCdBattery110vDc
                .Include(l => l.NiCdBattery110VDcToSubstation)
                .FirstOrDefaultAsync(m => m.NiCdBattery110vDcId == id);
            if (lookUpNiCdBattery110vDc == null)
            {
                return NotFound();
            }

            return View(lookUpNiCdBattery110vDc);
        }

        // GET: LookUpNiCdBattery110vDc/Create
        public IActionResult Create()
        {
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId");
            return View();
        }

        // POST: LookUpNiCdBattery110vDc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NiCdBattery110vDcId,SubstationId,ManufacturersNameAndAddress,ManufacturersModelNo,Type,OperatingVoltage,NumberOfCells,VoltagePerCell")] LookUpNiCdBattery110vDc lookUpNiCdBattery110vDc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpNiCdBattery110vDc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", lookUpNiCdBattery110vDc.SubstationId);
            return View(lookUpNiCdBattery110vDc);
        }

        // GET: LookUpNiCdBattery110vDc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpNiCdBattery110vDc = await _context.LookUpNiCdBattery110vDc.FindAsync(id);
            if (lookUpNiCdBattery110vDc == null)
            {
                return NotFound();
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", lookUpNiCdBattery110vDc.SubstationId);
            return View(lookUpNiCdBattery110vDc);
        }

        // POST: LookUpNiCdBattery110vDc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NiCdBattery110vDcId,SubstationId,ManufacturersNameAndAddress,ManufacturersModelNo,Type,OperatingVoltage,NumberOfCells,VoltagePerCell")] LookUpNiCdBattery110vDc lookUpNiCdBattery110vDc)
        {
            if (id != lookUpNiCdBattery110vDc.NiCdBattery110vDcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpNiCdBattery110vDc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpNiCdBattery110vDcExists(lookUpNiCdBattery110vDc.NiCdBattery110vDcId))
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
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", lookUpNiCdBattery110vDc.SubstationId);
            return View(lookUpNiCdBattery110vDc);
        }

        // GET: LookUpNiCdBattery110vDc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpNiCdBattery110vDc = await _context.LookUpNiCdBattery110vDc
                .Include(l => l.NiCdBattery110VDcToSubstation)
                .FirstOrDefaultAsync(m => m.NiCdBattery110vDcId == id);
            if (lookUpNiCdBattery110vDc == null)
            {
                return NotFound();
            }

            return View(lookUpNiCdBattery110vDc);
        }

        // POST: LookUpNiCdBattery110vDc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpNiCdBattery110vDc = await _context.LookUpNiCdBattery110vDc.FindAsync(id);
            _context.LookUpNiCdBattery110vDc.Remove(lookUpNiCdBattery110vDc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpNiCdBattery110vDcExists(int id)
        {
            return _context.LookUpNiCdBattery110vDc.Any(e => e.NiCdBattery110vDcId == id);
        }
    }
}
