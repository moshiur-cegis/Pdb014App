using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Repository;

//using Microsoft.AspNetCore.Mvc;


namespace Pdb014App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : Controller
    {
        private readonly PdbDbContext _dbContext;

        public AdminApiController(PdbDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("search/{fieldInfo}")]
        [Consumes("application/json")]
        public async Task<ActionResult> Search(string fieldInfo)
        {
            if (string.IsNullOrEmpty(fieldInfo))
                return Ok(null);

            string fieldName, tableName="";
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

            var optionList = await _dbContext.AutoCompleteInfo.FromSql(sql)
                .Where(t => !string.IsNullOrEmpty(t.Term))
                .GroupBy(t => t.Term)
                .OrderBy(gt => gt.Key)
                .Select(gt => gt.Key)
                .ToListAsync();

            //return null;

            return Ok(optionList);
        }

        [HttpGet("search/{fieldInfo}/{term}")]
        [Consumes("application/json")]
        public async Task<ActionResult> Search(string fieldInfo, string term)
        {
            term = !string.IsNullOrEmpty(term) ? term : HttpContext.Request.Query["term"].ToString();

            if (string.IsNullOrEmpty(fieldInfo))
                return Ok(null);

            string fieldName, tableName="";
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

            var optionList = await _dbContext.AutoCompleteInfo.FromSql(sql)
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
            var name = new SqlParameter("@CategoryName", "Test");
            var data= _dbContext.Database.ExecuteSqlCommand("EXEC AddCategory @CategoryName", name);

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