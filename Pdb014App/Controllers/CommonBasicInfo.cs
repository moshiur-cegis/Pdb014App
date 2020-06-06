using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.UserManage;
using Pdb014App.Repository;


namespace Pdb014App.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CommonBasicInfo : Controller
    {
        private readonly PdbDbContext _dbContext;
        private readonly UserDbContext _dbContextUser;
        private readonly UserManager<TblUserRegistrationDetail> _userManager;


        public CommonBasicInfo(PdbDbContext context)
        {
            _dbContext = context;
        }

        public CommonBasicInfo(PdbDbContext context, UserDbContext contextUser)
        {
            _dbContext = context;
            _dbContextUser = contextUser;
        }

        public CommonBasicInfo(PdbDbContext context, UserDbContext contextUser, UserManager<TblUserRegistrationDetail> userManager)
        {
            _dbContext = context;
            _dbContextUser = contextUser;
            _userManager = userManager;
        }

        
        public string GetUserRoleWiseQuery(string userId, string tableName, string queryFieldName)
        {
            //var user = await UserManager.GetUserAsync(User);

            string sql = "";

            if (User.IsInRole("System Administrator"))
            {
                sql = $"Select * from  {tableName}";
            }


            else if ((User.IsInRole("Super User") && User.IsInRole("Zone")) || User.IsInRole("Zone"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string zoneCode = _dbContextUser.UserProfileDetail.Where(u => u.Id == userId).Select(u => u.ZoneCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({queryFieldName}, 1, 1) = {zoneCode}";

            }
            else if ((User.IsInRole("Super User") && User.IsInRole("Circle")) || User.IsInRole("Circle"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string circleCode = _dbContextUser.UserProfileDetail.Where(u => u.Id == userId).Select(u => u.CircleCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({queryFieldName}, 1, 3) = {circleCode}";
            }
            else if ((User.IsInRole("Super User") && User.IsInRole("SnD")) || User.IsInRole("SnD"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string sndCode = _dbContextUser.UserProfileDetail.Where(u => u.Id == userId).Select(u => u.SnDCode).SingleOrDefault();
                sql = $"Select * from  {tableName} where SUBSTRING({queryFieldName}, 1, 5) = {sndCode}";

            }
            else if ((User.IsInRole("Super User") && User.IsInRole("Substation")) || User.IsInRole("Substation"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string substationId = _dbContextUser.UserProfileDetail.Where(u => u.Id == userId).Select(u => u.SubstationId).SingleOrDefault();
                sql = $"Select * from {tableName} where SUBSTRING({queryFieldName}, 1, 7) = {substationId}";

            }
            else
            {
                return null;
            }

            return sql;
        }

        public string GetUserRoleWiseQuery(string userId, string tableName, string queryFieldName, List<string> fieldList)
        {
            //var user = await UserManager.GetUserAsync(User);

            string sql = "";
            //fieldList == fieldList.RemoveAll(string.IsNullOrEmpty);
            string fields = fieldList == null
                ? "*"
                : string.Join(",", fieldList.RemoveAll(string.IsNullOrEmpty));

            fields = fields.Remove(',').Equals("") ? "*" : fields;

            if (User.IsInRole("System Administrator"))
            {
                sql = $"SELECT {fields} FROM {tableName}";
            }


            else if ((User.IsInRole("Super User") && User.IsInRole("Zone")) || User.IsInRole("Zone"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string zoneCode = _dbContextUser.UserProfileDetail.Where(u => u.Id == userId).Select(u => u.ZoneCode).SingleOrDefault();
                sql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 1) = {zoneCode}";

            }
            else if ((User.IsInRole("Super User") && User.IsInRole("Circle")) || User.IsInRole("Circle"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string circleCode = _dbContextUser.UserProfileDetail.Where(u => u.Id == userId).Select(u => u.CircleCode).SingleOrDefault();
                sql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 3) = {circleCode}";
            }
            else if ((User.IsInRole("Super User") && User.IsInRole("SnD")) || User.IsInRole("SnD"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string sndCode = _dbContextUser.UserProfileDetail.Where(u => u.Id == userId).Select(u => u.SnDCode).SingleOrDefault();
                sql = $"SELECT {fields} FROM {tableName} WHERE SUBSTRING({queryFieldName}, 1, 5) = {sndCode}";

            }
            else if ((User.IsInRole("Super User") && User.IsInRole("Substation")) || User.IsInRole("Substation"))
            {
                //var user = await UserManager.GetUserAsync(User);
                string substationId = _dbContextUser.UserProfileDetail.Where(u => u.Id == userId).Select(u => u.SubstationId).SingleOrDefault();
                sql = $"Select * from {tableName} where SUBSTRING({queryFieldName}, 1, 7) = {substationId}";
            }
            else
            {
                return null;
            }

            return sql;
        }



        public string GetUserRoleWiseQueryX(string userRole, string regionCode, string tableName, string queryFieldName, List<string> fieldList)
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





















        //[HttpGet("search/{fieldInfo}")]
        //[Consumes("application/json")]
        public async Task<ActionResult> Search(string fieldInfo)
        {
            if (string.IsNullOrEmpty(fieldInfo))
                return Ok(null);

            string fieldName, tableName = "";
            if (fieldInfo.Contains('.'))
            {
                fieldName = fieldInfo.Split('.').Length > 2 ? fieldInfo.Split('.')[2] : fieldInfo.Split('.')[1];
                //tableName = GetDataTableFullName(fieldInfo.Split('.')[0]);
                //tableName = fieldInfo.Split('.')[0];
            }
            else
            {
                fieldName = fieldInfo;
                //tableName = GetDataTableName(fieldName);
            }

            if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(tableName))
                return Ok(null);

            var sql = fieldName.Contains("Date")
                ? $"SELECT TOP 5000 ROW_NUMBER() OVER (ORDER BY {fieldName}) AS SlNo, CONVERT(VARCHAR, {fieldName}, 105) AS Term FROM {tableName}"
                : $"SELECT TOP 5000 ROW_NUMBER() OVER (ORDER BY {fieldName}) AS SlNo, CAST({fieldName} AS VARCHAR(500)) AS Term FROM {tableName}";

            //: $"SELECT ROW_NUMBER() OVER (ORDER BY {fieldName}) AS SlNo, CONVERT(VARCHAR(100), {fieldName}, 105) AS Term FROM {tableName}";
            //CONVERT(VARCHAR(100), {fieldName}, 105)

            var optionList = await _dbContext.AutoCompleteInfo.FromSqlRaw(sql)
                .Where(t => !string.IsNullOrEmpty(t.Term))
                .GroupBy(t => t.Term)
                .OrderBy(gt => gt.Key)
                .Select(gt => gt.Key)
                .ToListAsync();

            //return null;

            return Ok(optionList);
        }

        //[HttpGet("search/{fieldInfo}/{term}")]
        //[Consumes("application/json")]
        public async Task<ActionResult> Search(string fieldInfo, string term)
        {
            term = !string.IsNullOrEmpty(term) ? term : HttpContext.Request.Query["term"].ToString();

            if (string.IsNullOrEmpty(fieldInfo))
                return Ok(null);

            string fieldName, tableName = "";
            if (fieldInfo.Contains('.'))
            {
                fieldName = fieldInfo.Split('.').Length > 2 ? fieldInfo.Split('.')[2] : fieldInfo.Split('.')[1];
                //tableName = GetDataTableFullName(fieldInfo.Split('.')[0]);
                //tableName = fieldInfo.Split('.')[0];
            }
            else
            {
                fieldName = fieldInfo;
                //tableName = GetDataTableName(fieldName);
            }

            if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(tableName))
                return Ok(null);

            var sql = string.IsNullOrEmpty(term)
                ? $"SELECT TOP 1000 ROW_NUMBER() OVER (ORDER BY {fieldName}) AS SlNo, CONVERT(VARCHAR, {fieldName}, 105) AS Term FROM {tableName}"
                : $"SELECT TOP 1000 ROW_NUMBER() OVER (ORDER BY CHARINDEX('{term}', {fieldName})) AS SlNo, CONVERT(VARCHAR, {fieldName}, 105) AS Term FROM {tableName} WHERE CONVERT(VARCHAR, {fieldName}, 105) LIKE '%{term}%'";

            var optionList = await _dbContext.AutoCompleteInfo.FromSqlRaw(sql)
                .Where(t => !string.IsNullOrEmpty(t.Term))
                .OrderBy(t => t.SlNo)
                .Select(t => t.Term)
                .ToListAsync();

            //return null;

            return Ok(optionList);
        }



        //var m_sets = from t in _context.MeasureTags
        //        join s in _context.MeasureSets on t.ms.id equals s.id
        //        where s.userName == User.Identity.Name
        //        select new TagTable
        //        {
        //            id = t.id,
        //            set = s.name,
        //            tag = t.name,
        //            res = t.res.name
        //        };
        //    return View(m_sets.ToArray());

        public JsonResult GetSnDBasicInfo(string snDCode)
        {
            //var name = new SqlParameter("@CategoryName", "Test");
            //var data= _dbContext.Database.ExecuteSqlCommand("EXEC AddCategory @CategoryName", name);

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT * From Table1";
                _dbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    // do something with result
                }
            }


            var basicInfo = _dbContext.LookUpSnDInfo.Where(w => w.SnDCode == snDCode)
                .Select(s => new
                {
                    CenterLatitude = s.CenterLatitude,
                    CenterLongitude = s.CenterLongitude,
                    MinScale = s.MinScale,
                    DefaultZoomLevel = s.DefaultZoomLevel
                }).FirstOrDefault();
            return Json(basicInfo);
        }

        public JsonResult GetSubstationBasicInfo(string substationId)
        {
            var basicInfo = _dbContext.TblSubstation.Where(w => w.SubstationId == substationId)
                .Select(s => new
                {
                    CenterLatitude = s.Latitude,
                    CenterLongitude = s.Longitude,
                    DefaultZoomLevel = s.DefaultZoomLevel
                }).FirstOrDefault();
            return Json(basicInfo);
        }


    }
}