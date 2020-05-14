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
    public class TblUserGrpWisePermissionDetailsController : Controller
    {
        private readonly UserDbContext _context;

        public TblUserGrpWisePermissionDetailsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: TblUserGrpWisePermissionDetails
        public async Task<IActionResult> Index()
        {
            var userDbContext = _context.UserGrpWisePermissionDetail.Include(t => t.UserGrpWisePermissionDetailToIdentityRole).Include(t => t.UserGrpWisePermissionDetailToUsersPermittedContent);
            return View(await userDbContext.ToListAsync());
        }

        // GET: TblUserGrpWisePermissionDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserGrpWisePermissionDetail = await _context.UserGrpWisePermissionDetail
                .Include(t => t.UserGrpWisePermissionDetailToIdentityRole)
                .Include(t => t.UserGrpWisePermissionDetailToUsersPermittedContent)
                .FirstOrDefaultAsync(m => m.PermissionTypeId == id);
            if (tblUserGrpWisePermissionDetail == null)
            {
                return NotFound();
            }

            return View(tblUserGrpWisePermissionDetail);
        }

        // GET: TblUserGrpWisePermissionDetails/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["UsersPermittedContentId"] = new SelectList(_context.UsersPermittedContent, "UsersPermittedContentId", "UsersPermittedContentId");
            return View();
        }

        // POST: TblUserGrpWisePermissionDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionTypeId,UsersPermittedContentId,Id")] TblUserGrpWisePermissionDetail tblUserGrpWisePermissionDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUserGrpWisePermissionDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Roles, "Id", "Name", tblUserGrpWisePermissionDetail.Id);
            ViewData["UsersPermittedContentId"] = new SelectList(_context.UsersPermittedContent, "UsersPermittedContentId", "UsersPermittedContentId", tblUserGrpWisePermissionDetail.UsersPermittedContentId);
            return View(tblUserGrpWisePermissionDetail);
        }

        // GET: TblUserGrpWisePermissionDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserGrpWisePermissionDetail = await _context.UserGrpWisePermissionDetail.FindAsync(id);
            if (tblUserGrpWisePermissionDetail == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Roles, "Id", "Id", tblUserGrpWisePermissionDetail.Id);
            ViewData["UsersPermittedContentId"] = new SelectList(_context.UsersPermittedContent, "UsersPermittedContentId", "UsersPermittedContentId", tblUserGrpWisePermissionDetail.UsersPermittedContentId);
            return View(tblUserGrpWisePermissionDetail);
        }

        // POST: TblUserGrpWisePermissionDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermissionTypeId,UsersPermittedContentId,Id")] TblUserGrpWisePermissionDetail tblUserGrpWisePermissionDetail)
        {
            if (id != tblUserGrpWisePermissionDetail.PermissionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUserGrpWisePermissionDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserGrpWisePermissionDetailExists(tblUserGrpWisePermissionDetail.PermissionTypeId))
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
            ViewData["Id"] = new SelectList(_context.Roles, "Id", "Id", tblUserGrpWisePermissionDetail.Id);
            ViewData["UsersPermittedContentId"] = new SelectList(_context.UsersPermittedContent, "UsersPermittedContentId", "UsersPermittedContentId", tblUserGrpWisePermissionDetail.UsersPermittedContentId);
            return View(tblUserGrpWisePermissionDetail);
        }

        // GET: TblUserGrpWisePermissionDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserGrpWisePermissionDetail = await _context.UserGrpWisePermissionDetail
                .Include(t => t.UserGrpWisePermissionDetailToIdentityRole)
                .Include(t => t.UserGrpWisePermissionDetailToUsersPermittedContent)
                .FirstOrDefaultAsync(m => m.PermissionTypeId == id);
            if (tblUserGrpWisePermissionDetail == null)
            {
                return NotFound();
            }

            return View(tblUserGrpWisePermissionDetail);
        }

        // POST: TblUserGrpWisePermissionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUserGrpWisePermissionDetail = await _context.UserGrpWisePermissionDetail.FindAsync(id);
            _context.UserGrpWisePermissionDetail.Remove(tblUserGrpWisePermissionDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserGrpWisePermissionDetailExists(int id)
        {
            return _context.UserGrpWisePermissionDetail.Any(e => e.PermissionTypeId == id);
        }
    }
}
