using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateSnDInfoToAddCityDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DistrictGeoCode",
                table: "LookUpSnDInfo",
                type: "varchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsInCity",
                table: "LookUpSnDInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LookUpAdminBndDistrict",
                columns: table => new
                {
                    DistrictGeoCode = table.Column<string>(type: "varchar(4)", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpAdminBndDistrict", x => x.DistrictGeoCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUpSnDInfo_DistrictGeoCode",
                table: "LookUpSnDInfo",
                column: "DistrictGeoCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpSnDInfo_LookUpAdminBndDistrict_DistrictGeoCode",
                table: "LookUpSnDInfo",
                column: "DistrictGeoCode",
                principalTable: "LookUpAdminBndDistrict",
                principalColumn: "DistrictGeoCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUpSnDInfo_LookUpAdminBndDistrict_DistrictGeoCode",
                table: "LookUpSnDInfo");

            migrationBuilder.DropTable(
                name: "LookUpAdminBndDistrict");

            migrationBuilder.DropIndex(
                name: "IX_LookUpSnDInfo_DistrictGeoCode",
                table: "LookUpSnDInfo");

            migrationBuilder.DropColumn(
                name: "DistrictGeoCode",
                table: "LookUpSnDInfo");

            migrationBuilder.DropColumn(
                name: "IsInCity",
                table: "LookUpSnDInfo");
        }
    }
}
