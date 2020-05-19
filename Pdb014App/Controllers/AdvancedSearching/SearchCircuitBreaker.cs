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
using Pdb014App.Models.PDB.SwitchGearModels;


namespace Pdb014App.Controllers.AdvancedSearching
{
    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchCircuitBreaker([FromQuery] string cai, int pageIndex = 1, string sort = "CircuitBreakerId")
        {
            ViewBag.TotalRecords = _dbContext.LookUpCircuitBreaker.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "crbl.Type", Text = "Type"},
                new SelectListItem {Value = "crbl.RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "crbl.RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "crbl.OperatingCycle", Text = "Operating Cycle"},
                new SelectListItem {Value = "crbl.ControlVoltage", Text = "Control Voltage"},
                new SelectListItem {Value = "crbl.Type2", Text = "Type-2"},
                new SelectListItem {Value = "crbl.RatedVoltage2", Text = "Rated Voltage-2"},
                new SelectListItem {Value = "crbl.RatedCurrent2", Text = "Rated Current-2"},
                new SelectListItem {Value = "crbl.SwitchPositions", Text = "Switch Positions"}
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

            var qry = _dbContext.LookUpCircuitBreaker.AsNoTracking().AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "CircuitBreakerId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchCircuitBreaker", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchCircuitBreaker(List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "CircuitBreakerId")
        {
            ViewBag.TotalRecords = _dbContext.LookUpCircuitBreaker.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "crbl.Type", Text = "Type"},
                new SelectListItem {Value = "crbl.RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "crbl.RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "crbl.OperatingCycle", Text = "Operating Cycle"},
                new SelectListItem {Value = "crbl.ControlVoltage", Text = "Control Voltage"},
                new SelectListItem {Value = "crbl.Type2", Text = "Type-2"},
                new SelectListItem {Value = "crbl.RatedVoltage2", Text = "Rated Voltage-2"},
                new SelectListItem {Value = "crbl.RatedCurrent2", Text = "Rated Current-2"},
                new SelectListItem {Value = "crbl.SwitchPositions", Text = "Switch Positions"}
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


            Expression<Func<LookUpCircuitBreaker, bool>> searchExp = null;
            var searchParametersRoute = new RouteValueDictionary { { "cai", cai } };
            //searchParametersRoute.Add("cai", cai);

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

                    Expression<Func<LookUpCircuitBreaker, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
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

                        case "RatedVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedVoltage == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedVoltage != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RatedVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RatedVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RatedVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RatedVoltage) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedVoltage.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "RatedCurrent":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedCurrent == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedCurrent != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RatedCurrent) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RatedCurrent) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RatedCurrent) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RatedCurrent) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedCurrent == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedCurrent != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedCurrent.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "OperatingCycle":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.OperatingCycle == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.OperatingCycle != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.OperatingCycle) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.OperatingCycle) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.OperatingCycle) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.OperatingCycle) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.OperatingCycle == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.OperatingCycle != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.OperatingCycle.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ControlVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ControlVoltage == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ControlVoltage != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ControlVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ControlVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ControlVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ControlVoltage) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ControlVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ControlVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ControlVoltage.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "Type2":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Type2 == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Type2 != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Type2) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Type2) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Type2) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Type2) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Type2 == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Type2 != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Type2.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "RatedVoltage2":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedVoltage2 == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedVoltage2 != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RatedVoltage2) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RatedVoltage2) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RatedVoltage2) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RatedVoltage2) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedVoltage2 == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedVoltage2 != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedVoltage2.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "RatedCurrent2":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedCurrent2 == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedCurrent2 != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RatedCurrent2) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RatedCurrent2) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RatedCurrent2) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RatedCurrent2) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedCurrent2 == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedCurrent2 != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedCurrent2.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "SwitchPositions":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchPositions == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchPositions != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SwitchPositions) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SwitchPositions) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SwitchPositions) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SwitchPositions) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SwitchPositions == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SwitchPositions != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SwitchPositions.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<LookUpCircuitBreaker>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<LookUpCircuitBreaker>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }


            var qry = searchExp != null
                ? _dbContext.LookUpCircuitBreaker.AsNoTracking().Where(searchExp).AsQueryable()
                : _dbContext.LookUpCircuitBreaker.AsNoTracking().AsQueryable();


            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "CircuitBreakerId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchCircuitBreaker", searchResult);

        }

    }

}
