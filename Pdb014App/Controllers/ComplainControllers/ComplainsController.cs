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

        // GET: TblComplains
        public IActionResult NewComplain(string unionCode, string sndCode, int? lat, int? lon)
        {
            //ViewData["DivList"] = new SelectList(_context.LookUpAdminBndDivision, "DivisionGeoCode", "DivisionName");
            //ViewData["DistList"] = new SelectList(_context.LookUpAdminBndDistrict, "DistrictGeoCode", "DistrictName");


            ViewData["ComplainTypeList"] = new SelectList(_context.ComplainTypes, "ComplainTypeId", "ComplainType");
            ViewData["ComplainStatusList"] = new SelectList(_context.ComplainStatus, "ComplainStatusId", "ComplainStatus");

            ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode");
            ViewData["UnionList"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode");
            ViewData["ResolvingOfficerList"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id");
            ViewData["ResponsibleOfficerList"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id");


            return View();
        }


        // GET: TblComplains/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("ComplainId,ComplainNo,ComplainTypeId,ComplainStatusId,ComplainerName,ComplainerAddress,ComplainerDetails,ComplainDate,ComplainPriority,ResponsibleOfficerId,ResolveDate,ResolvingOfficerId,UnionGeoCode,SnDCode,Latitude,Longitude,Remark")] Complain tblComplain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblComplain);
                await _context.SaveChangesAsync();
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
