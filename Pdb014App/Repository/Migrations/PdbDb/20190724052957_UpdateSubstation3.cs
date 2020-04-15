using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdb014App.Repository.Migrations.PdbDb
{
    public partial class UpdateSubstation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WireLength",
                table: "TblSubstation",
                newName: "MaximumDemand");

            migrationBuilder.AddColumn<decimal>(
                name: "PeakLoad",
                table: "TblSubstation",
                type: "decimal(7, 2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeakLoad",
                table: "TblSubstation");

            migrationBuilder.RenameColumn(
                name: "MaximumDemand",
                table: "TblSubstation",
                newName: "WireLength");
        }
    }
}
