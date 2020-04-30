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
using Pdb014App.Models.PDB.SubstationModels;


namespace Pdb014App.Controllers.AdvancedSearching
{
    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchVacuumCircuitBreaker([FromQuery] string cai, int pageIndex = 1, string sort = "OutDoorTypeVacuumCircuitBreakerId")
        {
            ViewBag.TotalRecords = _dbContext.TblOutDoorTypeVacumnCircuitBreaker.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "vct.ManufacturersNameCountry", Text = "Manufacturers Name & Country"},
                new SelectListItem {Value = "vct.MaximumRatedVoltage", Text = "Maximum Rated Voltage"},
                new SelectListItem {Value = "vct.Frequency", Text = "Frequency"},
                new SelectListItem {Value = "vct.NoOfPhase", Text = "No of Phase"},
                new SelectListItem {Value = "vct.NoOfBreakPerPhrase", Text = "No of Break Per Phrase"},
                new SelectListItem {Value = "vct.SymmetricalRms", Text = "Symmetrical Rms"},
                new SelectListItem {Value = "vct.AsymmetricalRms", Text = "Asymmetrical Rms"}
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

            var qry = _dbContext.TblOutDoorTypeVacumnCircuitBreaker.AsNoTracking()
                .Include(cb => cb.OutDoorTypeVacumnCircuitBreakerIdToSubstation)
                .Include(cb => cb.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationType)
                .Include(cb => cb.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(cb => cb.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "OutDoorTypeVacumnCircuitBreakerId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchVacuumCircuitBreaker", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchVacuumCircuitBreaker(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "OutDoorTypeVacumnCircuitBreakerId")
        {
            ViewBag.TotalRecords = _dbContext.TblOutDoorTypeVacumnCircuitBreaker.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "vct.ManufacturersNameCountry", Text = "Manufacturers Name & Country"},
                new SelectListItem {Value = "vct.MaximumRatedVoltage", Text = "Maximum Rated Voltage"},
                new SelectListItem {Value = "vct.Frequency", Text = "Frequency"},
                new SelectListItem {Value = "vct.NoOfPhase", Text = "No of Phase"},
                new SelectListItem {Value = "vct.NoOfBreakPerPhrase", Text = "No of Break Per Phrase"},
                new SelectListItem {Value = "vct.SymmetricalRms", Text = "Symmetrical Rms"},
                new SelectListItem {Value = "vct.AsymmetricalRms", Text = "Asymmetrical Rms"}
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


            Expression<Func<TblOutDoorTypeVacumnCircuitBreaker, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode;

            zoneCode = circleCode = snDCode = substationCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblOutDoorTypeVacumnCircuitBreaker, bool>> tempExp = model =>
                        model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblOutDoorTypeVacumnCircuitBreaker>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblOutDoorTypeVacumnCircuitBreaker>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblOutDoorTypeVacumnCircuitBreaker>.AndAlso(searchExp, tempExp);

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
                {"regionList[3]", substationCode}
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

                    Expression<Func<TblOutDoorTypeVacumnCircuitBreaker, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "SubstationName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "ManufacturersNameCountry":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufacturersNameCountry == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufacturersNameCountry != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersNameCountry) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersNameCountry) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersNameCountry) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersNameCountry) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufacturersNameCountry == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufacturersNameCountry != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufacturersNameCountry.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "MaximumRatedVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MaximumRatedVoltage == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MaximumRatedVoltage != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.MaximumRatedVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.MaximumRatedVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.MaximumRatedVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.MaximumRatedVoltage) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MaximumRatedVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MaximumRatedVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MaximumRatedVoltage.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "Frequency":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Frequency == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Frequency != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Frequency) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Frequency) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Frequency) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Frequency) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Frequency == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Frequency != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Frequency.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NoOfPhase":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NoOfPhase == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NoOfPhase != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NoOfPhase) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NoOfPhase) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NoOfPhase) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NoOfPhase) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NoOfPhase == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NoOfPhase != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NoOfPhase.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NoOfBreakPerPhrase":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NoOfBreakPerPhrase == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NoOfBreakPerPhrase != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NoOfBreakPerPhrase) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NoOfBreakPerPhrase) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NoOfBreakPerPhrase) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NoOfBreakPerPhrase) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NoOfBreakPerPhrase == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NoOfBreakPerPhrase != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NoOfBreakPerPhrase.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "SymmetricalRms":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SymmetricalRms == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SymmetricalRms != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SymmetricalRms) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SymmetricalRms) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SymmetricalRms) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SymmetricalRms) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SymmetricalRms == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SymmetricalRms != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SymmetricalRms.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "AsymmetricalRms":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.AsymmetricalRms == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.AsymmetricalRms != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.AsymmetricalRms) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.AsymmetricalRms) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.AsymmetricalRms) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.AsymmetricalRms) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.AsymmetricalRms == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.AsymmetricalRms != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.AsymmetricalRms.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblOutDoorTypeVacumnCircuitBreaker>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblOutDoorTypeVacumnCircuitBreaker>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }


            var qry = searchExp != null
                ? _dbContext.TblOutDoorTypeVacumnCircuitBreaker.AsNoTracking().Where(searchExp)
                : _dbContext.TblOutDoorTypeVacumnCircuitBreaker.AsNoTracking();

            qry = qry
                .Include(cb => cb.OutDoorTypeVacumnCircuitBreakerIdToSubstation)
                .Include(cb => cb.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationType)
                .Include(cb => cb.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(cb => cb.OutDoorTypeVacumnCircuitBreakerIdToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "OutDoorTypeVacumnCircuitBreakerId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchVacuumCircuitBreaker", searchResult);

        }

    }

}
