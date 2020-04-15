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
using Pdb014App.Models.PDB.PhasePowerTransformerModel;
using Remotion.Linq.Utilities;


namespace Pdb014App.Controllers.AdvancedSearching
{

    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchPowerTransformer(int modelId = 1, int pageIndex = 1, string sort = "PhasePowerTransformerId", string sortExp = "PhasePowerTransformerId")
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
                new SelectListItem {Value = "PowerTransformerId", Text = "Power Transformer Id"},
                new SelectListItem {Value = "ManufacturersName", Text = "Manufacturers Name"},
                new SelectListItem {Value = "ManufacturersAddress", Text = "Manufacturers Address"},
                new SelectListItem {Value = "AppliedStandard", Text = "Applied Standard"},
                new SelectListItem {Value = "DescriptionType", Text = "Description Type"},
                new SelectListItem {Value = "SerialNumber", Text = "Serial Number"},
                new SelectListItem {Value = "RatedPower", Text = "Rated Power"},
                new SelectListItem {Value = "NumberofPhase", Text = "Number of Phase"}
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


            var qry = _context.TblPhasePowerTransformer.AsNoTracking()
                .Include(t => t.PhasePowerTransformerTo33KvFeederLine)
                .Include(t => t.PhasePowerTransformerToSourceSubstation)
                .Include(t => t.PhasePowerTransformerToTblSubstation)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchPowerTransformer", searchResult);


        }


        [HttpPost]
        public async Task<IActionResult> SearchPowerTransformer(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "PhasePowerTransformerId", string sortExp = "PhasePowerTransformerId")
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
                new SelectListItem {Value = "PowerTransformerId", Text = "Power Transformer Id"},
                new SelectListItem {Value = "ManufacturersName", Text = "Manufacturers Name"},
                new SelectListItem {Value = "ManufacturersAddress", Text = "Manufacturers Address"},
                new SelectListItem {Value = "AppliedStandard", Text = "Applied Standard"},
                new SelectListItem {Value = "DescriptionType", Text = "Description Type"},
                new SelectListItem {Value = "SerialNumber", Text = "Serial Number"},
                new SelectListItem {Value = "RatedPower", Text = "Rated Power"},
                new SelectListItem {Value = "NumberofPhase", Text = "Number of Phase"}
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


            var qry = _context.TblPhasePowerTransformer.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblPhasePowerTransformer, Boolean>> searchExp = null;

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

                    Expression<Func<TblPhasePowerTransformer, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {

                        case "PowerTransformerId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhasePowerTransformerId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhasePowerTransformerId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PhasePowerTransformerId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PhasePowerTransformerId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PhasePowerTransformerId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PhasePowerTransformerId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhasePowerTransformerId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhasePowerTransformerId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhasePowerTransformerId.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;




                        case "ManufacturersName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufacturersName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufacturersName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufacturersName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufacturersName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufacturersName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "ManufacturersAddress":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ManufacturersAddress == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ManufacturersAddress != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersAddress) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersAddress) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersAddress) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ManufacturersAddress) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ManufacturersAddress == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ManufacturersAddress != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ManufacturersAddress.Contains(searchOption.FieldValue);
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
                                    tempExp = model =>
                                        int.Parse(model.AppliedStandard) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.AppliedStandard) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.AppliedStandard) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.AppliedStandard) <= int.Parse(searchOption.FieldValue);
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



                        case "DescriptionType":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.DescriptionType == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.DescriptionType != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.DescriptionType) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.DescriptionType) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.DescriptionType) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.DescriptionType) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.DescriptionType == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.DescriptionType != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.DescriptionType.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "SerialNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SerialNumber == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SerialNumber != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SerialNumber) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SerialNumber) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SerialNumber) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SerialNumber) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SerialNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SerialNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SerialNumber.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "RatedPower":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.RatedPower == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.RatedPower != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.RatedPower) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.RatedPower) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.RatedPower) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.RatedPower) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.RatedPower == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.RatedPower != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.RatedPower.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NumberofPhase":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NumberOfPhase == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.NumberOfPhase != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.NumberOfPhase > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.NumberOfPhase < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.NumberOfPhase >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.NumberOfPhase <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => false;//model.NumberOfPhase == null;
                                    break;
                                case "not null":
                                    tempExp = model => true;//model.NumberOfPhase != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NumberOfPhase.ToString().Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblPhasePowerTransformer>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblPhasePowerTransformer>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(t => t.PhasePowerTransformerTo33KvFeederLine)
                .Include(t => t.PhasePowerTransformerToSourceSubstation)
                .Include(t => t.PhasePowerTransformerToTblSubstation)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchPowerTransformer", searchResult);

        }

    }



}
