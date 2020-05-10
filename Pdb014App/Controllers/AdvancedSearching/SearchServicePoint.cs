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

using Pdb014App.Models.Search;
using Pdb014App.Models.PDB.ServicePointModels;


namespace Pdb014App.Controllers.AdvancedSearching
{
    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchServicePoint([FromQuery] string cai, int pageIndex = 1, string sort = "ServicePointId")
        {
            ViewBag.TotalRecords = _dbContext.TblServicePoint.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "spt.ServicePointId", Text = "Service Point Id"},

                new SelectListItem {Value = "plt.PoleNo", Text = "Pole No."},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},

                new SelectListItem {Value = "sptl.ServicePointTypeName", Text = "Service Point Type"},
                new SelectListItem {Value = "vocl.VoltageCategoryName", Text = "Voltage Category"},

                new SelectListItem {Value = "spt.TransformerNumber", Text = "Transformer Number"},
                new SelectListItem {Value = "spt.RoadName", Text = "Road Name"},
                new SelectListItem {Value = "spt.VillageOrAreaName", Text = "Village/Area Name"},
                new SelectListItem {Value = "spt.Ward", Text = "Ward"},
                new SelectListItem {Value = "spt.CityTown", Text = "City Town"},
                new SelectListItem {Value = "spt.PrimaryLandmark", Text = "Primary Landmark"}
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

            var qry = _dbContext.TblServicePoint.AsNoTracking()
                .Include(sp => sp.ServicePointType)
                .Include(sp => sp.VoltageCategory)
                .Include(sp => sp.ServicePointToPole)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "ServicePointId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchServicePoint", searchResult);

        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchServicePoint(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "ServicePointId")
        {
            ViewBag.TotalRecords = _dbContext.TblServicePoint.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "spt.ServicePointId", Text = "Service Point Id"},

                new SelectListItem {Value = "plt.PoleNo", Text = "Pole No."},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},

                new SelectListItem {Value = "sptl.ServicePointTypeName", Text = "Service Point Type"},
                new SelectListItem {Value = "vocl.VoltageCategoryName", Text = "Voltage Category"},

                new SelectListItem {Value = "spt.TransformerNumber", Text = "Transformer Number"},
                new SelectListItem {Value = "spt.RoadName", Text = "Road Name"},
                new SelectListItem {Value = "spt.VillageOrAreaName", Text = "Village/Area Name"},
                new SelectListItem {Value = "spt.Ward", Text = "Ward"},
                new SelectListItem {Value = "spt.CityTown", Text = "City Town"},
                new SelectListItem {Value = "spt.PrimaryLandmark", Text = "Primary Landmark"}
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


            Expression<Func<TblServicePoint, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblServicePoint, bool>> tempExp = model =>
                        model.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.ServicePointToPole.PoleToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4)
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.ServicePointToPole.PoleToRoute.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);

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
                        FieldName = searchParameter[0].Contains('.') ? searchParameter[0].Split('.')[1] : searchParameter[0],
                        Operator = searchParameter[1],
                        FieldValue = searchParameter[2],
                        JoinOption = searchParameter[3]
                    };

                    Expression<Func<TblServicePoint, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {

                        case "ServicePointId":
                            switch (searchOption.Operator)
                            {

                                // Hide By RMO
                                //case "=":
                                //    tempExp = model => model.ServicePointId == int.Parse(searchOption.FieldValue);
                                //    break;
                                //case "!=":
                                //    tempExp = model => model.ServicePointId != int.Parse(searchOption.FieldValue);
                                //    break;
                                //case ">":
                                //    tempExp = model => model.ServicePointId > int.Parse(searchOption.FieldValue);
                                //    break;
                                //case "<":
                                //    tempExp = model => model.ServicePointId < int.Parse(searchOption.FieldValue);
                                //    break;
                                //case ">=":
                                //    tempExp = model => model.ServicePointId >= int.Parse(searchOption.FieldValue);
                                //    break;
                                //case "<=":
                                //    tempExp = model => model.ServicePointId <= int.Parse(searchOption.FieldValue);
                                //    break;
                                case "null":
                                    tempExp = model => false; //model.ServicePointId == null;
                                    break;
                                case "not null":
                                    tempExp = model => true; //model.ServicePointId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ServicesPointId.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ServicePointToPole.PoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ServicePointToPole.PoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointToPole.PoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointToPole.PoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointToPole.PoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointToPole.PoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ServicePointToPole.PoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ServicePointToPole.PoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ServicePointToPole.PoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ServicePointToPole.PoleToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ServicePointToPole.PoleToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointToPole.PoleToFeederLine.FeederName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointToPole.PoleToFeederLine.FeederName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointToPole.PoleToFeederLine.FeederName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointToPole.PoleToFeederLine.FeederName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ServicePointToPole.PoleToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ServicePointToPole.PoleToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.ServicePointToPole.PoleToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;


                        case "ServicePointTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ServicePointType.ServicePointTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ServicePointType.ServicePointTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointType.ServicePointTypeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointType.ServicePointTypeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointType.ServicePointTypeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ServicePointType.ServicePointTypeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ServicePointType.ServicePointTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ServicePointType.ServicePointTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ServicePointType.ServicePointTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "VoltageCategoryName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.VoltageCategory.VoltageCategoryName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.VoltageCategory.VoltageCategoryName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.VoltageCategory.VoltageCategoryName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.VoltageCategory.VoltageCategoryName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.VoltageCategory.VoltageCategoryName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.VoltageCategory.VoltageCategoryName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.VoltageCategory.VoltageCategoryName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.VoltageCategory.VoltageCategoryName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.VoltageCategory.VoltageCategoryName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "TransformerNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TransformerNumber == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TransformerNumber != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.TransformerNumber) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.TransformerNumber) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.TransformerNumber) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.TransformerNumber) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TransformerNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TransformerNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TransformerNumber.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;
                            
                        //RoadName VillageOrAreaName Ward CityTown PrimaryLandmark
                        case "RoadName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RoadName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RoadName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RoadName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RoadName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RoadName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RoadName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RoadName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RoadName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RoadName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "VillageOrAreaName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.VillageOrAreaName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.VillageOrAreaName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.VillageOrAreaName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.VillageOrAreaName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.VillageOrAreaName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.VillageOrAreaName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.VillageOrAreaName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.VillageOrAreaName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.VillageOrAreaName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;
                            
                        case "Ward":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Ward == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Ward != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Ward) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Ward) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Ward) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Ward) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Ward == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Ward != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Ward.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "CityTown":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.CityTown == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.CityTown != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.CityTown) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.CityTown) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.CityTown) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.CityTown) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.CityTown == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.CityTown != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.CityTown.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PrimaryLandmark":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PrimaryLandmark == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PrimaryLandmark != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PrimaryLandmark) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PrimaryLandmark) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PrimaryLandmark) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PrimaryLandmark) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PrimaryLandmark == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PrimaryLandmark != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PrimaryLandmark.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblServicePoint>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }

            var qry = searchExp != null
                ? _dbContext.TblServicePoint.AsNoTracking().Where(searchExp)
                : _dbContext.TblServicePoint.AsNoTracking();

            qry = qry
                .Include(sp => sp.ServicePointType)
                .Include(sp => sp.VoltageCategory)
                .Include(sp => sp.ServicePointToPole)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(sp => sp.ServicePointToPole.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "ServicePointId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchServicePoint", searchResult);

        }

    }

}
