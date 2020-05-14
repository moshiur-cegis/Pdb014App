using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB;
using Pdb014App.Repository;


namespace Pdb014App.Controllers.ComplaintControllers
{
    public class LookUpComplaintStatusController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpComplaintStatusController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpComplaintStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComplaintStatus.ToListAsync());
        }

        // GET: LookUpComplaintStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplaintStatus = await _context.ComplaintStatus
                .FirstOrDefaultAsync(m => m.ComplaintStatusId == id);
            if (lookUpComplaintStatus == null)
            {
                return NotFound();
            }

            return View(lookUpComplaintStatus);
        }

        // GET: LookUpComplaintStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpComplaintStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplaintStatusId,ComplaintStatus")] LookUpComplaintStatus lookUpComplaintStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpComplaintStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpComplaintStatus);
        }

        // GET: LookUpComplaintStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplaintStatus = await _context.ComplaintStatus.FindAsync(id);
            if (lookUpComplaintStatus == null)
            {
                return NotFound();
            }
            return View(lookUpComplaintStatus);
        }

        // POST: LookUpComplaintStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComplaintStatusId,ComplaintStatus")] LookUpComplaintStatus lookUpComplaintStatus)
        {
            if (id != lookUpComplaintStatus.ComplaintStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpComplaintStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpComplaintStatusExists(lookUpComplaintStatus.ComplaintStatusId))
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
            return View(lookUpComplaintStatus);
        }

        // GET: LookUpComplaintStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplaintStatus = await _context.ComplaintStatus
                .FirstOrDefaultAsync(m => m.ComplaintStatusId == id);
            if (lookUpComplaintStatus == null)
            {
                return NotFound();
            }

            return View(lookUpComplaintStatus);
        }

        // POST: LookUpComplaintStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpComplaintStatus = await _context.ComplaintStatus.FindAsync(id);
            _context.ComplaintStatus.Remove(lookUpComplaintStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpComplaintStatusExists(int id)
        {
            return _context.ComplaintStatus.Any(e => e.ComplaintStatusId == id);
        }
    }
}
