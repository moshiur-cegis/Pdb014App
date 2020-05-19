using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB;
using Pdb014App.Repository;
using ReflectionIT.Mvc.Paging;

namespace Pdb014App.Controllers.PoleControllers
{
    //[Authorize]
    public class TblPolesController : Controller
    {
        private readonly PdbDbContext _context;

        public TblPolesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblPoles1
        public async Task<IActionResult> Index(string filter, int pageIndex = 1, string sortExpression = "PoleId")
        {
            var qry = _context.TblPole.Include(t => t.LookUpLineType).Include(t => t.LookUpTypeOfWire).Include(t => t.PhaseACondition).Include(t => t.PhaseBCondition).Include(t => t.PhaseCCondition).Include(t => t.PoleCondition).Include(t => t.PoleToFeederLine).Include(t => t.PoleToRoute).Include(t => t.PoleType).Include(t => t.WireLookUpCondition).AsQueryable();

            if (filter != null)
            {
                qry = qry.Where(p => p.PoleId == filter);
            }

            var model = await PagingList.CreateAsync(qry, 10, pageIndex, sortExpression, "PoleId");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);

            //return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblPoles1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPole = await _context.TblPole
                .Include(t => t.PoleType)
                .Include(t => t.LookUpLineType)
                .Include(t => t.LookUpTypeOfWire)
                .Include(t => t.PhaseACondition)
                .Include(t => t.PhaseBCondition)
                .Include(t => t.PhaseCCondition)
                .Include(t => t.PoleCondition)
                .Include(t => t.PoleToFeederLine)
                //.Include(t => t.PoleToRoute)
                
                .Include(t => t.PoleToRoute.RouteToSubstation.SubstationType)
                .Include(t => t.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(t => t.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)

                .Include(t => t.WireLookUpCondition)
                .FirstOrDefaultAsync(m => m.PoleId == id);

            if (tblPole == null)
            {
                return NotFound();
            }

            return View(tblPole);
        }


        [Authorize(Roles = "System Administrator,Super User")]
        // GET: TblPoles1/Create
        public IActionResult Create()
        {
            ViewData["LineTypeId"] = new SelectList(_context.LookUpLineType, "Code", "Name");
            ViewData["TypeOfWireId"] = new SelectList(_context.LookUpTypeOfWire, "Code", "Name");
            ViewData["PhaseAId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseBId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseCId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PoleConditionId"] = new SelectList(_context.LookUpPoleCondition, "PoleConditionId", "PoleConditionId");
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteName");
            ViewData["SourceCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["TargetCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["PoleTypeId"] = new SelectList(_context.LookUpPoleType, "PoleTypeId", "Name");
            ViewData["WireConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");

            var poleIdList = _context.TblPole.AsNoTracking()
           .Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList();
            ViewData["PreviousPoleId"] = poleIdList;


            //ViewData["PreviousPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");

            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View();
        }

        // POST: TblPoles1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoleId,PoleUid,FeederLineUid,SurveyDate,RouteCode,FeederLineId,SurveyorName,PoleNo,PreviousPoleNo,Latitude,Longitude,PoleTypeId,PoleConditionId,LineTypeId,BackSpan,TypeOfWireId,NoOfWireHt,NoOfWireLt,WireLength,WireConditionId,MSJNo,SleeveNo,TwistNo,PhaseAId,PhaseBId,PhaseCId,Neutral,StreetLight,SourceCableId,TargetCableId,TransformerExist,CommonPole,Tap")] TblPole tblPole, string surveyDate)
        {
            //double latA = Convert.ToDouble(tblPole.Latitude);
            //double longA = Convert.ToDouble(tblPole.Longitude);
            //double latB = Convert.ToDouble(_context.TblPole.Where(i => i.PoleId == tblPole.PreviousPoleNo).Select(i => i.Latitude).SingleOrDefault());
            //double longB = Convert.ToDouble(_context.TblPole.Where(i => i.PoleId == tblPole.PreviousPoleNo).Select(i => i.Longitude).SingleOrDefault());


            //var RadianLatA = Math.PI * latA / 180;
            //var RadianLatb = Math.PI * latB / 180;
            //var RadianLongA = Math.PI * longA / 180;
            //var RadianLongB = Math.PI * longB / 180;

            //double theDistance = (Math.Sin(RadianLatA)) *
            //                     Math.Sin(RadianLatb) +
            //                     Math.Cos(RadianLatA) *
            //                     Math.Cos(RadianLatb) *
            //                     Math.Cos(RadianLongA - RadianLongB);

            //var dis = Convert.ToDecimal(((Math.Acos(theDistance) * (180.0 / Math.PI)))) * 69.09M * 1.6093M;

            //if (dis * 1000 < 70)
            //{
            //    ViewData["Error"] = "To pole distance can not less then 70 miter";
            //    return View();
            //}


            //10-31-2019


            //tblPole.SurveyDate = DateTime.ParseExact(surveyDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            tblPole.SurveyDate = Convert.ToDateTime(surveyDate) != null ? Convert.ToDateTime(surveyDate) : DateTime.Now;

            //tblPole.WireLength = Convert.ToDouble(tblPole.WireLength);
            //tblPole.Latitude = Convert.ToDouble(tblPole.Latitude);
            //tblPole.Longitude = Convert.ToDouble(tblPole.Longitude);

            if (ModelState.IsValid)
            {
                _context.Add(tblPole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineTypeId"] = new SelectList(_context.LookUpLineType, "Code", "Name");
            ViewData["TypeOfWireId"] = new SelectList(_context.LookUpTypeOfWire, "Code", "Name");
            ViewData["PhaseAId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseBId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseCId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PoleConditionId"] = new SelectList(_context.LookUpPoleCondition, "PoleConditionId", "PoleConditionId");
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteName");
            ViewData["SourceCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["TargetCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["PoleTypeId"] = new SelectList(_context.LookUpPoleType, "PoleTypeId", "Name");
            ViewData["WireConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");
            var poleIdList = _context.TblPole.AsNoTracking()
           .Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList();
            ViewData["PreviousPoleId"] = poleIdList;

            //ViewData["PreviousPoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");

            ViewData["ZoneCode"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");
            return View(tblPole);
        }

        // GET: TblPoles1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPole = await _context.TblPole.FindAsync(id);
            if (tblPole == null)
            {
                return NotFound();
            }
            ViewData["LineTypeId"] = new SelectList(_context.LookUpLineType, "Code", "Name");
            ViewData["TypeOfWireId"] = new SelectList(_context.LookUpTypeOfWire, "Code", "Name");
            ViewData["PhaseAId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseBId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseCId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PoleConditionId"] = new SelectList(_context.LookUpPoleCondition, "PoleConditionId", "PoleConditionId");
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteName");
            ViewData["SourceCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["TargetCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["PoleTypeId"] = new SelectList(_context.LookUpPoleType, "PoleTypeId", "Name");
            ViewData["WireConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");
            return View(tblPole);
        }

        // POST: TblPoles1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PoleId,PoleUid,FeederLineUid,SurveyDate,RouteCode,FeederLineId,SurveyorName,PoleNo,PreviousPoleNo,Latitude,Longitude,PoleTypeId,PoleConditionId,LineTypeId,BackSpan,TypeOfWireId,NoOfWireHt,NoOfWireLt,WireLength,WireConditionId,MSJNo,SleeveNo,TwistNo,PhaseAId,PhaseBId,PhaseCId,Neutral,StreetLight,SourceCableId,TargetCableId,TransformerExist,CommonPole,Tap")] TblPole tblPole, string surveyDate)
        {

            string dateFormat = surveyDate.ToString();

            tblPole.SurveyDate = Convert.ToDateTime(dateFormat) != null ? Convert.ToDateTime(dateFormat) : DateTime.Now;



            if (id != tblPole.PoleId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {


                    _context.Update(tblPole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPoleExists(tblPole.PoleId))
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


            ViewData["LineTypeId"] = new SelectList(_context.LookUpLineType, "Code", "Name");
            ViewData["TypeOfWireId"] = new SelectList(_context.LookUpTypeOfWire, "Code", "Name");
            ViewData["PhaseAId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseBId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseCId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PoleConditionId"] = new SelectList(_context.LookUpPoleCondition, "PoleConditionId", "PoleConditionId");
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteName");
            ViewData["SourceCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["TargetCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["PoleTypeId"] = new SelectList(_context.LookUpPoleType, "PoleTypeId", "Name");
            ViewData["WireConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");
            return View(tblPole);
        }

        // GET: TblPoles1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPole = await _context.TblPole
                .Include(t => t.LookUpLineType)
                .Include(t => t.LookUpTypeOfWire)
                .Include(t => t.PhaseACondition)
                .Include(t => t.PhaseBCondition)
                .Include(t => t.PhaseCCondition)
                .Include(t => t.PoleCondition)
                .Include(t => t.PoleToFeederLine)
                .Include(t => t.PoleToRoute)

                .Include(t => t.PoleType)
                .Include(t => t.WireLookUpCondition)
                .FirstOrDefaultAsync(m => m.PoleId == id);
            if (tblPole == null)
            {
                return NotFound();
            }

            return View(tblPole);
        }

        // POST: TblPoles1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblPole = await _context.TblPole.FindAsync(id);
            _context.TblPole.Remove(tblPole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPoleExists(string id)
        {
            return _context.TblPole.Any(e => e.PoleId == id);
        }
        [HttpPost]
        public JsonResult GetCircleList(string zoneCode)
        {
            var circleList = _context.LookUpCircleInfo
                .Where(u => u.ZoneCode.Equals(zoneCode))
                .Select(u => new { u.CircleCode, u.CircleName })
                .OrderBy(u => u.CircleCode).ToList();

            return Json(new SelectList(circleList, "CircleCode", "CircleName"));
        }

        public JsonResult GetSnDList(string circleCode)
        {
            var sndList = _context.LookUpSnDInfo
                .Where(u => u.CircleCode.Equals(circleCode))
                .Select(u => new { u.SnDCode, u.SnDName })
                .OrderBy(u => u.SnDCode).ToList();

            return Json(new SelectList(sndList, "SnDCode", "SnDName"));
        }

        public JsonResult GetSubStationList(string sndCode)
        {
            var substationList = _context.TblSubstation
                .Where(u => u.SnDCode.Equals(sndCode))
                .Select(u => new { u.SubstationId, u.SubstationName })
                .OrderBy(u => u.SubstationId).ToList();

            return Json(new SelectList(substationList, "SubstationId", "SubstationName"));
        }

        public JsonResult GetRouteList(string substationId)
        {
            var sndList = _context.LookUpRouteInfo
                .Where(u => u.SubstationId.Equals(substationId))
                .Select(u => new { u.RouteCode, u.RouteName })
                .OrderBy(u => u.RouteCode).ToList();

            return Json(new SelectList(sndList, "RouteCode", "RouteName"));
        }


        public JsonResult GetFeederLineList(string routeCode)
        {
            var sndList = _context.TblFeederLine
                .Where(u => u.RouteCode.Equals(routeCode))
                .Select(u => new { u.FeederLineId, FeederName = u.FeederName })
                .OrderBy(u => u.FeederLineId).ToList();

            return Json(new SelectList(sndList, "FeederLineId", "FeederName"));
        }

        public JsonResult GetPoleList(string feederLineId)
        {

            var poleNo = _context.TblPole
                .Where(u => u.FeederLineId.Equals(feederLineId)).OrderBy(u => u.PoleId).Select(u => u.PoleId).LastOrDefault();

            var poleId = Convert.ToInt64(poleNo);

            poleId = Convert.ToInt64(poleNo);

            if (poleNo == "")
            {
                poleId = Convert.ToInt64(feederLineId + "0001");
            }

            return Json(poleId);
        }

        //public async Task<IActionResult> JCP()
        //{
        //    //var pdbDbContext = _context.TblPole.Include(t => t.LookUpLineType).Include(t => t.LookUpTypeOfWire).Include(t => t.PhaseACondition).Include(t => t.PhaseBCondition).Include(t => t.PhaseCCondition).Include(t => t.PoleCondition).Include(t => t.PoleToFeederLine).Include(t => t.PoleToRoute).Include(t => t.PoleToSourceFeederLine).Include(t => t.PoleToTargetFeederLine).Include(t => t.PoleType).Include(t => t.WireLookUpCondition);
        //    return View();
        //}
    }
}
