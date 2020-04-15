using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateMeteringPanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblMeteringPanel_LookupControlSwitch_ControlSwitchId",
                table: "TblMeteringPanel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_IdmtOverCurrentAndEarthFaultRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripCircuitSupervisionRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.DropIndex(
                name: "IX_TblMeteringPanel_ControlSwitchId",
                table: "TblMeteringPanel");

            migrationBuilder.DropIndex(
                name: "IX_TblMeteringPanel_IdmtOverCurrentAndEarthFaultRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.DropIndex(
                name: "IX_TblMeteringPanel_TripCircuitSupervisionRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.DropIndex(
                name: "IX_TblMeteringPanel_TripRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.DropColumn(
                name: "ControlSwitchId",
                table: "TblMeteringPanel");

            migrationBuilder.DropColumn(
                name: "IdmtOverCurrentAndEarthFaultRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.DropColumn(
                name: "TripCircuitSupervisionRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.DropColumn(
                name: "TripRelayId",
                table: "TblMeteringPanel");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_ControlSwitchIdForFeeder",
                table: "TblMeteringPanel",
                column: "ControlSwitchIdForFeeder");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_IdmtOverCurrentAndEarthFaultRelayIdForFeeder",
                table: "TblMeteringPanel",
                column: "IdmtOverCurrentAndEarthFaultRelayIdForFeeder");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_TripCircuitSupervisionRelayIdForFeeder",
                table: "TblMeteringPanel",
                column: "TripCircuitSupervisionRelayIdForFeeder");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_TripRelayIdForFeeder",
                table: "TblMeteringPanel",
                column: "TripRelayIdForFeeder");

            migrationBuilder.AddForeignKey(
                name: "FK_TblMeteringPanel_LookupControlSwitch_ControlSwitchIdForFeeder",
                table: "TblMeteringPanel",
                column: "ControlSwitchIdForFeeder",
                principalTable: "LookupControlSwitch",
                principalColumn: "ControlSwitchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_IdmtOverCurrentAndEarthFaultRelayIdForFeeder",
                table: "TblMeteringPanel",
                column: "IdmtOverCurrentAndEarthFaultRelayIdForFeeder",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripCircuitSupervisionRelayIdForFeeder",
                table: "TblMeteringPanel",
                column: "TripCircuitSupervisionRelayIdForFeeder",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripRelayIdForFeeder",
                table: "TblMeteringPanel",
                column: "TripRelayIdForFeeder",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblMeteringPanel_LookupControlSwitch_ControlSwitchIdForFeeder",
                table: "TblMeteringPanel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_IdmtOverCurrentAndEarthFaultRelayIdForFeeder",
                table: "TblMeteringPanel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripCircuitSupervisionRelayIdForFeeder",
                table: "TblMeteringPanel");

            migrationBuilder.DropForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripRelayIdForFeeder",
                table: "TblMeteringPanel");

            migrationBuilder.DropIndex(
                name: "IX_TblMeteringPanel_ControlSwitchIdForFeeder",
                table: "TblMeteringPanel");

            migrationBuilder.DropIndex(
                name: "IX_TblMeteringPanel_IdmtOverCurrentAndEarthFaultRelayIdForFeeder",
                table: "TblMeteringPanel");

            migrationBuilder.DropIndex(
                name: "IX_TblMeteringPanel_TripCircuitSupervisionRelayIdForFeeder",
                table: "TblMeteringPanel");

            migrationBuilder.DropIndex(
                name: "IX_TblMeteringPanel_TripRelayIdForFeeder",
                table: "TblMeteringPanel");

            migrationBuilder.AddColumn<int>(
                name: "ControlSwitchId",
                table: "TblMeteringPanel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdmtOverCurrentAndEarthFaultRelayId",
                table: "TblMeteringPanel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripCircuitSupervisionRelayId",
                table: "TblMeteringPanel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripRelayId",
                table: "TblMeteringPanel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_ControlSwitchId",
                table: "TblMeteringPanel",
                column: "ControlSwitchId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_IdmtOverCurrentAndEarthFaultRelayId",
                table: "TblMeteringPanel",
                column: "IdmtOverCurrentAndEarthFaultRelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_TripCircuitSupervisionRelayId",
                table: "TblMeteringPanel",
                column: "TripCircuitSupervisionRelayId");

            migrationBuilder.CreateIndex(
                name: "IX_TblMeteringPanel_TripRelayId",
                table: "TblMeteringPanel",
                column: "TripRelayId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblMeteringPanel_LookupControlSwitch_ControlSwitchId",
                table: "TblMeteringPanel",
                column: "ControlSwitchId",
                principalTable: "LookupControlSwitch",
                principalColumn: "ControlSwitchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_IdmtOverCurrentAndEarthFaultRelayId",
                table: "TblMeteringPanel",
                column: "IdmtOverCurrentAndEarthFaultRelayId",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripCircuitSupervisionRelayId",
                table: "TblMeteringPanel",
                column: "TripCircuitSupervisionRelayId",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblMeteringPanel_LookUpDifferentRelay_TripRelayId",
                table: "TblMeteringPanel",
                column: "TripRelayId",
                principalTable: "LookUpDifferentRelay",
                principalColumn: "DifferentRelayId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
