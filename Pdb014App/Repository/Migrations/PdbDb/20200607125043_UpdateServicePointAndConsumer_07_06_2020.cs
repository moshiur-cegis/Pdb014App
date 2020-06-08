using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateServicePointAndConsumer_07_06_2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblConsumerData_TblDistributionTransformer_DistributionTransformerId",
                table: "TblConsumerData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblConsumerData",
                table: "TblConsumerData");

            migrationBuilder.DropIndex(
                name: "IX_TblConsumerData_DistributionTransformerId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "DistributionTransformerId",
                table: "TblConsumerData");

            migrationBuilder.AddColumn<string>(
                name: "DistributionTransformerId",
                table: "TblServicePoint",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                type: "varchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsumersId",
                table: "TblConsumerData",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblConsumerData",
                table: "TblConsumerData",
                column: "ConsumersId");

            migrationBuilder.CreateIndex(
                name: "IX_TblServicePoint_DistributionTransformerId",
                table: "TblServicePoint",
                column: "DistributionTransformerId");

            migrationBuilder.CreateIndex(
                name: "IX_TblDistributionTransformer_HTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                column: "HTBushingBPhaseGood");

            migrationBuilder.AddForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_HTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                column: "HTBushingBPhaseGood",
                principalTable: "LookUpDtCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblServicePoint_TblDistributionTransformer_DistributionTransformerId",
                table: "TblServicePoint",
                column: "DistributionTransformerId",
                principalTable: "TblDistributionTransformer",
                principalColumn: "DistributionTransformerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblDistributionTransformer_LookUpDtCondition_HTBushingBPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblServicePoint_TblDistributionTransformer_DistributionTransformerId",
                table: "TblServicePoint");

            migrationBuilder.DropIndex(
                name: "IX_TblServicePoint_DistributionTransformerId",
                table: "TblServicePoint");

            migrationBuilder.DropIndex(
                name: "IX_TblDistributionTransformer_HTBushingBPhaseGood",
                table: "TblDistributionTransformer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblConsumerData",
                table: "TblConsumerData");

            migrationBuilder.DropColumn(
                name: "DistributionTransformerId",
                table: "TblServicePoint");

            migrationBuilder.DropColumn(
                name: "ConsumersId",
                table: "TblConsumerData");

            migrationBuilder.AlterColumn<string>(
                name: "HTBushingBPhaseGood",
                table: "TblDistributionTransformer",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsumerId",
                table: "TblConsumerData",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "DistributionTransformerId",
                table: "TblConsumerData",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblConsumerData",
                table: "TblConsumerData",
                column: "ConsumerId");

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
    }
}
