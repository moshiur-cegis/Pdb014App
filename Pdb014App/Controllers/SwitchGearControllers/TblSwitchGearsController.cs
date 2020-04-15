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
    public class TblSwitchGearsController : Controller
    {
        private readonly PdbDbContext _context;

        public TblSwitchGearsController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblSwitchGears
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblSwitchGear
                .Include(t => t.SwitchGearToIdmtRelay)
                .Include(t => t.SwitchGearToAmpereMeter)
                .Include(t => t.SwitchGearToBusBar)
                .Include(t => t.SwitchGearToCircuitBreaker)
                .Include(t => t.SwitchGearToCurrentTransformer)
                .Include(t => t.SwitchGearToDimensionAndWeight)
                .Include(t => t.SwitchGearToPhasePowerTransformer)
                .Include(t => t.SwitchGearToSf6SafetyAndLife)
                .Include(t => t.SwitchGearToSwitchPosition)
                .Include(t => t.SwitchGearToTripCircuitSupervisionRelay)
                .Include(t => t.SwitchGearToTripRelay)
                .Include(t => t.SwitchGearToVoltMeter)
                .Include(t => t.SwitchGearType);

            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblSwitchGears/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSwitchGear = await _context.TblSwitchGear
                .Include(t => t.SwitchGearToIdmtRelay)
                .Include(t => t.SwitchGearToAmpereMeter)
                .Include(t => t.SwitchGearToBusBar)
                .Include(t => t.SwitchGearToCircuitBreaker)
                .Include(t => t.SwitchGearToCurrentTransformer)
                .Include(t => t.SwitchGearToDimensionAndWeight)
                .Include(t => t.SwitchGearToPhasePowerTransformer)
                .Include(t => t.SwitchGearToSf6SafetyAndLife)
                .Include(t => t.SwitchGearToSwitchPosition)
                .Include(t => t.SwitchGearToTripCircuitSupervisionRelay)
                .Include(t => t.SwitchGearToTripRelay)
                .Include(t => t.SwitchGearToVoltMeter)
                .Include(t => t.SwitchGearType)
                .FirstOrDefaultAsync(m => m.SwitchGearID == id);

            if (tblSwitchGear == null)
            {
                return NotFound();
            }

            return View(tblSwitchGear);
        }

        // GET: TblSwitchGears/Create
        public IActionResult Create()
        {
            ViewData["IdmtRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["AmpereMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName");
            ViewData["BusBarId"] = new SelectList(_context.LookupBusBar, "BusBarId", "BusBarType");
            ViewData["CircuitBreakerId"] = new SelectList(_context.LookUpCircuitBreaker, "CircuitBreakerId", "ElectricalAndMechanicalInterlock");
            ViewData["CurrentTransformerId"] = new SelectList(_context.LookUpCurrentTransformer, "CurrentTransformerId", "AccuracyClassMetering");
            ViewData["DimensionAndWeightId"] = new SelectList(_context.LookUpDimensionAndWeight, "DimensionAndWeightId", "WeightIncludingCircuitBreaker");
            ViewData["PhasePowerTransformerId"] = new SelectList(_context.TblPhasePowerTransformer, "PhasePowerTransformerId", "DescriptionType");
            ViewData["Sf6SafetyAndLifeId"] = new SelectList(_context.LookupSf6SafetyAndLife, "Sf6SafetyAndLifeId", "LifeEnduranceOfSwitchgear");
            ViewData["SwitchPositionId"] = new SelectList(_context.LookUpSwitchPosition, "SwitchPositionId", "SwitchPositionId");
            ViewData["TripCircuitSupervisionRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["TripRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay");
            ViewData["VoltMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName");
            ViewData["SwitchGearTypeId"] = new SelectList(_context.LookUpSwitchGearType, "SwitchGearTypeId", "SwitchGearTypeName");

            return View();
        }

        // POST: TblSwitchGears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SwitchGearID,SwitchGearTypeId,ManufacturersNameAndAddress,AppliedStandard,RatedNominalVoltage,RatedVoltage,RatedCurrentForMainBus,RatedShortTimeCurrent,ShortTimeCurrentRatedDuration,CircuitBreakerId,IdmtRelayId,TripRelayId,TripCircuitSupervisionRelayId,CurrentTransformerId,SwitchPositionId,AcWithStandVoltageDry,ImpulseWithStandFullWave,Enclosure,HvCompartment,LvCompartment,Sf6SafetyAndLifeId,VoltMeterId,AmpereMeterId,BusBarId,ReatedVoltage,ReatedCurrent,ReatedShortCircuitBreakerCurrent,PhasePowerTransformerId,DimensionAndWeightId")] TblSwitchGear tblSwitchGear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSwitchGear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdmtRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.IdmtRelayId);
            ViewData["AmpereMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName", tblSwitchGear.AmpereMeterId);
            ViewData["BusBarId"] = new SelectList(_context.LookupBusBar, "BusBarId", "BusBarType", tblSwitchGear.BusBarId);
            ViewData["CircuitBreakerId"] = new SelectList(_context.LookUpCircuitBreaker, "CircuitBreakerId", "ElectricalAndMechanicalInterlock", tblSwitchGear.CircuitBreakerId);
            ViewData["CurrentTransformerId"] = new SelectList(_context.LookUpCurrentTransformer, "CurrentTransformerId", "AccuracyClassMetering", tblSwitchGear.CurrentTransformerId);
            ViewData["DimensionAndWeightId"] = new SelectList(_context.LookUpDimensionAndWeight, "DimensionAndWeightId", "WeightIncludingCircuitBreaker", tblSwitchGear.DimensionAndWeightId);
            ViewData["PhasePowerTransformerId"] = new SelectList(_context.TblPhasePowerTransformer, "PhasePowerTransformerId", "DescriptionType", tblSwitchGear.PhasePowerTransformerId);
            ViewData["Sf6SafetyAndLifeId"] = new SelectList(_context.LookupSf6SafetyAndLife, "Sf6SafetyAndLifeId", "LifeEnduranceOfSwitchgear", tblSwitchGear.Sf6SafetyAndLifeId);
            ViewData["SwitchPositionId"] = new SelectList(_context.LookUpSwitchPosition, "SwitchPositionId", "SwitchPositionId", tblSwitchGear.SwitchPositionId);
            ViewData["TripCircuitSupervisionRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.TripCircuitSupervisionRelayId);
            ViewData["TripRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.TripRelayId);
            ViewData["VoltMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName", tblSwitchGear.VoltMeterId);
            ViewData["SwitchGearTypeId"] = new SelectList(_context.LookUpSwitchGearType, "SwitchGearTypeId", "SwitchGearTypeName", tblSwitchGear.SwitchGearTypeId);
            return View(tblSwitchGear);
        }

        // GET: TblSwitchGears/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSwitchGear = await _context.TblSwitchGear.FindAsync(id);
            if (tblSwitchGear == null)
            {
                return NotFound();
            }
            ViewData["IdmtRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.IdmtRelayId);
            ViewData["AmpereMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName", tblSwitchGear.AmpereMeterId);
            ViewData["BusBarId"] = new SelectList(_context.LookupBusBar, "BusBarId", "BusBarType", tblSwitchGear.BusBarId);
            ViewData["CircuitBreakerId"] = new SelectList(_context.LookUpCircuitBreaker, "CircuitBreakerId", "ElectricalAndMechanicalInterlock", tblSwitchGear.CircuitBreakerId);
            ViewData["CurrentTransformerId"] = new SelectList(_context.LookUpCurrentTransformer, "CurrentTransformerId", "AccuracyClassMetering", tblSwitchGear.CurrentTransformerId);
            ViewData["DimensionAndWeightId"] = new SelectList(_context.LookUpDimensionAndWeight, "DimensionAndWeightId", "WeightIncludingCircuitBreaker", tblSwitchGear.DimensionAndWeightId);
            ViewData["PhasePowerTransformerId"] = new SelectList(_context.TblPhasePowerTransformer, "PhasePowerTransformerId", "DescriptionType", tblSwitchGear.PhasePowerTransformerId);
            ViewData["Sf6SafetyAndLifeId"] = new SelectList(_context.LookupSf6SafetyAndLife, "Sf6SafetyAndLifeId", "LifeEnduranceOfSwitchgear", tblSwitchGear.Sf6SafetyAndLifeId);
            ViewData["SwitchPositionId"] = new SelectList(_context.LookUpSwitchPosition, "SwitchPositionId", "SwitchPositionId", tblSwitchGear.SwitchPositionId);
            ViewData["TripCircuitSupervisionRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.TripCircuitSupervisionRelayId);
            ViewData["TripRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.TripRelayId);
            ViewData["VoltMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName", tblSwitchGear.VoltMeterId);
            ViewData["SwitchGearTypeId"] = new SelectList(_context.LookUpSwitchGearType, "SwitchGearTypeId", "SwitchGearTypeName", tblSwitchGear.SwitchGearTypeId);
            return View(tblSwitchGear);
        }

        // POST: TblSwitchGears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SwitchGearID,SwitchGearTypeId,ManufacturersNameAndAddress,AppliedStandard,RatedNominalVoltage,RatedVoltage,RatedCurrentForMainBus,RatedShortTimeCurrent,ShortTimeCurrentRatedDuration,CircuitBreakerId,IdmtRelayId,TripRelayId,TripCircuitSupervisionRelayId,CurrentTransformerId,SwitchPositionId,AcWithStandVoltageDry,ImpulseWithStandFullWave,Enclosure,HvCompartment,LvCompartment,Sf6SafetyAndLifeId,VoltMeterId,AmpereMeterId,BusBarId,ReatedVoltage,ReatedCurrent,ReatedShortCircuitBreakerCurrent,PhasePowerTransformerId,DimensionAndWeightId")] TblSwitchGear tblSwitchGear)
        {
            if (id != tblSwitchGear.SwitchGearID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSwitchGear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSwitchGearExists(tblSwitchGear.SwitchGearID))
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

            ViewData["IdmtRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.IdmtRelayId);
            ViewData["AmpereMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName", tblSwitchGear.AmpereMeterId);
            ViewData["BusBarId"] = new SelectList(_context.LookupBusBar, "BusBarId", "BusBarType", tblSwitchGear.BusBarId);
            ViewData["CircuitBreakerId"] = new SelectList(_context.LookUpCircuitBreaker, "CircuitBreakerId", "ElectricalAndMechanicalInterlock", tblSwitchGear.CircuitBreakerId);
            ViewData["CurrentTransformerId"] = new SelectList(_context.LookUpCurrentTransformer, "CurrentTransformerId", "AccuracyClassMetering", tblSwitchGear.CurrentTransformerId);
            ViewData["DimensionAndWeightId"] = new SelectList(_context.LookUpDimensionAndWeight, "DimensionAndWeightId", "WeightIncludingCircuitBreaker", tblSwitchGear.DimensionAndWeightId);
            ViewData["PhasePowerTransformerId"] = new SelectList(_context.TblPhasePowerTransformer, "PhasePowerTransformerId", "DescriptionType", tblSwitchGear.PhasePowerTransformerId);
            ViewData["Sf6SafetyAndLifeId"] = new SelectList(_context.LookupSf6SafetyAndLife, "Sf6SafetyAndLifeId", "LifeEnduranceOfSwitchgear", tblSwitchGear.Sf6SafetyAndLifeId);
            ViewData["SwitchPositionId"] = new SelectList(_context.LookUpSwitchPosition, "SwitchPositionId", "SwitchPositionId", tblSwitchGear.SwitchPositionId);
            ViewData["TripCircuitSupervisionRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.TripCircuitSupervisionRelayId);
            ViewData["TripRelayId"] = new SelectList(_context.LookUpDifferentRelay, "DifferentRelayId", "DifferentTypesOfRelay", tblSwitchGear.TripRelayId);
            ViewData["VoltMeterId"] = new SelectList(_context.LookUpDifferentMeter, "DifferentMeterId", "MeterName", tblSwitchGear.VoltMeterId);
            ViewData["SwitchGearTypeId"] = new SelectList(_context.LookUpSwitchGearType, "SwitchGearTypeId", "SwitchGearTypeName", tblSwitchGear.SwitchGearTypeId);

            return View(tblSwitchGear);
        }

        // GET: TblSwitchGears/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSwitchGear = await _context.TblSwitchGear
                .Include(t => t.SwitchGearToIdmtRelay)
                .Include(t => t.SwitchGearToAmpereMeter)
                .Include(t => t.SwitchGearToBusBar)
                .Include(t => t.SwitchGearToCircuitBreaker)
                .Include(t => t.SwitchGearToCurrentTransformer)
                .Include(t => t.SwitchGearToDimensionAndWeight)
                .Include(t => t.SwitchGearToPhasePowerTransformer)
                .Include(t => t.SwitchGearToSf6SafetyAndLife)
                .Include(t => t.SwitchGearToSwitchPosition)
                .Include(t => t.SwitchGearToTripCircuitSupervisionRelay)
                .Include(t => t.SwitchGearToTripRelay)
                .Include(t => t.SwitchGearToVoltMeter)
                .Include(t => t.SwitchGearType)
                .FirstOrDefaultAsync(m => m.SwitchGearID == id);
            if (tblSwitchGear == null)
            {
                return NotFound();
            }

            return View(tblSwitchGear);
        }

        // POST: TblSwitchGears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblSwitchGear = await _context.TblSwitchGear.FindAsync(id);
            _context.TblSwitchGear.Remove(tblSwitchGear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSwitchGearExists(string id)
        {
            return _context.TblSwitchGear.Any(e => e.SwitchGearID == id);
        }
    }
}
