using Microsoft.EntityFrameworkCore.Migrations;

namespace AthelasAPI.Migrations
{
    public partial class FixedSpellingNumerToNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumer",
                table: "Clients",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Clients",
                newName: "PhoneNumer");
        }
    }
}
