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

        public async Task<IActionResult> SearchRelay(int modelId = 1, int pageIndex = 1, string sort = "RelayId", string sortExp = "RelayId")
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
                new SelectListItem {Value = "RelayName", Text = "Relay Name"},
                new SelectListItem {Value = "NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "ManufactureName", Text = "Manufacture Name"},
                new SelectListItem {Value = "ModelNumber", Text = "Model Number"},
                new SelectListItem {Value = "RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "ConnectionStatus", Text = "Connection Status"},
                new SelectListItem {Value = "FeederLine", Text = "Feeder Line"},
                new SelectListItem {Value = "Substation", Text = "Substation"}
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

            var qry = _context.TblRelay.AsNoTracking()
                .Include(t => t.RelayToFeederLine)
                .Include(t => t.RelayToSubstation)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchRelay", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchRelay(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "RelayId", string sortExp = "RelayId")
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
                new SelectListItem {Value = "RelayName", Text = "Relay Name"},
                new SelectListItem {Value = "NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "ManufactureName", Text = "Manufacture Name"},
                new SelectListItem {Value = "ModelNumber", Text = "Model Number"},
                new SelectListItem {Value = "RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "ConnectionStatus", Text = "Connection Status"},
                new SelectListItem {Value = "FeederLine", Text = "Feeder Line"},
                new SelectListItem {Value = "Substation", Text = "Substation"}
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


            var qry = _context.TblRelay.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblRelay, Boolean>> searchExp = null;

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

                    Expression<Func<TblRelay, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "RelayName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RelayName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RelayName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RelayName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RelayName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RelayName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RelayName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RelayName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RelayName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RelayName.Contains(searchOption.FieldValue);
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


                        case "ManufactureName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufactureName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufactureName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufactureName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufactureName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufactureName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufactureName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufactureName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufactureName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufactureName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "ModelNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ModelNumber == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ModelNumber != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ModelNumber) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ModelNumber) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ModelNumber) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ModelNumber) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ModelNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ModelNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ModelNumber.Contains(searchOption.FieldValue);
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


                        case "ConnectionStatus":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConnectionStatus == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConnectionStatus != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConnectionStatus) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConnectionStatus) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConnectionStatus) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConnectionStatus) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConnectionStatus == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConnectionStatus != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConnectionStatus.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "FeederLine":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RelayToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RelayToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RelayToFeederLine.FeederName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RelayToFeederLine.FeederName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RelayToFeederLine.FeederName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RelayToFeederLine.FeederName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RelayToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RelayToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RelayToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "Substation":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RelayToSubstation.SubstationName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RelayToSubstation.SubstationName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RelayToSubstation.SubstationName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RelayToSubstation.SubstationName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RelayToSubstation.SubstationName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RelayToSubstation.SubstationName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RelayToSubstation.SubstationName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RelayToSubstation.SubstationName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RelayToSubstation.SubstationName.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblRelay>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblRelay>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(t => t.RelayToFeederLine)
                .Include(t => t.RelayToSubstation)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchRelay", searchResult);

        }

    }



}
