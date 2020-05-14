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
    public class LookUpUserPermissionTypesController : Controller
    {
        private readonly UserDbContext _context;

        public LookUpUserPermissionTypesController(UserDbContext context)
        {
            _context = context;
        }

        // GET: LookUpUserPermissionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserPermissionType.ToListAsync());
        }

        // GET: LookUpUserPermissionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserPermissionType = await _context.UserPermissionType
                .FirstOrDefaultAsync(m => m.PermissionTypeId == id);
            if (lookUpUserPermissionType == null)
            {
                return NotFound();
            }

            return View(lookUpUserPermissionType);
        }

        // GET: LookUpUserPermissionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpUserPermissionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionTypeId,PermissionTypeName")] LookUpUserPermissionType lookUpUserPermissionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpUserPermissionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpUserPermissionType);
        }

        // GET: LookUpUserPermissionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserPermissionType = await _context.UserPermissionType.FindAsync(id);
            if (lookUpUserPermissionType == null)
            {
                return NotFound();
            }
            return View(lookUpUserPermissionType);
        }

        // POST: LookUpUserPermissionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermissionTypeId,PermissionTypeName")] LookUpUserPermissionType lookUpUserPermissionType)
        {
            if (id != lookUpUserPermissionType.PermissionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpUserPermissionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpUserPermissionTypeExists(lookUpUserPermissionType.PermissionTypeId))
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
            return View(lookUpUserPermissionType);
        }

        // GET: LookUpUserPermissionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserPermissionType = await _context.UserPermissionType
                .FirstOrDefaultAsync(m => m.PermissionTypeId == id);
            if (lookUpUserPermissionType == null)
            {
                return NotFound();
            }

            return View(lookUpUserPermissionType);
        }

        // POST: LookUpUserPermissionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpUserPermissionType = await _context.UserPermissionType.FindAsync(id);
            _context.UserPermissionType.Remove(lookUpUserPermissionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpUserPermissionTypeExists(int id)
        {
            return _context.UserPermissionType.Any(e => e.PermissionTypeId == id);
        }
    }
}
