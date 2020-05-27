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
        private readonly PdbDbContext _contextPDB;

        public TblUserProfileDetailsController(UserDbContext context, UserManager<TblUserRegistrationDetail> userManager, PdbDbContext _contextPDB)
        {
            this._context = context;
            this._userManager = userManager;
            this._contextPDB = _contextPDB;
        }

        // GET: TblUserProfileDetails
        public async Task<IActionResult> Index()
        {
            var userDbContext = _context.UserProfileDetail.Include(t => t.UserProfileDetailToUserBpdbEmployee).Include(t => t.UserProfileDetailToUserRegistrationDetail).Include(t => t.UserSecurityQuestion).Include(l => l.UserBpdbEmployeeUserBpdbDivision);


            var user = _context.UserProfileDetail.Include(t => t.UserProfileDetailToUserBpdbEmployee).Include(t => t.UserProfileDetailToUserRegistrationDetail).Include(t => t.UserSecurityQuestion).Include(l => l.UserBpdbEmployeeUserBpdbDivision).ToList();
            var substration = _contextPDB.TblSubstation.ToList();


            //var a = user.Join(
            //                     substration,
            //                     comp => comp.SubstationId,
            //                     sect => sect.SubstationId,
            //                     (comp, sect) => new { User = comp, Substation = sect })

            //                    .Select(c => new
            //                     {
            //                         UserId = c.User.UserId,
            //                         //UserRegistrationId=c.User.Id,
            //                         UserFullName = c.User.UserFullName,
            //                         UserNID = c.User.UserNID,
            //                         UserProfession = c.User.UserProfession,
            //                         UserDesignation = c.User.UserDesignation,
            //                         UserAddress = c.User.UserAddress,
            //                         UserAlternateEmail = c.User.UserAlternateEmail,
            //                         UserAlternateMobile = c.User.UserAlternateMobile,
            //                         //UserSecurityQuestion=c.User.UserSecurityQuestion.UserSecurityQuestion,
            //                         SecurityQuestionAnswer = c.User.SecurityQuestionAnswer,
            //                         IsProfileSubmitted = c.User.IsProfileSubmitted,
            //                         SignatureFileName = c.User.SignatureFileName,
            //                         IsBpdbEmployee = c.User.IsBpdbEmployee,

            //                         BpdbEmployeeLevel = c.User.BpdbEmployeeLevel,
            //                         //BpdbDivision=c.User.UserBpdbEmployeeUserBpdbDivision.BpdbDivisionName,
            //                         BpdbEmpDesignation = c.User.BpdbEmpDesignation,

            //                         SubstationName = c.Substation.SubstationName,
            //                         //SnDCodeName=c.Substation.SubstationToLookUpSnD.SnDName,
            //                         CircleName = c.Substation.SubstationToLookUpSnD.CircleInfo.CircleName,
            //                         ZoneName = c.Substation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
            //                     });


            //ViewBag.myList = a;
            //return View();


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
                .Include(l => l.UserBpdbEmployeeUserBpdbDivision)
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
                .Include(l => l.UserBpdbEmployeeUserBpdbDivision)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblUserProfileDetail == null)
            {
                return RedirectToAction("Create", new { id = id });

                //return Redirect(returnUrl + "TblUserProfileDetails/Create/" + userId);
                //return NotFound();
            }

            ViewBag.Zone = _contextPDB.LookUpZoneInfo.Where(i => i.ZoneCode == tblUserProfileDetail.ZoneCode).Select(i=>i.ZoneName).SingleOrDefault();
            ViewBag.circle = _contextPDB.LookUpCircleInfo.Where(i => i.CircleCode == tblUserProfileDetail.CircleCode).Select(i=>i.CircleName).SingleOrDefault();
            ViewBag.snd = _contextPDB.LookUpSnDInfo.Where(i => i.SnDCode == tblUserProfileDetail.SnDCode).Select(i=>i.SnDName).SingleOrDefault();
            ViewBag.substation = _contextPDB.TblSubstation.Where(i => i.SubstationId == tblUserProfileDetail.SubstationId).Select(i=>i.SubstationName).SingleOrDefault();

            return View(tblUserProfileDetail);
        }






        // GET: TblUserProfileDetails/Create
        public IActionResult Create()
        {
            ViewData["BpdbEmployeeId"] = new SelectList(_context.UserBpdbEmployee, "BpdbEmployeeId", "BpdbEmployeeId");
            ViewData["Id"] = new SelectList(_context.TblUserRegistrationDetail, "Id", "Id");
            ViewData["UserSecurityQuestionId"] = new SelectList(_context.UserSecurityQuestion, "UserSecurityQuestionId", "UserSecurityQuestion");
            ViewData["BpdbDivisionId"] = new SelectList(_context.UserBpdbDivision, "BpdbDivisionId", "BpdbDivisionName");
            ViewData["ZoneCode"] = new SelectList(_contextPDB.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");




            return View();
        }



        //BpdbEmployeeId
        //BpdbDivisionId
        //BpdbEmpDesignation
        //ZoneCode
        //CircleCode
        //SnDCode
        //SubstationId

        //,BpdbDivisionId,BpdbEmpDesignation,ZoneCode,CircleCode,SnDCode,SubstationId

        // POST: TblUserProfileDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Id,UserFullName,UserDateOfBirth,UserNID,IsBpdbEmployee,BpdbEmployeeId,UserProfession,UserDesignation,UserAddress,UserAlternateEmail,UserAlternateMobile,UserSecurityQuestionId,SecurityQuestionAnswer,IsProfileSubmitted,SignatureFileName,BpdbDivisionId,BpdbEmpDesignation,ZoneCode,CircleCode,SnDCode,SubstationId")] TblUserProfileDetail tblUserProfileDetail)
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
            ViewData["BpdbDivisionId"] = new SelectList(_context.UserBpdbDivision, "BpdbDivisionId", "BpdbDivisionName");
            ViewData["ZoneCode"] = new SelectList(_contextPDB.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

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
            ViewData["Id"] = new SelectList(_context.TblUserRegistrationDetail.Where(i => i.Id == tblUserProfileDetail.Id), "Id", "Id", tblUserProfileDetail.Id);
            ViewData["UserSecurityQuestionId"] = new SelectList(_context.UserSecurityQuestion, "UserSecurityQuestionId", "UserSecurityQuestion", tblUserProfileDetail.UserSecurityQuestionId);
            ViewData["BpdbDivisionId"] = new SelectList(_context.UserBpdbDivision, "BpdbDivisionId", "BpdbDivisionName");
            ViewData["ZoneCode"] = new SelectList(_contextPDB.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View(tblUserProfileDetail);
        }

        // POST: TblUserProfileDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int UserId, [Bind("UserId,Id,UserFullName,UserDateOfBirth,UserNID,IsBpdbEmployee,BpdbEmployeeId,UserProfession,UserDesignation,UserAddress,UserAlternateEmail,UserAlternateMobile,UserSecurityQuestionId,SecurityQuestionAnswer,IsProfileSubmitted,SignatureFileName,BpdbDivisionId,BpdbEmpDesignation,ZoneCode,CircleCode,SnDCode,SubstationId")]  TblUserProfileDetail tblUserProfileDetail)
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
            ViewData["BpdbDivisionId"] = new SelectList(_context.UserBpdbDivision, "BpdbDivisionId", "BpdbDivisionName");
            ViewData["ZoneCode"] = new SelectList(_contextPDB.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
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
                .Include(l => l.UserBpdbEmployeeUserBpdbDivision)
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

        public JsonResult GetCircleList(string zoneCode)
        {
            var circleList = _contextPDB.LookUpCircleInfo
                .Where(u => u.ZoneCode.Equals(zoneCode))
                .Select(u => new { u.CircleCode, u.CircleName })
                .OrderBy(u => u.CircleCode).ToList();

            return Json(new SelectList(circleList, "CircleCode", "CircleName"));
        }

        public JsonResult GetSnDList(string circleCode)
        {
            var sndList = _contextPDB.LookUpSnDInfo
                .Where(u => u.CircleCode.Equals(circleCode))
                .Select(u => new { u.SnDCode, u.SnDName })
                .OrderBy(u => u.SnDCode).ToList();

            return Json(new SelectList(sndList, "SnDCode", "SnDName"));
        }

        public JsonResult GetSubStationList(string sndCode)
        {
            var substationList = _contextPDB.TblSubstation
                .Where(u => u.SnDCode.Equals(sndCode))
                .Select(u => new { u.SubstationId, u.SubstationName })
                .OrderBy(u => u.SubstationId).ToList();

            return Json(new SelectList(substationList, "SubstationId", "SubstationName"));
        }
    }
}
