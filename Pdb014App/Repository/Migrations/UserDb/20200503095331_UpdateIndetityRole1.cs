using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.UserDb
{
    public partial class UpdateIndetityRole1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileDetail_Users_Id",
                table: "UserProfileDetail");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_UserRegistrationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRegistrationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRegistrationId",
                table: "UserProfileDetail");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserProfileDetail",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileDetail_Users_Id",
                table: "UserProfileDetail",
                column: "Id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfileDetail_Users_Id",
                table: "UserProfileDetail");

            migrationBuilder.AddColumn<int>(
                name: "UserRegistrationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserProfileDetail",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddColumn<int>(
                name: "UserRegistrationId",
                table: "UserProfileDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_UserRegistrationId",
                table: "Users",
                column: "UserRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfileDetail_Users_Id",
                table: "UserProfileDetail",
                column: "Id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
