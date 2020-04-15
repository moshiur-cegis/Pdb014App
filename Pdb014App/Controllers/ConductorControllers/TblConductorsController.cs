using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.ConductorModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.ConductorControllers
{
    public class TblConductorsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblConductorsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblConductors
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblConductor.Include(t => t.ConductorToPole).Include(t => t.ConductorType);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblConductors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var tblConductor = await _context.TblConductor
                .Include(t => t.ConductorToPole)
                .Include(t => t.ConductorType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblConductor == null)
            {
                return NotFound();
            }

            return View(tblConductor);
        }

        // GET: TblConductors/Create
        public IActionResult Create()
        {
            var poleIdList = _context.TblPole.AsNoTracking()
                .Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList();
            ViewData["PoleId"] = poleIdList;


            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");

            //ViewBag.PoleId = new SelectList(_context.TblPole, "PoleId", "PoleId");
            //ViewBag.ProjectId = new SelectList(db.LookupProjects.Where(i => i.Exclude != "Yes"), "ProjectId", "ProjectCode");
            ViewData["ConductorTypeId"] = new SelectList(_context.LookUpConductorType, "ConductorTypeId", "ConductorTypeName");
            return View();
        }

        // POST: TblConductors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConductorTypeId,ConductorName,Standard,Installation,Material,OverallDiameter,NumberOrDiameterOfAluminum,CrossSectionalAreaOfConducto,NominalAluminumCrossSectionalArea,NumberOrdiameterOfSteel,NominalSteelCrossSectionalArea,WeightOfConductor,CodeName,MaximumDcResistanceOfConductorAt20DegC,MinimumBreakingLoadOfConductor,PhasingCode,OperatingVoltage,NeutralMaterial,NeutralSize,AssemblyCode,NominalVoltage,PhaseOrientation,InstallDate,ConductorCrossSection,ConductorCapacityAmp,TotalSanctionedLoadFromTheFeeder,PoleId")] TblConductor tblConductor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblConductor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblConductor.PoleId);
            ViewData["ConductorTypeId"] = new SelectList(_context.LookUpConductorType, "ConductorTypeId", "ConductorTypeId", tblConductor.ConductorTypeId);
            return View(tblConductor);
        }

        // GET: TblConductors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var tblConductor = await _context.TblConductor.FindAsync(id);
            if (tblConductor == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblConductor.PoleId);
            ViewData["ConductorTypeId"] = new SelectList(_context.LookUpConductorType, "ConductorTypeId", "ConductorTypeId", tblConductor.ConductorTypeId);
            return View(tblConductor);
        }

        // POST: TblConductors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConductorTypeId,ConductorName,Standard,Installation,Material,OverallDiameter,NumberOrDiameterOfAluminum,CrossSectionalAreaOfConducto,NominalAluminumCrossSectionalArea,NumberOrdiameterOfSteel,NominalSteelCrossSectionalArea,WeightOfConductor,CodeName,MaximumDcResistanceOfConductorAt20DegC,MinimumBreakingLoadOfConductor,PhasingCode,OperatingVoltage,NeutralMaterial,NeutralSize,AssemblyCode,NominalVoltage,PhaseOrientation,InstallDate,ConductorCrossSection,ConductorCapacityAmp,TotalSanctionedLoadFromTheFeeder,PoleId")] TblConductor tblConductor)
        {
            if (id != tblConductor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblConductor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblConductorExists(tblConductor.Id))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblConductor.PoleId);
            ViewData["ConductorTypeId"] = new SelectList(_context.LookUpConductorType, "ConductorTypeId", "ConductorTypeId", tblConductor.ConductorTypeId);
            return View(tblConductor);
        }

        // GET: TblConductors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var tblConductor = await _context.TblConductor
                .Include(t => t.ConductorToPole)
                .Include(t => t.ConductorType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblConductor == null)
            {
                return NotFound();
            }

            return View(tblConductor);
        }

        // POST: TblConductors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblConductor = await _context.TblConductor.FindAsync(id);
            _context.TblConductor.Remove(tblConductor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblConductorExists(int id)
        {
            return _context.TblConductor.Any(e => e.Id == id);
        }
    }
}
