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

        public async Task<IActionResult> SearchSwitchgear(int modelId = 1, int pageIndex = 1, string sort = "SwitchGearID", string sortExp = "SwitchGearID")
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
                new SelectListItem {Value = "SwitchGearType", Text = "SwitchGear Type"},
                new SelectListItem {Value = "ManufacturersNameAndAddress", Text = "Manufacturers Name and Address"},
                new SelectListItem {Value = "AppliedStandard", Text = "Applied Standard"},
                new SelectListItem {Value = "RatedNominalVoltage", Text = "Rated Nominal Voltage"},
                new SelectListItem {Value = "RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "RatedCurrentForMainBus", Text = "Rated Current for Main Bus"},
                new SelectListItem {Value = "RatedShortTimeCurrent", Text = "Rated Short Time Current"},
                new SelectListItem {Value = "ShortTimeCurrentRatedDuration", Text = "Short Time Current Rated Duration"},
                
                new SelectListItem {Value = "CircuitBreaker", Text = "Circuit Breaker Type"},
                new SelectListItem {Value = "SwitchGearIdmtRelay", Text = "IDMT Relay"},
                new SelectListItem {Value = "TripRelay", Text = "Trip Relay"},
                
                //new SelectListItem {Value = "", Text = "TripCircuitSupervisionRelay"},
                //new SelectListItem {Value = "", Text = "CurrentTransformer"},
                //new SelectListItem {Value = "", Text = "SwitchPosition"},
                //new SelectListItem {Value = "", Text = "AcWithStandVoltageDry"},
                //new SelectListItem {Value = "", Text = "ImpulseWithStandFullWave"},
                //new SelectListItem {Value = "", Text = "Enclosure"},
                //new SelectListItem {Value = "", Text = "HvCompartment"},
                //new SelectListItem {Value = "", Text = "LvCompartment"},
                //new SelectListItem {Value = "", Text = "Sf6SafetyAndLife"},
                //new SelectListItem {Value = "", Text = "VoltMeter"},
                //new SelectListItem {Value = "", Text = "AmpereMeter"},
                //new SelectListItem {Value = "", Text = "BusBar"},
                //new SelectListItem {Value = "", Text = "ReatedVoltage"},
                //new SelectListItem {Value = "", Text = "ReatedCurrent"},
                //new SelectListItem {Value = "", Text = "ReatedShortCircuitBreakerCurrent"},
                //new SelectListItem {Value = "", Text = "PhasePowerTransformer"},
                //new SelectListItem {Value = "", Text = "DimensionAndWeight"},
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

            var qry = _context.TblSwitchGear.AsNoTracking()
                .Include(t => t.SwitchGearToIdmtRelay)
                .Include(t => t.SwitchGearToAmpereMeter)
                .Include(t => t.SwitchGearToBusBar)
                .Include(t => t.SwitchGearToCircuitBreaker)
                .Include(t => t.SwitchGearToCurrentTransformer)
                .Include(t => t.SwitchGearToDimensionAndWeight)
                .Include(t => t.SwitchGearToPhasePowerTransformer)
                .Include(t => t.SwitchGearToSf6SafetyAndLife)
                .Include(t => t.SwitchGearToSwitchPosition)
                .Include(t => t.SwitchGearToTripCircuitSupervisionRelay)
                .Include(t => t.SwitchGearToTripRelay)
                .Include(t => t.SwitchGearToVoltMeter)
                .Include(t => t.SwitchGearType)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchSwitchgear", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchSwitchgear(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "SwitchGearID", string sortExp = "SwitchGearID")
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
                new SelectListItem {Value = "SwitchGearType", Text = "SwitchGear Type"},
                new SelectListItem {Value = "ManufacturersNameAndAddress", Text = "Manufacturers Name and Address"},
                new SelectListItem {Value = "AppliedStandard", Text = "Applied Standard"},
                new SelectListItem {Value = "RatedNominalVoltage", Text = "Rated Nominal Voltage"},
                new SelectListItem {Value = "RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "RatedCurrentForMainBus", Text = "Rated Current for Main Bus"},
                new SelectListItem {Value = "RatedShortTimeCurrent", Text = "Rated Short Time Current"},
                new SelectListItem {Value = "ShortTimeCurrentRatedDuration", Text = "Short Time Current Rated Duration"},

                new SelectListItem {Value = "CircuitBreaker", Text = "Circuit Breaker Type"},
                new SelectListItem {Value = "SwitchGearIdmtRelay", Text = "IDMT Relay"},
                new SelectListItem {Value = "TripRelay", Text = "Trip Relay"},
                
                //new SelectListItem {Value = "", Text = "TripCircuitSupervisionRelay"},
                //new SelectListItem {Value = "", Text = "CurrentTransformer"},
                //new SelectListItem {Value = "", Text = "SwitchPosition"},
                //new SelectListItem {Value = "", Text = "AcWithStandVoltageDry"},
                //new SelectListItem {Value = "", Text = "ImpulseWithStandFullWave"},
                //new SelectListItem {Value = "", Text = "Enclosure"},
                //new SelectListItem {Value = "", Text = "HvCompartment"},
                //new SelectListItem {Value = "", Text = "LvCompartment"},
                //new SelectListItem {Value = "", Text = "Sf6SafetyAndLife"},
                //new SelectListItem {Value = "", Text = "VoltMeter"},
                //new SelectListItem {Value = "", Text = "AmpereMeter"},
                //new SelectListItem {Value = "", Text = "BusBar"},
                //new SelectListItem {Value = "", Text = "ReatedVoltage"},
                //new SelectListItem {Value = "", Text = "ReatedCurrent"},
                //new SelectListItem {Value = "", Text = "ReatedShortCircuitBreakerCurrent"},
                //new SelectListItem {Value = "", Text = "PhasePowerTransformer"},
                //new SelectListItem {Value = "", Text = "DimensionAndWeight"},
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


            var qry = _context.TblSwitchGear.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblSwitchGear, Boolean>> searchExp = null;

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

                    Expression<Func<TblSwitchGear, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "SwitchGearType":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchGearType.SwitchGearTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchGearType.SwitchGearTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SwitchGearType.SwitchGearTypeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SwitchGearType.SwitchGearTypeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SwitchGearType.SwitchGearTypeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SwitchGearType.SwitchGearTypeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SwitchGearType.SwitchGearTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SwitchGearType.SwitchGearTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SwitchGearType.SwitchGearTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;
                            
                        case "ManufacturersNameAndAddress":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufacturersNameAndAddress == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufacturersNameAndAddress != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.ManufacturersNameAndAddress) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.ManufacturersNameAndAddress) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.ManufacturersNameAndAddress) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.ManufacturersNameAndAddress) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufacturersNameAndAddress == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufacturersNameAndAddress != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufacturersNameAndAddress.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;
                            
                        case "AppliedStandard":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.AppliedStandard == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.AppliedStandard != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.AppliedStandard) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.AppliedStandard) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.AppliedStandard) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.AppliedStandard) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.AppliedStandard == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.AppliedStandard != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.AppliedStandard.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "RatedNominalVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedNominalVoltage == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedNominalVoltage != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.RatedNominalVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.RatedNominalVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.RatedNominalVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.RatedNominalVoltage) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedNominalVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedNominalVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedNominalVoltage.Contains(searchOption.FieldValue);
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
                                    tempExp = model => int.Parse(model.RatedVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.RatedVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.RatedVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.RatedVoltage) <= int.Parse(searchOption.FieldValue);
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

                        case "RatedCurrentForMainBus":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedCurrentForMainBus == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedCurrentForMainBus != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.RatedCurrentForMainBus) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.RatedCurrentForMainBus) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.RatedCurrentForMainBus) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.RatedCurrentForMainBus) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedCurrentForMainBus == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedCurrentForMainBus != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedCurrentForMainBus.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "RatedShortTimeCurrent":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedShortTimeCurrent == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedShortTimeCurrent != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.RatedShortTimeCurrent) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.RatedShortTimeCurrent) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.RatedShortTimeCurrent) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.RatedShortTimeCurrent) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedShortTimeCurrent == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedShortTimeCurrent != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedShortTimeCurrent.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;
                            
                        case "ShortTimeCurrentRatedDuration":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ShortTimeCurrentRatedDuration == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ShortTimeCurrentRatedDuration != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.ShortTimeCurrentRatedDuration) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.ShortTimeCurrentRatedDuration) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.ShortTimeCurrentRatedDuration) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.ShortTimeCurrentRatedDuration) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ShortTimeCurrentRatedDuration == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ShortTimeCurrentRatedDuration != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ShortTimeCurrentRatedDuration.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "CircuitBreaker":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchGearToCircuitBreaker.Type == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchGearToCircuitBreaker.Type != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SwitchGearToCircuitBreaker.Type) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SwitchGearToCircuitBreaker.Type) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SwitchGearToCircuitBreaker.Type) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SwitchGearToCircuitBreaker.Type) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SwitchGearToCircuitBreaker.Type == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SwitchGearToCircuitBreaker.Type != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SwitchGearToCircuitBreaker.Type.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "IdmtRelay":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchGearToIdmtRelay.ManufacturersModelNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchGearToIdmtRelay.ManufacturersModelNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SwitchGearToIdmtRelay.ManufacturersModelNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SwitchGearToIdmtRelay.ManufacturersModelNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SwitchGearToIdmtRelay.ManufacturersModelNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SwitchGearToIdmtRelay.ManufacturersModelNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SwitchGearToIdmtRelay.ManufacturersModelNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SwitchGearToIdmtRelay.ManufacturersModelNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SwitchGearToIdmtRelay.ManufacturersModelNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TripRelay":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchGearToTripRelay.ManufacturersModelNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchGearToTripRelay.ManufacturersModelNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SwitchGearToTripRelay.ManufacturersModelNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SwitchGearToTripRelay.ManufacturersModelNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SwitchGearToTripRelay.ManufacturersModelNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SwitchGearToTripRelay.ManufacturersModelNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SwitchGearToTripRelay.ManufacturersModelNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SwitchGearToTripRelay.ManufacturersModelNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SwitchGearToTripRelay.ManufacturersModelNo.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblSwitchGear>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblSwitchGear>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(t => t.SwitchGearToIdmtRelay)
                .Include(t => t.SwitchGearToAmpereMeter)
                .Include(t => t.SwitchGearToBusBar)
                .Include(t => t.SwitchGearToCircuitBreaker)
                .Include(t => t.SwitchGearToCurrentTransformer)
                .Include(t => t.SwitchGearToDimensionAndWeight)
                .Include(t => t.SwitchGearToPhasePowerTransformer)
                .Include(t => t.SwitchGearToSf6SafetyAndLife)
                .Include(t => t.SwitchGearToSwitchPosition)
                .Include(t => t.SwitchGearToTripCircuitSupervisionRelay)
                .Include(t => t.SwitchGearToTripRelay)
                .Include(t => t.SwitchGearToVoltMeter)
                .Include(t => t.SwitchGearType)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchSwitchgear", searchResult);

        }

    }
       
}
