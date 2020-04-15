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
        public async Task<IActionResult> Index(int? filter, int pageIndex = 1, string sortExpression = "OutDoorTypeVacumnCircuitBreakerId")
        {
            var qry = _context.TblOutDoorTypeVacumnCircuitBreaker.Include(t => t.OutDoorTypeVacumnCircuitBreakerIdToSubstation).AsQueryable();


            if (filter != null)
            {
                qry = qry.Where(p => p.OutDoorTypeVacumnCircuitBreakerId == filter);
            }

            var model = await PagingList.CreateAsync(qry, 10, pageIndex, sortExpression, "OutDoorTypeVacumnCircuitBreakerId");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        // GET: TblOutDoorTypeVacumnCircuitBreakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOutDoorTypeVacumnCircuitBreaker = await _context.TblOutDoorTypeVacumnCircuitBreaker
                .Include(t => t.OutDoorTypeVacumnCircuitBreakerIdToSubstation)
                .FirstOrDefaultAsync(m => m.OutDoorTypeVacumnCircuitBreakerId == id);
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
        public async Task<IActionResult> Create([Bind("OutDoorTypeVacumnCircuitBreakerId,SubstationId,ManufacturersNameCountry,ManufacturersModelNo,MaximumRatedVoltage,Frequency,RatedNormalCurrent,NoOfPhase,NoOfBreakPerPhrase,InterruptingMedium,ImpulseWithstandOn1250MsWave,PowerFrequencyTestVoltageDryAt50Hz1Min,ShortTimeWithstandCurrent3SecondRms,SymmetricalRms,AsymmetricalRms,ShortCircuitMakingCurrentPeak,TripCoilCurrent,TripCoilVoltage,OpeningTimeWithoutCurrentAt100OfRatedBreakingcurrent,BreakingTime,ClosingTime,RatedVoltageofSpringWindingMotorforClosing,SpringWindingMotorCurrent,ClosingReleaseCoilCurrent,ClosingReleaseCoilVoltage,NoOfTrippingCoil,CircuitBreakerTerminalConnectors,PressureInVacuumTubeforVCB,AtRatedCurrentSwitching,AtShortCircuitCurrentSwitching,RatedOperatingSequence")] TblOutDoorTypeVacumnCircuitBreaker tblOutDoorTypeVacumnCircuitBreaker)
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
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("OutDoorTypeVacumnCircuitBreakerId,SubstationId,ManufacturersNameCountry,ManufacturersModelNo,MaximumRatedVoltage,Frequency,RatedNormalCurrent,NoOfPhase,NoOfBreakPerPhrase,InterruptingMedium,ImpulseWithstandOn1250MsWave,PowerFrequencyTestVoltageDryAt50Hz1Min,ShortTimeWithstandCurrent3SecondRms,SymmetricalRms,AsymmetricalRms,ShortCircuitMakingCurrentPeak,TripCoilCurrent,TripCoilVoltage,OpeningTimeWithoutCurrentAt100OfRatedBreakingcurrent,BreakingTime,ClosingTime,RatedVoltageofSpringWindingMotorforClosing,SpringWindingMotorCurrent,ClosingReleaseCoilCurrent,ClosingReleaseCoilVoltage,NoOfTrippingCoil,CircuitBreakerTerminalConnectors,PressureInVacuumTubeforVCB,AtRatedCurrentSwitching,AtShortCircuitCurrentSwitching,RatedOperatingSequence")] TblOutDoorTypeVacumnCircuitBreaker tblOutDoorTypeVacumnCircuitBreaker)
        {
            if (id != tblOutDoorTypeVacumnCircuitBreaker.OutDoorTypeVacumnCircuitBreakerId)
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
                    if (!TblOutDoorTypeVacumnCircuitBreakerExists(tblOutDoorTypeVacumnCircuitBreaker.OutDoorTypeVacumnCircuitBreakerId))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOutDoorTypeVacumnCircuitBreaker = await _context.TblOutDoorTypeVacumnCircuitBreaker
                .Include(t => t.OutDoorTypeVacumnCircuitBreakerIdToSubstation)
                .FirstOrDefaultAsync(m => m.OutDoorTypeVacumnCircuitBreakerId == id);
            if (tblOutDoorTypeVacumnCircuitBreaker == null)
            {
                return NotFound();
            }

            return View(tblOutDoorTypeVacumnCircuitBreaker);
        }

        // POST: TblOutDoorTypeVacumnCircuitBreakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblOutDoorTypeVacumnCircuitBreaker = await _context.TblOutDoorTypeVacumnCircuitBreaker.FindAsync(id);
            _context.TblOutDoorTypeVacumnCircuitBreaker.Remove(tblOutDoorTypeVacumnCircuitBreaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblOutDoorTypeVacumnCircuitBreakerExists(int id)
        {
            return _context.TblOutDoorTypeVacumnCircuitBreaker.Any(e => e.OutDoorTypeVacumnCircuitBreakerId == id);
        }
    }
}
