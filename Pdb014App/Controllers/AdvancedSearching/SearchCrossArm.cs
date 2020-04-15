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
using Pdb014App.Models.PDB.PoleModels;


namespace Pdb014App.Controllers.AdvancedSearching
{

    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchCrossArm(int modelId = 1, int pageIndex = 1, string sort = "CrossArmId", string sortExp = "CrossArmId")
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
                new SelectListItem {Value = "Materials", Text = "Materials"},
                new SelectListItem {Value = "Type", Text = "Type"},
                new SelectListItem {Value = "Standard", Text = "Standard"},
                new SelectListItem {Value = "UltimateTensileStrength", Text = "Ultimate Tensile Strength"},
                new SelectListItem {Value = "TypeOfFittings", Text = "Type of Fittings"},
                new SelectListItem {Value = "NoOfSetFittings", Text = "No of Set Fittings"},
                new SelectListItem {Value = "FittingsCondition", Text = "Fittings Condition"},
                new SelectListItem {Value = "PoleName", Text = "Pole"}
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

            var qry = _context.TblCrossArmInfo.AsNoTracking()
                .Include(t => t.CrossArmToPole)
                .Include(t => t.FittingsLookUpCondition)
                .Include(t => t.LookUpTypeOfFittings)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchCrossArm", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchCrossArm(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "CrossArmId", string sortExp = "CrossArmId")
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
                new SelectListItem {Value = "Materials", Text = "Materials"},
                new SelectListItem {Value = "Type", Text = "Type"},
                new SelectListItem {Value = "Standard", Text = "Standard"},
                new SelectListItem {Value = "UltimateTensileStrength", Text = "Ultimate Tensile Strength"},
                new SelectListItem {Value = "TypeOfFittings", Text = "Type of Fittings"},
                new SelectListItem {Value = "NoOfSetFittings", Text = "No of Set Fittings"},
                new SelectListItem {Value = "FittingsCondition", Text = "Fittings Condition"},
                new SelectListItem {Value = "PoleName", Text = "Pole"}
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


            var qry = _context.TblCrossArmInfo.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblCrossArmInfo, Boolean>> searchExp = null;

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

                    Expression<Func<TblCrossArmInfo, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "Materials":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Materials == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Materials != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Materials) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Materials) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Materials) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Materials) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Materials == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Materials != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Materials.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "Type":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Type == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Type != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Type) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Type) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Type) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Type) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Type == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Type != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Type.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "Standard":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Standard == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Standard != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Standard) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Standard) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Standard) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Standard) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Standard == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Standard != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Standard.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "UltimateTensileStrength":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.UltimateTensileStrength == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.UltimateTensileStrength != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.UltimateTensileStrength) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.UltimateTensileStrength) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.UltimateTensileStrength) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.UltimateTensileStrength) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.UltimateTensileStrength == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.UltimateTensileStrength != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.UltimateTensileStrength.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TypeOfFittings":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.LookUpTypeOfFittings.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.LookUpTypeOfFittings.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.LookUpTypeOfFittings.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.LookUpTypeOfFittings.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.LookUpTypeOfFittings.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.LookUpTypeOfFittings.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.LookUpTypeOfFittings.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.LookUpTypeOfFittings.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.LookUpTypeOfFittings.Name.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NoOfSetFittings":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NoOfSetFittings == int.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.NoOfSetFittings != int.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model =>
                                        model.NoOfSetFittings > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        model.NoOfSetFittings < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.NoOfSetFittings >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.NoOfSetFittings <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NoOfSetFittings == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NoOfSetFittings != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NoOfSetFittings.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "FittingsCondition":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FittingsLookUpCondition.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FittingsLookUpCondition.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FittingsLookUpCondition.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FittingsLookUpCondition.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FittingsLookUpCondition.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FittingsLookUpCondition.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FittingsLookUpCondition.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FittingsLookUpCondition.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FittingsLookUpCondition.Name.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "PoleName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.CrossArmToPole.PoleId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.CrossArmToPole.PoleId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.CrossArmToPole.PoleId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.CrossArmToPole.PoleId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.CrossArmToPole.PoleId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.CrossArmToPole.PoleId.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblCrossArmInfo>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblCrossArmInfo>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }


            qry = qry
                .Include(t => t.CrossArmToPole)
                .Include(t => t.FittingsLookUpCondition)
                .Include(t => t.LookUpTypeOfFittings)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            return View("SearchCrossArm", searchResult);

        }

    }



}
