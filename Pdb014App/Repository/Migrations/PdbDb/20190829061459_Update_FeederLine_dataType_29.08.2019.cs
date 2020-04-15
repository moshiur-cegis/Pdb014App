using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class Update_FeederLine_dataType_29082019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedermeterNumber",
                table: "TblFeederLine",
                newName: "FeederMeterNumber");

            migrationBuilder.AlterColumn<decimal>(
                name: "SanctionedLoad",
                table: "TblFeederLine",
                type: "decimal(12, 5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PeakDemand",
                table: "TblFeederLine",
                type: "decimal(12, 5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NominalVoltage",
                table: "TblFeederLine",
                type: "decimal(12, 5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MeterVoltageRating",
                table: "TblFeederLine",
                type: "decimal(12, 5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MeterCurrentRating",
                table: "TblFeederLine",
                type: "decimal(12, 5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumLoad",
                table: "TblFeederLine",
                type: "decimal(12, 5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumDemand",
                table: "TblFeederLine",
                type: "decimal(12, 5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeederMeterNumber",
                table: "TblFeederLine",
                newName: "FeedermeterNumber");

            migrationBuilder.AlterColumn<string>(
                name: "SanctionedLoad",
                table: "TblFeederLine",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PeakDemand",
                table: "TblFeederLine",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NominalVoltage",
                table: "TblFeederLine",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeterVoltageRating",
                table: "TblFeederLine",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeterCurrentRating",
                table: "TblFeederLine",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaximumLoad",
                table: "TblFeederLine",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaximumDemand",
                table: "TblFeederLine",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 5)",
                oldNullable: true);
        }
    }
}
