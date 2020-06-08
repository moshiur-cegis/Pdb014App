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



        public async Task<IActionResult> PtList(string substationId, int isShowLayout = 0, int isShowAction = 0)
        {
            ViewBag.IsShowLayout = isShowLayout;
            ViewBag.IsShowAction = isShowAction;
            ViewBag.SubstationId = substationId;

            var ptList = _context.TblPhasePowerTransformer.Include(t => t.PhasePowerTransformerTo33KvFeederLine).Include(t => t.PhasePowerTransformerToSourceSubstation).Include(t => t.PhasePowerTransformerToTblSubstation).AsNoTracking();


            if (substationId != null)
            {
                ptList = ptList.Where(p => p.SubstationId == substationId);
            }

            return View(await ptList.ToListAsync());
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
        public IActionResult Create(string id)
        {
            ViewData["FeederID33KvId"] = new SelectList(_context.TblFeederLine.Where(i=>i.FeederLineTypeId=="1" && i.FeederLineToRoute.RouteToSubstation.SubstationId== id), "FeederLineId", "FeederName");
            ViewData["Source132or33kVSubstationId"] = new SelectList(_context.TblSubstation.Where(i => i.SubstationTypeId == "1" && i.SubstationId== id), "SubstationId", "SubstationName");
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation.Where(i=>i.SubstationId== id), "SubstationId", "SubstationName");
            return View();
        }

        // POST: TblPhasePowerTransformers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhasePowerTransformerId,ManufacturersName,ManufacturersAddress,AppliedStandard,DescriptionType,SerialNumber,RatedPower,NumberofPhase,RatedVoltagePhaseToPhase,HighVoltageWindingPhaseToPhase,LowVoltageWindingPhaseToPhase,RatedFrequency,RatedInsulationLevel,ImpulseWithStandFullWave,ImpulseHighVoltageWinding,ImpulseLowVoltageWinding,ACWithStandVoltage,ACHighVoltageWinding,ACLowVoltageWinding,TypeOfCooling28or35MVA,OnLoadTapChanger,TypeTap,TappingRangeHT,LocationOfTap,OilVolume,OneStepChange,MotorRating,ImpedanceVoltageAt75CAndAtNominalRatio,TemperatureRiseAtRatedPowerMaxAmbientTemperature40C,FiveMva,SixPointSixMva,OilByThermometer,WindingByResistanceMeasurement,TemperatureGradientBetweenWindingsAndOil,ShortCircuitlevelAtTerminal,ThirtyThreeKv,EleventKv,TransformerCore,TypeofCoreAndFluxEnsityAtNominalVoltage,TransformerBushings,HVBushing,HVBushingType,LVBushing,LVBushingType,NeutralBushing,NeutralBushingType,ConservatorWithAirSealedBagForConstantOilPressurYesNo,BreatherSilicagel,AuxiliaryCircuitVoltageForFanetc3P4W,ControlVoltage,SoundLevelIEC551,ONAN,ONAF,BushingCTParticulars,HVside,LVside,NeutralSide,NumberofCoolingFan,RatingOfFanMotors,CoolingFanLossesAtFullOnafCapacityOperation,CoreLossAtRatedFrequencyAndRatedVoltageAtNominalTapNoLoadLoss,CopperLossAtfullloadAtRatedFrequencyAndAt75CFullLoadLoss,AtMaximumTap,AtNominalTap,AtMinimumTap,RadiatorsYesNo,OverallDimensions,NoOfRadiators,SupervisoryAlarmAndTripContactsYesNo,TemperatureIndicatorsYesNo,MakeAndType,AlarmAndTripRange,NoOfContacts,CurrentRatingOfContacts,SupervisoryAlarmContact,DimensionsAndWeightMaximumSizeForTransport,LMulWMulH,WeightOFoil,WeightofCore,TotalWeight,SanctionedLoad,MaximumLoad,FeederID33KvId,SubstationId,Source132or33kVSubstationId")] TblPhasePowerTransformer tblPhasePowerTransformer)
        {


            string findId = _context.TblPhasePowerTransformer.Where(i => i.SubstationId == tblPhasePowerTransformer.SubstationId).OrderBy(u => u.PhasePowerTransformerId).Select(u => u.PhasePowerTransformerId).LastOrDefault();

            if (findId == null)
            {
                findId = tblPhasePowerTransformer.SubstationId + "001";
            }
            else
            {
                findId = (Convert.ToInt64(findId) + 1).ToString();
            }



            if (ModelState.IsValid)
            {
                tblPhasePowerTransformer.PhasePowerTransformerId = findId;
                _context.Add(tblPhasePowerTransformer);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                TempData["statuMessageSuccess"] = "Phase Power Transformer has been added Successfully under substation id: " + tblPhasePowerTransformer.SubstationId;
                return RedirectToAction("Index", "TblSubstations");
            }
            ViewData["FeederID33KvId"] = new SelectList(_context.TblFeederLine.Where(i => i.FeederLineTypeId == "1" && i.FeederLineToRoute.RouteToSubstation.SubstationId == tblPhasePowerTransformer.SubstationId), "FeederLineId", "FeederName", tblPhasePowerTransformer.FeederID33KvId);
            ViewData["Source132or33kVSubstationId"] = new SelectList(_context.TblSubstation.Where(i => i.SubstationTypeId == "1" && i.SubstationId == tblPhasePowerTransformer.SubstationId), "SubstationId", "SubstationName", tblPhasePowerTransformer.Source132or33kVSubstationId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation.Where(i => i.SubstationId == tblPhasePowerTransformer.SubstationId), "SubstationId", "SubstationName", tblPhasePowerTransformer.SubstationId);
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
            ViewData["FeederID33KvId"] = new SelectList(_context.TblFeederLine.Where(i => i.FeederLineTypeId == "1" && i.FeederLineToRoute.RouteToSubstation.SubstationId == tblPhasePowerTransformer.SubstationId), "FeederLineId", "FeederName", tblPhasePowerTransformer.FeederID33KvId);
            ViewData["Source132or33kVSubstationId"] = new SelectList(_context.TblSubstation.Where(i => i.SubstationTypeId == "1" && i.SubstationId == tblPhasePowerTransformer.SubstationId), "SubstationId", "SubstationName", tblPhasePowerTransformer.Source132or33kVSubstationId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation.Where(i => i.SubstationId == tblPhasePowerTransformer.SubstationId), "SubstationId", "SubstationName", tblPhasePowerTransformer.SubstationId);
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
                TempData["statuMessageSuccess"] = "Phase Power Transformer has been updated Successfully under subtation id: " + tblPhasePowerTransformer.SubstationId;
                return RedirectToAction("Index", "TblSubstations");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["FeederID33KvId"] = new SelectList(_context.TblFeederLine.Where(i => i.FeederLineTypeId == "1" && i.FeederLineToRoute.RouteToSubstation.SubstationId == tblPhasePowerTransformer.SubstationId), "FeederLineId", "FeederName", tblPhasePowerTransformer.FeederID33KvId);
            ViewData["Source132or33kVSubstationId"] = new SelectList(_context.TblSubstation.Where(i => i.SubstationTypeId == "1" && i.SubstationId == tblPhasePowerTransformer.SubstationId), "SubstationId", "SubstationName", tblPhasePowerTransformer.Source132or33kVSubstationId);
            ViewData["SubstationId"] = new SelectList(_context.TblSubstation.Where(i => i.SubstationId == tblPhasePowerTransformer.SubstationId), "SubstationId", "SubstationName", tblPhasePowerTransformer.SubstationId);
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
            //return RedirectToAction(nameof(Index));

            TempData["statuMessageSuccess"] = "Phase Power Transformer has been deleted Successfully under substation id: " + tblPhasePowerTransformer.SubstationId;
            return RedirectToAction("Index", "TblSubstations");
        }

        private bool TblPhasePowerTransformerExists(string id)
        {
            return _context.TblPhasePowerTransformer.Any(e => e.PhasePowerTransformerId == id);
        }
    }
}
