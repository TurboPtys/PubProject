using Microsoft.EntityFrameworkCore.Migrations;

namespace PubProjectApi.Migrations
{
    public partial class Venues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "GastronomicVenues",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "GastronomicVenues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseNr",
                table: "GastronomicVenues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalNr",
                table: "GastronomicVenues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "GastronomicVenues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "GastronomicVenues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "GastronomicVenues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "GastronomicVenues");

            migrationBuilder.DropColumn(
                name: "City",
                table: "GastronomicVenues");

            migrationBuilder.DropColumn(
                name: "HouseNr",
                table: "GastronomicVenues");

            migrationBuilder.DropColumn(
                name: "LocalNr",
                table: "GastronomicVenues");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "GastronomicVenues");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "GastronomicVenues");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "GastronomicVenues");
        }
    }
}
