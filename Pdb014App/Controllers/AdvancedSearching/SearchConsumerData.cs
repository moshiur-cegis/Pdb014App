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
using Pdb014App.Models.PDB.ServicePointModels;


namespace Pdb014App.Controllers.AdvancedSearching
{
    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchConsumerData([FromQuery] string cai, int pageIndex = 1, string sort = "ConsumerId")
        {
            ViewBag.TotalRecords = _dbContext.TblConsumerData.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "cdt.ConsumerId", Text = "Consumer Id"},

                new SelectListItem {Value = "plt.PoleNo", Text = "Pole No."},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},
                new SelectListItem {Value = "dtt.NearestHoldingbsHouseNobsShop", Text = "DT (Nearest Location)"},

                new SelectListItem {Value = "spt.ServicePoint.RoadName", Text = "Service Point Road Name"},

                new SelectListItem {Value = "cdt.CustomerName", Text = "Customer Name"},
                new SelectListItem {Value = "cdt.CustomerMobileNo", Text = "Customer Mobile No."},
                new SelectListItem {Value = "cdt.ConsumerNo", Text = "Consumer No."},
                new SelectListItem {Value = "cotl.ConsumerTypeName", Text = "Consumer Type"},
                new SelectListItem {Value = "cctl.ConnectionTypeName", Text = "Connection Type"},
                new SelectListItem {Value = "ccsl.ConnectionStatusName", Text = "Connection Status"},

                new SelectListItem {Value = "cdt.PremiseName", Text = "Premise Name"},
                new SelectListItem {Value = "cdt.Tariff", Text = "Tariff"},
                new SelectListItem {Value = "cdt.ServiceCableSize", Text = "Service Cable Size"},
                new SelectListItem {Value = "pctl.PhasingCodeName", Text = "Phasing Code"},
                new SelectListItem {Value = "opvl.OperatingVoltageName", Text = "Operating Voltage"},
                new SelectListItem {Value = "cdt.CustomerAddress", Text = "Address"},
                new SelectListItem {Value = "cdt.MeterNumber", Text = "Meter Number"},
                new SelectListItem {Value = "cdt.SanctionedLoad", Text = "Sanctioned Load"},
                new SelectListItem {Value = "cdt.ConnectedLoad", Text = "Connected Load"},
                new SelectListItem {Value = "cbtl.BusinessTypeName", Text = "Business Type"},
                new SelectListItem {Value = "cdt.AccountNumber", Text = "Account Number"},
                new SelectListItem {Value = "cdt.SpecialCode", Text = "Special Code"},
                new SelectListItem {Value = "cdt.SpecialType", Text = "Special Type"},
                new SelectListItem {Value = "clol.LocationName", Text = "Location"},
                new SelectListItem {Value = "cdt.BillGroup", Text = "Bill Group"},
                new SelectListItem {Value = "cdt.BookNumber", Text = "Book Number"},
                new SelectListItem {Value = "cdt.OmfKwh", Text = "Omf Kwh"},
                new SelectListItem {Value = "cdt.MeterReading", Text = "Meter Reading"},
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

            var qry = _dbContext.TblConsumerData.AsNoTracking()
                .Include(cd => cd.ConsumerType)
                .Include(cd => cd.ConsumerToConnectionType)
                .Include(cd => cd.ConsumerToConnectionStatus)
                .Include(cd => cd.ConsumerToBusinessType)
                .Include(cd => cd.ConsumerToLocation)
                .Include(cd => cd.ConsumerToMeterType)
                .Include(cd => cd.ConsumerToOperatingVoltage)
                .Include(cd => cd.ConsumerToPhasingCode)
                .Include(cd => cd.ConsumerToServiceCableType)
                .Include(cd => cd.ConsumerToStructureType)

                .Include(cd => cd.ConsumerDataToServicePoint)
                .Include(cd => cd.ConsumerDataToDistributionTransformer)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToPole)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "ConsumerId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchConsumerData", searchResult);

        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchConsumerData(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "ConsumerId")
        {
            ViewBag.TotalRecords = _dbContext.TblConsumerData.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "cdt.ConsumerId", Text = "Consumer Id"},

                new SelectListItem {Value = "plt.PoleNo", Text = "Pole No."},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},
                new SelectListItem {Value = "dtt.NearestHoldingbsHouseNobsShop", Text = "DT (Nearest Location)"},

                new SelectListItem {Value = "spt.ServicePoint.RoadName", Text = "Service Point Road Name"},

                new SelectListItem {Value = "cdt.CustomerName", Text = "Customer Name"},
                new SelectListItem {Value = "cdt.CustomerMobileNo", Text = "Customer Mobile No."},
                new SelectListItem {Value = "cdt.ConsumerNo", Text = "Consumer No."},
                new SelectListItem {Value = "cotl.ConsumerTypeName", Text = "Consumer Type"},
                new SelectListItem {Value = "cctl.ConnectionTypeName", Text = "Connection Type"},
                new SelectListItem {Value = "ccsl.ConnectionStatusName", Text = "Connection Status"},

                new SelectListItem {Value = "cdt.PremiseName", Text = "Premise Name"},
                new SelectListItem {Value = "cdt.Tariff", Text = "Tariff"},
                new SelectListItem {Value = "cdt.ServiceCableSize", Text = "Service Cable Size"},
                new SelectListItem {Value = "pctl.PhasingCodeName", Text = "Phasing Code"},
                new SelectListItem {Value = "opvl.OperatingVoltageName", Text = "Operating Voltage"},
                new SelectListItem {Value = "cdt.CustomerAddress", Text = "Address"},
                new SelectListItem {Value = "cdt.MeterNumber", Text = "Meter Number"},
                new SelectListItem {Value = "cdt.SanctionedLoad", Text = "Sanctioned Load"},
                new SelectListItem {Value = "cdt.ConnectedLoad", Text = "Connected Load"},
                new SelectListItem {Value = "cbtl.BusinessTypeName", Text = "Business Type"},
                new SelectListItem {Value = "cdt.AccountNumber", Text = "Account Number"},
                new SelectListItem {Value = "cdt.SpecialCode", Text = "Special Code"},
                new SelectListItem {Value = "cdt.SpecialType", Text = "Special Type"},
                new SelectListItem {Value = "clol.LocationName", Text = "Location"},
                new SelectListItem {Value = "cdt.BillGroup", Text = "Bill Group"},
                new SelectListItem {Value = "cdt.BookNumber", Text = "Book Number"},
                new SelectListItem {Value = "cdt.OmfKwh", Text = "Omf Kwh"},
                new SelectListItem {Value = "cdt.MeterReading", Text = "Meter Reading"},
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


            Expression<Func<TblConsumerData, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.ConsumerDataToDistributionTransformer.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblConsumerData, bool>> tempExp = model =>
                        model.ConsumerDataToDistributionTransformer.DtToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.ConsumerDataToDistributionTransformer.DtToPole.PoleToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.ConsumerDataToDistributionTransformer.DtToPole.PoleToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);

                            if (regionList.Count > 4)
                            {
                                routeCode = regionList[4];

                                tempExp = model => model.ConsumerDataToDistributionTransformer.DtToPole.PoleToRoute.RouteCode == routeCode;
                                searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);

                                ViewBag.RouteList = new SelectList(_dbContext.LookUpRouteInfo
                                    .Where(ri => ri.RouteToSubstation.SubstationId.Equals(substationCode))
                                    .Select(ri => new { ri.RouteCode, ri.RouteName })
                                    .OrderBy(ri => ri.RouteCode).ToList(), "RouteCode", "RouteName", routeCode);
                            }
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
                {"regionList[3]", substationCode},
                {"regionList[4]", routeCode}
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
                        FieldName = searchParameter[0].Contains('.') ? searchParameter[0].Split('.')[1] : searchParameter[0],
                        Operator = searchParameter[1],
                        FieldValue = searchParameter[2],
                        JoinOption = searchParameter[3]
                    };

                    Expression<Func<TblConsumerData, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {

                        case "ConsumerId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerId == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerId != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.ConsumerId > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.ConsumerId < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.ConsumerId >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.ConsumerId <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => false; //model.ConsumerId == null;
                                    break;
                                case "not null":
                                    tempExp = model => true; //model.ConsumerId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerId.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToPole.PoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "NearestHoldingbsHouseNobsShop":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.NearestHoldingbsHouseNobsShop.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "ServicePoint":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerDataToServicePoint.RoadName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerDataToServicePoint.RoadName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToServicePoint.RoadName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToServicePoint.RoadName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToServicePoint.RoadName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToServicePoint.RoadName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerDataToServicePoint.RoadName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerDataToServicePoint.RoadName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerDataToServicePoint.RoadName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "CustomerName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.CustomerName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.CustomerName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.CustomerName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.CustomerName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.CustomerName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.CustomerName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.CustomerName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.CustomerName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.CustomerName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "CustomerMobileNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.CustomerMobileNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.CustomerMobileNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.CustomerMobileNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.CustomerMobileNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.CustomerMobileNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.CustomerMobileNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.CustomerMobileNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.CustomerMobileNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.CustomerMobileNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "ConsumerNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ConsumerTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerType.ConsumerTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerType.ConsumerTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerType.ConsumerTypeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerType.ConsumerTypeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerType.ConsumerTypeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerType.ConsumerTypeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerType.ConsumerTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerType.ConsumerTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerType.ConsumerTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ConnectionTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerToConnectionType.ConnectionTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerToConnectionType.ConnectionTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToConnectionType.ConnectionTypeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToConnectionType.ConnectionTypeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToConnectionType.ConnectionTypeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToConnectionType.ConnectionTypeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerToConnectionType.ConnectionTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerToConnectionType.ConnectionTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerToConnectionType.ConnectionTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ConnectionStatusName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerToConnectionStatus.ConnectionStatusName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerToConnectionStatus.ConnectionStatusName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToConnectionStatus.ConnectionStatusName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToConnectionStatus.ConnectionStatusName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToConnectionStatus.ConnectionStatusName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToConnectionStatus.ConnectionStatusName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerToConnectionStatus.ConnectionStatusName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerToConnectionStatus.ConnectionStatusName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerToConnectionStatus.ConnectionStatusName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "PremiseName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PremiseName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PremiseName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PremiseName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PremiseName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PremiseName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PremiseName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PremiseName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PremiseName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PremiseName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "Tariff":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Tariff == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Tariff != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Tariff) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Tariff) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Tariff) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Tariff) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Tariff == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Tariff != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Tariff.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ServiceCableSize":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ServiceCableSize == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ServiceCableSize != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ServiceCableSize) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ServiceCableSize) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ServiceCableSize) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ServiceCableSize) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ServiceCableSize == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ServiceCableSize != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ServiceCableSize.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PhasingCodeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerToPhasingCode.PhasingCodeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerToPhasingCode.PhasingCodeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToPhasingCode.PhasingCodeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToPhasingCode.PhasingCodeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToPhasingCode.PhasingCodeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToPhasingCode.PhasingCodeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerToPhasingCode.PhasingCodeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerToPhasingCode.PhasingCodeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerToPhasingCode.PhasingCodeName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "OperatingVoltageName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerToOperatingVoltage.OperatingVoltageName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerToOperatingVoltage.OperatingVoltageName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToOperatingVoltage.OperatingVoltageName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToOperatingVoltage.OperatingVoltageName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToOperatingVoltage.OperatingVoltageName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToOperatingVoltage.OperatingVoltageName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerToOperatingVoltage.OperatingVoltageName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerToOperatingVoltage.OperatingVoltageName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerToOperatingVoltage.OperatingVoltageName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "CustomerAddress":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.CustomerAddress == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.CustomerAddress != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.CustomerAddress) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.CustomerAddress) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.CustomerAddress) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.CustomerAddress) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.CustomerAddress == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.CustomerAddress != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.CustomerAddress.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "MeterNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MeterNumber == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MeterNumber != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.MeterNumber) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.MeterNumber) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.MeterNumber) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.MeterNumber) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MeterNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MeterNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MeterNumber.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "SanctionedLoad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SanctionedLoad == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.SanctionedLoad != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model =>
                                        model.SanctionedLoad > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        model.SanctionedLoad < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.SanctionedLoad >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.SanctionedLoad <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SanctionedLoad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SanctionedLoad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SanctionedLoad.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ConnectedLoad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConnectedLoad == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.ConnectedLoad != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model =>
                                        model.ConnectedLoad > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        model.ConnectedLoad < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.ConnectedLoad >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.ConnectedLoad <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConnectedLoad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConnectedLoad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConnectedLoad.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "BusinessTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerToBusinessType.BusinessTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerToBusinessType.BusinessTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToBusinessType.BusinessTypeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToBusinessType.BusinessTypeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToBusinessType.BusinessTypeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToBusinessType.BusinessTypeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerToBusinessType.BusinessTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerToBusinessType.BusinessTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerToBusinessType.BusinessTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "AccountNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.AccountNumber == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.AccountNumber != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.AccountNumber) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.AccountNumber) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.AccountNumber) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.AccountNumber) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.AccountNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.AccountNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.AccountNumber.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "SpecialCode":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SpecialCode == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SpecialCode != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SpecialCode) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SpecialCode) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SpecialCode) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SpecialCode) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SpecialCode == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SpecialCode != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SpecialCode.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "SpecialType":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SpecialType == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SpecialType != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SpecialType) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SpecialType) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SpecialType) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SpecialType) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SpecialType == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SpecialType != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SpecialType.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "LocationName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerToLocation.LocationName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerToLocation.LocationName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToLocation.LocationName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToLocation.LocationName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToLocation.LocationName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerToLocation.LocationName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerToLocation.LocationName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerToLocation.LocationName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerToLocation.LocationName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "BillGroup":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.BillGroup == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.BillGroup != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model =>
                                        model.BillGroup > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        model.BillGroup < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.BillGroup >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.BillGroup <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.BillGroup == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.BillGroup != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.BillGroup.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "BookNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.BookNumber == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.BookNumber != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model =>
                                        model.BookNumber > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        model.BookNumber < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.BookNumber >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.BookNumber <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.BookNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.BookNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.BookNumber.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        //case "BcCode":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.BcCode == int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.BcCode != int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.BcCode) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.BcCode) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.BcCode) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.BcCode) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.BcCode == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.BcCode != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.BcCode.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


                        //case "Ws":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.Ws == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.Ws != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.Ws) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.Ws) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.Ws) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.Ws) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.Ws == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.Ws != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.Ws.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


                        case "OmfKwh":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.OmfKwh == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.OmfKwh != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.OmfKwh) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.OmfKwh) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.OmfKwh) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.OmfKwh) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.OmfKwh == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.OmfKwh != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.OmfKwh.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "MeterReading":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MeterReading == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MeterReading != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.MeterReading) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.MeterReading) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.MeterReading) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.MeterReading) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MeterReading == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MeterReading != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MeterReading.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                            //case "LastReadingDate":
                            //    switch (searchOption.Operator)
                            //    {
                            //        case "=":
                            //            tempExp = model => model.LastReadingDate == searchOption.FieldValue;
                            //            break;
                            //        case "!=":
                            //            tempExp = model => model.LastReadingDate != searchOption.FieldValue;
                            //            break;
                            //        case ">":
                            //            tempExp = model => DateTime.Parse(model.LastReadingDate) > DateTime.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<":
                            //            tempExp = model => DateTime.Parse(model.LastReadingDate) < DateTime.Parse(searchOption.FieldValue);
                            //            break;
                            //        case ">=":
                            //            tempExp = model => DateTime.Parse(model.LastReadingDate) >= DateTime.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<=":
                            //            tempExp = model => DateTime.Parse(model.LastReadingDate) <= DateTime.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "null":
                            //            tempExp = model => model.LastReadingDate == null;
                            //            break;
                            //        case "not null":
                            //            tempExp = model => model.LastReadingDate != null;
                            //            break;
                            //        case "Like":
                            //            tempExp = model => model.LastReadingDate.Contains(searchOption.FieldValue);
                            //            break;
                            //    }

                            //    break;

                    }


                    if (searchExp == null)
                    {
                        searchExp = tempExp;
                    }
                    else
                    {
                        searchExp = joinOption.ToUpper() == "OR"
                            ? ExpressionExtension<TblConsumerData>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }

            var qry = searchExp != null
                ? _dbContext.TblConsumerData.AsNoTracking().Where(searchExp)
                : _dbContext.TblConsumerData.AsNoTracking();

            qry = qry
                .Include(cd => cd.ConsumerType)
                .Include(cd => cd.ConsumerToConnectionType)
                .Include(cd => cd.ConsumerToConnectionStatus)
                .Include(cd => cd.ConsumerToBusinessType)
                .Include(cd => cd.ConsumerToLocation)
                .Include(cd => cd.ConsumerToMeterType)
                .Include(cd => cd.ConsumerToOperatingVoltage)
                .Include(cd => cd.ConsumerToPhasingCode)
                .Include(cd => cd.ConsumerToServiceCableType)
                .Include(cd => cd.ConsumerToStructureType)

                .Include(cd => cd.ConsumerDataToServicePoint)
                .Include(cd => cd.ConsumerDataToDistributionTransformer)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToPole)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationType)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(cd => cd.ConsumerDataToDistributionTransformer.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "ConsumerId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchConsumerData", searchResult);

        }

    }

}
