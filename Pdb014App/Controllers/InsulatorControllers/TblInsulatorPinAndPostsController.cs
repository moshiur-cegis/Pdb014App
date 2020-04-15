using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.InsulatorModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.InsulatorControllers
{
    public class TblInsulatorPinAndPostsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblInsulatorPinAndPostsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblInsulatorPinAndPosts
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblInsulatorPinAndPost.Include(t => t.InsulatorPinAndPostToPole).Include(t => t.LookUpInsulatorPinAndPostType);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblInsulatorPinAndPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorPinAndPost = await _context.TblInsulatorPinAndPost
                .Include(t => t.InsulatorPinAndPostToPole)
                .Include(t => t.LookUpInsulatorPinAndPostType)
                .FirstOrDefaultAsync(m => m.InsulatorPinAndPostId == id);
            if (tblInsulatorPinAndPost == null)
            {
                return NotFound();
            }

            return View(tblInsulatorPinAndPost);
        }

        // GET: TblInsulatorPinAndPosts/Create
        public IActionResult Create()
        {
            var poleIdList = _context.TblPole.AsNoTracking()
                .Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList();
            ViewData["PoleId"] = poleIdList;
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["InsulatorPinAndPostTypeId"] = new SelectList(_context.LookUpInsulatorPinAndPostType, "InsulatorPinAndPostTypeId", "InsulatorPinAndPostTypeName");
            return View();
        }

        // POST: TblInsulatorPinAndPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsulatorPinAndPostId,Installation,NominalSystemVoltage,InsulatorPinAndPostTypeId,MaximumSystemVoltage,TypeOfSystem,InsulatorVoltageClass,InsulatorMaterials,MinimumCreepageDistance,MinimumWithstandVoltage,PowerFrequencyDry,PowerFrequencyWet,ImpulseWithstandVoltage,MinimumPowerFrequencyFlashoverDry,MinimumPowerFrequencyFlashoverWet,FiftyPctImpulseFlashoverWavePositive,FiftyPctImpulseFlashoverWaveNegative,PowerFrequencyPuncherVoltage,MinimumDryArchingDistance,PowerFrequencyTestVoltageRmsToGround,MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt,MinimumNeckDiameter,MinimumDiameterOfInsulator,MinimumHeightOfTheInsulator,MinimumGroveDiameter,MinimumMechanicalFailingLoad,PoleId")] TblInsulatorPinAndPost tblInsulatorPinAndPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblInsulatorPinAndPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorPinAndPost.PoleId);
            ViewData["InsulatorPinAndPostTypeId"] = new SelectList(_context.LookUpInsulatorPinAndPostType, "InsulatorPinAndPostTypeId", "InsulatorPinAndPostTypeName", tblInsulatorPinAndPost.InsulatorPinAndPostTypeId);
            return View(tblInsulatorPinAndPost);
        }

        // GET: TblInsulatorPinAndPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorPinAndPost = await _context.TblInsulatorPinAndPost.FindAsync(id);
            if (tblInsulatorPinAndPost == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorPinAndPost.PoleId);
            ViewData["InsulatorPinAndPostTypeId"] = new SelectList(_context.LookUpInsulatorPinAndPostType, "InsulatorPinAndPostTypeId", "InsulatorPinAndPostTypeName", tblInsulatorPinAndPost.InsulatorPinAndPostTypeId);
            return View(tblInsulatorPinAndPost);
        }

        // POST: TblInsulatorPinAndPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsulatorPinAndPostId,Installation,NominalSystemVoltage,InsulatorPinAndPostTypeId,MaximumSystemVoltage,TypeOfSystem,InsulatorVoltageClass,InsulatorMaterials,MinimumCreepageDistance,MinimumWithstandVoltage,PowerFrequencyDry,PowerFrequencyWet,ImpulseWithstandVoltage,MinimumPowerFrequencyFlashoverDry,MinimumPowerFrequencyFlashoverWet,FiftyPctImpulseFlashoverWavePositive,FiftyPctImpulseFlashoverWaveNegative,PowerFrequencyPuncherVoltage,MinimumDryArchingDistance,PowerFrequencyTestVoltageRmsToGround,MinimumRadioInfluenceVoltageRIVAt1000KcInMicroVolt,MinimumNeckDiameter,MinimumDiameterOfInsulator,MinimumHeightOfTheInsulator,MinimumGroveDiameter,MinimumMechanicalFailingLoad,PoleId")] TblInsulatorPinAndPost tblInsulatorPinAndPost)
        {
            if (id != tblInsulatorPinAndPost.InsulatorPinAndPostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblInsulatorPinAndPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblInsulatorPinAndPostExists(tblInsulatorPinAndPost.InsulatorPinAndPostId))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblInsulatorPinAndPost.PoleId);
            ViewData["InsulatorPinAndPostTypeId"] = new SelectList(_context.LookUpInsulatorPinAndPostType, "InsulatorPinAndPostTypeId", "InsulatorPinAndPostTypeName", tblInsulatorPinAndPost.InsulatorPinAndPostTypeId);
            return View(tblInsulatorPinAndPost);
        }

        // GET: TblInsulatorPinAndPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblInsulatorPinAndPost = await _context.TblInsulatorPinAndPost
                .Include(t => t.InsulatorPinAndPostToPole)
                .Include(t => t.LookUpInsulatorPinAndPostType)
                .FirstOrDefaultAsync(m => m.InsulatorPinAndPostId == id);
            if (tblInsulatorPinAndPost == null)
            {
                return NotFound();
            }

            return View(tblInsulatorPinAndPost);
        }

        // POST: TblInsulatorPinAndPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblInsulatorPinAndPost = await _context.TblInsulatorPinAndPost.FindAsync(id);
            _context.TblInsulatorPinAndPost.Remove(tblInsulatorPinAndPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblInsulatorPinAndPostExists(int id)
        {
            return _context.TblInsulatorPinAndPost.Any(e => e.InsulatorPinAndPostId == id);
        }
    }
}
