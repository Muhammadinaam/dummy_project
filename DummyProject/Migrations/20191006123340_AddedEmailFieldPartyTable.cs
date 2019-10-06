using Microsoft.EntityFrameworkCore.Migrations;

namespace DummyProject.Migrations
{
    public partial class AddedEmailFieldPartyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Parties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Parties");
        }
    }
}
