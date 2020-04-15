using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateSubstationAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUpAuxiliaryTransformer_TblSubstation_LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_LookUpBatteryCharger_TblSubstation_LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger");

            migrationBuilder.DropForeignKey(
                name: "FK_LookUpNiCdBattery110vDc_TblSubstation_LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAutoCircuitReCloser_TblSubstation_TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOutDoorTypeVacumnCircuitBreaker_TblSubstation_TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitch33KvIsolator_TblSubstation_TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitch33KvIsolator_TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator");

            migrationBuilder.DropIndex(
                name: "IX_TblOutDoorTypeVacumnCircuitBreaker_TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.DropIndex(
                name: "IX_TblAutoCircuitReCloser_TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser");

            migrationBuilder.DropIndex(
                name: "IX_LookUpNiCdBattery110vDc_LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc");

            migrationBuilder.DropIndex(
                name: "IX_LookUpBatteryCharger_LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger");

            migrationBuilder.DropIndex(
                name: "IX_LookUpAuxiliaryTransformer_LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer");

            migrationBuilder.DropColumn(
                name: "TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator");

            migrationBuilder.DropColumn(
                name: "TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.DropColumn(
                name: "TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser");

            migrationBuilder.DropColumn(
                name: "LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc");

            migrationBuilder.DropColumn(
                name: "LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger");

            migrationBuilder.DropColumn(
                name: "LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer");

            migrationBuilder.AlterColumn<string>(
                name: "SubstationId",
                table: "TblSwitch33KvIsolator",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeederLineId",
                table: "TblSwitch33KvIsolator",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubstationId",
                table: "TblRelay",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FeederLineId",
                table: "TblRelay",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitch33KvIsolator_FeederLineId",
                table: "TblSwitch33KvIsolator",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRelay_FeederLineId",
                table: "TblRelay",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblRelay_SubstationId",
                table: "TblRelay",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer",
                column: "SubstationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpAuxiliaryTransformer_TblSubstation_SubstationId",
                table: "LookUpAuxiliaryTransformer",
                column: "SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpBatteryCharger_TblSubstation_SubstationId",
                table: "LookUpBatteryCharger",
                column: "SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpNiCdBattery110vDc_TblSubstation_SubstationId",
                table: "LookUpNiCdBattery110vDc",
                column: "SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAutoCircuitReCloser_TblSubstation_SubstationId",
                table: "TblAutoCircuitReCloser",
                column: "SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOutDoorTypeVacumnCircuitBreaker_TblSubstation_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                column: "SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblRelay_TblFeederLine_FeederLineId",
                table: "TblRelay",
                column: "FeederLineId",
                principalTable: "TblFeederLine",
                principalColumn: "FeederLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblRelay_TblSubstation_SubstationId",
                table: "TblRelay",
                column: "SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitch33KvIsolator_TblFeederLine_FeederLineId",
                table: "TblSwitch33KvIsolator",
                column: "FeederLineId",
                principalTable: "TblFeederLine",
                principalColumn: "FeederLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitch33KvIsolator_TblSubstation_SubstationId",
                table: "TblSwitch33KvIsolator",
                column: "SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LookUpAuxiliaryTransformer_TblSubstation_SubstationId",
                table: "LookUpAuxiliaryTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_LookUpBatteryCharger_TblSubstation_SubstationId",
                table: "LookUpBatteryCharger");

            migrationBuilder.DropForeignKey(
                name: "FK_LookUpNiCdBattery110vDc_TblSubstation_SubstationId",
                table: "LookUpNiCdBattery110vDc");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAutoCircuitReCloser_TblSubstation_SubstationId",
                table: "TblAutoCircuitReCloser");

            migrationBuilder.DropForeignKey(
                name: "FK_TblOutDoorTypeVacumnCircuitBreaker_TblSubstation_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRelay_TblFeederLine_FeederLineId",
                table: "TblRelay");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRelay_TblSubstation_SubstationId",
                table: "TblRelay");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitch33KvIsolator_TblFeederLine_FeederLineId",
                table: "TblSwitch33KvIsolator");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSwitch33KvIsolator_TblSubstation_SubstationId",
                table: "TblSwitch33KvIsolator");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitch33KvIsolator_FeederLineId",
                table: "TblSwitch33KvIsolator");

            migrationBuilder.DropIndex(
                name: "IX_TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator");

            migrationBuilder.DropIndex(
                name: "IX_TblRelay_FeederLineId",
                table: "TblRelay");

            migrationBuilder.DropIndex(
                name: "IX_TblRelay_SubstationId",
                table: "TblRelay");

            migrationBuilder.DropIndex(
                name: "IX_TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker");

            migrationBuilder.DropIndex(
                name: "IX_TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser");

            migrationBuilder.DropIndex(
                name: "IX_LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc");

            migrationBuilder.DropIndex(
                name: "IX_LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger");

            migrationBuilder.DropIndex(
                name: "IX_LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer");

            migrationBuilder.DropColumn(
                name: "FeederLineId",
                table: "TblSwitch33KvIsolator");

            migrationBuilder.AlterColumn<int>(
                name: "SubstationId",
                table: "TblSwitch33KvIsolator",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubstationId",
                table: "TblRelay",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FeederLineId",
                table: "TblRelay",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblSwitch33KvIsolator_TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator",
                column: "TblSwitch33KvIsolator_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblOutDoorTypeVacumnCircuitBreaker_TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                column: "TblOutDoorTypeVacumnCircuitBreaker_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAutoCircuitReCloser_TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser",
                column: "TblAutoCircuitReCloser_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpNiCdBattery110vDc_LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc",
                column: "LookUpNiCdBattery110vDc_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpBatteryCharger_LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger",
                column: "LookUpBatteryCharger_SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_LookUpAuxiliaryTransformer_LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer",
                column: "LookUpAuxiliaryTransformer_SubstationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpAuxiliaryTransformer_TblSubstation_LookUpAuxiliaryTransformer_SubstationId",
                table: "LookUpAuxiliaryTransformer",
                column: "LookUpAuxiliaryTransformer_SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpBatteryCharger_TblSubstation_LookUpBatteryCharger_SubstationId",
                table: "LookUpBatteryCharger",
                column: "LookUpBatteryCharger_SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LookUpNiCdBattery110vDc_TblSubstation_LookUpNiCdBattery110vDc_SubstationId",
                table: "LookUpNiCdBattery110vDc",
                column: "LookUpNiCdBattery110vDc_SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAutoCircuitReCloser_TblSubstation_TblAutoCircuitReCloser_SubstationId",
                table: "TblAutoCircuitReCloser",
                column: "TblAutoCircuitReCloser_SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblOutDoorTypeVacumnCircuitBreaker_TblSubstation_TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                table: "TblOutDoorTypeVacumnCircuitBreaker",
                column: "TblOutDoorTypeVacumnCircuitBreaker_SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSwitch33KvIsolator_TblSubstation_TblSwitch33KvIsolator_SubstationId",
                table: "TblSwitch33KvIsolator",
                column: "TblSwitch33KvIsolator_SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
