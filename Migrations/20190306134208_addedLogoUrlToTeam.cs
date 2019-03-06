using Microsoft.EntityFrameworkCore.Migrations;

namespace Fixtures.API.Migrations
{
    public partial class addedLogoUrlToTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeamLogoUrl",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "HomeTeamLogoUrl",
                table: "Fixtures");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Teams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "AwayTeamLogoUrl",
                table: "Fixtures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTeamLogoUrl",
                table: "Fixtures",
                nullable: true);
        }
    }
}
