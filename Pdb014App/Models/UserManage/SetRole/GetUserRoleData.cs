using Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB;
using Pdb014App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Pdb014App.Models.PDB.SubstationModels;
using Microsoft.AspNetCore.Authorization;
using NPOI.SS.Formula.Functions;
using NuGet.Frameworks;

namespace Pdb014App.Models.UserManage.SetRole
{
    public class GetUserRoleData : Controller
    {
        public  UserManager<TblUserRegistrationDetail> _userManager;
        public  UserDbContext _contextUser;

        public GetUserRoleData(UserDbContext contextUser, UserManager<TblUserRegistrationDetail> UserManager)
        {
            _contextUser = contextUser;
            _userManager = UserManager;
        }

        public string GetUserRoleWiseQuery(string userRole, string regionCode, string tableName, string queryFieldName, List<string> fieldList)
        {
            string fields = fieldList == null
                ? "*"
                : string.Join(",", fieldList.RemoveAll(string.IsNullOrEmpty));

            fields = fields.Remove(',').Equals("") ? "*" : fields;


            string retSql = "";

            switch (userRole.Trim().ToLower())
            {
                case "system":
                case "administrator":
                    retSql = $"SELECT {fields} FROM {tableName}";
                    break;

                case "zone":
                    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 1) = {regionCode}";
                    break;

                case "circle":
                    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 3) = {regionCode}";
                    break;

                case "snd":
                    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 5) = {regionCode}";
                    break;

                case "substation":
                    retSql = $"Select * from {tableName} where SUBSTRING({queryFieldName}, 1, 7) = {regionCode}";
                    break;

                default:
                    retSql = null;
                    break;
            }

            //if (User.IsInRole("System Administrator"))
            //{
            //    retSql = $"SELECT {fields} FROM {tableName}";
            //}
            //else if (User.IsInRole("Zone"))
            //{
            //    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 1) = {regionCode}";
            //}
            //else if (User.IsInRole("Circle"))
            //{
            //    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 3) = {regionCode}";
            //}
            //else if (User.IsInRole("SnD"))
            //{
            //    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 5) = {regionCode}";
            //}
            //else if (User.IsInRole("Substation"))
            //{
            //    retSql = $"Select * from {tableName} where SUBSTRING({queryFieldName}, 1, 7) = {regionCode}";
            //}
            //else
            //{
            //    return null;
            //}

            return retSql;
        }
                      
        public string GetUserRoleWiseQuery(string userRole, List<string> regionList, string tableName, string queryFieldName, List<string> fieldList)
        {
            string fields = fieldList == null
                ? "*"
                : string.Join(",", fieldList.RemoveAll(string.IsNullOrEmpty));

            fields = fields.Remove(',').Equals("") ? "*" : fields;


            string retSql = "", zoneCode = "", circleCode = "", sndCode = "", substationId = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        sndCode = regionList[2];

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationId = regionList[3];
                        }
                    }
                }
            }


            switch (userRole.Trim().ToLower())
            {
                case "system":
                case "administrator":
                    retSql = $"SELECT {fields} FROM {tableName}";
                    break;

                case "zone":
                    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 1) = {zoneCode}";
                    break;

                case "circle":
                    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 3) = {circleCode}";
                    break;

                case "snd":
                    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 5) = {sndCode}";
                    break;

                case "substation":
                    retSql = $"Select * from {tableName} where SUBSTRING({queryFieldName}, 1, 7) = {substationId}";
                    break;

                default:
                    retSql = null;
                    break;
            }


            //if (User.IsInRole("System Administrator"))
            //{
            //    retSql = $"SELECT {fields} FROM {tableName}";
            //}
            //else if (User.IsInRole("Zone"))
            //{
            //    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 1) = {zoneCode}";
            //}
            //else if (User.IsInRole("Circle"))
            //{
            //    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 3) = {circleCode}";
            //}
            //else if (User.IsInRole("SnD"))
            //{
            //    retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 5) = {sndCode}";
            //}
            //else if (User.IsInRole("Substation"))
            //{
            //    retSql = $"Select * from {tableName} where SUBSTRING({queryFieldName}, 1, 7) = {substationId}";
            //}
            //else
            //{
            //    return null;
            //}

            return retSql;
        }



        #region 
        //public string List<T>(string modelName, string property1, string property2)
        //{

        //    string model = "TblPole";
        //    string pro = "PoleId";

        //    ParameterExpression argParam = Expression.Parameter(typeof(T), model);



        //    Expression nameProperty = Expression.Property(argParam, pro);


        //    Expression namespaceProperty = Expression.Property(argParam, property2);

        //    var val1 = Expression.Constant("Modules");
        //    var val2 = Expression.Constant("Namespace");
        //    Expression e1 = Expression.Equal(nameProperty, val1);
        //    Expression e2 = Expression.Equal(namespaceProperty, val2);
        //    var andExp = Expression.AndAlso(e1, e2);


        //    Expression<Func<T, bool>> searchExp = null;




        //    //var qry = searchExp != null ? _context.+<argParam>+model.Where(searchExp).Include(t => t.LookUpLineType).Include(t => t.LookUpTypeOfWire).Include(t => t.PhaseACondition).Include(t => t.PhaseBCondition).Include(t => t.PhaseCCondition).Include(t => t.PoleCondition).Include(t => t.PoleToFeederLine).Include(t => t.PoleToRoute).Include(t => t.PoleType).Include(t => t.WireLookUpCondition).AsQueryable() :
        //    //                             _context.TblPole.Include(t => t.LookUpLineType).Include(t => t.LookUpTypeOfWire).Include(t => t.PhaseACondition).Include(t => t.PhaseBCondition).Include(t => t.PhaseCCondition).Include(t => t.PoleCondition).Include(t => t.PoleToFeederLine).Include(t => t.PoleToRoute).Include(t => t.PoleType).Include(t => t.WireLookUpCondition).AsQueryable();


        //    return "dfsd";

        //   

        //    //if (modelName == "TblSubstation")
        //    //{
        //    //    Expression<Func<TblSubstation, bool>> searchExp = null;
        //    //    Expression<Func<TblSubstation, bool>> tempExp = null;

        //    //}
        //    //else if ((modelName == "TblPole"))
        //    //{
        //    //    Expression<Func<TblSubstation, bool>> searchExp = null;
        //    //    Expression<Func<TblSubstation, bool>> tempExp = null;
        //    //}

        //    //var user = await _userManger.GetUserAsync(User);




        //    //if (User.IsInRole("System Administrator"))
        //    //{
        //    //    searchExp = null;
        //    //}

        //    //else if ((User.IsInRole("Super User") && User.IsInRole("Zone")) || User.IsInRole("Zone"))
        //    //{
        //    //    var user = await _userManger.GetUserAsync(User);
        //    //    string zoneCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.ZoneCode).SingleOrDefault();
        //    //    searchExp = i => i.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneCode == zoneCode;
        //    //}
        //    //else if ((User.IsInRole("Super User") && User.IsInRole("Circle")) || User.IsInRole("Circle"))
        //    //{
        //    //    var user = await _userManger.GetUserAsync(User);
        //    //    string circleCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.CircleCode).SingleOrDefault();
        //    //    searchExp = i => i.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.CircleCode == circleCode;

        //    //    searchExp = i => i.PoleId.Substring(0, 1) == circleCode;
        //    //}
        //    //else if ((User.IsInRole("Super User") && User.IsInRole("SnD")) || User.IsInRole("SnD"))
        //    //{
        //    //    var user = await _userManger.GetUserAsync(User);
        //    //    string sndCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SnDCode).SingleOrDefault();
        //    //    searchExp = i => i.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDCode == sndCode;

        //    //}
        //    //else if ((User.IsInRole("Super User") && User.IsInRole("Substation")) || User.IsInRole("Substation"))
        //    //{
        //    //    var user = await _userManger.GetUserAsync(User);
        //    //    string SubstationId = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SubstationId).SingleOrDefault();
        //    //    searchExp = i => i.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationId == SubstationId;

        //    //}
        //    //else
        //    //{
        //    //    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
        //    //}


        //    //if (filter != null)
        //    //{
        //    //    tempExp = p => p.PoleId.Contains(filter);
        //    //    searchExp = ExpressionExtension<TblPole>.AndAlso(searchExp, tempExp);
        //    //}
        //   
        //}
        #endregion

    }
}
