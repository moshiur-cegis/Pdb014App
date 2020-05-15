using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class ReportAndComplainUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintInfo");

            migrationBuilder.DropTable(
                name: "ComplaintStatus");

            migrationBuilder.DropTable(
                name: "ComplaintTypes");

            migrationBuilder.CreateTable(
                name: "ComplainStatus",
                columns: table => new
                {
                    ComplainStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplainStatus = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainStatus", x => x.ComplainStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ComplainTypes",
                columns: table => new
                {
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplainType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainTypes", x => x.ComplainTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ComplainInfo",
                columns: table => new
                {
                    ComplainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplainNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false),
                    ComplainStatusId = table.Column<int>(type: "int", nullable: false),
                    ComplainerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ComplainerAddress = table.Column<string>(name: "Complainer Address", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ComplainerDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ComplainDate = table.Column<DateTime>(type: "date", nullable: true),
                    ComplainPriority = table.Column<int>(type: "int", nullable: true),
                    ResponsibleOfficerId = table.Column<int>(type: "int", nullable: true),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true),
                    ResolvingOfficerId = table.Column<int>(type: "int", nullable: true),
                    UnionGeoCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainInfo", x => x.ComplainId);
                    table.ForeignKey(
                        name: "FK_ComplainInfo_ComplainStatus_ComplainStatusId",
                        column: x => x.ComplainStatusId,
                        principalTable: "ComplainStatus",
                        principalColumn: "ComplainStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplainInfo_ComplainTypes_ComplainTypeId",
                        column: x => x.ComplainTypeId,
                        principalTable: "ComplainTypes",
                        principalColumn: "ComplainTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplainInfo_TblUserProfileDetail_ResolvingOfficerId",
                        column: x => x.ResolvingOfficerId,
                        principalTable: "TblUserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ComplainInfo_TblUserProfileDetail_ResponsibleOfficerId",
                        column: x => x.ResponsibleOfficerId,
                        principalTable: "TblUserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplainInfo_LookUpSnDInfo_SnDCode",
                        column: x => x.SnDCode,
                        principalTable: "LookUpSnDInfo",
                        principalColumn: "SnDCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplainInfo_LookUpAdminBndUnion_UnionGeoCode",
                        column: x => x.UnionGeoCode,
                        principalTable: "LookUpAdminBndUnion",
                        principalColumn: "UnionGeoCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplainInfo_ComplainStatusId",
                table: "ComplainInfo",
                column: "ComplainStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainInfo_ComplainTypeId",
                table: "ComplainInfo",
                column: "ComplainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainInfo_ResolvingOfficerId",
                table: "ComplainInfo",
                column: "ResolvingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainInfo_ResponsibleOfficerId",
                table: "ComplainInfo",
                column: "ResponsibleOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainInfo_SnDCode",
                table: "ComplainInfo",
                column: "SnDCode");

            migrationBuilder.CreateIndex(
                name: "IX_ComplainInfo_UnionGeoCode",
                table: "ComplainInfo",
                column: "UnionGeoCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplainInfo");

            migrationBuilder.DropTable(
                name: "ComplainStatus");

            migrationBuilder.DropTable(
                name: "ComplainTypes");

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
                name: "ComplaintInfo",
                columns: table => new
                {
                    ComplaintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplainerAddress = table.Column<string>(name: "Complainer Address", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ComplainerDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ComplainerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ComplaintDate = table.Column<DateTime>(type: "date", nullable: true),
                    ComplaintNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ComplaintPriority = table.Column<int>(type: "int", nullable: true),
                    ComplaintStatusId = table.Column<int>(type: "int", nullable: false),
                    ComplaintTypeId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true),
                    ResolvingOfficerId = table.Column<int>(type: "int", nullable: true),
                    ResponsibleOfficerId = table.Column<int>(type: "int", nullable: true),
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UnionGeoCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplaintInfo_TblUserProfileDetail_ResponsibleOfficerId",
                        column: x => x.ResponsibleOfficerId,
                        principalTable: "TblUserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
        }
    }
}
