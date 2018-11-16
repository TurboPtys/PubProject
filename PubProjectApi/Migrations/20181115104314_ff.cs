using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PubProjectApi.Migrations
{
    public partial class ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_GastronomicVenues_GastronomicVenueId",
                table: "Advertisements");

            migrationBuilder.AlterColumn<Guid>(
                name: "GastronomicVenueId",
                table: "Advertisements",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_GastronomicVenues_GastronomicVenueId",
                table: "Advertisements",
                column: "GastronomicVenueId",
                principalTable: "GastronomicVenues",
                principalColumn: "GastronomicVenueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_GastronomicVenues_GastronomicVenueId",
                table: "Advertisements");

            migrationBuilder.AlterColumn<Guid>(
                name: "GastronomicVenueId",
                table: "Advertisements",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_GastronomicVenues_GastronomicVenueId",
                table: "Advertisements",
                column: "GastronomicVenueId",
                principalTable: "GastronomicVenues",
                principalColumn: "GastronomicVenueId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
