using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.UserDb
{
    public partial class UpdateUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BpdbDivisionId",
                table: "UserProfileDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BpdbEmpDesignation",
                table: "UserProfileDetail",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BpdbEmployeeLevel",
                table: "UserProfileDetail",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CircleCode",
                table: "UserProfileDetail",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SnDCode",
                table: "UserProfileDetail",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubstationId",
                table: "UserProfileDetail",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZoneCode",
                table: "UserProfileDetail",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileDetail_BpdbDivisionId",
                table: "UserProfileDetail",
                column: "BpdbDivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileDetail_UserBpdbDivision_BpdbDivisionId",
                table: "UserProfileDetail",
                column: "BpdbDivisionId",
                principalTable: "UserBpdbDivision",
                principalColumn: "BpdbDivisionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileDetail_UserBpdbDivision_BpdbDivisionId",
                table: "UserProfileDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserProfileDetail_BpdbDivisionId",
                table: "UserProfileDetail");

            migrationBuilder.DropColumn(
                name: "BpdbDivisionId",
                table: "UserProfileDetail");

            migrationBuilder.DropColumn(
                name: "BpdbEmpDesignation",
                table: "UserProfileDetail");

            migrationBuilder.DropColumn(
                name: "BpdbEmployeeLevel",
                table: "UserProfileDetail");

            migrationBuilder.DropColumn(
                name: "CircleCode",
                table: "UserProfileDetail");

            migrationBuilder.DropColumn(
                name: "SnDCode",
                table: "UserProfileDetail");

            migrationBuilder.DropColumn(
                name: "SubstationId",
                table: "UserProfileDetail");

            migrationBuilder.DropColumn(
                name: "ZoneCode",
                table: "UserProfileDetail");
        }
    }
}
