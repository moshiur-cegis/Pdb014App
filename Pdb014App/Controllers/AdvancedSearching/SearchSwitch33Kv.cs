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

        public async Task<IActionResult> SearchSwitch33Kv(int modelId = 1, int pageIndex = 1, string sort = "Switch33KvIsolatorId", string sortExp = "Switch33KvIsolatorId")
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

            var qry = _context.TblSwitch33KvIsolator.AsNoTracking()
                .Include(t => t.SwitchToFeederLine)
                .Include(t => t.Switch33KvIsolatorToSubstation)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchSwitch33Kv", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchSwitch33Kv(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "Switch33KvIsolatorId", string sortExp = "Switch33KvIsolatorId")
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
                new SelectListItem {Value = "TypeIsolatorSwitch", Text = "Type Isolator Switch"},
                new SelectListItem {Value = "SwitchID", Text = "Switch ID"},
                new SelectListItem {Value = "NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "BreakingType", Text = "Breaking Type"},
                new SelectListItem {Value = "ManufactureMonthAndYear", Text = "Manufacture Month and Year"},
                new SelectListItem {Value = "InstallationDate", Text = "Installation Date"},
                new SelectListItem {Value = "NormalStatus", Text = "Normal Status"},
                new SelectListItem {Value = "RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "ConnectionStatus", Text = "Connection Status"},
                new SelectListItem {Value = "SwitchNo", Text = "Switch No."},
                new SelectListItem {Value = "FeederName", Text = "Feeder"},
                new SelectListItem {Value = "SubstationName", Text = "Substation"}
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


            var qry = _context.TblSwitch33KvIsolator.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblSwitch33KvIsolator, Boolean>> searchExp = null;

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

                    Expression<Func<TblSwitch33KvIsolator, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {

                        case "TypeIsolatorSwitch":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TypeIsolatorSwitch == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TypeIsolatorSwitch != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.TypeIsolatorSwitch) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.TypeIsolatorSwitch) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.TypeIsolatorSwitch) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.TypeIsolatorSwitch) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TypeIsolatorSwitch == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TypeIsolatorSwitch != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TypeIsolatorSwitch.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "SwitchID":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchID == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchID != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SwitchID) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SwitchID) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SwitchID) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SwitchID) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SwitchID == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SwitchID != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SwitchID.Contains(searchOption.FieldValue);
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


                        case "BreakingType":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.BreakingType == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.BreakingType != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.BreakingType) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.BreakingType) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.BreakingType) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.BreakingType) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.BreakingType == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.BreakingType != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.BreakingType.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "ManufactureMonthAndYear":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufactureMonthAndYear == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufactureMonthAndYear != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufactureMonthAndYear) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufactureMonthAndYear) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufactureMonthAndYear) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufactureMonthAndYear) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufactureMonthAndYear == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufactureMonthAndYear != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufactureMonthAndYear.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "InstallationDate":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.InstallationDate == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.InstallationDate != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.InstallationDate) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.InstallationDate) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.InstallationDate) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.InstallationDate) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.InstallationDate == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.InstallationDate != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.InstallationDate.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NormalStatus":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NormalStatus == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NormalStatus != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NormalStatus) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NormalStatus) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NormalStatus) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NormalStatus) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NormalStatus == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NormalStatus != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NormalStatus.Contains(searchOption.FieldValue);
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


                        case "SwitchNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SwitchNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SwitchNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SwitchNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SwitchNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SwitchNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SwitchNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SwitchNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SwitchToFeederLine.FeederName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SwitchToFeederLine.FeederName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SwitchToFeederLine.FeederName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SwitchToFeederLine.FeederName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SwitchToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SwitchToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SwitchToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "SubstationName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Switch33KvIsolatorToSubstation.SubstationName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Switch33KvIsolatorToSubstation.SubstationName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Switch33KvIsolatorToSubstation.SubstationName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Switch33KvIsolatorToSubstation.SubstationName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Switch33KvIsolatorToSubstation.SubstationName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Switch33KvIsolatorToSubstation.SubstationName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Switch33KvIsolatorToSubstation.SubstationName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Switch33KvIsolatorToSubstation.SubstationName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Switch33KvIsolatorToSubstation.SubstationName.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblSwitch33KvIsolator>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblSwitch33KvIsolator>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(t => t.SwitchToFeederLine)
                .Include(t => t.Switch33KvIsolatorToSubstation)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchSwitch33Kv", searchResult);

        }

    }



}
