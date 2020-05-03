using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.UserDb
{
    public partial class UpdateIndetityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserRoleList_UserGroupId",
                table: "UserRoleList");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserRoleList");

            migrationBuilder.DropColumn(
                name: "UserGroupName",
                table: "UserRoleList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "UserRoleList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "UserGroupName",
                table: "UserRoleList",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserRoleList_UserGroupId",
                table: "UserRoleList",
                column: "UserGroupId");
        }
    }
}
