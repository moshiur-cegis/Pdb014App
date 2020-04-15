using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.ServicePointModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.ServicePointControllers
{
    public class TblServicePointsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblServicePointsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblServicePoints
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblServicePoint.Include(t => t.ServicePointToPole).Include(t => t.ServicePointType).Include(t => t.VoltageCategory);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblServicePoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServicePoint = await _context.TblServicePoint
                .Include(t => t.ServicePointToPole)
                .Include(t => t.ServicePointType)
                .Include(t => t.VoltageCategory)
                .FirstOrDefaultAsync(m => m.ServicePointId == id);
            if (tblServicePoint == null)
            {
                return NotFound();
            }

            return View(tblServicePoint);
        }

        // GET: TblServicePoints/Create
        public IActionResult Create()
        {
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["ServicePointTypeId"] = new SelectList(_context.LookUpServicePointType, "ServicePointTypeId", "ServicePointTypeName");
            ViewData["VoltageCategoryId"] = new SelectList(_context.LookUpVoltageCategory, "VoltageCategoryId", "VoltageCategoryName");
            return View();
        }

        // POST: TblServicePoints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicePointId,PoleId,VoltageCategoryId,TransformerNumber,ServicePointTypeId,AggregateLoadkw,NoOFConsumersR,NoOFConsumersY,NoOFConsumersB,NoOfConsumersRyb,RoadName,VillageOrAreaName,Ward,CityTown,PrimaryLandmark")] TblServicePoint tblServicePoint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblServicePoint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblServicePoint.PoleId);
            ViewData["ServicePointTypeId"] = new SelectList(_context.LookUpServicePointType, "ServicePointTypeId", "ServicePointTypeName", tblServicePoint.ServicePointTypeId);
            ViewData["VoltageCategoryId"] = new SelectList(_context.LookUpVoltageCategory, "VoltageCategoryId", "VoltageCategoryName", tblServicePoint.VoltageCategoryId);
            return View(tblServicePoint);
        }

        // GET: TblServicePoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServicePoint = await _context.TblServicePoint.FindAsync(id);
            if (tblServicePoint == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblServicePoint.PoleId);
            ViewData["ServicePointTypeId"] = new SelectList(_context.LookUpServicePointType, "ServicePointTypeId", "ServicePointTypeName", tblServicePoint.ServicePointTypeId);
            ViewData["VoltageCategoryId"] = new SelectList(_context.LookUpVoltageCategory, "VoltageCategoryId", "VoltageCategoryName", tblServicePoint.VoltageCategoryId);
            return View(tblServicePoint);
        }

        // POST: TblServicePoints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicePointId,PoleId,VoltageCategoryId,TransformerNumber,ServicePointTypeId,AggregateLoadkw,NoOFConsumersR,NoOFConsumersY,NoOFConsumersB,NoOfConsumersRyb,RoadName,VillageOrAreaName,Ward,CityTown,PrimaryLandmark")] TblServicePoint tblServicePoint)
        {
            if (id != tblServicePoint.ServicePointId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblServicePoint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblServicePointExists(tblServicePoint.ServicePointId))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblServicePoint.PoleId);
            ViewData["ServicePointTypeId"] = new SelectList(_context.LookUpServicePointType, "ServicePointTypeId", "ServicePointTypeName", tblServicePoint.ServicePointTypeId);
            ViewData["VoltageCategoryId"] = new SelectList(_context.LookUpVoltageCategory, "VoltageCategoryId", "VoltageCategoryName", tblServicePoint.VoltageCategoryId);
            return View(tblServicePoint);
        }

        // GET: TblServicePoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServicePoint = await _context.TblServicePoint
                .Include(t => t.ServicePointToPole)
                .Include(t => t.ServicePointType)
                .Include(t => t.VoltageCategory)
                .FirstOrDefaultAsync(m => m.ServicePointId == id);
            if (tblServicePoint == null)
            {
                return NotFound();
            }

            return View(tblServicePoint);
        }

        // POST: TblServicePoints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblServicePoint = await _context.TblServicePoint.FindAsync(id);
            _context.TblServicePoint.Remove(tblServicePoint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblServicePointExists(int id)
        {
            return _context.TblServicePoint.Any(e => e.ServicePointId == id);
        }
    }
}
