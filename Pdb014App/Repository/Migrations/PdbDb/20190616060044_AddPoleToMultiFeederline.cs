using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class AddPoleToMultiFeederline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblPoleToMultiFeederlineInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FeederLineId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PreviousPoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    NextPoleId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPoleToMultiFeederlineInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPoleToMultiFeederlineInfo_TblFeederLine_FeederLineId",
                        column: x => x.FeederLineId,
                        principalTable: "TblFeederLine",
                        principalColumn: "FeederLineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblPoleToMultiFeederlineInfo_TblPole_NextPoleId",
                        column: x => x.NextPoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPoleToMultiFeederlineInfo_TblPole_PoleId",
                        column: x => x.PoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblPoleToMultiFeederlineInfo_TblPole_PreviousPoleId",
                        column: x => x.PreviousPoleId,
                        principalTable: "TblPole",
                        principalColumn: "PoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPoleToMultiFeederlineInfo_FeederLineId",
                table: "TblPoleToMultiFeederlineInfo",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPoleToMultiFeederlineInfo_NextPoleId",
                table: "TblPoleToMultiFeederlineInfo",
                column: "NextPoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPoleToMultiFeederlineInfo_PoleId",
                table: "TblPoleToMultiFeederlineInfo",
                column: "PoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPoleToMultiFeederlineInfo_PreviousPoleId",
                table: "TblPoleToMultiFeederlineInfo",
                column: "PreviousPoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPoleToMultiFeederlineInfo");
        }
    }
}
