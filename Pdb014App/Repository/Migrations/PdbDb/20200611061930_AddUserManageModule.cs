using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class AddUserManageModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserActivationStatus",
                columns: table => new
                {
                    UserActivationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserActivationStatus = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivationStatus", x => x.UserActivationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "UserBpdbDivision",
                columns: table => new
                {
                    BpdbDivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BpdbDivisionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBpdbDivision", x => x.BpdbDivisionId);
                });

            migrationBuilder.CreateTable(
                name: "UserContentType",
                columns: table => new
                {
                    ContentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContentType", x => x.ContentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissionType",
                columns: table => new
                {
                    PermissionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionTypeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissionType", x => x.PermissionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleList",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleList", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserSecurityQuestion",
                columns: table => new
                {
                    UserSecurityQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSecurityQuestion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecurityQuestion", x => x.UserSecurityQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserNames = table.Column<string>(maxLength: 100, nullable: true),
                    UserActivationStatusId = table.Column<int>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    VerificationCode = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserActivationStatus_UserActivationStatusId",
                        column: x => x.UserActivationStatusId,
                        principalTable: "UserActivationStatus",
                        principalColumn: "UserActivationStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBpdbEmployee",
                columns: table => new
                {
                    BpdbEmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BpdbEmployeeLevel = table.Column<string>(maxLength: 100, nullable: true),
                    BpdbDivisionId = table.Column<int>(type: "int", nullable: false),
                    BpdbEmpDesignation = table.Column<string>(maxLength: 100, nullable: true),
                    ZoneCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CircleCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SubstationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBpdbEmployee", x => x.BpdbEmployeeId);
                    table.ForeignKey(
                        name: "FK_UserBpdbEmployee_UserBpdbDivision_BpdbDivisionId",
                        column: x => x.BpdbDivisionId,
                        principalTable: "UserBpdbDivision",
                        principalColumn: "BpdbDivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPermittedContent",
                columns: table => new
                {
                    UsersPermittedContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTypeId = table.Column<int>(type: "int", nullable: true),
                    ContentName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContentTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ContentDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPermittedContent", x => x.UsersPermittedContentId);
                    table.ForeignKey(
                        name: "FK_UsersPermittedContent_UserContentType_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "UserContentType",
                        principalColumn: "ContentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleClaim_UserRoleList_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoleList",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_UserRoleList_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoleList",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileDetail",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserDateOfBirth = table.Column<DateTime>(nullable: true),
                    UserNID = table.Column<string>(maxLength: 100, nullable: true),
                    UserProfession = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserDesignation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserAlternateEmail = table.Column<string>(nullable: true),
                    UserAlternateMobile = table.Column<string>(nullable: true),
                    UserSecurityQuestionId = table.Column<int>(type: "int", nullable: true),
                    SecurityQuestionAnswer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsProfileSubmitted = table.Column<bool>(nullable: false),
                    SignatureFileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsBpdbEmployee = table.Column<bool>(nullable: false),
                    BpdbEmployeeId = table.Column<int>(type: "int", nullable: true),
                    BpdbEmployeeLevel = table.Column<string>(maxLength: 100, nullable: true),
                    BpdbDivisionId = table.Column<int>(type: "int", nullable: true),
                    BpdbEmpDesignation = table.Column<string>(maxLength: 100, nullable: true),
                    ZoneCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CircleCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SubstationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileDetail", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserProfileDetail_UserBpdbDivision_BpdbDivisionId",
                        column: x => x.BpdbDivisionId,
                        principalTable: "UserBpdbDivision",
                        principalColumn: "BpdbDivisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfileDetail_UserBpdbEmployee_BpdbEmployeeId",
                        column: x => x.BpdbEmployeeId,
                        principalTable: "UserBpdbEmployee",
                        principalColumn: "BpdbEmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfileDetail_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileDetail_LookUpSnDInfo_SnDCode",
                        column: x => x.SnDCode,
                        principalTable: "LookUpSnDInfo",
                        principalColumn: "SnDCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfileDetail_UserSecurityQuestion_UserSecurityQuestionId",
                        column: x => x.UserSecurityQuestionId,
                        principalTable: "UserSecurityQuestion",
                        principalColumn: "UserSecurityQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGrpWisePermissionDetail",
                columns: table => new
                {
                    PermissionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersPermittedContentId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrpWisePermissionDetail", x => x.PermissionTypeId);
                    table.ForeignKey(
                        name: "FK_UserGrpWisePermissionDetail_UserRoleList_Id",
                        column: x => x.Id,
                        principalTable: "UserRoleList",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGrpWisePermissionDetail_UsersPermittedContent_UsersPermittedContentId",
                        column: x => x.UsersPermittedContentId,
                        principalTable: "UsersPermittedContent",
                        principalColumn: "UsersPermittedContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGrpWiseUsersDistribution",
                columns: table => new
                {
                    UserDistributionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrpWiseUsersDistribution", x => x.UserDistributionId);
                    table.ForeignKey(
                        name: "FK_UserGrpWiseUsersDistribution_UserRoleList_Id",
                        column: x => x.Id,
                        principalTable: "UserRoleList",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGrpWiseUsersDistribution_UserProfileDetail_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogHistory",
                columns: table => new
                {
                    UserLogHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServerOrIPAddress = table.Column<string>(maxLength: 100, nullable: true),
                    LoginDateTime = table.Column<DateTime>(nullable: false),
                    LogOutDateTime = table.Column<DateTime>(nullable: false),
                    LoginNotes = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogHistory", x => x.UserLogHistoryId);
                    table.ForeignKey(
                        name: "FK_UserLogHistory_UserProfileDetail_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBpdbEmployee_BpdbDivisionId",
                table: "UserBpdbEmployee",
                column: "BpdbDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrpWisePermissionDetail_Id",
                table: "UserGrpWisePermissionDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrpWisePermissionDetail_UsersPermittedContentId",
                table: "UserGrpWisePermissionDetail",
                column: "UsersPermittedContentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrpWiseUsersDistribution_Id",
                table: "UserGrpWiseUsersDistribution",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrpWiseUsersDistribution_UserId",
                table: "UserGrpWiseUsersDistribution",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogHistory_UserId",
                table: "UserLogHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileDetail_BpdbDivisionId",
                table: "UserProfileDetail",
                column: "BpdbDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileDetail_BpdbEmployeeId",
                table: "UserProfileDetail",
                column: "BpdbEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileDetail_Id",
                table: "UserProfileDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileDetail_SnDCode",
                table: "UserProfileDetail",
                column: "SnDCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileDetail_UserSecurityQuestionId",
                table: "UserProfileDetail",
                column: "UserSecurityQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleClaim_RoleId",
                table: "UserRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "UserRoleList",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserActivationStatusId",
                table: "Users",
                column: "UserActivationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPermittedContent_ContentTypeId",
                table: "UsersPermittedContent",
                column: "ContentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserGrpWisePermissionDetail");

            migrationBuilder.DropTable(
                name: "UserGrpWiseUsersDistribution");

            migrationBuilder.DropTable(
                name: "UserLogHistory");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserPermissionType");

            migrationBuilder.DropTable(
                name: "UserRoleClaim");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "UsersPermittedContent");

            migrationBuilder.DropTable(
                name: "UserProfileDetail");

            migrationBuilder.DropTable(
                name: "UserRoleList");

            migrationBuilder.DropTable(
                name: "UserContentType");

            migrationBuilder.DropTable(
                name: "UserBpdbEmployee");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSecurityQuestion");

            migrationBuilder.DropTable(
                name: "UserBpdbDivision");

            migrationBuilder.DropTable(
                name: "UserActivationStatus");
        }
    }
}
