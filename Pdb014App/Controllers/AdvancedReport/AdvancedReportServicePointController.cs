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

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

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

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

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

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];
                                //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                                //tempExp = model => model. == substationCode;
                                //searchExp = ExpressionExtension<TblConsumerData>.AndAlso(searchExp, tempExp);
                            }
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
                    data = qry
                        .Include(st =>
                            st.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i =>
                            i.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerTypeId == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerTypeId == 2),

                            //total11kOpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("11")),
                            //total400OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("400")),
                            //total230OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("230")),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltageId == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltageId == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltageId == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatusId == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatusId == 2),

                            totalMotherCount = k.Count(d => d.ConnectionTypeId == 1),
                            totalChildCount = k.Count(d => d.ConnectionTypeId == 2),
                            totalNACount = k.Count(d => d.ConnectionTypeId == 3),

                            totalPreCardCount = k.Count(d => d.MeterTypeId == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterTypeId == 2),
                            totalPreSmartCount = k.Count(d => d.MeterTypeId == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterTypeId == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterTypeId == 5),

                            totalRCount = k.Count(d => d.PhasingCodeId == 1),
                            totalYCount = k.Count(d => d.PhasingCodeId == 2),
                            totalBCount = k.Count(d => d.PhasingCodeId == 3),
                            totalRYBCount = k.Count(d => d.PhasingCodeId == 4),

                            totalEducationCount = k.Count(d => d.BusinessTypeId == 2),
                            totalHospitalCount = k.Count(d => d.BusinessTypeId == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessTypeId == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessTypeId == 5),
                            totalOfficeCount = k.Count(d => d.BusinessTypeId == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessTypeId == 7),
                            totalReligiousCount = k.Count(d => d.BusinessTypeId == 10),
                            totalResidentialCount = k.Count(d => d.BusinessTypeId == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessTypeId == 12),
                            totalBusinessCount = k.Count(d => d.BusinessTypeId == 51),
                            totalOthersCount = k.Count(d => d.BusinessTypeId == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableTypeId == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableTypeId == 2),

                            totalPaccaCount = k.Count(d => d.StructureTypeId == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureTypeId == 2),
                            totalWoodenCount = k.Count(d => d.StructureTypeId == 3),
                            totalEarthenCount = k.Count(d => d.StructureTypeId == 4),

                        }).ToList();
                    break;


                case "circle":
                    data = qry
                        .Include(st =>
                            st.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i =>
                            i.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            //wl = k.Sum(d => d.Poles.Sum(pi => pi.WireLength)),
                            zoneName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo.ZoneInfo.ZoneName,
                            circleCode = k.Key,
                            circleName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerTypeId == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerTypeId == 2),

                            //total11kOpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("11")),
                            //total400OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("400")),
                            //total230OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("230")),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltageId == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltageId == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltageId == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatusId == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatusId == 2),

                            totalMotherCount = k.Count(d => d.ConnectionTypeId == 1),
                            totalChildCount = k.Count(d => d.ConnectionTypeId == 2),
                            totalNACount = k.Count(d => d.ConnectionTypeId == 3),

                            totalPreCardCount = k.Count(d => d.MeterTypeId == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterTypeId == 2),
                            totalPreSmartCount = k.Count(d => d.MeterTypeId == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterTypeId == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterTypeId == 5),

                            totalRCount = k.Count(d => d.PhasingCodeId == 1),
                            totalYCount = k.Count(d => d.PhasingCodeId == 2),
                            totalBCount = k.Count(d => d.PhasingCodeId == 3),
                            totalRYBCount = k.Count(d => d.PhasingCodeId == 4),

                            totalEducationCount = k.Count(d => d.BusinessTypeId == 2),
                            totalHospitalCount = k.Count(d => d.BusinessTypeId == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessTypeId == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessTypeId == 5),
                            totalOfficeCount = k.Count(d => d.BusinessTypeId == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessTypeId == 7),
                            totalReligiousCount = k.Count(d => d.BusinessTypeId == 10),
                            totalResidentialCount = k.Count(d => d.BusinessTypeId == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessTypeId == 12),
                            totalBusinessCount = k.Count(d => d.BusinessTypeId == 51),
                            totalOthersCount = k.Count(d => d.BusinessTypeId == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableTypeId == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableTypeId == 2),

                            totalPaccaCount = k.Count(d => d.StructureTypeId == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureTypeId == 2),
                            totalWoodenCount = k.Count(d => d.StructureTypeId == 3),
                            totalEarthenCount = k.Count(d => d.StructureTypeId == 4),

                        })
                        .ToList();
                    break;

                case "snd":
                    data = qry
                        .Include(st =>
                            st.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD)
                        .Include(st =>
                            st.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo)
                        .Include(st =>
                            st.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i =>
                            i.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            zoneName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndCode = k.Key,
                            sndName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.SnDName,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerTypeId == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerTypeId == 2),

                            //total11kOpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("11")),
                            //total400OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("400")),
                            //total230OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("230")),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltageId == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltageId == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltageId == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatusId == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatusId == 2),

                            totalMotherCount = k.Count(d => d.ConnectionTypeId == 1),
                            totalChildCount = k.Count(d => d.ConnectionTypeId == 2),
                            totalNACount = k.Count(d => d.ConnectionTypeId == 3),

                            totalPreCardCount = k.Count(d => d.MeterTypeId == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterTypeId == 2),
                            totalPreSmartCount = k.Count(d => d.MeterTypeId == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterTypeId == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterTypeId == 5),

                            totalRCount = k.Count(d => d.PhasingCodeId == 1),
                            totalYCount = k.Count(d => d.PhasingCodeId == 2),
                            totalBCount = k.Count(d => d.PhasingCodeId == 3),
                            totalRYBCount = k.Count(d => d.PhasingCodeId == 4),

                            totalEducationCount = k.Count(d => d.BusinessTypeId == 2),
                            totalHospitalCount = k.Count(d => d.BusinessTypeId == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessTypeId == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessTypeId == 5),
                            totalOfficeCount = k.Count(d => d.BusinessTypeId == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessTypeId == 7),
                            totalReligiousCount = k.Count(d => d.BusinessTypeId == 10),
                            totalResidentialCount = k.Count(d => d.BusinessTypeId == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessTypeId == 12),
                            totalBusinessCount = k.Count(d => d.BusinessTypeId == 51),
                            totalOthersCount = k.Count(d => d.BusinessTypeId == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableTypeId == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableTypeId == 2),

                            totalPaccaCount = k.Count(d => d.StructureTypeId == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureTypeId == 2),
                            totalWoodenCount = k.Count(d => d.StructureTypeId == 3),
                            totalEarthenCount = k.Count(d => d.StructureTypeId == 4),

                        }).ToList();
                    break;

                case "substation":
                    data = qry
                        .Include(st =>
                            st.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i => i.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.SubstationId)
                        .Select(k => new
                        {
                            zoneName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.SnDName,
                            substationCode = k.Key,
                            substationName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationName,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerTypeId == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerTypeId == 2),

                            //total11kOpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("11")),
                            //total400OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("400")),
                            //total230OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("230")),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltageId == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltageId == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltageId == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatusId == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatusId == 2),

                            totalMotherCount = k.Count(d => d.ConnectionTypeId == 1),
                            totalChildCount = k.Count(d => d.ConnectionTypeId == 2),
                            totalNACount = k.Count(d => d.ConnectionTypeId == 3),

                            totalPreCardCount = k.Count(d => d.MeterTypeId == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterTypeId == 2),
                            totalPreSmartCount = k.Count(d => d.MeterTypeId == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterTypeId == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterTypeId == 5),

                            totalRCount = k.Count(d => d.PhasingCodeId == 1),
                            totalYCount = k.Count(d => d.PhasingCodeId == 2),
                            totalBCount = k.Count(d => d.PhasingCodeId == 3),
                            totalRYBCount = k.Count(d => d.PhasingCodeId == 4),

                            totalEducationCount = k.Count(d => d.BusinessTypeId == 2),
                            totalHospitalCount = k.Count(d => d.BusinessTypeId == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessTypeId == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessTypeId == 5),
                            totalOfficeCount = k.Count(d => d.BusinessTypeId == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessTypeId == 7),
                            totalReligiousCount = k.Count(d => d.BusinessTypeId == 10),
                            totalResidentialCount = k.Count(d => d.BusinessTypeId == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessTypeId == 12),
                            totalBusinessCount = k.Count(d => d.BusinessTypeId == 51),
                            totalOthersCount = k.Count(d => d.BusinessTypeId == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableTypeId == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableTypeId == 2),

                            totalPaccaCount = k.Count(d => d.StructureTypeId == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureTypeId == 2),
                            totalWoodenCount = k.Count(d => d.StructureTypeId == 3),
                            totalEarthenCount = k.Count(d => d.StructureTypeId == 4),

                        }).ToList();
                    break;

                default:
                    data = qry
                        .Include(st =>
                            st.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i =>
                            i.ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().ConsumerDataToServicesPoint.ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),

                            totalGovtCount = k.Count(d => d.ConsumerTypeId == 1),
                            totalPrivateCount = k.Count(d => d.ConsumerTypeId == 2),

                            //total11kOpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("11")),
                            //total400OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("400")),
                            //total230OpeVolCount = k.Count(d => d.ConsumerToOperatingVoltage.OperatingVoltageName.Contains("230")),

                            total11kOpeVolCount = k.Count(d => d.OperatingVoltageId == 1),
                            total400OpeVolCount = k.Count(d => d.OperatingVoltageId == 2),
                            total230OpeVolCount = k.Count(d => d.OperatingVoltageId == 3),

                            totalRegularCount = k.Count(d => d.ConnectionStatusId == 1),
                            totalTemporaryCount = k.Count(d => d.ConnectionStatusId == 2),

                            totalMotherCount = k.Count(d => d.ConnectionTypeId == 1),
                            totalChildCount = k.Count(d => d.ConnectionTypeId == 2),
                            totalNACount = k.Count(d => d.ConnectionTypeId == 3),

                            totalPreCardCount = k.Count(d => d.MeterTypeId == 1),
                            totalPreKeypadCount = k.Count(d => d.MeterTypeId == 2),
                            totalPreSmartCount = k.Count(d => d.MeterTypeId == 3),
                            totalPosDigitalCount = k.Count(d => d.MeterTypeId == 4),
                            totalPosAnalogueCount = k.Count(d => d.MeterTypeId == 5),

                            totalRCount = k.Count(d => d.PhasingCodeId == 1),
                            totalYCount = k.Count(d => d.PhasingCodeId == 2),
                            totalBCount = k.Count(d => d.PhasingCodeId == 3),
                            totalRYBCount = k.Count(d => d.PhasingCodeId == 4),

                            totalEducationCount = k.Count(d => d.BusinessTypeId == 2),
                            totalHospitalCount = k.Count(d => d.BusinessTypeId == 3),
                            totalFreedomFighterCount = k.Count(d => d.BusinessTypeId == 4),
                            totalWaterPumpCount = k.Count(d => d.BusinessTypeId == 5),
                            totalOfficeCount = k.Count(d => d.BusinessTypeId == 6),
                            totalStreetLightCount = k.Count(d => d.BusinessTypeId == 7),
                            totalReligiousCount = k.Count(d => d.BusinessTypeId == 10),
                            totalResidentialCount = k.Count(d => d.BusinessTypeId == 11),
                            totalMixedResidentialCount = k.Count(d => d.BusinessTypeId == 12),
                            totalBusinessCount = k.Count(d => d.BusinessTypeId == 51),
                            totalOthersCount = k.Count(d => d.BusinessTypeId == 99),

                            totalPVCCount = k.Count(d => d.ServiceCableTypeId == 1),
                            totalCBVCount = k.Count(d => d.ServiceCableTypeId == 2),

                            totalPaccaCount = k.Count(d => d.StructureTypeId == 1),
                            totalSemiPaccaCount = k.Count(d => d.StructureTypeId == 2),
                            totalWoodenCount = k.Count(d => d.StructureTypeId == 3),
                            totalEarthenCount = k.Count(d => d.StructureTypeId == 4),

                        }).ToList();
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

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

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
            //return View("ServicePointInfo");
        }

        [HttpPost]
        public JsonResult GetServicePointInfoData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            Expression<Func<TblServicePoint, bool>> searchExp = null;

            string zoneCode, circleCode, snDCode, substationCode, routeCode;

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

                            if (regionList.Count > 4 && !string.IsNullOrEmpty(regionList[4]))
                            {
                                routeCode = regionList[4];
                                //Expression<Func<LookUpRouteInfo, bool>> tempExpR = model => model.RouteCode == routeCode;

                                //tempExp = model => model. == substationCode;
                                //searchExp = ExpressionExtension<TblServicePoint>.AndAlso(searchExp, tempExp);
                            }
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
                    data = qry
                        .Include(st =>
                            st.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneInfo)
                        .GroupBy(i =>
                            i.ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().ServicePointToPole.PoleToRoute
                                .RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(d => d.ServicePointTypeId == 1),
                            total3PhaseCount = k.Count(d => d.ServicePointTypeId == 2),
                            totalBothCount = k.Count(d => d.ServicePointTypeId == 3),

                            total11kVolCatCount = k.Count(d => d.VoltageCategoryId == 1),
                            total400VolCatCount = k.Count(d => d.VoltageCategoryId == 2),
                            total230VolCatCount = k.Count(d => d.VoltageCategoryId == 3),

                            totalRConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersR) ? 0 : Convert.ToInt32(d.NoOFConsumersR)),
                            totalYConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersY) ? 0 : Convert.ToInt32(d.NoOFConsumersY)),
                            totalBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersB) ? 0 : Convert.ToInt32(d.NoOFConsumersB)),
                            totalRYBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOfConsumersRyb) ? 0 : Convert.ToInt32(d.NoOfConsumersRyb)),

                            totalAggregateLoad = k.Sum(d => string.IsNullOrEmpty(d.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(d.AggregateLoadkw)) / 1000,
                            maxAggregateLoad = k.Max(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),
                            minAggregateLoad = k.Min(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),


                            //total11kOpeVolCount = k.Count(d => d.ServicePointToOperatingVoltage.OperatingVoltageName.Contains("11")),
                            //total400OpeVolCount = k.Count(d => d.ServicePointToOperatingVoltage.OperatingVoltageName.Contains("400")),
                            //total230OpeVolCount = k.Count(d => d.ServicePointToOperatingVoltage.OperatingVoltageName.Contains("230")),

                            //total11kOpeVolCount = k.Count(d => d.OperatingVoltageId == 1),
                            //total400OpeVolCount = k.Count(d => d.OperatingVoltageId == 2),
                            //total230OpeVolCount = k.Count(d => d.OperatingVoltageId == 3),


                        }).ToList();
                    break;


                case "circle":
                    data = qry
                        .Include(st =>
                            st.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo)
                        .GroupBy(i =>
                            i.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            //wl = k.Sum(d => d.Poles.Sum(pi => pi.WireLength)),
                            zoneName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo.ZoneInfo.ZoneName,
                            circleCode = k.Key,
                            circleName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo
                                .CircleName,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(d => d.ServicePointTypeId == 1),
                            total3PhaseCount = k.Count(d => d.ServicePointTypeId == 2),
                            totalBothCount = k.Count(d => d.ServicePointTypeId == 3),

                            total11kVolCatCount = k.Count(d => d.VoltageCategoryId == 1),
                            total400VolCatCount = k.Count(d => d.VoltageCategoryId == 2),
                            total230VolCatCount = k.Count(d => d.VoltageCategoryId == 3),

                            totalRConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersR) ? 0 : Convert.ToInt32(d.NoOFConsumersR)),
                            totalYConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersY) ? 0 : Convert.ToInt32(d.NoOFConsumersY)),
                            totalBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersB) ? 0 : Convert.ToInt32(d.NoOFConsumersB)),
                            totalRYBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOfConsumersRyb) ? 0 : Convert.ToInt32(d.NoOfConsumersRyb)),

                            totalAggregateLoad = k.Sum(d => string.IsNullOrEmpty(d.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(d.AggregateLoadkw)) / 1000,
                            maxAggregateLoad = k.Max(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),
                            minAggregateLoad = k.Min(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),

                        })
                        .ToList();
                    break;

                case "snd":
                    data = qry
                        .Include(st => st.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD)
                        .Include(st =>
                            st.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo)
                        .Include(st =>
                            st.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo)
                        .GroupBy(i => i.ServicePointToPole.PoleToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            zoneName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndCode = k.Key,
                            sndName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .SnDName,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(d => d.ServicePointTypeId == 1),
                            total3PhaseCount = k.Count(d => d.ServicePointTypeId == 2),
                            totalBothCount = k.Count(d => d.ServicePointTypeId == 3),

                            total11kVolCatCount = k.Count(d => d.VoltageCategoryId == 1),
                            total400VolCatCount = k.Count(d => d.VoltageCategoryId == 2),
                            total230VolCatCount = k.Count(d => d.VoltageCategoryId == 3),

                            totalRConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersR) ? 0 : Convert.ToInt32(d.NoOFConsumersR)),
                            totalYConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersY) ? 0 : Convert.ToInt32(d.NoOFConsumersY)),
                            totalBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersB) ? 0 : Convert.ToInt32(d.NoOFConsumersB)),
                            totalRYBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOfConsumersRyb) ? 0 : Convert.ToInt32(d.NoOfConsumersRyb)),

                            totalAggregateLoad = k.Sum(d => string.IsNullOrEmpty(d.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(d.AggregateLoadkw)) / 1000,
                            maxAggregateLoad = k.Max(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),
                            minAggregateLoad = k.Min(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),

                        }).ToList();
                    break;

                case "substation":
                    data = qry
                        .Include(st =>
                            st.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo)
                        .GroupBy(i => i.ServicePointToPole.PoleToRoute.SubstationId)
                        .Select(k => new
                        {
                            zoneName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo
                                .ZoneInfo.ZoneName,
                            circleName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation
                                .SubstationToLookUpSnD.CircleInfo
                                .CircleName,
                            sndName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .SnDName,
                            substationCode = k.Key,
                            substationName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationName,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(d => d.ServicePointTypeId == 1),
                            total3PhaseCount = k.Count(d => d.ServicePointTypeId == 2),
                            totalBothCount = k.Count(d => d.ServicePointTypeId == 3),

                            total11kVolCatCount = k.Count(d => d.VoltageCategoryId == 1),
                            total400VolCatCount = k.Count(d => d.VoltageCategoryId == 2),
                            total230VolCatCount = k.Count(d => d.VoltageCategoryId == 3),

                            totalRConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersR) ? 0 : Convert.ToInt32(d.NoOFConsumersR)),
                            totalYConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersY) ? 0 : Convert.ToInt32(d.NoOFConsumersY)),
                            totalBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersB) ? 0 : Convert.ToInt32(d.NoOFConsumersB)),
                            totalRYBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOfConsumersRyb) ? 0 : Convert.ToInt32(d.NoOfConsumersRyb)),

                            totalAggregateLoad = k.Sum(d => string.IsNullOrEmpty(d.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(d.AggregateLoadkw)) / 1000,
                            maxAggregateLoad = k.Max(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),
                            minAggregateLoad = k.Min(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),

                        }).ToList();
                    break;

                default:
                    data = qry
                        .Include(st =>
                            st.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneInfo)
                        .GroupBy(i =>
                            i.ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneCode)
                        .Select(k => new
                        {
                            zoneCode = k.Key,
                            zoneName = k.First().ServicePointToPole.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD
                                .CircleInfo
                                .ZoneInfo.ZoneName,

                            totalCount = k.Count(),

                            totalSingleCount = k.Count(d => d.ServicePointTypeId == 1),
                            total3PhaseCount = k.Count(d => d.ServicePointTypeId == 2),
                            totalBothCount = k.Count(d => d.ServicePointTypeId == 3),

                            total11kVolCatCount = k.Count(d => d.VoltageCategoryId == 1),
                            total400VolCatCount = k.Count(d => d.VoltageCategoryId == 2),
                            total230VolCatCount = k.Count(d => d.VoltageCategoryId == 3),

                            totalRConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersR) ? 0 : Convert.ToInt32(d.NoOFConsumersR)),
                            totalYConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersY) ? 0 : Convert.ToInt32(d.NoOFConsumersY)),
                            totalBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOFConsumersB) ? 0 : Convert.ToInt32(d.NoOFConsumersB)),
                            totalRYBConsumers = k.Sum(d =>
                                string.IsNullOrEmpty(d.NoOfConsumersRyb) ? 0 : Convert.ToInt32(d.NoOfConsumersRyb)),

                            totalAggregateLoad = k.Sum(d => string.IsNullOrEmpty(d.AggregateLoadkw)
                                ? 0
                                : Convert.ToInt32(d.AggregateLoadkw)) / 1000,
                            maxAggregateLoad = k.Max(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),
                            minAggregateLoad = k.Min(d =>
                                string.IsNullOrEmpty(d.AggregateLoadkw) ? 0 : Convert.ToInt32(d.AggregateLoadkw)),

                        }).ToList();
                    break;
            }

            return Json(data);
        }

        #endregion

    }

}
