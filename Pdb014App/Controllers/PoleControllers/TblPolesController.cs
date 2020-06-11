using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Controllers.UserController;
using Pdb014App.Models.PDB;
using Pdb014App.Models.UserManage;
using Pdb014App.Models.UserManage.SetRole;
using Pdb014App.Repository;
using ReflectionIT.Mvc.Paging;

namespace Pdb014App.Controllers.PoleControllers
{
    //[Authorize]
    public class TblPolesController : Controller
    {
        private readonly UserManager<TblUserRegistrationDetail> _userManger;
       


        private readonly PdbDbContext _context;

        public TblPolesController(PdbDbContext context, UserManager<TblUserRegistrationDetail> UserManager)
        {
            _context = context;            
            _userManger = UserManager;
        }

        // GET: TblPoles1
        [Authorize(Roles = "System Administrator,Super User,Zone,Circle,SnD,Substation")]
        //public async Task<IActionResult> Index([FromQuery] string cai, string poleId, string condition, string feederLineName, int pageIndex = 1, string sortExpression = "PoleId")
        public async Task<IActionResult> Index([FromQuery] string cai, string fieldName, string fieldValue, int pageIndex = 1, string sortExpression = "PoleId")
        {

            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "plt.PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Name"}
                //new SelectListItem {Value = "fltl.FeederLineTypeName", Text = "Feeder Line Type"},
                //new SelectListItem {Value = "flcl.FeederConductorType", Text = "Feeder Conductor Type"},
                //new SelectListItem {Value = "roil.RouteName", Text = "Route Name"},
                //new SelectListItem {Value = "plt.PoleNo", Text = "Pole No"},
                //new SelectListItem {Value = "plt.PreviousPoleNo", Text = "Previous Pole No"},
                //new SelectListItem {Value = "pltl.PoleTypeName.Name", Text = "Pole Type"},
                //new SelectListItem {Value = "plcl.PoleCondition.Name", Text = "Pole Condition"},
                //new SelectListItem {Value = "plt.MSJNo", Text = "MSJ No"},
                //new SelectListItem {Value = "plt.SleeveNo", Text = "Sleeve No"},
                //new SelectListItem {Value = "plt.TwistNo", Text = "Twist No"},
                //new SelectListItem {Value = "plt.PhaseA", Text = "Phase A"},
                //new SelectListItem {Value = "plt.PhaseB", Text = "Phase B"},
                //new SelectListItem {Value = "plt.PhaseC", Text = "Phase C"},
                //new SelectListItem {Value = "plt.Neutral", Text = "Neutral"},
                //new SelectListItem {Value = "plt.StreetLight", Text = "Street Light"},
                //new SelectListItem {Value = "plt.Latitude", Text = "Latitude"},
                //new SelectListItem {Value = "plt.Longitude", Text = "Longitude"},
                //new SelectListItem {Value = "plt.SurveyDate", Text = "Survey Date"}
            };


            var fieldList = new SelectList(fields, "Value", "Text");
            ViewBag.FieldList = fieldList;

            //string getSql = await GetQuery("TblPole", "PoleId");
            var user = await _userManger.GetUserAsync(User);
            IList<string> userRole = await _userManger.GetRolesAsync(user);
            string getSql = new GetUserDetailsController(_context).GetUserRoleWiseQuery("TblPole", "PoleId", user.Id, userRole);

            //string getSql = await new GetUserRoleData(_contextUser, _userManger).GetQuery("TblPole", "PoleId");

            var query = _context.TblPole.FromSqlRaw(getSql).Include(i => i.PoleType).Include(i => i.PoleToRoute).Include(i => i.PoleToFeederLine).Include(i => i.PoleCondition).Include(i => i.LookUpLineType).Include(i => i.LookUpTypeOfWire).Include(i => i.WireLookUpCondition).Include(i => i.PhaseACondition).Include(i => i.PhaseBCondition).Include(i => i.PhaseCCondition).AsQueryable();


            #region lemda epression
            //Expression<Func<TblPole, bool>> searchExp = null;
            //Expression<Func<TblPole, bool>> tempExp = null;

            //var user = await _userManger.GetUserAsync(User);

            //if (User.IsInRole("System Administrator"))
            //{
            //    searchExp = null;
            //}

            //else if ((User.IsInRole("Super User") && User.IsInRole("Zone")) || User.IsInRole("Zone"))
            //{
            //    //var user = await _userManger.GetUserAsync(User);
            //    string zoneCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.ZoneCode).SingleOrDefault();
            //    searchExp = i => i.PoleId.Substring(0, 1).Contains(zoneCode);
            //}
            //else if ((User.IsInRole("Super User") && User.IsInRole("Circle")) || User.IsInRole("Circle"))
            //{
            //    //var user = await _userManger.GetUserAsync(User);
            //    string circleCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.CircleCode).SingleOrDefault();
            //    searchExp = i => i.PoleId.Substring(0, 3).Contains(circleCode);
            //}
            //else if ((User.IsInRole("Super User") && User.IsInRole("SnD")) || User.IsInRole("SnD"))
            //{
            //    //var user = await _userManger.GetUserAsync(User);
            //    string sndCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SnDCode).SingleOrDefault();
            //    searchExp = i => i.PoleId.Substring(0, 5).Contains(sndCode);

            //}
            //else if ((User.IsInRole("Super User") && User.IsInRole("Substation")) || User.IsInRole("Substation"))
            //{
            //    //var user = await _userManger.GetUserAsync(User);
            //    string SubstationId = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SubstationId).SingleOrDefault();
            //    searchExp = i => i.PoleId.Substring(0, 7).Contains(SubstationId);

            //}

            //tempExp = p => p.PoleId.Contains(filter);
            //searchExp = searchExp!=null? ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp): tempExp;    
            //var qry = searchExp != null ? _context.TblPole.Where(searchExp).Include(t => t.LookUpLineType).Include(t => t.LookUpTypeOfWire).Include(t => t.PhaseACondition).Include(t => t.PhaseBCondition).Include(t => t.PhaseCCondition).Include(t => t.PoleCondition).Include(t => t.PoleToFeederLine).Include(t => t.PoleToRoute).Include(t => t.PoleType).Include(t => t.WireLookUpCondition).AsQueryable() :
            //                              _context.TblPole.Include(t => t.LookUpLineType).Include(t => t.LookUpTypeOfWire).Include(t => t.PhaseACondition).Include(t => t.PhaseBCondition).Include(t => t.PhaseCCondition).Include(t => t.PoleCondition).Include(t => t.PoleToFeederLine).Include(t => t.PoleToRoute).Include(t => t.PoleType).Include(t => t.WireLookUpCondition).AsQueryable();

            #endregion

            if (query == null)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }


            if (fieldName != null && fieldValue != null)
            {

                if (fieldName == "plt.PoleId")
                {

                    query = query.Where(p => p.PoleId.Contains(fieldValue));
                }
                else
                {
                    query = query.Where(p => p.PoleToFeederLine.FeederName.Contains(fieldValue));
                }

            }


            var model = await PagingList.CreateAsync(query, 10, pageIndex, sortExpression, "PoleId");
            //model.RouteValue = new RouteValueDictionary { { "cai", cai }, { "FeederLineName", feederLineName }, { "Condition", condition }, { "PoleId", poleId } };
            model.RouteValue = new RouteValueDictionary { { "cai", cai }, { "FieldName", fieldName }, { "FieldValue", fieldValue } };


            return View(model);
        }


        public IActionResult Components(string poleId, int isShowLayout = 0, int isShowAction = 0)
        {
            ViewBag.PoleId = poleId;
            ViewBag.IsShowLayout = isShowLayout;
            ViewBag.IsShowAction = isShowAction;

            return View("Components");
            //return View("Pole");
        }


        //public async Task<string> GetQuery(string tableName, string fieldName)
        //{
        //    var user = await UserManager.GetUserAsync(User);


        //    var sql = "";

        //    if (User.IsInRole("System Administrator"))
        //    {
        //        sql = $"Select * from  {tableName}";
        //    }


        //    else if ((User.IsInRole("Super User") && User.IsInRole("Zone")) || User.IsInRole("Zone"))
        //    {
        //        //var user = await _userManger.GetUserAsync(User);
        //        string zoneCode = contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.ZoneCode).SingleOrDefault();
        //        sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,1)={zoneCode}";

        //    }
        //    else if ((User.IsInRole("Super User") && User.IsInRole("Circle")) || User.IsInRole("Circle"))
        //    {
        //        //var user = await _userManger.GetUserAsync(User);
        //        string circleCode = contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.CircleCode).SingleOrDefault();
        //        sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,3)={circleCode}";
        //    }
        //    else if ((User.IsInRole("Super User") && User.IsInRole("SnD")) || User.IsInRole("SnD"))
        //    {
        //        //var user = await _userManger.GetUserAsync(User);
        //        string sndCode = contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SnDCode).SingleOrDefault();
        //        sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,5)={sndCode}";

        //    }
        //    else if ((User.IsInRole("Super User") && User.IsInRole("Substation")) || User.IsInRole("Substation"))
        //    {
        //        //var user = await _userManger.GetUserAsync(User);
        //        string SubstationId = contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SubstationId).SingleOrDefault();
        //        sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,7)={SubstationId}";

        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    return sql;
        //}


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


        [Authorize(Roles = "System Administrator,Super User,Zone,Circle,SnD,Substation")]
        // GET: TblPoles1/Create
        public IActionResult Create()
        {

            ViewData["LineTypeId"] = new SelectList(_context.LookUpLineType, "Code", "Name");
            ViewData["TypeOfWireId"] = new SelectList(_context.LookUpTypeOfWire, "Code", "Name");
            ViewData["PhaseAId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseBId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseCId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PoleConditionId"] = new SelectList(_context.LookUpPoleCondition, "PoleConditionId", "Name");
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


        public decimal GetPoleDistance(double latA, double longA, double latB, double longB)
        {
            var RadianLatA = Math.PI * latA / 180;
            var RadianLatb = Math.PI * latB / 180;
            var RadianLongA = Math.PI * longA / 180;
            var RadianLongB = Math.PI * longB / 180;

            double theDistance = (Math.Sin(RadianLatA)) *
                                 Math.Sin(RadianLatb) +
                                 Math.Cos(RadianLatA) *
                                 Math.Cos(RadianLatb) *
                                 Math.Cos(RadianLongA - RadianLongB);

            var dis = Convert.ToDecimal(((Math.Acos(theDistance) * (180.0 / Math.PI)))) * 69.09M * 1.6093M;

            return dis * 1000;
        }


        // POST: TblPoles1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoleId,PoleUid,FeederLineUid,SurveyDate,RouteCode,FeederLineId,SurveyorName,PoleNo,PreviousPoleNo,Latitude,Longitude,PoleTypeId,PoleConditionId,LineTypeId,BackSpan,TypeOfWireId,NoOfWireHt,NoOfWireLt,WireLength,WireConditionId,MSJNo,SleeveNo,TwistNo,PhaseAId,PhaseBId,PhaseCId,Neutral,StreetLight,SourceCableId,TargetCableId,TransformerExist,CommonPole,Tap")] TblPole tblPole, string surveyDate)
        {

            double latA = Convert.ToDouble(tblPole.Latitude);
            double longA = Convert.ToDouble(tblPole.Longitude);
            double latB = Convert.ToDouble(_context.TblPole.Where(i => i.PoleId == tblPole.PreviousPoleNo).Select(i => i.Latitude).SingleOrDefault());
            double longB = Convert.ToDouble(_context.TblPole.Where(i => i.PoleId == tblPole.PreviousPoleNo).Select(i => i.Longitude).SingleOrDefault());

            var poleDistance = GetPoleDistance(latA, longA, latB, longB);

            if (poleDistance > 500)
            {
                TempData["statuMessageError"] = "Pole Distance is " + poleDistance.ToString("#.##") + "! Pole distance can not more  then 500 miter";
                //return RedirectToAction("Create");
            }
            else
            {
                tblPole.WireLength = poleDistance;
                tblPole.BackSpan = poleDistance.ToString("#.##");

                if (ModelState.IsValid)
                {
                    try
                    {
                        string UpdatePoleId = _context.TblPole.Where(i => i.PreviousPoleNo == tblPole.PreviousPoleNo).Select(i => i.PoleId).FirstOrDefault();
                        _context.Add(tblPole);
                        await _context.SaveChangesAsync();

                        //Update Pole After Inserting New pole Between Existing Pole
                        if (Convert.ToInt64(tblPole.PreviousPoleNo) != (Convert.ToInt64(tblPole.PoleId) - 1))
                        {
                            var findPoleInfo = await _context.TblPole.FindAsync(UpdatePoleId);
                            findPoleInfo.PreviousPoleNo = tblPole.PoleId;
                            _context.Update(findPoleInfo);
                            await _context.SaveChangesAsync();
                        }

                        TempData["statuMessageSuccess"] = "Pole has been added successfully";

                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        TempData["statuMessageError"] = ex.Message;

                    }
                }
            }



            ViewData["LineTypeId"] = new SelectList(_context.LookUpLineType, "Code", "Name");
            ViewData["TypeOfWireId"] = new SelectList(_context.LookUpTypeOfWire, "Code", "Name");
            ViewData["PhaseAId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseBId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseCId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PoleConditionId"] = new SelectList(_context.LookUpPoleCondition, "PoleConditionId", "Name");
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo, "RouteCode", "RouteName");
            ViewData["SourceCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["TargetCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["PoleTypeId"] = new SelectList(_context.LookUpPoleType, "PoleTypeId", "Name");
            ViewData["WireConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");
            var poleIdList = _context.TblPole.AsNoTracking().Select(pi => new SelectListItem() { Text = pi.PoleId, Value = pi.PoleId }).ToList();
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


            var feederLineId = id.Substring(0, 11);
            if (tblPole == null)
            {
                return NotFound();
            }
            ViewData["LineTypeId"] = new SelectList(_context.LookUpLineType, "Code", "Name");
            ViewData["TypeOfWireId"] = new SelectList(_context.LookUpTypeOfWire, "Code", "Name");
            ViewData["PhaseAId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseBId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseCId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PoleConditionId"] = new SelectList(_context.LookUpPoleCondition, "PoleConditionId", "Name");
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine.Where(i => i.FeederLineId == feederLineId), "FeederLineId", "FeederName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo.Where(i => i.RouteCode == feederLineId.Substring(0, 9)), "RouteCode", "RouteName");
            ViewData["SourceCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["TargetCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["PoleTypeId"] = new SelectList(_context.LookUpPoleType, "PoleTypeId", "Name");
            ViewData["WireConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");
            ViewData["PreviousPoleNo"] = new SelectList(_context.TblPole.Where(i => i.PoleId.Substring(0, 11).Contains(feederLineId)), "PoleId", "PoleId");
            return View(tblPole);
        }

        // POST: TblPoles1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PoleId,PoleUid,FeederLineUid,SurveyDate,RouteCode,FeederLineId,SurveyorName,PoleNo,PreviousPoleNo,Latitude,Longitude,PoleTypeId,PoleConditionId,LineTypeId,BackSpan,TypeOfWireId,NoOfWireHt,NoOfWireLt,WireLength,WireConditionId,MSJNo,SleeveNo,TwistNo,PhaseAId,PhaseBId,PhaseCId,Neutral,StreetLight,SourceCableId,TargetCableId,TransformerExist,CommonPole,Tap")] TblPole tblPole, string surveyDate)
        {
            var feederLineId = id.Substring(0, 11);

            if (id != tblPole.PoleId)
            {
                return NotFound();
            }

            double latA = Convert.ToDouble(tblPole.Latitude);
            double longA = Convert.ToDouble(tblPole.Longitude);
            double latB = Convert.ToDouble(_context.TblPole.Where(i => i.PoleId == tblPole.PreviousPoleNo).Select(i => i.Latitude).SingleOrDefault());
            double longB = Convert.ToDouble(_context.TblPole.Where(i => i.PoleId == tblPole.PreviousPoleNo).Select(i => i.Longitude).SingleOrDefault());

            var poleDistance = GetPoleDistance(latA, longA, latB, longB);

            if (poleDistance > 500)
            {
                TempData["statuMessageError"] = "Pole Distance is " + poleDistance.ToString("#.##") + "! Pole distance can not more  then 500 miter";
                //return RedirectToAction("Create");
            }
            else
            {
                tblPole.WireLength = poleDistance;
                tblPole.BackSpan = poleDistance.ToString("#.##");


                if (ModelState.IsValid)
                {
                    try
                    {

                        string UpdatePoleId = _context.TblPole.Where(i => i.PreviousPoleNo == tblPole.PreviousPoleNo).Select(i => i.PoleId).FirstOrDefault();
                        _context.Update(tblPole);
                        await _context.SaveChangesAsync();

                        if (Convert.ToInt64(tblPole.PreviousPoleNo) != (Convert.ToInt64(tblPole.PoleId) - 1))
                        {
                            var findPoleInfo = await _context.TblPole.FindAsync(UpdatePoleId);
                            findPoleInfo.PreviousPoleNo = tblPole.PoleId;
                            _context.Update(findPoleInfo);
                            await _context.SaveChangesAsync();
                        }

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
                    TempData["statuMessageSuccess"] = "Pole has been updated successfully";
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["LineTypeId"] = new SelectList(_context.LookUpLineType, "Code", "Name");
            ViewData["TypeOfWireId"] = new SelectList(_context.LookUpTypeOfWire, "Code", "Name");
            ViewData["PhaseAId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseBId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PhaseCId"] = new SelectList(_context.LookUpSagCondition, "SagConditionId", "Name");
            ViewData["PoleConditionId"] = new SelectList(_context.LookUpPoleCondition, "PoleConditionId", "Name");
            ViewData["FeederLineId"] = new SelectList(_context.TblFeederLine.Where(i => i.FeederLineId == feederLineId), "FeederLineId", "FeederName");
            ViewData["RouteCode"] = new SelectList(_context.LookUpRouteInfo.Where(i => i.RouteCode == feederLineId.Substring(0, 9)), "RouteCode", "RouteName");
            ViewData["SourceCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["TargetCableId"] = new SelectList(_context.TblFeederLine, "FeederLineId", "FeederName");
            ViewData["PoleTypeId"] = new SelectList(_context.LookUpPoleType, "PoleTypeId", "Name");
            ViewData["WireConditionId"] = new SelectList(_context.LookUpCondition, "Code", "Name");
            ViewData["PreviousPoleNo"] = new SelectList(_context.TblPole.Where(i => i.PoleId.Substring(0, 11).Contains(feederLineId)), "PoleId", "PoleId");
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
            TempData["statuMessageSuccess"] = "Pole has been deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool TblPoleExists(string id)
        {
            return _context.TblPole.Any(e => e.PoleId == id);
        }


        public JsonResult IsPoleIdExist(string id)
        {
            var validateName = _context.TblPole.FirstOrDefault
                                (x => x.PoleId == id);
            if (validateName != null)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
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

            //var poleNo = _context.TblPole
            //    .Where(u => u.FeederLineId.Equals(feederLineId)).OrderBy(u => u.PoleId).Select(u => u.PoleId).LastOrDefault();

            //var poleId = Convert.ToInt64(poleNo);

            //poleId = Convert.ToInt64(poleNo);

            //if (poleNo == "")
            //{
            //    poleId = Convert.ToInt64(feederLineId + "0000");
            //}


            var poleList = _context.TblPole
               .Where(u => u.FeederLineId.Equals(feederLineId)).OrderBy(u => u.PoleId)
               .Select(u => new { u.PoleId, FeederName = u.PoleId })
               .OrderByDescending(u => u.PoleId).ToList();


            //if (poleList.Count > 0)
            //{


            //else
            //{
            //    var poleId = Convert.ToInt64(feederLineId + "0000");
            //    return Json(poleId);
            //}



            return Json(new SelectList(poleList, "PoleId", "PoleId"));

        }


        //public async Task<IActionResult> JCP()
        //{
        //    //var pdbDbContext = _context.TblPole.Include(t => t.LookUpLineType).Include(t => t.LookUpTypeOfWire).Include(t => t.PhaseACondition).Include(t => t.PhaseBCondition).Include(t => t.PhaseCCondition).Include(t => t.PoleCondition).Include(t => t.PoleToFeederLine).Include(t => t.PoleToRoute).Include(t => t.PoleToSourceFeederLine).Include(t => t.PoleToTargetFeederLine).Include(t => t.PoleType).Include(t => t.WireLookUpCondition);
        //    return View();
        //}


    }
}
