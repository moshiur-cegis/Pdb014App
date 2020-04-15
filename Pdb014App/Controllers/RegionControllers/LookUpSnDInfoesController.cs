using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.LookUpModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.RegionControllers
{
    public class LookUpSnDInfoesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpSnDInfoesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpSnDInfoes
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.LookUpSnDInfo.Include(l => l.CircleInfo);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: LookUpSnDInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSnDInfo = await _context.LookUpSnDInfo
                .Include(l => l.CircleInfo)
                .FirstOrDefaultAsync(m => m.SnDCode == id);
            if (lookUpSnDInfo == null)
            {
                return NotFound();
            }

            return View(lookUpSnDInfo);
        }


        [HttpPost]
        public JsonResult GetSnDList(string circleCode)
        {
            var sndList = _context.LookUpSnDInfo
                .Where(sd => string.IsNullOrEmpty(circleCode) || sd.CircleCode.Equals(circleCode))
                .Select(sd => new { sd.SnDCode, sd.SnDName })
                .OrderBy(sd => sd.SnDCode).ToList();

            return Json(new SelectList(sndList, "SnDCode", "SnDName"));
        }

        // GET: LookUpSnDInfoes/Create
        public IActionResult Create()
        {
            ViewData["CircleCode"] = new SelectList(_context.LookUpCircleInfo, "CircleCode", "CircleName");
            return View();
        }

        // POST: LookUpSnDInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SnDCode,SnDName,SortingNo,CircleCode")] LookUpSnDInfo lookUpSnDInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpSnDInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CircleCode"] = new SelectList(_context.LookUpCircleInfo, "CircleCode", "CircleName", lookUpSnDInfo.CircleCode);
            return View(lookUpSnDInfo);
        }

        // GET: LookUpSnDInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSnDInfo = await _context.LookUpSnDInfo.FindAsync(id);
            if (lookUpSnDInfo == null)
            {
                return NotFound();
            }
            ViewData["CircleCode"] = new SelectList(_context.LookUpCircleInfo, "CircleCode", "CircleName", lookUpSnDInfo.CircleCode);
            return View(lookUpSnDInfo);
        }

        // POST: LookUpSnDInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SnDCode,SnDName,SortingNo,CircleCode")] LookUpSnDInfo lookUpSnDInfo)
        {
            if (id != lookUpSnDInfo.SnDCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpSnDInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpSnDInfoExists(lookUpSnDInfo.SnDCode))
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
            ViewData["CircleCode"] = new SelectList(_context.LookUpCircleInfo, "CircleCode", "CircleName", lookUpSnDInfo.CircleCode);
            return View(lookUpSnDInfo);
        }

        // GET: LookUpSnDInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpSnDInfo = await _context.LookUpSnDInfo
                .Include(l => l.CircleInfo)
                .FirstOrDefaultAsync(m => m.SnDCode == id);
            if (lookUpSnDInfo == null)
            {
                return NotFound();
            }

            return View(lookUpSnDInfo);
        }

        // POST: LookUpSnDInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lookUpSnDInfo = await _context.LookUpSnDInfo.FindAsync(id);
            _context.LookUpSnDInfo.Remove(lookUpSnDInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpSnDInfoExists(string id)
        {
            return _context.LookUpSnDInfo.Any(e => e.SnDCode == id);
        }
    }
}
