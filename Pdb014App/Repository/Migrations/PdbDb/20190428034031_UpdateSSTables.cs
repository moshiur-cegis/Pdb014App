using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateSSTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteCode",
                table: "TblIndoorOutdoorTypeProgrammableEnergyMeter");

            migrationBuilder.AlterColumn<string>(
                name: "SubstationId",
                table: "TblAutoCircuitReCloser",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubstationId",
                table: "LookUpNiCdBattery110vDc",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldDisplayFormat",
                table: "LookUpModelFieldInfo",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubstationId",
                table: "LookUpBatteryCharger",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubstationId",
                table: "LookUpAuxiliaryTransformer",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldDisplayFormat",
                table: "LookUpModelFieldInfo");

            migrationBuilder.AddColumn<string>(
                name: "RouteCode",
                table: "TblIndoorOutdoorTypeProgrammableEnergyMeter",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubstationId",
                table: "TblAutoCircuitReCloser",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubstationId",
                table: "LookUpNiCdBattery110vDc",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubstationId",
                table: "LookUpBatteryCharger",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubstationId",
                table: "LookUpAuxiliaryTransformer",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }
    }
}
