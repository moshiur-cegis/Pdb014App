using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateConsumerData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_TblFeederLine_FeederLineId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_FeederLineId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "FeederLineId",
                table: "TblConsumerData");

            migrationBuilder.AddColumn<string>(
                name: "DistributionTransformerId",
                table: "TblConsumerData",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_DistributionTransformerId",
                table: "TblConsumerData",
                column: "DistributionTransformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_TblDistributionTransformer_DistributionTransformerId",
                table: "TblConsumerData",
                column: "DistributionTransformerId",
                principalTable: "TblDistributionTransformer",
                principalColumn: "DistributionTransformerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_TblDistributionTransformer_DistributionTransformerId",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_DistributionTransformerId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "DistributionTransformerId",
                table: "TblConsumerData");

            migrationBuilder.AddColumn<string>(
                name: "FeederLineId",
                table: "TblConsumerData",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblConsumerData_FeederLineId",
                table: "TblConsumerData",
                column: "FeederLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblConsumerData_TblFeederLine_FeederLineId",
                table: "TblConsumerData",
                column: "FeederLineId",
                principalTable: "TblFeederLine",
                principalColumn: "FeederLineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
