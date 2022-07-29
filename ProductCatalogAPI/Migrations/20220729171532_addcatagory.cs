using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class addcatagory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_eventLocations",
                table: "eventLocations");

            migrationBuilder.RenameTable(
                name: "eventLocations",
                newName: "EventLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventLocations",
                table: "EventLocations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EventCatagories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCatagories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PictureURL = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Organizer = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    EventCatagoryId = table.Column<int>(nullable: false),
                    EventLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventItems_EventCatagories_EventCatagoryId",
                        column: x => x.EventCatagoryId,
                        principalTable: "EventCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventItems_EventLocations_EventLocationId",
                        column: x => x.EventLocationId,
                        principalTable: "EventLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventCatagoryId",
                table: "EventItems",
                column: "EventCatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventItems_EventLocationId",
                table: "EventItems",
                column: "EventLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventItems");

            migrationBuilder.DropTable(
                name: "EventCatagories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventLocations",
                table: "EventLocations");

            migrationBuilder.RenameTable(
                name: "EventLocations",
                newName: "eventLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_eventLocations",
                table: "eventLocations",
                column: "Id");
        }
    }
}
