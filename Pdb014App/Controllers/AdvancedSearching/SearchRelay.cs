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
        public async Task<IActionResult> SearchRelay([FromQuery] string cai, int pageIndex = 1, string sort = "RelayId")
        {
            ViewBag.TotalRecords = _dbContext.TblRelay.AsNoTracking().Count();
            ViewBag.SearchParameters = new List<List<string>>(3);


            var fields = new List<SelectListItem>
            {
                //new SelectListItem {Value = "plt.PoleNo", Text = "Pole No."},
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "ret.RelayName", Text = "Relay Name"},
                new SelectListItem {Value = "ret.NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "ret.ManufactureName", Text = "Manufacture Name"},
                new SelectListItem {Value = "ret.ModelNumber", Text = "Model Number"},
                new SelectListItem {Value = "ret.RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "ret.RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "ret.ConnectionStatus", Text = "Connection Status"},
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

            var qry = _dbContext.TblRelay.AsNoTracking()
                .Include(re => re.RelayToFeederLine)
                .Include(re => re.RelayToSubstation)
                .Include(re => re.RelayToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(re => re.RelayToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "RelayId");

            searchResult.RouteValue = new RouteValueDictionary { { "cai", cai } };

            return View("SearchRelay", searchResult);
        }


        //[HttpPost]
        [HttpGet]
        public async Task<IActionResult> SearchRelay(List<string> regionList, List<List<string>> searchParameters, string cai, int pageIndex = 1, string sort = "RelayId")
        {
            ViewBag.TotalRecords = _dbContext.TblRelay.AsNoTracking().Count();
            ViewBag.SearchParameters = searchParameters;


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "flt.FeederName", Text = "Feeder Line Name"},
                new SelectListItem {Value = "sst.SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "ret.RelayName", Text = "Relay Name"},
                new SelectListItem {Value = "ret.NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "ret.ManufactureName", Text = "Manufacture Name"},
                new SelectListItem {Value = "ret.ModelNumber", Text = "Model Number"},
                new SelectListItem {Value = "ret.RatedCurrent", Text = "Rated Current"},
                new SelectListItem {Value = "ret.RatedVoltage", Text = "Rated Voltage"},
                new SelectListItem {Value = "ret.ConnectionStatus", Text = "Connection Status"},
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
            

            Expression<Func<TblRelay, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode;

            zoneCode = circleCode = snDCode = substationCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.RelayToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                ViewBag.CircleList = new SelectList(_dbContext.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName", circleCode);

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblRelay, bool>> tempExp = model =>
                        model.RelayToSubstation.SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblRelay>.AndAlso(searchExp, tempExp);

                    ViewBag.SnDList = new SelectList(_dbContext.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName", snDCode);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.RelayToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblRelay>.AndAlso(searchExp, tempExp);

                        ViewBag.SubstationList = new SelectList(_dbContext.TblSubstation
                            .Where(ss => ss.SnDCode.Equals(snDCode))
                            .Select(ss => new { ss.SubstationId, ss.SubstationName })
                            .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName", substationCode);


                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model => model.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblRelay>.AndAlso(searchExp, tempExp);

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
                //Expression<Func<TblSubstation, bool>> searchExp = null;

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

                    Expression<Func<TblRelay, bool>> tempExp = null;

                    switch (searchOption.FieldName)
                    {

                        case "FeederName":
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
                                        Convert.ToInt16(model.RelayToFeederLine.FeederName) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayToFeederLine.FeederName) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayToFeederLine.FeederName) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayToFeederLine.FeederName) <= Convert.ToInt16(searchOption.FieldValue);
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


                        case "SubstationName":
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
                                        Convert.ToInt16(model.RelayToSubstation.SubstationName) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayToSubstation.SubstationName) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayToSubstation.SubstationName) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayToSubstation.SubstationName) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.RelayName) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayName) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayName) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.RelayName) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.ManufactureName) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufactureName) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufactureName) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ManufactureName) <= Convert.ToInt16(searchOption.FieldValue);
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
                                        Convert.ToInt16(model.ModelNumber) > Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ModelNumber) < Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ModelNumber) >= Convert.ToInt16(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        Convert.ToInt16(model.ModelNumber) <= Convert.ToInt16(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblRelay>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblRelay>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }

            }

            var qry = searchExp != null
                ? _dbContext.TblRelay.AsNoTracking().Where(searchExp)
                : _dbContext.TblRelay.AsNoTracking();

            qry = qry
                .Include(re => re.RelayToFeederLine)
                .Include(re => re.RelayToSubstation)
                .Include(re => re.RelayToSubstation.SubstationToLookUpSnD.LookUpAdminBndDistrict)
                .Include(re => re.RelayToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "RelayId");

            searchResult.RouteValue = searchParametersRoute;

            return View("SearchRelay", searchResult);

        }

    }
    
}
