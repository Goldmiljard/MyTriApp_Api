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
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<float>(type: "real", nullable: false),
                    MovingTime = table.Column<int>(type: "int", nullable: false),
                    ElapsedTime = table.Column<int>(type: "int", nullable: false),
                    TotalElevationGain = table.Column<float>(type: "real", nullable: false),
                    SportType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StravaId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateLocal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UtcOffset = table.Column<int>(type: "int", nullable: false),
                    StartLat = table.Column<float>(type: "real", nullable: false),
                    StartLng = table.Column<float>(type: "real", nullable: false),
                    EndLat = table.Column<float>(type: "real", nullable: false),
                    EndLng = table.Column<float>(type: "real", nullable: false),
                    Polyline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummaryPolyline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageSpeed = table.Column<float>(type: "real", nullable: false),
                    MaxSpeed = table.Column<float>(type: "real", nullable: false),
                    AverageCadence = table.Column<float>(type: "real", nullable: false),
                    AverageTemp = table.Column<int>(type: "int", nullable: false),
                    AverageWatts = table.Column<float>(type: "real", nullable: false),
                    WeightedAverageWatts = table.Column<int>(type: "int", nullable: false),
                    Kilojoules = table.Column<float>(type: "real", nullable: false),
                    DeviceWatts = table.Column<bool>(type: "bit", nullable: false),
                    HasHeartrate = table.Column<bool>(type: "bit", nullable: false),
                    AverageHeartrate = table.Column<float>(type: "real", nullable: false),
                    MaxHeartrate = table.Column<float>(type: "real", nullable: false),
                    MaxWatts = table.Column<int>(type: "int", nullable: false),
                    ElevHigh = table.Column<float>(type: "real", nullable: false),
                    ElevLow = table.Column<float>(type: "real", nullable: false),
                    SufferScore = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<float>(type: "real", nullable: false),
                    Gear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GearDistance = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ExternalId",
                        onDelete: ReferentialAction.Cascade);
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
                    AthleteId = table.Column<long>(type: "bigint", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Lap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StravaId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElapsedTime = table.Column<int>(type: "int", nullable: false),
                    MovingTime = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateLocal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distance = table.Column<float>(type: "real", nullable: false),
                    StartIndex = table.Column<int>(type: "int", nullable: false),
                    EndIndex = table.Column<int>(type: "int", nullable: false),
                    TotalElevationGain = table.Column<int>(type: "int", nullable: false),
                    AverageSpeed = table.Column<float>(type: "real", nullable: false),
                    MaxSpeed = table.Column<float>(type: "real", nullable: false),
                    AverageCadence = table.Column<float>(type: "real", nullable: false),
                    DeviceWatts = table.Column<bool>(type: "bit", nullable: false),
                    AverageWatts = table.Column<float>(type: "real", nullable: false),
                    LapIndex = table.Column<int>(type: "int", nullable: false),
                    SplitNumber = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lap_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Split",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<float>(type: "real", nullable: false),
                    ElapsedTime = table.Column<int>(type: "int", nullable: false),
                    ElevationDifference = table.Column<float>(type: "real", nullable: false),
                    MovingTime = table.Column<int>(type: "int", nullable: false),
                    SplitNumber = table.Column<int>(type: "int", nullable: false),
                    AverageSpeed = table.Column<float>(type: "real", nullable: false),
                    PaceZone = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Split", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Split_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lap_ActivityId",
                table: "Lap",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Split_ActivityId",
                table: "Split",
                column: "ActivityId");

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
                name: "Lap");

            migrationBuilder.DropTable(
                name: "Split");

            migrationBuilder.DropTable(
                name: "StravaAccessTokens");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
