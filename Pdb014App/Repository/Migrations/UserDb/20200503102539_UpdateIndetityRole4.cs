using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.UserDb
{
    public partial class UpdateIndetityRole4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGrpWisePermissionDetail_UserRoleList_TblUserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrpWiseUsersDistribution_UserRoleList_TblUserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution");

            migrationBuilder.DropIndex(
                name: "IX_UserGrpWiseUsersDistribution_TblUserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution");

            migrationBuilder.DropIndex(
                name: "IX_UserGrpWisePermissionDetail_TblUserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail");

            migrationBuilder.DropColumn(
                name: "TblUserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution");

            migrationBuilder.DropColumn(
                name: "TblUserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrpWisePermissionDetail_UserRoleList_Id",
                table: "UserGrpWisePermissionDetail",
                column: "Id",
                principalTable: "UserRoleList",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrpWiseUsersDistribution_UserRoleList_Id",
                table: "UserGrpWiseUsersDistribution",
                column: "Id",
                principalTable: "UserRoleList",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGrpWisePermissionDetail_UserRoleList_Id",
                table: "UserGrpWisePermissionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrpWiseUsersDistribution_UserRoleList_Id",
                table: "UserGrpWiseUsersDistribution");

            migrationBuilder.DropIndex(
                name: "IX_UserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution");

            migrationBuilder.DropIndex(
                name: "IX_UserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail");

            migrationBuilder.AddColumn<string>(
                name: "TblUserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TblUserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGrpWiseUsersDistribution_TblUserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution",
                column: "TblUserGrpWiseUsersDistribution_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrpWisePermissionDetail_TblUserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail",
                column: "TblUserGrpWisePermissionDetail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrpWisePermissionDetail_UserRoleList_TblUserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail",
                column: "TblUserGrpWisePermissionDetail_Id",
                principalTable: "UserRoleList",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrpWiseUsersDistribution_UserRoleList_TblUserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution",
                column: "TblUserGrpWiseUsersDistribution_Id",
                principalTable: "UserRoleList",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
