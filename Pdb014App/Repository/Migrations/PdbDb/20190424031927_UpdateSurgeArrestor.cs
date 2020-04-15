using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateSurgeArrestor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DistributionTransformerId",
                table: "TblPoleStructureMountedSurgearrestor",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPoleStructureMountedSurgearrestor_DistributionTransformerId",
                table: "TblPoleStructureMountedSurgearrestor",
                column: "DistributionTransformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPoleStructureMountedSurgearrestor_TblDistributionTransformer_DistributionTransformerId",
                table: "TblPoleStructureMountedSurgearrestor",
                column: "DistributionTransformerId",
                principalTable: "TblDistributionTransformer",
                principalColumn: "DistributionTransformerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPoleStructureMountedSurgearrestor_TblDistributionTransformer_DistributionTransformerId",
                table: "TblPoleStructureMountedSurgearrestor");

            migrationBuilder.DropIndex(
                name: "IX_TblPoleStructureMountedSurgearrestor_DistributionTransformerId",
                table: "TblPoleStructureMountedSurgearrestor");

            migrationBuilder.DropColumn(
                name: "DistributionTransformerId",
                table: "TblPoleStructureMountedSurgearrestor");
        }
    }
}
