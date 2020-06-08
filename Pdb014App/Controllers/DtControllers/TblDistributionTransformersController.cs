using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.DistributionTransformerModel;
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
            var pdbDbContext = _context.TblDistributionTransformer.Include(t => t.HTBushingBPhaseGoodToCondition).Include(t => t.BodyColourConditiontoBodyColourCondition).Include(t => t.ConditionofDistributionBoxToCondition).Include(t => t.ConditionofDropOutFuseBphaseToCondition).Include(t => t.ConditionofDropOutFuseRphaseToCondition).Include(t => t.ConditionofDropOutFuseYphaseToCondition).Include(t => t.ConditionofHTDropGoodbsBadToCondition).Include(t => t.ConditionofLTDropGoodbsBadCKT1ToCondition).Include(t => t.ConditionofLTDropGoodbsBadCKT2ToCondition).Include(t => t.ConditionofLightingArrestorBphaseToCondition).Include(t => t.ConditionofLightingArrestorRphaseToCondition).Include(t => t.ConditionofLightingArrestorYphaseToCondition).Include(t => t.ConditionofMCCBforCircuit1ToCondition).Include(t => t.ConditionofMCCBforCircuit2ToCondition).Include(t => t.ConditionofTransformerSupportPoleLeftToLeftRightCondition).Include(t => t.ConditionofTransformerSupportPoleRightToLeftRightCondition).Include(t => t.DtToFeederLine).Include(t => t.DtToPole).Include(t => t.EarthingLead1ConditionStandardToCondition).Include(t => t.EarthingLead2ConditionStandardToCondition).Include(t => t.HTBushingNPhaseGoodToCondition).Include(t => t.HTBushingRPhaseGoodToCondition).Include(t => t.HTBushingYPhaseGoodToCondition).Include(t => t.InstalledConditionPadbsPoleMountedToInstalledCondition).Include(t => t.InstalledPlaceIndoorbsOutdoorToInstalledPlace).Include(t => t.LTBushingBPhaseGoodToCondition).Include(t => t.LTBushingNPhaseGoodToCondition).Include(t => t.LTBushingRPhaseGoodToCondition).Include(t => t.LTBushingYPhaseGoodToCondition).Include(t => t.OwneroftheTransformerBPDBbsConsumerToTransformerOwner).Include(t => t.PlatformMaterialAnglbsChannelTolatformMaterial).Include(t => t.PlatformStandardbsNonStandardGoodBadToCondition).Include(t => t.TypeofTransformerSupportPoleLeftToLeftRightType).Include(t => t.TypeofTransformerSupportPoleRightToLeftRightType).AsNoTracking();
            
            if (id != null)
            {
                pdbDbContext = pdbDbContext.Where(i => i.PoleId == id);
            }

                return View(await pdbDbContext.ToListAsync());
        }

        public async Task<IActionResult> DistributionTransformerList(string poleId, int isShowLayout = 0, int isShowAction = 0)
        {
            ViewBag.PoleId = poleId;
            ViewBag.IsShowLayout = isShowLayout;
            ViewBag.IsShowAction = isShowAction;


            var distributionTransformerList = _context.TblDistributionTransformer.Include(t => t.HTBushingBPhaseGoodToCondition).Include(t => t.BodyColourConditiontoBodyColourCondition).Include(t => t.ConditionofDistributionBoxToCondition).Include(t => t.ConditionofDropOutFuseBphaseToCondition).Include(t => t.ConditionofDropOutFuseRphaseToCondition).Include(t => t.ConditionofDropOutFuseYphaseToCondition).Include(t => t.ConditionofHTDropGoodbsBadToCondition).Include(t => t.ConditionofLTDropGoodbsBadCKT1ToCondition).Include(t => t.ConditionofLTDropGoodbsBadCKT2ToCondition).Include(t => t.ConditionofLightingArrestorBphaseToCondition).Include(t => t.ConditionofLightingArrestorRphaseToCondition).Include(t => t.ConditionofLightingArrestorYphaseToCondition).Include(t => t.ConditionofMCCBforCircuit1ToCondition).Include(t => t.ConditionofMCCBforCircuit2ToCondition).Include(t => t.ConditionofTransformerSupportPoleLeftToLeftRightCondition).Include(t => t.ConditionofTransformerSupportPoleRightToLeftRightCondition).Include(t => t.DtToFeederLine).Include(t => t.DtToPole).Include(t => t.EarthingLead1ConditionStandardToCondition).Include(t => t.EarthingLead2ConditionStandardToCondition).Include(t => t.HTBushingNPhaseGoodToCondition).Include(t => t.HTBushingRPhaseGoodToCondition).Include(t => t.HTBushingYPhaseGoodToCondition).Include(t => t.InstalledConditionPadbsPoleMountedToInstalledCondition).Include(t => t.InstalledPlaceIndoorbsOutdoorToInstalledPlace).Include(t => t.LTBushingBPhaseGoodToCondition).Include(t => t.LTBushingNPhaseGoodToCondition).Include(t => t.LTBushingRPhaseGoodToCondition).Include(t => t.LTBushingYPhaseGoodToCondition).Include(t => t.OwneroftheTransformerBPDBbsConsumerToTransformerOwner).Include(t => t.PlatformMaterialAnglbsChannelTolatformMaterial).Include(t => t.PlatformStandardbsNonStandardGoodBadToCondition).Include(t => t.TypeofTransformerSupportPoleLeftToLeftRightType).Include(t => t.TypeofTransformerSupportPoleRightToLeftRightType).AsNoTracking();

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
                .Include(t => t.BodyColourConditiontoBodyColourCondition)
                .Include(t => t.ConditionofDistributionBoxToCondition)
                .Include(t => t.ConditionofDropOutFuseBphaseToCondition)
                .Include(t => t.ConditionofDropOutFuseRphaseToCondition)
                .Include(t => t.ConditionofDropOutFuseYphaseToCondition)
                .Include(t => t.ConditionofHTDropGoodbsBadToCondition)
                .Include(t => t.ConditionofLTDropGoodbsBadCKT1ToCondition)
                .Include(t => t.ConditionofLTDropGoodbsBadCKT2ToCondition)
                .Include(t => t.ConditionofLightingArrestorBphaseToCondition)
                .Include(t => t.ConditionofLightingArrestorRphaseToCondition)
                .Include(t => t.ConditionofLightingArrestorYphaseToCondition)
                .Include(t => t.ConditionofMCCBforCircuit1ToCondition)
                .Include(t => t.ConditionofMCCBforCircuit2ToCondition)
                .Include(t => t.ConditionofTransformerSupportPoleLeftToLeftRightCondition)
                .Include(t => t.ConditionofTransformerSupportPoleRightToLeftRightCondition)
                .Include(t => t.DtToFeederLine)
                .Include(t => t.DtToPole)

                .Include(t => t.EarthingLead1ConditionStandardToCondition)
                .Include(t => t.EarthingLead2ConditionStandardToCondition)
                .Include(t => t.HTBushingNPhaseGoodToCondition)
                .Include(t => t.HTBushingRPhaseGoodToCondition)
                .Include(t => t.HTBushingYPhaseGoodToCondition)
                .Include(t=>t.HTBushingBPhaseGoodToCondition)
                .Include(t => t.InstalledConditionPadbsPoleMountedToInstalledCondition)
                .Include(t => t.InstalledPlaceIndoorbsOutdoorToInstalledPlace)
                .Include(t => t.LTBushingBPhaseGoodToCondition)
                .Include(t => t.LTBushingNPhaseGoodToCondition)
                .Include(t => t.LTBushingRPhaseGoodToCondition)
                .Include(t => t.LTBushingYPhaseGoodToCondition)
                .Include(t => t.OwneroftheTransformerBPDBbsConsumerToTransformerOwner)
                .Include(t => t.PlatformMaterialAnglbsChannelTolatformMaterial)
                .Include(t => t.PlatformStandardbsNonStandardGoodBadToCondition)
                .Include(t => t.TypeofTransformerSupportPoleLeftToLeftRightType)
                .Include(t => t.TypeofTransformerSupportPoleRightToLeftRightType)
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
            ViewData["BodyColourCondition"] = new SelectList(_context.LookUpBodyColourCondition, "Id", "Name");
            ViewData["ConditionofDistributionBox"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofDropOutFuseBphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofDropOutFuseRphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofDropOutFuseYphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofHTDropGoodbsBad"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofLTDropGoodbsBadCKT1"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofLTDropGoodbsBadCKT2"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofLightingArrestorBphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofLightingArrestorRphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofLightingArrestorYphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofMCCBforCircuit1"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofMCCBforCircuit2"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["ConditionofTransformerSupportPoleLeft"] = new SelectList(_context.LookUpSupportPoleLeftRightCondition, "Id", "Name");
            ViewData["ConditionofTransformerSupportPoleRight"] = new SelectList(_context.LookUpSupportPoleLeftRightCondition, "Id", "Name");
            //ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId");
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            ViewData["EarthingLead1ConditionStandard"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["EarthingLead2ConditionStandard"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["HTBushingNPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["HTBushingRPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["HTBushingYPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");

            ViewData["HTBushingBPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");

            


            ViewData["InstalledConditionPadbsPoleMounted"] = new SelectList(_context.LookUpInstalledCondition, "Id", "Name");
            ViewData["InstalledPlaceIndoorbsOutdoor"] = new SelectList(_context.LookUpInstalledPlace, "Id", "Name");
            ViewData["LTBushingBPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["LTBushingNPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["LTBushingRPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["LTBushingYPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["OwneroftheTransformerBPDBbsConsumer"] = new SelectList(_context.LookUpTransformerOwner, "Id", "Name");
            ViewData["PlatformMaterialAnglbsChannel"] = new SelectList(_context.LookUpPlatformMaterial, "Id", "Name");
            ViewData["PlatformStandardbsNonStandardGoodBad"] = new SelectList(_context.LookUpDtCondition, "Id", "Name");
            ViewData["TypeofTransformerSupportPoleLeft"] = new SelectList(_context.LookUpSupportPoleLeftRightType, "Id", "Name");
            ViewData["TypeofTransformerSupportPoleRight"] = new SelectList(_context.LookUpSupportPoleLeftRightType, "Id", "Name");
            return View();
        }

        // POST: TblDistributionTransformers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistributionTransformerId,PoleId,FeederLineId,NameOf33bs11kVSubdsstation,Nameof11kVFeeder,SNDIdentificationNo,NearestHoldingbsHouseNobsShop,ExistingPoleNumberingifAny,InstalledConditionPadbsPoleMounted,InstalledPlaceIndoorbsOutdoor,ContractNo,OwneroftheTransformerBPDBbsConsumer,TransformerKVARating,YearofManufacturing,NameofManufacturer,TransformerSerialNo,RatedHTVoltage,RatedLTVoltage,RatedHTCurrent,RatedLTCurrent,ControlVoltage,MotorVoltageforspringcharge,RatedVoltage,BodyColourCondition,NameoBodyColour,OilLeakageYesOrNo,PlaceofOilLeakageMark,PlatformMaterialAnglbsChannel,PlatformStandardbsNonStandardGoodBad,TypeofTransformerSupportPoleLeft,ConditionofTransformerSupportPoleLeft,TypeofTransformerSupportPoleRight,ConditionofTransformerSupportPoleRight,HTBushingRPhaseOil,HTBushingRPhaseGood,HTBushingRPhaseColor,HTBushingYPhaseOil,HTBushingYPhaseGood,HTBushingYPhaseColor,HTBushingBPhaseOil,HTBushingBPhaseGood,HTBushingBPhaseColor,HTBushingNPhaseOil,HTBushingNPhaseGood,HTBushingNPhaseColor,LTBushingRPhaseOil,LTBushingRPhaseGood,LTBushingRPhaseColor,LTBushingYPhaseOil,LTBushingYPhaseGood,LTBushingYPhaseColor,LTBushingBPhaseOil,LTBushingBPhaseGood,LTBushingBPhaseColor,LTBushingNPhaseOil,LTBushingNPhaseGood,LTBushingNPhaseColor,WireSizeofHTDrop,ConditionofHTDropGoodbsBad,WirebsCableSizeofLTDropCKT1,ConditionofLTDropGoodbsBadCKT1,WirebsCableSizeofLTDropCKT2,ConditionofLTDropGoodbsBadCKT2,EarthingLead1,EarthingLead1Size,EarthingLead1Material,EarthingLead1ConditionStandard,EarthingLead2,EarthingLead2Size,EarthingLead2Material,EarthingLead2ConditionStandard,DayPeak,DateAndtime1,Voltage1,RYVoltageVolt1,YBVoltageVolt1,RBVoltageVolt1,RNVoltageVolt1,YNVoltageVolt1,BNVoltageVolt1,LeakageVoltageBodyEarthVolt1,RPhaseCurrentAmps1Ckt1,RPhaseCurrentAmps1Ckt2,RPhaseCurrentAmps1Ckt3,YPhaseCurrentAmps1Ckt1,YPhaseCurrentAmps1Ckt2,YPhaseCurrentAmps1Ckt3,BPhaseCurrentAmps1Ckt1,BPhaseCurrentAmps1Ckt2,BPhaseCurrentAmps1Ckt3,NeutralCurrentAmps1Ckt1,NeutralCurrentAmps1Ckt2,NeutralCurrentAmps1Ckt3,CalculatedDayPeakkVA,EveningPeak,DateAndTime2,Voltage2,RYVoltageVolt2,YBVoltageVolt2,RBVoltageVolt2,RNVoltageVolt2,YNVoltageVolt,BNVoltageVolt2,LeakageVoltageBodyEarthVolt2,RPhaseCurrentAmps2Ckt1,RPhaseCurrentAmps2Ckt2,RPhaseCurrentAmps2Ckt3,YPhaseCurrentAmps2Ckt1,YPhaseCurrentAmps2Ckt2,YPhaseCurrentAmps2Ckt3,BPhaseCurrentAmps2Ckt1,BPhaseCurrentAmps2Ckt2,BPhaseCurrentAmps2Ckt3,NeutralCurrentAmpsCkt1,NeutralCurrentAmps2Ckt2,NeutralCurrentAmps2Ckt3,CalculatedEveningPeakkVA,DropOutFuseExistbsNotExistRphase,DropOutFuseExistbsNotExistYphase,DropOutFuseExistbsNotExistBphase,ConditionofDropOutFuseRphase,ConditionofDropOutFuseYphase,ConditionofDropOutFuseBphase,LightningArrestorRphase,LightningArrestorYphase,LightningArrestorBphase,ConditionofLightingArrestorRphase,ConditionofLightingArrestorYphase,ConditionofLightingArrestorBphase,DistributionBoxExistbsnotExist,ConditionofDistributionBox,NoOfMCCB,ManufacturerTypeOriginofMCCBforCircuit1,ManufacturerTypeOriginofMCCBforCircuit2,AmpereRatingasPerNamePlateofMCCBforCKT1,AmpereRatingasPerNameplateOfMCCBForCKT2,ConditionofMCCBforCircuit1,ConditionofMCCBforCircuit2,Recommendation")] TblDistributionTransformer tblDistributionTransformer)
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
                _context.Add(tblDistributionTransformer);
                await _context.SaveChangesAsync();
                TempData["statuMessageSuccess"] = "Distribution Transformer has been added successfully under pole id " + tblDistributionTransformer.PoleId;
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "TblPoles");
            }
            ViewData["BodyColourCondition"] = new SelectList(_context.LookUpBodyColourCondition, "Id", "Name", tblDistributionTransformer.BodyColourCondition);
            ViewData["ConditionofDistributionBox"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDistributionBox);
            ViewData["ConditionofDropOutFuseBphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseBphase);
            ViewData["ConditionofDropOutFuseRphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseRphase);
            ViewData["ConditionofDropOutFuseYphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseYphase);
            ViewData["ConditionofHTDropGoodbsBad"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofHTDropGoodbsBad);
            ViewData["ConditionofLTDropGoodbsBadCKT1"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLTDropGoodbsBadCKT1);
            ViewData["ConditionofLTDropGoodbsBadCKT2"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLTDropGoodbsBadCKT2);
            ViewData["ConditionofLightingArrestorBphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorBphase);
            ViewData["ConditionofLightingArrestorRphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorRphase);
            ViewData["ConditionofLightingArrestorYphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorYphase);
            ViewData["ConditionofMCCBforCircuit1"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofMCCBforCircuit1);
            ViewData["ConditionofMCCBforCircuit2"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofMCCBforCircuit2);
            ViewData["ConditionofTransformerSupportPoleLeft"] = new SelectList(_context.LookUpSupportPoleLeftRightCondition, "Id", "Name", tblDistributionTransformer.ConditionofTransformerSupportPoleLeft);
            ViewData["ConditionofTransformerSupportPoleRight"] = new SelectList(_context.LookUpSupportPoleLeftRightCondition, "Id", "Name", tblDistributionTransformer.ConditionofTransformerSupportPoleRight);
            //ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblDistributionTransformer.FeederLineId);
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblDistributionTransformer.PoleId);
            ViewData["EarthingLead1ConditionStandard"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.EarthingLead1ConditionStandard);
            ViewData["EarthingLead2ConditionStandard"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.EarthingLead2ConditionStandard);
            ViewData["HTBushingNPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingNPhaseGood);
            ViewData["HTBushingRPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingRPhaseGood);
            ViewData["HTBushingYPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingYPhaseGood);
            ViewData["InstalledConditionPadbsPoleMounted"] = new SelectList(_context.LookUpInstalledCondition, "Id", "Name", tblDistributionTransformer.InstalledConditionPadbsPoleMounted);
            ViewData["InstalledPlaceIndoorbsOutdoor"] = new SelectList(_context.LookUpInstalledPlace, "Id", "Name", tblDistributionTransformer.InstalledPlaceIndoorbsOutdoor);
            ViewData["LTBushingBPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingBPhaseGood);
            ViewData["LTBushingNPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingNPhaseGood);
            ViewData["LTBushingRPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingRPhaseGood);
            ViewData["LTBushingYPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingYPhaseGood);

            ViewData["HTBushingBPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingBPhaseGood);

            ViewData["OwneroftheTransformerBPDBbsConsumer"] = new SelectList(_context.LookUpTransformerOwner, "Id", "Name", tblDistributionTransformer.OwneroftheTransformerBPDBbsConsumer);
            ViewData["PlatformMaterialAnglbsChannel"] = new SelectList(_context.LookUpPlatformMaterial, "Id", "Name", tblDistributionTransformer.PlatformMaterialAnglbsChannel);
            ViewData["PlatformStandardbsNonStandardGoodBad"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.PlatformStandardbsNonStandardGoodBad);
            ViewData["TypeofTransformerSupportPoleLeft"] = new SelectList(_context.LookUpSupportPoleLeftRightType, "Id", "Name", tblDistributionTransformer.TypeofTransformerSupportPoleLeft);
            ViewData["TypeofTransformerSupportPoleRight"] = new SelectList(_context.LookUpSupportPoleLeftRightType, "Id", "Name", tblDistributionTransformer.TypeofTransformerSupportPoleRight);
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
            ViewData["BodyColourCondition"] = new SelectList(_context.LookUpBodyColourCondition, "Id", "Name", tblDistributionTransformer.BodyColourCondition);
            ViewData["ConditionofDistributionBox"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDistributionBox);
            ViewData["ConditionofDropOutFuseBphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseBphase);
            ViewData["ConditionofDropOutFuseRphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseRphase);
            ViewData["ConditionofDropOutFuseYphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseYphase);
            ViewData["ConditionofHTDropGoodbsBad"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofHTDropGoodbsBad);
            ViewData["ConditionofLTDropGoodbsBadCKT1"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLTDropGoodbsBadCKT1);
            ViewData["ConditionofLTDropGoodbsBadCKT2"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLTDropGoodbsBadCKT2);
            ViewData["ConditionofLightingArrestorBphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorBphase);
            ViewData["ConditionofLightingArrestorRphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorRphase);
            ViewData["ConditionofLightingArrestorYphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorYphase);
            ViewData["ConditionofMCCBforCircuit1"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofMCCBforCircuit1);
            ViewData["ConditionofMCCBforCircuit2"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofMCCBforCircuit2);
            ViewData["ConditionofTransformerSupportPoleLeft"] = new SelectList(_context.LookUpSupportPoleLeftRightCondition, "Id", "Name", tblDistributionTransformer.ConditionofTransformerSupportPoleLeft);
            ViewData["ConditionofTransformerSupportPoleRight"] = new SelectList(_context.LookUpSupportPoleLeftRightCondition, "Id", "Name", tblDistributionTransformer.ConditionofTransformerSupportPoleRight);
            //ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblDistributionTransformer.FeederLineId);
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblDistributionTransformer.PoleId);
            ViewData["EarthingLead1ConditionStandard"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.EarthingLead1ConditionStandard);
            ViewData["EarthingLead2ConditionStandard"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.EarthingLead2ConditionStandard);
            ViewData["HTBushingNPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingNPhaseGood);
            ViewData["HTBushingRPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingRPhaseGood);
            ViewData["HTBushingYPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingYPhaseGood);
            ViewData["InstalledConditionPadbsPoleMounted"] = new SelectList(_context.LookUpInstalledCondition, "Id", "Name", tblDistributionTransformer.InstalledConditionPadbsPoleMounted);
            ViewData["InstalledPlaceIndoorbsOutdoor"] = new SelectList(_context.LookUpInstalledPlace, "Id", "Name", tblDistributionTransformer.InstalledPlaceIndoorbsOutdoor);
            ViewData["LTBushingBPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingBPhaseGood);
            ViewData["LTBushingNPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingNPhaseGood);
            ViewData["LTBushingRPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingRPhaseGood);
            ViewData["LTBushingYPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingYPhaseGood);

            ViewData["HTBushingBPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingBPhaseGood);

            ViewData["OwneroftheTransformerBPDBbsConsumer"] = new SelectList(_context.LookUpTransformerOwner, "Id", "Name", tblDistributionTransformer.OwneroftheTransformerBPDBbsConsumer);
            ViewData["PlatformMaterialAnglbsChannel"] = new SelectList(_context.LookUpPlatformMaterial, "Id", "Name", tblDistributionTransformer.PlatformMaterialAnglbsChannel);
            ViewData["PlatformStandardbsNonStandardGoodBad"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.PlatformStandardbsNonStandardGoodBad);
            ViewData["TypeofTransformerSupportPoleLeft"] = new SelectList(_context.LookUpSupportPoleLeftRightType, "Id", "Name", tblDistributionTransformer.TypeofTransformerSupportPoleLeft);
            ViewData["TypeofTransformerSupportPoleRight"] = new SelectList(_context.LookUpSupportPoleLeftRightType, "Id", "Name", tblDistributionTransformer.TypeofTransformerSupportPoleRight);
            return View(tblDistributionTransformer);
        }

        // POST: TblDistributionTransformers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DistributionTransformerId,PoleId,FeederLineId,NameOf33bs11kVSubdsstation,Nameof11kVFeeder,SNDIdentificationNo,NearestHoldingbsHouseNobsShop,ExistingPoleNumberingifAny,InstalledConditionPadbsPoleMounted,InstalledPlaceIndoorbsOutdoor,ContractNo,OwneroftheTransformerBPDBbsConsumer,TransformerKVARating,YearofManufacturing,NameofManufacturer,TransformerSerialNo,RatedHTVoltage,RatedLTVoltage,RatedHTCurrent,RatedLTCurrent,ControlVoltage,MotorVoltageforspringcharge,RatedVoltage,BodyColourCondition,NameoBodyColour,OilLeakageYesOrNo,PlaceofOilLeakageMark,PlatformMaterialAnglbsChannel,PlatformStandardbsNonStandardGoodBad,TypeofTransformerSupportPoleLeft,ConditionofTransformerSupportPoleLeft,TypeofTransformerSupportPoleRight,ConditionofTransformerSupportPoleRight,HTBushingRPhaseOil,HTBushingRPhaseGood,HTBushingRPhaseColor,HTBushingYPhaseOil,HTBushingYPhaseGood,HTBushingYPhaseColor,HTBushingBPhaseOil,HTBushingBPhaseGood,HTBushingBPhaseColor,HTBushingNPhaseOil,HTBushingNPhaseGood,HTBushingNPhaseColor,LTBushingRPhaseOil,LTBushingRPhaseGood,LTBushingRPhaseColor,LTBushingYPhaseOil,LTBushingYPhaseGood,LTBushingYPhaseColor,LTBushingBPhaseOil,LTBushingBPhaseGood,LTBushingBPhaseColor,LTBushingNPhaseOil,LTBushingNPhaseGood,LTBushingNPhaseColor,WireSizeofHTDrop,ConditionofHTDropGoodbsBad,WirebsCableSizeofLTDropCKT1,ConditionofLTDropGoodbsBadCKT1,WirebsCableSizeofLTDropCKT2,ConditionofLTDropGoodbsBadCKT2,EarthingLead1,EarthingLead1Size,EarthingLead1Material,EarthingLead1ConditionStandard,EarthingLead2,EarthingLead2Size,EarthingLead2Material,EarthingLead2ConditionStandard,DayPeak,DateAndtime1,Voltage1,RYVoltageVolt1,YBVoltageVolt1,RBVoltageVolt1,RNVoltageVolt1,YNVoltageVolt1,BNVoltageVolt1,LeakageVoltageBodyEarthVolt1,RPhaseCurrentAmps1Ckt1,RPhaseCurrentAmps1Ckt2,RPhaseCurrentAmps1Ckt3,YPhaseCurrentAmps1Ckt1,YPhaseCurrentAmps1Ckt2,YPhaseCurrentAmps1Ckt3,BPhaseCurrentAmps1Ckt1,BPhaseCurrentAmps1Ckt2,BPhaseCurrentAmps1Ckt3,NeutralCurrentAmps1Ckt1,NeutralCurrentAmps1Ckt2,NeutralCurrentAmps1Ckt3,CalculatedDayPeakkVA,EveningPeak,DateAndTime2,Voltage2,RYVoltageVolt2,YBVoltageVolt2,RBVoltageVolt2,RNVoltageVolt2,YNVoltageVolt,BNVoltageVolt2,LeakageVoltageBodyEarthVolt2,RPhaseCurrentAmps2Ckt1,RPhaseCurrentAmps2Ckt2,RPhaseCurrentAmps2Ckt3,YPhaseCurrentAmps2Ckt1,YPhaseCurrentAmps2Ckt2,YPhaseCurrentAmps2Ckt3,BPhaseCurrentAmps2Ckt1,BPhaseCurrentAmps2Ckt2,BPhaseCurrentAmps2Ckt3,NeutralCurrentAmpsCkt1,NeutralCurrentAmps2Ckt2,NeutralCurrentAmps2Ckt3,CalculatedEveningPeakkVA,DropOutFuseExistbsNotExistRphase,DropOutFuseExistbsNotExistYphase,DropOutFuseExistbsNotExistBphase,ConditionofDropOutFuseRphase,ConditionofDropOutFuseYphase,ConditionofDropOutFuseBphase,LightningArrestorRphase,LightningArrestorYphase,LightningArrestorBphase,ConditionofLightingArrestorRphase,ConditionofLightingArrestorYphase,ConditionofLightingArrestorBphase,DistributionBoxExistbsnotExist,ConditionofDistributionBox,NoOfMCCB,ManufacturerTypeOriginofMCCBforCircuit1,ManufacturerTypeOriginofMCCBforCircuit2,AmpereRatingasPerNamePlateofMCCBforCKT1,AmpereRatingasPerNameplateOfMCCBForCKT2,ConditionofMCCBforCircuit1,ConditionofMCCBforCircuit2,Recommendation")] TblDistributionTransformer tblDistributionTransformer)
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
            ViewData["BodyColourCondition"] = new SelectList(_context.LookUpBodyColourCondition, "Id", "Name", tblDistributionTransformer.BodyColourCondition);
            ViewData["ConditionofDistributionBox"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDistributionBox);
            ViewData["ConditionofDropOutFuseBphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseBphase);
            ViewData["ConditionofDropOutFuseRphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseRphase);
            ViewData["ConditionofDropOutFuseYphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofDropOutFuseYphase);
            ViewData["ConditionofHTDropGoodbsBad"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofHTDropGoodbsBad);
            ViewData["ConditionofLTDropGoodbsBadCKT1"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLTDropGoodbsBadCKT1);
            ViewData["ConditionofLTDropGoodbsBadCKT2"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLTDropGoodbsBadCKT2);
            ViewData["ConditionofLightingArrestorBphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorBphase);
            ViewData["ConditionofLightingArrestorRphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorRphase);
            ViewData["ConditionofLightingArrestorYphase"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofLightingArrestorYphase);
            ViewData["ConditionofMCCBforCircuit1"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofMCCBforCircuit1);
            ViewData["ConditionofMCCBforCircuit2"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.ConditionofMCCBforCircuit2);
            ViewData["ConditionofTransformerSupportPoleLeft"] = new SelectList(_context.LookUpSupportPoleLeftRightCondition, "Id", "Name", tblDistributionTransformer.ConditionofTransformerSupportPoleLeft);
            ViewData["ConditionofTransformerSupportPoleRight"] = new SelectList(_context.LookUpSupportPoleLeftRightCondition, "Id", "Name", tblDistributionTransformer.ConditionofTransformerSupportPoleRight);
            //ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederLineId", tblDistributionTransformer.FeederLineId);
            //ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblDistributionTransformer.PoleId);
            ViewData["EarthingLead1ConditionStandard"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.EarthingLead1ConditionStandard);
            ViewData["EarthingLead2ConditionStandard"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.EarthingLead2ConditionStandard);
            ViewData["HTBushingNPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingNPhaseGood);
            ViewData["HTBushingRPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingRPhaseGood);
            ViewData["HTBushingYPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingYPhaseGood);
            ViewData["InstalledConditionPadbsPoleMounted"] = new SelectList(_context.LookUpInstalledCondition, "Id", "Name", tblDistributionTransformer.InstalledConditionPadbsPoleMounted);
            ViewData["InstalledPlaceIndoorbsOutdoor"] = new SelectList(_context.LookUpInstalledPlace, "Id", "Name", tblDistributionTransformer.InstalledPlaceIndoorbsOutdoor);
            ViewData["LTBushingBPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingBPhaseGood);
            ViewData["LTBushingNPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingNPhaseGood);
            ViewData["LTBushingRPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingRPhaseGood);
            ViewData["LTBushingYPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.LTBushingYPhaseGood);

            ViewData["HTBushingBPhaseGood"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.HTBushingBPhaseGood);

            ViewData["OwneroftheTransformerBPDBbsConsumer"] = new SelectList(_context.LookUpTransformerOwner, "Id", "Name", tblDistributionTransformer.OwneroftheTransformerBPDBbsConsumer);
            ViewData["PlatformMaterialAnglbsChannel"] = new SelectList(_context.LookUpPlatformMaterial, "Id", "Name", tblDistributionTransformer.PlatformMaterialAnglbsChannel);
            ViewData["PlatformStandardbsNonStandardGoodBad"] = new SelectList(_context.LookUpDtCondition, "Id", "Name", tblDistributionTransformer.PlatformStandardbsNonStandardGoodBad);
            ViewData["TypeofTransformerSupportPoleLeft"] = new SelectList(_context.LookUpSupportPoleLeftRightType, "Id", "Name", tblDistributionTransformer.TypeofTransformerSupportPoleLeft);
            ViewData["TypeofTransformerSupportPoleRight"] = new SelectList(_context.LookUpSupportPoleLeftRightType, "Id", "Name", tblDistributionTransformer.TypeofTransformerSupportPoleRight);
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
                .Include(t => t.BodyColourConditiontoBodyColourCondition)
                .Include(t => t.ConditionofDistributionBoxToCondition)
                .Include(t => t.ConditionofDropOutFuseBphaseToCondition)
                .Include(t => t.ConditionofDropOutFuseRphaseToCondition)
                .Include(t => t.ConditionofDropOutFuseYphaseToCondition)
                .Include(t => t.ConditionofHTDropGoodbsBadToCondition)
                .Include(t => t.ConditionofLTDropGoodbsBadCKT1ToCondition)
                .Include(t => t.ConditionofLTDropGoodbsBadCKT2ToCondition)
                .Include(t => t.ConditionofLightingArrestorBphaseToCondition)
                .Include(t => t.ConditionofLightingArrestorRphaseToCondition)
                .Include(t => t.ConditionofLightingArrestorYphaseToCondition)
                .Include(t => t.ConditionofMCCBforCircuit1ToCondition)
                .Include(t => t.ConditionofMCCBforCircuit2ToCondition)
                .Include(t => t.ConditionofTransformerSupportPoleLeftToLeftRightCondition)
                .Include(t => t.ConditionofTransformerSupportPoleRightToLeftRightCondition)
                .Include(t => t.DtToFeederLine)
                .Include(t => t.DtToPole)
                .Include(t => t.HTBushingBPhaseGoodToCondition)
                .Include(t => t.EarthingLead1ConditionStandardToCondition)
                .Include(t => t.EarthingLead2ConditionStandardToCondition)
                .Include(t => t.HTBushingNPhaseGoodToCondition)
                .Include(t => t.HTBushingRPhaseGoodToCondition)
                .Include(t => t.HTBushingYPhaseGoodToCondition)
                .Include(t => t.InstalledConditionPadbsPoleMountedToInstalledCondition)
                .Include(t => t.InstalledPlaceIndoorbsOutdoorToInstalledPlace)
                .Include(t => t.LTBushingBPhaseGoodToCondition)
                .Include(t => t.LTBushingNPhaseGoodToCondition)
                .Include(t => t.LTBushingRPhaseGoodToCondition)
                .Include(t => t.LTBushingYPhaseGoodToCondition)
                .Include(t => t.OwneroftheTransformerBPDBbsConsumerToTransformerOwner)
                .Include(t => t.PlatformMaterialAnglbsChannelTolatformMaterial)
                .Include(t => t.PlatformStandardbsNonStandardGoodBadToCondition)
                .Include(t => t.TypeofTransformerSupportPoleLeftToLeftRightType)
                .Include(t => t.TypeofTransformerSupportPoleRightToLeftRightType)
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
            TempData["statuMessageSuccess"] = "Distribution Transformer has been Deleted successfully under pole id " + tblDistributionTransformer.PoleId;
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "TblPoles");
            //return RedirectToAction(nameof(Index));
        }

        private bool TblDistributionTransformerExists(string id)
        {
            return _context.TblDistributionTransformer.Any(e => e.DistributionTransformerId == id);
        }
    }
}
