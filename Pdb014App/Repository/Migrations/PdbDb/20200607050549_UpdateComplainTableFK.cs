using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateComplainTableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblComplains_TblUserProfileDetail_ResolvingOfficerId",
                table: "TblComplains");

            migrationBuilder.DropForeignKey(
                name: "FK_TblComplains_TblUserProfileDetail_ResponsibleOfficerId",
                table: "TblComplains");

            migrationBuilder.DropTable(
                name: "TblUserProfileDetail");

            migrationBuilder.DropTable(
                name: "LookUpUserBpdbEmployee");

            migrationBuilder.DropTable(
                name: "TblUserRegistrationDetail");

            migrationBuilder.DropTable(
                name: "LookUpUserSecurityQuestion");

            migrationBuilder.DropTable(
                name: "LookUpUserBpdbDivision");

            migrationBuilder.DropTable(
                name: "LookUpUserActivationStatus");

            migrationBuilder.DropIndex(
                name: "IX_TblComplains_ResolvingOfficerId",
                table: "TblComplains");

            migrationBuilder.DropIndex(
                name: "IX_TblComplains_ResponsibleOfficerId",
                table: "TblComplains");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_LookUpAdminRegionRel_SnDCode_UnionGeoCode",
                table: "LookUpAdminRegionRel");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpAdminRegionRel_SnDCode",
                table: "LookUpAdminRegionRel",
                column: "SnDCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LookUpAdminRegionRel_SnDCode",
                table: "LookUpAdminRegionRel");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_LookUpAdminRegionRel_SnDCode_UnionGeoCode",
                table: "LookUpAdminRegionRel",
                columns: new[] { "SnDCode", "UnionGeoCode" });

            migrationBuilder.CreateTable(
                name: "LookUpUserActivationStatus",
                columns: table => new
                {
                    UserActivationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserActivationStatus = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpUserActivationStatus", x => x.UserActivationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpUserBpdbDivision",
                columns: table => new
                {
                    BpdbDivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BpdbDivisionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpUserBpdbDivision", x => x.BpdbDivisionId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpUserSecurityQuestion",
                columns: table => new
                {
                    UserSecurityQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSecurityQuestion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpUserSecurityQuestion", x => x.UserSecurityQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "TblUserRegistrationDetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserActivationStatusId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNames = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VerificationCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserRegistrationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUserRegistrationDetail_LookUpUserActivationStatus_UserActivationStatusId",
                        column: x => x.UserActivationStatusId,
                        principalTable: "LookUpUserActivationStatus",
                        principalColumn: "UserActivationStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpUserBpdbEmployee",
                columns: table => new
                {
                    BpdbEmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BpdbDivisionId = table.Column<int>(type: "int", nullable: false),
                    BpdbEmpDesignation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BpdbEmployeeLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CircleCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SubstationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ZoneCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpUserBpdbEmployee", x => x.BpdbEmployeeId);
                    table.ForeignKey(
                        name: "FK_LookUpUserBpdbEmployee_LookUpUserBpdbDivision_BpdbDivisionId",
                        column: x => x.BpdbDivisionId,
                        principalTable: "LookUpUserBpdbDivision",
                        principalColumn: "BpdbDivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUserProfileDetail",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BpdbEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsBpdbEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsProfileSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    SecurityQuestionAnswer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SignatureFileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserAlternateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAlternateMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserDesignation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserFullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserNID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserProfession = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserSecurityQuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserProfileDetail", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_TblUserProfileDetail_LookUpUserBpdbEmployee_BpdbEmployeeId",
                        column: x => x.BpdbEmployeeId,
                        principalTable: "LookUpUserBpdbEmployee",
                        principalColumn: "BpdbEmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblUserProfileDetail_TblUserRegistrationDetail_Id",
                        column: x => x.Id,
                        principalTable: "TblUserRegistrationDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUserProfileDetail_LookUpUserSecurityQuestion_UserSecurityQuestionId",
                        column: x => x.UserSecurityQuestionId,
                        principalTable: "LookUpUserSecurityQuestion",
                        principalColumn: "UserSecurityQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblComplains_ResolvingOfficerId",
                table: "TblComplains",
                column: "ResolvingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplains_ResponsibleOfficerId",
                table: "TblComplains",
                column: "ResponsibleOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpUserBpdbEmployee_BpdbDivisionId",
                table: "LookUpUserBpdbEmployee",
                column: "BpdbDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserProfileDetail_BpdbEmployeeId",
                table: "TblUserProfileDetail",
                column: "BpdbEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserProfileDetail_Id",
                table: "TblUserProfileDetail",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserProfileDetail_UserSecurityQuestionId",
                table: "TblUserProfileDetail",
                column: "UserSecurityQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserRegistrationDetail_UserActivationStatusId",
                table: "TblUserRegistrationDetail",
                column: "UserActivationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblComplains_TblUserProfileDetail_ResolvingOfficerId",
                table: "TblComplains",
                column: "ResolvingOfficerId",
                principalTable: "TblUserProfileDetail",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblComplains_TblUserProfileDetail_ResponsibleOfficerId",
                table: "TblComplains",
                column: "ResponsibleOfficerId",
                principalTable: "TblUserProfileDetail",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
