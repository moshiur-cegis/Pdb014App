using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateDatabase_10102019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CenterLatitude",
                table: "LookUpZoneInfo",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CenterLongitude",
                table: "LookUpZoneInfo",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxScale",
                table: "LookUpZoneInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinScale",
                table: "LookUpZoneInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CenterLatitude",
                table: "LookUpSnDInfo",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CenterLongitude",
                table: "LookUpSnDInfo",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxScale",
                table: "LookUpSnDInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinScale",
                table: "LookUpSnDInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CenterLatitude",
                table: "LookUpRouteInfo",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CenterLongitude",
                table: "LookUpRouteInfo",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxScale",
                table: "LookUpRouteInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinScale",
                table: "LookUpRouteInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CenterLatitude",
                table: "LookUpCircleInfo",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CenterLongitude",
                table: "LookUpCircleInfo",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxScale",
                table: "LookUpCircleInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinScale",
                table: "LookUpCircleInfo",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenterLatitude",
                table: "LookUpZoneInfo");

            migrationBuilder.DropColumn(
                name: "CenterLongitude",
                table: "LookUpZoneInfo");

            migrationBuilder.DropColumn(
                name: "MaxScale",
                table: "LookUpZoneInfo");

            migrationBuilder.DropColumn(
                name: "MinScale",
                table: "LookUpZoneInfo");

            migrationBuilder.DropColumn(
                name: "CenterLatitude",
                table: "LookUpSnDInfo");

            migrationBuilder.DropColumn(
                name: "CenterLongitude",
                table: "LookUpSnDInfo");

            migrationBuilder.DropColumn(
                name: "MaxScale",
                table: "LookUpSnDInfo");

            migrationBuilder.DropColumn(
                name: "MinScale",
                table: "LookUpSnDInfo");

            migrationBuilder.DropColumn(
                name: "CenterLatitude",
                table: "LookUpRouteInfo");

            migrationBuilder.DropColumn(
                name: "CenterLongitude",
                table: "LookUpRouteInfo");

            migrationBuilder.DropColumn(
                name: "MaxScale",
                table: "LookUpRouteInfo");

            migrationBuilder.DropColumn(
                name: "MinScale",
                table: "LookUpRouteInfo");

            migrationBuilder.DropColumn(
                name: "CenterLatitude",
                table: "LookUpCircleInfo");

            migrationBuilder.DropColumn(
                name: "CenterLongitude",
                table: "LookUpCircleInfo");

            migrationBuilder.DropColumn(
                name: "MaxScale",
                table: "LookUpCircleInfo");

            migrationBuilder.DropColumn(
                name: "MinScale",
                table: "LookUpCircleInfo");
        }
    }
}
