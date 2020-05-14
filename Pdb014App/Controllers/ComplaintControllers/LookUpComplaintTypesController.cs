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
    public class LookUpComplaintTypesController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpComplaintTypesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpComplaintTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComplaintTypes.ToListAsync());
        }

        // GET: LookUpComplaintTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplaintType = await _context.ComplaintTypes
                .FirstOrDefaultAsync(m => m.ComplaintTypeId == id);
            if (lookUpComplaintType == null)
            {
                return NotFound();
            }

            return View(lookUpComplaintType);
        }

        // GET: LookUpComplaintTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpComplaintTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplaintTypeId,ComplaintType")] LookUpComplaintType lookUpComplaintType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpComplaintType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpComplaintType);
        }

        // GET: LookUpComplaintTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplaintType = await _context.ComplaintTypes.FindAsync(id);
            if (lookUpComplaintType == null)
            {
                return NotFound();
            }
            return View(lookUpComplaintType);
        }

        // POST: LookUpComplaintTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComplaintTypeId,ComplaintType")] LookUpComplaintType lookUpComplaintType)
        {
            if (id != lookUpComplaintType.ComplaintTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpComplaintType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpComplaintTypeExists(lookUpComplaintType.ComplaintTypeId))
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
            return View(lookUpComplaintType);
        }

        // GET: LookUpComplaintTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpComplaintType = await _context.ComplaintTypes
                .FirstOrDefaultAsync(m => m.ComplaintTypeId == id);
            if (lookUpComplaintType == null)
            {
                return NotFound();
            }

            return View(lookUpComplaintType);
        }

        // POST: LookUpComplaintTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpComplaintType = await _context.ComplaintTypes.FindAsync(id);
            _context.ComplaintTypes.Remove(lookUpComplaintType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpComplaintTypeExists(int id)
        {
            return _context.ComplaintTypes.Any(e => e.ComplaintTypeId == id);
        }
    }
}
