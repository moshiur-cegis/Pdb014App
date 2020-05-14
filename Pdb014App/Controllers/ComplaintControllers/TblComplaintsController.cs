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


namespace Pdb014App.Controllers.ComplaintControllers
{
    public class TblComplaintsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblComplaintsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblComplaints
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.ComplaintInfo.Include(t => t.ComplaintStatus).Include(t => t.ComplaintToSnD).Include(t => t.ComplaintToUnion).Include(t => t.ComplaintType).Include(t => t.ResolvingOfficer).Include(t => t.ResponsibleOfficer);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblComplaints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblComplaint = await _context.ComplaintInfo
                .Include(t => t.ComplaintStatus)
                .Include(t => t.ComplaintToSnD)
                .Include(t => t.ComplaintToUnion)
                .Include(t => t.ComplaintType)
                .Include(t => t.ResolvingOfficer)
                .Include(t => t.ResponsibleOfficer)
                .FirstOrDefaultAsync(m => m.ComplaintId == id);
            if (tblComplaint == null)
            {
                return NotFound();
            }

            return View(tblComplaint);
        }

        // GET: TblComplaints/Create
        public IActionResult Create()
        {
            ViewData["ComplaintStatusId"] = new SelectList(_context.ComplaintStatus, "ComplaintStatusId", "ComplaintStatus");
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode");
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode");
            ViewData["ComplaintTypeId"] = new SelectList(_context.ComplaintTypes, "ComplaintTypeId", "ComplaintType");
            ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id");
            ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id");
            return View();
        }

        // POST: TblComplaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplaintId,ComplaintNo,ComplaintTypeId,ComplaintStatusId,ComplainerName,ComplainerAddress,ComplainerDetails,ComplaintDate,ComplaintPriority,ResponsibleOfficerId,ResolveDate,ResolvingOfficerId,UnionGeoCode,SnDCode,Latitude,Longitude,Remark")] TblComplaint tblComplaint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblComplaint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComplaintStatusId"] = new SelectList(_context.ComplaintStatus, "ComplaintStatusId", "ComplaintStatus", tblComplaint.ComplaintStatusId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblComplaint.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", tblComplaint.UnionGeoCode);
            ViewData["ComplaintTypeId"] = new SelectList(_context.ComplaintTypes, "ComplaintTypeId", "ComplaintType", tblComplaint.ComplaintTypeId);
            ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplaint.ResolvingOfficerId);
            ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplaint.ResponsibleOfficerId);
            return View(tblComplaint);
        }

        // GET: TblComplaints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblComplaint = await _context.ComplaintInfo.FindAsync(id);
            if (tblComplaint == null)
            {
                return NotFound();
            }
            ViewData["ComplaintStatusId"] = new SelectList(_context.ComplaintStatus, "ComplaintStatusId", "ComplaintStatus", tblComplaint.ComplaintStatusId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblComplaint.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", tblComplaint.UnionGeoCode);
            ViewData["ComplaintTypeId"] = new SelectList(_context.ComplaintTypes, "ComplaintTypeId", "ComplaintType", tblComplaint.ComplaintTypeId);
            ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplaint.ResolvingOfficerId);
            ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplaint.ResponsibleOfficerId);
            return View(tblComplaint);
        }

        // POST: TblComplaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComplaintId,ComplaintNo,ComplaintTypeId,ComplaintStatusId,ComplainerName,ComplainerAddress,ComplainerDetails,ComplaintDate,ComplaintPriority,ResponsibleOfficerId,ResolveDate,ResolvingOfficerId,UnionGeoCode,SnDCode,Latitude,Longitude,Remark")] TblComplaint tblComplaint)
        {
            if (id != tblComplaint.ComplaintId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblComplaint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblComplaintExists(tblComplaint.ComplaintId))
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
            ViewData["ComplaintStatusId"] = new SelectList(_context.ComplaintStatus, "ComplaintStatusId", "ComplaintStatus", tblComplaint.ComplaintStatusId);
            ViewData["SnDCode"] = new SelectList(_context.LookUpSnDInfo, "SnDCode", "SnDCode", tblComplaint.SnDCode);
            ViewData["UnionGeoCode"] = new SelectList(_context.LookUpAdminBndUnion, "UnionGeoCode", "UnionGeoCode", tblComplaint.UnionGeoCode);
            ViewData["ComplaintTypeId"] = new SelectList(_context.ComplaintTypes, "ComplaintTypeId", "ComplaintType", tblComplaint.ComplaintTypeId);
            ViewData["ResolvingOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplaint.ResolvingOfficerId);
            ViewData["ResponsibleOfficerId"] = new SelectList(_context.Set<TblUserProfileDetail>(), "UserId", "Id", tblComplaint.ResponsibleOfficerId);
            return View(tblComplaint);
        }

        // GET: TblComplaints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblComplaint = await _context.ComplaintInfo
                .Include(t => t.ComplaintStatus)
                .Include(t => t.ComplaintToSnD)
                .Include(t => t.ComplaintToUnion)
                .Include(t => t.ComplaintType)
                .Include(t => t.ResolvingOfficer)
                .Include(t => t.ResponsibleOfficer)
                .FirstOrDefaultAsync(m => m.ComplaintId == id);
            if (tblComplaint == null)
            {
                return NotFound();
            }

            return View(tblComplaint);
        }

        // POST: TblComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblComplaint = await _context.ComplaintInfo.FindAsync(id);
            _context.ComplaintInfo.Remove(tblComplaint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblComplaintExists(int id)
        {
            return _context.ComplaintInfo.Any(e => e.ComplaintId == id);
        }
    }
}
