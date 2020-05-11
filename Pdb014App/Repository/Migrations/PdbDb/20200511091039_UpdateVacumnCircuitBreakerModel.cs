using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateVacumnCircuitBreakerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblOutDoorTypeVacumnCircuitBreaker",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.DropColumn(
                name: "OutDoorTypeVacumnCircuitBreakerId",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.AddColumn<string>(
                name: "VacumnCircuitBreakerId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblOutDoorTypeVacumnCircuitBreaker",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                column: "VacumnCircuitBreakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblOutDoorTypeVacumnCircuitBreaker",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.DropColumn(
                name: "VacumnCircuitBreakerId",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.AddColumn<int>(
                name: "OutDoorTypeVacumnCircuitBreakerId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblOutDoorTypeVacumnCircuitBreaker",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                column: "OutDoorTypeVacumnCircuitBreakerId");
        }
    }
}
