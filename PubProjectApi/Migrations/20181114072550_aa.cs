using Microsoft.EntityFrameworkCore.Migrations;

namespace PubProjectApi.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "GastronomicVenues",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "GastronomicVenues",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "GastronomicVenues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "GastronomicVenues");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "GastronomicVenues");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "GastronomicVenues");
        }
    }
}
