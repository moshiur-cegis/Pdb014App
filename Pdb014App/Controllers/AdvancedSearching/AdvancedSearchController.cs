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

using Pdb014App.Repository;
using Pdb014App.Models.Search;
using Pdb014App.Models.PDB;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Models.PDB.DistributionTransformerModel;
using Pdb014App.Models.PDB.ServicePointModels;


namespace Pdb014App.Controllers.AdvancedSearching
{
    public partial class AdvancedSearchingController : Controller
    {

        private readonly PdbDbContext _context;

        public AdvancedSearchingController(PdbDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> AdvSearch(int modelId = 1, int pageIndex = 1, string sort = "PoleId")
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

            //ViewData["SearchParameters"] = null;
            //ViewBag.SearchParameters = null;

            var fieldsDB = _context
                .LookUpModelFieldInfo
                .Where(mf => mf.ModelId == modelId)
                .Select(fi => new { Value = fi.FieldName, Text = fi.FieldDisplayName })
                .ToList();




            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "SurveyDate", Text = "Survey Date"},
                new SelectListItem {Value = "RouteName", Text = "Route Name"},
                new SelectListItem {Value = "PoleNo", Text = "Pole No"},
                new SelectListItem {Value = "PreviousPoleNo", Text = "Previous Pole No"},
                new SelectListItem {Value = "PoleTypeName", Text = "Pole Type"},
                new SelectListItem {Value = "PoleCondition", Text = "Pole Condition"},
                new SelectListItem {Value = "MSJNo", Text = "MSJ No"},
                new SelectListItem {Value = "SleeveNo", Text = "Sleeve No"},
                new SelectListItem {Value = "TwistNo", Text = "Twist No"},
                new SelectListItem {Value = "PhaseA", Text = "Phase A"},
                new SelectListItem {Value = "PhaseB", Text = "Phase B"},
                new SelectListItem {Value = "PhaseC", Text = "Phase C"},
                new SelectListItem {Value = "Neutral", Text = "Neutral"},
                new SelectListItem {Value = "StreetLight", Text = "Street Light"},
                new SelectListItem {Value = "SourceCable", Text = "Source Cable"},
                new SelectListItem {Value = "TargetCable", Text = "Target Cable"},
                new SelectListItem {Value = "Latitude", Text = "Latitude"},
                new SelectListItem {Value = "Longitude", Text = "Longitude"}
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



            var qry = _context.TblPole.AsNoTracking()
                .Include(pi => pi.PoleToFeederLine)
                .Include(pi => pi.PoleToRoute)
                .Include(pi => pi.PoleType)
                .Include(pi => pi.PoleCondition)
                //.Include(pi => pi.PoleToSourceFeederLine)
                //.Include(pi => pi.PoleToTargetFeederLine)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

            return View("AdvSearch", searchResult);




            //var tupleModel = new Tuple<PagingList<TblPole>, IList<SearchParameter>>(searchResult, new List<SearchParameter>(3));
            ////var tupleModel = new Tuple<IList<TblPole>, IList<SearchParameter>>(qry.ToList(), searchParameters);

            //return View("AdvSearch", tupleModel);


            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

        }

        [HttpPost]
        //public async Task<IActionResult> AdvSearch(SearchParameter srchParameter, int modelId = 1, int pageIndex = 1, string sort = "PoleId") 
        public async Task<IActionResult> AdvSearch(List<string> srchParameter, int modelId = 1, int pageIndex = 1, string sort = "PoleId")
        {
            //if (searchParameters == null)
            //{
            //    searchParameters = TempData["SearchParameters"] as List<List<string>>;
            //}
            //else
            //{
            //    TempData["SearchParameters"] = searchParameters;
            //}



            var searchParameters = new List<SearchParameter>(1);


            searchParameters[0] =
                srchParameter != null && srchParameter.Count > 3
                    ? new SearchParameter
                    {
                        FieldName = srchParameter[0],
                        Operator = srchParameter[1],
                        FieldValue = srchParameter[2],
                        JoinOption = srchParameter[3]
                    }
                    : new SearchParameter();


            //ViewData["SearchParameters"] = searchParameters;
            ViewBag.SearchParameters = searchParameters;

            var fieldsDB = _context
                .LookUpModelFieldInfo
                .Where(mf => mf.ModelId == modelId)
                .Select(fi => new { Value = fi.FieldName, Text = fi.FieldDisplayName })
                .ToList();



            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "SurveyDate", Text = "Survey Date"},
                new SelectListItem {Value = "RouteName", Text = "Route Name"},
                new SelectListItem {Value = "PoleNo", Text = "Pole No"},
                new SelectListItem {Value = "PreviousPoleNo", Text = "Previous Pole No"},
                new SelectListItem {Value = "PoleTypeName", Text = "Pole Type"},
                new SelectListItem {Value = "PoleCondition", Text = "Pole Condition"},
                new SelectListItem {Value = "MSJNo", Text = "MSJ No"},
                new SelectListItem {Value = "SleeveNo", Text = "Sleeve No"},
                new SelectListItem {Value = "TwistNo", Text = "Twist No"},
                new SelectListItem {Value = "PhaseA", Text = "Phase A"},
                new SelectListItem {Value = "PhaseB", Text = "Phase B"},
                new SelectListItem {Value = "PhaseC", Text = "Phase C"},
                new SelectListItem {Value = "Neutral", Text = "Neutral"},
                new SelectListItem {Value = "StreetLight", Text = "Street Light"},
                new SelectListItem {Value = "SourceCable", Text = "Source Cable"},
                new SelectListItem {Value = "TargetCable", Text = "Target Cable"},
                new SelectListItem {Value = "Latitude", Text = "Latitude"},
                new SelectListItem {Value = "Longitude", Text = "Longitude"}
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



            var qry = _context.TblPole.AsNoTracking();

            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblPole, Boolean>> searchExp = null;

                //var searchOptions = searchParameters
                //    .Select(so => new SearchParameter
                //    {
                //        FieldName = so[0],
                //        Operator = so[1],
                //        FieldValue = so[2],
                //        JoinOption = so[3]
                //    }).ToList();

                var searchOptions = searchParameters;


                string joinOption = "";
                foreach (var searchOption in searchOptions)
                {
                    if (string.IsNullOrEmpty(searchOption.FieldName) || string.IsNullOrEmpty(searchOption.Operator))
                        continue;

                    Expression<Func<TblPole, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "PoleId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PoleId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PoleId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PoleId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PoleId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "FeederLineId":
                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.PoleToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SurveyDate":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SurveyDate == DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.SurveyDate != DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.SurveyDate > DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.SurveyDate < DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.SurveyDate >= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.SurveyDate <= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SurveyDate == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SurveyDate != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SurveyDate.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "RouteName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleToRoute.RouteName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleToRoute.RouteName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleToRoute.RouteName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleToRoute.RouteName != null;
                                    break;
                            }

                            break;

                        case "PoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PreviousPoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PreviousPoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PreviousPoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PreviousPoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PreviousPoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PreviousPoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PoleTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleType.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleType.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleType.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleType.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleType.Name.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PoleCondition":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleConditionId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleConditionId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleConditionId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleConditionId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleConditionId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "MSJNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MSJNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MSJNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.MSJNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.MSJNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.MSJNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.MSJNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MSJNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MSJNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MSJNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SleeveNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SleeveNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SleeveNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SleeveNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SleeveNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SleeveNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SleeveNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SleeveNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SleeveNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SleeveNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "TwistNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TwistNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TwistNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.TwistNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.TwistNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.TwistNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.TwistNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TwistNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TwistNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TwistNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseA":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseAId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseAId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseAId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseAId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseAId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseAId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseAId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseAId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseAId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseB":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseBId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseBId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseBId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseBId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseBId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseBId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseBId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseBId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseBId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseC":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseCId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseCId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseCId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseCId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseCId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseCId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseCId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseCId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseCId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Neutral":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Neutral == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Neutral != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.Neutral) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.Neutral) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.Neutral) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.Neutral) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Neutral == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Neutral != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Neutral.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "StreetLight":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.StreetLight == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.StreetLight != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.StreetLight == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.StreetLight != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.StreetLight.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        //case "SourceCable":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.SourceCableId == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.SourceCableId != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.SourceCableId == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.SourceCableId != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.SourceCableId.Contains(searchOption.FieldValue);
                        //            break;
                        //    }

                        //    break;

                        //case "TargetCable":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.TargetCableId == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.TargetCableId != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.TargetCableId == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.TargetCableId != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.TargetCableId.Contains(searchOption.FieldValue);
                        //            break;
                        //    }

                        //    break;

                        case "Latitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Latitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Latitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Latitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Latitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Latitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Latitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Latitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Latitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Latitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Longitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Longitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Longitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Longitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Longitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Longitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Longitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Longitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Longitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Longitude.ToString().Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblPole>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(pi => pi.PoleToFeederLine)
                .Include(pi => pi.PoleToRoute)
                .Include(pi => pi.PoleType)
                .Include(pi => pi.PoleCondition)
                //.Include(pi => pi.PoleToSourceFeederLine)
                //.Include(pi => pi.PoleToTargetFeederLine)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

            return View("AdvSearch", searchResult);


            //ViewModel mymodel = new ViewModel();
            //mymodel.Teachers = GetTeachers();
            //mymodel.Students = GetStudents();
            //return View(mymodel);


            //var tupleModel = new Tuple<PagingList<TblPole>, IList<SearchParameter>>(searchResult, searchParameters);
            ////var tupleModel = new Tuple<IList<TblPole>, IList<SearchParameter>>(qry.ToList(), searchParameters);

            //return View("AdvSearch", tupleModel);

            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            //ViewData["FieldName"] = new SelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");
            //ViewBag.FieldNameList = new MultiSelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");


            //var qry = _context.TblPole.AsNoTracking()
            //    .Include(pi => pi.PoleToFeederLine)
            //    .Include(pi => pi.PoleToRoute)
            //    .Include(pi => pi.PoleType)
            //    .Include(pi => pi.PoleCondition)
            //    .Include(pi => pi.PoleToSourceFeederLine)
            //    .Include(pi => pi.PoleToTargetFeederLine)
            //    .AsQueryable();

            ////qry = qry.Where(result);

            //var finalResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            ////ViewData["FieldName"] = new SelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");
            ////ViewBag.FieldNameList = new MultiSelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");

            //return View(finalResult);
        }



    }


    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> AdvancedSearch(int modelId = 1, int pageIndex = 1, string sort = "PoleId")
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

            //ViewData["SearchParameters"] = null;
            //ViewBag.SearchParameters = null;

            var fieldsDB = _context
                .LookUpModelFieldInfo
                .Where(mf => mf.ModelId == modelId)
                .Select(fi => new { Value = fi.FieldName, Text = fi.FieldDisplayName })
                .ToList();




            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "SurveyDate", Text = "Survey Date"},
                new SelectListItem {Value = "RouteName", Text = "Route Name"},
                new SelectListItem {Value = "PoleNo", Text = "Pole No"},
                new SelectListItem {Value = "PreviousPoleNo", Text = "Previous Pole No"},
                new SelectListItem {Value = "PoleTypeName", Text = "Pole Type"},
                new SelectListItem {Value = "PoleCondition", Text = "Pole Condition"},
                new SelectListItem {Value = "MSJNo", Text = "MSJ No"},
                new SelectListItem {Value = "SleeveNo", Text = "Sleeve No"},
                new SelectListItem {Value = "TwistNo", Text = "Twist No"},
                new SelectListItem {Value = "PhaseA", Text = "Phase A"},
                new SelectListItem {Value = "PhaseB", Text = "Phase B"},
                new SelectListItem {Value = "PhaseC", Text = "Phase C"},
                new SelectListItem {Value = "Neutral", Text = "Neutral"},
                new SelectListItem {Value = "StreetLight", Text = "Street Light"},
                new SelectListItem {Value = "SourceCable", Text = "Source Cable"},
                new SelectListItem {Value = "TargetCable", Text = "Target Cable"},
                new SelectListItem {Value = "Latitude", Text = "Latitude"},
                new SelectListItem {Value = "Longitude", Text = "Longitude"}
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



            var qry = _context.TblPole.AsNoTracking()
                .Include(pi => pi.PoleToFeederLine)
                .Include(pi => pi.PoleToRoute)
                .Include(pi => pi.PoleType)
                .Include(pi => pi.PoleCondition)
                //.Include(pi => pi.PoleToSourceFeederLine)
                //.Include(pi => pi.PoleToTargetFeederLine)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

            return View("AdvancedSearch", searchResult);




            //var tupleModel = new Tuple<PagingList<TblPole>, IList<SearchParameter>>(searchResult, new List<SearchParameter>(3));
            ////var tupleModel = new Tuple<IList<TblPole>, IList<SearchParameter>>(qry.ToList(), searchParameters);

            //return View("AdvancedSearch", tupleModel);


            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

        }


        [HttpPost]
        public async Task<IActionResult> AdvancedSearch(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "PoleId")
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
                new SelectListItem {Value = "PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "SurveyDate", Text = "Survey Date"},
                new SelectListItem {Value = "RouteName", Text = "Route Name"},
                new SelectListItem {Value = "PoleNo", Text = "Pole No"},
                new SelectListItem {Value = "PreviousPoleNo", Text = "Previous Pole No"},
                new SelectListItem {Value = "PoleTypeName", Text = "Pole Type"},
                new SelectListItem {Value = "PoleCondition", Text = "Pole Condition"},
                new SelectListItem {Value = "MSJNo", Text = "MSJ No"},
                new SelectListItem {Value = "SleeveNo", Text = "Sleeve No"},
                new SelectListItem {Value = "TwistNo", Text = "Twist No"},
                new SelectListItem {Value = "PhaseA", Text = "Phase A"},
                new SelectListItem {Value = "PhaseB", Text = "Phase B"},
                new SelectListItem {Value = "PhaseC", Text = "Phase C"},
                new SelectListItem {Value = "Neutral", Text = "Neutral"},
                new SelectListItem {Value = "StreetLight", Text = "Street Light"},
                new SelectListItem {Value = "SourceCable", Text = "Source Cable"},
                new SelectListItem {Value = "TargetCable", Text = "Target Cable"},
                new SelectListItem {Value = "Latitude", Text = "Latitude"},
                new SelectListItem {Value = "Longitude", Text = "Longitude"}
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



            var qry = _context.TblPole.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblPole, Boolean>> searchExp = null;

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

                    Expression<Func<TblPole, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "PoleId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PoleId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PoleId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PoleId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PoleId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "FeederLineId":
                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.PoleToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SurveyDate":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SurveyDate == DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.SurveyDate != DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.SurveyDate > DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.SurveyDate < DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.SurveyDate >= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.SurveyDate <= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SurveyDate == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SurveyDate != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SurveyDate.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "RouteName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleToRoute.RouteName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleToRoute.RouteName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleToRoute.RouteName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleToRoute.RouteName != null;
                                    break;
                            }

                            break;

                        case "PoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PreviousPoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PreviousPoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PreviousPoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PreviousPoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PreviousPoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PreviousPoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PoleTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleType.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleType.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleType.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleType.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleType.Name.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PoleCondition":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleConditionId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleConditionId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleConditionId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleConditionId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleConditionId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "MSJNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MSJNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MSJNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.MSJNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.MSJNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.MSJNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.MSJNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MSJNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MSJNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MSJNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SleeveNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SleeveNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SleeveNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SleeveNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SleeveNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SleeveNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SleeveNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SleeveNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SleeveNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SleeveNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "TwistNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TwistNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TwistNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.TwistNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.TwistNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.TwistNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.TwistNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TwistNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TwistNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TwistNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseA":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseAId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseAId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseAId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseAId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseAId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseAId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseAId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseAId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseAId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseB":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseBId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseBId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseBId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseBId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseBId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseBId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseBId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseBId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseBId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseC":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseCId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseCId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseCId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseCId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseCId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseCId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseCId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseCId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseCId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Neutral":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Neutral == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Neutral != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.Neutral) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.Neutral) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.Neutral) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.Neutral) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Neutral == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Neutral != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Neutral.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "StreetLight":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.StreetLight == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.StreetLight != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.StreetLight == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.StreetLight != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.StreetLight.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        //case "SourceCable":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.SourceCableId == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.SourceCableId != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.SourceCableId == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.SourceCableId != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.SourceCableId.Contains(searchOption.FieldValue);
                        //            break;
                        //    }

                        //    break;

                        //case "TargetCable":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.TargetCableId == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.TargetCableId != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.TargetCableId == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.TargetCableId != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.TargetCableId.Contains(searchOption.FieldValue);
                        //            break;
                        //    }

                        //    break;


                        case "Latitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Latitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Latitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Latitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Latitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Latitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Latitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Latitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Latitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Latitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Longitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Longitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Longitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Longitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Longitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Longitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Longitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Longitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Longitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Longitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                            //case "Latitude":
                            //    switch (searchOption.Operator)
                            //    {
                            //        case "=":
                            //            tempExp = model => model.Latitude == searchOption.FieldValue;
                            //            break;
                            //        case "!=":
                            //            tempExp = model => model.Latitude != searchOption.FieldValue;
                            //            break;
                            //        case ">":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Latitude) > decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Latitude) < decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case ">=":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Latitude) >= decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<=":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Latitude) <= decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "null":
                            //            tempExp = model => model.Latitude == null;
                            //            break;
                            //        case "not null":
                            //            tempExp = model => model.Latitude != null;
                            //            break;
                            //        case "Like":
                            //            tempExp = model => model.Latitude.Contains(searchOption.FieldValue);
                            //            break;
                            //    }

                            //    break;

                            //case "Longitude":
                            //    switch (searchOption.Operator)
                            //    {
                            //        case "=":
                            //            tempExp = model => model.Longitude == searchOption.FieldValue;
                            //            break;
                            //        case "!=":
                            //            tempExp = model => model.Longitude != searchOption.FieldValue;
                            //            break;
                            //        case ">":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Longitude) > decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Longitude) < decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case ">=":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Longitude) >= decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<=":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Longitude) <= decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "null":
                            //            tempExp = model => model.Longitude == null;
                            //            break;
                            //        case "not null":
                            //            tempExp = model => model.Longitude != null;
                            //            break;
                            //        case "Like":
                            //            tempExp = model => model.Longitude.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblPole>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(pi => pi.PoleToFeederLine)
                .Include(pi => pi.PoleToRoute)
                .Include(pi => pi.PoleType)
                .Include(pi => pi.PoleCondition)
                //.Include(pi => pi.PoleToSourceFeederLine)
                //.Include(pi => pi.PoleToTargetFeederLine)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

            return View("AdvancedSearch", searchResult);


            //ViewModel mymodel = new ViewModel();
            //mymodel.Teachers = GetTeachers();
            //mymodel.Students = GetStudents();
            //return View(mymodel);


            //var tupleModel = new Tuple<PagingList<TblPole>, IList<SearchParameter>>(searchResult, searchParameters);
            ////var tupleModel = new Tuple<IList<TblPole>, IList<SearchParameter>>(qry.ToList(), searchParameters);

            //return View("AdvancedSearch", tupleModel);

            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            //ViewData["FieldName"] = new SelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");
            //ViewBag.FieldNameList = new MultiSelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");


            //var qry = _context.TblPole.AsNoTracking()
            //    .Include(pi => pi.PoleToFeederLine)
            //    .Include(pi => pi.PoleToRoute)
            //    .Include(pi => pi.PoleType)
            //    .Include(pi => pi.PoleCondition)
            //    .Include(pi => pi.PoleToSourceFeederLine)
            //    .Include(pi => pi.PoleToTargetFeederLine)
            //    .AsQueryable();

            ////qry = qry.Where(result);

            //var finalResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            ////ViewData["FieldName"] = new SelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");
            ////ViewBag.FieldNameList = new MultiSelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");

            //return View(finalResult);
        }


        //public async Task<IActionResult> AdvancedSearch(string[][] searchParameters, string searchOptions, int modelId = 1, int pageIndex = 1, string sort = "PoleId") 


        public async Task<IActionResult> SearchPole(int modelId = 1, int pageIndex = 1, string sort = "PoleId")
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

            //ViewData["SearchParameters"] = null;
            //ViewBag.SearchParameters = null;

            var fieldsDB = _context
                .LookUpModelFieldInfo
                .Where(mf => mf.ModelId == modelId)
                .Select(fi => new { Value = fi.FieldName, Text = fi.FieldDisplayName })
                .ToList();


            var fields = new List<SelectListItem>
            {
                new SelectListItem {Value = "PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "SurveyDate", Text = "Survey Date"},
                new SelectListItem {Value = "RouteName", Text = "Route Name"},
                new SelectListItem {Value = "PoleNo", Text = "Pole No"},
                new SelectListItem {Value = "PreviousPoleNo", Text = "Previous Pole No"},
                new SelectListItem {Value = "PoleTypeName", Text = "Pole Type"},
                new SelectListItem {Value = "PoleCondition", Text = "Pole Condition"},
                new SelectListItem {Value = "MSJNo", Text = "MSJ No"},
                new SelectListItem {Value = "SleeveNo", Text = "Sleeve No"},
                new SelectListItem {Value = "TwistNo", Text = "Twist No"},
                new SelectListItem {Value = "PhaseA", Text = "Phase A"},
                new SelectListItem {Value = "PhaseB", Text = "Phase B"},
                new SelectListItem {Value = "PhaseC", Text = "Phase C"},
                new SelectListItem {Value = "Neutral", Text = "Neutral"},
                new SelectListItem {Value = "StreetLight", Text = "Street Light"},
                new SelectListItem {Value = "SourceCable", Text = "Source Cable"},
                new SelectListItem {Value = "TargetCable", Text = "Target Cable"},
                new SelectListItem {Value = "Latitude", Text = "Latitude"},
                new SelectListItem {Value = "Longitude", Text = "Longitude"}
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



            var qry = _context.TblPole.AsNoTracking()
                .Include(pi => pi.PoleToFeederLine)
                .Include(pi => pi.PoleToRoute)
                .Include(pi => pi.PoleType)
                .Include(pi => pi.PoleCondition)
                //.Include(pi => pi.PoleToSourceFeederLine)
                //.Include(pi => pi.PoleToTargetFeederLine)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

            return View("SearchPole", searchResult);




            //var tupleModel = new Tuple<PagingList<TblPole>, IList<SearchParameter>>(searchResult, new List<SearchParameter>(3));
            ////var tupleModel = new Tuple<IList<TblPole>, IList<SearchParameter>>(qry.ToList(), searchParameters);

            //return View("SearchPole", tupleModel);


            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

        }


        [HttpPost]
        public async Task<IActionResult> SearchPole(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "PoleId")
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
                new SelectListItem {Value = "PoleId", Text = "Pole Id"},
                new SelectListItem {Value = "FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "SurveyDate", Text = "Survey Date"},
                new SelectListItem {Value = "RouteName", Text = "Route Name"},
                new SelectListItem {Value = "PoleNo", Text = "Pole No"},
                new SelectListItem {Value = "PreviousPoleNo", Text = "Previous Pole No"},
                new SelectListItem {Value = "PoleTypeName", Text = "Pole Type"},
                new SelectListItem {Value = "PoleCondition", Text = "Pole Condition"},
                new SelectListItem {Value = "MSJNo", Text = "MSJ No"},
                new SelectListItem {Value = "SleeveNo", Text = "Sleeve No"},
                new SelectListItem {Value = "TwistNo", Text = "Twist No"},
                new SelectListItem {Value = "PhaseA", Text = "Phase A"},
                new SelectListItem {Value = "PhaseB", Text = "Phase B"},
                new SelectListItem {Value = "PhaseC", Text = "Phase C"},
                new SelectListItem {Value = "Neutral", Text = "Neutral"},
                new SelectListItem {Value = "StreetLight", Text = "Street Light"},
                new SelectListItem {Value = "SourceCable", Text = "Source Cable"},
                new SelectListItem {Value = "TargetCable", Text = "Target Cable"},
                new SelectListItem {Value = "Latitude", Text = "Latitude"},
                new SelectListItem {Value = "Longitude", Text = "Longitude"}
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


            var qry = _context.TblPole.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblPole, Boolean>> searchExp = null;

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

                    Expression<Func<TblPole, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "PoleId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PoleId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PoleId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PoleId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PoleId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "FeederLineId":
                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleToFeederLine.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleToFeederLine.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToFeederLine.FeederName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleToFeederLine.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.PoleToFeederLine.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SurveyDate":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SurveyDate == DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.SurveyDate != DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.SurveyDate > DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.SurveyDate < DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.SurveyDate >= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.SurveyDate <= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SurveyDate == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SurveyDate != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SurveyDate.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            //switch (searchOption.Operator)
                            //{
                            //    case "=":
                            //        tempExp = model => model.SurveyDate == searchOption.FieldValue;
                            //        break;
                            //    case "!=":
                            //        tempExp = model => model.SurveyDate != searchOption.FieldValue;
                            //        break;
                            //    case ">":
                            //        tempExp = model =>
                            //            DateTime.Parse(model.SurveyDate) > DateTime.Parse(searchOption.FieldValue);
                            //        break;
                            //    case "<":
                            //        tempExp = model =>
                            //            DateTime.Parse(model.SurveyDate) < DateTime.Parse(searchOption.FieldValue);
                            //        break;
                            //    case ">=":
                            //        tempExp = model =>
                            //            DateTime.Parse(model.SurveyDate) >= DateTime.Parse(searchOption.FieldValue);
                            //        break;
                            //    case "<=":
                            //        tempExp = model =>
                            //            DateTime.Parse(model.SurveyDate) <= DateTime.Parse(searchOption.FieldValue);
                            //        break;
                            //    case "null":
                            //        tempExp = model => model.SurveyDate == null;
                            //        break;
                            //    case "not null":
                            //        tempExp = model => model.SurveyDate != null;
                            //        break;
                            //    case "Like":
                            //        tempExp = model => model.SurveyDate.Contains(searchOption.FieldValue);
                            //        break;
                            //}

                            break;

                        case "RouteName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleToRoute.RouteName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleToRoute.RouteName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleToRoute.RouteName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleToRoute.RouteName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleToRoute.RouteName != null;
                                    break;
                            }

                            break;

                        case "PoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PreviousPoleNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PreviousPoleNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PreviousPoleNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PreviousPoleNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PreviousPoleNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PreviousPoleNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PreviousPoleNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PoleTypeName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleType.Name == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleType.Name != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleType.Name) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleType.Name == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleType.Name != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleType.Name.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PoleCondition":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PoleConditionId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PoleConditionId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PoleConditionId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PoleConditionId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PoleConditionId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PoleConditionId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "MSJNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MSJNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.MSJNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.MSJNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.MSJNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.MSJNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.MSJNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MSJNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MSJNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MSJNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SleeveNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SleeveNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SleeveNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SleeveNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SleeveNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SleeveNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SleeveNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SleeveNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SleeveNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SleeveNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "TwistNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TwistNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TwistNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.TwistNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.TwistNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.TwistNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.TwistNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TwistNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TwistNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TwistNo.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseA":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseAId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseAId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseAId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseAId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseAId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseAId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseAId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseAId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseAId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseB":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseBId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseBId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseBId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseBId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseBId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseBId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseBId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseBId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseBId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PhaseC":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PhaseCId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PhaseCId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.PhaseCId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.PhaseCId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.PhaseCId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.PhaseCId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PhaseCId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PhaseCId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PhaseCId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Neutral":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Neutral == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Neutral != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.Neutral) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.Neutral) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.Neutral) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.Neutral) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Neutral == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Neutral != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Neutral.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "StreetLight":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.StreetLight == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.StreetLight != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.StreetLight) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.StreetLight == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.StreetLight != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.StreetLight.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        //case "SourceCable":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.SourceCableId == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.SourceCableId != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.SourceCableId) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.SourceCableId == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.SourceCableId != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.SourceCableId.Contains(searchOption.FieldValue);
                        //            break;
                        //    }

                        //    break;

                        //case "TargetCable":
                        //    switch (searchOption.Operator)
                        //    {
                        //        case "=":
                        //            tempExp = model => model.TargetCableId == searchOption.FieldValue;
                        //            break;
                        //        case "!=":
                        //            tempExp = model => model.TargetCableId != searchOption.FieldValue;
                        //            break;
                        //        case ">":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) > int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) < int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case ">=":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) >= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "<=":
                        //            tempExp = model =>
                        //                int.Parse(model.TargetCableId) <= int.Parse(searchOption.FieldValue);
                        //            break;
                        //        case "null":
                        //            tempExp = model => model.TargetCableId == null;
                        //            break;
                        //        case "not null":
                        //            tempExp = model => model.TargetCableId != null;
                        //            break;
                        //        case "Like":
                        //            tempExp = model => model.TargetCableId.Contains(searchOption.FieldValue);
                        //            break;
                        //    }

                        //    break;


                        case "Latitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Latitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Latitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Latitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Latitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Latitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Latitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Latitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Latitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Latitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Longitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Longitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Longitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Longitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Longitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Longitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Longitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Longitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Longitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Longitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;
                            //case "Latitude":
                            //    switch (searchOption.Operator)
                            //    {
                            //        case "=":
                            //            tempExp = model => model.Latitude == searchOption.FieldValue;
                            //            break;
                            //        case "!=":
                            //            tempExp = model => model.Latitude != searchOption.FieldValue;
                            //            break;
                            //        case ">":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Latitude) > decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Latitude) < decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case ">=":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Latitude) >= decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<=":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Latitude) <= decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "null":
                            //            tempExp = model => model.Latitude == null;
                            //            break;
                            //        case "not null":
                            //            tempExp = model => model.Latitude != null;
                            //            break;
                            //        case "Like":
                            //            tempExp = model => model.Latitude.Contains(searchOption.FieldValue);
                            //            break;
                            //    }

                            //    break;

                            //case "Longitude":
                            //    switch (searchOption.Operator)
                            //    {
                            //        case "=":
                            //            tempExp = model => model.Longitude == searchOption.FieldValue;
                            //            break;
                            //        case "!=":
                            //            tempExp = model => model.Longitude != searchOption.FieldValue;
                            //            break;
                            //        case ">":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Longitude) > decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Longitude) < decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case ">=":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Longitude) >= decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "<=":
                            //            tempExp = model =>
                            //                decimal.Parse(model.Longitude) <= decimal.Parse(searchOption.FieldValue);
                            //            break;
                            //        case "null":
                            //            tempExp = model => model.Longitude == null;
                            //            break;
                            //        case "not null":
                            //            tempExp = model => model.Longitude != null;
                            //            break;
                            //        case "Like":
                            //            tempExp = model => model.Longitude.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblPole>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(pi => pi.PoleToFeederLine)
                .Include(pi => pi.PoleToRoute)
                .Include(pi => pi.PoleType)
                .Include(pi => pi.PoleCondition)
                //.Include(pi => pi.PoleToSourceFeederLine)
                //.Include(pi => pi.PoleToTargetFeederLine)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

            return View("SearchPole", searchResult);


            //ViewModel mymodel = new ViewModel();
            //mymodel.Teachers = GetTeachers();
            //mymodel.Students = GetStudents();
            //return View(mymodel);


            //var tupleModel = new Tuple<PagingList<TblPole>, IList<SearchParameter>>(searchResult, searchParameters);
            ////var tupleModel = new Tuple<IList<TblPole>, IList<SearchParameter>>(qry.ToList(), searchParameters);

            //return View("SearchPole", tupleModel);

            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            //ViewData["FieldName"] = new SelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");
            //ViewBag.FieldNameList = new MultiSelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");


            //var qry = _context.TblPole.AsNoTracking()
            //    .Include(pi => pi.PoleToFeederLine)
            //    .Include(pi => pi.PoleToRoute)
            //    .Include(pi => pi.PoleType)
            //    .Include(pi => pi.PoleCondition)
            //    .Include(pi => pi.PoleToSourceFeederLine)
            //    .Include(pi => pi.PoleToTargetFeederLine)
            //    .AsQueryable();

            ////qry = qry.Where(result);

            //var finalResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, sortExp);

            //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            ////ViewData["FieldName"] = new SelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");
            ////ViewBag.FieldNameList = new MultiSelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");

            //return View(finalResult);
        }

    }


    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchSubstation(int modelId = 1, int pageIndex = 1, string sort = "SubstationId")
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
                new SelectListItem {Value = "SubstationId", Text = "Substation Id"},
                new SelectListItem {Value = "SubstationType", Text = "Substation Type"},
                new SelectListItem {Value = "SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "SnDCode", Text = "S&D Code"},
                new SelectListItem {Value = "NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "InstalledCapacity", Text = "Installed Capacity"},
                new SelectListItem {Value = "MaximumDemand", Text = "Maximum Demand"},
                new SelectListItem {Value = "PeakLoad", Text = "Peak Load"},
                new SelectListItem {Value = "Location", Text = "Location"},
                new SelectListItem {Value = "AreaOfSubstation", Text = "Area of Substation"},
                new SelectListItem {Value = "Latitude", Text = "Latitude"},
                new SelectListItem {Value = "Longitude", Text = "Longitude"},
                new SelectListItem {Value = "YearOfComissioning", Text = "Year of Commissioning"}
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

            var qry = _context.TblSubstation.AsNoTracking()
                .Include(st => st.SubstationType)
                .Include(st => st.SubstationToLookUpSnD)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();


            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "SubstationId");

            return View("SearchSubstation", searchResult);
        }


        [HttpPost]
        public async Task<IActionResult> SearchSubstation(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "SubstationId")
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
                new SelectListItem {Value = "SubstationId", Text = "Substation Id"},
                new SelectListItem {Value = "SubstationType", Text = "Substation Type"},
                new SelectListItem {Value = "SubstationName", Text = "Substation Name"},
                new SelectListItem {Value = "SnDCode", Text = "S&D Code"},
                new SelectListItem {Value = "NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "InstalledCapacity", Text = "Installed Capacity"},
                new SelectListItem {Value = "MaximumDemand", Text = "Maximum Demand"},
                new SelectListItem {Value = "PeakLoad", Text = "Peak Load"},
                new SelectListItem {Value = "Location", Text = "Location"},
                new SelectListItem {Value = "AreaOfSubstation", Text = "Area of Substation"},
                new SelectListItem {Value = "Latitude", Text = "Latitude"},
                new SelectListItem {Value = "Longitude", Text = "Longitude"},
                new SelectListItem {Value = "YearOfComissioning", Text = "Year of Commissioning"}
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


            var qry = _context.TblSubstation.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblSubstation, Boolean>> searchExp = null;

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

                    Expression<Func<TblSubstation, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "SubstationId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SubstationId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SubstationId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.SubstationId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.SubstationId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.SubstationId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.SubstationId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SubstationId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SubstationId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SubstationId.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SubstationTypeId":
                        case "SubstationType":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SubstationType.SubstationTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SubstationType.SubstationTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SubstationType.SubstationTypeName) >
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SubstationType.SubstationTypeName) <
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SubstationType.SubstationTypeName) >=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SubstationType.SubstationTypeName) <=
                                        int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SubstationType.SubstationTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SubstationType.SubstationTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model =>
                                        model.SubstationType.SubstationTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SubstationName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SubstationName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SubstationName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SubstationName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SubstationName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SubstationName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SubstationName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SubstationName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SubstationName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SubstationName.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "SnDCode":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SnDCode == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SnDCode != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SnDCode) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SnDCode) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SnDCode) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SnDCode) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SnDCode == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SnDCode != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SnDCode.Contains(searchOption.FieldValue);
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
                                        int.Parse(model.NominalVoltage) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NominalVoltage) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NominalVoltage) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NominalVoltage) <= int.Parse(searchOption.FieldValue);
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

                        case "InstalledCapacity":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.InstalledCapacity == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.InstalledCapacity != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.InstalledCapacity) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.InstalledCapacity) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.InstalledCapacity) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.InstalledCapacity) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.InstalledCapacity == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.InstalledCapacity != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.InstalledCapacity.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "MaximumDemand":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MaximumDemand == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MaximumDemand != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MaximumDemand > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MaximumDemand < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MaximumDemand >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MaximumDemand <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MaximumDemand == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MaximumDemand != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MaximumDemand.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "PeakLoad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PeakLoad == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.PeakLoad != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.PeakLoad > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.PeakLoad < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.PeakLoad >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.PeakLoad <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PeakLoad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PeakLoad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PeakLoad.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Location":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Location == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Location != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.Location) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.Location) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.Location) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.Location) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Location == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Location != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Location.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "AreaOfSubstation":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.AreaOfSubstation == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.AreaOfSubstation != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.AreaOfSubstation) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.AreaOfSubstation) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.AreaOfSubstation) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.AreaOfSubstation) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.AreaOfSubstation == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.AreaOfSubstation != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.AreaOfSubstation.Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;



                        case "Latitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Latitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Latitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Latitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Latitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Latitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Latitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Latitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Latitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Latitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "Longitude":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Longitude == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.Longitude != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.Longitude > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.Longitude < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.Longitude >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.Longitude <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Longitude == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Longitude != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Longitude.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }

                            break;

                        case "YearOfComissioning":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.YearOfComissioning == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.YearOfComissioning != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        DateTime.Parse(model.YearOfComissioning) > DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        DateTime.Parse(model.YearOfComissioning) < DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        DateTime.Parse(model.YearOfComissioning) >= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        DateTime.Parse(model.YearOfComissioning) <= DateTime.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.YearOfComissioning == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.YearOfComissioning != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.YearOfComissioning.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblSubstation>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblSubstation>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(st => st.SubstationType)
                .Include(st => st.SubstationToLookUpSnD)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo)
                .Include(st => st.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "SubstationId");

            return View("SearchSubstation", searchResult);
        }

    }


    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchDistributionTransformer(int modelId = 1, int pageIndex = 1, string sort = "DistributionTransformerId")          /*string sort = "PoleId",*/
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
                new SelectListItem {Value = "DistributionTransformerId", Text = "Distribution Transformer Id"},
                new SelectListItem {Value = "NameOf33bs11kVSubdsstation", Text = "Name of 33/11kV Sub-station"},
                new SelectListItem {Value = "Nameof11kVFeeder", Text = "Name of 11kV Feeder"},
                new SelectListItem {Value = "SNDIdentificationNo", Text = "SND Id No."},
                new SelectListItem {Value = "NearestHoldingbsHouseNobsShop", Text = "Nearest Holding/HouseNo/Shop"},
                new SelectListItem {Value = "ExistingPoleNumberingifAny", Text = "Existing Pole Numbering (if Any)"},
                new SelectListItem {Value = "InstalledConditionPadbsPoleMounted", Text = "Installed Condition (Pad/Pole Mounted)"},
                new SelectListItem {Value = "InstalledPlaceIndoorbsOutdoor", Text = "Installed Place (Indoor/Outdoor)"},
                new SelectListItem {Value = "ContractNo", Text = "Contract No."},
                new SelectListItem {Value = "OwneroftheTransformerBPDBbsConsumer", Text = "Owner of the Transformer (BPDB/Consumer)"},
                new SelectListItem {Value = "TransformerKVARating", Text = "Transformer KVA Rating"},
                new SelectListItem {Value = "YearofManufacturing", Text = "Year of Manufacturing"},
                new SelectListItem {Value = "NameofManufacturer", Text = "Name of Manufacturer"},
                new SelectListItem {Value = "BodyColourCondition", Text = "Body Colour Condition"},
                new SelectListItem {Value = "NameoBodyColour", Text = "Name of Body Colour"},
                new SelectListItem {Value = "OilLeakageYesOrNo", Text = "Oil Leakage (Yes/No)"},
                new SelectListItem {Value = "PlaceofOilLeakageMark", Text = "Place of Oil Leakage Mark"},
                new SelectListItem {Value = "PlatformMaterialAnglbsChannel", Text = "Platform Material (Angle/Channel)"},
                new SelectListItem {Value = "PlatformStandardbsNonStandardGoodBad", Text = "Platform (Standard/NonStandard/Good/Bad)"},
                new SelectListItem {Value = "TypeofTransformerSupportPoleLeft", Text = "Type of Transformer Support Pole (Left)"},
                new SelectListItem {Value = "ConditionofTransformerSupportPoleLeft", Text = "Condition of Transformer Support Pole (Left)"},
                new SelectListItem {Value = "TypeofTransformerSupportPoleRight", Text = "Type of Transformer Support Pole (Right)"},
                new SelectListItem {Value = "ConditionofTransformerSupportPoleRight", Text = "Condition of Transformer Support Pole (Right)"}
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



            var qry = _context.TblDistributionTransformer.AsNoTracking()
                .Include(t => t.DtToFeederLine)
                .Include(t => t.DtToPole)
                .Include(t => t.PoleStructureMountedSurgeArrestor)
                .AsQueryable();


            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "DistributionTransformerId");

            return View("SearchDistributionTransformer", searchResult);


        }


        [HttpPost]
        public async Task<IActionResult> SearchDistributionTransformer(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "DistributionTransformerId")          /*string sort = "PoleId",*/
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
                new SelectListItem {Value = "DistributionTransformerId", Text = "Distribution Transformer Id"},
                new SelectListItem {Value = "NameOf33bs11kVSubdsstation", Text = "Name of 33/11kV Sub-station"},
                new SelectListItem {Value = "Nameof11kVFeeder", Text = "Name of 11kV Feeder"},
                new SelectListItem {Value = "SNDIdentificationNo", Text = "SND Id No."},
                new SelectListItem {Value = "NearestHoldingbsHouseNobsShop", Text = "Nearest Holding/HouseNo/Shop"},
                new SelectListItem {Value = "ExistingPoleNumberingifAny", Text = "Existing Pole Numbering (if Any)"},
                new SelectListItem {Value = "InstalledConditionPadbsPoleMounted", Text = "Installed Condition (Pad/Pole Mounted)"},
                new SelectListItem {Value = "InstalledPlaceIndoorbsOutdoor", Text = "Installed Place (Indoor/Outdoor)"},
                new SelectListItem {Value = "ContractNo", Text = "Contract No."},
                new SelectListItem {Value = "OwneroftheTransformerBPDBbsConsumer", Text = "Owner of the Transformer (BPDB/Consumer)"},
                new SelectListItem {Value = "TransformerKVARating", Text = "Transformer KVA Rating"},
                new SelectListItem {Value = "YearofManufacturing", Text = "Year of Manufacturing"},
                new SelectListItem {Value = "NameofManufacturer", Text = "Name of Manufacturer"},
                new SelectListItem {Value = "BodyColourCondition", Text = "Body Colour Condition"},
                new SelectListItem {Value = "NameoBodyColour", Text = "Name of Body Colour"},
                new SelectListItem {Value = "OilLeakageYesOrNo", Text = "Oil Leakage (Yes/No)"},
                new SelectListItem {Value = "PlaceofOilLeakageMark", Text = "Place of Oil Leakage Mark"},
                new SelectListItem {Value = "PlatformMaterialAnglbsChannel", Text = "Platform Material (Angle/Channel)"},
                new SelectListItem {Value = "PlatformStandardbsNonStandardGoodBad", Text = "Platform (Standard/NonStandard/Good/Bad)"},
                new SelectListItem {Value = "TypeofTransformerSupportPoleLeft", Text = "Type of Transformer Support Pole (Left)"},
                new SelectListItem {Value = "ConditionofTransformerSupportPoleLeft", Text = "Condition of Transformer Support Pole (Left)"},
                new SelectListItem {Value = "TypeofTransformerSupportPoleRight", Text = "Type of Transformer Support Pole (Right)"},
                new SelectListItem {Value = "ConditionofTransformerSupportPoleRight", Text = "Condition of Transformer Support Pole (Right)"}
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


            var qry = _context.TblDistributionTransformer.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblDistributionTransformer, Boolean>> searchExp = null;

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

                    Expression<Func<TblDistributionTransformer, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "DistributionTransformerId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.DistributionTransformerId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.DistributionTransformerId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.DistributionTransformerId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.DistributionTransformerId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.DistributionTransformerId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.DistributionTransformerId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.DistributionTransformerId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.DistributionTransformerId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.DistributionTransformerId.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NameOf33bs11kVSubdsstation":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NameOf33bs11kVSubdsstation) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NameOf33bs11kVSubdsstation) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NameOf33bs11kVSubdsstation) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NameOf33bs11kVSubdsstation) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NameOf33bs11kVSubdsstation.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "Nameof11kVFeeder":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.Nameof11kVFeeder == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.Nameof11kVFeeder != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.Nameof11kVFeeder) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.Nameof11kVFeeder) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.Nameof11kVFeeder) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.Nameof11kVFeeder) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.Nameof11kVFeeder == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.Nameof11kVFeeder != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.Nameof11kVFeeder.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "SNDIdentificationNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SNDIdentificationNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.SNDIdentificationNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.SNDIdentificationNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.SNDIdentificationNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.SNDIdentificationNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.SNDIdentificationNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.SNDIdentificationNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.SNDIdentificationNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.SNDIdentificationNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "NearestHoldingbsHouseNobsShop":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NearestHoldingbsHouseNobsShop) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NearestHoldingbsHouseNobsShop) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NearestHoldingbsHouseNobsShop) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NearestHoldingbsHouseNobsShop) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NearestHoldingbsHouseNobsShop.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ExistingPoleNumberingifAny":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ExistingPoleNumberingifAny == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ExistingPoleNumberingifAny != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ExistingPoleNumberingifAny) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ExistingPoleNumberingifAny) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ExistingPoleNumberingifAny) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ExistingPoleNumberingifAny) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ExistingPoleNumberingifAny == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ExistingPoleNumberingifAny != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ExistingPoleNumberingifAny.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "InstalledConditionPadbsPoleMounted":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.InstalledConditionPadbsPoleMounted) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.InstalledConditionPadbsPoleMounted) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.InstalledConditionPadbsPoleMounted) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.InstalledConditionPadbsPoleMounted) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.InstalledConditionPadbsPoleMounted.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "InstalledPlaceIndoorbsOutdoor":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.InstalledPlaceIndoorbsOutdoor) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.InstalledPlaceIndoorbsOutdoor) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.InstalledPlaceIndoorbsOutdoor) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.InstalledPlaceIndoorbsOutdoor) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.InstalledPlaceIndoorbsOutdoor.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ContractNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ContractNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ContractNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ContractNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ContractNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ContractNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ContractNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ContractNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ContractNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ContractNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "OwneroftheTransformerBPDBbsConsumer":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.OwneroftheTransformerBPDBbsConsumer) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.OwneroftheTransformerBPDBbsConsumer) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.OwneroftheTransformerBPDBbsConsumer) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.OwneroftheTransformerBPDBbsConsumer) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.OwneroftheTransformerBPDBbsConsumer.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TransformerKVARating":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TransformerKVARating == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TransformerKVARating != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.TransformerKVARating) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.TransformerKVARating) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.TransformerKVARating) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.TransformerKVARating) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TransformerKVARating == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TransformerKVARating != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TransformerKVARating.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "YearofManufacturing":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.YearofManufacturing == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.YearofManufacturing != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.YearofManufacturing) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.YearofManufacturing) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.YearofManufacturing) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.YearofManufacturing) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.YearofManufacturing == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.YearofManufacturing != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.YearofManufacturing.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "NameofManufacturer":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NameofManufacturer == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NameofManufacturer != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NameofManufacturer) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NameofManufacturer) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NameofManufacturer) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NameofManufacturer) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NameofManufacturer == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NameofManufacturer != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NameofManufacturer.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "BodyColourCondition":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.BodyColourCondition == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.BodyColourCondition != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.BodyColourCondition) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.BodyColourCondition) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.BodyColourCondition) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.BodyColourCondition) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.BodyColourCondition == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.BodyColourCondition != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.BodyColourCondition.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "NameoBodyColour":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NameoBodyColour == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.NameoBodyColour != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.NameoBodyColour) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.NameoBodyColour) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.NameoBodyColour) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.NameoBodyColour) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NameoBodyColour == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NameoBodyColour != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NameoBodyColour.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "OilLeakageYesOrNo":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.OilLeakageYesOrNo == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.OilLeakageYesOrNo != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.OilLeakageYesOrNo) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.OilLeakageYesOrNo) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.OilLeakageYesOrNo) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.OilLeakageYesOrNo) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.OilLeakageYesOrNo == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.OilLeakageYesOrNo != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.OilLeakageYesOrNo.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PlaceofOilLeakageMark":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PlaceofOilLeakageMark == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PlaceofOilLeakageMark != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PlaceofOilLeakageMark) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PlaceofOilLeakageMark) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PlaceofOilLeakageMark) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PlaceofOilLeakageMark) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PlaceofOilLeakageMark == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PlaceofOilLeakageMark != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PlaceofOilLeakageMark.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PlatformMaterialAnglbsChannel":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PlatformMaterialAnglbsChannel) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PlatformMaterialAnglbsChannel) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PlatformMaterialAnglbsChannel) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PlatformMaterialAnglbsChannel) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PlatformMaterialAnglbsChannel.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PlatformStandardbsNonStandardGoodBad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.PlatformStandardbsNonStandardGoodBad) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.PlatformStandardbsNonStandardGoodBad) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.PlatformStandardbsNonStandardGoodBad) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.PlatformStandardbsNonStandardGoodBad) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PlatformStandardbsNonStandardGoodBad.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TypeofTransformerSupportPoleLeft":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleLeft) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleLeft) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleLeft) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleLeft) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TypeofTransformerSupportPoleLeft.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ConditionofTransformerSupportPoleLeft":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleLeft) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleLeft) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleLeft) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleLeft) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConditionofTransformerSupportPoleLeft.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "TypeofTransformerSupportPoleRight":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleRight) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleRight) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleRight) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.TypeofTransformerSupportPoleRight) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.TypeofTransformerSupportPoleRight.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "ConditionofTransformerSupportPoleRight":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleRight) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleRight) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleRight) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.ConditionofTransformerSupportPoleRight) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.ConditionofTransformerSupportPoleRight.Contains(searchOption.FieldValue);
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
                            ? ExpressionExtension<TblDistributionTransformer>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblDistributionTransformer>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(t => t.DtToFeederLine)
                .Include(t => t.DtToPole)
                .Include(t => t.PoleStructureMountedSurgeArrestor)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "DistributionTransformerId");

            return View("SearchDistributionTransformer", searchResult);

        }

    }




    public partial class AdvancedSearchingController : Controller
    {

        public async Task<IActionResult> SearchFeederLine(int modelId = 1, int pageIndex = 1, string sort = "FeederLineId")          /*string sort = "PoleId",*/
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
                new SelectListItem {Value = "FeederLineId", Text = "Feeder Line Id"},
                new SelectListItem {Value = "FeederLineUId", Text = "Feeder Line UId"},
                new SelectListItem {Value = "FeederLineType", Text = "Feeder Line Type"},
                new SelectListItem {Value = "RouteName", Text = "Route Name"},
                new SelectListItem {Value = "FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "FeederLocation", Text = "Feeder Location"},
                new SelectListItem {Value = "FeedermeterNumber", Text = "Feeder Meter Number"},
                new SelectListItem {Value = "MeterCurrentRating", Text = "Meter Current Rating"},
                new SelectListItem {Value = "MeterVoltageRating", Text = "Meter Voltage Rating"},
                new SelectListItem {Value = "MaximumDemand", Text = "Maximum Demand"},
                new SelectListItem {Value = "PeakDemand", Text = "Peak Demand"},
                new SelectListItem {Value = "MaximumLoad", Text = "Maximum Load"},
                new SelectListItem {Value = "SanctionedLoad", Text = "Sanctioned Load"},
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


            var qry = _context.TblFeederLine.AsNoTracking()
                .Include(t => t.FeederLineToRoute)
                .Include(t => t.FeederLineType)
                .AsQueryable();


            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "FeederLineId");

            return View("SearchFeederLine", searchResult);


        }


        [HttpPost]
        public async Task<IActionResult> SearchFeederLine(List<List<string>> searchParameters, int modelId = 1, int pageIndex = 1, string sort = "FeederLineId")          /*string sort = "PoleId",*/
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
                new SelectListItem {Value = "FeederLineId", Text = "Feeder Line Id"},
                new SelectListItem {Value = "FeederLineUId", Text = "Feeder Line UId"},
                new SelectListItem {Value = "FeederLineType", Text = "Feeder Line Type"},
                new SelectListItem {Value = "RouteName", Text = "Route Name"},
                new SelectListItem {Value = "FeederName", Text = "Feeder Name"},
                new SelectListItem {Value = "NominalVoltage", Text = "Nominal Voltage"},
                new SelectListItem {Value = "FeederLocation", Text = "Feeder Location"},
                new SelectListItem {Value = "FeedermeterNumber", Text = "Feeder Meter Number"},
                new SelectListItem {Value = "MeterCurrentRating", Text = "Meter Current Rating"},
                new SelectListItem {Value = "MeterVoltageRating", Text = "Meter Voltage Rating"},
                new SelectListItem {Value = "MaximumDemand", Text = "Maximum Demand"},
                new SelectListItem {Value = "PeakDemand", Text = "Peak Demand"},
                new SelectListItem {Value = "MaximumLoad", Text = "Maximum Load"},
                new SelectListItem {Value = "SanctionedLoad", Text = "Sanctioned Load"},
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


            var qry = _context.TblFeederLine.AsNoTracking();


            if (searchParameters != null && searchParameters.Count > 0)
            {
                Expression<Func<TblFeederLine, Boolean>> searchExp = null;

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

                    Expression<Func<TblFeederLine, Boolean>> tempExp = null;

                    switch (searchOption.FieldName)
                    {
                        case "FeederLineId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLineId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLineId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.FeederLineId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.FeederLineId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.FeederLineId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.FeederLineId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLineId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLineId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLineId.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "FeederLineUId":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLineUId == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLineUId != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineUId) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineUId) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineUId) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineUId) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLineUId == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLineUId != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLineUId.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "FeederLineType":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineType.FeederLineTypeName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineType.FeederLineTypeName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineType.FeederLineTypeName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineType.FeederLineTypeName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLineType.FeederLineTypeName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "RouteName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLineToRoute.RouteName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLineToRoute.RouteName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineToRoute.RouteName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineToRoute.RouteName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineToRoute.RouteName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLineToRoute.RouteName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLineToRoute.RouteName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLineToRoute.RouteName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLineToRoute.RouteName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "FeederName":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederName == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederName != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederName) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederName) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederName) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederName) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederName == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederName != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederName.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "NominalVoltage":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.NominalVoltage == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.NominalVoltage != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model =>model.NominalVoltage > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>model.NominalVoltage < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        model.NominalVoltage >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        model.NominalVoltage <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.NominalVoltage == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.NominalVoltage != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.NominalVoltage.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "FeederLocation":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederLocation == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederLocation != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model =>
                                        int.Parse(model.FeederLocation) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model =>
                                        int.Parse(model.FeederLocation) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLocation) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model =>
                                        int.Parse(model.FeederLocation) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederLocation == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederLocation != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederLocation.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;




                        case "FeedermeterNumber":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.FeederMeterNumber == searchOption.FieldValue;
                                    break;
                                case "!=":
                                    tempExp = model => model.FeederMeterNumber != searchOption.FieldValue;
                                    break;
                                case ">":
                                    tempExp = model => int.Parse(model.FeederMeterNumber) > int.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => int.Parse(model.FeederMeterNumber) < int.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => int.Parse(model.FeederMeterNumber) >= int.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => int.Parse(model.FeederMeterNumber) <= int.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.FeederMeterNumber == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.FeederMeterNumber != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.FeederMeterNumber.Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "MeterCurrentRating":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MeterCurrentRating == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MeterCurrentRating != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MeterCurrentRating > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MeterCurrentRating < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MeterCurrentRating >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MeterCurrentRating <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MeterCurrentRating == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MeterCurrentRating != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MeterCurrentRating.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "MeterVoltageRating":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MeterVoltageRating == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MeterVoltageRating != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MeterVoltageRating > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MeterVoltageRating < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MeterVoltageRating >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MeterVoltageRating <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MeterVoltageRating == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MeterVoltageRating != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MeterVoltageRating.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "MaximumDemand":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MaximumDemand == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MaximumDemand != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MaximumDemand > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MaximumDemand < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MaximumDemand >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MaximumDemand <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MaximumDemand == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MaximumDemand != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MaximumDemand.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;

                        case "PeakDemand":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.PeakDemand == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.PeakDemand != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.PeakDemand > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.PeakDemand < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.PeakDemand >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.PeakDemand <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.PeakDemand == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.PeakDemand != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.PeakDemand.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;



                        case "MaximumLoad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.MaximumLoad == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.MaximumLoad != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.MaximumLoad > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.MaximumLoad < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.MaximumLoad >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.MaximumLoad <= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "null":
                                    tempExp = model => model.MaximumLoad == null;
                                    break;
                                case "not null":
                                    tempExp = model => model.MaximumLoad != null;
                                    break;
                                case "Like":
                                    tempExp = model => model.MaximumLoad.ToString().Contains(searchOption.FieldValue);
                                    break;
                            }
                            break;


                        case "SanctionedLoad":
                            switch (searchOption.Operator)
                            {
                                case "=":
                                    tempExp = model => model.SanctionedLoad == decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "!=":
                                    tempExp = model => model.SanctionedLoad != decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">":
                                    tempExp = model => model.SanctionedLoad > decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<":
                                    tempExp = model => model.SanctionedLoad < decimal.Parse(searchOption.FieldValue);
                                    break;
                                case ">=":
                                    tempExp = model => model.SanctionedLoad >= decimal.Parse(searchOption.FieldValue);
                                    break;
                                case "<=":
                                    tempExp = model => model.SanctionedLoad <= decimal.Parse(searchOption.FieldValue);
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
                    }


                    if (searchExp == null)
                    {
                        searchExp = tempExp;
                    }
                    else
                    {
                        searchExp = joinOption.ToUpper() == "OR"
                            ? ExpressionExtension<TblFeederLine>.OrElse(searchExp, tempExp)
                            : ExpressionExtension<TblFeederLine>.AndAlso(searchExp, tempExp);
                    }

                    joinOption = searchOption.JoinOption;
                }


                if (searchExp != null)
                    qry = qry.Where(searchExp);
            }

            qry = qry
                .Include(t => t.FeederLineToRoute)
                .Include(t => t.FeederLineType)
                .AsQueryable();

            var searchResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "FeederLineId");

            return View("SearchFeederLine", searchResult);

        }

    }







    public partial class AdvancedSearchingController : Controller
    {

        /*
               public static IEnumerable<string> GetColumns<TEntity>(string modelName)
               {
                   var property = typeof(TEntity)
                       .GetProperties()
                       .Single(s => s.Name == modelName);

                   return property.PropertyType
                       .GetGenericArguments() //Get the generic type of the DbSet
                       .SelectMany(t => t.GetProperties()
                           .Select(pi => pi.Name));
               }


               [HttpPost]
               public JsonResult GetSelectedFieldValue(string selectedField)
               {
                   var selectedFieldValue = _context.TblPole
                       .Select(u => new { SelectedField = selectedField })
                       .OrderBy(u => selectedField).ToList();

                   return Json(new SelectList(selectedFieldValue, selectedField, selectedField));
               }



               public JsonResult GetCircleList(string zoneCode)
               {
                   var circleList = _context.LookUpCircleInfo
                       .Where(u => u.ZoneCode.Equals(zoneCode))
                       .Select(u => new { u.CircleCode, u.CircleName })
                       .OrderBy(u => u.CircleCode).ToList();

                   return Json(new SelectList(circleList, "CircleCode", "CircleName"));
               }




               //start Advance Search

               private Expression<Func<TblPole, Boolean>> CreateExpression(string fieldName, string fieldValue, string Operator)
               {
                   Expression<Func<TblPole, Boolean>> returnQuery = null;

                   switch (Operator)
                   {
                       case "=":
                           returnQuery = model => model.GetType().GetProperty(fieldName).GetValue(fieldName).ToString() == fieldValue;
                           break;
                       case "!=":
                           returnQuery = model => fieldName != fieldValue;
                           break;
                       case ">":
                           returnQuery = model => int.Parse(fieldName) > int.Parse(fieldValue);
                           break;
                       case "<":
                           returnQuery = model => int.Parse(fieldName) < int.Parse(fieldValue);
                           break;
                       case ">=":
                           returnQuery = model => int.Parse(fieldName) >= int.Parse(fieldValue);
                           break;
                       case "<=":
                           returnQuery = model => int.Parse(fieldName) <= int.Parse(fieldValue);
                           break;
                       case "null":
                           returnQuery = model => fieldName == null;
                           break;
                       case "not null":
                           returnQuery = model => fieldName != null;
                           break;
                   }


                   return returnQuery;
               }

       */

        private Expression<Func<TblPole, Boolean>> AppendExpression(Expression<Func<TblPole, Boolean>> left,
            Expression<Func<TblPole, Boolean>> right, string condition)
        {
            Expression<Func<TblPole, Boolean>> result;

            switch (condition)
            {
                case "ANY":
                    //the initial case starts off with a left epxression as null. If that's the case,
                    //then give the short-circuit operator something to trigger on for the right expression
                    if (left == null)
                    {
                        left = model => false;
                    }

                    result = ExpressionExtension<TblPole>.OrElse(left, right);
                    break;
                case "ALL":

                    if (left == null)
                    {
                        left = model => true;
                    }

                    result = ExpressionExtension<TblPole>.AndAlso(left, right);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return result;
        }


        // GET: ProjectInfoes
        //public ActionResult Index(int? divId)

        // GET: ProjectInfoes
        //public ActionResult Index(int? divId)
        public async Task<IActionResult> Index(string fieldName1, string operator1, string fieldValue1, string AndOr1, string FieldName2, string Operator2, string FieldValue2, string AndOr2, string FieldName3, string Operator3, string FieldValue3, string AndOr3, int pageIndex = 1, string sort = "PoleId")          /*string sort = "PoleId",*/
        {
            //AndOr1 = String.IsNullOrEmpty(AndOr1)? "ALL" : AndOr1;

            TblPole aSearch = new TblPole();
            Expression<Func<TblPole, Boolean>> result = null;

            Expression<Func<TblPole, Boolean>> expr0 = model => model.PoleId != null;

            result = AppendExpression(result, expr0, "ALL");



            //if(aSearch.PoleId.ToString() == FieldName1)
            // "PoleId,FeederName,SurveyDate,RouteName,PoleNo,PreviousPoleNo,Name,PoleConditionId,MSJNo,SleeveNo,TwistNo,
            // PhaseAId,PhaseBId,PhaseCId,Neutral,StreetLight,SourceCableId,TargetCableId,Latitude,Longitude"

            if (!string.IsNullOrEmpty(fieldName1))
            {
                Expression<Func<TblPole, Boolean>> expr1 = null;
                switch (fieldName1)
                {
                    case "PoleId":
                        //Expression<Func<VwPoleData, Boolean>> expr1 = null;                        
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PoleId == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PoleId != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PoleId) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PoleId) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PoleId) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PoleId) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PoleId == null;
                                break;
                            case "not null":
                                expr1 = model => model.PoleId != null;
                                break;
                        }
                        //Expression<Func<VwPoleData, Boolean>> expr1 = model => model.PoleId == FieldValue1;    //  model => model.PoleId == FieldValue1;    CreateExpression(FieldName1, FieldValue1, Operator1);              //Operator1 == "=" ? model => model.PoleId == FieldValue1 : Operator1 == "!=" ? model => model.PoleId != FieldValue1 : Operator1 == ">" ? model => int.Parse(model.PoleId) > int.Parse(FieldValue1) : Operator1 == "<" ? model => int.Parse(model.PoleId) < int.Parse(FieldValue1) : Operator1 == ">=" ? model => int.Parse(model.PoleId) >= int.Parse(FieldValue1) : Operator1 == "<=" ? model => int.Parse(model.PoleId) <= int.Parse(FieldValue1) : Operator1 == "null" ? model => model.PoleId = null : Operator1 == "not null" ? model => model.PoleId != null : model => model.PoleId == FieldValue1;
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "FeederName":
                        //aSearch.FeederName = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr2 = model => model.FeederName == FieldValue1;
                        //Expression<Func<VwPoleData, Boolean>> expr2 = null;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PoleToFeederLine.FeederName == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PoleToFeederLine.FeederName != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PoleToFeederLine.FeederName) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PoleToFeederLine.FeederName) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PoleToFeederLine.FeederName) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PoleToFeederLine.FeederName) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PoleToFeederLine.FeederName == null;
                                break;
                            case "not null":
                                expr1 = model => model.PoleToFeederLine.FeederName != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "SurveyDate":
                        //aSearch.SurveyDate = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr3 = model => model.SurveyDate == FieldValue1;
                        //switch (operator1)
                        //{
                        //    case "=":
                        //        expr1 = model => model.SurveyDate == fieldValue1;
                        //        break;
                        //    case "!=":
                        //        expr1 = model => model.SurveyDate != fieldValue1;
                        //        break;
                        //    case ">":
                        //        expr1 = model => DateTime.Parse(model.SurveyDate) > DateTime.Parse(fieldValue1);
                        //        break;
                        //    case "<":
                        //        expr1 = model => DateTime.Parse(model.SurveyDate) < DateTime.Parse(fieldValue1);
                        //        break;
                        //    case ">=":
                        //        expr1 = model => DateTime.Parse(model.SurveyDate) >= DateTime.Parse(fieldValue1);
                        //        break;
                        //    case "<=":
                        //        expr1 = model => DateTime.Parse(model.SurveyDate) <= DateTime.Parse(fieldValue1);
                        //        break;
                        //    case "null":
                        //        expr1 = model => model.SurveyDate == null;
                        //        break;
                        //    case "not null":
                        //        expr1 = model => model.SurveyDate != null;
                        //        break;
                        //}
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "RouteName":
                        //aSearch.RouteName = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr4 = model => model.RouteName == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PoleToRoute.RouteName == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PoleToRoute.RouteName != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PoleToRoute.RouteName) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PoleToRoute.RouteName) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PoleToRoute.RouteName) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PoleToRoute.RouteName) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PoleToRoute.RouteName == null;
                                break;
                            case "not null":
                                expr1 = model => model.PoleToRoute.RouteName != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "PoleNo":
                        //aSearch.PoleNo = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr5 = model => model.PoleNo == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PoleNo == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PoleNo != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PoleNo) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PoleNo) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PoleNo) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PoleNo) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PoleNo == null;
                                break;
                            case "not null":
                                expr1 = model => model.PoleNo != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "PreviousPoleNo":
                        //aSearch.PreviousPoleNo = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr6 = model => model.PreviousPoleNo == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PreviousPoleNo == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PreviousPoleNo != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PreviousPoleNo == null;
                                break;
                            case "not null":
                                expr1 = model => model.PreviousPoleNo != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "Name":
                        //aSearch.Name = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr7 = model => model.Name == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PoleType.Name == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PoleType.Name != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PoleType.Name.Length.ToString()) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PoleType.Name.Length.ToString()) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PoleType.Name.Length.ToString()) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PoleType.Name.Length.ToString()) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PoleType.Name == null;
                                break;
                            case "not null":
                                expr1 = model => model.PoleType.Name != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "PoleConditionId":
                        //aSearch.PoleConditionId = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr8 = model => model.PoleConditionId == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PoleConditionId == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PoleConditionId != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PoleConditionId) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PoleConditionId) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PoleConditionId) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PoleConditionId) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PoleConditionId == null;
                                break;
                            case "not null":
                                expr1 = model => model.PoleConditionId != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "MSJNo":
                        //aSearch.MSJNo = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr9 = model => model.MSJNo == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.MSJNo == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.MSJNo != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.MSJNo) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.MSJNo) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.MSJNo) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.MSJNo) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.MSJNo == null;
                                break;
                            case "not null":
                                expr1 = model => model.MSJNo != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "SleeveNo":
                        //aSearch.SleeveNo = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr10 = model => model.SleeveNo == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.SleeveNo == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.SleeveNo != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.SleeveNo) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.SleeveNo) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.SleeveNo) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.SleeveNo) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.SleeveNo == null;
                                break;
                            case "not null":
                                expr1 = model => model.SleeveNo != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "TwistNo":
                        //aSearch.TwistNo = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr11 = model => model.TwistNo == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.TwistNo == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.TwistNo != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.TwistNo) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.TwistNo) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.TwistNo) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.TwistNo) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.TwistNo == null;
                                break;
                            case "not null":
                                expr1 = model => model.TwistNo != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "PhaseAId":
                        //aSearch.PhaseAId = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr12 = model => model.PhaseAId == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PhaseAId == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PhaseAId != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PhaseAId) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PhaseAId) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PhaseAId) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PhaseAId) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PhaseAId == null;
                                break;
                            case "not null":
                                expr1 = model => model.PhaseAId != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "PhaseBId":
                        //aSearch.PhaseBId = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr13 = model => model.PhaseBId == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PhaseBId == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PhaseBId != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PhaseBId) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PhaseBId) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PhaseBId) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PhaseBId) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PhaseBId == null;
                                break;
                            case "not null":
                                expr1 = model => model.PhaseBId != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "PhaseCId":
                        //aSearch.PhaseCId = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr14 = model => model.PhaseCId == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.PhaseCId == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.PhaseCId != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.PhaseCId) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.PhaseCId) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.PhaseCId) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.PhaseCId) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.PhaseCId == null;
                                break;
                            case "not null":
                                expr1 = model => model.PhaseCId != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "Neutral":
                        //aSearch.Neutral = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr15 = model => model.Neutral == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.Neutral == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.Neutral != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.Neutral.Length.ToString()) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.Neutral.Length.ToString()) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.Neutral.Length.ToString()) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.Neutral.Length.ToString()) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.Neutral == null;
                                break;
                            case "not null":
                                expr1 = model => model.Neutral != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                    case "StreetLight":
                        //aSearch.StreetLight = (FieldName1 == null ? null : FieldName1);
                        //Expression<Func<VwPoleData, Boolean>> expr16 = model => model.StreetLight == FieldValue1;
                        switch (operator1)
                        {
                            case "=":
                                expr1 = model => model.StreetLight == fieldValue1;
                                break;
                            case "!=":
                                expr1 = model => model.StreetLight != fieldValue1;
                                break;
                            case ">":
                                expr1 = model => int.Parse(model.StreetLight.Length.ToString()) > int.Parse(fieldValue1);
                                break;
                            case "<":
                                expr1 = model => int.Parse(model.StreetLight.Length.ToString()) < int.Parse(fieldValue1);
                                break;
                            case ">=":
                                expr1 = model => int.Parse(model.StreetLight.Length.ToString()) >= int.Parse(fieldValue1);
                                break;
                            case "<=":
                                expr1 = model => int.Parse(model.StreetLight.Length.ToString()) <= int.Parse(fieldValue1);
                                break;
                            case "null":
                                expr1 = model => model.StreetLight == null;
                                break;
                            case "not null":
                                expr1 = model => model.StreetLight != null;
                                break;
                        }
                        result = AppendExpression(result, expr1, AndOr1);
                        break;
                        //case "SourceCableId":
                        //    //aSearch.SourceCableId = (FieldName1 == null ? null : FieldName1);
                        //    //Expression<Func<VwPoleData, Boolean>> expr17 = model => model.SourceCableId == FieldValue1;
                        //    switch (operator1)
                        //    {
                        //        case "=":
                        //            expr1 = model => model.SourceCableId == fieldValue1;
                        //            break;
                        //        case "!=":
                        //            expr1 = model => model.SourceCableId != fieldValue1;
                        //            break;
                        //        case ">":
                        //            expr1 = model => int.Parse(model.SourceCableId) > int.Parse(fieldValue1);
                        //            break;
                        //        case "<":
                        //            expr1 = model => int.Parse(model.SourceCableId) < int.Parse(fieldValue1);
                        //            break;
                        //        case ">=":
                        //            expr1 = model => int.Parse(model.SourceCableId) >= int.Parse(fieldValue1);
                        //            break;
                        //        case "<=":
                        //            expr1 = model => int.Parse(model.SourceCableId) <= int.Parse(fieldValue1);
                        //            break;
                        //        case "null":
                        //            expr1 = model => model.SourceCableId == null;
                        //            break;
                        //        case "not null":
                        //            expr1 = model => model.SourceCableId != null;
                        //            break;
                        //    }
                        //    result = AppendExpression(result, expr1, AndOr1);
                        //    break;
                        //case "TargetCableId":
                        //    //aSearch.TargetCableId = (FieldName1 == null ? null : FieldName1);
                        //    //Expression<Func<VwPoleData, Boolean>> expr18 = model => model.TargetCableId == FieldValue1;
                        //    switch (operator1)
                        //    {
                        //        case "=":
                        //            expr1 = model => model.TargetCableId == fieldValue1;
                        //            break;
                        //        case "!=":
                        //            expr1 = model => model.TargetCableId != fieldValue1;
                        //            break;
                        //        case ">":
                        //            expr1 = model => int.Parse(model.TargetCableId) > int.Parse(fieldValue1);
                        //            break;
                        //        case "<":
                        //            expr1 = model => int.Parse(model.TargetCableId) < int.Parse(fieldValue1);
                        //            break;
                        //        case ">=":
                        //            expr1 = model => int.Parse(model.TargetCableId) >= int.Parse(fieldValue1);
                        //            break;
                        //        case "<=":
                        //            expr1 = model => int.Parse(model.TargetCableId) <= int.Parse(fieldValue1);
                        //            break;
                        //        case "null":
                        //            expr1 = model => model.TargetCableId == null;
                        //            break;
                        //        case "not null":
                        //            expr1 = model => model.TargetCableId != null;
                        //            break;
                        //    }
                        //    result = AppendExpression(result, expr1, AndOr1);
                        //    break;

                        //case "Latitude":
                        //    //aSearch.Latitude = (FieldName1 == null ? null : FieldName1);
                        //    //Expression<Func<VwPoleData, Boolean>> expr19 = model => model.Latitude == FieldValue1;
                        //    switch (operator1)
                        //    {
                        //        case "=":
                        //            expr1 = model => model.Latitude == fieldValue1;
                        //            break;
                        //        case "!=":
                        //            expr1 = model => model.Latitude != fieldValue1;
                        //            break;
                        //        case ">":
                        //            expr1 = model => decimal.Parse(model.Latitude) > decimal.Parse(fieldValue1);
                        //            break;
                        //        case "<":
                        //            expr1 = model => decimal.Parse(model.Latitude) < decimal.Parse(fieldValue1);
                        //            break;
                        //        case ">=":
                        //            expr1 = model => decimal.Parse(model.Latitude) >= decimal.Parse(fieldValue1);
                        //            break;
                        //        case "<=":
                        //            expr1 = model => decimal.Parse(model.Latitude) <= decimal.Parse(fieldValue1);
                        //            break;
                        //        case "null":
                        //            expr1 = model => model.Latitude == null;
                        //            break;
                        //        case "not null":
                        //            expr1 = model => model.Latitude != null;
                        //            break;
                        //    }
                        //    result = AppendExpression(result, expr1, AndOr1);
                        //    break;
                        //case "Longitude":
                        //    //aSearch.Longitude = (FieldName1 == null ? null : FieldName1);
                        //    //Expression<Func<VwPoleData, Boolean>> expr20 = model => model.Longitude == FieldValue1;
                        //    switch (operator1)
                        //    {
                        //        case "=":
                        //            expr1 = model => model.Longitude == fieldValue1;
                        //            break;
                        //        case "!=":
                        //            expr1 = model => model.Longitude != fieldValue1;
                        //            break;
                        //        case ">":
                        //            expr1 = model => decimal.Parse(model.Longitude) > decimal.Parse(fieldValue1);
                        //            break;
                        //        case "<":
                        //            expr1 = model => decimal.Parse(model.Longitude) < decimal.Parse(fieldValue1);
                        //            break;
                        //        case ">=":
                        //            expr1 = model => decimal.Parse(model.Longitude) >= decimal.Parse(fieldValue1);
                        //            break;
                        //        case "<=":
                        //            expr1 = model => decimal.Parse(model.Longitude) <= decimal.Parse(fieldValue1);
                        //            break;
                        //        case "null":
                        //            expr1 = model => model.Longitude == null;
                        //            break;
                        //        case "not null":
                        //            expr1 = model => model.Longitude != null;
                        //            break;
                        //    }
                        //    result = AppendExpression(result, expr1, AndOr1);
                        //    break;
                }


                if (!string.IsNullOrEmpty(FieldName2))
                {
                    Expression<Func<TblPole, Boolean>> expr2 = null;
                    switch (FieldName2)
                    {
                        case "PoleId":
                            //Expression<Func<VwPoleData, Boolean>> expr2 = null;                        
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PoleId == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PoleId != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PoleId) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PoleId) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PoleId) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PoleId) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PoleId == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PoleId != null;
                                    break;
                            }
                            //Expression<Func<VwPoleData, Boolean>> expr2 = model => model.PoleId == FieldValue2;    //  model => model.PoleId == FieldValue2;    CreateExpression(FieldName2, FieldValue2, Operator1);              //Operator1 == "=" ? model => model.PoleId == FieldValue1 : Operator1 == "!=" ? model => model.PoleId != FieldValue1 : Operator1 == ">" ? model => int.Parse(model.PoleId) > int.Parse(FieldValue1) : Operator1 == "<" ? model => int.Parse(model.PoleId) < int.Parse(FieldValue1) : Operator1 == ">=" ? model => int.Parse(model.PoleId) >= int.Parse(FieldValue1) : Operator1 == "<=" ? model => int.Parse(model.PoleId) <= int.Parse(FieldValue1) : Operator1 == "null" ? model => model.PoleId = null : Operator1 == "not null" ? model => model.PoleId != null : model => model.PoleId == FieldValue1;
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "FeederName":
                            //aSearch.FeederName = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr2 = model => model.FeederName == FieldValue1;
                            //Expression<Func<VwPoleData, Boolean>> expr2 = null;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PoleToFeederLine.FeederName == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PoleToFeederLine.FeederName != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PoleToFeederLine.FeederName.Length.ToString()) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PoleToFeederLine.FeederName.Length.ToString()) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PoleToFeederLine.FeederName.Length.ToString()) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PoleToFeederLine.FeederName.Length.ToString()) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PoleToFeederLine.FeederName == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PoleToFeederLine.FeederName != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "SurveyDate":
                            //aSearch.SurveyDate = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr3 = model => model.SurveyDate == FieldValue1;
                            //switch (Operator2)
                            //{
                            //    case "=":
                            //        expr2 = model => model.SurveyDate == FieldValue2;
                            //        break;
                            //    case "!=":
                            //        expr2 = model => model.SurveyDate != FieldValue2;
                            //        break;
                            //    case ">":
                            //        expr2 = model => DateTime.Parse(model.SurveyDate) > DateTime.Parse(FieldValue2);
                            //        break;
                            //    case "<":
                            //        expr2 = model => DateTime.Parse(model.SurveyDate) < DateTime.Parse(FieldValue2);
                            //        break;
                            //    case ">=":
                            //        expr2 = model => DateTime.Parse(model.SurveyDate) >= DateTime.Parse(FieldValue2);
                            //        break;
                            //    case "<=":
                            //        expr2 = model => DateTime.Parse(model.SurveyDate) <= DateTime.Parse(FieldValue2);
                            //        break;
                            //    case "null":
                            //        expr2 = model => model.SurveyDate == null;
                            //        break;
                            //    case "not null":
                            //        expr2 = model => model.SurveyDate != null;
                            //        break;
                            //}
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "RouteName":
                            //aSearch.RouteName = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr4 = model => model.RouteName == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PoleToRoute.RouteName == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PoleToRoute.RouteName != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PoleToRoute.RouteName.Length.ToString()) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PoleToRoute.RouteName.Length.ToString()) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PoleToRoute.RouteName.Length.ToString()) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PoleToRoute.RouteName.Length.ToString()) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PoleToRoute.RouteName == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PoleToRoute.RouteName != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "PoleNo":
                            //aSearch.PoleNo = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr5 = model => model.PoleNo == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PoleNo == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PoleNo != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PoleNo.Length.ToString()) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PoleNo.Length.ToString()) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PoleNo.Length.ToString()) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PoleNo.Length.ToString()) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PoleNo == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PoleNo != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "PreviousPoleNo":
                            //aSearch.PreviousPoleNo = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr6 = model => model.PreviousPoleNo == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PreviousPoleNo == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PreviousPoleNo != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PreviousPoleNo == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PreviousPoleNo != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "Name":
                            //aSearch.Name = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr7 = model => model.Name == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PoleType.Name == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PoleType.Name != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PoleType.Name.Length.ToString()) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PoleType.Name.Length.ToString()) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PoleType.Name.Length.ToString()) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PoleType.Name.Length.ToString()) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PoleType.Name == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PoleType.Name != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "PoleConditionId":
                            //aSearch.PoleConditionId = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr8 = model => model.PoleConditionId == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PoleConditionId == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PoleConditionId != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PoleConditionId) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PoleConditionId) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PoleConditionId) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PoleConditionId) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PoleConditionId == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PoleConditionId != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "MSJNo":
                            //aSearch.MSJNo = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr9 = model => model.MSJNo == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.MSJNo == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.MSJNo != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.MSJNo) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.MSJNo) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.MSJNo) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.MSJNo) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.MSJNo == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.MSJNo != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "SleeveNo":
                            //aSearch.SleeveNo = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr10 = model => model.SleeveNo == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.SleeveNo == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.SleeveNo != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.SleeveNo) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.SleeveNo) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.SleeveNo) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.SleeveNo) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.SleeveNo == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.SleeveNo != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "TwistNo":
                            //aSearch.TwistNo = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr11 = model => model.TwistNo == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.TwistNo == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.TwistNo != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.TwistNo) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.TwistNo) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.TwistNo) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.TwistNo) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.TwistNo == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.TwistNo != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "PhaseAId":
                            //aSearch.PhaseAId = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr12 = model => model.PhaseAId == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PhaseAId == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PhaseAId != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PhaseAId) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PhaseAId) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PhaseAId) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PhaseAId) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PhaseAId == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PhaseAId != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "PhaseBId":
                            //aSearch.PhaseBId = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr13 = model => model.PhaseBId == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PhaseBId == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PhaseBId != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PhaseBId) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PhaseBId) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PhaseBId) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PhaseBId) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PhaseBId == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PhaseBId != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "PhaseCId":
                            //aSearch.PhaseCId = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr14 = model => model.PhaseCId == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.PhaseCId == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.PhaseCId != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.PhaseCId) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.PhaseCId) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.PhaseCId) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.PhaseCId) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.PhaseCId == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.PhaseCId != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "Neutral":
                            //aSearch.Neutral = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr15 = model => model.Neutral == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.Neutral == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.Neutral != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.Neutral.Length.ToString()) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.Neutral.Length.ToString()) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.Neutral.Length.ToString()) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.Neutral.Length.ToString()) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.Neutral == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.Neutral != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;
                        case "StreetLight":
                            //aSearch.StreetLight = (FieldName1 == null ? null : FieldName1);
                            //Expression<Func<VwPoleData, Boolean>> expr16 = model => model.StreetLight == FieldValue1;
                            switch (Operator2)
                            {
                                case "=":
                                    expr2 = model => model.StreetLight == FieldValue2;
                                    break;
                                case "!=":
                                    expr2 = model => model.StreetLight != FieldValue2;
                                    break;
                                case ">":
                                    expr2 = model => int.Parse(model.StreetLight.Length.ToString()) > int.Parse(FieldValue2);
                                    break;
                                case "<":
                                    expr2 = model => int.Parse(model.StreetLight.Length.ToString()) < int.Parse(FieldValue2);
                                    break;
                                case ">=":
                                    expr2 = model => int.Parse(model.StreetLight.Length.ToString()) >= int.Parse(FieldValue2);
                                    break;
                                case "<=":
                                    expr2 = model => int.Parse(model.StreetLight.Length.ToString()) <= int.Parse(FieldValue2);
                                    break;
                                case "null":
                                    expr2 = model => model.StreetLight == null;
                                    break;
                                case "not null":
                                    expr2 = model => model.StreetLight != null;
                                    break;
                            }
                            result = AppendExpression(result, expr2, AndOr2);
                            break;

                            //case "SourceCableId":
                            //    //aSearch.SourceCableId = (FieldName1 == null ? null : FieldName1);
                            //    //Expression<Func<VwPoleData, Boolean>> expr17 = model => model.SourceCableId == FieldValue1;
                            //    switch (Operator2)
                            //    {
                            //        case "=":
                            //            expr2 = model => model.SourceCableId == FieldValue2;
                            //            break;
                            //        case "!=":
                            //            expr2 = model => model.SourceCableId != FieldValue2;
                            //            break;
                            //        case ">":
                            //            expr2 = model => int.Parse(model.SourceCableId) > int.Parse(FieldValue2);
                            //            break;
                            //        case "<":
                            //            expr2 = model => int.Parse(model.SourceCableId) < int.Parse(FieldValue2);
                            //            break;
                            //        case ">=":
                            //            expr2 = model => int.Parse(model.SourceCableId) >= int.Parse(FieldValue2);
                            //            break;
                            //        case "<=":
                            //            expr2 = model => int.Parse(model.SourceCableId) <= int.Parse(FieldValue2);
                            //            break;
                            //        case "null":
                            //            expr2 = model => model.SourceCableId == null;
                            //            break;
                            //        case "not null":
                            //            expr2 = model => model.SourceCableId != null;
                            //            break;
                            //    }
                            //    result = AppendExpression(result, expr2, AndOr2);
                            //    break;
                            //case "TargetCableId":
                            //    //aSearch.TargetCableId = (FieldName1 == null ? null : FieldName1);
                            //    //Expression<Func<VwPoleData, Boolean>> expr18 = model => model.TargetCableId == FieldValue1;
                            //    switch (Operator2)
                            //    {
                            //        case "=":
                            //            expr2 = model => model.TargetCableId == FieldValue2;
                            //            break;
                            //        case "!=":
                            //            expr2 = model => model.TargetCableId != FieldValue2;
                            //            break;
                            //        case ">":
                            //            expr2 = model => int.Parse(model.TargetCableId) > int.Parse(FieldValue2);
                            //            break;
                            //        case "<":
                            //            expr2 = model => int.Parse(model.TargetCableId) < int.Parse(FieldValue2);
                            //            break;
                            //        case ">=":
                            //            expr2 = model => int.Parse(model.TargetCableId) >= int.Parse(FieldValue2);
                            //            break;
                            //        case "<=":
                            //            expr2 = model => int.Parse(model.TargetCableId) <= int.Parse(FieldValue2);
                            //            break;
                            //        case "null":
                            //            expr2 = model => model.TargetCableId == null;
                            //            break;
                            //        case "not null":
                            //            expr2 = model => model.TargetCableId != null;
                            //            break;
                            //    }
                            //    result = AppendExpression(result, expr2, AndOr2);
                            //    break;

                            //case "Latitude":
                            //    //aSearch.Latitude = (FieldName1 == null ? null : FieldName1);
                            //    //Expression<Func<VwPoleData, Boolean>> expr19 = model => model.Latitude == FieldValue1;
                            //    switch (Operator2)
                            //    {
                            //        case "=":
                            //            expr2 = model => model.Latitude == FieldValue2;
                            //            break;
                            //        case "!=":
                            //            expr2 = model => model.Latitude != FieldValue2;
                            //            break;
                            //        case ">":
                            //            expr2 = model => decimal.Parse(model.Latitude) > decimal.Parse(FieldValue2);
                            //            break;
                            //        case "<":
                            //            expr2 = model => decimal.Parse(model.Latitude) < decimal.Parse(FieldValue2);
                            //            break;
                            //        case ">=":
                            //            expr2 = model => decimal.Parse(model.Latitude) >= decimal.Parse(FieldValue2);
                            //            break;
                            //        case "<=":
                            //            expr2 = model => decimal.Parse(model.Latitude) <= decimal.Parse(FieldValue2);
                            //            break;
                            //        case "null":
                            //            expr2 = model => model.Latitude == null;
                            //            break;
                            //        case "not null":
                            //            expr2 = model => model.Latitude != null;
                            //            break;
                            //    }
                            //    result = AppendExpression(result, expr2, AndOr2);
                            //    break;
                            //case "Longitude":
                            //    //aSearch.Longitude = (FieldName1 == null ? null : FieldName1);
                            //    //Expression<Func<VwPoleData, Boolean>> expr20 = model => model.Longitude == FieldValue1;
                            //    switch (Operator2)
                            //    {
                            //        case "=":
                            //            expr2 = model => model.Longitude == FieldValue2;
                            //            break;
                            //        case "!=":
                            //            expr2 = model => model.Longitude != FieldValue2;
                            //            break;
                            //        case ">":
                            //            expr2 = model => decimal.Parse(model.Longitude) > decimal.Parse(FieldValue2);
                            //            break;
                            //        case "<":
                            //            expr2 = model => decimal.Parse(model.Longitude) < decimal.Parse(FieldValue2);
                            //            break;
                            //        case ">=":
                            //            expr2 = model => decimal.Parse(model.Longitude) >= decimal.Parse(FieldValue2);
                            //            break;
                            //        case "<=":
                            //            expr2 = model => decimal.Parse(model.Longitude) <= decimal.Parse(FieldValue2);
                            //            break;
                            //        case "null":
                            //            expr2 = model => model.Longitude == null;
                            //            break;
                            //        case "not null":
                            //            expr2 = model => model.Longitude != null;
                            //            break;
                            //    }

                            //result = AppendExpression(result, expr2, AndOr2);
                            //break;
                    }


                    if (!string.IsNullOrEmpty(FieldName3))
                    {
                        Expression<Func<TblPole, Boolean>> expr3 = null;
                        switch (FieldName3)
                        {
                            case "PoleId":
                                //Expression<Func<VwPoleData, Boolean>> expr2 = null;                        
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PoleId == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PoleId != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PoleId) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PoleId) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PoleId) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PoleId) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PoleId == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PoleId != null;
                                        break;
                                }
                                //Expression<Func<VwPoleData, Boolean>> expr3 = model => model.PoleId == FieldValue3;    //  model => model.PoleId == FieldValue3;    CreateExpression(FieldName3, FieldValue3, Operator1);              //Operator1 == "=" ? model => model.PoleId == FieldValue1 : Operator1 == "!=" ? model => model.PoleId != FieldValue1 : Operator1 == ">" ? model => int.Parse(model.PoleId) > int.Parse(FieldValue1) : Operator1 == "<" ? model => int.Parse(model.PoleId) < int.Parse(FieldValue1) : Operator1 == ">=" ? model => int.Parse(model.PoleId) >= int.Parse(FieldValue1) : Operator1 == "<=" ? model => int.Parse(model.PoleId) <= int.Parse(FieldValue1) : Operator1 == "null" ? model => model.PoleId = null : Operator1 == "not null" ? model => model.PoleId != null : model => model.PoleId == FieldValue1;
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "FeederName":
                                //aSearch.FeederName = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr2 = model => model.FeederName == FieldValue1;
                                //Expression<Func<VwPoleData, Boolean>> expr2 = null;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PoleToFeederLine.FeederName == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PoleToFeederLine.FeederName != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PoleToFeederLine.FeederName.Length.ToString()) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PoleToFeederLine.FeederName.Length.ToString()) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PoleToFeederLine.FeederName.Length.ToString()) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PoleToFeederLine.FeederName.Length.ToString()) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PoleToFeederLine.FeederName == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PoleToFeederLine.FeederName != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "SurveyDate":
                                //aSearch.SurveyDate = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr3 = model => model.SurveyDate == FieldValue1;
                                //switch (Operator3)
                                //{
                                //    case "=":
                                //        expr3 = model => model.SurveyDate == FieldValue3;
                                //        break;
                                //    case "!=":
                                //        expr3 = model => model.SurveyDate != FieldValue3;
                                //        break;
                                //    case ">":
                                //        expr3 = model => DateTime.Parse(model.SurveyDate) > DateTime.Parse(FieldValue3);
                                //        break;
                                //    case "<":
                                //        expr3 = model => DateTime.Parse(model.SurveyDate) < DateTime.Parse(FieldValue3);
                                //        break;
                                //    case ">=":
                                //        expr3 = model => DateTime.Parse(model.SurveyDate) >= DateTime.Parse(FieldValue3);
                                //        break;
                                //    case "<=":
                                //        expr3 = model => DateTime.Parse(model.SurveyDate) <= DateTime.Parse(FieldValue3);
                                //        break;
                                //    case "null":
                                //        expr3 = model => model.SurveyDate == null;
                                //        break;
                                //    case "not null":
                                //        expr3 = model => model.SurveyDate != null;
                                //        break;
                                //}
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "RouteName":
                                //aSearch.RouteName = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr4 = model => model.RouteName == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PoleToRoute.RouteName == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PoleToRoute.RouteName != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PoleToRoute.RouteName.Length.ToString()) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PoleToRoute.RouteName.Length.ToString()) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PoleToRoute.RouteName.Length.ToString()) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PoleToRoute.RouteName.Length.ToString()) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PoleToRoute.RouteName == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PoleToRoute.RouteName != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "PoleNo":
                                //aSearch.PoleNo = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr5 = model => model.PoleNo == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PoleNo == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PoleNo != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PoleNo.Length.ToString()) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PoleNo.Length.ToString()) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PoleNo.Length.ToString()) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PoleNo.Length.ToString()) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PoleNo == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PoleNo != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "PreviousPoleNo":
                                //aSearch.PreviousPoleNo = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr6 = model => model.PreviousPoleNo == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PreviousPoleNo == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PreviousPoleNo != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PreviousPoleNo.Length.ToString()) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PreviousPoleNo == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PreviousPoleNo != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "Name":
                                //aSearch.Name = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr7 = model => model.Name == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PoleType.Name == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PoleType.Name != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PoleType.Name.Length.ToString()) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PoleType.Name.Length.ToString()) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PoleType.Name.Length.ToString()) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PoleType.Name.Length.ToString()) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PoleType.Name == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PoleType.Name != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "PoleConditionId":
                                //aSearch.PoleConditionId = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr8 = model => model.PoleConditionId == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PoleConditionId == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PoleConditionId != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PoleConditionId) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PoleConditionId) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PoleConditionId) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PoleConditionId) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PoleConditionId == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PoleConditionId != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "MSJNo":
                                //aSearch.MSJNo = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr9 = model => model.MSJNo == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.MSJNo == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.MSJNo != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.MSJNo) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.MSJNo) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.MSJNo) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.MSJNo) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.MSJNo == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.MSJNo != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "SleeveNo":
                                //aSearch.SleeveNo = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr10 = model => model.SleeveNo == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.SleeveNo == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.SleeveNo != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.SleeveNo) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.SleeveNo) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.SleeveNo) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.SleeveNo) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.SleeveNo == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.SleeveNo != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "TwistNo":
                                //aSearch.TwistNo = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr11 = model => model.TwistNo == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.TwistNo == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.TwistNo != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.TwistNo) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.TwistNo) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.TwistNo) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.TwistNo) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.TwistNo == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.TwistNo != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "PhaseAId":
                                //aSearch.PhaseAId = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr12 = model => model.PhaseAId == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PhaseAId == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PhaseAId != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PhaseAId) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PhaseAId) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PhaseAId) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PhaseAId) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PhaseAId == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PhaseAId != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "PhaseBId":
                                //aSearch.PhaseBId = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr13 = model => model.PhaseBId == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PhaseBId == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PhaseBId != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PhaseBId) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PhaseBId) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PhaseBId) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PhaseBId) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PhaseBId == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PhaseBId != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "PhaseCId":
                                //aSearch.PhaseCId = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr14 = model => model.PhaseCId == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.PhaseCId == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.PhaseCId != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.PhaseCId) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.PhaseCId) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.PhaseCId) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.PhaseCId) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.PhaseCId == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.PhaseCId != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "Neutral":
                                //aSearch.Neutral = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr15 = model => model.Neutral == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.Neutral == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.Neutral != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.Neutral.Length.ToString()) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.Neutral.Length.ToString()) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.Neutral.Length.ToString()) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.Neutral.Length.ToString()) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.Neutral == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.Neutral != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;
                            case "StreetLight":
                                //aSearch.StreetLight = (FieldName1 == null ? null : FieldName1);
                                //Expression<Func<VwPoleData, Boolean>> expr16 = model => model.StreetLight == FieldValue1;
                                switch (Operator3)
                                {
                                    case "=":
                                        expr3 = model => model.StreetLight == FieldValue3;
                                        break;
                                    case "!=":
                                        expr3 = model => model.StreetLight != FieldValue3;
                                        break;
                                    case ">":
                                        expr3 = model => int.Parse(model.StreetLight.Length.ToString()) > int.Parse(FieldValue3);
                                        break;
                                    case "<":
                                        expr3 = model => int.Parse(model.StreetLight.Length.ToString()) < int.Parse(FieldValue3);
                                        break;
                                    case ">=":
                                        expr3 = model => int.Parse(model.StreetLight.Length.ToString()) >= int.Parse(FieldValue3);
                                        break;
                                    case "<=":
                                        expr3 = model => int.Parse(model.StreetLight.Length.ToString()) <= int.Parse(FieldValue3);
                                        break;
                                    case "null":
                                        expr3 = model => model.StreetLight == null;
                                        break;
                                    case "not null":
                                        expr3 = model => model.StreetLight != null;
                                        break;
                                }
                                result = AppendExpression(result, expr3, AndOr3);
                                break;


                                //case "SourceCableId":
                                //    //aSearch.SourceCableId = (FieldName1 == null ? null : FieldName1);
                                //    //Expression<Func<VwPoleData, Boolean>> expr17 = model => model.SourceCableId == FieldValue1;
                                //    switch (Operator3)
                                //    {
                                //        case "=":
                                //            expr3 = model => model.SourceCableId == FieldValue3;
                                //            break;
                                //        case "!=":
                                //            expr3 = model => model.SourceCableId != FieldValue3;
                                //            break;
                                //        case ">":
                                //            expr3 = model => int.Parse(model.SourceCableId) > int.Parse(FieldValue3);
                                //            break;
                                //        case "<":
                                //            expr3 = model => int.Parse(model.SourceCableId) < int.Parse(FieldValue3);
                                //            break;
                                //        case ">=":
                                //            expr3 = model => int.Parse(model.SourceCableId) >= int.Parse(FieldValue3);
                                //            break;
                                //        case "<=":
                                //            expr3 = model => int.Parse(model.SourceCableId) <= int.Parse(FieldValue3);
                                //            break;
                                //        case "null":
                                //            expr3 = model => model.SourceCableId == null;
                                //            break;
                                //        case "not null":
                                //            expr3 = model => model.SourceCableId != null;
                                //            break;
                                //    }
                                //    result = AppendExpression(result, expr3, AndOr3);
                                //    break;
                                //case "TargetCableId":
                                //    //aSearch.TargetCableId = (FieldName1 == null ? null : FieldName1);
                                //    //Expression<Func<VwPoleData, Boolean>> expr18 = model => model.TargetCableId == FieldValue1;
                                //    switch (Operator3)
                                //    {
                                //        case "=":
                                //            expr3 = model => model.TargetCableId == FieldValue3;
                                //            break;
                                //        case "!=":
                                //            expr3 = model => model.TargetCableId != FieldValue3;
                                //            break;
                                //        case ">":
                                //            expr3 = model => int.Parse(model.TargetCableId) > int.Parse(FieldValue3);
                                //            break;
                                //        case "<":
                                //            expr3 = model => int.Parse(model.TargetCableId) < int.Parse(FieldValue3);
                                //            break;
                                //        case ">=":
                                //            expr3 = model => int.Parse(model.TargetCableId) >= int.Parse(FieldValue3);
                                //            break;
                                //        case "<=":
                                //            expr3 = model => int.Parse(model.TargetCableId) <= int.Parse(FieldValue3);
                                //            break;
                                //        case "null":
                                //            expr3 = model => model.TargetCableId == null;
                                //            break;
                                //        case "not null":
                                //            expr3 = model => model.TargetCableId != null;
                                //            break;
                                //    }
                                //    result = AppendExpression(result, expr3, AndOr3);
                                //    break;


                                //case "Latitude":
                                //    //aSearch.Latitude = (FieldName1 == null ? null : FieldName1);
                                //    //Expression<Func<VwPoleData, Boolean>> expr19 = model => model.Latitude == FieldValue1;
                                //    switch (Operator3)
                                //    {
                                //        case "=":
                                //            expr3 = model => model.Latitude == FieldValue3;
                                //            break;
                                //        case "!=":
                                //            expr3 = model => model.Latitude != FieldValue3;
                                //            break;
                                //        case ">":
                                //            expr3 = model => decimal.Parse(model.Latitude) > decimal.Parse(FieldValue3);
                                //            break;
                                //        case "<":
                                //            expr3 = model => decimal.Parse(model.Latitude) < decimal.Parse(FieldValue3);
                                //            break;
                                //        case ">=":
                                //            expr3 = model => decimal.Parse(model.Latitude) >= decimal.Parse(FieldValue3);
                                //            break;
                                //        case "<=":
                                //            expr3 = model => decimal.Parse(model.Latitude) <= decimal.Parse(FieldValue3);
                                //            break;
                                //        case "null":
                                //            expr3 = model => model.Latitude == null;
                                //            break;
                                //        case "not null":
                                //            expr3 = model => model.Latitude != null;
                                //            break;
                                //    }
                                //    result = AppendExpression(result, expr3, AndOr3);
                                //    break;
                                //case "Longitude":
                                //    //aSearch.Longitude = (FieldName1 == null ? null : FieldName1);
                                //    //Expression<Func<VwPoleData, Boolean>> expr20 = model => model.Longitude == FieldValue1;
                                //    switch (Operator3)
                                //    {
                                //        case "=":
                                //            expr3 = model => model.Longitude == FieldValue3;
                                //            break;
                                //        case "!=":
                                //            expr3 = model => model.Longitude != FieldValue3;
                                //            break;
                                //        case ">":
                                //            expr3 = model => decimal.Parse(model.Longitude) > decimal.Parse(FieldValue3);
                                //            break;
                                //        case "<":
                                //            expr3 = model => decimal.Parse(model.Longitude) < decimal.Parse(FieldValue3);
                                //            break;
                                //        case ">=":
                                //            expr3 = model => decimal.Parse(model.Longitude) >= decimal.Parse(FieldValue3);
                                //            break;
                                //        case "<=":
                                //            expr3 = model => decimal.Parse(model.Longitude) <= decimal.Parse(FieldValue3);
                                //            break;
                                //        case "null":
                                //            expr3 = model => model.Longitude == null;
                                //            break;
                                //        case "not null":
                                //            expr3 = model => model.Longitude != null;
                                //            break;
                                //    }

                                //    result = AppendExpression(result, expr3, AndOr3);
                                //    break;
                        }
                        /*
                        switch (FieldName3)
                        {
                            case "PoleId":
                                //aSearch.PoleId = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr01 = model => model.PoleId == FieldValue3;
                                result = AppendExpression(result, expr1, "ALL");
                                break;
                            case "FeederName":
                                //aSearch.FeederName = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr2 = model => model.FeederName == FieldValue3;
                                result = AppendExpression(result, expr2, "ALL");
                                break;
                            case "SurveyDate":
                                //aSearch.SurveyDate = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr3 = model => model.SurveyDate == FieldValue3;
                                result = AppendExpression(result, expr3, "ALL");
                                break;
                            case "RouteName":
                                //aSearch.RouteName = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr4 = model => model.RouteName == FieldValue3;
                                result = AppendExpression(result, expr4, "ALL");
                                break;
                            case "PoleNo":
                                //aSearch.PoleNo = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr5 = model => model.PoleNo == FieldValue3;
                                result = AppendExpression(result, expr5, "ALL");
                                break;
                            case "PreviousPoleNo":
                                //aSearch.PreviousPoleNo = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr6 = model => model.PreviousPoleNo == FieldValue3;
                                result = AppendExpression(result, expr6, "ALL");
                                break;
                            case "Name":
                                //aSearch.Name = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr7 = model => model.Name == FieldValue3;
                                result = AppendExpression(result, expr7, "ALL");
                                break;
                            case "PoleConditionId":
                                //aSearch.PoleConditionId = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr8 = model => model.PoleConditionId == FieldValue3;
                                result = AppendExpression(result, expr8, "ALL");
                                break;
                            case "MSJNo":
                                //aSearch.MSJNo = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr9 = model => model.MSJNo == FieldValue3;
                                result = AppendExpression(result, expr9, "ALL");
                                break;
                            case "SleeveNo":
                                //aSearch.SleeveNo = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr10 = model => model.SleeveNo == FieldValue3;
                                result = AppendExpression(result, expr10, "ALL");
                                break;
                            case "TwistNo":
                                //aSearch.TwistNo = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr11 = model => model.TwistNo == FieldValue3;
                                result = AppendExpression(result, expr11, "ALL");
                                break;
                            case "PhaseAId":
                                //aSearch.PhaseAId = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr12 = model => model.PhaseAId == FieldValue3;
                                result = AppendExpression(result, expr12, "ALL");
                                break;
                            case "PhaseBId":
                                //aSearch.PhaseBId = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr13 = model => model.PhaseBId == FieldValue3;
                                result = AppendExpression(result, expr13, "ALL");
                                break;
                            case "PhaseCId":
                                //aSearch.PhaseCId = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr14 = model => model.PhaseCId == FieldValue3;
                                result = AppendExpression(result, expr14, "ALL");
                                break;
                            case "Neutral":
                                //aSearch.Neutral = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr15 = model => model.Neutral == FieldValue3;
                                result = AppendExpression(result, expr15, "ALL");
                                break;
                            case "StreetLight":
                                //aSearch.StreetLight = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr16 = model => model.StreetLight == FieldValue3;
                                result = AppendExpression(result, expr16, "ALL");
                                break;
                            case "SourceCableId":
                                //aSearch.SourceCableId = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr17 = model => model.SourceCableId == FieldValue3;
                                result = AppendExpression(result, expr17, "ALL");
                                break;
                            case "TargetCableId":
                                //aSearch.TargetCableId = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr18 = model => model.TargetCableId == FieldValue3;
                                result = AppendExpression(result, expr18, "ALL");
                                break;
                            case "Latitude":
                                //aSearch.Latitude = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr19 = model => model.Latitude == FieldValue3;
                                result = AppendExpression(result, expr19, "ALL");
                                break;
                            case "Longitude":
                                //aSearch.Longitude = (FieldName1 == null ? null : FieldName1);
                                Expression<Func<VwPoleData, Boolean>> expr20 = model => model.Longitude == FieldValue3;
                                result = AppendExpression(result, expr20, "ALL");
                                break;

                                // ,,,,,
                        }
                        */
                    }



                }



                //var ab = new TblPole();
                //var ab1 = new ModelBuilder("TblPole");

                //ab.

                var qry = _context.TblPole.AsNoTracking()
                    .Include(pi => pi.PoleToFeederLine)
                    .Include(pi => pi.PoleToRoute)
                    .Include(pi => pi.PoleType)
                    .Include(pi => pi.PoleCondition)
                    //.Include(pi => pi.PoleToSourceFeederLine)
                    //.Include(pi => pi.PoleToTargetFeederLine)
                    .AsQueryable();

                qry = qry.Where(result);

                var finalResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

                //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

                //ViewData["FieldName"] = new SelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");
                //ViewBag.FieldNameList = new MultiSelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");

                return View(finalResult);
            }
            else
            {
                var qry = _context.TblPole.AsNoTracking()
                    .Include(pi => pi.PoleToFeederLine)
                    .Include(pi => pi.PoleToRoute)
                    .Include(pi => pi.PoleType)
                    .Include(pi => pi.PoleCondition)
                    //.Include(pi => pi.PoleToSourceFeederLine)
                    //.Include(pi => pi.PoleToTargetFeederLine)
                    .AsQueryable();

                //qry = qry.Where(result);

                var finalResult = await PagingList.CreateAsync(qry, 10, pageIndex, sort, "PoleId");

                //model.RouteValue = new RouteValueDictionary { { "filter", filter } };

                //ViewData["FieldName"] = new SelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");
                //ViewBag.FieldNameList = new MultiSelectList(_context.TblCustomSearchFields, "FieldName", "FieldDescription");

                return View(finalResult);
            }


        }

    }
}