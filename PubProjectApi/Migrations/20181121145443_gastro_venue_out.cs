using Microsoft.EntityFrameworkCore.Migrations;

namespace PubProjectApi.Migrations
{
    public partial class gastro_venue_out : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_GastronomicVenues_GastronomicVenueId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_GastronomicVenueId",
                table: "Advertisements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_GastronomicVenueId",
                table: "Advertisements",
                column: "GastronomicVenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_GastronomicVenues_GastronomicVenueId",
                table: "Advertisements",
                column: "GastronomicVenueId",
                principalTable: "GastronomicVenues",
                principalColumn: "GastronomicVenueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
