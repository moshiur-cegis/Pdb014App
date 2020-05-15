using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class ComplainUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplainInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComplainTypes",
                table: "ComplainTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComplainStatus",
                table: "ComplainStatus");

            migrationBuilder.RenameTable(
                name: "ComplainTypes",
                newName: "LookUpComplainTypes");

            migrationBuilder.RenameTable(
                name: "ComplainStatus",
                newName: "LookUpComplainStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookUpComplainTypes",
                table: "LookUpComplainTypes",
                column: "ComplainTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LookUpComplainStatus",
                table: "LookUpComplainStatus",
                column: "ComplainStatusId");

            migrationBuilder.CreateTable(
                name: "TblComplains",
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
                    table.PrimaryKey("PK_TblComplains", x => x.ComplainId);
                    table.ForeignKey(
                        name: "FK_TblComplains_LookUpComplainStatus_ComplainStatusId",
                        column: x => x.ComplainStatusId,
                        principalTable: "LookUpComplainStatus",
                        principalColumn: "ComplainStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblComplains_LookUpComplainTypes_ComplainTypeId",
                        column: x => x.ComplainTypeId,
                        principalTable: "LookUpComplainTypes",
                        principalColumn: "ComplainTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblComplains_TblUserProfileDetail_ResolvingOfficerId",
                        column: x => x.ResolvingOfficerId,
                        principalTable: "TblUserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TblComplains_TblUserProfileDetail_ResponsibleOfficerId",
                        column: x => x.ResponsibleOfficerId,
                        principalTable: "TblUserProfileDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblComplains_LookUpSnDInfo_SnDCode",
                        column: x => x.SnDCode,
                        principalTable: "LookUpSnDInfo",
                        principalColumn: "SnDCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblComplains_LookUpAdminBndUnion_UnionGeoCode",
                        column: x => x.UnionGeoCode,
                        principalTable: "LookUpAdminBndUnion",
                        principalColumn: "UnionGeoCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblComplains_ComplainStatusId",
                table: "TblComplains",
                column: "ComplainStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplains_ComplainTypeId",
                table: "TblComplains",
                column: "ComplainTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplains_ResolvingOfficerId",
                table: "TblComplains",
                column: "ResolvingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplains_ResponsibleOfficerId",
                table: "TblComplains",
                column: "ResponsibleOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplains_SnDCode",
                table: "TblComplains",
                column: "SnDCode");

            migrationBuilder.CreateIndex(
                name: "IX_TblComplains_UnionGeoCode",
                table: "TblComplains",
                column: "UnionGeoCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblComplains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookUpComplainTypes",
                table: "LookUpComplainTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LookUpComplainStatus",
                table: "LookUpComplainStatus");

            migrationBuilder.RenameTable(
                name: "LookUpComplainTypes",
                newName: "ComplainTypes");

            migrationBuilder.RenameTable(
                name: "LookUpComplainStatus",
                newName: "ComplainStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComplainTypes",
                table: "ComplainTypes",
                column: "ComplainTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComplainStatus",
                table: "ComplainStatus",
                column: "ComplainStatusId");

            migrationBuilder.CreateTable(
                name: "ComplainInfo",
                columns: table => new
                {
                    ComplainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplainDate = table.Column<DateTime>(type: "date", nullable: true),
                    ComplainNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ComplainPriority = table.Column<int>(type: "int", nullable: true),
                    ComplainStatusId = table.Column<int>(type: "int", nullable: false),
                    ComplainTypeId = table.Column<int>(type: "int", nullable: false),
                    ComplainerAddress = table.Column<string>(name: "Complainer Address", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ComplainerDetails = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ComplainerName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
    }
}
