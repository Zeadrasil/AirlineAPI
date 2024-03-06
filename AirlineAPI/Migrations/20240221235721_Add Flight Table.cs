using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineAPI.Data.Migrations
{
    public partial class AddFlightTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightNumber = table.Column<int>(type: "int", nullable: false),
                    AirlineIATA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    EstimatedDeparture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureTerminal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalTerminal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureIATA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalIATA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedArrival = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReserverID = table.Column<int>(type: "int", nullable: false),
                    DepartureGate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalGate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
