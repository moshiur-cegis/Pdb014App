using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateSwitchGear3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpCircuitBreaker_CircuitBreakerId",
                table: "TblSwitchGear");

            migrationBuilder.AlterColumn<int>(
                name: "CircuitBreakerId",
                table: "TblSwitchGear",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpCircuitBreaker_CircuitBreakerId",
                table: "TblSwitchGear",
                column: "CircuitBreakerId",
                principalTable: "LookUpCircuitBreaker",
                principalColumn: "CircuitBreakerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitchGear_LookUpCircuitBreaker_CircuitBreakerId",
                table: "TblSwitchGear");

            migrationBuilder.AlterColumn<int>(
                name: "CircuitBreakerId",
                table: "TblSwitchGear",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitchGear_LookUpCircuitBreaker_CircuitBreakerId",
                table: "TblSwitchGear",
                column: "CircuitBreakerId",
                principalTable: "LookUpCircuitBreaker",
                principalColumn: "CircuitBreakerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
