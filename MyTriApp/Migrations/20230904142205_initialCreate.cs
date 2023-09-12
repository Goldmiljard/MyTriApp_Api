using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTriApp.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    MovingTime = table.Column<int>(type: "int", nullable: false),
                    ElapsedTime = table.Column<int>(type: "int", nullable: false),
                    TotalElevationGain = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StravaId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateLocal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UTCOffset = table.Column<int>(type: "int", nullable: false),
                    StartLat = table.Column<float>(type: "real", nullable: false),
                    StartLng = table.Column<float>(type: "real", nullable: false),
                    EndLat = table.Column<float>(type: "real", nullable: false),
                    EndLng = table.Column<float>(type: "real", nullable: false),
                    LocationCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageSpeed = table.Column<double>(type: "float", nullable: false),
                    MaxSpeed = table.Column<int>(type: "int", nullable: false),
                    AverageCadence = table.Column<double>(type: "float", nullable: false),
                    AverageWatts = table.Column<double>(type: "float", nullable: false),
                    WeightedAverageWatts = table.Column<int>(type: "int", nullable: false),
                    Kilojoules = table.Column<double>(type: "float", nullable: false),
                    DeviceWatts = table.Column<bool>(type: "bit", nullable: false),
                    HasHeartRate = table.Column<bool>(type: "bit", nullable: false),
                    AverageHeartRate = table.Column<double>(type: "float", nullable: false),
                    MaxHeartRate = table.Column<int>(type: "int", nullable: false),
                    MaxWatts = table.Column<int>(type: "int", nullable: false),
                    PRCount = table.Column<int>(type: "int", nullable: false),
                    SufferScore = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ExternalId);
                });

            migrationBuilder.CreateTable(
                name: "StravaAccessTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<int>(type: "int", nullable: false),
                    ExpiresIn = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StravaAccessTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StravaAccessTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ExternalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StravaAccessTokens_UserId",
                table: "StravaAccessTokens",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "StravaAccessTokens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
