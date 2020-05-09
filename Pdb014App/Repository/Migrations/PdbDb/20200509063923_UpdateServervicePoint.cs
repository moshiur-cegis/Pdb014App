using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateServervicePoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SpLatitude",
                table: "TblServicePoint",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SpLongitude",
                table: "TblServicePoint",
                type: "decimal(10, 8)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AutoCompleteInfo",
                columns: table => new
                {
                    SlNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Term = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoCompleteInfo", x => x.SlNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoCompleteInfo");

            migrationBuilder.DropColumn(
                name: "SpLatitude",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "SpLongitude",
                table: "TblServicePoint");
        }
    }
}
