using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class Substation_by_ahi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TblSubstationPicture_TblSubstation_TblSubstationPicture_SubstationId",
            //    table: "TblSubstationPicture");

            //migrationBuilder.DropIndex(
            //    name: "IX_TblSubstationPicture_TblSubstationPicture_SubstationId",
            //    table: "TblSubstationPicture");

            //migrationBuilder.DropColumn(
            //    name: "TblSubstationPicture_SubstationId",
            //    table: "TblSubstationPicture");

            migrationBuilder.RenameColumn(
                name: "SubstrationPictureId",
                table: "TblSubstationPicture",
                newName: "SubstationPictureId");

            migrationBuilder.RenameColumn(
                name: "SubstrationName",
                table: "TblSubstation",
                newName: "SubstationName");

            migrationBuilder.CreateIndex(
                name: "IX_TblSubstationPicture_SubstationId",
                table: "TblSubstationPicture",
                column: "SubstationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubstationPicture_TblSubstation_SubstationId",
                table: "TblSubstationPicture",
                column: "SubstationId",
                principalTable: "TblSubstation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSubstationPicture_TblSubstation_SubstationId",
                table: "TblSubstationPicture");

            migrationBuilder.DropIndex(
                name: "IX_TblSubstationPicture_SubstationId",
                table: "TblSubstationPicture");

            migrationBuilder.RenameColumn(
                name: "SubstationPictureId",
                table: "TblSubstationPicture",
                newName: "SubstrationPictureId");

            migrationBuilder.RenameColumn(
                name: "SubstationName",
                table: "TblSubstation",
                newName: "SubstrationName");

            //migrationBuilder.AddColumn<string>(
            //    name: "TblSubstationPicture_SubstationId",
            //    table: "TblSubstationPicture",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_TblSubstationPicture_TblSubstationPicture_SubstationId",
            //    table: "TblSubstationPicture",
            //    column: "TblSubstationPicture_SubstationId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TblSubstationPicture_TblSubstation_TblSubstationPicture_SubstationId",
            //    table: "TblSubstationPicture",
            //    column: "TblSubstationPicture_SubstationId",
            //    principalTable: "TblSubstation",
            //    principalColumn: "SubstationId",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
