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

        public async Task<IActionResult> SearchConsumerData(int modelId = 1, int pageIndex = 1, string sort = "ConsumerId", string sortExp = "ConsumerId") 
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
                new SelectListItem {Value = "ConsumerId", Text = "Consumer Id"},
                new SelectListItem {Value = "CustomerName", Text = "Customer Name"},
                new SelectListItem {Value = "ConsumerDataToServicePoint", Text = "Service Point"},
                new SelectListItem {Value = "ConsumerDataToDistributionTransformer", Text = "Distribution Transformer"},
                new SelectListItem {Value = "Tariff", Text = "Tariff"},
                new SelectListItem {Value = "PhasingCode", Text = "Phasing Code"},
                new SelectListItem {Value = "Status", Text = "Status"},
                new SelectListItem {Value = "OperatingVoltage", Text = "Operating Voltage"},
                new SelectListItem {Value = "Address", Text = "Address"},
                new SelectListItem {Value = "CriticalCustomer", Text = "Critical Customer"},
                new SelectListItem {Value = "MeterNumber", Text = "Meter Number"},
                new SelectListItem {Value = "SanctionedLoad", Text = "Sanctioned Load"},
                new SelectListItem {Value = "ConnectedLoad", Text = "Connected Load"},
                new SelectListItem {Value = "BusinessType", Text = "Business Type"},
                new SelectListItem {Value = "ConnectionStatus", Text = "Connection Status"},
                new SelectListItem {Value = "AccountNumber", Text = "Account Number"},
                new SelectListItem {Value = "SpecialCode", Text = "Special Code"},
                new SelectListItem {Value = "SpecialType", Text = "Special Type"},
                new SelectListItem {Value = "Location", Text = "Location"},
                new SelectListItem {Value = "BillGroup", Text = "Bill Group"},
                new SelectListItem {Value = "BookNumber", Text = "Book Number"},
                new SelectListItem {Value = "BcCode", Text = "Bc Code"},
                new SelectListItem {Value = "Ws", Text = "Ws"},
                new SelectListItem {Value = "OmfKwh", Text = "Omf Kwh"},
                new SelectListItem {Value = "MeterReading", Text = "Meter Reading"},
                new SelectListItem {Value = "LastReadingDate", Text = "Last Reading Date"}
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

            var qry = _context.TblConsumerData.AsNoTracking()
                .Include(t => t.ConsumerDataToDistributionTransformer)
                .Include(t => t.ConsumerDataToServicePoint)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchConsumerData", searchResult);

        }


        [HttpPost]
        public async Task<IActionResult> SearchConsumerData(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "ConsumerId", string sortExp = "ConsumerId") 
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
                new SelectListItem {Value = "ConsumerId", Text = "Consumer Id"},
                new SelectListItem {Value = "CustomerName", Text = "Customer Name"},
                new SelectListItem {Value = "ConsumerDataToServicePoint", Text = "Service Point"},
                new SelectListItem {Value = "ConsumerDataToDistributionTransformer", Text = "Distribution Transformer"},
                new SelectListItem {Value = "Tariff", Text = "Tariff"},
                new SelectListItem {Value = "PhasingCode", Text = "Phasing Code"},
                new SelectListItem {Value = "Status", Text = "Status"},
                new SelectListItem {Value = "OperatingVoltage", Text = "Operating Voltage"},
                new SelectListItem {Value = "Address", Text = "Address"},
                new SelectListItem {Value = "CriticalCustomer", Text = "Critical Customer"},
                new SelectListItem {Value = "MeterNumber", Text = "Meter Number"},
                new SelectListItem {Value = "SanctionedLoad", Text = "Sanctioned Load"},
                new SelectListItem {Value = "ConnectedLoad", Text = "Connected Load"},
                new SelectListItem {Value = "BusinessType", Text = "Business Type"},
                new SelectListItem {Value = "ConnectionStatus", Text = "Connection Status"},
                new SelectListItem {Value = "AccountNumber", Text = "Account Number"},
                new SelectListItem {Value = "SpecialCode", Text = "Special Code"},
                new SelectListItem {Value = "SpecialType", Text = "Special Type"},
                new SelectListItem {Value = "Location", Text = "Location"},
                new SelectListItem {Value = "BillGroup", Text = "Bill Group"},
                new SelectListItem {Value = "BookNumber", Text = "Book Number"},
                new SelectListItem {Value = "BcCode", Text = "Bc Code"},
                new SelectListItem {Value = "Ws", Text = "Ws"},
                new SelectListItem {Value = "OmfKwh", Text = "Omf Kwh"},
                new SelectListItem {Value = "MeterReading", Text = "Meter Reading"},
                new SelectListItem {Value = "LastReadingDate", Text = "Last Reading Date"}
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


            var qry = _context.TblConsumerData.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblConsumerData, Boolean>> searchExp = null;

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

                    Expression<Func<TblConsumerData, Boolean>> tempExp = null;

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


                        //case "ConsumerDataToServicePoint":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.ConsumerDataToServicePoint.PremiseName == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.ConsumerDataToServicePoint.PremiseName != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.ConsumerDataToServicePoint.PremiseName) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.ConsumerDataToServicePoint.PremiseName) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.ConsumerDataToServicePoint.PremiseName) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.ConsumerDataToServicePoint.PremiseName) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.ConsumerDataToServicePoint.PremiseName == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.ConsumerDataToServicePoint.PremiseName != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.ConsumerDataToServicePoint.PremiseName.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


                        case "ConsumerDataToDistributionTransformer":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DistributionTransformerId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DistributionTransformerId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DistributionTransformerId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DistributionTransformerId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DistributionTransformerId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConsumerDataToDistributionTransformer.DistributionTransformerId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DistributionTransformerId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DistributionTransformerId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConsumerDataToDistributionTransformer.DistributionTransformerId.Contains(searchOption.FieldValue);
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


                        //case "PhasingCode":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.PhasingCode == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.PhasingCode != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.PhasingCode) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.PhasingCode) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.PhasingCode) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.PhasingCode) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.PhasingCode == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.PhasingCode != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.PhasingCode.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


                        //case "Status":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.Status == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.Status != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.Status) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.Status) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.Status) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.Status) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.Status == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.Status != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.Status.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


                        //case "OperatingVoltage":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.OperatingVoltage == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.OperatingVoltage != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.OperatingVoltage) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.OperatingVoltage) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.OperatingVoltage) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.OperatingVoltage) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.OperatingVoltage == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.OperatingVoltage != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.OperatingVoltage.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


                        //case "Address":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.Address == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.Address != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.Address) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.Address) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.Address) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.Address) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.Address == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.Address != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.Address.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


                        //case "CriticalCustomer":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.CriticalCustomer == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.CriticalCustomer != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.CriticalCustomer) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.CriticalCustomer) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.CriticalCustomer) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.CriticalCustomer) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.CriticalCustomer == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.CriticalCustomer != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.CriticalCustomer.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


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


                        //case "BusinessType":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.BusinessType == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.BusinessType != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.BusinessType) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.BusinessType) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.BusinessType) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.BusinessType) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.BusinessType == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.BusinessType != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.BusinessType.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


                        //case "ConnectionStatus":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.ConnectionStatus == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.ConnectionStatus != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.ConnectionStatus) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.ConnectionStatus) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.ConnectionStatus) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.ConnectionStatus) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.ConnectionStatus == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.ConnectionStatus != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.ConnectionStatus.Contains(searchOption.FieldValue);
                        //            break;
                        //    }
                        //    break;


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


                        case "Location":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.LocationId == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.LocationId != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model =>
                                        model.LocationId > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        model.LocationId < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.LocationId >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.LocationId <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.LocationId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.LocationId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.LocationId.ToString().Contains(searchOption.FieldValue);
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


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(t => t.ConsumerDataToDistributionTransformer)
                .Include(t => t.ConsumerDataToServicePoint)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchConsumerData", searchResult);

        }

    }



}
