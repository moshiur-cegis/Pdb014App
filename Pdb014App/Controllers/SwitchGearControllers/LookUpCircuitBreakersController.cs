using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.SwitchGearModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.SwitchGearControllers
{
    public class LookUpCircuitBreakersController : Controller
    {
        private readonly PdbDbContext _context;

        public LookUpCircuitBreakersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: LookUpCircuitBreakers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LookUpCircuitBreaker.ToListAsync());
        }

        // GET: LookUpCircuitBreakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCircuitBreaker = await _context.LookUpCircuitBreaker
                .FirstOrDefaultAsync(m => m.CircuitBreakerId == id);
            if (lookUpCircuitBreaker == null)
            {
                return NotFound();
            }

            return View(lookUpCircuitBreaker);
        }

        // GET: LookUpCircuitBreakers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpCircuitBreakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CircuitBreakerId,Type,RatedVoltage,RatedCurrent,OperatingCycle,RatedShortCktBreakingCurrent,RatedShortCktMakingCurrent,RatedBreakingTime,OpeningTime,ClosingTime,RatedOperatingSequence,ControlVoltage,MotorVoltageForSpringCharge,ThreePositionDisconnectorSwitch,Type2,RatedVoltage2,RatedCurrent2,SwitchPositions,ElectricalAndMechanicalInterlock")] LookUpCircuitBreaker lookUpCircuitBreaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpCircuitBreaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpCircuitBreaker);
        }

        // GET: LookUpCircuitBreakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCircuitBreaker = await _context.LookUpCircuitBreaker.FindAsync(id);
            if (lookUpCircuitBreaker == null)
            {
                return NotFound();
            }
            return View(lookUpCircuitBreaker);
        }

        // POST: LookUpCircuitBreakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CircuitBreakerId,Type,RatedVoltage,RatedCurrent,OperatingCycle,RatedShortCktBreakingCurrent,RatedShortCktMakingCurrent,RatedBreakingTime,OpeningTime,ClosingTime,RatedOperatingSequence,ControlVoltage,MotorVoltageForSpringCharge,ThreePositionDisconnectorSwitch,Type2,RatedVoltage2,RatedCurrent2,SwitchPositions,ElectricalAndMechanicalInterlock")] LookUpCircuitBreaker lookUpCircuitBreaker)
        {
            if (id != lookUpCircuitBreaker.CircuitBreakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpCircuitBreaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpCircuitBreakerExists(lookUpCircuitBreaker.CircuitBreakerId))
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
            return View(lookUpCircuitBreaker);
        }

        // GET: LookUpCircuitBreakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpCircuitBreaker = await _context.LookUpCircuitBreaker
                .FirstOrDefaultAsync(m => m.CircuitBreakerId == id);
            if (lookUpCircuitBreaker == null)
            {
                return NotFound();
            }

            return View(lookUpCircuitBreaker);
        }

        // POST: LookUpCircuitBreakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpCircuitBreaker = await _context.LookUpCircuitBreaker.FindAsync(id);
            _context.LookUpCircuitBreaker.Remove(lookUpCircuitBreaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpCircuitBreakerExists(int id)
        {
            return _context.LookUpCircuitBreaker.Any(e => e.CircuitBreakerId == id);
        }
    }
}
