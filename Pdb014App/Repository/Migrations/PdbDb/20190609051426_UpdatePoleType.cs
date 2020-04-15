using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePoleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WireLength",
                table: "TblPole",
                type: "decimal(10, 2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "TblPole",
                type: "decimal(10, 8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "TblPole",
                type: "decimal(10, 8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 0)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WireLength",
                table: "TblPole",
                type: "decimal(10, 0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "TblPole",
                type: "decimal(10, 0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "TblPole",
                type: "decimal(10, 0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 8)",
                oldNullable: true);
        }
    }
}
