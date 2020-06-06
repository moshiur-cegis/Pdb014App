using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Pdb014App.Models;
using Pdb014App.Models.Report;
using Pdb014App.Models.UserManage;
using Pdb014App.Repository;


namespace Pdb014App.Controllers
{
    public class HomeController : Controller
    {
        private readonly PdbDbContext _dbContext;
        private readonly UserDbContext _dbContextUser;
        private readonly UserManager<TblUserRegistrationDetail> _userManager;


        //public HomeController(PdbDbContext context)
        //{
        //    _dbContext = context;
        //}

        //public HomeController(PdbDbContext context, UserDbContext contextUser)
        //{
        //    _dbContext = context;
        //    _dbContextUser = contextUser;
        //}

        public HomeController(PdbDbContext context, UserDbContext contextUser, UserManager<TblUserRegistrationDetail> userManager)
        {
            _dbContext = context;
            _dbContextUser = contextUser;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var regionLevel = "zone";
            var regionList = new List<string>(4) { "", "", "", "" };

            var user = await _userManager.GetUserAsync(User);

            if (user != null && !string.IsNullOrEmpty(user.Id))
            {
                var userInfo = _dbContextUser.UserProfileDetail.SingleOrDefault(u => u.Id == user.Id);

                if (userInfo != null)
                {
                    regionList[0] = userInfo.ZoneCode;
                    regionList[1] = userInfo.CircleCode;
                    regionList[2] = userInfo.SnDCode;
                    regionList[3] = userInfo.SubstationId;


                    if (User.IsInRole("System Administrator"))
                    {
                        regionLevel = "zone";
                    }
                    else if (User.IsInRole("Zone"))
                    {
                        regionLevel = "circle";
                    }
                    else if (User.IsInRole("Circle"))
                    {
                        regionLevel = "snd";
                    }
                    else if (User.IsInRole("SnD"))
                    {
                        regionLevel = "substation";
                    }
                    else if (User.IsInRole("Substation"))
                    {
                        regionLevel = "substation";
                    }
                    else
                    {
                        regionLevel = "zone";
                        
                        if (!string.IsNullOrEmpty(regionList[3]))
                        {
                            regionLevel = "substation";
                        }
                        else if (!string.IsNullOrEmpty(regionList[2]))
                        {
                            regionLevel = "substation";
                        }
                        else if (!string.IsNullOrEmpty(regionList[1]))
                        {
                            regionLevel = "snd";
                        }
                        else if (!string.IsNullOrEmpty(regionList[0]))
                        {
                            regionLevel = "circle";
                        }
                    }
                }
            }


            ViewBag.RegionLevel = regionLevel;

            ViewBag.ZoneCode = regionList[0];
            ViewBag.CircleCode = regionList[1];
            ViewBag.SnDCode = regionList[2];
            ViewBag.SubstationId = regionList[3];


            ViewBag.PlCount = _dbContext.TblPole.Count();
            ViewBag.FlCount = _dbContext.TblFeederLine.Count();
            ViewBag.SsCount = _dbContext.TblSubstation.Count();
            ViewBag.PtCount = _dbContext.TblPhasePowerTransformer.Count();
            ViewBag.DtCount = _dbContext.TblDistributionTransformer.Count();
            ViewBag.CmCount = _dbContext.TblConsumerData.Count();


            return View(GetDashboardData(regionLevel, regionList));
        }

        public async Task<IActionResult> Index_ok()
        {
            ViewBag.RegionLevel = "zone";

            ViewBag.ZoneCode =
                ViewBag.CircleCode =
                    ViewBag.SnDCode =
                        ViewBag.SubstationId = "";


            var user = await _userManager.GetUserAsync(User);

            if (user != null && !string.IsNullOrEmpty(user.Id))
            {
                var userInfo = _dbContextUser.UserProfileDetail.SingleOrDefault(u => u.Id == user.Id);

                if (userInfo != null)
                {
                    ViewBag.ZoneCode = userInfo.ZoneCode;
                    ViewBag.CircleCode = userInfo.CircleCode;
                    ViewBag.SnDCode = userInfo.SnDCode;
                    ViewBag.SubstationId = userInfo.SubstationId;


                    if (User.IsInRole("System Administrator"))
                    {
                        ViewBag.RegionLevel = "zone";
                    }
                    else if (User.IsInRole("Zone"))
                    {
                        ViewBag.RegionLevel = "circle";
                    }
                    else if (User.IsInRole("Circle"))
                    {
                        ViewBag.RegionLevel = "snd";
                    }
                    else if (User.IsInRole("SnD"))
                    {
                        ViewBag.RegionLevel = "substation";
                    }
                    else if (User.IsInRole("Substation"))
                    {
                        ViewBag.RegionLevel = "substation";
                    }
                    else
                    {
                        ViewBag.RegionLevel = "zone";
                    }
                }
            }

            var stInfo = _dbContext.TblSubstation
                .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    StCount = k.Count()
                }).ToList();

            var st11Info = _dbContext.TblSubstation
                .Where(ss => ss.SubstationType.SubstationTypeName.Contains("/11"))
                .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    StCount = k.Count()
                }).ToList();

            var st33Info = _dbContext.TblSubstation
                .Where(ss => ss.SubstationType.SubstationTypeName.Contains("/33"))
                .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    StCount = k.Count()
                }).ToList();


            var flInfo = _dbContext.TblFeederLine
                .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    FlCount = k.Count()
                }).ToList();

            var fl11Info = _dbContext.TblFeederLine
                .Where(fl => fl.NominalVoltage == 11)
                .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    FlCount = k.Count()
                }).ToList();

            var fl33Info = _dbContext.TblFeederLine
                .Where(fl => fl.NominalVoltage == 33)
                .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    FlCount = k.Count()
                }).ToList();


            var dtInfo = _dbContext.TblDistributionTransformer
                .GroupBy(z => z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    DtCount = k.Count()
                }).ToList();

            var dt11Info = _dbContext.TblDistributionTransformer
                .Where(dt => dt.DtToFeederLine.NominalVoltage == 11)
                .GroupBy(z => z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    DtCount = k.Count()
                }).ToList();

            var dt33Info = _dbContext.TblDistributionTransformer
                .Where(dt => dt.DtToFeederLine.NominalVoltage == 33)
                .GroupBy(z => z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    DtCount = k.Count()
                }).ToList();


            var plInfo = _dbContext.TblPole
                .GroupBy(z => z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    PlCount = k.Count()
                }).ToList();


            var ptInfo = _dbContext.TblPhasePowerTransformer
                .GroupBy(z => z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                .Select(k => new
                {
                    ZoneCode = k.Key,
                    PtCount = k.Count()
                }).ToList();


            var zoneList = _dbContext.LookUpZoneInfo.Select(z => new { z.ZoneCode, z.ZoneName }).ToList();


            RegionWiseData dtRow;
            List<RegionWiseData> aData = new List<RegionWiseData>();

            foreach (var zone in zoneList)
            {
                dtRow = new RegionWiseData
                {
                    Name = zone.ZoneName,
                    St = stInfo.FirstOrDefault(ss => ss.ZoneCode == zone.ZoneCode && ss.StCount > 0)?.StCount,
                    St11 = st11Info.FirstOrDefault(ss => ss.ZoneCode == zone.ZoneCode && ss.StCount > 0)?.StCount,
                    St33 = st33Info.FirstOrDefault(ss => ss.ZoneCode == zone.ZoneCode && ss.StCount > 0)?.StCount,
                    Fl = flInfo.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.FlCount > 0)?.FlCount,
                    Fl11 = fl11Info.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.FlCount > 0)?.FlCount,
                    Fl33 = fl33Info.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.FlCount > 0)?.FlCount,
                    Pt = ptInfo.FirstOrDefault(pt => pt.ZoneCode == zone.ZoneCode && pt.PtCount > 0)?.PtCount,
                    Dt = dtInfo.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.DtCount > 0)?.DtCount,
                    Dt11 = dt11Info.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.DtCount > 0)?.DtCount,
                    Dt33 = dt33Info.FirstOrDefault(dt => dt.ZoneCode == zone.ZoneCode && dt.DtCount > 0)?.DtCount,
                    Pl = plInfo.FirstOrDefault(pl => pl.ZoneCode == zone.ZoneCode && pl.PlCount > 0)?.PlCount
                };

                aData.Add(dtRow);
            }


            dtRow = new RegionWiseData
            {
                Name = "Total",
                St = stInfo.Sum(ss => ss.StCount),
                St11 = st11Info.Sum(ss => ss.StCount),
                St33 = st33Info.Sum(ss => ss.StCount),
                Fl = flInfo.Sum(dt => dt.FlCount),
                Fl11 = fl11Info.Sum(dt => dt.FlCount),
                Fl33 = fl33Info.Sum(dt => dt.FlCount),
                Pt = ptInfo.Sum(pt => pt.PtCount),
                Dt = dtInfo.Sum(dt => dt.DtCount),
                Dt11 = dt11Info.Sum(dt => dt.DtCount),
                Dt33 = dt33Info.Sum(dt => dt.DtCount),
                Pl = plInfo.Sum(pl => pl.PlCount)
            };

            aData.Add(dtRow);


            ViewBag.PlCount = plInfo.Sum(pl => pl.PlCount);
            ViewBag.FlCount = flInfo.Sum(fl => fl.FlCount);
            ViewBag.SsCount = stInfo.Sum(ss => ss.StCount);
            ViewBag.PtCount = ptInfo.Sum(pt => pt.PtCount);
            ViewBag.DtCount = dtInfo.Sum(dt => dt.DtCount);
            ViewBag.CmCount = _dbContext.TblConsumerData.Count();

            return View(aData);

        }


        [HttpPost]
        public List<RegionWiseData> GetDashboardData(string regionLevel = "zone", List<string> regionList = null)
        {
            regionLevel = string.IsNullOrEmpty(regionLevel) ? "zone" : regionLevel;

            string zoneCode = "", circleCode = "", snDCode = "", substationId = "";

            if (regionList != null && regionList.Count > 0 && !string.IsNullOrEmpty(regionList[0]))
            {
                zoneCode = regionList[0];

                if (regionList.Count > 1 && !string.IsNullOrEmpty(regionList[1]))
                {
                    circleCode = regionList[1];

                    if (regionList.Count > 2 && !string.IsNullOrEmpty(regionList[2]))
                    {
                        snDCode = regionList[2];

                        if (regionList.Count > 3 && !string.IsNullOrEmpty(regionList[3]))
                        {
                            substationId = regionList[3];
                        }
                    }
                }
            }


            RegionWiseData dtRow;
            List<RegionWiseData> allData = new List<RegionWiseData>();

            switch (regionLevel)
            {
                case "zone":

                    var stInfo = _dbContext.TblSubstation
                        .Where(z => zoneCode.Equals("") || z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    var st11Info = _dbContext.TblSubstation
                        .Where(z => zoneCode.Equals("") ||
                                    z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode) &&
                                    z.SubstationType.SubstationTypeName.Contains("/11"))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    var st33Info = _dbContext.TblSubstation.Where(z =>
                            zoneCode.Equals("") || z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode) &&
                            z.SubstationType.SubstationTypeName.Contains("/33"))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();


                    var flInfo = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") || z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                            .CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    var fl11Info = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode
                                        .Equals(zoneCode) && z.NominalVoltage == 11)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    var fl33Info = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode
                                        .Equals(zoneCode) && z.NominalVoltage == 33)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();


                    var dtInfo = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") || z.DtToFeederLine.FeederLineToRoute.RouteToSubstation
                            .SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    var dt11Info = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleInfo.ZoneCode.Equals(zoneCode) && z.DtToFeederLine.NominalVoltage == 11)
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    var dt33Info = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleInfo.ZoneCode.Equals(zoneCode) && z.DtToFeederLine.NominalVoltage == 33)
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();


                    var plInfo = _dbContext.TblPole
                        .Where(z => zoneCode.Equals("") ||
                                    z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(
                                        zoneCode))
                        .GroupBy(z => z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PlCount = k.Count()
                        })
                        .ToList();


                    var ptInfo = _dbContext.TblPhasePowerTransformer
                        .Where(z => zoneCode.Equals("") || z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD
                            .CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PtCount = k.Count()
                        })
                        .ToList();

                    var regions = _dbContext.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            RegionCode = z.ZoneCode,
                            RegionName = z.ZoneName
                        })
                        .ToList();


                    foreach (var region in regions)
                    {
                        dtRow = new RegionWiseData
                        {
                            Name = region.RegionName,
                            St = stInfo.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St11 = st11Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St33 = st33Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            Fl = flInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl11 = fl11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl33 = fl33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Pt = ptInfo.FirstOrDefault(pt => pt.RegionCode == region.RegionCode && pt.PtCount > 0)
                                ?.PtCount,
                            Dt = dtInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt11 = dt11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt33 = dt33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Pl = plInfo.FirstOrDefault(pl => pl.RegionCode == region.RegionCode && pl.PlCount > 0)
                                ?.PlCount
                        };

                        allData.Add(dtRow);
                    }

                    dtRow = new RegionWiseData
                    {
                        Name = "Total",
                        St = stInfo.Sum(ss => ss.StCount),
                        St11 = st11Info.Sum(ss => ss.StCount),
                        St33 = st33Info.Sum(ss => ss.StCount),
                        Fl = flInfo.Sum(dt => dt.FlCount),
                        Fl11 = fl11Info.Sum(dt => dt.FlCount),
                        Fl33 = fl33Info.Sum(dt => dt.FlCount),
                        Pt = ptInfo.Sum(pt => pt.PtCount),
                        Dt = dtInfo.Sum(dt => dt.DtCount),
                        Dt11 = dt11Info.Sum(dt => dt.DtCount),
                        Dt33 = dt33Info.Sum(dt => dt.DtCount),
                        Pl = plInfo.Sum(pl => pl.PlCount)
                    };

                    allData.Add(dtRow);

                    break;


                case "circle":

                    stInfo = _dbContext.TblSubstation
                        .Where(z => zoneCode.Equals("") || z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    st11Info = _dbContext.TblSubstation
                        .Where(z => zoneCode.Equals("") ||
                                    z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode) &&
                                    z.SubstationType.SubstationTypeName.Contains("/11"))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    st33Info = _dbContext.TblSubstation.Where(z =>
                            zoneCode.Equals("") || z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode) &&
                            z.SubstationType.SubstationTypeName.Contains("/33"))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();


                    flInfo = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") || z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                            .CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    fl11Info = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode
                                        .Equals(zoneCode) && z.NominalVoltage == 11)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    fl33Info = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode
                                        .Equals(zoneCode) && z.NominalVoltage == 33)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();


                    dtInfo = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") || z.DtToFeederLine.FeederLineToRoute.RouteToSubstation
                            .SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    dt11Info = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleInfo.ZoneCode.Equals(zoneCode) && z.DtToFeederLine.NominalVoltage == 11)
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    dt33Info = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleInfo.ZoneCode.Equals(zoneCode) && z.DtToFeederLine.NominalVoltage == 33)
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();


                    plInfo = _dbContext.TblPole
                        .Where(z => zoneCode.Equals("") ||
                                    z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(
                                        zoneCode))
                        .GroupBy(z => z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PlCount = k.Count()
                        })
                        .ToList();


                    ptInfo = _dbContext.TblPhasePowerTransformer
                        .Where(z => zoneCode.Equals("") || z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD
                            .CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PtCount = k.Count()
                        })
                        .ToList();

                    regions = _dbContext.LookUpCircleInfo
                        .Where(c => (zoneCode.Equals("") || c.ZoneCode.Equals(zoneCode))
                                    && (circleCode.Equals("") || c.CircleCode.Equals(circleCode)))
                        .Select(c => new
                        {
                            RegionCode = c.CircleCode,
                            RegionName = c.CircleName
                        })
                        .ToList();


                    foreach (var region in regions)
                    {
                        dtRow = new RegionWiseData
                        {
                            Name = region.RegionName,
                            St = stInfo.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St11 = st11Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St33 = st33Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            Fl = flInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl11 = fl11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl33 = fl33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Pt = ptInfo.FirstOrDefault(pt => pt.RegionCode == region.RegionCode && pt.PtCount > 0)
                                ?.PtCount,
                            Dt = dtInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt11 = dt11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt33 = dt33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Pl = plInfo.FirstOrDefault(pl => pl.RegionCode == region.RegionCode && pl.PlCount > 0)
                                ?.PlCount
                        };

                        allData.Add(dtRow);
                    }

                    dtRow = new RegionWiseData
                    {
                        Name = "Total",
                        St = stInfo.Sum(ss => ss.StCount),
                        St11 = st11Info.Sum(ss => ss.StCount),
                        St33 = st33Info.Sum(ss => ss.StCount),
                        Fl = flInfo.Sum(dt => dt.FlCount),
                        Fl11 = fl11Info.Sum(dt => dt.FlCount),
                        Fl33 = fl33Info.Sum(dt => dt.FlCount),
                        Pt = ptInfo.Sum(pt => pt.PtCount),
                        Dt = dtInfo.Sum(dt => dt.DtCount),
                        Dt11 = dt11Info.Sum(dt => dt.DtCount),
                        Dt33 = dt33Info.Sum(dt => dt.DtCount),
                        Pl = plInfo.Sum(pl => pl.PlCount)
                    };

                    allData.Add(dtRow);

                    break;


                case "snd":

                    stInfo = _dbContext.TblSubstation
                        .Where(z => circleCode.Equals("") || z.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                        .GroupBy(z => z.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    st11Info = _dbContext.TblSubstation
                        .Where(z => circleCode.Equals("") || z.SubstationToLookUpSnD.CircleCode.Equals(circleCode) &&
                            z.SubstationType.SubstationTypeName.Contains("/11"))
                        .GroupBy(z => z.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    st33Info = _dbContext.TblSubstation.Where(z =>
                            circleCode.Equals("") || z.SubstationToLookUpSnD.CircleCode.Equals(circleCode) &&
                            z.SubstationType.SubstationTypeName.Contains("/33"))
                        .GroupBy(z => z.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();


                    flInfo = _dbContext.TblFeederLine
                        .Where(z => circleCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode.Equals(
                                        circleCode))
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    fl11Info = _dbContext.TblFeederLine
                        .Where(z => circleCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode.Equals(
                                        circleCode) && z.NominalVoltage == 11)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    fl33Info = _dbContext.TblFeederLine
                        .Where(z => circleCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode.Equals(
                                        circleCode) && z.NominalVoltage == 33)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();


                    dtInfo = _dbContext.TblDistributionTransformer
                        .Where(z => circleCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleCode.Equals(circleCode))
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    dt11Info = _dbContext.TblDistributionTransformer
                        .Where(z => circleCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleCode.Equals(circleCode) && z.DtToFeederLine.NominalVoltage == 11)
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    dt33Info = _dbContext.TblDistributionTransformer
                        .Where(z => circleCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleCode.Equals(circleCode) && z.DtToFeederLine.NominalVoltage == 33)
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();


                    plInfo = _dbContext.TblPole
                        .Where(z => circleCode.Equals("") ||
                                    z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleCode.Equals(circleCode))
                        .GroupBy(z => z.PoleToRoute.RouteToSubstation.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PlCount = k.Count()
                        })
                        .ToList();


                    ptInfo = _dbContext.TblPhasePowerTransformer
                        .Where(z => circleCode.Equals("") ||
                                    z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleCode.Equals(
                                        circleCode))
                        .GroupBy(z => z.PhasePowerTransformerToTblSubstation.SnDCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PtCount = k.Count()
                        })
                        .ToList();


                    regions = _dbContext.LookUpSnDInfo
                        .Where(d => (circleCode.Equals("") || d.CircleCode.Equals(circleCode))
                                    && (snDCode.Equals("") || d.SnDCode.Equals(snDCode)))
                        .Select(d => new
                        {
                            RegionCode = d.SnDCode,
                            RegionName = d.SnDName
                        })
                        .ToList();


                    foreach (var region in regions)
                    {
                        dtRow = new RegionWiseData
                        {
                            Name = region.RegionName,
                            St = stInfo.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St11 = st11Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St33 = st33Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            Fl = flInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl11 = fl11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl33 = fl33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Pt = ptInfo.FirstOrDefault(pt => pt.RegionCode == region.RegionCode && pt.PtCount > 0)
                                ?.PtCount,
                            Dt = dtInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt11 = dt11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt33 = dt33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Pl = plInfo.FirstOrDefault(pl => pl.RegionCode == region.RegionCode && pl.PlCount > 0)
                                ?.PlCount
                        };

                        allData.Add(dtRow);
                    }

                    dtRow = new RegionWiseData
                    {
                        Name = "Total",
                        St = stInfo.Sum(ss => ss.StCount),
                        St11 = st11Info.Sum(ss => ss.StCount),
                        St33 = st33Info.Sum(ss => ss.StCount),
                        Fl = flInfo.Sum(dt => dt.FlCount),
                        Fl11 = fl11Info.Sum(dt => dt.FlCount),
                        Fl33 = fl33Info.Sum(dt => dt.FlCount),
                        Pt = ptInfo.Sum(pt => pt.PtCount),
                        Dt = dtInfo.Sum(dt => dt.DtCount),
                        Dt11 = dt11Info.Sum(dt => dt.DtCount),
                        Dt33 = dt33Info.Sum(dt => dt.DtCount),
                        Pl = plInfo.Sum(pl => pl.PlCount)
                    };

                    allData.Add(dtRow);

                    break;


                case "substation":

                    stInfo = _dbContext.TblSubstation
                        .Where(z => snDCode.Equals("") || z.SubstationToLookUpSnD.SnDCode.Equals(snDCode))
                        .GroupBy(z => z.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    st11Info = _dbContext.TblSubstation
                        .Where(z => snDCode.Equals("") || z.SubstationToLookUpSnD.SnDCode.Equals(snDCode) &&
                            z.SubstationType.SubstationTypeName.Contains("/11"))
                        .GroupBy(z => z.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    st33Info = _dbContext.TblSubstation.Where(z =>
                            snDCode.Equals("") || z.SubstationToLookUpSnD.SnDCode.Equals(snDCode) &&
                            z.SubstationType.SubstationTypeName.Contains("/33"))
                        .GroupBy(z => z.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();


                    flInfo = _dbContext.TblFeederLine
                        .Where(z => snDCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDCode.Equals(snDCode))
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    fl11Info = _dbContext.TblFeederLine
                        .Where(z => snDCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDCode
                                        .Equals(snDCode) && z.NominalVoltage == 11)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    fl33Info = _dbContext.TblFeederLine
                        .Where(z => snDCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDCode
                                        .Equals(snDCode) && z.NominalVoltage == 33)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();


                    dtInfo = _dbContext.TblDistributionTransformer
                        .Where(z => snDCode.Equals("") || z.DtToFeederLine.FeederLineToRoute.RouteToSubstation
                            .SubstationToLookUpSnD.SnDCode.Equals(snDCode))
                        .GroupBy(z => z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    dt11Info = _dbContext.TblDistributionTransformer
                        .Where(z => snDCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDCode
                                        .Equals(snDCode) && z.DtToFeederLine.NominalVoltage == 11)
                        .GroupBy(z => z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    dt33Info = _dbContext.TblDistributionTransformer
                        .Where(z => snDCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDCode
                                        .Equals(snDCode) && z.DtToFeederLine.NominalVoltage == 33)
                        .GroupBy(z => z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();


                    plInfo = _dbContext.TblPole
                        .Where(z => snDCode.Equals("") ||
                                    z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.SnDCode.Equals(snDCode))
                        .GroupBy(z => z.PoleToRoute.RouteToSubstation.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PlCount = k.Count()
                        })
                        .ToList();


                    ptInfo = _dbContext.TblPhasePowerTransformer
                        .Where(z => snDCode.Equals("") ||
                                    z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.SnDCode
                                        .Equals(snDCode))
                        .GroupBy(z => z.PhasePowerTransformerToTblSubstation.SubstationId)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PtCount = k.Count()
                        })
                        .ToList();


                    regions = _dbContext.TblSubstation
                        .Where(s =>
                            (snDCode.Equals("") || s.SnDCode.Equals(snDCode))
                            && (substationId.Equals("") || s.SubstationId.Equals(substationId)))
                        .Select(s => new
                        {
                            RegionCode = s.SubstationId,
                            RegionName = s.SubstationName
                        })
                        .ToList();


                    foreach (var region in regions)
                    {
                        dtRow = new RegionWiseData
                        {
                            Name = region.RegionName,
                            St = stInfo.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St11 = st11Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St33 = st33Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            Fl = flInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl11 = fl11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl33 = fl33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Pt = ptInfo.FirstOrDefault(pt => pt.RegionCode == region.RegionCode && pt.PtCount > 0)
                                ?.PtCount,
                            Dt = dtInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt11 = dt11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt33 = dt33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Pl = plInfo.FirstOrDefault(pl => pl.RegionCode == region.RegionCode && pl.PlCount > 0)
                                ?.PlCount
                        };

                        allData.Add(dtRow);
                    }

                    dtRow = new RegionWiseData
                    {
                        Name = "Total",
                        St = stInfo.Sum(ss => ss.StCount),
                        St11 = st11Info.Sum(ss => ss.StCount),
                        St33 = st33Info.Sum(ss => ss.StCount),
                        Fl = flInfo.Sum(dt => dt.FlCount),
                        Fl11 = fl11Info.Sum(dt => dt.FlCount),
                        Fl33 = fl33Info.Sum(dt => dt.FlCount),
                        Pt = ptInfo.Sum(pt => pt.PtCount),
                        Dt = dtInfo.Sum(dt => dt.DtCount),
                        Dt11 = dt11Info.Sum(dt => dt.DtCount),
                        Dt33 = dt33Info.Sum(dt => dt.DtCount),
                        Pl = plInfo.Sum(pl => pl.PlCount)
                    };

                    allData.Add(dtRow);

                    break;


                default:

                    stInfo = _dbContext.TblSubstation
                        .Where(z => zoneCode.Equals("") || z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    st11Info = _dbContext.TblSubstation
                        .Where(z => zoneCode.Equals("") ||
                                    z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode) &&
                                    z.SubstationType.SubstationTypeName.Contains("/11"))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();

                    st33Info = _dbContext.TblSubstation.Where(z =>
                            zoneCode.Equals("") || z.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode) &&
                            z.SubstationType.SubstationTypeName.Contains("/33"))
                        .GroupBy(z => z.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            StCount = k.Count()
                        })
                        .ToList();


                    flInfo = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") || z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                            .CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    fl11Info = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode
                                        .Equals(zoneCode) && z.NominalVoltage == 11)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();

                    fl33Info = _dbContext.TblFeederLine
                        .Where(z => zoneCode.Equals("") ||
                                    z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode
                                        .Equals(zoneCode) && z.NominalVoltage == 33)
                        .GroupBy(z => z.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            FlCount = k.Count()
                        })
                        .ToList();


                    dtInfo = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") || z.DtToFeederLine.FeederLineToRoute.RouteToSubstation
                            .SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    dt11Info = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleInfo.ZoneCode.Equals(zoneCode) && z.DtToFeederLine.NominalVoltage == 11)
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();

                    dt33Info = _dbContext.TblDistributionTransformer
                        .Where(z => zoneCode.Equals("") ||
                                    z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD
                                        .CircleInfo.ZoneCode.Equals(zoneCode) && z.DtToFeederLine.NominalVoltage == 33)
                        .GroupBy(z =>
                            z.DtToFeederLine.FeederLineToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo
                                .ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            DtCount = k.Count()
                        })
                        .ToList();


                    plInfo = _dbContext.TblPole
                        .Where(z => zoneCode.Equals("") ||
                                    z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode.Equals(
                                        zoneCode))
                        .GroupBy(z => z.PoleToRoute.RouteToSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PlCount = k.Count()
                        })
                        .ToList();


                    ptInfo = _dbContext.TblPhasePowerTransformer
                        .Where(z => zoneCode.Equals("") || z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD
                            .CircleInfo.ZoneCode.Equals(zoneCode))
                        .GroupBy(z => z.PhasePowerTransformerToTblSubstation.SubstationToLookUpSnD.CircleInfo.ZoneCode)
                        .Select(k => new
                        {
                            RegionCode = k.Key,
                            PtCount = k.Count()
                        })
                        .ToList();

                    regions = _dbContext.LookUpZoneInfo
                        .Where(z => zoneCode.Equals("") || z.ZoneCode.Equals(zoneCode))
                        .Select(z => new
                        {
                            RegionCode = z.ZoneCode,
                            RegionName = z.ZoneName
                        })
                        .ToList();


                    foreach (var region in regions)
                    {
                        dtRow = new RegionWiseData
                        {
                            Name = region.RegionName,
                            St = stInfo.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St11 = st11Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            St33 = st33Info.FirstOrDefault(ss => ss.RegionCode == region.RegionCode && ss.StCount > 0)
                                ?.StCount,
                            Fl = flInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl11 = fl11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Fl33 = fl33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.FlCount > 0)
                                ?.FlCount,
                            Pt = ptInfo.FirstOrDefault(pt => pt.RegionCode == region.RegionCode && pt.PtCount > 0)
                                ?.PtCount,
                            Dt = dtInfo.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt11 = dt11Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Dt33 = dt33Info.FirstOrDefault(dt => dt.RegionCode == region.RegionCode && dt.DtCount > 0)
                                ?.DtCount,
                            Pl = plInfo.FirstOrDefault(pl => pl.RegionCode == region.RegionCode && pl.PlCount > 0)
                                ?.PlCount
                        };

                        allData.Add(dtRow);
                    }

                    dtRow = new RegionWiseData
                    {
                        Name = "Total",
                        St = stInfo.Sum(ss => ss.StCount),
                        St11 = st11Info.Sum(ss => ss.StCount),
                        St33 = st33Info.Sum(ss => ss.StCount),
                        Fl = flInfo.Sum(dt => dt.FlCount),
                        Fl11 = fl11Info.Sum(dt => dt.FlCount),
                        Fl33 = fl33Info.Sum(dt => dt.FlCount),
                        Pt = ptInfo.Sum(pt => pt.PtCount),
                        Dt = dtInfo.Sum(dt => dt.DtCount),
                        Dt11 = dt11Info.Sum(dt => dt.DtCount),
                        Dt33 = dt33Info.Sum(dt => dt.DtCount),
                        Pl = plInfo.Sum(pl => pl.PlCount)
                    };

                    allData.Add(dtRow);

                    break;
            }


            return allData;
            //return Json(allData);
        }




        [HttpPost]
        public JsonResult GetBasicData(string regionLevel = "zone", List<string> regionList = null)
        {
            return Json(GetDashboardData(regionLevel, regionList));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
