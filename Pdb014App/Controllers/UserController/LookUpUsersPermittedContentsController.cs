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
    public class LookUpUsersPermittedContentsController : Controller
    {
        private readonly UserDbContext _context;

        public LookUpUsersPermittedContentsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: LookUpUsersPermittedContents
        public async Task<IActionResult> Index()
        {
            var userDbContext = _context.UsersPermittedContent.Include(l => l.UsersPermittedContentToUserContentType);
            return View(await userDbContext.ToListAsync());
        }

        // GET: LookUpUsersPermittedContents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUsersPermittedContent = await _context.UsersPermittedContent
                .Include(l => l.UsersPermittedContentToUserContentType)
                .FirstOrDefaultAsync(m => m.UsersPermittedContentId == id);
            if (lookUpUsersPermittedContent == null)
            {
                return NotFound();
            }

            return View(lookUpUsersPermittedContent);
        }

        // GET: LookUpUsersPermittedContents/Create
        public IActionResult Create()
        {
            ViewData["ContentTypeId"] = new SelectList(_context.UserContentType, "ContentTypeId", "ContentTypeName");
            return View();
        }

        // POST: LookUpUsersPermittedContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsersPermittedContentId,ContentTypeId,ContentName,ContentTitle,ContentDescription,ModelName,ControllerName,ActionName")] LookUpUsersPermittedContent lookUpUsersPermittedContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpUsersPermittedContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContentTypeId"] = new SelectList(_context.UserContentType, "ContentTypeId", "ContentTypeName", lookUpUsersPermittedContent.ContentTypeId);
            return View(lookUpUsersPermittedContent);
        }

        // GET: LookUpUsersPermittedContents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUsersPermittedContent = await _context.UsersPermittedContent.FindAsync(id);
            if (lookUpUsersPermittedContent == null)
            {
                return NotFound();
            }
            ViewData["ContentTypeId"] = new SelectList(_context.UserContentType, "ContentTypeId", "ContentTypeName", lookUpUsersPermittedContent.ContentTypeId);
            return View(lookUpUsersPermittedContent);
        }

        // POST: LookUpUsersPermittedContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsersPermittedContentId,ContentTypeId,ContentName,ContentTitle,ContentDescription,ModelName,ControllerName,ActionName")] LookUpUsersPermittedContent lookUpUsersPermittedContent)
        {
            if (id != lookUpUsersPermittedContent.UsersPermittedContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpUsersPermittedContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpUsersPermittedContentExists(lookUpUsersPermittedContent.UsersPermittedContentId))
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
            ViewData["ContentTypeId"] = new SelectList(_context.UserContentType, "ContentTypeId", "ContentTypeName", lookUpUsersPermittedContent.ContentTypeId);
            return View(lookUpUsersPermittedContent);
        }

        // GET: LookUpUsersPermittedContents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUsersPermittedContent = await _context.UsersPermittedContent
                .Include(l => l.UsersPermittedContentToUserContentType)
                .FirstOrDefaultAsync(m => m.UsersPermittedContentId == id);
            if (lookUpUsersPermittedContent == null)
            {
                return NotFound();
            }

            return View(lookUpUsersPermittedContent);
        }

        // POST: LookUpUsersPermittedContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpUsersPermittedContent = await _context.UsersPermittedContent.FindAsync(id);
            _context.UsersPermittedContent.Remove(lookUpUsersPermittedContent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpUsersPermittedContentExists(int id)
        {
            return _context.UsersPermittedContent.Any(e => e.UsersPermittedContentId == id);
        }
    }
}
