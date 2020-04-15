using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePole30_5_2019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "WireLength",
                table: "TblPole",
                type: "decimal(10, 0)",
                nullable: true,
                oldClrType: typeof(double),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SurveyDate",
                table: "TblPole",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "TblPole",
                type: "decimal(10, 0)",
                nullable: true,
                oldClrType: typeof(double),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "TblPole",
                type: "decimal(10, 0)",
                nullable: true,
                oldClrType: typeof(double),
                oldMaxLength: 250);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "WireLength",
                table: "TblPole",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SurveyDate",
                table: "TblPole",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "TblPole",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "TblPole",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 0)",
                oldNullable: true);
        }
    }
}
