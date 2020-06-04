using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Udf;
using Pdb014App.Models.PDB.DistributionTransformerModel;
using Pdb014App.Models.PDB.PoleModels;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.DtControllers
{
    public class TblDistributionTransformersController : Controller
    {
        private readonly PdbDbContext _context;

        public TblDistributionTransformersController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblDistributionTransformers
        public async Task<IActionResult> Index(string id)
        {
            var pdbDbContext = _context.TblDistributionTransformer.Include(t => t.DtToFeederLine).Include(t => t.DtToPole).Include(t => t.PoleStructureMountedSurgeArrestor);
            if (id != null)
            {
                pdbDbContext = _context.TblDistributionTransformer.Where(i=>i.PoleId==id).Include(t => t.DtToFeederLine).Include(t => t.DtToPole).Include(t => t.PoleStructureMountedSurgeArrestor);
            }
               
            return View(await pdbDbContext.ToListAsync());
        }

        public async Task<IActionResult> DistributionTransformerList(string poleId, int isShowLayout = 0, int isShowAction = 0)
        {
            //ViewBag.PoleId = poleId;
            ViewBag.IsShowLayout = isShowLayout;
            ViewBag.IsShowAction = isShowAction;


            var distributionTransformerList = _context.TblDistributionTransformer.Include(t => t.DtToFeederLine).Include(t => t.DtToPole).Include(t => t.PoleStructureMountedSurgeArrestor).AsNoTracking(); ;
            

            if (poleId != null)
            {
                distributionTransformerList = distributionTransformerList.Where(p => p.PoleId == poleId);
            }

            return View(await distributionTransformerList.ToListAsync());
        }

        // GET: TblDistributionTransformers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDistributionTransformer = await _context.TblDistributionTransformer
                .Include(t => t.DtToPole)
                .Include(t => t.DtToFeederLine)
                .Include(t => t.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(t => t.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(t => t.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)


                .Include(t => t.PoleStructureMountedSurgeArrestor)
                .FirstOrDefaultAsync(m => m.DistributionTransformerId == id);

            if (tblDistributionTransformer == null)
            {
                return NotFound();
            }

            return View(tblDistributionTransformer);
        }

        // GET: TblDistributionTransformers/Create
        public IActionResult Create()
        {
            //var poleIdList = _context.TblPole.AsNoTracking()
                //.Select(pi => new SelectListItem() {Text = pi.PoleId, Value = pi.PoleNo}).ToList();
            //ViewData["PoleId"] = poleIdList;

            //ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            //ViewData["PoleId"] = poleIdList;
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleNo");
           // ViewData["PoleId"] = new SelectList(_context.TblPole.AsNoTracking().Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList());
            ViewData["PoleStructureMountedSurgearrestorId"] = new SelectList(_context.TblPoleStructureMountedSurgearrestor, "PoleStructureMountedSurgeArrestorId", "PoleStructureMountedSurgeArrestorId");

            return View();
        }

        // POST: TblDistributionTransformers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistributionTransformerId,PoleStructureMountedSurgearrestorId,PoleId,FeederLineId,NameOf33bs11kVSubdsstation,Nameof11kVFeeder,SNDIdentificationNo,NearestHoldingbsHouseNobsShop,ExistingPoleNumberingifAny,InstalledConditionPadbsPoleMounted,InstalledPlaceIndoorbsOutdoor,ContractNo,OwneroftheTransformerBPDBbsConsumer,TransformerKVARating,YearofManufacturing,NameofManufacturer,TransformerSerialNo,RatedHTVoltage,RatedLTVoltage,RatedHTCurrent,RatedLTCurrent,ControlVoltage,MotorVoltageforspringcharge,RatedVoltage,BodyColourCondition,NameoBodyColour,OilLeakageYesOrNo,PlaceofOilLeakageMark,PlatformMaterialAnglbsChannel,PlatformStandardbsNonStandardGoodBad,TypeofTransformerSupportPoleLeft,ConditionofTransformerSupportPoleLeft,TypeofTransformerSupportPoleRight,ConditionofTransformerSupportPoleRight,HTBushingRPhaseOil,HTBushingRPhaseGood,HTBushingRPhaseColor,HTBushingYPhaseOil,HTBushingYPhaseGood,HTBushingYPhaseColor,HTBushingBPhaseOil,HTBushingBPhaseGood,HTBushingBPhaseColor,HTBushingNPhaseOil,HTBushingNPhaseGood,HTBushingNPhaseColor,LTBushingRPhaseOil,LTBushingRPhaseGood,LTBushingRPhaseColor,LTBushingYPhaseOil,LTBushingYPhaseGood,LTBushingYPhaseColor,LTBushingBPhaseOil,LTBushingBPhaseGood,LTBushingBPhaseColor,LTBushingNPhaseOil,LTBushingNPhaseGood,LTBushingNPhaseColor,WireSizeofHTDrop,ConditionofHTDropGoodbsBad,WirebsCableSizeofLTDropCKT1,ConditionofLTDropGoodbsBadCKT1,WirebsCableSizeofLTDropCKT2,ConditionofLTDropGoodbsBadCKT2,EarthingLead1,EarthingLead1Size,EarthingLead1Material,EarthingLead1ConditionStandard,EarthingLead2,EarthingLead2Size,EarthingLead2Material,EarthingLead2ConditionStandard,DayPeak,DateAndtime1,Voltage1,RYVoltageVolt1,YBVoltageVolt1,RBVoltageVolt1,RNVoltageVolt1,YNVoltageVolt1,BNVoltageVolt1,LeakageVoltageBodyEarthVolt1,RPhaseCurrentAmps1Ckt1,RPhaseCurrentAmps1Ckt2,RPhaseCurrentAmps1Ckt3,YPhaseCurrentAmps1Ckt1,YPhaseCurrentAmps1Ckt2,YPhaseCurrentAmps1Ckt3,BPhaseCurrentAmps1Ckt1,BPhaseCurrentAmps1Ckt2,BPhaseCurrentAmps1Ckt3,NeutralCurrentAmps1Ckt1,NeutralCurrentAmps1Ckt2,NeutralCurrentAmps1Ckt3,CalculatedDayPeakkVA,EveningPeak,DateAndTime2,Voltage2,RYVoltageVolt2,YBVoltageVolt2,RBVoltageVolt2,RNVoltageVolt2,YNVoltageVolt,BNVoltageVolt2,LeakageVoltageBodyEarthVolt2,RPhaseCurrentAmps2Ckt1,RPhaseCurrentAmps2Ckt2,RPhaseCurrentAmps2Ckt3,YPhaseCurrentAmps2Ckt1,YPhaseCurrentAmps2Ckt2,YPhaseCurrentAmps2Ckt3,BPhaseCurrentAmps2Ckt1,BPhaseCurrentAmps2Ckt2,BPhaseCurrentAmps2Ckt3,NeutralCurrentAmpsCkt1,NeutralCurrentAmps2Ckt2,NeutralCurrentAmps2Ckt3,CalculatedEveningPeakkVA,DropOutFuseExistbsNotExistRphase,DropOutFuseExistbsNotExistYphase,DropOutFuseExistbsNotExistBphase,ConditionofDropOutFuseRphase,ConditionofDropOutFuseYphase,ConditionofDropOutFuseBphase,LightningArrestorRphase,LightningArrestorYphase,LightningArrestorBphase,ConditionofLightingArrestorRphase,ConditionofLightingArrestorYphase,ConditionofLightingArrestorBphase,DistributionBoxExistbsnotExist,ConditionofDistributionBox,NoOfMCCB,ManufacturerTypeOriginofMCCBforCircuit1,ManufacturerTypeOriginofMCCBforCircuit2,AmpereRatingasPerNamePlateofMCCBforCKT1,AmpereRatingasPerNameplateOfMCCBForCKT2,ConditionofMCCBforCircuit1,ConditionofMCCBforCircuit2,Recommendation")] TblDistributionTransformer tblDistributionTransformer)
        {

            string findDtId = _context.TblDistributionTransformer.Where(i => i.PoleId == tblDistributionTransformer.PoleId).OrderBy(u => u.DistributionTransformerId).Select(u => u.DistributionTransformerId).LastOrDefault();

            if (findDtId == null)
            {
                findDtId = tblDistributionTransformer.PoleId + "001";
            }
            else
            {
                findDtId = (Convert.ToInt64(findDtId) + 1).ToString();
            }

            if (ModelState.IsValid)
            {
                

                tblDistributionTransformer.DistributionTransformerId = findDtId;

                tblDistributionTransformer.FeederLineId = findDtId.Substring(0, 11);
                _context.Add(tblDistributionTransformer);
                await _context.SaveChangesAsync();
                TempData["statuMessageSuccess"] = "Distribution Transformer has been added successfully under pole id "+ tblDistributionTransformer.PoleId;
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "TblPoles");
            }

            //ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblDistributionTransformer.FeederLineId);
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblDistributionTransformer.PoleId);
            ViewData["PoleStructureMountedSurgearrestorId"] = new SelectList(_context.TblPoleStructureMountedSurgearrestor, "PoleStructureMountedSurgeArrestorId", "PoleStructureMountedSurgeArrestorId", tblDistributionTransformer.PoleStructureMountedSurgearrestorId);

            return View(tblDistributionTransformer);
        }

        // GET: TblDistributionTransformers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDistributionTransformer = await _context.TblDistributionTransformer.FindAsync(id);
            if (tblDistributionTransformer == null)
            {
                return NotFound();
            }
            //ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblDistributionTransformer.FeederLineId);
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblDistributionTransformer.PoleId);
            ViewData["PoleStructureMountedSurgearrestorId"] = new SelectList(_context.TblPoleStructureMountedSurgearrestor, "PoleStructureMountedSurgeArrestorId", "PoleStructureMountedSurgeArrestorId", tblDistributionTransformer.PoleStructureMountedSurgearrestorId);
            return View(tblDistributionTransformer);
        }

        // POST: TblDistributionTransformers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DistributionTransformerId,PoleStructureMountedSurgearrestorId,PoleId,FeederLineId,NameOf33bs11kVSubdsstation,Nameof11kVFeeder,SNDIdentificationNo,NearestHoldingbsHouseNobsShop,ExistingPoleNumberingifAny,InstalledConditionPadbsPoleMounted,InstalledPlaceIndoorbsOutdoor,ContractNo,OwneroftheTransformerBPDBbsConsumer,TransformerKVARating,YearofManufacturing,NameofManufacturer,TransformerSerialNo,RatedHTVoltage,RatedLTVoltage,RatedHTCurrent,RatedLTCurrent,ControlVoltage,MotorVoltageforspringcharge,RatedVoltage,BodyColourCondition,NameoBodyColour,OilLeakageYesOrNo,PlaceofOilLeakageMark,PlatformMaterialAnglbsChannel,PlatformStandardbsNonStandardGoodBad,TypeofTransformerSupportPoleLeft,ConditionofTransformerSupportPoleLeft,TypeofTransformerSupportPoleRight,ConditionofTransformerSupportPoleRight,HTBushingRPhaseOil,HTBushingRPhaseGood,HTBushingRPhaseColor,HTBushingYPhaseOil,HTBushingYPhaseGood,HTBushingYPhaseColor,HTBushingBPhaseOil,HTBushingBPhaseGood,HTBushingBPhaseColor,HTBushingNPhaseOil,HTBushingNPhaseGood,HTBushingNPhaseColor,LTBushingRPhaseOil,LTBushingRPhaseGood,LTBushingRPhaseColor,LTBushingYPhaseOil,LTBushingYPhaseGood,LTBushingYPhaseColor,LTBushingBPhaseOil,LTBushingBPhaseGood,LTBushingBPhaseColor,LTBushingNPhaseOil,LTBushingNPhaseGood,LTBushingNPhaseColor,WireSizeofHTDrop,ConditionofHTDropGoodbsBad,WirebsCableSizeofLTDropCKT1,ConditionofLTDropGoodbsBadCKT1,WirebsCableSizeofLTDropCKT2,ConditionofLTDropGoodbsBadCKT2,EarthingLead1,EarthingLead1Size,EarthingLead1Material,EarthingLead1ConditionStandard,EarthingLead2,EarthingLead2Size,EarthingLead2Material,EarthingLead2ConditionStandard,DayPeak,DateAndtime1,Voltage1,RYVoltageVolt1,YBVoltageVolt1,RBVoltageVolt1,RNVoltageVolt1,YNVoltageVolt1,BNVoltageVolt1,LeakageVoltageBodyEarthVolt1,RPhaseCurrentAmps1Ckt1,RPhaseCurrentAmps1Ckt2,RPhaseCurrentAmps1Ckt3,YPhaseCurrentAmps1Ckt1,YPhaseCurrentAmps1Ckt2,YPhaseCurrentAmps1Ckt3,BPhaseCurrentAmps1Ckt1,BPhaseCurrentAmps1Ckt2,BPhaseCurrentAmps1Ckt3,NeutralCurrentAmps1Ckt1,NeutralCurrentAmps1Ckt2,NeutralCurrentAmps1Ckt3,CalculatedDayPeakkVA,EveningPeak,DateAndTime2,Voltage2,RYVoltageVolt2,YBVoltageVolt2,RBVoltageVolt2,RNVoltageVolt2,YNVoltageVolt,BNVoltageVolt2,LeakageVoltageBodyEarthVolt2,RPhaseCurrentAmps2Ckt1,RPhaseCurrentAmps2Ckt2,RPhaseCurrentAmps2Ckt3,YPhaseCurrentAmps2Ckt1,YPhaseCurrentAmps2Ckt2,YPhaseCurrentAmps2Ckt3,BPhaseCurrentAmps2Ckt1,BPhaseCurrentAmps2Ckt2,BPhaseCurrentAmps2Ckt3,NeutralCurrentAmpsCkt1,NeutralCurrentAmps2Ckt2,NeutralCurrentAmps2Ckt3,CalculatedEveningPeakkVA,DropOutFuseExistbsNotExistRphase,DropOutFuseExistbsNotExistYphase,DropOutFuseExistbsNotExistBphase,ConditionofDropOutFuseRphase,ConditionofDropOutFuseYphase,ConditionofDropOutFuseBphase,LightningArrestorRphase,LightningArrestorYphase,LightningArrestorBphase,ConditionofLightingArrestorRphase,ConditionofLightingArrestorYphase,ConditionofLightingArrestorBphase,DistributionBoxExistbsnotExist,ConditionofDistributionBox,NoOfMCCB,ManufacturerTypeOriginofMCCBforCircuit1,ManufacturerTypeOriginofMCCBforCircuit2,AmpereRatingasPerNamePlateofMCCBforCKT1,AmpereRatingasPerNameplateOfMCCBForCKT2,ConditionofMCCBforCircuit1,ConditionofMCCBforCircuit2,Recommendation")] TblDistributionTransformer tblDistributionTransformer)
        {
            if (id != tblDistributionTransformer.DistributionTransformerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDistributionTransformer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDistributionTransformerExists(tblDistributionTransformer.DistributionTransformerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["statuMessageSuccess"] = "Distribution Transformer has been Updated successfully under pole id " + tblDistributionTransformer.PoleId;
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "TblPoles");
            }
            //ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblDistributionTransformer.FeederLineId);
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblDistributionTransformer.PoleId);
            ViewData["PoleStructureMountedSurgearrestorId"] = new SelectList(_context.TblPoleStructureMountedSurgearrestor, "PoleStructureMountedSurgeArrestorId", "PoleStructureMountedSurgeArrestorId", tblDistributionTransformer.PoleStructureMountedSurgearrestorId);
            return View(tblDistributionTransformer);
        }

        // GET: TblDistributionTransformers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDistributionTransformer = await _context.TblDistributionTransformer
                .Include(t => t.DtToFeederLine)
                .Include(t => t.DtToPole)
                .Include(t => t.PoleStructureMountedSurgeArrestor)
                .FirstOrDefaultAsync(m => m.DistributionTransformerId == id);
            if (tblDistributionTransformer == null)
            {
                return NotFound();
            }

            return View(tblDistributionTransformer);
        }

        // POST: TblDistributionTransformers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblDistributionTransformer = await _context.TblDistributionTransformer.FindAsync(id);
            _context.TblDistributionTransformer.Remove(tblDistributionTransformer);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            TempData["statuMessageSuccess"] = "Distribution Transformer has been Deleted successfully under pole id " + tblDistributionTransformer.PoleId;
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "TblPoles");
        }

        private bool TblDistributionTransformerExists(string id)
        {
            return _context.TblDistributionTransformer.Any(e => e.DistributionTransformerId == id);
        }
    }
}
