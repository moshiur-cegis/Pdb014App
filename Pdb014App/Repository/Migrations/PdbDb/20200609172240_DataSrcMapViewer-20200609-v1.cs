using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class DataSrcMapViewer20200609v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUpMapViewDataSource_LookUpMapViewLayerType_LayerTypeId",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropIndex(
                name: "IX_LookUpMapViewDataSource_LayerTypeId",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "CenterLatitude",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "CenterLongitude",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "DefaultZoomLevel",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "LayerOrder",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "LayerTitle",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "LayerTypeId",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "LayerVisibility",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "MaxScale",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "MinScale",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "PopupTemplateTitle",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolColor",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolOutlineColor",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolOutlineWidth",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolStyle",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolType",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererType",
                table: "LookUpMapViewDataSource");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CenterLatitude",
                table: "LookUpMapViewDataSource",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CenterLongitude",
                table: "LookUpMapViewDataSource",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultZoomLevel",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LayerOrder",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LayerTitle",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(100)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LayerTypeId",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LayerVisibility",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxScale",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinScale",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PopupTemplateTitle",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RendererSymbolColor",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RendererSymbolOutlineColor",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RendererSymbolOutlineWidth",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RendererSymbolStyle",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RendererSymbolType",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RendererType",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookUpMapViewDataSource_LayerTypeId",
                table: "LookUpMapViewDataSource",
                column: "LayerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpMapViewDataSource_LookUpMapViewLayerType_LayerTypeId",
                table: "LookUpMapViewDataSource",
                column: "LayerTypeId",
                principalTable: "LookUpMapViewLayerType",
                principalColumn: "LayerTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
