using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class AdminBndAndComplaint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DivisionGeoCode",
                table: "LookUpAdminBndDistrict",
                type: "varchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComplaintStatus",
                columns: table => new
                {
                    ComplaintStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplaintStatus = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintStatus", x => x.ComplaintStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintTypes",
                columns: table => new
                {
                    ComplaintTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplaintType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintTypes", x => x.ComplaintTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpAdminBndDivision",
                columns: table => new
                {
                    DivisionGeoCode = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpAdminBndDivision", x => x.DivisionGeoCode);
                });

            migrationBuilder.CreateTable(
                name: "LookUpAdminBndUpazila",
                columns: table => new
                {
                    UpazilaGeoCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    UpazilaName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DistrictGeoCode = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpAdminBndUpazila", x => x.UpazilaGeoCode);
                    table.ForeignKey(
                        name: "FK_LookUpAdminBndUpazila_LookUpAdminBndDistrict_DistrictGeoCode",
                        column: x => x.DistrictGeoCode,
                        principalTable: "LookUpAdminBndDistrict",
                        principalColumn: "DistrictGeoCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookUpUserActivationStatus",
                columns: table => new
                {
                    UserActivationStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserSecurityQuestion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpUserSecurityQuestion", x => x.UserSecurityQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpAdminBndUnion",
                columns: table => new
                {
                    UnionGeoCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    UnionName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DistrictGeoCode = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    UpazilaGeoCode = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpAdminBndUnion", x => x.UnionGeoCode);
                    table.ForeignKey(
                        name: "FK_LookUpAdminBndUnion_LookUpAdminBndDistrict_DistrictGeoCode",
                        column: x => x.DistrictGeoCode,
                        principalTable: "LookUpAdminBndDistrict",
                        principalColumn: "DistrictGeoCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookUpAdminBndUnion_LookUpAdminBndUpazila_UpazilaGeoCode",
                        column: x => x.UpazilaGeoCode,
                        principalTable: "LookUpAdminBndUpazila",
                        principalColumn: "UpazilaGeoCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblUserRegistrationDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserDateOfBirth = table.Column<DateTime>(nullable: true),
                    UserNID = table.Column<string>(maxLength: 100, nullable: true),
                    IsBpdbEmployee = table.Column<bool>(nullable: false),
                    BpdbEmployeeId = table.Column<int>(type: "int", nullable: true),
                    UserProfession = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserDesignation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserAlternateEmail = table.Column<string>(nullable: true),
                    UserAlternateMobile = table.Column<string>(nullable: true),
                    UserSecurityQuestionId = table.Column<int>(type: "int", nullable: true),
                    SecurityQuestionAnswer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsProfileSubmitted = table.Column<bool>(nullable: false),
                    SignatureFileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ComplaintInfo",
                columns: table => new
                {
                    ComplaintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplaintNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ComplaintTypeId = table.Column<int>(type: "int", nullable: false),
                    ComplaintStatusId = table.Column<int>(type: "int", nullable: false),
                    ComplainerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ComplainerAddress = table.Column<string>(name: "Complainer Address", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ComplainerDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    ComplaintDate = table.Column<DateTime>(type: "date", nullable: true),
                    ComplaintPriority = table.Column<int>(type: "int", nullable: false),
                    ResponsibleOfficerId = table.Column<int>(type: "int", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true),
                    ResolvingOfficerId = table.Column<int>(type: "int", nullable: false),
                    UnionGeoCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintInfo", x => x.ComplaintId);
                    table.ForeignKey(
                        name: "FK_ComplaintInfo_ComplaintStatus_ComplaintStatusId",
                        column: x => x.ComplaintStatusId,
                        principalTable: "ComplaintStatus",
                        principalColumn: "ComplaintStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplaintInfo_ComplaintTypes_ComplaintTypeId",
                        column: x => x.ComplaintTypeId,
                        principalTable: "ComplaintTypes",
                        principalColumn: "ComplaintTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplaintInfo_TblUserProfileDetail_ResolvingOfficerId",
                        column: x => x.ResolvingOfficerId,
                        principalTable: "TblUserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ComplaintInfo_TblUserProfileDetail_ResponsibleOfficerId",
                        column: x => x.ResponsibleOfficerId,
                        principalTable: "TblUserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplaintInfo_LookUpSnDInfo_SnDCode",
                        column: x => x.SnDCode,
                        principalTable: "LookUpSnDInfo",
                        principalColumn: "SnDCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplaintInfo_LookUpAdminBndUnion_UnionGeoCode",
                        column: x => x.UnionGeoCode,
                        principalTable: "LookUpAdminBndUnion",
                        principalColumn: "UnionGeoCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUpAdminBndDistrict_DivisionGeoCode",
                table: "LookUpAdminBndDistrict",
                column: "DivisionGeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintInfo_ComplaintStatusId",
                table: "ComplaintInfo",
                column: "ComplaintStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintInfo_ComplaintTypeId",
                table: "ComplaintInfo",
                column: "ComplaintTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintInfo_ResolvingOfficerId",
                table: "ComplaintInfo",
                column: "ResolvingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintInfo_ResponsibleOfficerId",
                table: "ComplaintInfo",
                column: "ResponsibleOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintInfo_SnDCode",
                table: "ComplaintInfo",
                column: "SnDCode");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintInfo_UnionGeoCode",
                table: "ComplaintInfo",
                column: "UnionGeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpAdminBndUnion_DistrictGeoCode",
                table: "LookUpAdminBndUnion",
                column: "DistrictGeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpAdminBndUnion_UpazilaGeoCode",
                table: "LookUpAdminBndUnion",
                column: "UpazilaGeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpAdminBndUpazila_DistrictGeoCode",
                table: "LookUpAdminBndUpazila",
                column: "DistrictGeoCode");

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
                name: "FK_LookUpAdminBndDistrict_LookUpAdminBndDivision_DivisionGeoCode",
                table: "LookUpAdminBndDistrict",
                column: "DivisionGeoCode",
                principalTable: "LookUpAdminBndDivision",
                principalColumn: "DivisionGeoCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUpAdminBndDistrict_LookUpAdminBndDivision_DivisionGeoCode",
                table: "LookUpAdminBndDistrict");

            migrationBuilder.DropTable(
                name: "ComplaintInfo");

            migrationBuilder.DropTable(
                name: "LookUpAdminBndDivision");

            migrationBuilder.DropTable(
                name: "ComplaintStatus");

            migrationBuilder.DropTable(
                name: "ComplaintTypes");

            migrationBuilder.DropTable(
                name: "TblUserProfileDetail");

            migrationBuilder.DropTable(
                name: "LookUpAdminBndUnion");

            migrationBuilder.DropTable(
                name: "LookUpUserBpdbEmployee");

            migrationBuilder.DropTable(
                name: "TblUserRegistrationDetail");

            migrationBuilder.DropTable(
                name: "LookUpUserSecurityQuestion");

            migrationBuilder.DropTable(
                name: "LookUpAdminBndUpazila");

            migrationBuilder.DropTable(
                name: "LookUpUserBpdbDivision");

            migrationBuilder.DropTable(
                name: "LookUpUserActivationStatus");

            migrationBuilder.DropIndex(
                name: "IX_LookUpAdminBndDistrict_DivisionGeoCode",
                table: "LookUpAdminBndDistrict");

            migrationBuilder.DropColumn(
                name: "DivisionGeoCode",
                table: "LookUpAdminBndDistrict");
        }
    }
}
