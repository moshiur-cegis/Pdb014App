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
    public class LookUpUserBpdbDivisionsController : Controller
    {
        private readonly UserDbContext _context;

        public LookUpUserBpdbDivisionsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: LookUpUserBpdbDivisions
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserBpdbDivision.ToListAsync());
        }

        // GET: LookUpUserBpdbDivisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserBpdbDivision = await _context.UserBpdbDivision
                .FirstOrDefaultAsync(m => m.BpdbDivisionId == id);
            if (lookUpUserBpdbDivision == null)
            {
                return NotFound();
            }

            return View(lookUpUserBpdbDivision);
        }

        // GET: LookUpUserBpdbDivisions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpUserBpdbDivisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BpdbDivisionId,BpdbDivisionName")] LookUpUserBpdbDivision lookUpUserBpdbDivision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpUserBpdbDivision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpUserBpdbDivision);
        }

        // GET: LookUpUserBpdbDivisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserBpdbDivision = await _context.UserBpdbDivision.FindAsync(id);
            if (lookUpUserBpdbDivision == null)
            {
                return NotFound();
            }
            return View(lookUpUserBpdbDivision);
        }

        // POST: LookUpUserBpdbDivisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BpdbDivisionId,BpdbDivisionName")] LookUpUserBpdbDivision lookUpUserBpdbDivision)
        {
            if (id != lookUpUserBpdbDivision.BpdbDivisionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpUserBpdbDivision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpUserBpdbDivisionExists(lookUpUserBpdbDivision.BpdbDivisionId))
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
            return View(lookUpUserBpdbDivision);
        }

        // GET: LookUpUserBpdbDivisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserBpdbDivision = await _context.UserBpdbDivision
                .FirstOrDefaultAsync(m => m.BpdbDivisionId == id);
            if (lookUpUserBpdbDivision == null)
            {
                return NotFound();
            }

            return View(lookUpUserBpdbDivision);
        }

        // POST: LookUpUserBpdbDivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpUserBpdbDivision = await _context.UserBpdbDivision.FindAsync(id);
            _context.UserBpdbDivision.Remove(lookUpUserBpdbDivision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpUserBpdbDivisionExists(int id)
        {
            return _context.UserBpdbDivision.Any(e => e.BpdbDivisionId == id);
        }
    }
}
