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
using Pdb014App.Models.PDB.MeteringPanelModels;


namespace Pdb014App.Controllers.AdvancedSearching
{

    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchDifferentRelay(int modelId = 1, int pageIndex = 1, string sort = "DifferentRelayId", string sortExp = "DifferentRelayId")
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
                new SelectListItem {Value = "ManufacturersName", Text = "Manufacturers Name"},
                new SelectListItem {Value = "CountryOfOrigin", Text = "Country of Origin"},
                new SelectListItem {Value = "ManufacturersModelNo", Text = "Manufacturers Model No."},
                new SelectListItem {Value = "RelayTypeName", Text = "Type of Relay"}
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

            var qry = _context.LookUpDifferentRelay.AsNoTracking()
                .Include(l => l.DifferentTypesOfRelay)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchDifferentRelay", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchDifferentRelay(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "DifferentRelayId", string sortExp = "DifferentRelayId")
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
                new SelectListItem {Value = "ManufacturersName", Text = "Manufacturers Name"},
                new SelectListItem {Value = "CountryOfOrigin", Text = "Country of Origin"},
                new SelectListItem {Value = "ManufacturersModelNo", Text = "Manufacturers Model No."},
                new SelectListItem {Value = "RelayTypeName", Text = "Type of Relay"}
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


            var qry = _context.LookUpDifferentRelay.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<LookUpDifferentRelay, Boolean>> searchExp = null;

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

                    Expression<Func<LookUpDifferentRelay, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
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


                        case "CountryOfOrigin":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.CountryOfOrigin == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.CountryOfOrigin != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.CountryOfOrigin) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.CountryOfOrigin) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.CountryOfOrigin) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.CountryOfOrigin) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.CountryOfOrigin == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.CountryOfOrigin != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.CountryOfOrigin.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "ManufacturersModelNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufacturersModelNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufacturersModelNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersModelNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersModelNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersModelNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersModelNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufacturersModelNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufacturersModelNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufacturersModelNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "RelayTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.DifferentTypesOfRelay.RelayTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.DifferentTypesOfRelay.RelayTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.DifferentTypesOfRelay.RelayTypeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.DifferentTypesOfRelay.RelayTypeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.DifferentTypesOfRelay.RelayTypeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.DifferentTypesOfRelay.RelayTypeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.DifferentTypesOfRelay.RelayTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.DifferentTypesOfRelay.RelayTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.DifferentTypesOfRelay.RelayTypeName.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<LookUpDifferentRelay>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<LookUpDifferentRelay>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(l => l.DifferentTypesOfRelay)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchDifferentRelay", searchResult);

        }

    }



}
