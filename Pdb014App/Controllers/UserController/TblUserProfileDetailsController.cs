using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.UserManage;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.UserController
{
    [Authorize]
    public class TblUserProfileDetailsController : Controller
    {
        private readonly UserDbContext _context;
        private readonly UserManager<TblUserRegistrationDetail> _userManager;

        public TblUserProfileDetailsController(UserDbContext context, UserManager<TblUserRegistrationDetail> userManager)
        {
            this._context = context;
            this._userManager = userManager;
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

        public async Task<IActionResult> ProfileDetials(string id)
        {

            if (id == null)
            {
                return NotFound();
                
            }

            var tblUserProfileDetail = await _context.UserProfileDetail
                .Include(t => t.UserProfileDetailToUserBpdbEmployee)
                .Include(t => t.UserProfileDetailToUserRegistrationDetail)
                .Include(t => t.UserSecurityQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblUserProfileDetail == null)
            {
                return RedirectToAction("Create",new { id=id });

                //return Redirect(returnUrl + "TblUserProfileDetails/Create/" + userId);
                //return NotFound();
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

            //de4605d2 - b29c - 4d83 - 9cc6 - 501063993724

            var id = tblUserProfileDetail.Id;

            var user = await _userManager.FindByIdAsync(id);

            //var user = _userManager.Users.Where(i => i.Id == id).SingleOrDefault();


            //TblUserRegistrationDetail user = userManager.Users.Where(i=> i.Id == id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.UserActivationStatusId = 2;
               
                //user.City = model.City;

                var result = await _userManager.UpdateAsync(user);
            }

                if (ModelState.IsValid)
            {
                _context.Add(tblUserProfileDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction("ProfileDetials", new { id = tblUserProfileDetail.Id });
                //return RedirectToAction(nameof(Index));
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
            ViewData["Id"] = new SelectList(_context.TblUserRegistrationDetail.Where(i=>i.Id== tblUserProfileDetail.Id), "Id", "Id", tblUserProfileDetail.Id);
            ViewData["UserSecurityQuestionId"] = new SelectList(_context.UserSecurityQuestion, "UserSecurityQuestionId", "UserSecurityQuestion", tblUserProfileDetail.UserSecurityQuestionId);
            return View(tblUserProfileDetail);
        }

        // POST: TblUserProfileDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int UserId, [Bind("UserId,Id,UserFullName,UserDateOfBirth,UserNID,IsBpdbEmployee,BpdbEmployeeId,UserProfession,UserDesignation,UserAddress,UserAlternateEmail,UserAlternateMobile,UserSecurityQuestionId,SecurityQuestionAnswer,IsProfileSubmitted,SignatureFileName")]  TblUserProfileDetail tblUserProfileDetail)
        {
            //
            if (UserId != tblUserProfileDetail.UserId)
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
                return RedirectToAction("ProfileDetials", new { id = tblUserProfileDetail.Id });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["BpdbEmployeeId"] = new SelectList(_context.UserBpdbEmployee, "BpdbEmployeeId", "BpdbEmployeeId", tblUserProfileDetail.BpdbEmployeeId);
            ViewData["Id"] = new SelectList(_context.TblUserRegistrationDetail, "Id", "Id", tblUserProfileDetail.Id);
            ViewData["UserSecurityQuestionId"] = new SelectList(_context.UserSecurityQuestion, "UserSecurityQuestionId", "UserSecurityQuestion", tblUserProfileDetail.UserSecurityQuestionId);
            //return RedirectToAction("ProfileDetials")

             
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
