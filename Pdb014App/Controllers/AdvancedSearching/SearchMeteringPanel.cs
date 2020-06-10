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

        public async Task<IActionResult> SearchMeteringPanel([FromQuery] string cai, int pageIndex = 1, string sort = "SubstationId")
        {
            ViewBag.TotalRecords = _dbContext.TblMeteringPanel.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "mpt.ManufacturersNameCountryOfOrigin", Text = "Manufacturers Name Country of Origin"},
                new SelectListItem {Value = "mpt.ManufacturersModelNo", Text = "Manufacturers Model No."},
                new SelectListItem {Value = "mpt.SystemNominalVoltage", Text = "System Nominal Voltage"},
                new SelectListItem {Value = "mpt.MaximumSystemVoltage", Text = "Maximum System Voltage"},
                new SelectListItem {Value = "mpt.RatedFrequency", Text = "Rated Frequency"}
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


            ViewBag.ZoneList = new SelectList(_dbContext.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            ViewBag.FieldList = fieldList;
            ViewBag.OperatorList = operatorList;

            var qry = _dbContext.TblMeteringPanel.AsNoTracking()
                .Include(mp => mp.AmpereMeter)
                .Include(mp => mp.AnnuciatorForFeeder)
                .Include(mp => mp.AnnuciatorForTransformer)
                .Include(mp => mp.AuxiliaryFlagRelayForTransformer)
                .Include(mp => mp.ControlSwitchForFeeder)
                .Include(mp => mp.ControlSwitchForTransformer)
                .Include(mp => mp.DifferentialRelayForTransformer)
                .Include(mp => mp.IdmtOverCurrentAndEarthFaultRelayForFeeder)
                .Include(mp => mp.IdmtOverCurrentAndEarthFaultRelayForTransformer)
                .Include(mp => mp.KWHandkVARHMeter)
                .Include(mp => mp.MegaVarMeter)
                .Include(mp => mp.MegaWattMeter)
                .Include(mp => mp.MeteringPanelToDimensionAndWeight)
                .Include(mp => mp.RestrictedEarthFaultRelayForTransformer)
                .Include(mp => mp.TripCircuitSupervisionRelayForFeeder)
                .Include(mp => mp.TripCircuitSupervisionRelayForTransformer)
                .Include(mp => mp.TripRelayForFeeder)
                .Include(mp => mp.TripRelayForTransformer)
                .Include(mp => mp.VoltMeterWithSelectorSwitch)
                .Include(mp => mp.MeteringPanelToSubstation)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationType)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "SubstationId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchMeteringPanel", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchMeteringPanel(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "SubstationId")
        {
            ViewBag.TotalRecords = _dbContext.TblMeteringPanel.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "mpt.ManufacturersNameCountryOfOrigin", Text = "Manufacturers Name Country of Origin"},
                new SelectListItem {Value = "mpt.ManufacturersModelNo", Text = "Manufacturers Model No."},
                new SelectListItem {Value = "mpt.SystemNominalVoltage", Text = "System Nominal Voltage"},
                new SelectListItem {Value = "mpt.MaximumSystemVoltage", Text = "Maximum System Voltage"},
                new SelectListItem {Value = "mpt.RatedFrequency", Text = "Rated Frequency"}
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
            

            Expression<Func<TblMeteringPanel, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode;

            zoneCode = circleCode = snDCode = substationCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.MeteringPanelToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblMeteringPanel, bool>> tempExp = model =>
                        model.MeteringPanelToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblMeteringPanel>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.MeteringPanelToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblMeteringPanel>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblMeteringPanel>.AndAlso(searchExp, tempExp);

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

                    Expression<Func<TblMeteringPanel, bool>> tempExp = null;

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
                                        Convert.ToInt16(model.MeteringPanelToSubstation.SubstationName) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.MeteringPanelToSubstation.SubstationName) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.MeteringPanelToSubstation.SubstationName) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.MeteringPanelToSubstation.SubstationName) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.ManufacturersNameCountryOfOrigin) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufacturersNameCountryOfOrigin) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufacturersNameCountryOfOrigin) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufacturersNameCountryOfOrigin) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.ManufacturersModelNo) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufacturersModelNo) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufacturersModelNo) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufacturersModelNo) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.SystemNominalVoltage) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SystemNominalVoltage) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SystemNominalVoltage) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SystemNominalVoltage) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.MaximumSystemVoltage) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.MaximumSystemVoltage) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.MaximumSystemVoltage) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.MaximumSystemVoltage) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.RatedFrequency) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedFrequency) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedFrequency) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedFrequency) <= Convert.ToInt16(searchOption.FieldValue);
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

            }


            var qry = searchExp != null
                ? _dbContext.TblMeteringPanel.AsNoTracking().Where(searchExp)
                : _dbContext.TblMeteringPanel.AsNoTracking();

            qry = qry
                .Include(mp => mp.AmpereMeter)
                .Include(mp => mp.AnnuciatorForFeeder)
                .Include(mp => mp.AnnuciatorForTransformer)
                .Include(mp => mp.AuxiliaryFlagRelayForTransformer)
                .Include(mp => mp.ControlSwitchForFeeder)
                .Include(mp => mp.ControlSwitchForTransformer)
                .Include(mp => mp.DifferentialRelayForTransformer)
                .Include(mp => mp.IdmtOverCurrentAndEarthFaultRelayForFeeder)
                .Include(mp => mp.IdmtOverCurrentAndEarthFaultRelayForTransformer)
                .Include(mp => mp.KWHandkVARHMeter)
                .Include(mp => mp.MegaVarMeter)
                .Include(mp => mp.MegaWattMeter)
                .Include(mp => mp.MeteringPanelToDimensionAndWeight)
                .Include(mp => mp.RestrictedEarthFaultRelayForTransformer)
                .Include(mp => mp.TripCircuitSupervisionRelayForFeeder)
                .Include(mp => mp.TripCircuitSupervisionRelayForTransformer)
                .Include(mp => mp.TripRelayForFeeder)
                .Include(mp => mp.TripRelayForTransformer)
                .Include(mp => mp.VoltMeterWithSelectorSwitch)
                .Include(mp => mp.MeteringPanelToSubstation)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationType)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(mp => mp.MeteringPanelToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "SubstationId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchMeteringPanel", searchResult);

        }

    }

}
