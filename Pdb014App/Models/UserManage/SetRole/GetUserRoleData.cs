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

        [Authorize(Roles = "System Administrator,Super User,Zone,Circle,SnD,Substation")]
        public async Task<string> GetQuery(string tableName, string fieldName)
        {
            //this.userManager = UserManager;
            var user = await _userManager.GetUserAsync(User);


            var sql = "";

            if (User.IsInRole("System Administrator"))
            {
                sql = $"Select * from  {tableName}";
            }

            else if ((User.IsInRole("Super User") && User.IsInRole("Zone")) || User.IsInRole("Zone"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string zoneCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.ZoneCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,1)={zoneCode}";

            }
            else if ((User.IsInRole("Super User") && User.IsInRole("Circle")) || User.IsInRole("Circle"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string circleCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.CircleCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,3)={circleCode}";
            }
            else if ((User.IsInRole("Super User") && User.IsInRole("SnD")) || User.IsInRole("SnD"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string sndCode = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SnDCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,5)={sndCode}";

            }
            else if ((User.IsInRole("Super User") && User.IsInRole("Substation")) || User.IsInRole("Substation"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string SubstationId = _contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SubstationId).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,7)={SubstationId}";

            }
            else
            {
                return null;
            }

            return sql;
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

        //    //var user = await UserManager.GetUserAsync(User);




        //    //if (User.IsInRole("System Administrator"))
        //    //{
        //    //    searchExp = null;
        //    //}

        //    //else if ((User.IsInRole("Super User") && User.IsInRole("Zone")) || User.IsInRole("Zone"))
        //    //{
        //    //    var user = await UserManager.GetUserAsync(User);
        //    //    string zoneCode = contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.ZoneCode).SingleOrDefault();
        //    //    searchExp = i => i.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneCode == zoneCode;
        //    //}
        //    //else if ((User.IsInRole("Super User") && User.IsInRole("Circle")) || User.IsInRole("Circle"))
        //    //{
        //    //    var user = await UserManager.GetUserAsync(User);
        //    //    string circleCode = contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.CircleCode).SingleOrDefault();
        //    //    searchExp = i => i.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.CircleCode == circleCode;

        //    //    searchExp = i => i.PoleId.Substring(0, 1) == circleCode;
        //    //}
        //    //else if ((User.IsInRole("Super User") && User.IsInRole("SnD")) || User.IsInRole("SnD"))
        //    //{
        //    //    var user = await UserManager.GetUserAsync(User);
        //    //    string sndCode = contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SnDCode).SingleOrDefault();
        //    //    searchExp = i => i.PoleToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDCode == sndCode;

        //    //}
        //    //else if ((User.IsInRole("Super User") && User.IsInRole("Substation")) || User.IsInRole("Substation"))
        //    //{
        //    //    var user = await UserManager.GetUserAsync(User);
        //    //    string SubstationId = contextUser.UserProfileDetail.Where(i => i.Id == user.Id).Select(i => i.SubstationId).SingleOrDefault();
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
