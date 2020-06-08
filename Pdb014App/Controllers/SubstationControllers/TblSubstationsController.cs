using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Controllers.PoleControllers;
using Pdb014App.Controllers.UserController;
using Pdb014App.Models.PDB;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Models.UserManage;
using Pdb014App.Models.UserManage.SetRole;
using Pdb014App.Repository;
using ReflectionIT.Mvc.Paging;

namespace Pdb014App.Controllers.SubstationControllers
{

    public class TblSubstationsController : Controller
    {
       
        private readonly UserManager<TblUserRegistrationDetail> _userManger;
        private readonly UserDbContext _contextUser;
        private readonly PdbDbContext _context;

        public TblSubstationsController(PdbDbContext context, UserDbContext contextUser, UserManager<TblUserRegistrationDetail> UserManager)
        {
            _context = context;            
            _contextUser = contextUser;
            _userManger = UserManager;
        }

        // GET: TblSubstations


        [Authorize(Roles = "System Administrator,Super User,Zone,Circle,SnD,Substation")]
        public async Task<IActionResult> Index([FromQuery] string cai, string filter, int pageIndex = 1, string sortExpression = "SubstationId")
        {


            // RMO User Role wise query
            var user = await _userManger.GetUserAsync(User);
            IList<string> userRole = await _userManger.GetRolesAsync(user);
            string getSql = new GetUserDetailsController(_contextUser).GetUserRoleWiseQuery("TblSubstation", "SubstationId", user.Id,userRole);


            var query = _context.TblSubstation.FromSqlRaw(getSql)
                .Include(st => st.SubstationType)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();


            if (query == null)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

           
            if (filter != null)
            {
                query = query.Where(p => p.SubstationId.Contains(filter));

            }

            var model = await PagingList.CreateAsync(query, 10, pageIndex, sortExpression, "SubstationId");

            model.RouteValue = new RouteValueDictionary { { "cai", cai }, { "Filter", filter } };

            return View(model);
        }

     

        public IActionResult Components(string substationId, int isShowLayout = 0, int isShowAction = 0)
        {
            ViewBag.SubstationId = substationId;
            ViewBag.IsShowLayout = isShowLayout;
            ViewBag.IsShowAction = isShowAction;
            return View("Components");
            //return View("Pole");
        }




        // GET: TblSubstations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubstation = await _context.TblSubstation
                .Include(st => st.SubstationType)
                //.Include(st => st.SubstationToLookUpSnD)
                .Include(st => st.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .FirstOrDefaultAsync(m => m.SubstationId == id);
            if (tblSubstation == null)
            {
                return NotFound();
            }

            return View(tblSubstation);
        }

        // GET: TblSubstations/Create
        public IActionResult Create()
        {
            var SubstationTypeInfoes = _context.LookUpSubstationType.Select(agn =>
                new { Code = agn.SubstationTypeId, Name = agn.SubstationTypeId + " : " + agn.SubstationTypeName });

            ViewData["SubstationTypeId"] = new SelectList(SubstationTypeInfoes, "Code", "Name");


            //ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode");
            var SnDInfoes = _context.LookUpSnDInfo.Select(agn =>
                new { Code = agn.SnDCode, Name = agn.SnDCode + " : " + agn.SnDName });

            ViewData["SnDCode"] = new SelectList(SnDInfoes, "Code", "Name");
            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View();
        }

        // POST: TblSubstations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubstationId,SubstationTypeId,SubstationName,SnDCode,NominalVoltage,InstalledCapacity,MaximumDemand,PeakLoad,Location,AreaOfSubstation,Latitude,Longitude,YearOfComissioning")] TblSubstation tblSubstation)
        {

            //if (tblSubstation.IsEmpty() != "")
            //{
            //    ViewData["Error"] = tblSubstation.IsEmpty();
            //    return Redirect("Create");

            //}

            //try
            //{

            if (ModelState.IsValid)
            {
                _context.Add(tblSubstation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //}
            //catch (Exception e)
            //{
            //    ViewData["Error"]= e;
            //    throw;
            //}

            //ViewData["SubstationTypeId"] = new SelectList(_context.LookUpSubstationType, "SubstationTypeId", "SubstationTypeName", tblSubstation.SubstationTypeId);
            //ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblSubstation.SnDCode);

            var SubstationTypeInfoes = _context.LookUpSubstationType.Select(agn =>
                new { Code = agn.SubstationTypeId, Name = agn.SubstationTypeId + " : " + agn.SubstationTypeName });

            ViewData["SubstationTypeId"] = new SelectList(SubstationTypeInfoes, "Code", "Name");


            //ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode");
            var SnDInfoes = _context.LookUpSnDInfo.Select(agn =>
                new { Code = agn.SnDCode, Name = agn.SnDCode + " : " + agn.SnDName });

            ViewData["SnDCode"] = new SelectList(SnDInfoes, "Code", "Name");
            return View(tblSubstation);
        }

        // GET: TblSubstations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubstation = await _context.TblSubstation.FindAsync(id);
            if (tblSubstation == null)
            {
                return NotFound();
            }
            ViewData["SubstationTypeId"] = new SelectList(_context.LookUpSubstationType, "SubstationTypeId", "SubstationTypeName", tblSubstation.SubstationTypeId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDName", tblSubstation.SnDCode);
            return View(tblSubstation);
        }

        // POST: TblSubstations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SubstationId,SubstationTypeId,SubstationName,SnDCode,NominalVoltage,InstalledCapacity,MaximumDemand,PeakLoad,Location,AreaOfSubstation,Latitude,Longitude,YearOfComissioning")] TblSubstation tblSubstation)
        {
            if (id != tblSubstation.SubstationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSubstation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSubstationExists(tblSubstation.SubstationId))
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
            ViewData["SubstationTypeId"] = new SelectList(_context.LookUpSubstationType, "SubstationTypeId", "SubstationTypeId", tblSubstation.SubstationTypeId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblSubstation.SnDCode);
            return View(tblSubstation);
        }

        // GET: TblSubstations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSubstation = await _context.TblSubstation
                .Include(t => t.SubstationType)
                .Include(t => t.SubstationToLookUpSnD)
                .FirstOrDefaultAsync(m => m.SubstationId == id);
            if (tblSubstation == null)
            {
                return NotFound();
            }

            return View(tblSubstation);
        }

        // POST: TblSubstations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblSubstation = await _context.TblSubstation.FindAsync(id);
            _context.TblSubstation.Remove(tblSubstation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSubstationExists(string id)
        {
            return _context.TblSubstation.Any(e => e.SubstationId == id);
        }
        public JsonResult GetCircleList(string zoneCode)
        {
            var circleList = _context.LookUpCircleInfo
                .Where(u => u.ZoneCode.Equals(zoneCode))
                .Select(u => new { u.CircleCode, u.CircleName })
                .OrderBy(u => u.CircleCode).ToList();

            return Json(new SelectList(circleList, "CircleCode", "CircleName"));
        }

        public JsonResult GetSnDList(string circleCode)
        {
            var sndList = _context.LookUpSnDInfo
                .Where(u => u.CircleCode.Equals(circleCode))
                .Select(u => new { u.SnDCode, u.SnDName })
                .OrderBy(u => u.SnDCode).ToList();

            return Json(new SelectList(sndList, "SnDCode", "SnDName"));
        }

        public JsonResult GetSubStationList(string sndCode)
        {
            var substationList = _context.TblSubstation
                .Where(u => u.SnDCode.Equals(sndCode))
                .Select(u => new { u.SubstationId, u.SubstationName })
                .OrderByDescending(u => u.SubstationId).ToList();

            return Json(new SelectList(substationList, "SubstationId", "SubstationName"));
        }
    }
}
