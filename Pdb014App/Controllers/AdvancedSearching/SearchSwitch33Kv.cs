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

        public async Task<IActionResult> SearchSwitch33Kv([FromQuery] string cai, int pageIndex = 1, string sort = "Switch33KvIsolatorId")
        {
            ViewBag.TotalRecords = _dbContext.TblSwitch33KvIsolator.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "sit.TypeIsolatorSwitch", Text = "Type Isolator Switch"},
                new SelectListItem {Value = "sit.SwitchID", Text = "Switch ID"},
                new SelectListItem {Value = "sit.NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "sit.BreakingType", Text = "Breaking Type"},
                new SelectListItem {Value = "sit.ManufactureMonthAndYear", Text = "Manufacture Month and Year"},
                new SelectListItem {Value = "sit.InstallationDate", Text = "Installation Date"},
                new SelectListItem {Value = "sit.NormalStatus", Text = "Normal Status"},
                new SelectListItem {Value = "sit.RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "sit.RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "sit.ConnectionStatus", Text = "Connection Status"},
                new SelectListItem {Value = "sit.SwitchNo", Text = "Switch No."},
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

            var qry = _dbContext.TblSwitch33KvIsolator.AsNoTracking()
                .Include(si => si.SwitchToFeederLine)
                .Include(si => si.SwitchToFeederLine.FeederLineToRoute)
                .Include(si => si.Switch33KvIsolatorToSubstation)
                .Include(si => si.Switch33KvIsolatorToSubstation.SubstationType)
                .Include(si => si.Switch33KvIsolatorToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(si => si.Switch33KvIsolatorToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "Switch33KvIsolatorId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchSwitch33Kv", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchSwitch33Kv(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "Switch33KvIsolatorId")
        {
            ViewBag.TotalRecords = _dbContext.TblSwitch33KvIsolator.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "sit.TypeIsolatorSwitch", Text = "Type Isolator Switch"},
                new SelectListItem {Value = "sit.SwitchID", Text = "Switch ID"},
                new SelectListItem {Value = "sit.SwitchNo", Text = "Switch No."},
                new SelectListItem {Value = "sit.NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "sit.BreakingType", Text = "Breaking Type"},
                new SelectListItem {Value = "sit.ManufactureMonthAndYear", Text = "Manufacture Month and Year"},
                new SelectListItem {Value = "sit.InstallationDate", Text = "Installation Date"},
                new SelectListItem {Value = "sit.NormalStatus", Text = "Normal Status"},
                new SelectListItem {Value = "sit.RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "sit.RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "sit.ConnectionStatus", Text = "Connection Status"}
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


            Expression<Func<TblSwitch33KvIsolator, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode;

            zoneCode = circleCode = snDCode = substationCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.Switch33KvIsolatorToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblSwitch33KvIsolator, bool>> tempExp = model =>
                        model.Switch33KvIsolatorToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblSwitch33KvIsolator>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.Switch33KvIsolatorToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblSwitch33KvIsolator>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.Switch33KvIsolatorToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblSwitch33KvIsolator>.AndAlso(searchExp, tempExp);

                            //if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            //{
                            //    routeCode = regionList[4];

                            //    tempExp = model => model.SwitchToFeederLine.FeederLineToRoute.RouteCode == routeCode;
                            //    searchExp = ExpressionExtension<TblSwitch33KvIsolator>.AndAlso(searchExp, tempExp);

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

                    Expression<Func<TblSwitch33KvIsolator, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {

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
                                        Convert.ToInt16(model.SwitchToFeederLine.FeederName) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchToFeederLine.FeederName) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchToFeederLine.FeederName) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchToFeederLine.FeederName) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.Switch33KvIsolatorToSubstation.SubstationName) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.Switch33KvIsolatorToSubstation.SubstationName) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.Switch33KvIsolatorToSubstation.SubstationName) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.Switch33KvIsolatorToSubstation.SubstationName) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.TypeIsolatorSwitch) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.TypeIsolatorSwitch) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.TypeIsolatorSwitch) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.TypeIsolatorSwitch) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.SwitchID) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchID) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchID) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchID) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.SwitchNo) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchNo) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchNo) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.SwitchNo) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.NominalVoltage) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.NominalVoltage) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.NominalVoltage) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.NominalVoltage) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.BreakingType) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.BreakingType) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.BreakingType) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.BreakingType) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.ManufactureMonthAndYear) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufactureMonthAndYear) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufactureMonthAndYear) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufactureMonthAndYear) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.InstallationDate) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.InstallationDate) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.InstallationDate) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.InstallationDate) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.NormalStatus) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.NormalStatus) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.NormalStatus) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.NormalStatus) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.RatedCurrent) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedCurrent) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedCurrent) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedCurrent) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.RatedVoltage) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedVoltage) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedVoltage) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RatedVoltage) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.ConnectionStatus) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ConnectionStatus) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ConnectionStatus) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ConnectionStatus) <= Convert.ToInt16(searchOption.FieldValue);
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

            }


            var qry = searchExp != null
                ? _dbContext.TblSwitch33KvIsolator.AsNoTracking().Where(searchExp)
                : _dbContext.TblSwitch33KvIsolator.AsNoTracking();
            
            qry = qry
                .Include(si => si.SwitchToFeederLine)
                .Include(si => si.SwitchToFeederLine.FeederLineToRoute)
                .Include(si => si.Switch33KvIsolatorToSubstation)
                .Include(si => si.Switch33KvIsolatorToSubstation.SubstationType)
                .Include(si => si.Switch33KvIsolatorToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(si => si.Switch33KvIsolatorToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "Switch33KvIsolatorId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchSwitch33Kv", searchResult);

        }

    }
    
}
