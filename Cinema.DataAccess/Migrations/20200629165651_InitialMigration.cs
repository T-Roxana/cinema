using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatsMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatsMaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieTheaters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SeatsMapsId = table.Column<Guid>(nullable: true),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheaters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTheaters_SeatsMaps_SeatsMapsId",
                        column: x => x.SeatsMapsId,
                        principalTable: "SeatsMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Row = table.Column<string>(nullable: true),
                    Column = table.Column<string>(nullable: true),
                    IsReserved = table.Column<bool>(nullable: false),
                    SeatsMapId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_SeatsMaps_SeatsMapId",
                        column: x => x.SeatsMapId,
                        principalTable: "SeatsMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoviePlannings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MovieTheaterId = table.Column<Guid>(nullable: true),
                    MovieId = table.Column<Guid>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePlannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviePlannings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoviePlannings_MovieTheaters_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MoviePlanningId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_MoviePlannings_MoviePlanningId",
                        column: x => x.MoviePlanningId,
                        principalTable: "MoviePlannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlannings_MovieId",
                table: "MoviePlannings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlannings_MovieTheaterId",
                table: "MoviePlannings",
                column: "MovieTheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaters_SeatsMapsId",
                table: "MovieTheaters",
                column: "SeatsMapsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MoviePlanningId",
                table: "Reservations",
                column: "MoviePlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatsMapId",
                table: "Seats",
                column: "SeatsMapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MoviePlannings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MovieTheaters");

            migrationBuilder.DropTable(
                name: "SeatsMaps");
        }
    }
}
