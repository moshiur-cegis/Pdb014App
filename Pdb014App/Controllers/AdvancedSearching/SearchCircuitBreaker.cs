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

        public async Task<IActionResult> SearchCircuitBreaker(int modelId = 1, int pageIndex = 1, string sort = "CircuitBreakerId", string sortExp = "CircuitBreakerId")
        {
            //if (searchParameters == null)
            //{
            //    searchParameters = TempData["SearchParameters"] as List<List<string>>;
            //}
            //else
            //{
            //    TempData["SearchParameters"] = searchParameters;
            //}


            ViewBag.SearchParameters = new List<List<string>>(3);


            var fieldsDB = _context
                .LookUpModelFieldInfo
                .Where(mf => mf.ModelId == modelId)
                .Select(fi => new { Value = fi.FieldName, Text = fi.FieldDisplayName })
                .ToList();


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "Type", Text = "Type"},
                new SelectListItem {Value = "RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "OperatingCycle", Text = "Operating Cycle"},
                new SelectListItem {Value = "ControlVoltage", Text = "Control Voltage"},
                new SelectListItem {Value = "Type2", Text = "Type-2"},
                new SelectListItem {Value = "RatedVoltage2", Text = "Rated Voltage-2"},
                new SelectListItem {Value = "RatedCurrent2", Text = "Rated Current-2"},
                new SelectListItem {Value = "SwitchPositions", Text = "Switch Positions"}
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

            var qry = _context.LookUpCircuitBreaker.AsNoTracking().AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchCircuitBreaker", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchCircuitBreaker(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "CircuitBreakerId", string sortExp = "CircuitBreakerId")
        {
            //if (searchParameters == null)
            //{
            //    searchParameters = TempData["SearchParameters"] as List<List<string>>;
            //}
            //else
            //{
            //    TempData["SearchParameters"] = searchParameters;
            //}


            //ViewData["SearchParameters"] = searchParameters;
            ViewBag.SearchParameters = searchParameters;

            var fieldsDB = _context
                .LookUpModelFieldInfo
                .Where(mf => mf.ModelId == modelId)
                .Select(fi => new { Value = fi.FieldName, Text = fi.FieldDisplayName })
                .ToList();


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "Type", Text = "Type"},
                new SelectListItem {Value = "RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "OperatingCycle", Text = "Operating Cycle"},
                new SelectListItem {Value = "ControlVoltage", Text = "Control Voltage"},
                new SelectListItem {Value = "Type2", Text = "Type-2"},
                new SelectListItem {Value = "RatedVoltage2", Text = "Rated Voltage-2"},
                new SelectListItem {Value = "RatedCurrent2", Text = "Rated Current-2"},
                new SelectListItem {Value = "SwitchPositions", Text = "Switch Positions"}
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


            var qry = _context.LookUpCircuitBreaker.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<LookUpCircuitBreaker, Boolean>> searchExp = null;

                var searchOptions = searchParameters
                    .Select(so => new SearchParameter
                    {
                        FieldName = so[0],
                        Operator = so[1],
                        FieldValue = so[2],
                        JoinOption = so[3]
                    }).ToList();

                string joinOption = "";
                foreach (var searchOption in searchOptions)
                {
                    if (string.IsNullOrEmpty(searchOption.FieldName) || string.IsNullOrEmpty(searchOption.Operator))
                        continue;

                    Expression<Func<LookUpCircuitBreaker, Boolean>> tempExp = null;

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


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry.AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchCircuitBreaker", searchResult);

        }

    }



}
