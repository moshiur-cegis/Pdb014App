using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class ARH_MapViewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InstallDate",
                table: "TblConsumerData",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LookUpMapViewApplicationServer",
                columns: table => new
                {
                    AppServerUrlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppServerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AppServerIPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: true),
                    AppServerFullUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AppServerActivationStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpMapViewApplicationServer", x => x.AppServerUrlId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpMapViewBaseMapDetail",
                columns: table => new
                {
                    BaseMapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseMapName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultZoomLevel = table.Column<int>(type: "int", nullable: true),
                    BaseMapCenterLat = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    BaseMapCenterLong = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    MinScale = table.Column<int>(type: "int", nullable: true),
                    BaseMapActivationStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpMapViewBaseMapDetail", x => x.BaseMapId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpMapViewGisServer",
                columns: table => new
                {
                    GisServerUrlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GisServerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GisServerIPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: true),
                    GisServerFullUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GisServerActivationStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpMapViewGisServer", x => x.GisServerUrlId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpMapViewLayerType",
                columns: table => new
                {
                    LayerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LayerType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LayerTypeActivationStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpMapViewLayerType", x => x.LayerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpMapViewDataSource",
                columns: table => new
                {
                    DataSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSourceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LayerTypeId = table.Column<int>(type: "int", nullable: false),
                    LayerOrder = table.Column<int>(type: "int", nullable: true),
                    LayerTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: true),
                    LayerVisibility = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DefaultZoomLevel = table.Column<int>(type: "int", nullable: true),
                    CenterLatitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    CenterLongitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    MinScale = table.Column<int>(type: "int", nullable: true),
                    MaxScale = table.Column<int>(type: "int", nullable: true),
                    PopupTemplateTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RendererType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RendererSymbolType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RendererSymbolStyle = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    RendererSymbolColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RendererSymbolOutlineColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RendererSymbolOutlineWidth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpMapViewDataSource", x => x.DataSourceId);
                    table.ForeignKey(
                        name: "FK_LookUpMapViewDataSource_LookUpMapViewLayerType_LayerTypeId",
                        column: x => x.LayerTypeId,
                        principalTable: "LookUpMapViewLayerType",
                        principalColumn: "LayerTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookUpMapViewPopUpFieldDetails",
                columns: table => new
                {
                    PopupFieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSourceId = table.Column<int>(type: "int", nullable: false),
                    PopupFieldName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PopupFieldTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PopupContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PopupFieldVisibility = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FieldActivationStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpMapViewPopUpFieldDetails", x => x.PopupFieldId);
                    table.ForeignKey(
                        name: "FK_LookUpMapViewPopUpFieldDetails_LookUpMapViewDataSource_DataSourceId",
                        column: x => x.DataSourceId,
                        principalTable: "LookUpMapViewDataSource",
                        principalColumn: "DataSourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUpMapViewDataSource_LayerTypeId",
                table: "LookUpMapViewDataSource",
                column: "LayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpMapViewPopUpFieldDetails_DataSourceId",
                table: "LookUpMapViewPopUpFieldDetails",
                column: "DataSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUpMapViewApplicationServer");

            migrationBuilder.DropTable(
                name: "LookUpMapViewBaseMapDetail");

            migrationBuilder.DropTable(
                name: "LookUpMapViewGisServer");

            migrationBuilder.DropTable(
                name: "LookUpMapViewPopUpFieldDetails");

            migrationBuilder.DropTable(
                name: "LookUpMapViewDataSource");

            migrationBuilder.DropTable(
                name: "LookUpMapViewLayerType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InstallDate",
                table: "TblConsumerData",
                type: "date",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
