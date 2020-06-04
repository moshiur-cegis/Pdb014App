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
    public class TblCrossArmInfoesController : Controller
    {
        private readonly PdbDbContext _context;

        public TblCrossArmInfoesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblCrossArmInfoes
        public async Task<IActionResult> Index(string id)
        {

            var pdbDbContext = _context.TblCrossArmInfo.Include(t => t.CrossArmToPole).Include(t => t.FittingsLookUpCondition).Include(t => t.LookUpTypeOfFittings);
            if (id != null)
            {
                pdbDbContext = _context.TblCrossArmInfo.Where(i => i.PoleId == id).Include(t => t.CrossArmToPole).Include(t => t.FittingsLookUpCondition).Include(t => t.LookUpTypeOfFittings);
            }
            return PartialView(await pdbDbContext.ToListAsync());
        }


        // GET: TblCrossArmInfoes
        public async Task<IActionResult> CrossArmList(string poleId, int isShowLayout = 0, int isShowAction = 0)
        {
            //ViewBag.PoleId = poleId;
            ViewBag.IsShowLayout = isShowLayout;
            ViewBag.IsShowAction = isShowAction;

            var crossArmList = _context.TblCrossArmInfo
                .Include(t => t.CrossArmToPole)
                .Include(t => t.FittingsLookUpCondition)
                .Include(t => t.LookUpTypeOfFittings)
                .AsNoTracking();

            if (poleId != null)
            {
                crossArmList = crossArmList.Where(p => p.PoleId == poleId);
            }

            return View(await crossArmList.ToListAsync());
        }

        public async Task<IActionResult> IndexPartialView(string poleId)
        {
            var pdbDbContext = _context.TblCrossArmInfo.Include(t => t.CrossArmToPole).Include(t => t.FittingsLookUpCondition).Include(t => t.LookUpTypeOfFittings);
            if (poleId != null)
            {
                pdbDbContext = _context.TblCrossArmInfo.Where(i => i.PoleId == poleId).Include(t => t.CrossArmToPole).Include(t => t.FittingsLookUpCondition).Include(t => t.LookUpTypeOfFittings);
            }
            return PartialView(await pdbDbContext.ToListAsync());
        }

        // GET: TblCrossArmInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCrossArmInfo = await _context.TblCrossArmInfo
                .Include(ca => ca.CrossArmToPole)
                .Include(ca => ca.FittingsLookUpCondition)
                .Include(ca => ca.LookUpTypeOfFittings)
                .Include(ca => ca.CrossArmToPole.PoleToRoute)
                .Include(ca => ca.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(ca => ca.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .FirstOrDefaultAsync(m => m.CrossArmId == id);

            if (tblCrossArmInfo == null)
            {
                return NotFound();
            }

            return View(tblCrossArmInfo);
        }

        // GET: TblCrossArmInfoes/Create
        public IActionResult Create()
        {

            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["FittingsConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");
            ViewData["TypeOfFittingsId"] = new SelectList(_context.LookUpTypeOfFittings, "Code", "Name");
            return View();
        }

        // POST: TblCrossArmInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CrossArmId,Materials,Type,Standard,UltimateTensileStrength,TypeOfFittingsId,NoOfSetFittings,FittingsConditionId,PoleId")] TblCrossArmInfo tblCrossArmInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCrossArmInfo);
                await _context.SaveChangesAsync();

                TempData["statuMessageSuccess"] = "Cross Arm has been Added Successfully under pole id: " + tblCrossArmInfo.PoleId;
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "TblPoles");
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblCrossArmInfo.PoleId);
            ViewData["FittingsConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblCrossArmInfo.FittingsConditionId);
            ViewData["TypeOfFittingsId"] = new SelectList(_context.LookUpTypeOfFittings, "Code", "Name", tblCrossArmInfo.TypeOfFittingsId);



            return View(tblCrossArmInfo);

        }

        // GET: TblCrossArmInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCrossArmInfo = await _context.TblCrossArmInfo.FindAsync(id);
            if (tblCrossArmInfo == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblCrossArmInfo.PoleId);
            ViewData["FittingsConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblCrossArmInfo.FittingsConditionId);
            ViewData["TypeOfFittingsId"] = new SelectList(_context.LookUpTypeOfFittings, "Code", "Name", tblCrossArmInfo.TypeOfFittingsId);
            return View(tblCrossArmInfo);
        }

        // POST: TblCrossArmInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CrossArmId,Materials,Type,Standard,UltimateTensileStrength,TypeOfFittingsId,NoOfSetFittings,FittingsConditionId,PoleId")] TblCrossArmInfo tblCrossArmInfo)
        {
            if (id != tblCrossArmInfo.CrossArmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCrossArmInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCrossArmInfoExists(tblCrossArmInfo.CrossArmId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["statuMessageSuccess"] = "Cross Arm has been Updated Successfully under pole id: " + tblCrossArmInfo.PoleId;
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "TblPoles");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblCrossArmInfo.PoleId);
            ViewData["FittingsConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name", tblCrossArmInfo.FittingsConditionId);
            ViewData["TypeOfFittingsId"] = new SelectList(_context.LookUpTypeOfFittings, "Code", "Name", tblCrossArmInfo.TypeOfFittingsId);
            return View(tblCrossArmInfo);
        }

        // GET: TblCrossArmInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCrossArmInfo = await _context.TblCrossArmInfo
                .Include(t => t.CrossArmToPole)
                .Include(t => t.FittingsLookUpCondition)
                .Include(t => t.LookUpTypeOfFittings)
                .FirstOrDefaultAsync(m => m.CrossArmId == id);
            if (tblCrossArmInfo == null)
            {
                return NotFound();
            }

            return View(tblCrossArmInfo);
        }

        // POST: TblCrossArmInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCrossArmInfo = await _context.TblCrossArmInfo.FindAsync(id);
            _context.TblCrossArmInfo.Remove(tblCrossArmInfo);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            TempData["statuMessageSuccess"] = "Cross Arm has been Deleted Successfully under pole id: " + tblCrossArmInfo.PoleId;

            return RedirectToAction("Index", "TblPoles");
        }

        private bool TblCrossArmInfoExists(int id)
        {
            return _context.TblCrossArmInfo.Any(e => e.CrossArmId == id);
        }
    }
}
