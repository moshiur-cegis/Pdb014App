using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class CreateTblSearchFieldList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblSearchFieldList",
                columns: table => new
                {
                    SearchFieldId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TableGroupId = table.Column<int>(nullable: false),
                    TableGroupName = table.Column<string>(nullable: true),
                    PropertyName = table.Column<string>(nullable: true),
                    PropertyNameDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSearchFieldList", x => x.SearchFieldId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblSearchFieldList");
        }
    }
}
