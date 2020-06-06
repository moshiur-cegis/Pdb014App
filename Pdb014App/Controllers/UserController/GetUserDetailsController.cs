using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pdb014App.Models.UserManage;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.UserController
{
    public class GetUserDetailsController : Controller
    {

        public UserDbContext _contextUser;

        public GetUserDetailsController(UserDbContext contextUser)
        {
            _contextUser = contextUser;
        }


        public async Task<string> GetUserRoleWiseQuery(string tableName, string fieldName,string userId, IList<string> userRole)
        {


            var sql = "";
            if (userRole.Contains("System Administrator"))
            {
                sql = $"Select * from  {tableName}";
            }

            else if (userRole.Contains("Zone"))
            {
                string zoneCode = _contextUser.UserProfileDetail.Where(i => i.Id == userId).Select(i => i.ZoneCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,1)={zoneCode}";

            }
            else if (userRole.Contains("Circle"))
            {
                string circleCode = _contextUser.UserProfileDetail.Where(i => i.Id == userId).Select(i => i.CircleCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,3)={circleCode}";
            }
            else if (userRole.Contains("SnD"))
            {
                string sndCode = _contextUser.UserProfileDetail.Where(i => i.Id == userId).Select(i => i.SnDCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,5)={sndCode}";

            }
            else if (userRole.Contains("Substation"))
            {
                string SubstationId = _contextUser.UserProfileDetail.Where(i => i.Id == userId).Select(i => i.SubstationId).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({fieldName},1,7)={SubstationId}";
            }
            else
            {
                return null;
            }

            return sql;



        }

        //public string GetUserRoleWiseQuery(string userRole, List<string> regionList, string tableName, string queryFieldName, List<string> fieldList)
        //{
        //    string fields = fieldList == null
        //        ? "*"
        //        : string.Join(",", fieldList.RemoveAll(string.IsNullOrEmpty));

        //    fields = fields.Remove(',').Equals("") ? "*" : fields;


        //    string retSql = "", zoneCode = "", circleCode = "", sndCode = "", substationId = "";

        //    if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
        //    {
        //        zoneCode = regionList[0];

        //        if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
        //        {
        //            circleCode = regionList[1];

        //            if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
        //            {
        //                sndCode = regionList[2];

        //                if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
        //                {
        //                    substationId = regionList[3];
        //                }
        //            }
        //        }
        //    }


        //    switch (userRole.Trim().ToLower())
        //    {
        //        case "system":
        //        case "administrator":
        //            retSql = $"SELECT {fields} FROM {tableName}";
        //            break;

        //        case "zone":
        //            retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 1) = {zoneCode}";
        //            break;

        //        case "circle":
        //            retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 3) = {circleCode}";
        //            break;

        //        case "snd":
        //            retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 5) = {sndCode}";
        //            break;

        //        case "substation":
        //            retSql = $"Select * from {tableName} where SUBSTRING({queryFieldName}, 1, 7) = {substationId}";
        //            break;

        //        default:
        //            retSql = null;
        //            break;
        //    }


        //    if (User.IsInRole("System Administrator"))
        //    {
        //        retSql = $"SELECT {fields} FROM {tableName}";
        //    }
        //    else if (User.IsInRole("Zone"))
        //    {
        //        retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 1) = {zoneCode}";
        //    }
        //    else if (User.IsInRole("Circle"))
        //    {
        //        retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 3) = {circleCode}";
        //    }
        //    else if (User.IsInRole("SnD"))
        //    {
        //        retSql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 5) = {sndCode}";
        //    }
        //    else if (User.IsInRole("Substation"))
        //    {
        //        retSql = $"Select * from {tableName} where SUBSTRING({queryFieldName}, 1, 7) = {substationId}";
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    return retSql;
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}