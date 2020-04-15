using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateMeteringPanel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUpDifferentMeter_LookUpDifferentTypesOfMeter_RelayTypeId",
                table: "LookUpDifferentMeter");

            migrationBuilder.DropIndex(
                name: "IX_LookUpDifferentMeter_RelayTypeId",
                table: "LookUpDifferentMeter");

            migrationBuilder.DropColumn(
                name: "RelayTypeId",
                table: "LookUpDifferentMeter");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpDifferentMeter_MeterTypeId",
                table: "LookUpDifferentMeter",
                column: "MeterTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpDifferentMeter_LookUpDifferentTypesOfMeter_MeterTypeId",
                table: "LookUpDifferentMeter",
                column: "MeterTypeId",
                principalTable: "LookUpDifferentTypesOfMeter",
                principalColumn: "MeterTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUpDifferentMeter_LookUpDifferentTypesOfMeter_MeterTypeId",
                table: "LookUpDifferentMeter");

            migrationBuilder.DropIndex(
                name: "IX_LookUpDifferentMeter_MeterTypeId",
                table: "LookUpDifferentMeter");

            migrationBuilder.AddColumn<int>(
                name: "RelayTypeId",
                table: "LookUpDifferentMeter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookUpDifferentMeter_RelayTypeId",
                table: "LookUpDifferentMeter",
                column: "RelayTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpDifferentMeter_LookUpDifferentTypesOfMeter_RelayTypeId",
                table: "LookUpDifferentMeter",
                column: "RelayTypeId",
                principalTable: "LookUpDifferentTypesOfMeter",
                principalColumn: "MeterTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
