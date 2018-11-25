using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PubProjectApi.Migrations
{
    public partial class EventDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Advertisements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Advertisements");
        }
    }
}
