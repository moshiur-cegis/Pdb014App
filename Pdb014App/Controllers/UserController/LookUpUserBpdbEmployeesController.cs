using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.UserManage;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.UserController
{
    public class LookUpUserBpdbEmployeesController : Controller
    {
        private readonly UserDbContext _context;
        private readonly PdbDbContext _contextPDB;

        public LookUpUserBpdbEmployeesController(UserDbContext context, PdbDbContext _contextPDB)
        {
            _context = context;
            this._contextPDB = _contextPDB;
        }

        // GET: LookUpUserBpdbEmployees
        public async Task<IActionResult> Index()
        {
            var userDbContext = _context.UserBpdbEmployee.Include(l => l.UserBpdbEmployeeUserBpdbDivision);
            return View(await userDbContext.ToListAsync());
        }

        // GET: LookUpUserBpdbEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserBpdbEmployee = await _context.UserBpdbEmployee
                .Include(l => l.UserBpdbEmployeeUserBpdbDivision)
                .FirstOrDefaultAsync(m => m.BpdbEmployeeId == id);
            if (lookUpUserBpdbEmployee == null)
            {
                return NotFound();
            }

            return View(lookUpUserBpdbEmployee);
        }

        // GET: LookUpUserBpdbEmployees/Create
        public IActionResult Create()
        {
            ViewData["BpdbDivisionId"] = new SelectList(_context.UserBpdbDivision, "BpdbDivisionId", "BpdbDivisionName");
            ViewData["ZoneCode"] = new SelectList(_contextPDB.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View();
        }

        // POST: LookUpUserBpdbEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BpdbEmployeeId,BpdbEmployeeLevel,BpdbDivisionId,BpdbEmpDesignation,ZoneCode,CircleCode,SnDCode,SubstationId")] LookUpUserBpdbEmployee lookUpUserBpdbEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpUserBpdbEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BpdbDivisionId"] = new SelectList(_context.UserBpdbDivision, "BpdbDivisionId", "BpdbDivisionName", lookUpUserBpdbEmployee.BpdbDivisionId);
            ViewData["ZoneCode"] = new SelectList(_contextPDB.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View(lookUpUserBpdbEmployee);
        }

        // GET: LookUpUserBpdbEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserBpdbEmployee = await _context.UserBpdbEmployee.FindAsync(id);
            if (lookUpUserBpdbEmployee == null)
            {
                return NotFound();
            }
            ViewData["BpdbDivisionId"] = new SelectList(_context.UserBpdbDivision, "BpdbDivisionId", "BpdbDivisionName", lookUpUserBpdbEmployee.BpdbDivisionId);
            return View(lookUpUserBpdbEmployee);
        }

        // POST: LookUpUserBpdbEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BpdbEmployeeId,BpdbEmployeeLevel,BpdbDivisionId,BpdbEmpDesignation,ZoneCode,CircleCode,SnDCode,SubstationId")] LookUpUserBpdbEmployee lookUpUserBpdbEmployee)
        {
            if (id != lookUpUserBpdbEmployee.BpdbEmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpUserBpdbEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpUserBpdbEmployeeExists(lookUpUserBpdbEmployee.BpdbEmployeeId))
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
            ViewData["BpdbDivisionId"] = new SelectList(_context.UserBpdbDivision, "BpdbDivisionId", "BpdbDivisionName", lookUpUserBpdbEmployee.BpdbDivisionId);
            return View(lookUpUserBpdbEmployee);
        }

        // GET: LookUpUserBpdbEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserBpdbEmployee = await _context.UserBpdbEmployee
                .Include(l => l.UserBpdbEmployeeUserBpdbDivision)
                .FirstOrDefaultAsync(m => m.BpdbEmployeeId == id);
            if (lookUpUserBpdbEmployee == null)
            {
                return NotFound();
            }

            return View(lookUpUserBpdbEmployee);
        }

        // POST: LookUpUserBpdbEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpUserBpdbEmployee = await _context.UserBpdbEmployee.FindAsync(id);
            _context.UserBpdbEmployee.Remove(lookUpUserBpdbEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpUserBpdbEmployeeExists(int id)
        {
            return _context.UserBpdbEmployee.Any(e => e.BpdbEmployeeId == id);
        }

        public JsonResult GetCircleList(string zoneCode)
        {
            var circleList = _contextPDB.LookUpCircleInfo
                .Where(u => u.ZoneCode.Equals(zoneCode))
                .Select(u => new { u.CircleCode, u.CircleName })
                .OrderBy(u => u.CircleCode).ToList();

            return Json(new SelectList(circleList, "CircleCode", "CircleName"));
        }

        public JsonResult GetSnDList(string circleCode)
        {
            var sndList = _contextPDB.LookUpSnDInfo
                .Where(u => u.CircleCode.Equals(circleCode))
                .Select(u => new { u.SnDCode, u.SnDName })
                .OrderBy(u => u.SnDCode).ToList();

            return Json(new SelectList(sndList, "SnDCode", "SnDName"));
        }

        public JsonResult GetSubStationList(string sndCode)
        {
            var substationList = _contextPDB.TblSubstation
                .Where(u => u.SnDCode.Equals(sndCode))
                .Select(u => new { u.SubstationId, u.SubstationName })
                .OrderBy(u => u.SubstationId).ToList();

            return Json(new SelectList(substationList, "SubstationId", "SubstationName"));
        }
    }
}
