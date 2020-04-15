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

        public async Task<IActionResult> SearchMeteringPanel(int modelId = 1, int pageIndex = 1, string sort = "SubstationId", string sortExp = "SubstationId")
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
                new SelectListItem {Value = "SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "ManufacturersNameCountryOfOrigin", Text = "Manufacturers Name Country of Origin"},
                new SelectListItem {Value = "ManufacturersModelNo", Text = "Manufacturers Model No."},
                new SelectListItem {Value = "SystemNominalVoltage", Text = "System Nominal Voltage"},
                new SelectListItem {Value = "MaximumSystemVoltage", Text = "Maximum System Voltage"},
                new SelectListItem {Value = "RatedFrequency", Text = "Rated Frequency"}
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

            var qry = _context.TblMeteringPanel.AsNoTracking()
                .Include(t => t.AmpereMeter)
                .Include(t => t.AnnuciatorForFeeder)
                .Include(t => t.AnnuciatorForTransformer)
                .Include(t => t.AuxiliaryFlagRelayForTransformer)
                .Include(t => t.ControlSwitchForFeeder)
                .Include(t => t.ControlSwitchForTransformer)
                .Include(t => t.DifferentialRelayForTransformer)
                .Include(t => t.IdmtOverCurrentAndEarthFaultRelayForFeeder)
                .Include(t => t.IdmtOverCurrentAndEarthFaultRelayForTransformer)
                .Include(t => t.KWHandkVARHMeter)
                .Include(t => t.MegaVarMeter)
                .Include(t => t.MegaWattMeter)
                .Include(t => t.MeteringPanelToDimensionAndWeight)
                .Include(t => t.MeteringPanelToSubstation)
                .Include(t => t.RestrictedEarthFaultRelayForTransformer)
                .Include(t => t.TripCircuitSupervisionRelayForFeeder)
                .Include(t => t.TripCircuitSupervisionRelayForTransformer)
                .Include(t => t.TripRelayForFeeder)
                .Include(t => t.TripRelayForTransformer)
                .Include(t => t.VoltMeterWithSelectorSwitch)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchMeteringPanel", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchMeteringPanel(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "SubstationId", string sortExp = "SubstationId")
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
                new SelectListItem {Value = "SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "ManufacturersNameCountryOfOrigin", Text = "Manufacturers Name Country of Origin"},
                new SelectListItem {Value = "ManufacturersModelNo", Text = "Manufacturers Model No."},
                new SelectListItem {Value = "SystemNominalVoltage", Text = "System Nominal Voltage"},
                new SelectListItem {Value = "MaximumSystemVoltage", Text = "Maximum System Voltage"},
                new SelectListItem {Value = "RatedFrequency", Text = "Rated Frequency"}
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


            var qry = _context.TblMeteringPanel.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblMeteringPanel, Boolean>> searchExp = null;

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

                    Expression<Func<TblMeteringPanel, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "SubstationName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MeteringPanelToSubstation.SubstationName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MeteringPanelToSubstation.SubstationName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.MeteringPanelToSubstation.SubstationName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.MeteringPanelToSubstation.SubstationName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.MeteringPanelToSubstation.SubstationName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.MeteringPanelToSubstation.SubstationName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MeteringPanelToSubstation.SubstationName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MeteringPanelToSubstation.SubstationName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MeteringPanelToSubstation.SubstationName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ManufacturersNameCountryOfOrigin":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufacturersNameCountryOfOrigin == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufacturersNameCountryOfOrigin != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersNameCountryOfOrigin) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersNameCountryOfOrigin) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersNameCountryOfOrigin) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersNameCountryOfOrigin) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufacturersNameCountryOfOrigin == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufacturersNameCountryOfOrigin != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufacturersNameCountryOfOrigin.Contains(searchOption.FieldValue);
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


                        case "SystemNominalVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SystemNominalVoltage == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SystemNominalVoltage != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SystemNominalVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SystemNominalVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SystemNominalVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SystemNominalVoltage) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SystemNominalVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SystemNominalVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SystemNominalVoltage.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "MaximumSystemVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MaximumSystemVoltage == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MaximumSystemVoltage != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.MaximumSystemVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.MaximumSystemVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.MaximumSystemVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.MaximumSystemVoltage) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MaximumSystemVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MaximumSystemVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MaximumSystemVoltage.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "RatedFrequency":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedFrequency == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedFrequency != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RatedFrequency) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RatedFrequency) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RatedFrequency) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RatedFrequency) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedFrequency == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedFrequency != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedFrequency.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblMeteringPanel>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblMeteringPanel>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(t => t.AmpereMeter)
                .Include(t => t.AnnuciatorForFeeder)
                .Include(t => t.AnnuciatorForTransformer)
                .Include(t => t.AuxiliaryFlagRelayForTransformer)
                .Include(t => t.ControlSwitchForFeeder)
                .Include(t => t.ControlSwitchForTransformer)
                .Include(t => t.DifferentialRelayForTransformer)
                .Include(t => t.IdmtOverCurrentAndEarthFaultRelayForFeeder)
                .Include(t => t.IdmtOverCurrentAndEarthFaultRelayForTransformer)
                .Include(t => t.KWHandkVARHMeter)
                .Include(t => t.MegaVarMeter)
                .Include(t => t.MegaWattMeter)
                .Include(t => t.MeteringPanelToDimensionAndWeight)
                .Include(t => t.MeteringPanelToSubstation)
                .Include(t => t.RestrictedEarthFaultRelayForTransformer)
                .Include(t => t.TripCircuitSupervisionRelayForFeeder)
                .Include(t => t.TripCircuitSupervisionRelayForTransformer)
                .Include(t => t.TripRelayForFeeder)
                .Include(t => t.TripRelayForTransformer)
                .Include(t => t.VoltMeterWithSelectorSwitch)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchMeteringPanel", searchResult);

        }

    }



}
