using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Repository;
using ReflectionIT.Mvc.Paging;

namespace Pdb014App.Controllers.SubstationControllers
{
    public class TblOutDoorTypeVacumnCircuitBreakersController : Controller
    {
        private readonly PdbDbContext _context;

        public TblOutDoorTypeVacumnCircuitBreakersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblOutDoorTypeVacumnCircuitBreakers


        public async Task<IActionResult> Index(string filter, int pageIndex = 1, string sortExpression = "VacumnCircuitBreakerId")
        {
            var qry = _context.TblOutDoorTypeVacumnCircuitBreaker.Include(t => t.OutDoorTypeVacumnCircuitBreakerIdToSubstation).AsQueryable();


            if (filter != null)
            {
                qry = qry.Where(p => p.VacumnCircuitBreakerId == filter);
            }

            var model = await PagingList.CreateAsync(qry, 10, pageIndex, sortExpression, "VacumnCircuitBreakerId");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        public async Task<IActionResult> OutDoorTypeVacumnCircuitBreakersList(string substationId, int isShowLayout = 0, int isShowAction = 0)
        {
            ViewBag.IsShowLayout = isShowLayout;
            ViewBag.IsShowAction = isShowAction;

            var vacumnCircuitBreakersList = _context.TblOutDoorTypeVacumnCircuitBreaker.Include(t => t.OutDoorTypeVacumnCircuitBreakerIdToSubstation).AsNoTracking();


            if (substationId != null)
            {
                vacumnCircuitBreakersList = vacumnCircuitBreakersList.Where(p => p.SubstationId == substationId);
            }

            return View(await vacumnCircuitBreakersList.ToListAsync());
        }



        // GET: TblOutDoorTypeVacumnCircuitBreakers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOutDoorTypeVacumnCircuitBreaker = await _context.TblOutDoorTypeVacumnCircuitBreaker
                .Include(t => t.OutDoorTypeVacumnCircuitBreakerIdToSubstation)
                .FirstOrDefaultAsync(m => m.VacumnCircuitBreakerId == id);
            if (tblOutDoorTypeVacumnCircuitBreaker == null)
            {
                return NotFound();
            }

            return View(tblOutDoorTypeVacumnCircuitBreaker);
        }

        // GET: TblOutDoorTypeVacumnCircuitBreakers/Create
        public IActionResult Create()
        {
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId");
            return View();
        }

        // POST: TblOutDoorTypeVacumnCircuitBreakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacumnCircuitBreakerId,SubstationId,ManufacturersNameCountry,ManufacturersModelNo,MaximumRatedVoltage,Frequency,RatedNormalCurrent,NoOfPhase,NoOfBreakPerPhrase,InterruptingMedium,ImpulseWithstandOn1250MsWave,PowerFrequencyTestVoltageDryAt50Hz1Min,ShortTimeWithstandCurrent3SecondRms,SymmetricalRms,AsymmetricalRms,ShortCircuitMakingCurrentPeak,TripCoilCurrent,TripCoilVoltage,OpeningTimeWithoutCurrentAt100OfRatedBreakingcurrent,BreakingTime,ClosingTime,RatedVoltageofSpringWindingMotorforClosing,SpringWindingMotorCurrent,ClosingReleaseCoilCurrent,ClosingReleaseCoilVoltage,NoOfTrippingCoil,CircuitBreakerTerminalConnectors,PressureInVacuumTubeforVCB,AtRatedCurrentSwitching,AtShortCircuitCurrentSwitching,RatedOperatingSequence")] TblOutDoorTypeVacumnCircuitBreaker tblOutDoorTypeVacumnCircuitBreaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblOutDoorTypeVacumnCircuitBreaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblOutDoorTypeVacumnCircuitBreaker.SubstationId);
            return View(tblOutDoorTypeVacumnCircuitBreaker);
        }

        // GET: TblOutDoorTypeVacumnCircuitBreakers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOutDoorTypeVacumnCircuitBreaker = await _context.TblOutDoorTypeVacumnCircuitBreaker.FindAsync(id);
            if (tblOutDoorTypeVacumnCircuitBreaker == null)
            {
                return NotFound();
            }
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblOutDoorTypeVacumnCircuitBreaker.SubstationId);
            return View(tblOutDoorTypeVacumnCircuitBreaker);
        }

        // POST: TblOutDoorTypeVacumnCircuitBreakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VacumnCircuitBreakerId,SubstationId,ManufacturersNameCountry,ManufacturersModelNo,MaximumRatedVoltage,Frequency,RatedNormalCurrent,NoOfPhase,NoOfBreakPerPhrase,InterruptingMedium,ImpulseWithstandOn1250MsWave,PowerFrequencyTestVoltageDryAt50Hz1Min,ShortTimeWithstandCurrent3SecondRms,SymmetricalRms,AsymmetricalRms,ShortCircuitMakingCurrentPeak,TripCoilCurrent,TripCoilVoltage,OpeningTimeWithoutCurrentAt100OfRatedBreakingcurrent,BreakingTime,ClosingTime,RatedVoltageofSpringWindingMotorforClosing,SpringWindingMotorCurrent,ClosingReleaseCoilCurrent,ClosingReleaseCoilVoltage,NoOfTrippingCoil,CircuitBreakerTerminalConnectors,PressureInVacuumTubeforVCB,AtRatedCurrentSwitching,AtShortCircuitCurrentSwitching,RatedOperatingSequence")] TblOutDoorTypeVacumnCircuitBreaker tblOutDoorTypeVacumnCircuitBreaker)
        {
            if (id != tblOutDoorTypeVacumnCircuitBreaker.VacumnCircuitBreakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblOutDoorTypeVacumnCircuitBreaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblOutDoorTypeVacumnCircuitBreakerExists(tblOutDoorTypeVacumnCircuitBreaker.VacumnCircuitBreakerId))
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
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblOutDoorTypeVacumnCircuitBreaker.SubstationId);
            return View(tblOutDoorTypeVacumnCircuitBreaker);
        }

        // GET: TblOutDoorTypeVacumnCircuitBreakers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOutDoorTypeVacumnCircuitBreaker = await _context.TblOutDoorTypeVacumnCircuitBreaker
                .Include(t => t.OutDoorTypeVacumnCircuitBreakerIdToSubstation)
                .FirstOrDefaultAsync(m => m.VacumnCircuitBreakerId == id);
            if (tblOutDoorTypeVacumnCircuitBreaker == null)
            {
                return NotFound();
            }

            return View(tblOutDoorTypeVacumnCircuitBreaker);
        }

        // POST: TblOutDoorTypeVacumnCircuitBreakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblOutDoorTypeVacumnCircuitBreaker = await _context.TblOutDoorTypeVacumnCircuitBreaker.FindAsync(id);
            _context.TblOutDoorTypeVacumnCircuitBreaker.Remove(tblOutDoorTypeVacumnCircuitBreaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblOutDoorTypeVacumnCircuitBreakerExists(string id)
        {
            return _context.TblOutDoorTypeVacumnCircuitBreaker.Any(e => e.VacumnCircuitBreakerId == id);
        }
    }
}
