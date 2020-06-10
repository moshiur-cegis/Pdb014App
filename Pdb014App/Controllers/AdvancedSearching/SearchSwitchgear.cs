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

        public async Task<IActionResult> SearchSwitchgear([FromQuery] string cai, int pageIndex = 1, string sort = "SwitchGearID")
        {
            ViewBag.TotalRecords = _dbContext.TblSwitchGear.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "sgtl.SwitchGearTypeName", Text = "Switchgear Type"},
                new SelectListItem {Value = "sgt.ManufacturersNameAndAddress", Text = "Manufacturers Name and Address"},
                new SelectListItem {Value = "sgt.AppliedStandard", Text = "Applied Standard"},
                new SelectListItem {Value = "sgt.RatedNominalVoltage", Text = "Rated Nominal Voltage"},
                new SelectListItem {Value = "sgt.RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "sgt.RatedCurrentForMainBus", Text = "Rated Current for Main Bus"},
                new SelectListItem {Value = "sgt.RatedShortTimeCurrent", Text = "Rated Short Time Current"},
                new SelectListItem {Value = "sgt.ShortTimeCurrentRatedDuration", Text = "Short Time Current Rated Duration"},

                new SelectListItem {Value = "cbrl.CircuitBreaker.Type", Text = "Circuit Breaker Type"},
                new SelectListItem {Value = "drel.IdmtRelay.ManufacturersModelNo", Text = "IDMT Relay Model No."},
                new SelectListItem {Value = "drel.TripRelay.ManufacturersModelNo", Text = "Trip Relay Model No."},
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

            var qry = _dbContext.TblSwitchGear.AsNoTracking()
                .Include(sg => sg.SwitchGearToIdmtRelay)
                .Include(sg => sg.SwitchGearToAmpereMeter)
                .Include(sg => sg.SwitchGearToBusBar)
                .Include(sg => sg.SwitchGearToCircuitBreaker)
                .Include(sg => sg.SwitchGearToCurrentTransformer)
                .Include(sg => sg.SwitchGearToDimensionAndWeight)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer)
                .Include(sg => sg.SwitchGearToSf6SafetyAndLife)
                .Include(sg => sg.SwitchGearToSwitchPosition)
                .Include(sg => sg.SwitchGearToTripCircuitSupervisionRelay)
                .Include(sg => sg.SwitchGearToTripRelay)
                .Include(sg => sg.SwitchGearToVoltMeter)
                .Include(sg => sg.SwitchGearType)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer.PhasePowerTransformerTo33KvFeederLine)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationType)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "SwitchGearID");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchSwitchgear", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchSwitchgear(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "SwitchGearID")
        {
            ViewBag.TotalRecords = _dbContext.TblSwitchGear.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "sgtl.SwitchGearTypeName", Text = "Switchgear Type"},
                new SelectListItem {Value = "sgt.ManufacturersNameAndAddress", Text = "Manufacturers Name and Address"},
                new SelectListItem {Value = "sgt.AppliedStandard", Text = "Applied Standard"},
                new SelectListItem {Value = "sgt.RatedNominalVoltage", Text = "Rated Nominal Voltage"},
                new SelectListItem {Value = "sgt.RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "sgt.RatedCurrentForMainBus", Text = "Rated Current for Main Bus"},
                new SelectListItem {Value = "sgt.RatedShortTimeCurrent", Text = "Rated Short Time Current"},
                new SelectListItem {Value = "sgt.ShortTimeCurrentRatedDuration", Text = "Short Time Current Rated Duration"},

                new SelectListItem {Value = "cbrl.CircuitBreaker.Type", Text = "Circuit Breaker Type"},
                new SelectListItem {Value = "drel.IdmtRelay.ManufacturersModelNo", Text = "IDMT Relay Model No."},
                new SelectListItem {Value = "drel.TripRelay.ManufacturersModelNo", Text = "Trip Relay Model No."},
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


            Expression<Func<TblSwitchGear, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode;

            zoneCode = circleCode = snDCode = substationCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblSwitchGear, bool>> tempExp = model =>
                        model.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblSwitchGear>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblSwitchGear>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblSwitchGear>.AndAlso(searchExp, tempExp);

                            //if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            //{
                            //    routeCode = regionList[4];

                            //    tempExp = model => model.SwitchGearToPhasePowerTransformer.PhasePowerTransformerTo33KvFeederLine.FeederLineToRoute.RouteCode == routeCode;
                            //    searchExp = ExpressionExtension<TblSwitchGear>.AndAlso(searchExp, tempExp);

                            //    ViewBag.RouteList = new SelectList(_dbContext.LookUpRouteInfo
                            //        .Where(ri => ri.RouteToSubstation.SubstationId.Equals(substationCode))
                            //        .Select(ri => new { ri.RouteCode, ri.RouteName })
                            //        .OrderBy(ri => ri.RouteCode).ToList(), "RouteCode", "RouteName", routeCode);
                            //}
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

                    Expression<Func<TblSwitchGear, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "SwitchGearTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SwitchGearType.SwitchGearTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SwitchGearType.SwitchGearTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearType.SwitchGearTypeName) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearType.SwitchGearTypeName) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearType.SwitchGearTypeName) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearType.SwitchGearTypeName) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.ManufacturersNameAndAddress) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.ManufacturersNameAndAddress) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.ManufacturersNameAndAddress) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.ManufacturersNameAndAddress) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.AppliedStandard) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.AppliedStandard) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.AppliedStandard) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.AppliedStandard) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.RatedNominalVoltage) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.RatedNominalVoltage) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.RatedNominalVoltage) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.RatedNominalVoltage) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.RatedVoltage) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.RatedVoltage) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.RatedVoltage) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.RatedVoltage) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.RatedCurrentForMainBus) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.RatedCurrentForMainBus) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.RatedCurrentForMainBus) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.RatedCurrentForMainBus) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.RatedShortTimeCurrent) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.RatedShortTimeCurrent) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.RatedShortTimeCurrent) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.RatedShortTimeCurrent) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.ShortTimeCurrentRatedDuration) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.ShortTimeCurrentRatedDuration) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.ShortTimeCurrentRatedDuration) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.ShortTimeCurrentRatedDuration) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToCircuitBreaker.Type) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToCircuitBreaker.Type) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToCircuitBreaker.Type) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToCircuitBreaker.Type) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToIdmtRelay.ManufacturersModelNo) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToIdmtRelay.ManufacturersModelNo) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToIdmtRelay.ManufacturersModelNo) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToIdmtRelay.ManufacturersModelNo) <= Convert.ToInt16(searchOption.FieldValue);
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
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToTripRelay.ManufacturersModelNo) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToTripRelay.ManufacturersModelNo) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToTripRelay.ManufacturersModelNo) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => Convert.ToInt16(model.SwitchGearToTripRelay.ManufacturersModelNo) <= Convert.ToInt16(searchOption.FieldValue);
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
                
            }


            var qry = searchExp != null
                ? _dbContext.TblSwitchGear.AsNoTracking().Where(searchExp)
                : _dbContext.TblSwitchGear.AsNoTracking();

            qry = qry
                .Include(sg => sg.SwitchGearToIdmtRelay)
                .Include(sg => sg.SwitchGearToAmpereMeter)
                .Include(sg => sg.SwitchGearToBusBar)
                .Include(sg => sg.SwitchGearToCircuitBreaker)
                .Include(sg => sg.SwitchGearToCurrentTransformer)
                .Include(sg => sg.SwitchGearToDimensionAndWeight)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer)
                .Include(sg => sg.SwitchGearToSf6SafetyAndLife)
                .Include(sg => sg.SwitchGearToSwitchPosition)
                .Include(sg => sg.SwitchGearToTripCircuitSupervisionRelay)
                .Include(sg => sg.SwitchGearToTripRelay)
                .Include(sg => sg.SwitchGearToVoltMeter)
                .Include(sg => sg.SwitchGearType)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer.PhasePowerTransformerTo33KvFeederLine)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationType)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(sg => sg.SwitchGearToPhasePowerTransformer.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "SwitchGearID");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchSwitchgear", searchResult);

        }

    }

}
