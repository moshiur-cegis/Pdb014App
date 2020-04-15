using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpRouteInfo_RouteCode",
                table: "TblPole");

            migrationBuilder.AlterColumn<string>(
                name: "RouteCode",
                table: "TblPole",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpRouteInfo_RouteCode",
                table: "TblPole",
                column: "RouteCode",
                principalTable: "LookUpRouteInfo",
                principalColumn: "RouteCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPole_LookUpRouteInfo_RouteCode",
                table: "TblPole");

            migrationBuilder.AlterColumn<string>(
                name: "RouteCode",
                table: "TblPole",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPole_LookUpRouteInfo_RouteCode",
                table: "TblPole",
                column: "RouteCode",
                principalTable: "LookUpRouteInfo",
                principalColumn: "RouteCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
