using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateSearchMode2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUpModelInfo",
                columns: table => new
                {
                    ModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelName = table.Column<string>(nullable: true),
                    ModelType = table.Column<string>(nullable: true),
                    ModelTitle = table.Column<string>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpModelInfo", x => x.ModelId);
                });

            migrationBuilder.CreateTable(
                name: "LookUpModelFieldInfo",
                columns: table => new
                {
                    ModeFieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelId = table.Column<int>(nullable: false),
                    FieldId = table.Column<int>(nullable: false),
                    FieldName = table.Column<string>(nullable: true),
                    FieldDataType = table.Column<string>(nullable: true),
                    FieldDisplayName = table.Column<string>(nullable: true),
                    IsUSeInSearch = table.Column<bool>(nullable: true),
                    SortingOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpModelFieldInfo", x => x.ModeFieldId);
                    table.ForeignKey(
                        name: "FK_LookUpModelFieldInfo_LookUpModelInfo_ModelId",
                        column: x => x.ModelId,
                        principalTable: "LookUpModelInfo",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LookUpModelFieldInfo_ModelId",
                table: "LookUpModelFieldInfo",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUpModelFieldInfo");

            migrationBuilder.DropTable(
                name: "LookUpModelInfo");
        }
    }
}
