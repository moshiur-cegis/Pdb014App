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
    public class TblSubstationsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblSubstationsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblSubstations
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblSubstation.Include(t => t.SubstationType).Include(t => t.SubstationToLookUpSnD);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblSubstations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubstation = await _context.TblSubstation
                .Include(t => t.SubstationType)
                .Include(t => t.SubstationToLookUpSnD)
                .FirstOrDefaultAsync(m => m.SubstationId == id);
            if (tblSubstation == null)
            {
                return NotFound();
            }

            return View(tblSubstation);
        }

        // GET: TblSubstations/Create
        public IActionResult Create()
        {
            var SubstationTypeInfoes = _context.LookUpSubstationType.Select(agn =>
                new { Code = agn.SubstationTypeId, Name = agn.SubstationTypeId + " : " + agn.SubstationTypeName });

            ViewData["SubstationTypeId"] = new SelectList(SubstationTypeInfoes, "Code", "Name");


            //ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode");
            var SnDInfoes = _context.LookUpSnDInfo.Select(agn =>
                new { Code = agn.SnDCode, Name = agn.SnDCode + " : " + agn.SnDName });

            ViewData["SnDCode"] = new SelectList(SnDInfoes, "Code", "Name");
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View();
        }

        // POST: TblSubstations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubstationId,SubstationTypeId,SubstationName,SnDCode,NominalVoltage,InstalledCapacity,MaximumDemand,PeakLoad,Location,AreaOfSubstation,Latitude,Longitude,YearOfComissioning")] TblSubstation tblSubstation)
        {

            //if (tblSubstation.IsEmpty() != "")
            //{
            //    ViewData["Error"] = tblSubstation.IsEmpty();
            //    return Redirect("Create");

            //}

            //try
            //{

                if (ModelState.IsValid)
                {
                    _context.Add(tblSubstation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            //}
            //catch (Exception e)
            //{
            //    ViewData["Error"]= e;
            //    throw;
            //}

            //ViewData["SubstationTypeId"] = new SelectList(_context.LookUpSubstationType, "SubstationTypeId", "SubstationTypeName", tblSubstation.SubstationTypeId);
            //ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblSubstation.SnDCode);

            var SubstationTypeInfoes = _context.LookUpSubstationType.Select(agn =>
                new { Code = agn.SubstationTypeId, Name = agn.SubstationTypeId + " : " + agn.SubstationTypeName });

            ViewData["SubstationTypeId"] = new SelectList(SubstationTypeInfoes, "Code", "Name");


            //ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode");
            var SnDInfoes = _context.LookUpSnDInfo.Select(agn =>
                new { Code = agn.SnDCode, Name = agn.SnDCode + " : " + agn.SnDName });

            ViewData["SnDCode"] = new SelectList(SnDInfoes, "Code", "Name");
            return View(tblSubstation);
        }

        // GET: TblSubstations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubstation = await _context.TblSubstation.FindAsync(id);
            if (tblSubstation == null)
            {
                return NotFound();
            }
            ViewData["SubstationTypeId"] = new SelectList(_context.LookUpSubstationType, "SubstationTypeId", "SubstationTypeName", tblSubstation.SubstationTypeId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDName", tblSubstation.SnDCode);
            return View(tblSubstation);
        }

        // POST: TblSubstations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SubstationId,SubstationTypeId,SubstationName,SnDCode,NominalVoltage,InstalledCapacity,MaximumDemand,PeakLoad,Location,AreaOfSubstation,Latitude,Longitude,YearOfComissioning")] TblSubstation tblSubstation)
        {
            if (id != tblSubstation.SubstationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSubstation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSubstationExists(tblSubstation.SubstationId))
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
            ViewData["SubstationTypeId"] = new SelectList(_context.LookUpSubstationType, "SubstationTypeId", "SubstationTypeId", tblSubstation.SubstationTypeId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblSubstation.SnDCode);
            return View(tblSubstation);
        }

        // GET: TblSubstations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubstation = await _context.TblSubstation
                .Include(t => t.SubstationType)
                .Include(t => t.SubstationToLookUpSnD)
                .FirstOrDefaultAsync(m => m.SubstationId == id);
            if (tblSubstation == null)
            {
                return NotFound();
            }

            return View(tblSubstation);
        }

        // POST: TblSubstations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblSubstation = await _context.TblSubstation.FindAsync(id);
            _context.TblSubstation.Remove(tblSubstation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSubstationExists(string id)
        {
            return _context.TblSubstation.Any(e => e.SubstationId == id);
        }
        public JsonResult GetCircleList(string zoneCode)
        {
            var circleList = _context.LookUpCircleInfo
                .Where(u => u.ZoneCode.Equals(zoneCode))
                .Select(u => new { u.CircleCode, u.CircleName })
                .OrderBy(u => u.CircleCode).ToList();

            return Json(new SelectList(circleList, "CircleCode", "CircleName"));
        }

        public JsonResult GetSnDList(string circleCode)
        {
            var sndList = _context.LookUpSnDInfo
                .Where(u => u.CircleCode.Equals(circleCode))
                .Select(u => new { u.SnDCode, u.SnDName })
                .OrderBy(u => u.SnDCode).ToList();

            return Json(new SelectList(sndList, "SnDCode", "SnDName"));
        }

        public JsonResult GetSubStationList(string sndCode)
        {
            var substationList = _context.TblSubstation
                .Where(u => u.SnDCode.Equals(sndCode))
                .Select(u => new { u.SubstationId, u.SubstationName })
                .OrderBy(u => u.SubstationId).ToList();

            return Json(new SelectList(substationList, "SubstationId", "SubstationName"));
        }
    }
}
