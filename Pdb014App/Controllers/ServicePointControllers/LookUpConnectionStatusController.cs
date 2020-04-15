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
    public class LookUpConnectionStatusController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpConnectionStatusController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpConnectionStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpConnectionStatus.ToListAsync());
        }

        // GET: LookUpConnectionStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConnectionStatus = await _context.LookUpConnectionStatus
                .FirstOrDefaultAsync(m => m.ConnectionStatusId == id);
            if (lookUpConnectionStatus == null)
            {
                return NotFound();
            }

            return View(lookUpConnectionStatus);
        }

        // GET: LookUpConnectionStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpConnectionStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConnectionStatusId,ConnectionStatusName")] LookUpConnectionStatus lookUpConnectionStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpConnectionStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpConnectionStatus);
        }

        // GET: LookUpConnectionStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConnectionStatus = await _context.LookUpConnectionStatus.FindAsync(id);
            if (lookUpConnectionStatus == null)
            {
                return NotFound();
            }
            return View(lookUpConnectionStatus);
        }

        // POST: LookUpConnectionStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConnectionStatusId,ConnectionStatusName")] LookUpConnectionStatus lookUpConnectionStatus)
        {
            if (id != lookUpConnectionStatus.ConnectionStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpConnectionStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpConnectionStatusExists(lookUpConnectionStatus.ConnectionStatusId))
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
            return View(lookUpConnectionStatus);
        }

        // GET: LookUpConnectionStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpConnectionStatus = await _context.LookUpConnectionStatus
                .FirstOrDefaultAsync(m => m.ConnectionStatusId == id);
            if (lookUpConnectionStatus == null)
            {
                return NotFound();
            }

            return View(lookUpConnectionStatus);
        }

        // POST: LookUpConnectionStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpConnectionStatus = await _context.LookUpConnectionStatus.FindAsync(id);
            _context.LookUpConnectionStatus.Remove(lookUpConnectionStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpConnectionStatusExists(int id)
        {
            return _context.LookUpConnectionStatus.Any(e => e.ConnectionStatusId == id);
        }
    }
}
