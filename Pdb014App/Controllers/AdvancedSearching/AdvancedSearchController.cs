using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

using ReflectionIT.Mvc.Paging;

using Pdb014App.Repository;
using Pdb014App.Models.Search;
using Pdb014App.Models.PDB;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Models.PDB.DistributionTransformerModel;
using Pdb014App.Models.PDB.PhasePowerTransformerModel;


namespace Pdb014App.Controllers.AdvancedSearching
{
    public partial class AdvancedSearchingController : Controller
    {

        private readonly PdbDbContext _dbContext;

        public AdvancedSearchingController(PdbDbContext context)
        {
            _dbContext = context;
        }

    }



    //SearchPole
    public partial class AdvancedSearchingController : Controller
    {
        public async Task<IActionResult> SearchPole([FromQuery] string cai, int pageIndex = 1, string sort = "PoleId")
        {
            ViewBag.TotalRecords = _dbContext.TblPole.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);

            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "plt.PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "plt.SurveyDate", Text = "Survey Date"},
                new SelectListItem {Value = "roil.RouteName", Text = "Route Name"},
                new SelectListItem {Value = "plt.PoleNo", Text = "Pole No"},
                new SelectListItem {Value = "plt.PreviousPoleNo", Text = "Previous Pole No"},
                new SelectListItem {Value = "pltl.PoleTypeName.Name", Text = "Pole Type"},
                new SelectListItem {Value = "plcl.PoleCondition.Name", Text = "Pole Condition"},
                new SelectListItem {Value = "plt.MSJNo", Text = "MSJ No"},
                new SelectListItem {Value = "plt.SleeveNo", Text = "Sleeve No"},
                new SelectListItem {Value = "plt.TwistNo", Text = "Twist No"},
                new SelectListItem {Value = "plt.PhaseA", Text = "Phase A"},
                new SelectListItem {Value = "plt.PhaseB", Text = "Phase B"},
                new SelectListItem {Value = "plt.PhaseC", Text = "Phase C"},
                new SelectListItem {Value = "plt.Neutral", Text = "Neutral"},
                new SelectListItem {Value = "plt.StreetLight", Text = "Street Light"},
                new SelectListItem {Value = "plt.Latitude", Text = "Latitude"},
                new SelectListItem {Value = "plt.Longitude", Text = "Longitude"}
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };

            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;

            var qry = _dbContext.TblPole.AsNoTracking()
                .Include(pi => pi.PoleToFeederLine)
                .Include(pi => pi.PoleToRoute)
                .Include(pi => pi.PoleType)
                .Include(pi => pi.PoleCondition)
                .Include(pi => pi.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(pi => pi.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

            searchResult.RouteValue = new RouteValueDictionary() { { "cai", cai } };

            return View("SearchPole", searchResult);

        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchPole(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "PoleId")
        {
            ViewBag.TotalRecords = _dbContext.TblPole.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "plt.PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "plt.SurveyDate", Text = "Survey Date"},
                new SelectListItem {Value = "roil.RouteName", Text = "Route Name"},
                new SelectListItem {Value = "plt.PoleNo", Text = "Pole No"},
                new SelectListItem {Value = "plt.PreviousPoleNo", Text = "Previous Pole No"},
                new SelectListItem {Value = "pltl.PoleTypeName.Name", Text = "Pole Type"},
                new SelectListItem {Value = "plcl.PoleCondition.Name", Text = "Pole Condition"},
                new SelectListItem {Value = "plt.MSJNo", Text = "MSJ No"},
                new SelectListItem {Value = "plt.SleeveNo", Text = "Sleeve No"},
                new SelectListItem {Value = "plt.TwistNo", Text = "Twist No"},
                new SelectListItem {Value = "plt.PhaseA", Text = "Phase A"},
                new SelectListItem {Value = "plt.PhaseB", Text = "Phase B"},
                new SelectListItem {Value = "plt.PhaseC", Text = "Phase C"},
                new SelectListItem {Value = "plt.Neutral", Text = "Neutral"},
                new SelectListItem {Value = "plt.StreetLight", Text = "Street Light"},
                new SelectListItem {Value = "plt.Latitude", Text = "Latitude"},
                new SelectListItem {Value = "plt.Longitude", Text = "Longitude"}
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };


            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;


            Expression<Func<TblPole, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblPole, bool>> tempExp = model =>
                        model.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.PoleToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.PoleToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.PoleToRoute.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);

                                ViewBag.RouteList = new SelectList(_dbContext.LookUpRouteInfo
                                    .Where(ri => ri.RouteToSubstation.SubstationId.Equals(substationCode))
                                    .Select(ri => new { ri.RouteCode, ri.RouteName })
                                    .OrderBy(ri => ri.RouteCode).ToList(), "RouteCode", "RouteName", routeCode);
                            }
                        }
                    }
                }
            }

            ViewBag.RegionList = regionList;
            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName", zoneCode);

            var searchParametersRoute = new RouteValueDictionary()
            {
                { "cai", cai },
                {"regionList[0]", zoneCode},
                {"regionList[1]", circleCode},
                {"regionList[2]", snDCode},
                {"regionList[3]", substationCode},
                {"regionList[4]", routeCode}
            };

            if (searchParameters != null && searchParameters.Count > 0)
            {
                int pc = 0;
                string joinOption = "";
                //Expression<Func<TblPole, bool>> searchExp = null;

                foreach (var searchParameter in searchParameters)
                {
                    if (string.IsNullOrEmpty(searchParameter[0]) || string.IsNullOrEmpty(searchParameter[1]))
                        continue;

                    for (int oc = 0; oc < searchParameter.Count; oc++)
                    {
                        searchParametersRoute.Add("searchParameters[" + pc + "][" + oc + "]", searchParameter[oc]);
                    }
                    ++pc;

                    var searchOption = new SearchParameter
                    {
                        FieldName = searchParameter[0].Contains('.') ? searchParameter[0].Split('.')[1] : searchParameter[0],
                        Operator = searchParameter[1],
                        FieldValue = searchParameter[2],
                        JoinOption = searchParameter[3]
                    };

                    Expression<Func<TblPole, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "PoleId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PoleId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PoleId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PoleId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PoleId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "FeederLineId":
                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.PoleToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SurveyDate":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SurveyDate == DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.SurveyDate != DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.SurveyDate > DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.SurveyDate < DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.SurveyDate >= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.SurveyDate <= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SurveyDate == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SurveyDate != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SurveyDate.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "RouteName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleToRoute.RouteName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleToRoute.RouteName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleToRoute.RouteName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleToRoute.RouteName != null;
                                    break;
                            }

                            break;

                        case "PoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PreviousPoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PreviousPoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PreviousPoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PreviousPoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PreviousPoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PreviousPoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PoleTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleType.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleType.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleType.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleType.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleType.Name.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PoleCondition":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleCondition.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleCondition.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleCondition.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleCondition.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleCondition.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleCondition.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleCondition.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleCondition.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleCondition.Name.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "MSJNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MSJNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MSJNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.MSJNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.MSJNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.MSJNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.MSJNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MSJNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MSJNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MSJNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SleeveNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SleeveNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SleeveNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SleeveNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SleeveNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SleeveNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SleeveNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SleeveNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SleeveNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SleeveNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "TwistNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TwistNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TwistNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.TwistNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.TwistNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.TwistNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.TwistNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TwistNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TwistNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TwistNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseA":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseAId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseAId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseAId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseAId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseAId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseAId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseAId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseAId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseAId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseB":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseBId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseBId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseBId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseBId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseBId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseBId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseBId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseBId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseBId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseC":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseCId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseCId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseCId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseCId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseCId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseCId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseCId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseCId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseCId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Neutral":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Neutral == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Neutral != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.Neutral) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.Neutral) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.Neutral) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.Neutral) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Neutral == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Neutral != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Neutral.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "StreetLight":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.StreetLight == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.StreetLight != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.StreetLight == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.StreetLight != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.StreetLight.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;


                        case "Latitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Latitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Latitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Latitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Latitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Latitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Latitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Latitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Latitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Latitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Longitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Longitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Longitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Longitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Longitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Longitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Longitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Longitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Longitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Longitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;
                    }


                    if (searchExp == null)
                    {
                        searchExp = tempExp;
                    }
                    else
                    {
                        searchExp = joinOption.ToUpper() == "OR"
                            ? ExpressionExtension<TblPole>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }

            var qry = searchExp != null
                ? _dbContext.TblPole.AsNoTracking().Where(searchExp)
                : _dbContext.TblPole.AsNoTracking();

            qry = qry
                .Include(pi => pi.PoleToFeederLine)
                .Include(pi => pi.PoleToRoute)
                .Include(pi => pi.PoleType)
                .Include(pi => pi.PoleCondition)
                .Include(pi => pi.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(pi => pi.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchPole", searchResult);

        }

    }


    //SearchFeederLine
    public partial class AdvancedSearchingController : Controller
    {
        public async Task<IActionResult> SearchFeederLine([FromQuery] string cai, int pageIndex = 1, string sort = "FeederLineId")
        {
            ViewBag.TotalRecords = _dbContext.TblFeederLine.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);

            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "flt.FeederLineId", Text = "Feeder Line Id"},
                new SelectListItem {Value = "flt.FeederLineUId", Text = "Feeder Line UId"},
                new SelectListItem {Value = "fltl.FeederLineTypeName", Text = "Feeder Line Type"},
                new SelectListItem {Value = "roil.RouteName", Text = "Route Name"},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},
                new SelectListItem {Value = "flt.NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "flt.FeederLocation", Text = "Feeder Location"},
                new SelectListItem {Value = "flt.FeedermeterNumber", Text = "Feeder Meter Number"},
                new SelectListItem {Value = "flt.MeterCurrentRating", Text = "Meter Current Rating"},
                new SelectListItem {Value = "flt.MeterVoltageRating", Text = "Meter Voltage Rating"},
                new SelectListItem {Value = "flt.MaximumDemand", Text = "Maximum Demand"},
                new SelectListItem {Value = "flt.PeakDemand", Text = "Peak Demand"},
                new SelectListItem {Value = "flt.MaximumLoad", Text = "Maximum Load"},
                new SelectListItem {Value = "flt.SanctionedLoad", Text = "Sanctioned Load"},
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };

            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;


            var qry = _dbContext.TblFeederLine.AsNoTracking()
                .Include(fl => fl.FeederLineType)
                //.Include(fl => fl.FeederLineToRoute)
                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();


            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "FeederLineId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchFeederLine", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchFeederLine(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "FeederLineId")
        {
            ViewBag.TotalRecords = _dbContext.TblFeederLine.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;

            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "flt.FeederLineId", Text = "Feeder Line Id"},
                new SelectListItem {Value = "flt.FeederLineUId", Text = "Feeder Line UId"},
                new SelectListItem {Value = "fltl.FeederLineTypeName", Text = "Feeder Line Type"},
                new SelectListItem {Value = "roil.RouteName", Text = "Route Name"},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},
                new SelectListItem {Value = "flt.NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "flt.FeederLocation", Text = "Feeder Location"},
                new SelectListItem {Value = "flt.FeedermeterNumber", Text = "Feeder Meter Number"},
                new SelectListItem {Value = "flt.MeterCurrentRating", Text = "Meter Current Rating"},
                new SelectListItem {Value = "flt.MeterVoltageRating", Text = "Meter Voltage Rating"},
                new SelectListItem {Value = "flt.MaximumDemand", Text = "Maximum Demand"},
                new SelectListItem {Value = "flt.PeakDemand", Text = "Peak Demand"},
                new SelectListItem {Value = "flt.MaximumLoad", Text = "Maximum Load"},
                new SelectListItem {Value = "flt.SanctionedLoad", Text = "Sanctioned Load"},
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };

            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;


            Expression<Func<TblFeederLine, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblFeederLine, bool>> tempExp = model =>
                        model.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.FeederLineToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.FeederLineToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.FeederLineToRoute.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);

                                ViewBag.RouteList = new SelectList(_dbContext.LookUpRouteInfo
                                    .Where(ri => ri.RouteToSubstation.SubstationId.Equals(substationCode))
                                    .Select(ri => new { ri.RouteCode, ri.RouteName })
                                    .OrderBy(ri => ri.RouteCode).ToList(), "RouteCode", "RouteName", routeCode);
                            }
                        }
                    }
                }
            }

            ViewBag.RegionList = regionList;
            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName", zoneCode);

            var searchParametersRoute = new RouteValueDictionary()
            {
                { "cai", cai },
                {"regionList[0]", zoneCode},
                {"regionList[1]", circleCode},
                {"regionList[2]", snDCode},
                {"regionList[3]", substationCode},
                {"regionList[4]", routeCode}
            };

            if (searchParameters != null && searchParameters.Count > 0)
            {
                int pc = 0;
                string joinOption = "";
                //Expression<Func<TblFeederLine, bool>> searchExp = null;

                foreach (var searchParameter in searchParameters)
                {
                    if (string.IsNullOrEmpty(searchParameter[0]) || string.IsNullOrEmpty(searchParameter[1]))
                        continue;

                    for (int oc = 0; oc < searchParameter.Count; oc++)
                    {
                        searchParametersRoute.Add("searchParameters[" + pc + "][" + oc + "]", searchParameter[oc]);
                    }
                    ++pc;

                    var searchOption = new SearchParameter
                    {
                        FieldName = searchParameter[0].Contains('.')
                            ? searchParameter[0].Split('.')[1]
                            : searchParameter[0],
                        Operator = searchParameter[1],
                        FieldValue = searchParameter[2],
                        JoinOption = searchParameter[3]
                    };

                    Expression<Func<TblFeederLine, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "FeederLineId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLineId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLineId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.FeederLineId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.FeederLineId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.FeederLineId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.FeederLineId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLineId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLineId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLineId.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "FeederLineUId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLineUId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLineUId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineUId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineUId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineUId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineUId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLineUId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLineUId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLineUId.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "FeederLineTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineType.FeederLineTypeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineType.FeederLineTypeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineType.FeederLineTypeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineType.FeederLineTypeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "RouteName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLineToRoute.RouteName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLineToRoute.RouteName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineToRoute.RouteName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineToRoute.RouteName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineToRoute.RouteName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineToRoute.RouteName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLineToRoute.RouteName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLineToRoute.RouteName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLineToRoute.RouteName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NominalVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NominalVoltage == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.NominalVoltage != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.NominalVoltage > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.NominalVoltage < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.NominalVoltage >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.NominalVoltage <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NominalVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NominalVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NominalVoltage.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "FeederLocation":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLocation == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLocation != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederLocation) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederLocation) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLocation) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLocation) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLocation == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLocation != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLocation.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;




                        case "FeedermeterNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederMeterNumber == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederMeterNumber != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.FeederMeterNumber) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.FeederMeterNumber) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.FeederMeterNumber) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.FeederMeterNumber) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederMeterNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederMeterNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederMeterNumber.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "MeterCurrentRating":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MeterCurrentRating == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MeterCurrentRating != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MeterCurrentRating > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MeterCurrentRating < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MeterCurrentRating >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MeterCurrentRating <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MeterCurrentRating == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MeterCurrentRating != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MeterCurrentRating.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "MeterVoltageRating":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MeterVoltageRating == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MeterVoltageRating != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MeterVoltageRating > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MeterVoltageRating < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MeterVoltageRating >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MeterVoltageRating <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MeterVoltageRating == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MeterVoltageRating != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MeterVoltageRating.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "MaximumDemand":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MaximumDemand == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MaximumDemand != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MaximumDemand > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MaximumDemand < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MaximumDemand >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MaximumDemand <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MaximumDemand == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MaximumDemand != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MaximumDemand.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PeakDemand":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PeakDemand == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.PeakDemand != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.PeakDemand > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.PeakDemand < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.PeakDemand >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.PeakDemand <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PeakDemand == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PeakDemand != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PeakDemand.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "MaximumLoad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MaximumLoad == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MaximumLoad != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MaximumLoad > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MaximumLoad < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MaximumLoad >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MaximumLoad <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MaximumLoad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MaximumLoad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MaximumLoad.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "SanctionedLoad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SanctionedLoad == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.SanctionedLoad != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.SanctionedLoad > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.SanctionedLoad < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.SanctionedLoad >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.SanctionedLoad <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SanctionedLoad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SanctionedLoad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SanctionedLoad.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;
                    }


                    if (searchExp == null)
                    {
                        searchExp = tempExp;
                    }
                    else
                    {
                        searchExp = joinOption.ToUpper() == "OR"
                            ? ExpressionExtension<TblFeederLine>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }


            var qry = searchExp != null
                ? _dbContext.TblFeederLine.AsNoTracking().Where(searchExp)
                : _dbContext.TblFeederLine.AsNoTracking();

            qry = qry
                .Include(fl => fl.FeederLineType)
                //.Include(fl => fl.FeederLineToRoute)
                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(fl => fl.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "FeederLineId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchFeederLine", searchResult);

        }

    }


    //SearchSubstation
    public partial class AdvancedSearchingController : Controller
    {
        public async Task<IActionResult> SearchSubstation([FromQuery] string cai, int pageIndex = 1, string sort = "SubstationId")
        {
            ViewBag.TotalRecords = _dbContext.TblSubstation.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);

            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "sst.SubstationId", Text = "Substation Id"},
                new SelectListItem {Value = "sstl.SubstationTypeName", Text = "Substation Type"},
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "sst.SnDCode", Text = "S&D Code"},
                new SelectListItem {Value = "sst.NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "sst.InstalledCapacity", Text = "Installed Capacity"},
                new SelectListItem {Value = "sst.MaximumDemand", Text = "Maximum Demand"},
                new SelectListItem {Value = "sst.PeakLoad", Text = "Peak Load"},
                new SelectListItem {Value = "sst.Location", Text = "Location"},
                new SelectListItem {Value = "sst.AreaOfSubstation", Text = "Area of Substation"},
                new SelectListItem {Value = "sst.Latitude", Text = "Latitude"},
                new SelectListItem {Value = "sst.Longitude", Text = "Longitude"},
                new SelectListItem {Value = "sst.YearOfComissioning", Text = "Year of Commissioning"}
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };


            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;

            var qry = _dbContext.TblSubstation.AsNoTracking()
                .Include(st => st.SubstationType)
                .Include(st => st.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "SubstationId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchSubstation", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchSubstation(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "SubstationId")
        {
            ViewBag.TotalRecords = _dbContext.TblSubstation.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;

            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "sst.SubstationId", Text = "Substation Id"},
                new SelectListItem {Value = "sstl.SubstationTypeName", Text = "Substation Type"},
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "sst.SnDCode", Text = "S&D Code"},
                new SelectListItem {Value = "sst.NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "sst.InstalledCapacity", Text = "Installed Capacity"},
                new SelectListItem {Value = "sst.MaximumDemand", Text = "Maximum Demand"},
                new SelectListItem {Value = "sst.PeakLoad", Text = "Peak Load"},
                new SelectListItem {Value = "sst.Location", Text = "Location"},
                new SelectListItem {Value = "sst.AreaOfSubstation", Text = "Area of Substation"},
                new SelectListItem {Value = "sst.Latitude", Text = "Latitude"},
                new SelectListItem {Value = "sst.Longitude", Text = "Longitude"},
                new SelectListItem {Value = "sst.YearOfComissioning", Text = "Year of Commissioning"}
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };

            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");

            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;


            Expression<Func<TblSubstation, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode;

            zoneCode = circleCode = snDCode = substationCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblSubstation, bool>> tempExp = model =>
                        model.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);

                            //if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            //{
                            //    routeCode = regionList[4];

                            //    tempExp = model => model.PoleToRoute.RouteCode == routeCode;
                            //    searchExp = ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);

                            //    ViewBag.RouteList = new SelectList(_context.LookUpRouteInfo
                            //        .Where(ri => ri.RouteToSubstation.SubstationId.Equals(substationCode))
                            //        .Select(ri => new { ri.RouteCode, ri.RouteName })
                            //        .OrderBy(ri => ri.RouteCode).ToList(), "RouteCode", "RouteName", routeCode);
                            //}
                        }
                    }
                }
            }

            ViewBag.RegionList = regionList;
            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName", zoneCode);


            var searchParametersRoute = new RouteValueDictionary()
            {
                { "cai", cai },
                {"regionList[0]", zoneCode},
                {"regionList[1]", circleCode},
                {"regionList[2]", snDCode},
                {"regionList[3]", substationCode},
                //{"regionList[4]", routeCode}
            };


            if (searchParameters != null && searchParameters.Count > 0)
            {
                int pc = 0;
                string joinOption = "";

                foreach (var searchParameter in searchParameters)
                {
                    if (string.IsNullOrEmpty(searchParameter[0]) || string.IsNullOrEmpty(searchParameter[1]))
                        continue;

                    for (int oc = 0; oc < searchParameter.Count; oc++)
                    {
                        searchParametersRoute.Add("searchParameters[" + pc + "][" + oc + "]", searchParameter[oc]);
                    }
                    ++pc;

                    var searchOption = new SearchParameter
                    {
                        FieldName = searchParameter[0].Contains('.')
                            ? searchParameter[0].Split('.')[1]
                            : searchParameter[0],
                        Operator = searchParameter[1],
                        FieldValue = searchParameter[2],
                        JoinOption = searchParameter[3]
                    };

                    Expression<Func<TblSubstation, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "SubstationId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SubstationId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SubstationId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SubstationId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SubstationId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SubstationId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SubstationId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SubstationId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SubstationId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SubstationId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SubstationTypeId":
                        case "SubstationTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SubstationType.SubstationTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SubstationType.SubstationTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SubstationType.SubstationTypeName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SubstationType.SubstationTypeName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SubstationType.SubstationTypeName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SubstationType.SubstationTypeName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SubstationType.SubstationTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SubstationType.SubstationTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.SubstationType.SubstationTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SubstationName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SubstationName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SubstationName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SubstationName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SubstationName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SubstationName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SubstationName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SubstationName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SubstationName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SubstationName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SnDCode":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SnDCode == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SnDCode != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SnDCode) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SnDCode) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SnDCode) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SnDCode) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SnDCode == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SnDCode != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SnDCode.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "NominalVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NominalVoltage == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NominalVoltage != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NominalVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NominalVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NominalVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NominalVoltage) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NominalVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NominalVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NominalVoltage.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "InstalledCapacity":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.InstalledCapacity == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.InstalledCapacity != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.InstalledCapacity) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.InstalledCapacity) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.InstalledCapacity) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.InstalledCapacity) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.InstalledCapacity == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.InstalledCapacity != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.InstalledCapacity.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "MaximumDemand":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MaximumDemand == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MaximumDemand != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MaximumDemand > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MaximumDemand < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MaximumDemand >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MaximumDemand <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MaximumDemand == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MaximumDemand != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MaximumDemand.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PeakLoad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PeakLoad == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.PeakLoad != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.PeakLoad > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.PeakLoad < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.PeakLoad >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.PeakLoad <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PeakLoad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PeakLoad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PeakLoad.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Location":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Location == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Location != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.Location) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.Location) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.Location) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.Location) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Location == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Location != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Location.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "AreaOfSubstation":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.AreaOfSubstation == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.AreaOfSubstation != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.AreaOfSubstation) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.AreaOfSubstation) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.AreaOfSubstation) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.AreaOfSubstation) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.AreaOfSubstation == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.AreaOfSubstation != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.AreaOfSubstation.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;



                        case "Latitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Latitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Latitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Latitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Latitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Latitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Latitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Latitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Latitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Latitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Longitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Longitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Longitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Longitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Longitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Longitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Longitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Longitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Longitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Longitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "YearOfComissioning":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.YearOfComissioning == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.YearOfComissioning != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        DateTime.Parse(model.YearOfComissioning) > DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        DateTime.Parse(model.YearOfComissioning) < DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        DateTime.Parse(model.YearOfComissioning) >= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        DateTime.Parse(model.YearOfComissioning) <= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.YearOfComissioning == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.YearOfComissioning != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.YearOfComissioning.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;
                    }


                    if (searchExp == null)
                    {
                        searchExp = tempExp;
                    }
                    else
                    {
                        searchExp = joinOption.ToUpper() == "OR"
                            ? ExpressionExtension<TblSubstation>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                //if (searchExp != null)
                //    qry = qry.Where(searchExp);
            }


            var qry = searchExp != null
                ? _dbContext.TblSubstation.AsNoTracking().Where(searchExp)
                : _dbContext.TblSubstation.AsNoTracking();

            qry = qry
                .Include(st => st.SubstationType)
                .Include(st => st.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "SubstationId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchSubstation", searchResult);
        }

    }


    //SearchDistributionTransformer
    public partial class AdvancedSearchingController : Controller
    {
        public async Task<IActionResult> SearchDistributionTransformer([FromQuery] string cai, int pageIndex = 1, string sort = "DistributionTransformerId")
        {
            ViewBag.TotalRecords = _dbContext.TblDistributionTransformer.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);

            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "dtt.DistributionTransformerId", Text = "Distribution Transformer Id"},
                new SelectListItem {Value = "dtt.NameOf33bs11kVSubdsstation", Text = "Name of 33/11kV Sub-station"},
                new SelectListItem {Value = "dtt.Nameof11kVFeeder", Text = "Name of 11kV Feeder"},
                new SelectListItem {Value = "dtt.SNDIdentificationNo", Text = "SND Id No."},
                new SelectListItem {Value = "dtt.NearestHoldingbsHouseNobsShop", Text = "Nearest Holding/HouseNo/Shop"},
                new SelectListItem {Value = "dtt.ExistingPoleNumberingifAny", Text = "Existing Pole Numbering (if Any)"},
                new SelectListItem {Value = "dtt.InstalledConditionPadbsPoleMounted", Text = "Installed Condition (Pad/Pole Mounted)"},
                new SelectListItem {Value = "dtt.InstalledPlaceIndoorbsOutdoor", Text = "Installed Place (Indoor/Outdoor)"},
                new SelectListItem {Value = "dtt.ContractNo", Text = "Contract No."},
                new SelectListItem {Value = "dtt.OwneroftheTransformerBPDBbsConsumer", Text = "Owner of the Transformer (BPDB/Consumer)"},
                new SelectListItem {Value = "dtt.TransformerKVARating", Text = "Transformer KVA Rating"},
                new SelectListItem {Value = "dtt.YearofManufacturing", Text = "Year of Manufacturing"},
                new SelectListItem {Value = "dtt.NameofManufacturer", Text = "Name of Manufacturer"},
                new SelectListItem {Value = "dtt.BodyColourCondition", Text = "Body Colour Condition"},
                new SelectListItem {Value = "dtt.NameoBodyColour", Text = "Name of Body Colour"},
                new SelectListItem {Value = "dtt.OilLeakageYesOrNo", Text = "Oil Leakage (Yes/No)"},
                new SelectListItem {Value = "dtt.PlaceofOilLeakageMark", Text = "Place of Oil Leakage Mark"},
                new SelectListItem {Value = "dtt.PlatformMaterialAnglbsChannel", Text = "Platform Material (Angle/Channel)"},
                new SelectListItem {Value = "dtt.PlatformStandardbsNonStandardGoodBad", Text = "Platform (Standard/NonStandard/Good/Bad)"},
                new SelectListItem {Value = "dtt.TypeofTransformerSupportPoleLeft", Text = "Type of Transformer Support Pole (Left)"},
                new SelectListItem {Value = "dtt.ConditionofTransformerSupportPoleLeft", Text = "Condition of Transformer Support Pole (Left)"},
                new SelectListItem {Value = "dtt.TypeofTransformerSupportPoleRight", Text = "Type of Transformer Support Pole (Right)"},
                new SelectListItem {Value = "dtt.ConditionofTransformerSupportPoleRight", Text = "Condition of Transformer Support Pole (Right)"}
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };

            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;


            var qry = _dbContext.TblDistributionTransformer.AsNoTracking()
                .Include(dt => dt.DtToPole)
                //.Include(dt => dt.DtToFeederLine)
                .Include(dt => dt.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(dt => dt.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(dt => dt.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .Include(dt => dt.PoleStructureMountedSurgeArrestor)
                .AsQueryable();


            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "DistributionTransformerId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchDistributionTransformer", searchResult);

        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchDistributionTransformer(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "DistributionTransformerId")
        {
            ViewBag.TotalRecords = _dbContext.TblDistributionTransformer.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;

            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "dtt.DistributionTransformerId", Text = "Distribution Transformer Id"},
                new SelectListItem {Value = "dtt.NameOf33bs11kVSubdsstation", Text = "Name of 33/11kV Sub-station"},
                new SelectListItem {Value = "dtt.Nameof11kVFeeder", Text = "Name of 11kV Feeder"},
                new SelectListItem {Value = "dtt.SNDIdentificationNo", Text = "SND Id No."},
                new SelectListItem {Value = "dtt.NearestHoldingbsHouseNobsShop", Text = "Nearest Holding/HouseNo/Shop"},
                new SelectListItem {Value = "dtt.ExistingPoleNumberingifAny", Text = "Existing Pole Numbering (if Any)"},
                new SelectListItem {Value = "dtt.InstalledConditionPadbsPoleMounted", Text = "Installed Condition (Pad/Pole Mounted)"},
                new SelectListItem {Value = "dtt.InstalledPlaceIndoorbsOutdoor", Text = "Installed Place (Indoor/Outdoor)"},
                new SelectListItem {Value = "dtt.ContractNo", Text = "Contract No."},
                new SelectListItem {Value = "dtt.OwneroftheTransformerBPDBbsConsumer", Text = "Owner of the Transformer (BPDB/Consumer)"},
                new SelectListItem {Value = "dtt.TransformerKVARating", Text = "Transformer KVA Rating"},
                new SelectListItem {Value = "dtt.YearofManufacturing", Text = "Year of Manufacturing"},
                new SelectListItem {Value = "dtt.NameofManufacturer", Text = "Name of Manufacturer"},
                new SelectListItem {Value = "dtt.BodyColourCondition", Text = "Body Colour Condition"},
                new SelectListItem {Value = "dtt.NameoBodyColour", Text = "Name of Body Colour"},
                new SelectListItem {Value = "dtt.OilLeakageYesOrNo", Text = "Oil Leakage (Yes/No)"},
                new SelectListItem {Value = "dtt.PlaceofOilLeakageMark", Text = "Place of Oil Leakage Mark"},
                new SelectListItem {Value = "dtt.PlatformMaterialAnglbsChannel", Text = "Platform Material (Angle/Channel)"},
                new SelectListItem {Value = "dtt.PlatformStandardbsNonStandardGoodBad", Text = "Platform (Standard/NonStandard/Good/Bad)"},
                new SelectListItem {Value = "dtt.TypeofTransformerSupportPoleLeft", Text = "Type of Transformer Support Pole (Left)"},
                new SelectListItem {Value = "dtt.ConditionofTransformerSupportPoleLeft", Text = "Condition of Transformer Support Pole (Left)"},
                new SelectListItem {Value = "dtt.TypeofTransformerSupportPoleRight", Text = "Type of Transformer Support Pole (Right)"},
                new SelectListItem {Value = "dtt.ConditionofTransformerSupportPoleRight", Text = "Condition of Transformer Support Pole (Right)"}
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };

            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;


            Expression<Func<TblDistributionTransformer, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblDistributionTransformer, bool>> tempExp = model =>
                        model.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.DtToFeederLine.FeederLineToRoute.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);

                                ViewBag.RouteList = new SelectList(_dbContext.LookUpRouteInfo
                                    .Where(ri => ri.RouteToSubstation.SubstationId.Equals(substationCode))
                                    .Select(ri => new { ri.RouteCode, ri.RouteName })
                                    .OrderBy(ri => ri.RouteCode).ToList(), "RouteCode", "RouteName", routeCode);
                            }
                        }
                    }
                }
            }

            ViewBag.RegionList = regionList;
            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName", zoneCode);

            var searchParametersRoute = new RouteValueDictionary()
            {
                { "cai", cai },
                {"regionList[0]", zoneCode},
                {"regionList[1]", circleCode},
                {"regionList[2]", snDCode},
                {"regionList[3]", substationCode},
                {"regionList[4]", routeCode}
            };


            if (searchParameters != null && searchParameters.Count > 0)
            {
                int pc = 0;
                string joinOption = "";

                foreach (var searchParameter in searchParameters)
                {
                    if (string.IsNullOrEmpty(searchParameter[0]) || string.IsNullOrEmpty(searchParameter[1]))
                        continue;

                    for (int oc = 0; oc < searchParameter.Count; oc++)
                    {
                        searchParametersRoute.Add("searchParameters[" + pc + "][" + oc + "]", searchParameter[oc]);
                    }
                    ++pc;

                    var searchOption = new SearchParameter
                    {
                        FieldName = searchParameter[0].Contains('.')
                            ? searchParameter[0].Split('.')[1]
                            : searchParameter[0],
                        Operator = searchParameter[1],
                        FieldValue = searchParameter[2],
                        JoinOption = searchParameter[3]
                    };

                    Expression<Func<TblDistributionTransformer, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "DistributionTransformerId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.DistributionTransformerId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.DistributionTransformerId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.DistributionTransformerId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.DistributionTransformerId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.DistributionTransformerId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.DistributionTransformerId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.DistributionTransformerId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.DistributionTransformerId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.DistributionTransformerId.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NameOf33bs11kVSubdsstation":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NameOf33bs11kVSubdsstation) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NameOf33bs11kVSubdsstation) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NameOf33bs11kVSubdsstation) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NameOf33bs11kVSubdsstation) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "Nameof11kVFeeder":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Nameof11kVFeeder == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Nameof11kVFeeder != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Nameof11kVFeeder) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Nameof11kVFeeder) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Nameof11kVFeeder) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Nameof11kVFeeder) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Nameof11kVFeeder == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Nameof11kVFeeder != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Nameof11kVFeeder.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "SNDIdentificationNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SNDIdentificationNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SNDIdentificationNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SNDIdentificationNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SNDIdentificationNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SNDIdentificationNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SNDIdentificationNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SNDIdentificationNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SNDIdentificationNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SNDIdentificationNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "NearestHoldingbsHouseNobsShop":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NearestHoldingbsHouseNobsShop) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NearestHoldingbsHouseNobsShop) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NearestHoldingbsHouseNobsShop) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NearestHoldingbsHouseNobsShop) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ExistingPoleNumberingifAny":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ExistingPoleNumberingifAny == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ExistingPoleNumberingifAny != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ExistingPoleNumberingifAny) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ExistingPoleNumberingifAny) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ExistingPoleNumberingifAny) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ExistingPoleNumberingifAny) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ExistingPoleNumberingifAny == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ExistingPoleNumberingifAny != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ExistingPoleNumberingifAny.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "InstalledConditionPadbsPoleMounted":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.InstalledConditionPadbsPoleMounted) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.InstalledConditionPadbsPoleMounted) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.InstalledConditionPadbsPoleMounted) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.InstalledConditionPadbsPoleMounted) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "InstalledPlaceIndoorbsOutdoor":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.InstalledPlaceIndoorbsOutdoor) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.InstalledPlaceIndoorbsOutdoor) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.InstalledPlaceIndoorbsOutdoor) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.InstalledPlaceIndoorbsOutdoor) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ContractNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ContractNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ContractNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ContractNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ContractNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ContractNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ContractNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ContractNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ContractNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ContractNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "OwneroftheTransformerBPDBbsConsumer":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.OwneroftheTransformerBPDBbsConsumer) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.OwneroftheTransformerBPDBbsConsumer) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.OwneroftheTransformerBPDBbsConsumer) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.OwneroftheTransformerBPDBbsConsumer) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TransformerKVARating":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TransformerKVARating == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TransformerKVARating != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.TransformerKVARating) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.TransformerKVARating) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.TransformerKVARating) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.TransformerKVARating) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TransformerKVARating == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TransformerKVARating != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TransformerKVARating.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "YearofManufacturing":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.YearofManufacturing == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.YearofManufacturing != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.YearofManufacturing) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.YearofManufacturing) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.YearofManufacturing) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.YearofManufacturing) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.YearofManufacturing == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.YearofManufacturing != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.YearofManufacturing.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "NameofManufacturer":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NameofManufacturer == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NameofManufacturer != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NameofManufacturer) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NameofManufacturer) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NameofManufacturer) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NameofManufacturer) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NameofManufacturer == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NameofManufacturer != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NameofManufacturer.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "BodyColourCondition":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.BodyColourCondition == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.BodyColourCondition != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.BodyColourCondition) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.BodyColourCondition) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.BodyColourCondition) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.BodyColourCondition) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.BodyColourCondition == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.BodyColourCondition != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.BodyColourCondition.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "NameoBodyColour":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NameoBodyColour == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NameoBodyColour != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NameoBodyColour) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NameoBodyColour) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NameoBodyColour) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NameoBodyColour) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NameoBodyColour == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NameoBodyColour != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NameoBodyColour.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "OilLeakageYesOrNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.OilLeakageYesOrNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.OilLeakageYesOrNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.OilLeakageYesOrNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.OilLeakageYesOrNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.OilLeakageYesOrNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.OilLeakageYesOrNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.OilLeakageYesOrNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.OilLeakageYesOrNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.OilLeakageYesOrNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PlaceofOilLeakageMark":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PlaceofOilLeakageMark == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PlaceofOilLeakageMark != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PlaceofOilLeakageMark) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PlaceofOilLeakageMark) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PlaceofOilLeakageMark) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PlaceofOilLeakageMark) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PlaceofOilLeakageMark == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PlaceofOilLeakageMark != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PlaceofOilLeakageMark.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PlatformMaterialAnglbsChannel":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PlatformMaterialAnglbsChannel) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PlatformMaterialAnglbsChannel) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PlatformMaterialAnglbsChannel) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PlatformMaterialAnglbsChannel) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PlatformStandardbsNonStandardGoodBad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PlatformStandardbsNonStandardGoodBad) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PlatformStandardbsNonStandardGoodBad) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PlatformStandardbsNonStandardGoodBad) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PlatformStandardbsNonStandardGoodBad) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TypeofTransformerSupportPoleLeft":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleLeft) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleLeft) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleLeft) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleLeft) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ConditionofTransformerSupportPoleLeft":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleLeft) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleLeft) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleLeft) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleLeft) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TypeofTransformerSupportPoleRight":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleRight) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleRight) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleRight) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleRight) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ConditionofTransformerSupportPoleRight":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleRight) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleRight) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleRight) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleRight) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                    }


                    if (searchExp == null)
                    {
                        searchExp = tempExp;
                    }
                    else
                    {
                        searchExp = joinOption.ToUpper() == "OR"
                            ? ExpressionExtension<TblDistributionTransformer>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }


            var qry = searchExp != null
                ? _dbContext.TblDistributionTransformer.AsNoTracking().Where(searchExp)
                : _dbContext.TblDistributionTransformer.AsNoTracking();

            qry = qry
                .Include(dt => dt.DtToPole)
                //.Include(dt => dt.DtToFeederLine)
                .Include(dt => dt.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(dt => dt.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(dt => dt.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .Include(dt => dt.PoleStructureMountedSurgeArrestor)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "DistributionTransformerId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchDistributionTransformer", searchResult);

        }

    }


    //SearchPowerTransformer
    public partial class AdvancedSearchingController : Controller
    {
        public async Task<IActionResult> SearchPowerTransformer([FromQuery] string cai, int pageIndex = 1, string sort = "PhasePowerTransformerId")
        {
            ViewBag.TotalRecords = _dbContext.TblPhasePowerTransformer.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "ptt.PowerTransformerId", Text = "Power Transformer Id"},
                new SelectListItem {Value = "ptt.ManufacturersName", Text = "Manufacturers Name"},
                new SelectListItem {Value = "ptt.ManufacturersAddress", Text = "Manufacturers Address"},
                new SelectListItem {Value = "ptt.AppliedStandard", Text = "Applied Standard"},
                new SelectListItem {Value = "ptt.DescriptionType", Text = "Description Type"},
                new SelectListItem {Value = "ptt.SerialNumber", Text = "Serial Number"},
                new SelectListItem {Value = "ptt.RatedPower", Text = "Rated Power"},
                new SelectListItem {Value = "ptt.NumberofPhase", Text = "Number of Phase"}
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };


            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;


            var qry = _dbContext.TblPhasePowerTransformer.AsNoTracking()
                    .Include(pt => pt.PhasePowerTransformerTo33KvFeederLine)
                    .Include(pt => pt.PhasePowerTransformerTo33KvFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                    .Include(pt => pt.PhasePowerTransformerTo33KvFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                    .Include(pt => pt.PhasePowerTransformerTo33KvFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                    .Include(pt => pt.PhasePowerTransformerToSourceSubstation)
                    .Include(pt => pt.PhasePowerTransformerToTblSubstation)
                    .Include(pt => pt.PhasePowerTransformerToTblSubstation.SubstationType)
                    //.Include(pt => pt.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                    //.Include(pt => pt.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                    .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PhasePowerTransformerId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchPowerTransformer", searchResult);

        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchPowerTransformer(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "PhasePowerTransformerId")
        {
            ViewBag.TotalRecords = _dbContext.TblPhasePowerTransformer.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "ptt.PowerTransformerId", Text = "Power Transformer Id"},
                new SelectListItem {Value = "ptt.ManufacturersName", Text = "Manufacturers Name"},
                new SelectListItem {Value = "ptt.ManufacturersAddress", Text = "Manufacturers Address"},
                new SelectListItem {Value = "ptt.AppliedStandard", Text = "Applied Standard"},
                new SelectListItem {Value = "ptt.DescriptionType", Text = "Description Type"},
                new SelectListItem {Value = "ptt.SerialNumber", Text = "Serial Number"},
                new SelectListItem {Value = "ptt.RatedPower", Text = "Rated Power"},
                new SelectListItem {Value = "ptt.NumberofPhase", Text = "Number of Phase"}
            };

            var operators = new List<SelectListItem>
            {
                new SelectListItem {Value = "=", Text = "="},
                new SelectListItem {Value = "!=", Text = "!="},
                new SelectListItem {Value = ">", Text = ">"},
                new SelectListItem {Value = "<", Text = "<"},
                new SelectListItem {Value = ">=", Text = ">="},
                new SelectListItem {Value = "<=", Text = "<="},
                new SelectListItem {Value = "null", Text = "Is Null"},
                new SelectListItem {Value = "not null", Text = "Is Not Null"},
                new SelectListItem {Value = "Like", Text = "Like"}
            };


            var fieldList = new SelectList(fields, "Value", "Text");
            var operatorList = new SelectList(operators, "Value", "Text");


            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;


            Expression<Func<TblPhasePowerTransformer, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblPhasePowerTransformer, bool>> tempExp = model =>
                        model.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.PhasePowerTransformerToTblSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.PhasePowerTransformerToTblSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.PhasePowerTransformerTo33KvFeederLine.FeederLineToRoute.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);

                                ViewBag.RouteList = new SelectList(_dbContext.LookUpRouteInfo
                                    .Where(ri => ri.RouteToSubstation.SubstationId.Equals(substationCode))
                                    .Select(ri => new { ri.RouteCode, ri.RouteName })
                                    .OrderBy(ri => ri.RouteCode).ToList(), "RouteCode", "RouteName", routeCode);
                            }
                        }
                    }
                }
            }

            ViewBag.RegionList = regionList;
            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName", zoneCode);

            var searchParametersRoute = new RouteValueDictionary()
            {
                { "cai", cai },
                {"regionList[0]", zoneCode},
                {"regionList[1]", circleCode},
                {"regionList[2]", snDCode},
                {"regionList[3]", substationCode},
                {"regionList[4]", routeCode}
            };


            if (searchParameters != null && searchParameters.Count > 0)
            {
                int pc = 0;
                string joinOption = "";

                foreach (var searchParameter in searchParameters)
                {
                    if (string.IsNullOrEmpty(searchParameter[0]) || string.IsNullOrEmpty(searchParameter[1]))
                        continue;

                    for (int oc = 0; oc < searchParameter.Count; oc++)
                    {
                        searchParametersRoute.Add("searchParameters[" + pc + "][" + oc + "]", searchParameter[oc]);
                    }
                    ++pc;

                    var searchOption = new SearchParameter
                    {
                        FieldName = searchParameter[0].Contains('.')
                            ? searchParameter[0].Split('.')[1]
                            : searchParameter[0],
                        Operator = searchParameter[1],
                        FieldValue = searchParameter[2],
                        JoinOption = searchParameter[3]
                    };


                    Expression<Func<TblPhasePowerTransformer, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {

                        case "PowerTransformerId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhasePowerTransformerId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhasePowerTransformerId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PhasePowerTransformerId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PhasePowerTransformerId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PhasePowerTransformerId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PhasePowerTransformerId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhasePowerTransformerId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhasePowerTransformerId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhasePowerTransformerId.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;




                        case "ManufacturersName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufacturersName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufacturersName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufacturersName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufacturersName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufacturersName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "ManufacturersAddress":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufacturersAddress == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufacturersAddress != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersAddress) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersAddress) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersAddress) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersAddress) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufacturersAddress == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufacturersAddress != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufacturersAddress.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "AppliedStandard":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.AppliedStandard == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.AppliedStandard != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.AppliedStandard) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.AppliedStandard) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.AppliedStandard) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.AppliedStandard) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.AppliedStandard == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.AppliedStandard != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.AppliedStandard.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "DescriptionType":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.DescriptionType == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.DescriptionType != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.DescriptionType) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.DescriptionType) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.DescriptionType) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.DescriptionType) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.DescriptionType == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.DescriptionType != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.DescriptionType.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "SerialNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SerialNumber == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SerialNumber != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SerialNumber) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SerialNumber) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SerialNumber) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SerialNumber) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SerialNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SerialNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SerialNumber.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "RatedPower":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedPower == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedPower != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RatedPower) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RatedPower) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RatedPower) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RatedPower) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedPower == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedPower != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedPower.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NumberofPhase":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NumberOfPhase == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.NumberOfPhase != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.NumberOfPhase > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.NumberOfPhase < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.NumberOfPhase >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.NumberOfPhase <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => false;//model.NumberOfPhase == null;
                                    break;
                                case "not null":
                                    tempExp = model => true;//model.NumberOfPhase != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NumberOfPhase.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;
                    }

                    if (searchExp == null)
                    {
                        searchExp = tempExp;
                    }
                    else
                    {
                        searchExp = joinOption.ToUpper() == "OR"
                            ? ExpressionExtension<TblPhasePowerTransformer>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }


            var qry = searchExp != null
                ? _dbContext.TblPhasePowerTransformer.AsNoTracking().Where(searchExp)
                : _dbContext.TblPhasePowerTransformer.AsNoTracking();

            qry = qry
                .Include(pt => pt.PhasePowerTransformerTo33KvFeederLine)
                .Include(pt => pt.PhasePowerTransformerTo33KvFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(pt => pt.PhasePowerTransformerTo33KvFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(pt => pt.PhasePowerTransformerTo33KvFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .Include(pt => pt.PhasePowerTransformerToSourceSubstation)
                .Include(pt => pt.PhasePowerTransformerToTblSubstation)
                .Include(pt => pt.PhasePowerTransformerToTblSubstation.SubstationType)
                //.Include(pt => pt.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                //.Include(pt => pt.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();


            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PhasePowerTransformerId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchPowerTransformer", searchResult);

        }

    }


}