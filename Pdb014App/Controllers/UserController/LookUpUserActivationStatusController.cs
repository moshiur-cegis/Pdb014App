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
    public class LookUpUserActivationStatusController : Controller
    {
        private readonly UserDbContext _context;

        public LookUpUserActivationStatusController(UserDbContext context)
        {
            _context = context;
        }

        // GET: LookUpUserActivationStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserActivationStatus.ToListAsync());
        }

        // GET: LookUpUserActivationStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserActivationStatus = await _context.UserActivationStatus
                .FirstOrDefaultAsync(m => m.UserActivationStatusId == id);
            if (lookUpUserActivationStatus == null)
            {
                return NotFound();
            }

            return View(lookUpUserActivationStatus);
        }

        // GET: LookUpUserActivationStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpUserActivationStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserActivationStatusId,UserActivationStatus")] LookUpUserActivationStatus lookUpUserActivationStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpUserActivationStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpUserActivationStatus);
        }

        // GET: LookUpUserActivationStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserActivationStatus = await _context.UserActivationStatus.FindAsync(id);
            if (lookUpUserActivationStatus == null)
            {
                return NotFound();
            }
            return View(lookUpUserActivationStatus);
        }

        // POST: LookUpUserActivationStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserActivationStatusId,UserActivationStatus")] LookUpUserActivationStatus lookUpUserActivationStatus)
        {
            if (id != lookUpUserActivationStatus.UserActivationStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpUserActivationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpUserActivationStatusExists(lookUpUserActivationStatus.UserActivationStatusId))
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
            return View(lookUpUserActivationStatus);
        }

        // GET: LookUpUserActivationStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserActivationStatus = await _context.UserActivationStatus
                .FirstOrDefaultAsync(m => m.UserActivationStatusId == id);
            if (lookUpUserActivationStatus == null)
            {
                return NotFound();
            }

            return View(lookUpUserActivationStatus);
        }

        // POST: LookUpUserActivationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpUserActivationStatus = await _context.UserActivationStatus.FindAsync(id);
            _context.UserActivationStatus.Remove(lookUpUserActivationStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpUserActivationStatusExists(int id)
        {
            return _context.UserActivationStatus.Any(e => e.UserActivationStatusId == id);
        }
    }
}
