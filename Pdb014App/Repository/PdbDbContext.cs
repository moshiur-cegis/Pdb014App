using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Pdb014App.Models.Basic;
using Pdb014App.Models.PDB;
using Pdb014App.Models.PDB.LookUpModels;
using Pdb014App.Models.PDB.SubstationModels;
using Pdb014App.Models.PDB.ConductorModels;
using Pdb014App.Models.PDB.DistributionTransformerModel;
using Pdb014App.Models.PDB.InsulatorModels;
using Pdb014App.Models.PDB.MeteringPanelModels;
using Pdb014App.Models.PDB.Mount_BracketModels;
using Pdb014App.Models.PDB.PhasePowerTransformerModel;
using Pdb014App.Models.PDB.PoleModels;
using Pdb014App.Models.PDB.ServicePointModels;
using Pdb014App.Models.PDB.SwitchGearModels;
using Pdb014App.Models.PDB.CopperCableModels;
using Pdb014App.Models.Search;
using Pdb014App.Models.MapViewer.Settings;
using Pdb014App.Models.PDB.RegionModels;


namespace Pdb014App.Repository
{
    public class PdbDbContext : DbContext
    {
        public PdbDbContext(DbContextOptions<PdbDbContext> options) : base(options) { }


        [NotMapped]
        public virtual DbSet<AutoCompleteInfo> AutoCompleteInfo { get; set; }


        #region Conductor 2
        public virtual DbSet<TblConductor> TblConductor { get; set; }
        public virtual DbSet<LookUpConductorType> LookUpConductorType { get; set; }
        #endregion

        #region CopperCable 2
        public virtual DbSet<TblCopperCables> TblCopperCables { get; set; }
        public virtual DbSet<LookUpCopperCablesType> LookUpCopperCablesType { get; set; }
        #endregion

        #region DistributionTransformerMode 3
        public virtual DbSet<TblDistributionTransformer> TblDistributionTransformer { get; set; }
        public virtual DbSet<TblDistributionTransformerPicture> TblDistributionTransformerPicture { get; set; }
        public virtual DbSet<TblPoleStructureMountedSurgeArrestor> TblPoleStructureMountedSurgearrestor { get; set; }
        #endregion

        #region InsulatorModels 8
        public virtual DbSet<LookUpInsulatorDiskType> LookUpInsulatorDiskType { get; set; }
        public virtual DbSet<LookUpInsulatorPinAndPostType> LookUpInsulatorPinAndPostType { get; set; }
        public virtual DbSet<LookUpInsulatorShackleOrGuyType> LookUpInsulatorShackleOrGuyType { get; set; }
        public virtual DbSet<TblInsulatorDisk> TblInsulatorDisk { get; set; }
        public virtual DbSet<TblInsulatorPinAndPost> TblInsulatorPinAndPost { get; set; }
        public virtual DbSet<TblInsulatorShackleOrGuy> TblInsulatorShackleOrGuy { get; set; }
        public virtual DbSet<TblAacInsulator> TblAacInsulator { get; set; }
        public virtual DbSet<LookUpAacInsulatorType> LookUpAacInsulatorType { get; set; }

        public virtual DbSet<LookUpGuyType> LookUpGuyType { get; set; }
        public virtual DbSet<LookUpInsulatorType> LookUpInsulatorType { get; set; }
        public virtual DbSet<TblGuy> TblGuy { get; set; }
        public virtual DbSet<TblInsulator> TblInsulator { get; set; }

        #endregion

        #region MeteringPanelModels
        public virtual DbSet<LookUpDifferentMeter> LookUpDifferentMeter { get; set; }
        public virtual DbSet<LookUpDifferentTypesOfMeter> LookUpDifferentTypesOfMeter { get; set; }
        public virtual DbSet<LookupAnnuciator> LookupAnnuciator { get; set; }
        public virtual DbSet<LookupControlSwitch> LookupControlSwitch { get; set; }
        public virtual DbSet<LookUpDifferentRelay> LookUpDifferentRelay { get; set; }
        public virtual DbSet<LookUpDifferentTypesOfRelay> LookUpDifferentTypesOfRelay { get; set; }
        public virtual DbSet<LookUpDimensionAndWeight> LookUpDimensionAndWeight { get; set; }
        public virtual DbSet<TblMeteringPanel> TblMeteringPanel { get; set; }
        #endregion

        #region MountBracketModels
        public virtual DbSet<LookUpSpecificationsOfMountBracketType> LookUpSpecificationsOfMountBracketType { get; set; }
        public virtual DbSet<TblSpecificationsOfMountBracket> TblSpecificationsOfMountBracket { get; set; }
        #endregion

        #region PhasePowerTransformerModel
        public virtual DbSet<TblPhasePowerTransformer> TblPhasePowerTransformer { get; set; }
        public virtual DbSet<TblSurgeArrestor> TblSurgeArrestor { get; set; }
        #endregion

        #region Pole Model 8



        public virtual DbSet<TblSearchFieldList> TblSearchFieldList { get; set; }

        //public virtual DbSet<TblCrossArm> TblCrossArm { get; set; }
        public virtual DbSet<TblCrossArmInfo> TblCrossArmInfo { get; set; }


        public virtual DbSet<TblPoleToMultiFeederlineInfo> TblPoleToMultiFeederlineInfo { get; set; }

        public virtual DbSet<LookUpPoleType> LookUpPoleType { get; set; }
        public virtual DbSet<LookUpPoleCondition> LookUpPoleCondition { get; set; }
        public virtual DbSet<LookUpSagCondition> LookUpSagCondition { get; set; }
        public virtual DbSet<LookUpSideLockTieTerminalClampMerlin> LookUpSideLockTieTerminalClampMerlin { get; set; }
        public virtual DbSet<TblPole> TblPole { get; set; }
        public virtual DbSet<TblPolePicture> TblPolePicture { get; set; }
        public virtual DbSet<TblPoleMountedDofCutOutFuseLink> TblPoleMountedDofCutOutFuseLink { get; set; }


        //public virtual DbSet<VwPoleData> VwPoleData { get; set; } //MNH
        //public virtual DbSet<TblCustomSearchFields> TblCustomSearchFields { get; set; } //MNH

        public virtual DbSet<LookUpCondition> LookUpCondition { get; set; }
        //public virtual DbSet<LookUpGuyCondition> LookUpGuyCondition { get; set; }
        //public virtual DbSet<LookUpGuyType> LookUpGuyType { get; set; }
        public virtual DbSet<LookUpLineType> LookUpLineType { get; set; }
        public virtual DbSet<LookUpTypeOfFittings> LookUpTypeOfFittings { get; set; }
        //public virtual DbSet<LookUpTypeOfInsulator> LookUpTypeOfInsulator { get; set; }
        public virtual DbSet<LookUpTypeOfWire> LookUpTypeOfWire { get; set; }


        #endregion

        #region RegionModels
        public virtual DbSet<LookUpZoneInfo> LookUpZoneInfo { get; set; }
        public virtual DbSet<LookUpCircleInfo> LookUpCircleInfo { get; set; }
        public virtual DbSet<LookUpSnDInfo> LookUpSnDInfo { get; set; }
        public virtual DbSet<LookUpRouteInfo> LookUpRouteInfo { get; set; }
        public virtual DbSet<LookUpAdminBndDistrict> LookUpAdminBndDistrict { get; set; }
        #endregion

        #region ServicePointModels
        public virtual DbSet<TblConsumerData> TblConsumerData { get; set; }
        public virtual DbSet<TblServicePoint> TblServicePoint { get; set; }

        public virtual DbSet<LookUpBusinessType> LookUpBusinessType { get; set; }
        public virtual DbSet<LookUpConnectionStatus> LookUpConnectionStatus { get; set; }
        public virtual DbSet<LookUpConnectionType> LookUpConnectionType { get; set; }
        public virtual DbSet<LookUpConsumerType> LookUpConsumerType { get; set; }
        public virtual DbSet<LookUpLocation> LookUpLocation { get; set; }
        public virtual DbSet<LookUpMeterType> LookUpMeterType { get; set; }
        public virtual DbSet<LookUpOperatingVoltage> LookUpOperatingVoltage { get; set; }
        public virtual DbSet<LookUpPhasingCodeType> LookUpPhasingCodeType { get; set; }
        public virtual DbSet<LookUpServiceCableType> LookUpServiceCableType { get; set; }
        public virtual DbSet<LookUpServicePointType> LookUpServicePointType { get; set; }
        public virtual DbSet<LookUpStructureType> LookUpStructureType { get; set; }
        public virtual DbSet<LookUpVoltageCategory> LookUpVoltageCategory { get; set; }



        #endregion

        #region SubstationModels 11
        public virtual DbSet<TblRelay> TblRelay { get; set; }
        public virtual DbSet<TblSubstation> TblSubstation { get; set; }

        public virtual DbSet<TblAutoCircuitReCloser> TblAutoCircuitReCloser { get; set; }
        public virtual DbSet<LookUpAutoCircuitReCloserType> LookUpAutoCircuitReCloserType { get; set; }
        public virtual DbSet<LookUpAuxiliaryTransformer> LookUpAuxiliaryTransformer { get; set; }
        public virtual DbSet<LookUpBatteryCharger> LookUpBatteryCharger { get; set; }
        public virtual DbSet<LookUpNiCdBattery110vDc> LookUpNiCdBattery110vDc { get; set; }

        public virtual DbSet<TblFeederLine> TblFeederLine { get; set; }

        public virtual DbSet<TblSubstationPicture> TblSubstationPicture { get; set; }

        public virtual DbSet<TblSwitch33KvIsolator> TblSwitch33KvIsolator { get; set; }

        public virtual DbSet<TblOutDoorTypeVacumnCircuitBreaker> TblOutDoorTypeVacumnCircuitBreaker { get; set; }

        public virtual DbSet<LookUpSubstationType> LookUpSubstationType { get; set; }
        public virtual DbSet<LookUpFeederLineType> LookUpFeederLineType { get; set; }


        #endregion

        #region SwitchGearModels
        public virtual DbSet<TblIndoorOutdoorTypeProgrammableEnergyMeter> TblIndoorOutdoorTypeProgrammableEnergyMeter { get; set; }
        public virtual DbSet<LookupBusBar> LookupBusBar { get; set; }
        public virtual DbSet<LookUpCircuitBreaker> LookUpCircuitBreaker { get; set; }
        public virtual DbSet<LookUpCurrentTransformer> LookUpCurrentTransformer { get; set; }
        public virtual DbSet<LookupSf6SafetyAndLife> LookupSf6SafetyAndLife { get; set; }
        public virtual DbSet<LookUpSwitchGearType> LookUpSwitchGearType { get; set; }
        public virtual DbSet<LookUpSwitchGearUnit> LookUpSwitchGearUnit { get; set; }
        public virtual DbSet<LookUpSwitchPosition> LookUpSwitchPosition { get; set; }
        public virtual DbSet<LookUpPotentialTrans33KV> LookUpPotentialTrans33KV { get; set; }
        public virtual DbSet<LookUpTerminationKits> LookUpTerminationKits { get; set; }

        public virtual DbSet<TblSwitchGear> TblSwitchGear { get; set; }
        public DbSet<TblTerminationKit> TblTerminationKit { get; set; }
        public virtual DbSet<TblXLPEaluminiumCopperGalvanize11KV> TblXLPEaluminiumCopperGalvanize11KV { get; set; }
        #endregion

        #region Search
        public virtual DbSet<LookUpModelInfo> LookUpModelInfo { get; set; }
        public virtual DbSet<LookUpModelFieldInfo> LookUpModelFieldInfo { get; set; }

        #endregion

        #region MapViewer
        public virtual DbSet<LookUpMapViewApplicationServer> LookUpMapViewApplicationServer { get; set; }
        public virtual DbSet<LookUpMapViewBaseMapDetail> LookUpMapViewBaseMapDetail { get; set; }
        public virtual DbSet<LookUpMapViewDataSource> LookUpMapViewDataSource { get; set; }
        public virtual DbSet<LookUpMapViewGisServer> LookUpMapViewGisServer { get; set; }
        public virtual DbSet<LookUpMapViewLayerType> LookUpMapViewLayerType { get; set; }
        public virtual DbSet<LookUpMapViewPopUpFieldDetails> LookUpMapViewPopUpFieldDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<TblFeederLine>()
            //    .HasKey(fl => fl.FeederLineId);

            //modelBuilder.Entity<TblFeederLine>()
            //    .HasOne(fl => fl.FeederLineType);

            //    //.WithOne(fl => fl.)
            //    //.HasForeignKey(fl => fl.FeederLineTypeId);

            //    modelBuilder.Entity<TblFeederLine>()
            //        .HasOne(fl => fl.FeederLineToRoute);

            //modelBuilder.Entity<TblFeederLine>()
            //    .HasMany(fl => fl.Poles)
            //    .WithOne(pi=>pi.PoleToFeederLine);

            //modelBuilder.Entity<TblPole>()
            //    .HasOne(pi => pi.PoleToFeederLine)
            //    .WithMany(fl => fl.Poles)
            //    .HasForeignKey(p => p.FeederLineId);

            //modelBuilder.Entity<BookCategory>()
            //    .HasKey(bc => new { bc.BookId, bc.CategoryId });
            //modelBuilder.Entity<BookCategory>()
            //    .HasOne(bc => bc.Category)
            //    .WithMany(c => c.BookCategories)
            //    .HasForeignKey(bc => bc.CategoryId);

        }

    }
}
