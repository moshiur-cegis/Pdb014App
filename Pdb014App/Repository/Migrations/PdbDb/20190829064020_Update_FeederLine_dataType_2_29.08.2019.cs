using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class Update_FeederLine_dataType_2_29082019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NominalVoltage",
                table: "TblFeederLine",
                type: "decimal(5, 0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12, 5)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NominalVoltage",
                table: "TblFeederLine",
                type: "decimal(12, 5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 0)",
                oldNullable: true);
        }
    }
}
