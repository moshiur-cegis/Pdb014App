using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.PoleModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.PoleControllers
{
    public class TblPoleMountedDofCutOutFuseLinksController : Controller
    {
        private readonly PdbDbContext _context;

        public TblPoleMountedDofCutOutFuseLinksController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblPoleMountedDofCutOutFuseLinks
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblPoleMountedDofCutOutFuseLink.Include(t => t.PoleMountedDofCutOutFuseLinkToPole);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblPoleMountedDofCutOutFuseLinks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleMountedDofCutOutFuseLink = await _context.TblPoleMountedDofCutOutFuseLink
                .Include(t => t.PoleMountedDofCutOutFuseLinkToPole)
                .FirstOrDefaultAsync(m => m.PoleMountedDofCutOutFuseLinkId == id);
            if (tblPoleMountedDofCutOutFuseLink == null)
            {
                return NotFound();
            }

            return View(tblPoleMountedDofCutOutFuseLink);
        }

        // GET: TblPoleMountedDofCutOutFuseLinks/Create
        public IActionResult Create()
        {
            var poleIdList = _context.TblPole.AsNoTracking()
                .Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList();
            ViewData["PoleId"] = poleIdList;

            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            return View();
        }

        // POST: TblPoleMountedDofCutOutFuseLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoleMountedDofCutOutFuseLinkId,Standard,General,Installation,TypeorModel,Construction,Application,NominalRatedVoltage,MaximumSystemVoltage,SystemFrequency,TypeofSystem,ContinuousCurrentRating,InterruptingCapacityoftheCutOutMin,FuseHolderType,FuseLinkRatedCurrentContinuous,BasicInsulationLevelBIL,FuseLinkType,PoleId")] TblPoleMountedDofCutOutFuseLink tblPoleMountedDofCutOutFuseLink)
        {


            string fuseLinkId= tblPoleMountedDofCutOutFuseLink.PoleId;

            bool has = _context.TblPoleMountedDofCutOutFuseLink.Any(cus => cus.PoleMountedDofCutOutFuseLinkId == tblPoleMountedDofCutOutFuseLink.PoleId+"_1");

            if (has)
            {
                tblPoleMountedDofCutOutFuseLink.PoleMountedDofCutOutFuseLinkId = fuseLinkId+"_2";
                has = _context.TblPoleMountedDofCutOutFuseLink.Any(cus => cus.PoleMountedDofCutOutFuseLinkId == tblPoleMountedDofCutOutFuseLink.PoleId);
                if (has)
                {
                    tblPoleMountedDofCutOutFuseLink.PoleMountedDofCutOutFuseLinkId = fuseLinkId+"_3";
                }
            }
            else
            {
                tblPoleMountedDofCutOutFuseLink.PoleMountedDofCutOutFuseLinkId = fuseLinkId+"_1";
            }

           
            if (ModelState.IsValid)
            {
                _context.Add(tblPoleMountedDofCutOutFuseLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleMountedDofCutOutFuseLink.PoleId);
            return View(tblPoleMountedDofCutOutFuseLink);
        }

        // GET: TblPoleMountedDofCutOutFuseLinks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleMountedDofCutOutFuseLink = await _context.TblPoleMountedDofCutOutFuseLink.FindAsync(id);
            if (tblPoleMountedDofCutOutFuseLink == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleMountedDofCutOutFuseLink.PoleId);
            return View(tblPoleMountedDofCutOutFuseLink);
        }

        // POST: TblPoleMountedDofCutOutFuseLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PoleMountedDofCutOutFuseLinkId,Standard,General,Installation,TypeorModel,Construction,Application,NominalRatedVoltage,MaximumSystemVoltage,SystemFrequency,TypeofSystem,ContinuousCurrentRating,InterruptingCapacityoftheCutOutMin,FuseHolderType,FuseLinkRatedCurrentContinuous,BasicInsulationLevelBIL,FuseLinkType,PoleId")] TblPoleMountedDofCutOutFuseLink tblPoleMountedDofCutOutFuseLink)
        {
            if (id != tblPoleMountedDofCutOutFuseLink.PoleMountedDofCutOutFuseLinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPoleMountedDofCutOutFuseLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPoleMountedDofCutOutFuseLinkExists(tblPoleMountedDofCutOutFuseLink.PoleMountedDofCutOutFuseLinkId))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPoleMountedDofCutOutFuseLink.PoleId);
            return View(tblPoleMountedDofCutOutFuseLink);
        }

        // GET: TblPoleMountedDofCutOutFuseLinks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoleMountedDofCutOutFuseLink = await _context.TblPoleMountedDofCutOutFuseLink
                .Include(t => t.PoleMountedDofCutOutFuseLinkToPole)
                .FirstOrDefaultAsync(m => m.PoleMountedDofCutOutFuseLinkId == id);
            if (tblPoleMountedDofCutOutFuseLink == null)
            {
                return NotFound();
            }

            return View(tblPoleMountedDofCutOutFuseLink);
        }

        // POST: TblPoleMountedDofCutOutFuseLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblPoleMountedDofCutOutFuseLink = await _context.TblPoleMountedDofCutOutFuseLink.FindAsync(id);
            _context.TblPoleMountedDofCutOutFuseLink.Remove(tblPoleMountedDofCutOutFuseLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPoleMountedDofCutOutFuseLinkExists(string id)
        {
            return _context.TblPoleMountedDofCutOutFuseLink.Any(e => e.PoleMountedDofCutOutFuseLinkId == id);
        }
    }
}
