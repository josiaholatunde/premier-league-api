using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fixtures.API.Migrations
{
    public partial class AddedDbModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LocationCity = table.Column<string>(nullable: true),
                    LocationCountry = table.Column<string>(nullable: true),
                    FanStrength = table.Column<double>(nullable: false),
                    StadiumName = table.Column<string>(nullable: true),
                    NameOfManager = table.Column<string>(nullable: true),
                    YearFounded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    FavoriteTeam = table.Column<string>(nullable: true),
                    UserRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HomeTeamName = table.Column<string>(nullable: true),
                    HomeTeamLogoUrl = table.Column<string>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: false),
                    AwayTeamName = table.Column<string>(nullable: true),
                    AwayTeamLogoUrl = table.Column<string>(nullable: true),
                    AwayTeamScore = table.Column<int>(nullable: false),
                    TimeOfPlay = table.Column<DateTime>(nullable: false),
                    LocationOfPlay = table.Column<string>(nullable: true),
                    IsFixtureCompleted = table.Column<bool>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixtures_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_TeamId",
                table: "Fixtures",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
