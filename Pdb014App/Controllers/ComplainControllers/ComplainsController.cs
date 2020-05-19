using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Pdb014App.Models.PDB;
using Pdb014App.Models.UserManage;
using Pdb014App.Repository;


namespace Pdb014App.Controllers.ComplainControllers
{
    public class ComplainsController : Controller
    {
        private readonly PdbDbContext _context;

        public ComplainsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblComplains
        public async Task<IActionResult> Index()
        {
            var complains = _context.ComplainInfo.Include(t => t.ComplainStatus).Include(t => t.ComplainToSnD).Include(t => t.ComplainToUnion).Include(t => t.ComplainType).Include(t => t.ResolvingOfficer).Include(t => t.ResponsibleOfficer);

            return View(await complains.ToListAsync());
        }



        // GET: TblComplains
        public IActionResult AddComplain()
        {
            ViewData["DivList"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionName");
            //ViewData["DistList"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterComplain(string unionCode, string sndCode, decimal? latitude, decimal? longitude)
        {
            Complain newComplain = new Complain
                {UnionGeoCode = unionCode, SnDCode = sndCode, Latitude = latitude, Longitude = longitude};

            ViewData["ComplainTypeList"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainType");
            //ViewData["ComplainStatusList"] = new SelectList(_context.ComplainStatus, "ComplainStatusId", "ComplainStatus");

            ViewData["UnionList"] = new SelectList(_context.LookUpAdminBndUnion.Where(un => un.UnionGeoCode.Equals(unionCode)), "UnionGeoCode", "UnionName", unionCode);
            ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo.Where(snd => snd.SnDCode.Equals(sndCode)), "SnDCode", "SnDName", sndCode);

            //if (!string.IsNullOrEmpty(unionCode))
            //{
            //    var divCode = _context.LookUpAdminBndUnion.FirstOrDefault(un => un.UnionGeoCode.Equals(unionCode))?
            //        .District.DivisionGeoCode;
            //    var distCode = _context.LookUpAdminBndUnion.FirstOrDefault(un => un.UnionGeoCode.Equals(unionCode))?
            //        .DistrictGeoCode;
            //    var upazCode = _context.LookUpAdminBndUnion.FirstOrDefault(un => un.UnionGeoCode.Equals(unionCode))?
            //        .UpazilaGeoCode;

            //    ViewData["DivList"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionName",
            //        divCode);
            
            //    ViewData["DistList"] =
            //        new SelectList(_context.LookUpAdminBndDistrict.Where(un => un.DivisionGeoCode.Equals(divCode)),
            //            "DistrictGeoCode", "DistrictName", distCode);
            //    ViewData["UpazList"] =
            //        new SelectList(_context.LookUpAdminBndUpazila.Where(up => up.DistrictGeoCode.Equals(distCode)),
            //            "UpazilaGeoCode", "UpazilaName", upazCode);
            //    ViewData["UnionList"] =
            //        new SelectList(_context.LookUpAdminBndUnion.Where(un => un.UpazilaGeoCode.Equals(upazCode)),
            //            "UnionGeoCode", "UnionName", unionCode);
            //}
            //else
            //{
            //    ViewData["DivList"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionName");
            //}


            //ViewData["ResolvingOfficerList"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id");
            //ViewData["ResponsibleOfficerList"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id");

            return View(newComplain);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterComplain([Bind("ComplainTypeId,ComplainerName,ComplainerAddress,ComplainerDetails,UnionGeoCode,SnDCode,Latitude,Longitude")] Complain newComplain)
        {
            newComplain.ComplainStatusId = 1;
            newComplain.ComplainDate = DateTime.Now;
            newComplain.ComplainPriority = 1;


            if (ModelState.IsValid)
            {
                _context.Add(newComplain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["ComplainTypeList"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainType", newComplain.ComplainTypeId);
            //ViewData["ComplainStatusList"] = new SelectList(_context.ComplainStatus, "ComplainStatusId", "ComplainStatus");

            ViewData["UnionList"] = new SelectList(_context.LookUpAdminBndUnion.Where(un => un.UnionGeoCode.Equals(newComplain.UnionGeoCode)), "UnionGeoCode", "UnionName", newComplain.UnionGeoCode);
            ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo.Where(snd => snd.SnDCode.Equals(newComplain.SnDCode)), "SnDCode", "SnDName", newComplain.SnDCode);

            //if (!string.IsNullOrEmpty(newComplain.UnionGeoCode))
            //{
            //    var divCode = _context.LookUpAdminBndUnion.FirstOrDefault(un => un.UnionGeoCode.Equals(newComplain.UnionGeoCode))?
            //        .District.DivisionGeoCode;
            //    var distCode = _context.LookUpAdminBndUnion.FirstOrDefault(un => un.UnionGeoCode.Equals(newComplain.UnionGeoCode))?
            //        .DistrictGeoCode;
            //    var upazCode = _context.LookUpAdminBndUnion.FirstOrDefault(un => un.UnionGeoCode.Equals(newComplain.UnionGeoCode))?
            //        .UpazilaGeoCode;

            //    ViewData["DivList"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionName",
            //        divCode);

            //    ViewData["DistList"] =
            //        new SelectList(_context.LookUpAdminBndDistrict.Where(un => un.DivisionGeoCode.Equals(divCode)),
            //            "DistrictGeoCode", "DistrictName", distCode);
            //    ViewData["UpazList"] =
            //        new SelectList(_context.LookUpAdminBndUpazila.Where(up => up.DistrictGeoCode.Equals(distCode)),
            //            "UpazilaGeoCode", "UpazilaName", upazCode);
            //    ViewData["UnionList"] =
            //        new SelectList(_context.LookUpAdminBndUnion.Where(un => un.UpazilaGeoCode.Equals(upazCode)),
            //            "UnionGeoCode", "UnionName", newComplain.UnionGeoCode);
            //}
            //else
            //{
            //    ViewData["DivList"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionName");
            //}


            //ViewData["ComplainStatusId"] = new SelectList(_context.ComplainStatus, "ComplainStatusId", "ComplainStatus", newComplain.ComplainStatusId);
            //ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", newComplain.SnDCode);
            //ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", newComplain.UnionGeoCode);
            //ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainType", newComplain.ComplainTypeId);
            //ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", newComplain.ResolvingOfficerId);
            //ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", newComplain.ResponsibleOfficerId);

            return View(newComplain);
        }







        // GET: TblComplains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complain = await _context.ComplainInfo
                .Include(t => t.ComplainStatus)
                .Include(t => t.ComplainToSnD)
                .Include(t => t.ComplainToUnion)
                .Include(t => t.ComplainType)
                .Include(t => t.ResolvingOfficer)
                .Include(t => t.ResponsibleOfficer)
                .FirstOrDefaultAsync(m => m.ComplainId == id);

            if (complain == null)
            {
                return NotFound();
            }

            return View(complain);
        }

        // GET: TblComplains/Create
        public IActionResult Create()
        {
            ViewData["ComplainStatusId"] = new SelectList(_context.ComplainStatus, "ComplainStatusId", "ComplainStatus");
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode");
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode");
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainType");
            ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id");
            ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id");
            return View();
        }

        // POST: TblComplains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplainId,ComplainNo,ComplainTypeId,ComplainStatusId,ComplainerName,ComplainerAddress,ComplainerDetails,ComplainDate,ComplainPriority,ResponsibleOfficerId,ResolveDate,ResolvingOfficerId,UnionGeoCode,SnDCode,Latitude,Longitude,Remark")] Complain newComplain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newComplain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ComplainStatusId"] = new SelectList(_context.ComplainStatus, "ComplainStatusId", "ComplainStatus", newComplain.ComplainStatusId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", newComplain.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", newComplain.UnionGeoCode);
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainType", newComplain.ComplainTypeId);
            ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", newComplain.ResolvingOfficerId);
            ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", newComplain.ResponsibleOfficerId);

            return View(newComplain);
        }

        // GET: TblComplains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblComplain = await _context.ComplainInfo.FindAsync(id);
            if (tblComplain == null)
            {
                return NotFound();
            }
            ViewData["ComplainStatusId"] = new SelectList(_context.ComplainStatus, "ComplainStatusId", "ComplainStatus", tblComplain.ComplainStatusId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblComplain.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", tblComplain.UnionGeoCode);
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainType", tblComplain.ComplainTypeId);
            ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplain.ResolvingOfficerId);
            ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplain.ResponsibleOfficerId);
            return View(tblComplain);
        }

        // POST: TblComplains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComplainId,ComplainNo,ComplainTypeId,ComplainStatusId,ComplainerName,ComplainerAddress,ComplainerDetails,ComplainDate,ComplainPriority,ResponsibleOfficerId,ResolveDate,ResolvingOfficerId,UnionGeoCode,SnDCode,Latitude,Longitude,Remark")] Complain tblComplain)
        {
            if (id != tblComplain.ComplainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblComplain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblComplainExists(tblComplain.ComplainId))
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
            ViewData["ComplainStatusId"] = new SelectList(_context.ComplainStatus, "ComplainStatusId", "ComplainStatus", tblComplain.ComplainStatusId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblComplain.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", tblComplain.UnionGeoCode);
            ViewData["ComplainTypeId"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainType", tblComplain.ComplainTypeId);
            ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplain.ResolvingOfficerId);
            ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplain.ResponsibleOfficerId);
            return View(tblComplain);
        }

        // GET: TblComplains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblComplain = await _context.ComplainInfo
                .Include(t => t.ComplainStatus)
                .Include(t => t.ComplainToSnD)
                .Include(t => t.ComplainToUnion)
                .Include(t => t.ComplainType)
                .Include(t => t.ResolvingOfficer)
                .Include(t => t.ResponsibleOfficer)
                .FirstOrDefaultAsync(m => m.ComplainId == id);
            if (tblComplain == null)
            {
                return NotFound();
            }

            return View(tblComplain);
        }

        // POST: TblComplains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblComplain = await _context.ComplainInfo.FindAsync(id);
            _context.ComplainInfo.Remove(tblComplain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblComplainExists(int id)
        {
            return _context.ComplainInfo.Any(e => e.ComplainId == id);
        }
    }
}
