using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePDBRegionsZoomLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxScale",
                table: "LookUpZoneInfo",
                newName: "DefaultZoomLevel");

            migrationBuilder.RenameColumn(
                name: "MaxScale",
                table: "LookUpSnDInfo",
                newName: "DefaultZoomLevel");

            migrationBuilder.RenameColumn(
                name: "MaxScale",
                table: "LookUpCircleInfo",
                newName: "DefaultZoomLevel");

            migrationBuilder.AddColumn<int>(
                name: "DefaultZoomLevel",
                table: "TblSubstation",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultZoomLevel",
                table: "TblSubstation");

            migrationBuilder.RenameColumn(
                name: "DefaultZoomLevel",
                table: "LookUpZoneInfo",
                newName: "MaxScale");

            migrationBuilder.RenameColumn(
                name: "DefaultZoomLevel",
                table: "LookUpSnDInfo",
                newName: "MaxScale");

            migrationBuilder.RenameColumn(
                name: "DefaultZoomLevel",
                table: "LookUpCircleInfo",
                newName: "MaxScale");
        }
    }
}
