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
        public async Task<IActionResult> SearchDifferentRelay([FromQuery] string cai, int pageIndex = 1, string sort = "DifferentRelayId")
        {
            ViewBag.TotalRecords = _dbContext.LookUpDifferentRelay.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "drel.ManufacturersName", Text = "Manufacturers Name"},
                new SelectListItem {Value = "drel.CountryOfOrigin", Text = "Country of Origin"},
                new SelectListItem {Value = "drel.ManufacturersModelNo", Text = "Manufacturers Model No."},
                new SelectListItem {Value = "drtl.RelayTypeName", Text = "Type of Relay"}
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

            var qry = _dbContext.LookUpDifferentRelay.AsNoTracking()
                .Include(dr => dr.DifferentTypesOfRelay)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "DifferentRelayId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchDifferentRelay", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchDifferentRelay(List<List<string>> searchParameters, [FromQuery] string cai, int pageIndex = 1, string sort = "DifferentRelayId")
        {
            ViewBag.TotalRecords = _dbContext.LookUpDifferentRelay.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "drel.ManufacturersName", Text = "Manufacturers Name"},
                new SelectListItem {Value = "drel.CountryOfOrigin", Text = "Country of Origin"},
                new SelectListItem {Value = "drel.ManufacturersModelNo", Text = "Manufacturers Model No."},
                new SelectListItem {Value = "drtl.RelayTypeName", Text = "Type of Relay"}
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


            Expression<Func<LookUpDifferentRelay, bool>> searchExp = null;
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

                    Expression<Func<LookUpDifferentRelay, bool>> tempExp = null;

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

            }


            var qry = searchExp != null
                ? _dbContext.LookUpDifferentRelay.AsNoTracking().Where(searchExp)
                : _dbContext.LookUpDifferentRelay.AsNoTracking();

            qry = qry
                .Include(dr => dr.DifferentTypesOfRelay)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "DifferentRelayId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchDifferentRelay", searchResult);

        }

    }

}
