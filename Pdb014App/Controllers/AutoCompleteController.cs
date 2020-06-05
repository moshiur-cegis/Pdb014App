using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Pdb014App.Repository;


namespace Pdb014App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoCompleteController : ControllerBase
    {
        private readonly PdbDbContext _dbContext;

        public AutoCompleteController(PdbDbContext context)
        {
            _dbContext = context;
        }
        
        //private readonly UserDbContext _dbContextUser;

        //public AutoCompleteController(PdbDbContext context, UserDbContext contextUser)
        //{
        //    _dbContext = context;
        //    _dbContextUser = contextUser;
        //}

        [HttpGet("search/{fieldInfo}")]
        [Consumes("application/json")]
        public async Task<ActionResult> Search(string fieldInfo)
        {
            if (string.IsNullOrEmpty(fieldInfo))
                return Ok(null);

            string fieldName, tableName;
            if (fieldInfo.Contains('.'))
            {
                fieldName = fieldInfo.Split('.').Length > 2 ? fieldInfo.Split('.')[2] : fieldInfo.Split('.')[1];
                tableName = GetDataTableFullName(fieldInfo.Split('.')[0]);
                //tableName = fieldInfo.Split('.')[0];
            }
            else
            {
                fieldName = fieldInfo;
                tableName = GetDataTableName(fieldName);
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

        [HttpGet("search/{fieldInfo}/{term}")]
        [Consumes("application/json")]
        public async Task<ActionResult> Search(string fieldInfo, string term)
        {
            term = !string.IsNullOrEmpty(term) ? term : HttpContext.Request.Query["term"].ToString();

            if (string.IsNullOrEmpty(fieldInfo))
                return Ok(null);

            string fieldName, tableName;
            if (fieldInfo.Contains('.'))
            {
                fieldName = fieldInfo.Split('.').Length > 2 ? fieldInfo.Split('.')[2] : fieldInfo.Split('.')[1];
                tableName = GetDataTableFullName(fieldInfo.Split('.')[0]);
                //tableName = fieldInfo.Split('.')[0];
            }
            else
            {
                fieldName = fieldInfo;
                tableName = GetDataTableName(fieldName);
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


        public string GetDataTableName(string fieldName)
        {
            if (fieldName == null)
                return null;

            string tableName = null;

            switch (fieldName)
            {
                case "PoleId":
                case "SurveyDate":
                case "PoleNo":
                case "PreviousPoleNo":
                case "MSJNo":
                case "SleeveNo":
                case "TwistNo":
                case "PhaseA":
                case "PhaseB":
                case "PhaseC":
                case "Neutral":
                case "StreetLight":
                    //case "SourceCable":
                    //case "TargetCable":
                    //case "Latitude":
                    //case "Longitude":
                    tableName = "TblPole";
                    break;

                case "PoleTypeName":
                    tableName = "LookUpPoleType";
                    break;

                case "PoleCondition":
                    tableName = "LookUpPoleCondition";
                    break;

                case "RouteName":
                    tableName = "LookUpRouteInfo";
                    break;

                case "FeederName":
                case "FeederLineId":
                case "FeederLineUId":
                //case "NominalVoltage":
                case "FeederLocation":
                case "FeedermeterNumber":
                case "MeterCurrentRating":
                case "MeterVoltageRating":
                //case "MaximumDemand":
                case "PeakDemand":
                case "MaximumLoad":
                case "SanctionedLoad":
                    tableName = "TblFeederLine";
                    break;

                case "SubstationId":
                case "SubstationName":
                case "SnDCode":
                case "NominalVoltage":
                case "InstalledCapacity":
                case "MaximumDemand":
                case "PeakLoad":
                case "Location":
                case "AreaOfSubstation":
                //case "Latitude":
                //case "Longitude":
                case "YearOfComissioning":
                    tableName = "TblSubstation";
                    break;

                case "SubstationTypeName":
                    tableName = "LookUpSubstationType";
                    break;

                case "FeederLineType":
                    tableName = "LookUpFeederLineType";
                    break;

                default:
                    break;

            }

            return tableName;

        }

        public string GetDataTableFullName(string tblName)
        {
            if (tblName == null)
                return null;

            if (tblName.Length > 5)
                return tblName;

            string tableName = null;

            switch (tblName)
            {
                case "plt": tableName = "TblPole"; break;
                case "flt": tableName = "TblFeederLine"; break;
                case "sst": tableName = "TblSubstation"; break;
                case "dtt": tableName = "TblDistributionTransformer"; break;
                case "ptt": tableName = "TblPhasePowerTransformer"; break;
                case "mpt": tableName = "TblMeteringPanel"; break;
                case "cat": tableName = "TblCrossArmInfo"; break;
                case "sgt": tableName = "TblSwitchGear"; break;
                case "ret": tableName = "TblRelay"; break;
                case "sit": tableName = "TblSwitch33KvIsolator"; break;
                case "vct": tableName = "TblOutDoorTypeVacumnCircuitBreaker"; break;
                case "cdt": tableName = "TblConsumerData"; break;
                case "spt": tableName = "TblServicePoint"; break;

                case "roil": tableName = "LookUpRouteInfo"; break;
                case "pltl": tableName = "LookUpPoleType"; break;
                case "plcl": tableName = "LookUpPoleCondition"; break;
                case "fltl": tableName = "LookUpFeederLineType"; break;
                case "flcl": tableName = "LookUpFeederConductorType"; break;
                case "sstl": tableName = "LookUpSubstationType"; break;
                case "cftl": tableName = "LookUpTypeOfFittings"; break;
                case "cfcl": tableName = "LookUpCondition"; break;
                case "crbl": tableName = "LookUpCircuitBreaker"; break;
                case "sgtl": tableName = "LookUpSwitchGearType"; break;
                case "cbrl": tableName = "LookUpCircuitBreaker"; break;
                case "drel": tableName = "LookUpDifferentRelay"; break;
                case "drtl": tableName = "LookUpDifferentTypesOfRelay"; break;
                case "cotl": tableName = "LookUpConsumerType"; break;
                case "cctl": tableName = "LookUpConnectionType"; break;
                case "ccsl": tableName = "LookUpConnectionStatus"; break;
                case "pctl": tableName = "LookUpPhasingCodeType"; break;
                case "opvl": tableName = "LookUpOperatingVoltage"; break;
                case "cbtl": tableName = "LookUpBusinessType"; break;
                case "clol": tableName = "LookUpLocation"; break;
                case "sptl": tableName = "LookUpServicePointType"; break;
                case "vocl": tableName = "LookUpVoltageCategory"; break;

                default: break;
            }

            return tableName;

        }


/*
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

*/

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


    }
}