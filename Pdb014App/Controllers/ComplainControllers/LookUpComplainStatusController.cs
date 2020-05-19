using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB;
using Pdb014App.Repository;


namespace Pdb014App.Controllers.ComplainControllers
{
    public class LookUpComplainStatusController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpComplainStatusController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpComplainStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComplainStatus.ToListAsync());
        }

        // GET: LookUpComplainStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplainStatus = await _context.ComplainStatus
                .FirstOrDefaultAsync(m => m.ComplainStatusId == id);
            if (lookUpComplainStatus == null)
            {
                return NotFound();
            }

            return View(lookUpComplainStatus);
        }

        // GET: LookUpComplainStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpComplainStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplainStatusId,ComplainStatus")] LookUpComplainStatus lookUpComplainStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpComplainStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpComplainStatus);
        }

        // GET: LookUpComplainStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplainStatus = await _context.ComplainStatus.FindAsync(id);
            if (lookUpComplainStatus == null)
            {
                return NotFound();
            }
            return View(lookUpComplainStatus);
        }

        // POST: LookUpComplainStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComplainStatusId,ComplainStatus")] LookUpComplainStatus lookUpComplainStatus)
        {
            if (id != lookUpComplainStatus.ComplainStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpComplainStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpComplainStatusExists(lookUpComplainStatus.ComplainStatusId))
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
            return View(lookUpComplainStatus);
        }

        // GET: LookUpComplainStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplainStatus = await _context.ComplainStatus
                .FirstOrDefaultAsync(m => m.ComplainStatusId == id);
            if (lookUpComplainStatus == null)
            {
                return NotFound();
            }

            return View(lookUpComplainStatus);
        }

        // POST: LookUpComplainStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpComplainStatus = await _context.ComplainStatus.FindAsync(id);
            _context.ComplainStatus.Remove(lookUpComplainStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpComplainStatusExists(int id)
        {
            return _context.ComplainStatus.Any(e => e.ComplainStatusId == id);
        }
    }
}
