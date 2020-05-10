using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.ServicePointModels;
using Pdb014App.Repository;
using ReflectionIT.Mvc.Paging;

namespace Pdb014App.Controllers.ServicePointControllers
{
    public class TblConsumerDatasController : Controller
    {
        private readonly PdbDbContext _context;

        public TblConsumerDatasController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblConsumerDatas
        //public async Task<IActionResult> Index(int? id)
        //{
        //    var pdbDbContext = _context.TblConsumerData.Include(t => t.ConsumerDataToDistributionTransformer)
        //        .Include(t => t.ConsumerDataToServicePoint).Include(t => t.ConsumerToBusinessType)
        //        .Include(t => t.ConsumerToConnectionStatus).Include(t => t.ConsumerToConnectionType)
        //        .Include(t => t.ConsumerToLocation).Include(t => t.ConsumerToMeterType)
        //        .Include(t => t.ConsumerToOperatingVoltage).Include(t => t.ConsumerToPhasingCode)
        //        .Include(t => t.ConsumerToServiceCableType).Include(t => t.ConsumerToStructureType)
        //        .Include(t => t.ConsumerType);

        //    if (id!= null)
        //    {
        //        pdbDbContext = _context.TblConsumerData.Where(p => p.ServicePointId == id).Include(t => t.ConsumerDataToDistributionTransformer)
        //        .Include(t => t.ConsumerDataToServicePoint).Include(t => t.ConsumerToBusinessType)
        //        .Include(t => t.ConsumerToConnectionStatus).Include(t => t.ConsumerToConnectionType)
        //        .Include(t => t.ConsumerToLocation).Include(t => t.ConsumerToMeterType)
        //        .Include(t => t.ConsumerToOperatingVoltage).Include(t => t.ConsumerToPhasingCode)
        //        .Include(t => t.ConsumerToServiceCableType).Include(t => t.ConsumerToStructureType)
        //        .Include(t => t.ConsumerType);
        //    }
        //    return View(await pdbDbContext.ToListAsync());
        //}


            // By RMO
        public async Task<IActionResult> Index(string id, string filter, int pageIndex = 1, string sortExpression = "ConsumerId")
        //public async Task<IActionResult> Index(int? id, string filter, int pageIndex = 1, string sortExpression = "ConsumerId")
        {
            var qry = _context.TblConsumerData.Include(t => t.ConsumerDataToDistributionTransformer)
                .Include(t => t.ConsumerDataToServicesPoint).Include(t => t.ConsumerToBusinessType)
                .Include(t => t.ConsumerToConnectionStatus).Include(t => t.ConsumerToConnectionType)
                .Include(t => t.ConsumerToLocation).Include(t => t.ConsumerToMeterType)
                .Include(t => t.ConsumerToOperatingVoltage).Include(t => t.ConsumerToPhasingCode)
                .Include(t => t.ConsumerToServiceCableType).Include(t => t.ConsumerToStructureType)
                .Include(t => t.ConsumerType).AsQueryable();


            if (id != null)
            {
                qry = qry.Where(p => p.ServicesPointId == id);
            }


            if (!string.IsNullOrEmpty(filter))
            {
                qry = qry.Where(p => p.ConsumerNo.Contains(filter) || p.MeterNumber.Contains(filter));
            }

            var model = await PagingList.CreateAsync(qry, 10, pageIndex, sortExpression, "ConsumerId");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        // GET: TblConsumerDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblConsumerData = await _context.TblConsumerData
                .Include(cd => cd.ConsumerType)
                .Include(cd => cd.ConsumerToConnectionType)
                .Include(cd => cd.ConsumerToConnectionStatus)
                .Include(cd => cd.ConsumerToBusinessType)
                .Include(cd => cd.ConsumerToLocation)
                .Include(cd => cd.ConsumerToMeterType)
                .Include(cd => cd.ConsumerToOperatingVoltage)
                .Include(cd => cd.ConsumerToPhasingCode)
                .Include(cd => cd.ConsumerToServiceCableType)
                .Include(cd => cd.ConsumerToStructureType)
                
                .Include(cd => cd.ConsumerDataToServicesPoint)
                .Include(cd => cd.ConsumerDataToDistributionTransformer)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToPole)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .FirstOrDefaultAsync(m => m.ConsumerId == id);


            if (tblConsumerData == null)
            {
                return NotFound();
            }

            return View(tblConsumerData);
        }

        // GET: TblConsumerDatas/Create
        public IActionResult Create()
        {
            ViewData["DistributionTransformerId"] = new SelectList(_context.TblDistributionTransformer, "DistributionTransformerId", "DistributionTransformerId");
            ViewData["ServicePointId"] = new SelectList(_context.TblServicePoint, "ServicePointId", "ServicePointId");
            ViewData["BusinessTypeId"] = new SelectList(_context.LookUpBusinessType, "BusinessTypeId", "BusinessTypeName");
            ViewData["ConnectionStatusId"] = new SelectList(_context.LookUpConnectionStatus, "ConnectionStatusId", "ConnectionStatusName");
            ViewData["ConnectionTypeId"] = new SelectList(_context.LookUpConnectionType, "ConnectionTypeId", "ConnectionTypeName");
            ViewData["LocationId"] = new SelectList(_context.LookUpLocation, "LocationId", "LocationName");
            ViewData["MeterTypeId"] = new SelectList(_context.LookUpMeterType, "MeterTypeId", "MeterTypeName");
            ViewData["OperatingVoltageId"] = new SelectList(_context.LookUpOperatingVoltage, "OperatingVoltageId", "OperatingVoltageName");
            ViewData["PhasingCodeId"] = new SelectList(_context.LookUpPhasingCodeType, "PhasingCodeId", "PhasingCodeName");
            ViewData["ServiceCableTypeId"] = new SelectList(_context.LookUpServiceCableType, "ServiceCableTypeId", "ServiceCableTypeName");
            ViewData["StructureTypeId"] = new SelectList(_context.LookUpStructureType, "StructureTypeId", "StructureTypeName");
            ViewData["ConsumerTypeId"] = new SelectList(_context.LookUpConsumerType, "ConsumerTypeId", "ConsumerTypeName");
            return View();
        }

        // POST: TblConsumerDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumerId,ServicesPointId,DistributionTransformerId,CustomerName,CustomerMobileNo,ConsumerNo,Tariff,PhasingCodeId,ConsumerTypeId,OperatingVoltageId,InstallDate,ConnectionStatusId,ConnectionTypeId,MeterTypeId,MeterNumber,MeterModel,MeterManufacturer,SanctionedLoad,ConnectedLoad,BusinessTypeId,OthersBusiness,AccountNumber,SpecialCode,SpecialType,LocationId,BillGroup,BookNumber,OmfKwh,MeterReading,ServiceCableSize,ServiceCableTypeId,CustomerAddress,PlotNo,BuildingApptNo,PremiseName,SurveyDate,Latitude,Longitude,StructureId,StructureMapNo,StructureTypeId,NumberOfFloor")] TblConsumerData tblConsumerData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblConsumerData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistributionTransformerId"] = new SelectList(_context.TblDistributionTransformer, "DistributionTransformerId", "DistributionTransformerId", tblConsumerData.DistributionTransformerId);
            ViewData["ServicePointId"] = new SelectList(_context.TblServicePoint, "ServicesPointId", "ServicesPointId", tblConsumerData.ServicesPointId);
            ViewData["BusinessTypeId"] = new SelectList(_context.LookUpBusinessType, "BusinessTypeId", "BusinessTypeName", tblConsumerData.BusinessTypeId);
            ViewData["ConnectionStatusId"] = new SelectList(_context.LookUpConnectionStatus, "ConnectionStatusId", "ConnectionStatusName", tblConsumerData.ConnectionStatusId);
            ViewData["ConnectionTypeId"] = new SelectList(_context.LookUpConnectionType, "ConnectionTypeId", "ConnectionTypeName", tblConsumerData.ConnectionTypeId);
            ViewData["LocationId"] = new SelectList(_context.LookUpLocation, "LocationId", "LocationName", tblConsumerData.LocationId);
            ViewData["MeterTypeId"] = new SelectList(_context.LookUpMeterType, "MeterTypeId", "MeterTypeName", tblConsumerData.MeterTypeId);
            ViewData["OperatingVoltageId"] = new SelectList(_context.LookUpOperatingVoltage, "OperatingVoltageId", "OperatingVoltageName", tblConsumerData.OperatingVoltageId);
            ViewData["PhasingCodeId"] = new SelectList(_context.LookUpPhasingCodeType, "PhasingCodeId", "PhasingCodeName", tblConsumerData.PhasingCodeId);
            ViewData["ServiceCableTypeId"] = new SelectList(_context.LookUpServiceCableType, "ServiceCableTypeId", "ServiceCableTypeName", tblConsumerData.ServiceCableTypeId);
            ViewData["StructureTypeId"] = new SelectList(_context.LookUpStructureType, "StructureTypeId", "StructureTypeName", tblConsumerData.StructureTypeId);
            ViewData["ConsumerTypeId"] = new SelectList(_context.LookUpConsumerType, "ConsumerTypeId", "ConsumerTypeName", tblConsumerData.ConsumerTypeId);
            return View(tblConsumerData);
        }

        // GET: TblConsumerDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblConsumerData = await _context.TblConsumerData.FindAsync(id);
            if (tblConsumerData == null)
            {
                return NotFound();
            }

            ViewData["DistributionTransformerId"] = new SelectList(_context.TblDistributionTransformer, "DistributionTransformerId", "DistributionTransformerId", tblConsumerData.DistributionTransformerId);
            ViewData["ServicePointId"] = new SelectList(_context.TblServicePoint, "ServicesPointId", "ServicesPointId", tblConsumerData.ServicesPointId);
            ViewData["BusinessTypeId"] = new SelectList(_context.LookUpBusinessType, "BusinessTypeId", "BusinessTypeName", tblConsumerData.BusinessTypeId);
            ViewData["ConnectionStatusId"] = new SelectList(_context.LookUpConnectionStatus, "ConnectionStatusId", "ConnectionStatusName", tblConsumerData.ConnectionStatusId);
            ViewData["ConnectionTypeId"] = new SelectList(_context.LookUpConnectionType, "ConnectionTypeId", "ConnectionTypeName", tblConsumerData.ConnectionTypeId);
            ViewData["LocationId"] = new SelectList(_context.LookUpLocation, "LocationId", "LocationName", tblConsumerData.LocationId);
            ViewData["MeterTypeId"] = new SelectList(_context.LookUpMeterType, "MeterTypeId", "MeterTypeName", tblConsumerData.MeterTypeId);
            ViewData["OperatingVoltageId"] = new SelectList(_context.LookUpOperatingVoltage, "OperatingVoltageId", "OperatingVoltageName", tblConsumerData.OperatingVoltageId);
            ViewData["PhasingCodeId"] = new SelectList(_context.LookUpPhasingCodeType, "PhasingCodeId", "PhasingCodeName", tblConsumerData.PhasingCodeId);
            ViewData["ServiceCableTypeId"] = new SelectList(_context.LookUpServiceCableType, "ServiceCableTypeId", "ServiceCableTypeName", tblConsumerData.ServiceCableTypeId);
            ViewData["StructureTypeId"] = new SelectList(_context.LookUpStructureType, "StructureTypeId", "StructureTypeName", tblConsumerData.StructureTypeId);
            ViewData["ConsumerTypeId"] = new SelectList(_context.LookUpConsumerType, "ConsumerTypeId", "ConsumerTypeName", tblConsumerData.ConsumerTypeId);

            return View(tblConsumerData);
        }

        // POST: TblConsumerDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumerId,ServicesPointId,DistributionTransformerId,CustomerName,CustomerMobileNo,ConsumerNo,Tariff,PhasingCodeId,ConsumerTypeId,OperatingVoltageId,InstallDate,ConnectionStatusId,ConnectionTypeId,MeterTypeId,MeterNumber,MeterModel,MeterManufacturer,SanctionedLoad,ConnectedLoad,BusinessTypeId,OthersBusiness,AccountNumber,SpecialCode,SpecialType,LocationId,BillGroup,BookNumber,OmfKwh,MeterReading,ServiceCableSize,ServiceCableTypeId,CustomerAddress,PlotNo,BuildingApptNo,PremiseName,SurveyDate,Latitude,Longitude,StructureId,StructureMapNo,StructureTypeId,NumberOfFloor")] TblConsumerData tblConsumerData)
        {
            if (id != tblConsumerData.ConsumerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblConsumerData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblConsumerDataExists(tblConsumerData.ConsumerId))
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

            ViewData["DistributionTransformerId"] = new SelectList(_context.TblDistributionTransformer, "DistributionTransformerId", "DistributionTransformerId", tblConsumerData.DistributionTransformerId);
            ViewData["ServicePointId"] = new SelectList(_context.TblServicePoint, "ServicesPointId", "ServicesPointId", tblConsumerData.ServicesPointId);
            ViewData["BusinessTypeId"] = new SelectList(_context.LookUpBusinessType, "BusinessTypeId", "BusinessTypeName", tblConsumerData.BusinessTypeId);
            ViewData["ConnectionStatusId"] = new SelectList(_context.LookUpConnectionStatus, "ConnectionStatusId", "ConnectionStatusName", tblConsumerData.ConnectionStatusId);
            ViewData["ConnectionTypeId"] = new SelectList(_context.LookUpConnectionType, "ConnectionTypeId", "ConnectionTypeName", tblConsumerData.ConnectionTypeId);
            ViewData["LocationId"] = new SelectList(_context.LookUpLocation, "LocationId", "LocationName", tblConsumerData.LocationId);
            ViewData["MeterTypeId"] = new SelectList(_context.LookUpMeterType, "MeterTypeId", "MeterTypeName", tblConsumerData.MeterTypeId);
            ViewData["OperatingVoltageId"] = new SelectList(_context.LookUpOperatingVoltage, "OperatingVoltageId", "OperatingVoltageName", tblConsumerData.OperatingVoltageId);
            ViewData["PhasingCodeId"] = new SelectList(_context.LookUpPhasingCodeType, "PhasingCodeId", "PhasingCodeName", tblConsumerData.PhasingCodeId);
            ViewData["ServiceCableTypeId"] = new SelectList(_context.LookUpServiceCableType, "ServiceCableTypeId", "ServiceCableTypeName", tblConsumerData.ServiceCableTypeId);
            ViewData["StructureTypeId"] = new SelectList(_context.LookUpStructureType, "StructureTypeId", "StructureTypeName", tblConsumerData.StructureTypeId);
            ViewData["ConsumerTypeId"] = new SelectList(_context.LookUpConsumerType, "ConsumerTypeId", "ConsumerTypeName", tblConsumerData.ConsumerTypeId);
            return View(tblConsumerData);
        }

        // GET: TblConsumerDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblConsumerData = await _context.TblConsumerData
                .Include(t => t.ConsumerDataToDistributionTransformer)
                .Include(t => t.ConsumerDataToServicesPoint)
                .Include(t => t.ConsumerToBusinessType)
                .Include(t => t.ConsumerToConnectionStatus)
                .Include(t => t.ConsumerToConnectionType)
                .Include(t => t.ConsumerToLocation)
                .Include(t => t.ConsumerToMeterType)
                .Include(t => t.ConsumerToOperatingVoltage)
                .Include(t => t.ConsumerToPhasingCode)
                .Include(t => t.ConsumerToServiceCableType)
                .Include(t => t.ConsumerToStructureType)
                .Include(t => t.ConsumerType)
                .FirstOrDefaultAsync(m => m.ConsumerId == id);
            if (tblConsumerData == null)
            {
                return NotFound();
            }

            return View(tblConsumerData);
        }

        // POST: TblConsumerDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblConsumerData = await _context.TblConsumerData.FindAsync(id);
            _context.TblConsumerData.Remove(tblConsumerData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblConsumerDataExists(int id)
        {
            return _context.TblConsumerData.Any(e => e.ConsumerId == id);
        }
    }
}
