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
    public class LookUpUserContentTypesController : Controller
    {
        private readonly UserDbContext _context;

        public LookUpUserContentTypesController(UserDbContext context)
        {
            _context = context;
        }

        // GET: LookUpUserContentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserContentType.ToListAsync());
        }

        // GET: LookUpUserContentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserContentType = await _context.UserContentType
                .FirstOrDefaultAsync(m => m.ContentTypeId == id);
            if (lookUpUserContentType == null)
            {
                return NotFound();
            }

            return View(lookUpUserContentType);
        }

        // GET: LookUpUserContentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpUserContentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContentTypeId,ContentTypeName")] LookUpUserContentType lookUpUserContentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpUserContentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpUserContentType);
        }

        // GET: LookUpUserContentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserContentType = await _context.UserContentType.FindAsync(id);
            if (lookUpUserContentType == null)
            {
                return NotFound();
            }
            return View(lookUpUserContentType);
        }

        // POST: LookUpUserContentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContentTypeId,ContentTypeName")] LookUpUserContentType lookUpUserContentType)
        {
            if (id != lookUpUserContentType.ContentTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpUserContentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpUserContentTypeExists(lookUpUserContentType.ContentTypeId))
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
            return View(lookUpUserContentType);
        }

        // GET: LookUpUserContentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserContentType = await _context.UserContentType
                .FirstOrDefaultAsync(m => m.ContentTypeId == id);
            if (lookUpUserContentType == null)
            {
                return NotFound();
            }

            return View(lookUpUserContentType);
        }

        // POST: LookUpUserContentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpUserContentType = await _context.UserContentType.FindAsync(id);
            _context.UserContentType.Remove(lookUpUserContentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpUserContentTypeExists(int id)
        {
            return _context.UserContentType.Any(e => e.ContentTypeId == id);
        }
    }
}
