using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.PhasePowerTransformerModel;
using Pdb014App.Repository;


namespace Pdb014App.Controllers.PtControllers
{
    public class TblPhasePowerTransformersController : Controller
    {
        private readonly PdbDbContext _context;

        public TblPhasePowerTransformersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblPhasePowerTransformers
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblPhasePowerTransformer.Include(t => t.PhasePowerTransformerTo33KvFeederLine).Include(t => t.PhasePowerTransformerToSourceSubstation).Include(t => t.PhasePowerTransformerToTblSubstation);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblPhasePowerTransformers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhasePowerTransformer = await _context.TblPhasePowerTransformer
                .Include(t => t.PhasePowerTransformerTo33KvFeederLine)
                .Include(t => t.PhasePowerTransformerToSourceSubstation)
                .Include(t => t.PhasePowerTransformerToTblSubstation)
                .FirstOrDefaultAsync(m => m.PhasePowerTransformerId == id);
            if (tblPhasePowerTransformer == null)
            {
                return NotFound();
            }

            return View(tblPhasePowerTransformer);
        }

        // GET: TblPhasePowerTransformers/Create
        public IActionResult Create()
        {
            ViewData["FeederID33KvId"] = new SelectList(_context.TblFeederLine.Where(i=>i.FeederLineTypeId=="1"), "FeederLineId", "FeederName");
            ViewData["Source132or33kVSubstationId"] = new SelectList(_context.TblSubstation.Where(i => i.SubstationTypeId == "1"), "SubstationId", "SubstationName");
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationName");
            return View();
        }

        // POST: TblPhasePowerTransformers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhasePowerTransformerId,ManufacturersName,ManufacturersAddress,AppliedStandard,DescriptionType,SerialNumber,RatedPower,NumberofPhase,RatedVoltagePhaseToPhase,HighVoltageWindingPhaseToPhase,LowVoltageWindingPhaseToPhase,RatedFrequency,RatedInsulationLevel,ImpulseWithStandFullWave,ImpulseHighVoltageWinding,ImpulseLowVoltageWinding,ACWithStandVoltage,ACHighVoltageWinding,ACLowVoltageWinding,TypeOfCooling28or35MVA,OnLoadTapChanger,TypeTap,TappingRangeHT,LocationOfTap,OilVolume,OneStepChange,MotorRating,ImpedanceVoltageAt75CAndAtNominalRatio,TemperatureRiseAtRatedPowerMaxAmbientTemperature40C,FiveMva,SixPointSixMva,OilByThermometer,WindingByResistanceMeasurement,TemperatureGradientBetweenWindingsAndOil,ShortCircuitlevelAtTerminal,ThirtyThreeKv,EleventKv,TransformerCore,TypeofCoreAndFluxEnsityAtNominalVoltage,TransformerBushings,HVBushing,HVBushingType,LVBushing,LVBushingType,NeutralBushing,NeutralBushingType,ConservatorWithAirSealedBagForConstantOilPressurYesNo,BreatherSilicagel,AuxiliaryCircuitVoltageForFanetc3P4W,ControlVoltage,SoundLevelIEC551,ONAN,ONAF,BushingCTParticulars,HVside,LVside,NeutralSide,NumberofCoolingFan,RatingOfFanMotors,CoolingFanLossesAtFullOnafCapacityOperation,CoreLossAtRatedFrequencyAndRatedVoltageAtNominalTapNoLoadLoss,CopperLossAtfullloadAtRatedFrequencyAndAt75CFullLoadLoss,AtMaximumTap,AtNominalTap,AtMinimumTap,RadiatorsYesNo,OverallDimensions,NoOfRadiators,SupervisoryAlarmAndTripContactsYesNo,TemperatureIndicatorsYesNo,MakeAndType,AlarmAndTripRange,NoOfContacts,CurrentRatingOfContacts,SupervisoryAlarmContact,DimensionsAndWeightMaximumSizeForTransport,LMulWMulH,WeightOFoil,WeightofCore,TotalWeight,SanctionedLoad,MaximumLoad,FeederID33KvId,SubstationId,Source132or33kVSubstationId")] TblPhasePowerTransformer tblPhasePowerTransformer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPhasePowerTransformer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeederID33KvId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblPhasePowerTransformer.FeederID33KvId);
            ViewData["Source132or33kVSubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblPhasePowerTransformer.Source132or33kVSubstationId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblPhasePowerTransformer.SubstationId);
            return View(tblPhasePowerTransformer);
        }

        // GET: TblPhasePowerTransformers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhasePowerTransformer = await _context.TblPhasePowerTransformer.FindAsync(id);
            if (tblPhasePowerTransformer == null)
            {
                return NotFound();
            }
            ViewData["FeederID33KvId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblPhasePowerTransformer.FeederID33KvId);
            ViewData["Source132or33kVSubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblPhasePowerTransformer.Source132or33kVSubstationId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblPhasePowerTransformer.SubstationId);
            return View(tblPhasePowerTransformer);
        }

        // POST: TblPhasePowerTransformers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PhasePowerTransformerId,ManufacturersName,ManufacturersAddress,AppliedStandard,DescriptionType,SerialNumber,RatedPower,NumberofPhase,RatedVoltagePhaseToPhase,HighVoltageWindingPhaseToPhase,LowVoltageWindingPhaseToPhase,RatedFrequency,RatedInsulationLevel,ImpulseWithStandFullWave,ImpulseHighVoltageWinding,ImpulseLowVoltageWinding,ACWithStandVoltage,ACHighVoltageWinding,ACLowVoltageWinding,TypeOfCooling28or35MVA,OnLoadTapChanger,TypeTap,TappingRangeHT,LocationOfTap,OilVolume,OneStepChange,MotorRating,ImpedanceVoltageAt75CAndAtNominalRatio,TemperatureRiseAtRatedPowerMaxAmbientTemperature40C,FiveMva,SixPointSixMva,OilByThermometer,WindingByResistanceMeasurement,TemperatureGradientBetweenWindingsAndOil,ShortCircuitlevelAtTerminal,ThirtyThreeKv,EleventKv,TransformerCore,TypeofCoreAndFluxEnsityAtNominalVoltage,TransformerBushings,HVBushing,HVBushingType,LVBushing,LVBushingType,NeutralBushing,NeutralBushingType,ConservatorWithAirSealedBagForConstantOilPressurYesNo,BreatherSilicagel,AuxiliaryCircuitVoltageForFanetc3P4W,ControlVoltage,SoundLevelIEC551,ONAN,ONAF,BushingCTParticulars,HVside,LVside,NeutralSide,NumberofCoolingFan,RatingOfFanMotors,CoolingFanLossesAtFullOnafCapacityOperation,CoreLossAtRatedFrequencyAndRatedVoltageAtNominalTapNoLoadLoss,CopperLossAtfullloadAtRatedFrequencyAndAt75CFullLoadLoss,AtMaximumTap,AtNominalTap,AtMinimumTap,RadiatorsYesNo,OverallDimensions,NoOfRadiators,SupervisoryAlarmAndTripContactsYesNo,TemperatureIndicatorsYesNo,MakeAndType,AlarmAndTripRange,NoOfContacts,CurrentRatingOfContacts,SupervisoryAlarmContact,DimensionsAndWeightMaximumSizeForTransport,LMulWMulH,WeightOFoil,WeightofCore,TotalWeight,SanctionedLoad,MaximumLoad,FeederID33KvId,SubstationId,Source132or33kVSubstationId")] TblPhasePowerTransformer tblPhasePowerTransformer)
        {
            if (id != tblPhasePowerTransformer.PhasePowerTransformerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPhasePowerTransformer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPhasePowerTransformerExists(tblPhasePowerTransformer.PhasePowerTransformerId))
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
            ViewData["FeederID33KvId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblPhasePowerTransformer.FeederID33KvId);
            ViewData["Source132or33kVSubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblPhasePowerTransformer.Source132or33kVSubstationId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation, "SubstationId", "SubstationId", tblPhasePowerTransformer.SubstationId);
            return View(tblPhasePowerTransformer);
        }

        // GET: TblPhasePowerTransformers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhasePowerTransformer = await _context.TblPhasePowerTransformer
                .Include(t => t.PhasePowerTransformerTo33KvFeederLine)
                .Include(t => t.PhasePowerTransformerToSourceSubstation)
                .Include(t => t.PhasePowerTransformerToTblSubstation)
                .FirstOrDefaultAsync(m => m.PhasePowerTransformerId == id);
            if (tblPhasePowerTransformer == null)
            {
                return NotFound();
            }

            return View(tblPhasePowerTransformer);
        }

        // POST: TblPhasePowerTransformers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblPhasePowerTransformer = await _context.TblPhasePowerTransformer.FindAsync(id);
            _context.TblPhasePowerTransformer.Remove(tblPhasePowerTransformer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPhasePowerTransformerExists(string id)
        {
            return _context.TblPhasePowerTransformer.Any(e => e.PhasePowerTransformerId == id);
        }
    }
}
