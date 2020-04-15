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

        public async Task<IActionResult> SearchVacumnCircuitBreaker(int modelId = 1, int pageIndex = 1, string sort = "OutDoorTypeVacumnCircuitBreakerId", string sortExp = "OutDoorTypeVacumnCircuitBreakerId")
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
                new SelectListItem {Value = "Substation", Text = "Substation"},
                new SelectListItem {Value = "ManufacturersNameCountry", Text = "Manufacturers Name & Country"},
                new SelectListItem {Value = "MaximumRatedVoltage", Text = "Maximum Rated Voltage"},
                new SelectListItem {Value = "Frequency", Text = "Frequency"},
                new SelectListItem {Value = "NoOfPhase", Text = "No of Phase"},
                new SelectListItem {Value = "NoOfBreakPerPhrase", Text = "No of Break Per Phrase"},
                new SelectListItem {Value = "SymmetricalRms", Text = "Symmetrical Rms"},
                new SelectListItem {Value = "AsymmetricalRms", Text = "Asymmetrical Rms"}
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

            var qry = _context.TblOutDoorTypeVacumnCircuitBreaker.AsNoTracking().AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchVacumnCircuitBreaker", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchVacumnCircuitBreaker(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "OutDoorTypeVacumnCircuitBreakerId", string sortExp = "OutDoorTypeVacumnCircuitBreakerId")
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
                new SelectListItem {Value = "Substation", Text = "Substation"},
                new SelectListItem {Value = "ManufacturersNameCountry", Text = "Manufacturers Name & Country"},
                new SelectListItem {Value = "MaximumRatedVoltage", Text = "Maximum Rated Voltage"},
                new SelectListItem {Value = "Frequency", Text = "Frequency"},
                new SelectListItem {Value = "NoOfPhase", Text = "No of Phase"},
                new SelectListItem {Value = "NoOfBreakPerPhrase", Text = "No of Break Per Phrase"},
                new SelectListItem {Value = "SymmetricalRms", Text = "Symmetrical Rms"},
                new SelectListItem {Value = "AsymmetricalRms", Text = "Asymmetrical Rms"}
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


            var qry = _context.TblOutDoorTypeVacumnCircuitBreaker.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblOutDoorTypeVacumnCircuitBreaker, Boolean>> searchExp = null;

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

                    Expression<Func<TblOutDoorTypeVacumnCircuitBreaker, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "Substation":
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


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry.AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchVacumnCircuitBreaker", searchResult);

        }

    }



}
