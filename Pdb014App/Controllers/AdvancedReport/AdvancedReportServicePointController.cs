using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Extensions;

using Pdb014App.Models.PDB.ServicePointModels;
using Pdb014App.Models.Report;


namespace Pdb014App.Controllers.AdvancedReport
{
    public partial class AdvancedReportController
    {

        #region ServicePointInfoAdvancedReport

        public IActionResult ConsumerInfo([FromQuery] string cai, string regionLevel)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };


            var fieldList = new List<ReportField>(16)
            {
                new ReportField {Name = "totalCount", Title = "No. of Consumer", Selected = true},

                //1 Govt
                //2 Private
                ////Consumer Type
                new ReportField {Name = "groupCT", Title = "Consumer Type", Selected = true},
                new ReportField
                    {Name = "totalGovtCount", Title = "Govt.", Selected = true, Visible = false, GroupName = "groupCT"},
                new ReportField
                {
                    Name = "totalPrivateCount", Title = "Private", Selected = true, Visible = false,
                    GroupName = "groupCT"
                },

                //1 11KV
                //2 400V
                //3 230V
                ////Operating Voltage
                new ReportField {Name = "groupOV", Title = "Operating Voltage", Selected = true},
                new ReportField
                {
                    Name = "total11kOpeVolCount", Title = "11kV", Selected = true, Visible = false,
                    GroupName = "groupOV"
                },
                new ReportField
                {
                    Name = "total400OpeVolCount", Title = "400V", Selected = true, Visible = false,
                    GroupName = "groupOV"
                },
                new ReportField
                {
                    Name = "total230OpeVolCount", Title = "230V", Selected = true, Visible = false,
                    GroupName = "groupOV"
                },

                //1 Regular
                //2 Temporary
                ////Connection Status
                new ReportField {Name = "groupCS", Title = "Connection Status", Selected = true},
                new ReportField
                {
                    Name = "totalRegularCount", Title = "Regular", Selected = true, Visible = false,
                    GroupName = "groupCS"
                },
                new ReportField
                {
                    Name = "totalTemporaryCount", Title = "Temporary", Selected = true, Visible = false,
                    GroupName = "groupCS"
                },

                //1 Mother Meter
                //2 Child Meter
                //3 N/A
                ////Connection Type
                new ReportField {Name = "groupCoT", Title = "Connection Type", Selected = true},
                new ReportField
                {
                    Name = "totalMotherCount", Title = "Mother Meter", Selected = true, Visible = false,
                    GroupName = "groupCoT"
                },
                new ReportField
                {
                    Name = "totalChildCount", Title = "Child Meter", Selected = true, Visible = false,
                    GroupName = "groupCoT"
                },
                new ReportField
                    {Name = "totalNACount", Title = "N/A", Selected = true, Visible = false, GroupName = "groupCoT"},

                //1 Prepaid (Card based)
                //2 Prepaid (keypad)
                //3 Prepaid (Smart)
                //4 Postpaid (Digital)
                //5 Postpaid (Analogue)
                ////Meter Type
                new ReportField {Name = "groupMT", Title = "Meter Type", Selected = true},
                new ReportField
                {
                    Name = "totalPreCardCount", Title = "Prepaid (Card based)", Selected = true, Visible = false,
                    GroupName = "groupMT"
                },
                new ReportField
                {
                    Name = "totalPreKeypadCount", Title = "Prepaid (Keypad)", Selected = true, Visible = false,
                    GroupName = "groupMT"
                },
                new ReportField
                {
                    Name = "totalPreSmartCount", Title = "Prepaid (Smart)", Selected = true, Visible = false,
                    GroupName = "groupMT"
                },
                new ReportField
                {
                    Name = "totalPosDigitalCount", Title = "Postpaid (Digital)", Selected = true, Visible = false,
                    GroupName = "groupMT"
                },
                new ReportField
                {
                    Name = "totalPosAnalogueCount", Title = "Postpaid (Analogue)", Selected = true, Visible = false,
                    GroupName = "groupMT"
                },

                //1 R
                //2 Y
                //3 B
                //4 RYB
                ////Phasing Code
                new ReportField {Name = "groupPC", Title = "Phasing Code", Selected = true},
                new ReportField
                    {Name = "totalRCount", Title = "R", Selected = true, Visible = false, GroupName = "groupPC"},
                new ReportField
                    {Name = "totalYCount", Title = "Y", Selected = true, Visible = false, GroupName = "groupPC"},
                new ReportField
                    {Name = "totalBCount", Title = "B", Selected = true, Visible = false, GroupName = "groupPC"},
                new ReportField
                    {Name = "totalRYBCount", Title = "RYB", Selected = true, Visible = false, GroupName = "groupPC"},

                //2 Education
                //3 Govt. Hospital
                //4 Freedom Fighter
                //5 Water Pump
                //6 Office
                //7 Street Light
                //10 Religious
                //11 Residential
                //12 Mixed Residential
                //51 Business
                //99 Others
                ////Business Type
                new ReportField {Name = "groupBT", Title = "Business Type", Selected = true},
                new ReportField
                {
                    Name = "totalEducationCount", Title = "Education", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalHospitalCount", Title = "Govt. Hospital", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalFreedomFighterCount", Title = "Freedom Fighter", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalWaterPumpCount", Title = "Water Pump", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalOfficeCount", Title = "Office", Selected = true, Visible = false, GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalStreetLightCount", Title = "Street Light", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalReligiousCount", Title = "Religious", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalResidentialCount", Title = "Residential", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalMixedResidentialCount", Title = "Mixed Residential", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalBusinessCount", Title = "Business", Selected = true, Visible = false,
                    GroupName = "groupBT"
                },
                new ReportField
                {
                    Name = "totalOthersCount", Title = "Others", Selected = true, Visible = false, GroupName = "groupBT"
                },

                //1 PVC
                //2 Concentric (by visiting)
                ////Service Cable Type
                new ReportField {Name = "groupSCT", Title = "Service Cable Type", Selected = true},
                new ReportField
                    {Name = "totalPVCCount", Title = "PVC", Selected = true, Visible = false, GroupName = "groupSCT"},
                new ReportField
                {
                    Name = "totalCBVCount", Title = "Concentric (by visiting)", Selected = true, Visible = false,
                    GroupName = "groupSCT"
                },

                //1 Pacca
                //2 Semi-Pacca
                //3 Wooden
                //4 Earthen
                ////Structure Type
                new ReportField {Name = "groupST", Title = "Connection Status", Selected = true},
                new ReportField
                {
                    Name = "totalPaccaCount", Title = "Pacca", Selected = true, Visible = false, GroupName = "groupST"
                },
                new ReportField
                {
                    Name = "totalSemiPaccaCount", Title = "Semi-Pacca", Selected = true, Visible = false,
                    GroupName = "groupST"
                },
                new ReportField
                {
                    Name = "totalWoodenCount", Title = "Wooden", Selected = true, Visible = false, GroupName = "groupST"
                },
                new ReportField
                {
                    Name = "totalEarthenCount", Title = "Earthen", Selected = true, Visible = false,
                    GroupName = "groupST"
                },

            };


            ViewBag.ReportName = "Consumer Info.";
            ViewBag.ReportAction = "GetConsumerInfoData";
            ViewBag.ReportController = "AdvancedReport";

            var regionList = new List<string>(5);

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("AdvancedReport");
            //return View("ConsumerInfo");
        }

        [HttpPost]
        public IActionResult ConsumerInfo([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };


            if (fieldList == null || fieldList.Count < 1)
            {
                fieldList = new List<ReportField>(16)
                {
                    new ReportField {Name = "totalCount", Title = "Total PT", Selected = true},

                    //1 Govt
                    //2 Private
                    ////Consumer Type
                    new ReportField {Name = "groupCT", Title = "Consumer Type", Selected = true},
                    new ReportField
                    {
                        Name = "totalGovtCount", Title = "Govt.", Selected = true, Visible = false,
                        GroupName = "groupCT"
                    },
                    new ReportField
                    {
                        Name = "totalPrivateCount", Title = "Private", Selected = true, Visible = false,
                        GroupName = "groupCT"
                    },

                    //1 11KV
                    //2 400V
                    //3 230V
                    ////Operating Voltage
                    new ReportField {Name = "groupOV", Title = "Operating Voltage", Selected = true},
                    new ReportField
                    {
                        Name = "total11kOpeVolCount", Title = "11kV", Selected = true, Visible = false,
                        GroupName = "groupOV"
                    },
                    new ReportField
                    {
                        Name = "total400OpeVolCount", Title = "400V", Selected = true, Visible = false,
                        GroupName = "groupOV"
                    },
                    new ReportField
                    {
                        Name = "total230OpeVolCount", Title = "230V", Selected = true, Visible = false,
                        GroupName = "groupOV"
                    },

                    //1 Regular
                    //2 Temporary
                    ////Connection Status
                    new ReportField {Name = "groupCS", Title = "Connection Status", Selected = true},
                    new ReportField
                    {
                        Name = "totalRegularCount", Title = "Regular", Selected = true, Visible = false,
                        GroupName = "groupCS"
                    },
                    new ReportField
                    {
                        Name = "totalTemporaryCount", Title = "Temporary", Selected = true, Visible = false,
                        GroupName = "groupCS"
                    },

                    //1 Mother Meter
                    //2 Child Meter
                    //3 N/A
                    ////Connection Type
                    new ReportField {Name = "groupCoT", Title = "Connection Type", Selected = true},
                    new ReportField
                    {
                        Name = "totalMotherCount", Title = "Mother Meter", Selected = true, Visible = false,
                        GroupName = "groupCoT"
                    },
                    new ReportField
                    {
                        Name = "totalChildCount", Title = "Child Meter", Selected = true, Visible = false,
                        GroupName = "groupCoT"
                    },
                    new ReportField
                    {
                        Name = "totalNACount", Title = "N/A", Selected = true, Visible = false, GroupName = "groupCoT"
                    },

                    //1 Prepaid (Card based)
                    //2 Prepaid (keypad)
                    //3 Prepaid (Smart)
                    //4 Postpaid (Digital)
                    //5 Postpaid (Analogue)
                    ////Meter Type
                    new ReportField {Name = "groupMT", Title = "Meter Type", Selected = true},
                    new ReportField
                    {
                        Name = "totalPreCardCount", Title = "Prepaid (Card based)", Selected = true, Visible = false,
                        GroupName = "groupMT"
                    },
                    new ReportField
                    {
                        Name = "totalPreKeypadCount", Title = "Prepaid (Keypad)", Selected = true, Visible = false,
                        GroupName = "groupMT"
                    },
                    new ReportField
                    {
                        Name = "totalPreSmartCount", Title = "Prepaid (Smart)", Selected = true, Visible = false,
                        GroupName = "groupMT"
                    },
                    new ReportField
                    {
                        Name = "totalPosDigitalCount", Title = "Postpaid (Digital)", Selected = true, Visible = false,
                        GroupName = "groupMT"
                    },
                    new ReportField
                    {
                        Name = "totalPosAnalogueCount", Title = "Postpaid (Analogue)", Selected = true, Visible = false,
                        GroupName = "groupMT"
                    },

                    //1 R
                    //2 Y
                    //3 B
                    //4 RYB
                    ////Phasing Code
                    new ReportField {Name = "groupPC", Title = "Phasing Code", Selected = true},
                    new ReportField
                        {Name = "totalRCount", Title = "R", Selected = true, Visible = false, GroupName = "groupPC"},
                    new ReportField
                        {Name = "totalYCount", Title = "Y", Selected = true, Visible = false, GroupName = "groupPC"},
                    new ReportField
                        {Name = "totalBCount", Title = "B", Selected = true, Visible = false, GroupName = "groupPC"},
                    new ReportField
                    {
                        Name = "totalRYBCount", Title = "RYB", Selected = true, Visible = false, GroupName = "groupPC"
                    },

                    //2 Education
                    //3 Govt. Hospital
                    //4 Freedom Fighter
                    //5 Water Pump
                    //6 Office
                    //7 Street Light
                    //10 Religious
                    //11 Residential
                    //12 Mixed Residential
                    //51 Business
                    //99 Others
                    ////Business Type
                    new ReportField {Name = "groupBT", Title = "Business Type", Selected = true},
                    new ReportField
                    {
                        Name = "totalEducationCount", Title = "Education", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalHospitalCount", Title = "Govt. Hospital", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalFreedomFighterCount", Title = "Freedom Fighter", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalWaterPumpCount", Title = "Water Pump", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalOfficeCount", Title = "Office", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalStreetLightCount", Title = "Street Light", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalReligiousCount", Title = "Religious", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalResidentialCount", Title = "Residential", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalMixedResidentialCount", Title = "Mixed Residential", Selected = true,
                        Visible = false, GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalBusinessCount", Title = "Business", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },
                    new ReportField
                    {
                        Name = "totalOthersCount", Title = "Others", Selected = true, Visible = false,
                        GroupName = "groupBT"
                    },

                    //1 PVC
                    //2 Concentric (by visiting)
                    ////Service Cable Type
                    new ReportField {Name = "groupSCT", Title = "Service Cable Type", Selected = true},
                    new ReportField
                    {
                        Name = "totalPVCCount", Title = "PVC", Selected = true, Visible = false, GroupName = "groupSCT"
                    },
                    new ReportField
                    {
                        Name = "totalCBVCount", Title = "Concentric (by visiting)", Selected = true, Visible = false,
                        GroupName = "groupSCT"
                    },

                    //1 Pacca
                    //2 Semi-Pacca
                    //3 Wooden
                    //4 Earthen
                    ////Structure Type
                    new ReportField {Name = "groupST", Title = "Connection Status", Selected = true},
                    new ReportField
                    {
                        Name = "totalPaccaCount", Title = "Pacca", Selected = true, Visible = false,
                        GroupName = "groupST"
                    },
                    new ReportField
                    {
                        Name = "totalSemiPaccaCount", Title = "Semi-Pacca", Selected = true, Visible = false,
                        GroupName = "groupST"
                    },
                    new ReportField
                    {
                        Name = "totalWoodenCount", Title = "Wooden", Selected = true, Visible = false,
                        GroupName = "groupST"
                    },
                    new ReportField
                    {
                        Name = "totalEarthenCount", Title = "Earthen", Selected = true, Visible = false,
                        GroupName = "groupST"
                    },

                };
            }

            ViewBag.ReportName = "Consumer Info.";
            ViewBag.ReportAction = "GetConsumerInfoData";
            ViewBag.ReportController = "AdvancedReport";

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionInfo = regionInfo;
            ViewBag.RegionLevel = regionLevel;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "", routeCode = "";

            zoneCode = circleCode = snDCode = substationCode = routeCode = "";

            if (regionList.Count > 0)
            {
                zoneCode = regionList[0];

                if (regionList.Count > 1)
                {
                    circleCode = regionList[1];

                    if (regionList.Count > 2)
                    {
                        snDCode = regionList[2];

                        if (regionList.Count > 3)
                        {
                            substationCode = regionList[3];

                            if (regionList.Count > 4)
                            {
                                routeCode = regionList[4];
                            }
                        }
                    }
                }
            }

            ViewBag.ZoneCode = zoneCode;
            ViewBag.CircleCode = circleCode;
            ViewBag.SnDCode = snDCode;
            ViewBag.SubstationCode = substationCode;
            ViewBag.RouteCode = routeCode;


            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode).ToList(), "ZoneCode",
                "ZoneName");

            if (!string.IsNullOrEmpty(zoneCode))
            {
                ViewData["CircleList"] = new SelectList(_context.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName");

                if (!string.IsNullOrEmpty(circleCode))
                {
                    ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName");

                    //if (!string.IsNullOrEmpty(snDCode))
                    //{
                    //    ViewData["DtList"] = new SelectList(_context.TblDT
                    //        //.Where(ss => ss.DTId..SnDCode.Equals(snDCode))
                    //        .Select(ss => new { ss.SubstationId, ss.SubstationName })
                    //        .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
                    //}
                    //else
                    //{
                    //    ViewData["SubstationList"] = null;
                    //}
                }
                else
                {
                    ViewData["SnDList"] = ViewData["SubstationList"] = null;
                }
            }
            else
            {
                ViewData["CircleList"] = ViewData["SnDList"] = ViewData["SubstationList"] = null;
            }

            return View("AdvancedReport");
            //return View("ConsumerInfo");
        }

        [HttpPost]
        public JsonResult GetConsumerInfoData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            Expression<Func<TblConsumerData, bool>> searchExp = null;

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                        .SubstationToLookUpSnD.CircleInfo.ZoneCode == zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblConsumerData, bool>> tempExp = model =>
                        model.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                            .SubstationToLookUpSnD.CircleCode == circleCode;
                    searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model =>
                            model.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation.SnDCode ==
                            snDCode;
                        searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model =>
                                model.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                    .SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);

                            //if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            //{
                            //    routeCode = regionList[4];
                            //    //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                            //    //tempExp = model => model. == substationCode;
                            //    //searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);
                            //}
                        }
                    }
                }
            }

            var qry = searchExp != null
                ? _context.TblConsumerData
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblConsumerData
                    .AsNoTracking();


            object data;

            switch (regionLevel)
            {
                case "zone":

                    var cmInfo = qry
                        .Select(c => new
                        {
                            RegionCode = c.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                    .RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,

                            ConsumerType = c.ConsumerTypeId ?? 0,
                            OperatingVoltage = c.OperatingVoltageId ?? 0,
                            //OperatingVoltage = c.OperatingVoltageId != null ? c.ConsumerToOperatingVoltage.OperatingVoltageName : "",
                            ConnectionStatus = c.ConnectionStatusId ?? 0,
                            ConnectionType = c.ConnectionTypeId ?? 0,
                            MeterType = c.MeterTypeId ?? 0,
                            PhasingCode = c.PhasingCodeId ?? 0,

                            BusinessType = c.BusinessTypeId ?? 0,
                            ServiceCableType = c.ServiceCableTypeId ?? 0,
                            StructureType = c.StructureTypeId ?? 0,
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerType == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerType == 2),

                            //total11kOpeVolCount = k.Count(d => d.OperatingVoltage.Contains("11")),
                            //total400OpeVolCount = k.Count(d => d.OperatingVoltage.Contains("400")),
                            //total230OpeVolCount = k.Count(d => d.OperatingVoltage.Contains("230")),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltage == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltage == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltage == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatus == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatus == 2),

                            totalMotherCount = k.Count(d => d.ConnectionType == 1),
                            totalChildCount = k.Count(d => d.ConnectionType == 2),
                            totalNACount = k.Count(d => d.ConnectionType == 3),

                            totalPreCardCount = k.Count(d => d.MeterType == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterType == 2),
                            totalPreSmartCount = k.Count(d => d.MeterType == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterType == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterType == 5),

                            totalRCount = k.Count(d => d.PhasingCode == 1),
                            totalYCount = k.Count(d => d.PhasingCode == 2),
                            totalBCount = k.Count(d => d.PhasingCode == 3),
                            totalRYBCount = k.Count(d => d.PhasingCode == 4),

                            totalEducationCount = k.Count(d => d.BusinessType == 2),
                            totalHospitalCount = k.Count(d => d.BusinessType == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessType == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessType == 5),
                            totalOfficeCount = k.Count(d => d.BusinessType == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessType == 7),
                            totalReligiousCount = k.Count(d => d.BusinessType == 10),
                            totalResidentialCount = k.Count(d => d.BusinessType == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessType == 12),
                            totalBusinessCount = k.Count(d => d.BusinessType == 51),
                            totalOthersCount = k.Count(d => d.BusinessType == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableType == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableType == 2),

                            totalPaccaCount = k.Count(d => d.StructureType == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureType == 2),
                            totalWoodenCount = k.Count(d => d.StructureType == 3),
                            totalEarthenCount = k.Count(d => d.StructureType == 4),
                        })
                        .ToList();


                    var regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join cm in cmInfo on rg.regionCode equals cm.regionCode into rcm
                            from cm in rcm.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                cm?.totalCount,

                                cm?.totalGovtCount,
                                cm?.totalPrivateCount,

                                cm?.total11kOpeVolCount,
                                cm?.total400OpeVolCount,
                                cm?.total230OpeVolCount,

                                cm?.totalRegularCount,
                                cm?.totalTemporaryCount,

                                cm?.totalMotherCount,
                                cm?.totalChildCount,
                                cm?.totalNACount,

                                cm?.totalPreCardCount,
                                cm?.totalPreKeypadCount,
                                cm?.totalPreSmartCount,
                                cm?.totalPosDigitalCount,
                                cm?.totalPosAnalogueCount,

                                cm?.totalRCount,
                                cm?.totalYCount,
                                cm?.totalBCount,
                                cm?.totalRYBCount,

                                cm?.totalEducationCount,
                                cm?.totalHospitalCount,
                                cm?.totalFreedomFighterCount,
                                cm?.totalWaterPumpCount,
                                cm?.totalOfficeCount,
                                cm?.totalStreetLightCount,
                                cm?.totalReligiousCount,
                                cm?.totalResidentialCount,
                                cm?.totalMixedResidentialCount,
                                cm?.totalBusinessCount,
                                cm?.totalOthersCount,

                                cm?.totalPVCCount,
                                cm?.totalCBVCount,

                                cm?.totalPaccaCount,
                                cm?.totalSemiPaccaCount,
                                cm?.totalWoodenCount,
                                cm?.totalEarthenCount,
                            })
                        .ToList();

                    break;


                case "circle":

                    cmInfo = qry
                        .Select(c => new
                        {
                            RegionCode = c.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                    .RouteToSubstation.SubstationToLookUpSnD.CircleCode,

                            ConsumerType = c.ConsumerTypeId ?? 0,
                            OperatingVoltage = c.OperatingVoltageId ?? 0,
                            ConnectionStatus = c.ConnectionStatusId ?? 0,
                            ConnectionType = c.ConnectionTypeId ?? 0,
                            MeterType = c.MeterTypeId ?? 0,
                            PhasingCode = c.PhasingCodeId ?? 0,

                            BusinessType = c.BusinessTypeId ?? 0,
                            ServiceCableType = c.ServiceCableTypeId ?? 0,
                            StructureType = c.StructureTypeId ?? 0,
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerType == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerType == 2),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltage == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltage == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltage == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatus == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatus == 2),

                            totalMotherCount = k.Count(d => d.ConnectionType == 1),
                            totalChildCount = k.Count(d => d.ConnectionType == 2),
                            totalNACount = k.Count(d => d.ConnectionType == 3),

                            totalPreCardCount = k.Count(d => d.MeterType == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterType == 2),
                            totalPreSmartCount = k.Count(d => d.MeterType == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterType == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterType == 5),

                            totalRCount = k.Count(d => d.PhasingCode == 1),
                            totalYCount = k.Count(d => d.PhasingCode == 2),
                            totalBCount = k.Count(d => d.PhasingCode == 3),
                            totalRYBCount = k.Count(d => d.PhasingCode == 4),

                            totalEducationCount = k.Count(d => d.BusinessType == 2),
                            totalHospitalCount = k.Count(d => d.BusinessType == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessType == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessType == 5),
                            totalOfficeCount = k.Count(d => d.BusinessType == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessType == 7),
                            totalReligiousCount = k.Count(d => d.BusinessType == 10),
                            totalResidentialCount = k.Count(d => d.BusinessType == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessType == 12),
                            totalBusinessCount = k.Count(d => d.BusinessType == 51),
                            totalOthersCount = k.Count(d => d.BusinessType == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableType == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableType == 2),

                            totalPaccaCount = k.Count(d => d.StructureType == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureType == 2),
                            totalWoodenCount = k.Count(d => d.StructureType == 3),
                            totalEarthenCount = k.Count(d => d.StructureType == 4),
                        })
                        .ToList();


                    regions = _context.LookUpCircleInfo
                        .Where(c => (zoneCode.Equals("") || c.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || c.CircleCode.Equals(circleCode)))
                        .Include(z => z.ZoneInfo)
                        .Select(c => new
                        {
                            regionCode = c.CircleCode,
                            zoneName = c.ZoneInfo.ZoneName,
                            circleName = c.CircleName,
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join cm in cmInfo on rg.regionCode equals cm.regionCode into rcm
                            from cm in rcm.DefaultIfEmpty()
                            select new
                            {
                                circleCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,

                                cm?.totalCount,

                                cm?.totalGovtCount,
                                cm?.totalPrivateCount,

                                cm?.total11kOpeVolCount,
                                cm?.total400OpeVolCount,
                                cm?.total230OpeVolCount,

                                cm?.totalRegularCount,
                                cm?.totalTemporaryCount,

                                cm?.totalMotherCount,
                                cm?.totalChildCount,
                                cm?.totalNACount,

                                cm?.totalPreCardCount,
                                cm?.totalPreKeypadCount,
                                cm?.totalPreSmartCount,
                                cm?.totalPosDigitalCount,
                                cm?.totalPosAnalogueCount,

                                cm?.totalRCount,
                                cm?.totalYCount,
                                cm?.totalBCount,
                                cm?.totalRYBCount,

                                cm?.totalEducationCount,
                                cm?.totalHospitalCount,
                                cm?.totalFreedomFighterCount,
                                cm?.totalWaterPumpCount,
                                cm?.totalOfficeCount,
                                cm?.totalStreetLightCount,
                                cm?.totalReligiousCount,
                                cm?.totalResidentialCount,
                                cm?.totalMixedResidentialCount,
                                cm?.totalBusinessCount,
                                cm?.totalOthersCount,

                                cm?.totalPVCCount,
                                cm?.totalCBVCount,

                                cm?.totalPaccaCount,
                                cm?.totalSemiPaccaCount,
                                cm?.totalWoodenCount,
                                cm?.totalEarthenCount,
                            })
                        .ToList();

                    break;


                case "snd":

                    cmInfo = qry
                        .Select(c => new
                        {
                            RegionCode = c.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation.SnDCode,

                            ConsumerType = c.ConsumerTypeId ?? 0,
                            OperatingVoltage = c.OperatingVoltageId ?? 0,
                            ConnectionStatus = c.ConnectionStatusId ?? 0,
                            ConnectionType = c.ConnectionTypeId ?? 0,
                            MeterType = c.MeterTypeId ?? 0,
                            PhasingCode = c.PhasingCodeId ?? 0,

                            BusinessType = c.BusinessTypeId ?? 0,
                            ServiceCableType = c.ServiceCableTypeId ?? 0,
                            StructureType = c.StructureTypeId ?? 0,
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerType == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerType == 2),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltage == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltage == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltage == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatus == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatus == 2),

                            totalMotherCount = k.Count(d => d.ConnectionType == 1),
                            totalChildCount = k.Count(d => d.ConnectionType == 2),
                            totalNACount = k.Count(d => d.ConnectionType == 3),

                            totalPreCardCount = k.Count(d => d.MeterType == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterType == 2),
                            totalPreSmartCount = k.Count(d => d.MeterType == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterType == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterType == 5),

                            totalRCount = k.Count(d => d.PhasingCode == 1),
                            totalYCount = k.Count(d => d.PhasingCode == 2),
                            totalBCount = k.Count(d => d.PhasingCode == 3),
                            totalRYBCount = k.Count(d => d.PhasingCode == 4),

                            totalEducationCount = k.Count(d => d.BusinessType == 2),
                            totalHospitalCount = k.Count(d => d.BusinessType == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessType == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessType == 5),
                            totalOfficeCount = k.Count(d => d.BusinessType == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessType == 7),
                            totalReligiousCount = k.Count(d => d.BusinessType == 10),
                            totalResidentialCount = k.Count(d => d.BusinessType == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessType == 12),
                            totalBusinessCount = k.Count(d => d.BusinessType == 51),
                            totalOthersCount = k.Count(d => d.BusinessType == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableType == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableType == 2),

                            totalPaccaCount = k.Count(d => d.StructureType == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureType == 2),
                            totalWoodenCount = k.Count(d => d.StructureType == 3),
                            totalEarthenCount = k.Count(d => d.StructureType == 4),
                        })
                        .ToList();


                    regions = _context.LookUpSnDInfo
                        .Where(d => (zoneCode.Equals("") || d.CircleInfo.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || d.CircleCode.Equals(circleCode))
                                    && (snDCode.Equals("") || d.SnDCode.Equals(snDCode)))
                        .Include(z => z.CircleInfo.ZoneInfo)
                        .Select(d => new
                        {
                            regionCode = d.SnDCode,
                            zoneName = d.CircleInfo.ZoneInfo.ZoneName,
                            circleName = d.CircleInfo.CircleName,
                            sndName = d.SnDName,
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join cm in cmInfo on rg.regionCode equals cm.regionCode into rcm
                            from cm in rcm.DefaultIfEmpty()
                            select new
                            {
                                sndCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,

                                cm?.totalCount,

                                cm?.totalGovtCount,
                                cm?.totalPrivateCount,

                                cm?.total11kOpeVolCount,
                                cm?.total400OpeVolCount,
                                cm?.total230OpeVolCount,

                                cm?.totalRegularCount,
                                cm?.totalTemporaryCount,

                                cm?.totalMotherCount,
                                cm?.totalChildCount,
                                cm?.totalNACount,

                                cm?.totalPreCardCount,
                                cm?.totalPreKeypadCount,
                                cm?.totalPreSmartCount,
                                cm?.totalPosDigitalCount,
                                cm?.totalPosAnalogueCount,

                                cm?.totalRCount,
                                cm?.totalYCount,
                                cm?.totalBCount,
                                cm?.totalRYBCount,

                                cm?.totalEducationCount,
                                cm?.totalHospitalCount,
                                cm?.totalFreedomFighterCount,
                                cm?.totalWaterPumpCount,
                                cm?.totalOfficeCount,
                                cm?.totalStreetLightCount,
                                cm?.totalReligiousCount,
                                cm?.totalResidentialCount,
                                cm?.totalMixedResidentialCount,
                                cm?.totalBusinessCount,
                                cm?.totalOthersCount,

                                cm?.totalPVCCount,
                                cm?.totalCBVCount,

                                cm?.totalPaccaCount,
                                cm?.totalSemiPaccaCount,
                                cm?.totalWoodenCount,
                                cm?.totalEarthenCount,
                            })
                        .ToList();

                    break;


                case "substation":

                    cmInfo = qry
                        .Select(c => new
                        {
                            RegionCode = c.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.SubstationId,

                            ConsumerType = c.ConsumerTypeId ?? 0,
                            OperatingVoltage = c.OperatingVoltageId ?? 0,
                            ConnectionStatus = c.ConnectionStatusId ?? 0,
                            ConnectionType = c.ConnectionTypeId ?? 0,
                            MeterType = c.MeterTypeId ?? 0,
                            PhasingCode = c.PhasingCodeId ?? 0,

                            BusinessType = c.BusinessTypeId ?? 0,
                            ServiceCableType = c.ServiceCableTypeId ?? 0,
                            StructureType = c.StructureTypeId ?? 0,
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerType == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerType == 2),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltage == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltage == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltage == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatus == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatus == 2),

                            totalMotherCount = k.Count(d => d.ConnectionType == 1),
                            totalChildCount = k.Count(d => d.ConnectionType == 2),
                            totalNACount = k.Count(d => d.ConnectionType == 3),

                            totalPreCardCount = k.Count(d => d.MeterType == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterType == 2),
                            totalPreSmartCount = k.Count(d => d.MeterType == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterType == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterType == 5),

                            totalRCount = k.Count(d => d.PhasingCode == 1),
                            totalYCount = k.Count(d => d.PhasingCode == 2),
                            totalBCount = k.Count(d => d.PhasingCode == 3),
                            totalRYBCount = k.Count(d => d.PhasingCode == 4),

                            totalEducationCount = k.Count(d => d.BusinessType == 2),
                            totalHospitalCount = k.Count(d => d.BusinessType == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessType == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessType == 5),
                            totalOfficeCount = k.Count(d => d.BusinessType == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessType == 7),
                            totalReligiousCount = k.Count(d => d.BusinessType == 10),
                            totalResidentialCount = k.Count(d => d.BusinessType == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessType == 12),
                            totalBusinessCount = k.Count(d => d.BusinessType == 51),
                            totalOthersCount = k.Count(d => d.BusinessType == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableType == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableType == 2),

                            totalPaccaCount = k.Count(d => d.StructureType == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureType == 2),
                            totalWoodenCount = k.Count(d => d.StructureType == 3),
                            totalEarthenCount = k.Count(d => d.StructureType == 4),
                        })
                        .ToList();


                    regions = _context.TblSubstation
                        .Where(s =>
                            (zoneCode.Equals("") || s.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                            && (circleCode.Equals("") || s.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                            && (snDCode.Equals("") || s.SnDCode.Equals(snDCode))
                            && (substationCode.Equals("") || s.SubstationId.Equals(substationCode)))
                        .Include(z => z.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .Select(s => new
                        {
                            regionCode = s.SubstationId,
                            zoneName = s.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = s.SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndName = s.SubstationToLookUpSnD.SnDName,
                            substationName = s.SubstationName,
                        })
                        .ToList();

                    data = (from rg in regions
                            join cm in cmInfo on rg.regionCode equals cm.regionCode into rcm
                            from cm in rcm.DefaultIfEmpty()
                            select new
                            {

                                substationCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,
                                rg.substationName,

                                cm?.totalCount,

                                cm?.totalGovtCount,
                                cm?.totalPrivateCount,

                                cm?.total11kOpeVolCount,
                                cm?.total400OpeVolCount,
                                cm?.total230OpeVolCount,

                                cm?.totalRegularCount,
                                cm?.totalTemporaryCount,

                                cm?.totalMotherCount,
                                cm?.totalChildCount,
                                cm?.totalNACount,

                                cm?.totalPreCardCount,
                                cm?.totalPreKeypadCount,
                                cm?.totalPreSmartCount,
                                cm?.totalPosDigitalCount,
                                cm?.totalPosAnalogueCount,

                                cm?.totalRCount,
                                cm?.totalYCount,
                                cm?.totalBCount,
                                cm?.totalRYBCount,

                                cm?.totalEducationCount,
                                cm?.totalHospitalCount,
                                cm?.totalFreedomFighterCount,
                                cm?.totalWaterPumpCount,
                                cm?.totalOfficeCount,
                                cm?.totalStreetLightCount,
                                cm?.totalReligiousCount,
                                cm?.totalResidentialCount,
                                cm?.totalMixedResidentialCount,
                                cm?.totalBusinessCount,
                                cm?.totalOthersCount,

                                cm?.totalPVCCount,
                                cm?.totalCBVCount,

                                cm?.totalPaccaCount,
                                cm?.totalSemiPaccaCount,
                                cm?.totalWoodenCount,
                                cm?.totalEarthenCount,
                            })
                        .ToList();

                    break;


                default:

                    cmInfo = qry
                        .Select(c => new
                        {
                            RegionCode =
                                c.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                    .RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,

                            ConsumerType = c.ConsumerTypeId ?? 0,
                            OperatingVoltage = c.OperatingVoltageId ?? 0,
                            ConnectionStatus = c.ConnectionStatusId ?? 0,
                            ConnectionType = c.ConnectionTypeId ?? 0,
                            MeterType = c.MeterTypeId ?? 0,
                            PhasingCode = c.PhasingCodeId ?? 0,

                            BusinessType = c.BusinessTypeId ?? 0,
                            ServiceCableType = c.ServiceCableTypeId ?? 0,
                            StructureType = c.StructureTypeId ?? 0,
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerType == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerType == 2),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltage == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltage == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltage == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatus == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatus == 2),

                            totalMotherCount = k.Count(d => d.ConnectionType == 1),
                            totalChildCount = k.Count(d => d.ConnectionType == 2),
                            totalNACount = k.Count(d => d.ConnectionType == 3),

                            totalPreCardCount = k.Count(d => d.MeterType == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterType == 2),
                            totalPreSmartCount = k.Count(d => d.MeterType == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterType == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterType == 5),

                            totalRCount = k.Count(d => d.PhasingCode == 1),
                            totalYCount = k.Count(d => d.PhasingCode == 2),
                            totalBCount = k.Count(d => d.PhasingCode == 3),
                            totalRYBCount = k.Count(d => d.PhasingCode == 4),

                            totalEducationCount = k.Count(d => d.BusinessType == 2),
                            totalHospitalCount = k.Count(d => d.BusinessType == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessType == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessType == 5),
                            totalOfficeCount = k.Count(d => d.BusinessType == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessType == 7),
                            totalReligiousCount = k.Count(d => d.BusinessType == 10),
                            totalResidentialCount = k.Count(d => d.BusinessType == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessType == 12),
                            totalBusinessCount = k.Count(d => d.BusinessType == 51),
                            totalOthersCount = k.Count(d => d.BusinessType == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableType == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableType == 2),

                            totalPaccaCount = k.Count(d => d.StructureType == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureType == 2),
                            totalWoodenCount = k.Count(d => d.StructureType == 3),
                            totalEarthenCount = k.Count(d => d.StructureType == 4),
                        })
                        .ToList();


                    regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join cm in cmInfo on rg.regionCode equals cm.regionCode into rcm
                            from cm in rcm.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                cm?.totalCount,

                                cm?.totalGovtCount,
                                cm?.totalPrivateCount,

                                cm?.total11kOpeVolCount,
                                cm?.total400OpeVolCount,
                                cm?.total230OpeVolCount,

                                cm?.totalRegularCount,
                                cm?.totalTemporaryCount,

                                cm?.totalMotherCount,
                                cm?.totalChildCount,
                                cm?.totalNACount,

                                cm?.totalPreCardCount,
                                cm?.totalPreKeypadCount,
                                cm?.totalPreSmartCount,
                                cm?.totalPosDigitalCount,
                                cm?.totalPosAnalogueCount,

                                cm?.totalRCount,
                                cm?.totalYCount,
                                cm?.totalBCount,
                                cm?.totalRYBCount,

                                cm?.totalEducationCount,
                                cm?.totalHospitalCount,
                                cm?.totalFreedomFighterCount,
                                cm?.totalWaterPumpCount,
                                cm?.totalOfficeCount,
                                cm?.totalStreetLightCount,
                                cm?.totalReligiousCount,
                                cm?.totalResidentialCount,
                                cm?.totalMixedResidentialCount,
                                cm?.totalBusinessCount,
                                cm?.totalOthersCount,

                                cm?.totalPVCCount,
                                cm?.totalCBVCount,

                                cm?.totalPaccaCount,
                                cm?.totalSemiPaccaCount,
                                cm?.totalWoodenCount,
                                cm?.totalEarthenCount,
                            })
                        .ToList();

                    break;
            }

            return Json(data);
        }

        #endregion



        #region ServicePointAdvancedReport

        public IActionResult ServicePointInfo([FromQuery] string cai, string regionLevel)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };


            var fieldList = new List<ReportField>(16)
            {
                new ReportField {Name = "totalCount", Title = "No. of Service Point", Selected = true},

                //1 Single Phase 	Edit | Details | Delete
                //2 3-Phase     Edit | Details | Delete
                //3 Both
                ////Service Point Type
                new ReportField {Name = "groupSPT", Title = "Service Point Type", Selected = true},
                new ReportField
                {
                    Name = "totalSingleCount", Title = "Single Phase", Selected = true, Visible = false,
                    GroupName = "groupSPT"
                },
                new ReportField
                {
                    Name = "total3PhaseCount", Title = "3-Phase", Selected = true, Visible = false,
                    GroupName = "groupSPT"
                },
                new ReportField
                {
                    Name = "totalBothCount", Title = "Both Phase", Selected = true, Visible = false,
                    GroupName = "groupSPT"
                },


                //1 11KV
                //2 400V
                //3 230V
                ////Voltage Category
                new ReportField {Name = "groupVC", Title = "Voltage Category", Selected = true},
                new ReportField
                {
                    Name = "total11kVolCatCount", Title = "11kV", Selected = true, Visible = false,
                    GroupName = "groupVC"
                },
                new ReportField
                {
                    Name = "total400VolCatCount", Title = "0.4kV/400V", Selected = true, Visible = false,
                    GroupName = "groupVC"
                },
                new ReportField
                {
                    Name = "total230VolCatCount", Title = "230V", Selected = true, Visible = false,
                    GroupName = "groupVC"
                },


                //1 R
                //2 Y
                //3 B
                //4 RYB
                ////No. of Consumers
                new ReportField {Name = "groupNoC", Title = "No. of Consumers", Selected = true},
                new ReportField
                    {Name = "totalRConsumers", Title = "R", Selected = true, Visible = false, GroupName = "groupNoC"},
                new ReportField
                    {Name = "totalYConsumers", Title = "Y", Selected = true, Visible = false, GroupName = "groupNoC"},
                new ReportField
                    {Name = "totalBConsumers", Title = "B", Selected = true, Visible = false, GroupName = "groupNoC"},
                new ReportField
                {
                    Name = "totalRYBConsumers", Title = "RYB", Selected = true, Visible = false, GroupName = "groupNoC"
                },


                //Aggregate Load kw
                //new ReportField {Name = "totalAggregateLoad", Title = "Aggregate Load (KW)", Selected = true},
                new ReportField {Name = "totalAggregateLoad", Title = "Total Aggregate Load (MW)", Selected = true},
                new ReportField {Name = "maxAggregateLoad", Title = "Max Aggregate Load (KW)", Selected = true},
                new ReportField {Name = "minAggregateLoad", Title = "Min Aggregate Load (KW)", Selected = true},

            };


            ViewBag.ReportName = "Service Point Info.";
            ViewBag.ReportAction = "GetServicePointInfoData";
            ViewBag.ReportController = "AdvancedReport";

            var regionList = new List<string>(5);

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionLevel = regionLevel;
            ViewBag.RegionInfo = regionInfo;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            ViewData["ZoneList"] =
                new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode), "ZoneCode", "ZoneName");

            return View("AdvancedReport");
            //return View("ServicePointInfo");
        }

        [HttpPost]
        public IActionResult ServicePointInfo([FromQuery] string cai, string regionLevel, List<ReportField> fieldList, List<string> regionList)
        {
            var regionInfo = new List<ReportField>
            {
                new ReportField {Name = "zone", Title = "Zone"},
                new ReportField {Name = "circle", Title = "Circle"},
                new ReportField {Name = "snd", Title = "S&D"},
                new ReportField {Name = "substation", Title = "Substation"},
            };


            if (fieldList == null || fieldList.Count < 1)
            {
                fieldList = new List<ReportField>(16)
                {
                    new ReportField {Name = "totalCount", Title = "No. of Service Point", Selected = true},

                    //1 Single Phase 	Edit | Details | Delete
                    //2 3-Phase     Edit | Details | Delete
                    //3 Both
                    ////Service Point Type
                    new ReportField {Name = "groupSPT", Title = "Service Point Type", Selected = true},
                    new ReportField
                    {
                        Name = "totalSingleCount", Title = "Single Phase", Selected = true, Visible = false,
                        GroupName = "groupSPT"
                    },
                    new ReportField
                    {
                        Name = "total3PhaseCount", Title = "3-Phase", Selected = true, Visible = false,
                        GroupName = "groupSPT"
                    },
                    new ReportField
                    {
                        Name = "totalBothCount", Title = "Both Phase", Selected = true, Visible = false,
                        GroupName = "groupSPT"
                    },


                    //1 11KV
                    //2 400V
                    //3 230V
                    ////Voltage Category
                    new ReportField {Name = "groupVC", Title = "Voltage Category", Selected = true},
                    new ReportField
                    {
                        Name = "total11kVolCatCount", Title = "11kV", Selected = true, Visible = false,
                        GroupName = "groupVC"
                    },
                    new ReportField
                    {
                        Name = "total400VolCatCount", Title = "0.4kV/400V", Selected = true, Visible = false,
                        GroupName = "groupVC"
                    },
                    new ReportField
                    {
                        Name = "total230VolCatCount", Title = "230V", Selected = true, Visible = false,
                        GroupName = "groupVC"
                    },


                    //1 R
                    //2 Y
                    //3 B
                    //4 RYB
                    ////No. of Consumers
                    new ReportField {Name = "groupNoC", Title = "No. of Consumers", Selected = true},
                    new ReportField
                    {
                        Name = "totalRConsumers", Title = "R", Selected = true, Visible = false, GroupName = "groupNoC"
                    },
                    new ReportField
                    {
                        Name = "totalYConsumers", Title = "Y", Selected = true, Visible = false, GroupName = "groupNoC"
                    },
                    new ReportField
                    {
                        Name = "totalBConsumers", Title = "B", Selected = true, Visible = false, GroupName = "groupNoC"
                    },
                    new ReportField
                    {
                        Name = "totalRYBConsumers", Title = "RYB", Selected = true, Visible = false,
                        GroupName = "groupNoC"
                    },


                    //Aggregate Load kw
                    //new ReportField {Name = "totalAggregateLoad", Title = "Aggregate Load (KW)", Selected = true},
                    new ReportField {Name = "totalAggregateLoad", Title = "Total Aggregate Load (MW)", Selected = true},
                    new ReportField {Name = "maxAggregateLoad", Title = "Max Aggregate Load (KW)", Selected = true},
                    new ReportField {Name = "minAggregateLoad", Title = "Min Aggregate Load (KW)", Selected = true},

                };
            }

            ViewBag.ReportName = "Service Point Info.";
            ViewBag.ReportAction = "GetServicePointInfoData";
            ViewBag.ReportController = "AdvancedReport";

            regionLevel = regionLevel ?? "zone";

            ViewBag.RegionInfo = regionInfo;
            ViewBag.RegionLevel = regionLevel;
            ViewBag.FieldList = fieldList;
            ViewBag.RegionList = regionList;

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "";

            if (regionList.Count > 0)
            {
                zoneCode = regionList[0];

                if (regionList.Count > 1)
                {
                    circleCode = regionList[1];

                    if (regionList.Count > 2)
                    {
                        snDCode = regionList[2];

                        if (regionList.Count > 3)
                        {
                            substationCode = regionList[3];
                        }
                    }
                }
            }

            ViewBag.ZoneCode = zoneCode;
            ViewBag.CircleCode = circleCode;
            ViewBag.SnDCode = snDCode;
            ViewBag.SubstationCode = substationCode;
            //ViewBag.RouteCode = routeCode;


            ViewData["ZoneList"] = new SelectList(_context.LookUpZoneInfo.OrderBy(d => d.ZoneCode).ToList(), "ZoneCode",
                "ZoneName");

            if (!string.IsNullOrEmpty(zoneCode))
            {
                ViewData["CircleList"] = new SelectList(_context.LookUpCircleInfo
                    .Where(c => c.ZoneCode.Equals(zoneCode))
                    .Select(c => new { c.CircleCode, c.CircleName })
                    .OrderBy(c => c.CircleCode).ToList(), "CircleCode", "CircleName");

                if (!string.IsNullOrEmpty(circleCode))
                {
                    ViewData["SnDList"] = new SelectList(_context.LookUpSnDInfo
                        .Where(sd => sd.CircleCode.Equals(circleCode))
                        .Select(sd => new { sd.SnDCode, sd.SnDName })
                        .OrderBy(sd => sd.SnDCode).ToList(), "SnDCode", "SnDName");

                    //if (!string.IsNullOrEmpty(snDCode))
                    //{
                    //    ViewData["DtList"] = new SelectList(_context.TblDT
                    //        //.Where(ss => ss.DTId..SnDCode.Equals(snDCode))
                    //        .Select(ss => new { ss.SubstationId, ss.SubstationName })
                    //        .OrderBy(ss => ss.SubstationId).ToList(), "SubstationId", "SubstationName");
                    //}
                    //else
                    //{
                    //    ViewData["SubstationList"] = null;
                    //}
                }
                else
                {
                    ViewData["SnDList"] = ViewData["SubstationList"] = null;
                }
            }
            else
            {
                ViewData["CircleList"] = ViewData["SnDList"] = ViewData["SubstationList"] = null;
            }

            return View("AdvancedReport");
            //return View("ServicePointInfo");
        }

        [HttpPost]
        public JsonResult GetServicePointInfoData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            Expression<Func<TblServicePoint, bool>> searchExp = null;

            string zoneCode = "", circleCode = "", snDCode = "", substationCode = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                searchExp = model =>
                    model.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode ==
                    zoneCode;

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    Expression<Func<TblServicePoint, bool>> tempExp = model =>
                        model.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode ==
                        circleCode;
                    searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        tempExp = model => model.ServicePointToPole.PoleToRoute.RouteToSubstation.SnDCode == snDCode;
                        searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationCode = regionList[3];

                            tempExp = model =>
                                model.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationId == substationCode;
                            searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);

                            //if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            //{
                            //    routeCode = regionList[4];
                            //    //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                            //    //tempExp = model => model. == substationCode;
                            //    //searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);
                            //}
                        }
                    }
                }
            }

            var qry = searchExp != null
                ? _context.TblServicePoint
                    .AsNoTracking()
                    .Where(searchExp)
                : _context.TblServicePoint
                    .AsNoTracking();


            object data;

            switch (regionLevel)
            {
                case "zone":

                    var spInfo = qry
                        .Select(sp => new
                        {
                            RegionCode = sp.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode,

                            ServicePointType = sp.ServicePointTypeId ?? 0,
                            VoltageCategory = sp.VoltageCategoryId ?? 0,
                            //ServicePointType = sp.ServicePointTypeId != null ? sp.ServicePointType.ServicePointTypeName : "",
                            //VoltageCategory = sp.VoltageCategoryId != null ? sp.VoltageCategory.VoltageCategoryName : "",

                            NoOfConsumersR = string.IsNullOrEmpty(sp.NoOFConsumersR) ? 0 : Convert.ToInt32(sp.NoOFConsumersR),
                            NoOfConsumersY = string.IsNullOrEmpty(sp.NoOFConsumersY) ? 0 : Convert.ToInt32(sp.NoOFConsumersY),
                            NoOfConsumersB = string.IsNullOrEmpty(sp.NoOFConsumersB) ? 0 : Convert.ToInt32(sp.NoOFConsumersB),
                            NoOfConsumersRyb = string.IsNullOrEmpty(sp.NoOfConsumersRyb) ? 0 : Convert.ToInt32(sp.NoOfConsumersRyb),

                            AggregateLoadkw = string.IsNullOrEmpty(sp.AggregateLoadkw) ? 0 : Convert.ToInt32(sp.AggregateLoadkw),
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(p => p.ServicePointType == 1),
                            total3PhaseCount = k.Count(p => p.ServicePointType == 2),
                            totalBothCount = k.Count(p => p.ServicePointType == 3),

                            total11kVolCatCount = k.Count(p => p.VoltageCategory == 1),
                            total400VolCatCount = k.Count(p => p.VoltageCategory == 2),
                            total230VolCatCount = k.Count(p => p.VoltageCategory == 3),

                            totalRConsumers = k.Sum(p => p.NoOfConsumersR),
                            totalYConsumers = k.Sum(p => p.NoOfConsumersY),
                            totalBConsumers = k.Sum(p => p.NoOfConsumersB),
                            totalRYBConsumers = k.Sum(p => p.NoOfConsumersRyb),

                            totalAggregateLoad = (k.Sum(p => p.AggregateLoadkw) / 1000).ToString("0.##"),
                            maxAggregateLoad = k.Max(p => p.AggregateLoadkw),
                            minAggregateLoad = k.Min(p => p.AggregateLoadkw),

                            //total11kOpeVolCount = k.Count(p => p.ServicePointType.Contains("11")),
                            //total400OpeVolCount = k.Count(p => p.ServicePointType.Contains("400")),
                            //total230OpeVolCount = k.Count(p => p.ServicePointType.Contains("230")),

                            //total11kVolCatCount = k.Count(p => p.VoltageCategory.Contains("11")),
                            //total400VolCatCount = k.Count(p => p.VoltageCategory.Contains("400")),
                            //total230VolCatCount = k.Count(p => p.VoltageCategory.Contains("230")),
                        })
                        .ToList();


                    var regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join sp in spInfo on rg.regionCode equals sp.regionCode into rsp
                            from sp in rsp.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                sp?.totalCount,

                                sp?.totalSingleCount,
                                sp?.total3PhaseCount,
                                sp?.totalBothCount,

                                sp?.total11kVolCatCount,
                                sp?.total400VolCatCount,
                                sp?.total230VolCatCount,

                                sp?.totalRConsumers,
                                sp?.totalYConsumers,
                                sp?.totalBConsumers,
                                sp?.totalRYBConsumers,

                                sp?.totalAggregateLoad,
                                sp?.maxAggregateLoad,
                                sp?.minAggregateLoad,
                            })
                        .ToList();

                    break;


                case "circle":

                    spInfo = qry
                        .Select(sp => new
                        {
                            RegionCode = sp.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode,

                            ServicePointType = sp.ServicePointTypeId ?? 0,
                            VoltageCategory = sp.VoltageCategoryId ?? 0,

                            NoOfConsumersR = string.IsNullOrEmpty(sp.NoOFConsumersR)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersR),
                            NoOfConsumersY = string.IsNullOrEmpty(sp.NoOFConsumersY)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersY),
                            NoOfConsumersB = string.IsNullOrEmpty(sp.NoOFConsumersB)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersB),
                            NoOfConsumersRyb = string.IsNullOrEmpty(sp.NoOfConsumersRyb)
                                ? 0
                                : Convert.ToInt32(sp.NoOfConsumersRyb),

                            AggregateLoadkw = string.IsNullOrEmpty(sp.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(sp.AggregateLoadkw),
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(p => p.ServicePointType == 1),
                            total3PhaseCount = k.Count(p => p.ServicePointType == 2),
                            totalBothCount = k.Count(p => p.ServicePointType == 3),

                            total11kVolCatCount = k.Count(p => p.VoltageCategory == 1),
                            total400VolCatCount = k.Count(p => p.VoltageCategory == 2),
                            total230VolCatCount = k.Count(p => p.VoltageCategory == 3),

                            totalRConsumers = k.Sum(p => p.NoOfConsumersR),
                            totalYConsumers = k.Sum(p => p.NoOfConsumersY),
                            totalBConsumers = k.Sum(p => p.NoOfConsumersB),
                            totalRYBConsumers = k.Sum(p => p.NoOfConsumersRyb),

                            totalAggregateLoad = (k.Sum(p => p.AggregateLoadkw) / 1000).ToString("0.##"),
                            maxAggregateLoad = k.Max(p => p.AggregateLoadkw),
                            minAggregateLoad = k.Min(p => p.AggregateLoadkw),
                        })
                        .ToList();


                    regions = _context.LookUpCircleInfo
                        .Where(c => (zoneCode.Equals("") || c.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || c.CircleCode.Equals(circleCode)))
                        .Include(z => z.ZoneInfo)
                        .Select(c => new
                        {
                            regionCode = c.CircleCode,
                            zoneName = c.ZoneInfo.ZoneName,
                            circleName = c.CircleName,
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();


                    data = (from rg in regions
                            join sp in spInfo on rg.regionCode equals sp.regionCode into rsp
                            from sp in rsp.DefaultIfEmpty()
                            select new
                            {
                                circleCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,

                                sp?.totalCount,

                                sp?.totalSingleCount,
                                sp?.total3PhaseCount,
                                sp?.totalBothCount,

                                sp?.total11kVolCatCount,
                                sp?.total400VolCatCount,
                                sp?.total230VolCatCount,

                                sp?.totalRConsumers,
                                sp?.totalYConsumers,
                                sp?.totalBConsumers,
                                sp?.totalRYBConsumers,

                                sp?.totalAggregateLoad,
                                sp?.maxAggregateLoad,
                                sp?.minAggregateLoad,
                            })
                        .ToList();

                    break;

                case "snd":

                    spInfo = qry
                        .Select(sp => new
                        {
                            RegionCode = sp.ServicePointToPole.PoleToRoute.RouteToSubstation.SnDCode,

                            ServicePointType = sp.ServicePointTypeId ?? 0,
                            VoltageCategory = sp.VoltageCategoryId ?? 0,

                            NoOfConsumersR = string.IsNullOrEmpty(sp.NoOFConsumersR)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersR),
                            NoOfConsumersY = string.IsNullOrEmpty(sp.NoOFConsumersY)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersY),
                            NoOfConsumersB = string.IsNullOrEmpty(sp.NoOFConsumersB)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersB),
                            NoOfConsumersRyb = string.IsNullOrEmpty(sp.NoOfConsumersRyb)
                                ? 0
                                : Convert.ToInt32(sp.NoOfConsumersRyb),

                            AggregateLoadkw = string.IsNullOrEmpty(sp.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(sp.AggregateLoadkw),
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(p => p.ServicePointType == 1),
                            total3PhaseCount = k.Count(p => p.ServicePointType == 2),
                            totalBothCount = k.Count(p => p.ServicePointType == 3),

                            total11kVolCatCount = k.Count(p => p.VoltageCategory == 1),
                            total400VolCatCount = k.Count(p => p.VoltageCategory == 2),
                            total230VolCatCount = k.Count(p => p.VoltageCategory == 3),

                            totalRConsumers = k.Sum(p => p.NoOfConsumersR),
                            totalYConsumers = k.Sum(p => p.NoOfConsumersY),
                            totalBConsumers = k.Sum(p => p.NoOfConsumersB),
                            totalRYBConsumers = k.Sum(p => p.NoOfConsumersRyb),

                            totalAggregateLoad = (k.Sum(p => p.AggregateLoadkw) / 1000).ToString("0.##"),
                            maxAggregateLoad = k.Max(p => p.AggregateLoadkw),
                            minAggregateLoad = k.Min(p => p.AggregateLoadkw),
                        })
                        .ToList();


                    regions = _context.LookUpSnDInfo
                        .Where(d => (zoneCode.Equals("") || d.CircleInfo.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || d.CircleCode.Equals(circleCode))
                                    && (snDCode.Equals("") || d.SnDCode.Equals(snDCode)))
                        .Include(z => z.CircleInfo.ZoneInfo)
                        .Select(d => new
                        {
                            regionCode = d.SnDCode,
                            zoneName = d.CircleInfo.ZoneInfo.ZoneName,
                            circleName = d.CircleInfo.CircleName,
                            sndName = d.SnDName,
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join sp in spInfo on rg.regionCode equals sp.regionCode into rsp
                            from sp in rsp.DefaultIfEmpty()
                            select new
                            {
                                sndCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,

                                sp?.totalCount,

                                sp?.totalSingleCount,
                                sp?.total3PhaseCount,
                                sp?.totalBothCount,

                                sp?.total11kVolCatCount,
                                sp?.total400VolCatCount,
                                sp?.total230VolCatCount,

                                sp?.totalRConsumers,
                                sp?.totalYConsumers,
                                sp?.totalBConsumers,
                                sp?.totalRYBConsumers,

                                sp?.totalAggregateLoad,
                                sp?.maxAggregateLoad,
                                sp?.minAggregateLoad,
                            })
                        .ToList();

                    break;


                case "substation":

                    spInfo = qry
                        .Select(sp => new
                        {
                            RegionCode = sp.ServicePointToPole.PoleToRoute.SubstationId,

                            ServicePointType = sp.ServicePointTypeId ?? 0,
                            VoltageCategory = sp.VoltageCategoryId ?? 0,

                            NoOfConsumersR = string.IsNullOrEmpty(sp.NoOFConsumersR)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersR),
                            NoOfConsumersY = string.IsNullOrEmpty(sp.NoOFConsumersY)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersY),
                            NoOfConsumersB = string.IsNullOrEmpty(sp.NoOFConsumersB)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersB),
                            NoOfConsumersRyb = string.IsNullOrEmpty(sp.NoOfConsumersRyb)
                                ? 0
                                : Convert.ToInt32(sp.NoOfConsumersRyb),

                            AggregateLoadkw = string.IsNullOrEmpty(sp.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(sp.AggregateLoadkw),
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(p => p.ServicePointType == 1),
                            total3PhaseCount = k.Count(p => p.ServicePointType == 2),
                            totalBothCount = k.Count(p => p.ServicePointType == 3),

                            total11kVolCatCount = k.Count(p => p.VoltageCategory == 1),
                            total400VolCatCount = k.Count(p => p.VoltageCategory == 2),
                            total230VolCatCount = k.Count(p => p.VoltageCategory == 3),

                            totalRConsumers = k.Sum(p => p.NoOfConsumersR),
                            totalYConsumers = k.Sum(p => p.NoOfConsumersY),
                            totalBConsumers = k.Sum(p => p.NoOfConsumersB),
                            totalRYBConsumers = k.Sum(p => p.NoOfConsumersRyb),

                            totalAggregateLoad = (k.Sum(p => p.AggregateLoadkw) / 1000).ToString("0.##"),
                            maxAggregateLoad = k.Max(p => p.AggregateLoadkw),
                            minAggregateLoad = k.Min(p => p.AggregateLoadkw),
                        })
                        .ToList();


                    regions = _context.TblSubstation
                        .Where(s =>
                            (zoneCode.Equals("") || s.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                            && (circleCode.Equals("") || s.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                            && (snDCode.Equals("") || s.SnDCode.Equals(snDCode))
                            && (substationCode.Equals("") || s.SubstationId.Equals(substationCode)))
                        .Include(z => z.SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .Select(s => new
                        {
                            regionCode = s.SubstationId,
                            zoneName = s.SubstationToLookUpSnD.CircleInfo.ZoneInfo.ZoneName,
                            circleName = s.SubstationToLookUpSnD.CircleInfo.CircleName,
                            sndName = s.SubstationToLookUpSnD.SnDName,
                            substationName = s.SubstationName,
                        })
                        .ToList();

                    data = (from rg in regions
                            join sp in spInfo on rg.regionCode equals sp.regionCode into rsp
                            from sp in rsp.DefaultIfEmpty()
                            select new
                            {
                                substationCode = rg.regionCode,
                                rg.zoneName,
                                rg.circleName,
                                rg.sndName,
                                rg.substationName,

                                sp?.totalCount,

                                sp?.totalSingleCount,
                                sp?.total3PhaseCount,
                                sp?.totalBothCount,

                                sp?.total11kVolCatCount,
                                sp?.total400VolCatCount,
                                sp?.total230VolCatCount,

                                sp?.totalRConsumers,
                                sp?.totalYConsumers,
                                sp?.totalBConsumers,
                                sp?.totalRYBConsumers,

                                sp?.totalAggregateLoad,
                                sp?.maxAggregateLoad,
                                sp?.minAggregateLoad,
                            })
                        .ToList();

                    break;


                default:

                    spInfo = qry
                        .Select(sp => new
                        {
                            RegionCode = sp.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo.ZoneCode,

                            ServicePointType = sp.ServicePointTypeId ?? 0,
                            VoltageCategory = sp.VoltageCategoryId ?? 0,

                            NoOfConsumersR = string.IsNullOrEmpty(sp.NoOFConsumersR)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersR),
                            NoOfConsumersY = string.IsNullOrEmpty(sp.NoOFConsumersY)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersY),
                            NoOfConsumersB = string.IsNullOrEmpty(sp.NoOFConsumersB)
                                ? 0
                                : Convert.ToInt32(sp.NoOFConsumersB),
                            NoOfConsumersRyb = string.IsNullOrEmpty(sp.NoOfConsumersRyb)
                                ? 0
                                : Convert.ToInt32(sp.NoOfConsumersRyb),

                            AggregateLoadkw = string.IsNullOrEmpty(sp.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(sp.AggregateLoadkw),
                        })
                        .ToList()
                        .AsQueryable()
                        .GroupBy(f => f.RegionCode)
                        .Select(k => new
                        {
                            regionCode = k.Key,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(p => p.ServicePointType == 1),
                            total3PhaseCount = k.Count(p => p.ServicePointType == 2),
                            totalBothCount = k.Count(p => p.ServicePointType == 3),

                            total11kVolCatCount = k.Count(p => p.VoltageCategory == 1),
                            total400VolCatCount = k.Count(p => p.VoltageCategory == 2),
                            total230VolCatCount = k.Count(p => p.VoltageCategory == 3),

                            totalRConsumers = k.Sum(p => p.NoOfConsumersR),
                            totalYConsumers = k.Sum(p => p.NoOfConsumersY),
                            totalBConsumers = k.Sum(p => p.NoOfConsumersB),
                            totalRYBConsumers = k.Sum(p => p.NoOfConsumersRyb),

                            totalAggregateLoad = (k.Sum(p => p.AggregateLoadkw) / 1000).ToString("0.##"),
                            maxAggregateLoad = k.Max(p => p.AggregateLoadkw),
                            minAggregateLoad = k.Min(p => p.AggregateLoadkw),
                        })
                        .ToList();


                    regions = _context.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            regionCode = z.ZoneCode,
                            zoneName = z.ZoneName,
                            circleName = "",
                            sndName = "",
                            substationName = "",
                        })
                        .ToList();

                    data = (from rg in regions
                            join sp in spInfo on rg.regionCode equals sp.regionCode into rsp
                            from sp in rsp.DefaultIfEmpty()
                            select new
                            {
                                zoneCode = rg.regionCode,
                                rg.zoneName,

                                sp?.totalCount,

                                sp?.totalSingleCount,
                                sp?.total3PhaseCount,
                                sp?.totalBothCount,

                                sp?.total11kVolCatCount,
                                sp?.total400VolCatCount,
                                sp?.total230VolCatCount,

                                sp?.totalRConsumers,
                                sp?.totalYConsumers,
                                sp?.totalBConsumers,
                                sp?.totalRYBConsumers,

                                sp?.totalAggregateLoad,
                                sp?.maxAggregateLoad,
                                sp?.minAggregateLoad,
                            })
                        .ToList();

                    break;
            }

            return Json(data);
        }

        #endregion

    }

}
