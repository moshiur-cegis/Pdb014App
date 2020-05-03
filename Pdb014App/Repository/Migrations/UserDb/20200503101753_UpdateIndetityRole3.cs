using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.UserDb
{
    public partial class UpdateIndetityRole3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserGrpWiseUsersDistribution");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserGrpWisePermissionDetail");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserGrpWiseUsersDistribution",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TblUserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserGrpWisePermissionDetail",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserGrpWiseUsersDistribution",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "UserGrpWiseUsersDistribution",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserGrpWisePermissionDetail",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "UserGrpWisePermissionDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrpWiseUsersDistribution_UserRoleList_Id",
                table: "UserGrpWiseUsersDistribution",
                column: "Id",
                principalTable: "UserRoleList",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
