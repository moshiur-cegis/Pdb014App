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


        public string GetUserRoleWiseQuery(string tableName, string fieldName, string userId, IList<string> userRole)
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

        public IActionResult Index()
        {
            return View();
        }
    }
}