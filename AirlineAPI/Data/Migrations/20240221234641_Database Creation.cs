using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineAPI.Data.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftTypes",
                columns: table => new
                {
                    PlaneTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IATACode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AircraftTypeID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTypes", x => x.PlaneTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    IATACode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IATAAccounting = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ICAOCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Callsign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FleetSize = table.Column<int>(type: "int", nullable: false),
                    FleetAge = table.Column<float>(type: "real", nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryISO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.IATACode);
                });

            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    RegistrationCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ProductionLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICAOHex = table.Column<int>(type: "int", nullable: false),
                    ShortIATACode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ConstructionID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    RolloutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstFlight = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerIATACode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    EngineCount = table.Column<int>(type: "int", nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.RegistrationCode);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    IATACode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    GMTOffset = table.Column<float>(type: "real", nullable: false),
                    CountryISO = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityIATA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.IATACode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftTypes");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
