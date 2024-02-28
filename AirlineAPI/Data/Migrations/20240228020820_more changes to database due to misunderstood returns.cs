using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineAPI.Data.Migrations
{
    public partial class morechangestodatabaseduetomisunderstoodreturns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ICAOHex",
                table: "Airplanes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ICAOHex",
                table: "Airplanes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
