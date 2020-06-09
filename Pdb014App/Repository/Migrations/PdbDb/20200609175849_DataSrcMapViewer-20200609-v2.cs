using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class DataSrcMapViewer20200609v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PopupFieldVisibility",
                table: "LookUpMapViewPopUpFieldDetails",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

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
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LayerVisibility",
                table: "LookUpMapViewDataSource",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PopupTemplateName",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RendererSymbolColorB",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RendererSymbolColorG",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RendererSymbolColorOpacity",
                table: "LookUpMapViewDataSource",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RendererSymbolColorR",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RendererSymbolOutLineColorB",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RendererSymbolOutLineColorG",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RendererSymbolOutLineColorOpacity",
                table: "LookUpMapViewDataSource",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RendererSymbolOutLineColorR",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RendererSymbolOutLineWidth",
                table: "LookUpMapViewDataSource",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RendererSymbolStyle",
                table: "LookUpMapViewDataSource",
                type: "nvarchar(50)",
                maxLength: 50,
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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUpMapViewDataSource_LookUpMapViewLayerType_LayerTypeId",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropIndex(
                name: "IX_LookUpMapViewDataSource_LayerTypeId",
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
                name: "PopupTemplateName",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolColorB",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolColorG",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolColorOpacity",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolColorR",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolOutLineColorB",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolOutLineColorG",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolOutLineColorOpacity",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolOutLineColorR",
                table: "LookUpMapViewDataSource");

            migrationBuilder.DropColumn(
                name: "RendererSymbolOutLineWidth",
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

            migrationBuilder.AlterColumn<string>(
                name: "PopupFieldVisibility",
                table: "LookUpMapViewPopUpFieldDetails",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(bool),
                oldMaxLength: 10);
        }
    }
}
