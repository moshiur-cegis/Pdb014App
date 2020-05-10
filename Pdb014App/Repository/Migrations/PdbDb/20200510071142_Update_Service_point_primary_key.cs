using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class Update_Service_point_primary_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_TblServicePoint_ServicePointId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblServicePoint_TblPole_PoleId",
                table: "TblServicePoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblServicePoint",
                table: "TblServicePoint");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_ServicePointId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "ServicePointId",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "ServicePointId",
                table: "TblConsumerData");

            migrationBuilder.AlterColumn<string>(
                name: "PoleId",
                table: "TblServicePoint",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesPointId",
                table: "TblServicePoint",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServicesPointId",
                table: "TblConsumerData",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblServicePoint",
                table: "TblServicePoint",
                column: "ServicesPointId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_ServicesPointId",
                table: "TblConsumerData",
                column: "ServicesPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_TblServicePoint_ServicesPointId",
                table: "TblConsumerData",
                column: "ServicesPointId",
                principalTable: "TblServicePoint",
                principalColumn: "ServicesPointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblServicePoint_TblPole_PoleId",
                table: "TblServicePoint",
                column: "PoleId",
                principalTable: "TblPole",
                principalColumn: "PoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_TblServicePoint_ServicesPointId",
                table: "TblConsumerData");

            migrationBuilder.DropForeignKey(
                name: "FK_TblServicePoint_TblPole_PoleId",
                table: "TblServicePoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblServicePoint",
                table: "TblServicePoint");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_ServicesPointId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "ServicesPointId",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "ServicesPointId",
                table: "TblConsumerData");

            migrationBuilder.AlterColumn<string>(
                name: "PoleId",
                table: "TblServicePoint",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ServicePointId",
                table: "TblServicePoint",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ServicePointId",
                table: "TblConsumerData",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblServicePoint",
                table: "TblServicePoint",
                column: "ServicePointId");

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_ServicePointId",
                table: "TblConsumerData",
                column: "ServicePointId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_TblServicePoint_ServicePointId",
                table: "TblConsumerData",
                column: "ServicePointId",
                principalTable: "TblServicePoint",
                principalColumn: "ServicePointId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblServicePoint_TblPole_PoleId",
                table: "TblServicePoint",
                column: "PoleId",
                principalTable: "TblPole",
                principalColumn: "PoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
