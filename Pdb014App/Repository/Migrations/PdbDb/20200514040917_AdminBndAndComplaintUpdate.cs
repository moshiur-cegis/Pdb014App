using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class AdminBndAndComplaintUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintInfo_TblUserProfileDetail_ResolvingOfficerId",
                table: "ComplaintInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintInfo_TblUserProfileDetail_ResponsibleOfficerId",
                table: "ComplaintInfo");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleOfficerId",
                table: "ComplaintInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ResolvingOfficerId",
                table: "ComplaintInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "LookUpAdminRegionRel",
                columns: table => new
                {
                    UnionGeoCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    SnDCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpAdminRegionRel", x => new { x.UnionGeoCode, x.SnDCode });
                    table.UniqueConstraint("AK_LookUpAdminRegionRel_SnDCode_UnionGeoCode", x => new { x.SnDCode, x.UnionGeoCode });
                    table.ForeignKey(
                        name: "FK_LookUpAdminRegionRel_LookUpSnDInfo_SnDCode",
                        column: x => x.SnDCode,
                        principalTable: "LookUpSnDInfo",
                        principalColumn: "SnDCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LookUpAdminRegionRel_LookUpAdminBndUnion_UnionGeoCode",
                        column: x => x.UnionGeoCode,
                        principalTable: "LookUpAdminBndUnion",
                        principalColumn: "UnionGeoCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintInfo_TblUserProfileDetail_ResolvingOfficerId",
                table: "ComplaintInfo",
                column: "ResolvingOfficerId",
                principalTable: "TblUserProfileDetail",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintInfo_TblUserProfileDetail_ResponsibleOfficerId",
                table: "ComplaintInfo",
                column: "ResponsibleOfficerId",
                principalTable: "TblUserProfileDetail",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintInfo_TblUserProfileDetail_ResolvingOfficerId",
                table: "ComplaintInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplaintInfo_TblUserProfileDetail_ResponsibleOfficerId",
                table: "ComplaintInfo");

            migrationBuilder.DropTable(
                name: "LookUpAdminRegionRel");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleOfficerId",
                table: "ComplaintInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResolvingOfficerId",
                table: "ComplaintInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintInfo_TblUserProfileDetail_ResolvingOfficerId",
                table: "ComplaintInfo",
                column: "ResolvingOfficerId",
                principalTable: "TblUserProfileDetail",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplaintInfo_TblUserProfileDetail_ResponsibleOfficerId",
                table: "ComplaintInfo",
                column: "ResponsibleOfficerId",
                principalTable: "TblUserProfileDetail",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
