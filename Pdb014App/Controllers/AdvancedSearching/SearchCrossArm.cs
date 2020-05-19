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
using Pdb014App.Models.PDB.PoleModels;


namespace Pdb014App.Controllers.AdvancedSearching
{
    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchCrossArm([FromQuery] string cai, int pageIndex = 1, string sort = "CrossArmId")
        {
            ViewBag.TotalRecords = _dbContext.TblCrossArmInfo.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "plt.PoleNo", Text = "Pole No."},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},
                new SelectListItem {Value = "cat.Materials", Text = "Materials"},
                new SelectListItem {Value = "cat.Type", Text = "Type"},
                new SelectListItem {Value = "cat.Standard", Text = "Standard"},
                new SelectListItem {Value = "cat.UltimateTensileStrength", Text = "Ultimate Tensile Strength"},
                new SelectListItem {Value = "cftl.TypeOfFittings.Name", Text = "Type of Fittings"},
                new SelectListItem {Value = "cat.NoOfSetFittings", Text = "No of Set Fittings"},
                new SelectListItem {Value = "cfcl.FittingCondition.Name", Text = "Fittings Condition"}
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

            var qry = _dbContext.TblCrossArmInfo.AsNoTracking()
                .Include(ca => ca.CrossArmToPole)
                .Include(ca => ca.FittingsLookUpCondition)
                .Include(ca => ca.LookUpTypeOfFittings)
                .Include(ca => ca.CrossArmToPole.PoleToRoute)
                .Include(ca => ca.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(ca => ca.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "CrossArmId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchCrossArm", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchCrossArm(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "CrossArmId")
        {
            ViewBag.TotalRecords = _dbContext.TblCrossArmInfo.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "plt.PoleNo", Text = "Pole No."},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},
                new SelectListItem {Value = "cat.Materials", Text = "Materials"},
                new SelectListItem {Value = "cat.Type", Text = "Type"},
                new SelectListItem {Value = "cat.Standard", Text = "Standard"},
                new SelectListItem {Value = "cat.UltimateTensileStrength", Text = "Ultimate Tensile Strength"},
                new SelectListItem {Value = "cftl.TypeOfFittings.Name", Text = "Type of Fittings"},
                new SelectListItem {Value = "cat.NoOfSetFittings", Text = "No of Set Fittings"},
                new SelectListItem {Value = "cfcl.FittingCondition.Name", Text = "Fittings Condition"}
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
            

            Expression<Func<TblCrossArmInfo, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblCrossArmInfo, bool>> tempExp = model =>
                        model.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblCrossArmInfo>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.CrossArmToPole.PoleToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblCrossArmInfo>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblCrossArmInfo>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.CrossArmToPole.PoleToRoute.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblCrossArmInfo>.AndAlso(searchExp, tempExp);

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

                    Expression<Func<TblCrossArmInfo, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "PoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.CrossArmToPole.PoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.CrossArmToPole.PoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.CrossArmToPole.PoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.CrossArmToPole.PoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.CrossArmToPole.PoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.CrossArmToPole.PoleToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.CrossArmToPole.PoleToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleToFeederLine.FeederName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleToFeederLine.FeederName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleToFeederLine.FeederName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleToFeederLine.FeederName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.CrossArmToPole.PoleToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.CrossArmToPole.PoleToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.CrossArmToPole.PoleToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Materials":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Materials == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Materials != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Materials) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Materials) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Materials) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Materials) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Materials == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Materials != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Materials.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "Type":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Type == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Type != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Type) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Type) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Type) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Type) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Type == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Type != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Type.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "Standard":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Standard == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Standard != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Standard) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Standard) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Standard) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Standard) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Standard == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Standard != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Standard.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "UltimateTensileStrength":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.UltimateTensileStrength == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.UltimateTensileStrength != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.UltimateTensileStrength) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.UltimateTensileStrength) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.UltimateTensileStrength) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.UltimateTensileStrength) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.UltimateTensileStrength == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.UltimateTensileStrength != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.UltimateTensileStrength.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TypeOfFittings":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.LookUpTypeOfFittings.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.LookUpTypeOfFittings.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.LookUpTypeOfFittings.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.LookUpTypeOfFittings.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.LookUpTypeOfFittings.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.LookUpTypeOfFittings.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.LookUpTypeOfFittings.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.LookUpTypeOfFittings.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.LookUpTypeOfFittings.Name.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NoOfSetFittings":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NoOfSetFittings == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.NoOfSetFittings != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model =>
                                        model.NoOfSetFittings > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        model.NoOfSetFittings < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.NoOfSetFittings >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.NoOfSetFittings <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NoOfSetFittings == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NoOfSetFittings != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NoOfSetFittings.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "FittingCondition":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FittingsLookUpCondition.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FittingsLookUpCondition.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FittingsLookUpCondition.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FittingsLookUpCondition.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FittingsLookUpCondition.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FittingsLookUpCondition.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FittingsLookUpCondition.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FittingsLookUpCondition.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FittingsLookUpCondition.Name.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblCrossArmInfo>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblCrossArmInfo>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }


            var qry = searchExp != null
                ? _dbContext.TblCrossArmInfo.AsNoTracking().Where(searchExp)
                : _dbContext.TblCrossArmInfo.AsNoTracking();

            qry = qry
                .Include(ca => ca.CrossArmToPole)
                .Include(ca => ca.FittingsLookUpCondition)
                .Include(ca => ca.LookUpTypeOfFittings)
                .Include(ca => ca.CrossArmToPole.PoleToRoute)
                .Include(ca => ca.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(ca => ca.CrossArmToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "CrossArmId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchCrossArm", searchResult);

        }

    }

}
