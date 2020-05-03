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
    public class TblUserProfileDetailsController : Controller
    {
        private readonly UserDbContext _context;

        public TblUserProfileDetailsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: TblUserProfileDetails
        public async Task<IActionResult> Index()
        {
            var userDbContext = _context.UserProfileDetail.Include(t => t.UserProfileDetailToUserBpdbEmployee).Include(t => t.UserProfileDetailToUserRegistrationDetail).Include(t => t.UserSecurityQuestion);
            return View(await userDbContext.ToListAsync());
        }

        // GET: TblUserProfileDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserProfileDetail = await _context.UserProfileDetail
                .Include(t => t.UserProfileDetailToUserBpdbEmployee)
                .Include(t => t.UserProfileDetailToUserRegistrationDetail)
                .Include(t => t.UserSecurityQuestion)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tblUserProfileDetail == null)
            {
                return NotFound();
            }

            return View(tblUserProfileDetail);
        }

        // GET: TblUserProfileDetails/Create
        public IActionResult Create()
        {
            ViewData["BpdbEmployeeId"] = new SelectList(_context.UserBpdbEmployee, "BpdbEmployeeId", "BpdbEmployeeId");
            ViewData["Id"] = new SelectList(_context.TblUserRegistrationDetail, "Id", "Id");
            ViewData["UserSecurityQuestionId"] = new SelectList(_context.UserSecurityQuestion, "UserSecurityQuestionId", "UserSecurityQuestion");
            return View();
        }

        // POST: TblUserProfileDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Id,UserFullName,UserDateOfBirth,UserNID,IsBpdbEmployee,BpdbEmployeeId,UserProfession,UserDesignation,UserAddress,UserAlternateEmail,UserAlternateMobile,UserSecurityQuestionId,SecurityQuestionAnswer,IsProfileSubmitted,SignatureFileName")] TblUserProfileDetail tblUserProfileDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUserProfileDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BpdbEmployeeId"] = new SelectList(_context.UserBpdbEmployee, "BpdbEmployeeId", "BpdbEmployeeId", tblUserProfileDetail.BpdbEmployeeId);
            ViewData["Id"] = new SelectList(_context.TblUserRegistrationDetail, "Id", "Id", tblUserProfileDetail.Id);
            ViewData["UserSecurityQuestionId"] = new SelectList(_context.UserSecurityQuestion, "UserSecurityQuestionId", "UserSecurityQuestion", tblUserProfileDetail.UserSecurityQuestionId);
            return View(tblUserProfileDetail);
        }

        // GET: TblUserProfileDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserProfileDetail = await _context.UserProfileDetail.FindAsync(id);
            if (tblUserProfileDetail == null)
            {
                return NotFound();
            }
            ViewData["BpdbEmployeeId"] = new SelectList(_context.UserBpdbEmployee, "BpdbEmployeeId", "BpdbEmployeeId", tblUserProfileDetail.BpdbEmployeeId);
            ViewData["Id"] = new SelectList(_context.TblUserRegistrationDetail, "Id", "Id", tblUserProfileDetail.Id);
            ViewData["UserSecurityQuestionId"] = new SelectList(_context.UserSecurityQuestion, "UserSecurityQuestionId", "UserSecurityQuestion", tblUserProfileDetail.UserSecurityQuestionId);
            return View(tblUserProfileDetail);
        }

        // POST: TblUserProfileDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Id,UserFullName,UserDateOfBirth,UserNID,IsBpdbEmployee,BpdbEmployeeId,UserProfession,UserDesignation,UserAddress,UserAlternateEmail,UserAlternateMobile,UserSecurityQuestionId,SecurityQuestionAnswer,IsProfileSubmitted,SignatureFileName")] TblUserProfileDetail tblUserProfileDetail)
        {
            if (id != tblUserProfileDetail.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUserProfileDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserProfileDetailExists(tblUserProfileDetail.UserId))
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
            ViewData["BpdbEmployeeId"] = new SelectList(_context.UserBpdbEmployee, "BpdbEmployeeId", "BpdbEmployeeId", tblUserProfileDetail.BpdbEmployeeId);
            ViewData["Id"] = new SelectList(_context.TblUserRegistrationDetail, "Id", "Id", tblUserProfileDetail.Id);
            ViewData["UserSecurityQuestionId"] = new SelectList(_context.UserSecurityQuestion, "UserSecurityQuestionId", "UserSecurityQuestion", tblUserProfileDetail.UserSecurityQuestionId);
            return View(tblUserProfileDetail);
        }

        // GET: TblUserProfileDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserProfileDetail = await _context.UserProfileDetail
                .Include(t => t.UserProfileDetailToUserBpdbEmployee)
                .Include(t => t.UserProfileDetailToUserRegistrationDetail)
                .Include(t => t.UserSecurityQuestion)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (tblUserProfileDetail == null)
            {
                return NotFound();
            }

            return View(tblUserProfileDetail);
        }

        // POST: TblUserProfileDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUserProfileDetail = await _context.UserProfileDetail.FindAsync(id);
            _context.UserProfileDetail.Remove(tblUserProfileDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserProfileDetailExists(int id)
        {
            return _context.UserProfileDetail.Any(e => e.UserId == id);
        }
    }
}
