using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePDBRegionsMaxScale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxScale",
                table: "LookUpZoneInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxScale",
                table: "LookUpSnDInfo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxScale",
                table: "LookUpCircleInfo",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxScale",
                table: "LookUpZoneInfo");

            migrationBuilder.DropColumn(
                name: "MaxScale",
                table: "LookUpSnDInfo");

            migrationBuilder.DropColumn(
                name: "MaxScale",
                table: "LookUpCircleInfo");
        }
    }
}
