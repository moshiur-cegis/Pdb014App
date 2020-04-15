using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateConsumerInfoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_TblFeederLine_SourceCableId",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_TblFeederLine_TargetCableId",
                table: "TblPole");

            migrationBuilder.DropForeignKey(
                name: "FK_TblServicePoint_TblFeederLine_FeederLineId",
                table: "TblServicePoint");

            migrationBuilder.DropIndex(
                name: "IX_TblServicePoint_FeederLineId",
                table: "TblServicePoint");

            migrationBuilder.DropIndex(
                name: "IX_TblPole_SourceCableId",
                table: "TblPole");

            migrationBuilder.DropIndex(
                name: "IX_TblPole_TargetCableId",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "PeakLoad",
                table: "TblSubstation");

            migrationBuilder.DropColumn(
                name: "BuildingApptNo",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "BuildingType",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "FeederLineId",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "PlotNo",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "PremiseName",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "SourceCableId",
                table: "TblPole");

            migrationBuilder.DropColumn(
                name: "TargetCableId",
                table: "TblPole");

            migrationBuilder.RenameColumn(
                name: "MaximumDemand",
                table: "TblSubstation",
                newName: "WireLength");

            migrationBuilder.RenameColumn(
                name: "VoltageCategory",
                table: "TblServicePoint",
                newName: "VillageOrAreaName");

            migrationBuilder.RenameColumn(
                name: "ServicePointType",
                table: "TblServicePoint",
                newName: "TransformerNumber");

            migrationBuilder.RenameColumn(
                name: "Ws",
                table: "TblConsumerData",
                newName: "StructureMapNo");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TblConsumerData",
                newName: "StructureId");

            migrationBuilder.RenameColumn(
                name: "PhasingCode",
                table: "TblConsumerData",
                newName: "ServiceCableSize");

            migrationBuilder.RenameColumn(
                name: "OperatingVoltage",
                table: "TblConsumerData",
                newName: "PremiseName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "TblConsumerData",
                newName: "PlotNo");

            migrationBuilder.RenameColumn(
                name: "LastReadingDate",
                table: "TblConsumerData",
                newName: "OthersBusiness");

            migrationBuilder.RenameColumn(
                name: "CriticalCustomer",
                table: "TblConsumerData",
                newName: "MeterModel");

            migrationBuilder.RenameColumn(
                name: "ConnectionStatus",
                table: "TblConsumerData",
                newName: "MeterManufacturer");

            migrationBuilder.RenameColumn(
                name: "BusinessType",
                table: "TblConsumerData",
                newName: "CustomerMobileNo");

            migrationBuilder.RenameColumn(
                name: "BcCode",
                table: "TblConsumerData",
                newName: "CustomerAddress");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "TblConsumerData",
                newName: "ConsumerNo");

            migrationBuilder.AlterColumn<decimal>(
                name: "WireLength",
                table: "TblSubstation",
                type: "decimal(7, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicePointTypeId",
                table: "TblServicePoint",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoltageCategoryId",
                table: "TblServicePoint",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SanctionedLoad",
                table: "TblConsumerData",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConnectedLoad",
                table: "TblConsumerData",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookNumber",
                table: "TblConsumerData",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillGroup",
                table: "TblConsumerData",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingApptNo",
                table: "TblConsumerData",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BusinessTypeId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConnectionStatusId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConnectionTypeId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsumerTypeId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallDate",
                table: "TblConsumerData",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "TblConsumerData",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "TblConsumerData",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeterTypeId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFloor",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatingVoltageId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhasingCodeId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceCableTypeId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StructureTypeId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SurveyDate",
                table: "TblConsumerData",
                type: "date",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LookUpBusinessType",
                columns: table => new
                {
                    BusinessTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpBusinessType", x => x.BusinessTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpConnectionStatus",
                columns: table => new
                {
                    ConnectionStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConnectionStatusName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpConnectionStatus", x => x.ConnectionStatusId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpConnectionType",
                columns: table => new
                {
                    ConnectionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConnectionTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpConnectionType", x => x.ConnectionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpConsumerType",
                columns: table => new
                {
                    ConsumerTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsumerTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpConsumerType", x => x.ConsumerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpLocation",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpLocation", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpMeterType",
                columns: table => new
                {
                    MeterTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeterTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpMeterType", x => x.MeterTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpOperatingVoltage",
                columns: table => new
                {
                    OperatingVoltageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperatingVoltageName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpOperatingVoltage", x => x.OperatingVoltageId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpPhasingCodeType",
                columns: table => new
                {
                    PhasingCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhasingCodeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpPhasingCodeType", x => x.PhasingCodeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpServiceCableType",
                columns: table => new
                {
                    ServiceCableTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceCableTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpServiceCableType", x => x.ServiceCableTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpServicePointType",
                columns: table => new
                {
                    ServicePointTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServicePointTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpServicePointType", x => x.ServicePointTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpStructureType",
                columns: table => new
                {
                    StructureTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StructureTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpStructureType", x => x.StructureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpVoltageCategory",
                columns: table => new
                {
                    VoltageCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VoltageCategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpVoltageCategory", x => x.VoltageCategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblServicePoint_ServicePointTypeId",
                table: "TblServicePoint",
                column: "ServicePointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblServicePoint_VoltageCategoryId",
                table: "TblServicePoint",
                column: "VoltageCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_BusinessTypeId",
                table: "TblConsumerData",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_ConnectionStatusId",
                table: "TblConsumerData",
                column: "ConnectionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_ConnectionTypeId",
                table: "TblConsumerData",
                column: "ConnectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_ConsumerTypeId",
                table: "TblConsumerData",
                column: "ConsumerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_LocationId",
                table: "TblConsumerData",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_MeterTypeId",
                table: "TblConsumerData",
                column: "MeterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_OperatingVoltageId",
                table: "TblConsumerData",
                column: "OperatingVoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_PhasingCodeId",
                table: "TblConsumerData",
                column: "PhasingCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_ServiceCableTypeId",
                table: "TblConsumerData",
                column: "ServiceCableTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_StructureTypeId",
                table: "TblConsumerData",
                column: "StructureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpBusinessType_BusinessTypeId",
                table: "TblConsumerData",
                column: "BusinessTypeId",
                principalTable: "LookUpBusinessType",
                principalColumn: "BusinessTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpConnectionStatus_ConnectionStatusId",
                table: "TblConsumerData",
                column: "ConnectionStatusId",
                principalTable: "LookUpConnectionStatus",
                principalColumn: "ConnectionStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpConnectionType_ConnectionTypeId",
                table: "TblConsumerData",
                column: "ConnectionTypeId",
                principalTable: "LookUpConnectionType",
                principalColumn: "ConnectionTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpConsumerType_ConsumerTypeId",
                table: "TblConsumerData",
                column: "ConsumerTypeId",
                principalTable: "LookUpConsumerType",
                principalColumn: "ConsumerTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpLocation_LocationId",
                table: "TblConsumerData",
                column: "LocationId",
                principalTable: "LookUpLocation",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpMeterType_MeterTypeId",
                table: "TblConsumerData",
                column: "MeterTypeId",
                principalTable: "LookUpMeterType",
                principalColumn: "MeterTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpOperatingVoltage_OperatingVoltageId",
                table: "TblConsumerData",
                column: "OperatingVoltageId",
                principalTable: "LookUpOperatingVoltage",
                principalColumn: "OperatingVoltageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpPhasingCodeType_PhasingCodeId",
                table: "TblConsumerData",
                column: "PhasingCodeId",
                principalTable: "LookUpPhasingCodeType",
                principalColumn: "PhasingCodeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpServiceCableType_ServiceCableTypeId",
                table: "TblConsumerData",
                column: "ServiceCableTypeId",
                principalTable: "LookUpServiceCableType",
                principalColumn: "ServiceCableTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_LookUpStructureType_StructureTypeId",
                table: "TblConsumerData",
                column: "StructureTypeId",
                principalTable: "LookUpStructureType",
                principalColumn: "StructureTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblServicePoint_LookUpServicePointType_ServicePointTypeId",
                table: "TblServicePoint",
                column: "ServicePointTypeId",
                principalTable: "LookUpServicePointType",
                principalColumn: "ServicePointTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblServicePoint_LookUpVoltageCategory_VoltageCategoryId",
                table: "TblServicePoint",
                column: "VoltageCategoryId",
                principalTable: "LookUpVoltageCategory",
                principalColumn: "VoltageCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpBusinessType_BusinessTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpConnectionStatus_ConnectionStatusId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpConnectionType_ConnectionTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpConsumerType_ConsumerTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpLocation_LocationId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpMeterType_MeterTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpOperatingVoltage_OperatingVoltageId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpPhasingCodeType_PhasingCodeId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpServiceCableType_ServiceCableTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_LookUpStructureType_StructureTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblServicePoint_LookUpServicePointType_ServicePointTypeId",
                table: "TblServicePoint");

            migrationBuilder.DropForeignKey(
                name: "FK_TblServicePoint_LookUpVoltageCategory_VoltageCategoryId",
                table: "TblServicePoint");

            migrationBuilder.DropTable(
                name: "LookUpBusinessType");

            migrationBuilder.DropTable(
                name: "LookUpConnectionStatus");

            migrationBuilder.DropTable(
                name: "LookUpConnectionType");

            migrationBuilder.DropTable(
                name: "LookUpConsumerType");

            migrationBuilder.DropTable(
                name: "LookUpLocation");

            migrationBuilder.DropTable(
                name: "LookUpMeterType");

            migrationBuilder.DropTable(
                name: "LookUpOperatingVoltage");

            migrationBuilder.DropTable(
                name: "LookUpPhasingCodeType");

            migrationBuilder.DropTable(
                name: "LookUpServiceCableType");

            migrationBuilder.DropTable(
                name: "LookUpServicePointType");

            migrationBuilder.DropTable(
                name: "LookUpStructureType");

            migrationBuilder.DropTable(
                name: "LookUpVoltageCategory");

            migrationBuilder.DropIndex(
                name: "IX_TblServicePoint_ServicePointTypeId",
                table: "TblServicePoint");

            migrationBuilder.DropIndex(
                name: "IX_TblServicePoint_VoltageCategoryId",
                table: "TblServicePoint");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_BusinessTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_ConnectionStatusId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_ConnectionTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_ConsumerTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_LocationId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_MeterTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_OperatingVoltageId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_PhasingCodeId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_ServiceCableTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_StructureTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "ServicePointTypeId",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "VoltageCategoryId",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "BuildingApptNo",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "ConnectionStatusId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "ConnectionTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "ConsumerTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "InstallDate",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "MeterTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "NumberOfFloor",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "OperatingVoltageId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "PhasingCodeId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "ServiceCableTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "StructureTypeId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "SurveyDate",
                table: "TblConsumerData");

            migrationBuilder.RenameColumn(
                name: "WireLength",
                table: "TblSubstation",
                newName: "MaximumDemand");

            migrationBuilder.RenameColumn(
                name: "VillageOrAreaName",
                table: "TblServicePoint",
                newName: "VoltageCategory");

            migrationBuilder.RenameColumn(
                name: "TransformerNumber",
                table: "TblServicePoint",
                newName: "ServicePointType");

            migrationBuilder.RenameColumn(
                name: "StructureMapNo",
                table: "TblConsumerData",
                newName: "Ws");

            migrationBuilder.RenameColumn(
                name: "StructureId",
                table: "TblConsumerData",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ServiceCableSize",
                table: "TblConsumerData",
                newName: "PhasingCode");

            migrationBuilder.RenameColumn(
                name: "PremiseName",
                table: "TblConsumerData",
                newName: "OperatingVoltage");

            migrationBuilder.RenameColumn(
                name: "PlotNo",
                table: "TblConsumerData",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "OthersBusiness",
                table: "TblConsumerData",
                newName: "LastReadingDate");

            migrationBuilder.RenameColumn(
                name: "MeterModel",
                table: "TblConsumerData",
                newName: "CriticalCustomer");

            migrationBuilder.RenameColumn(
                name: "MeterManufacturer",
                table: "TblConsumerData",
                newName: "ConnectionStatus");

            migrationBuilder.RenameColumn(
                name: "CustomerMobileNo",
                table: "TblConsumerData",
                newName: "BusinessType");

            migrationBuilder.RenameColumn(
                name: "CustomerAddress",
                table: "TblConsumerData",
                newName: "BcCode");

            migrationBuilder.RenameColumn(
                name: "ConsumerNo",
                table: "TblConsumerData",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "MaximumDemand",
                table: "TblSubstation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(7, 2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeakLoad",
                table: "TblSubstation",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingApptNo",
                table: "TblServicePoint",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingId",
                table: "TblServicePoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingType",
                table: "TblServicePoint",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeederLineId",
                table: "TblServicePoint",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlotNo",
                table: "TblServicePoint",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PremiseName",
                table: "TblServicePoint",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceCableId",
                table: "TblPole",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetCableId",
                table: "TblPole",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SanctionedLoad",
                table: "TblConsumerData",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConnectedLoad",
                table: "TblConsumerData",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookNumber",
                table: "TblConsumerData",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillGroup",
                table: "TblConsumerData",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblServicePoint_FeederLineId",
                table: "TblServicePoint",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_SourceCableId",
                table: "TblPole",
                column: "SourceCableId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPole_TargetCableId",
                table: "TblPole",
                column: "TargetCableId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_TblFeederLine_SourceCableId",
                table: "TblPole",
                column: "SourceCableId",
                principalTable: "TblFeederLine",
                principalColumn: "FeederLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_TblFeederLine_TargetCableId",
                table: "TblPole",
                column: "TargetCableId",
                principalTable: "TblFeederLine",
                principalColumn: "FeederLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblServicePoint_TblFeederLine_FeederLineId",
                table: "TblServicePoint",
                column: "FeederLineId",
                principalTable: "TblFeederLine",
                principalColumn: "FeederLineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
