using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdatePowerTransformer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPhasePowerTransformer_TblFeederLine_FeederLineId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropForeignKey(
                name: "FK_TblPhasePowerTransformer_TblSurgeArrestor_SurgeArrestorId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblPhasePowerTransformer_FeederLineId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropIndex(
                name: "IX_TblPhasePowerTransformer_SurgeArrestorId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "FeederLineId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.DropColumn(
                name: "SurgeArrestorId",
                table: "TblPhasePowerTransformer");

            migrationBuilder.AddColumn<string>(
                name: "PhasePowerTransformerId",
                table: "TblSurgeArrestor",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblSurgeArrestor_PhasePowerTransformerId",
                table: "TblSurgeArrestor",
                column: "PhasePowerTransformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSurgeArrestor_TblPhasePowerTransformer_PhasePowerTransformerId",
                table: "TblSurgeArrestor",
                column: "PhasePowerTransformerId",
                principalTable: "TblPhasePowerTransformer",
                principalColumn: "PhasePowerTransformerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSurgeArrestor_TblPhasePowerTransformer_PhasePowerTransformerId",
                table: "TblSurgeArrestor");

            migrationBuilder.DropIndex(
                name: "IX_TblSurgeArrestor_PhasePowerTransformerId",
                table: "TblSurgeArrestor");

            migrationBuilder.DropColumn(
                name: "PhasePowerTransformerId",
                table: "TblSurgeArrestor");

            migrationBuilder.AddColumn<string>(
                name: "FeederLineId",
                table: "TblPhasePowerTransformer",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurgeArrestorId",
                table: "TblPhasePowerTransformer",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblPhasePowerTransformer_FeederLineId",
                table: "TblPhasePowerTransformer",
                column: "FeederLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPhasePowerTransformer_SurgeArrestorId",
                table: "TblPhasePowerTransformer",
                column: "SurgeArrestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPhasePowerTransformer_TblFeederLine_FeederLineId",
                table: "TblPhasePowerTransformer",
                column: "FeederLineId",
                principalTable: "TblFeederLine",
                principalColumn: "FeederLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblPhasePowerTransformer_TblSurgeArrestor_SurgeArrestorId",
                table: "TblPhasePowerTransformer",
                column: "SurgeArrestorId",
                principalTable: "TblSurgeArrestor",
                principalColumn: "SurgeArrestorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
