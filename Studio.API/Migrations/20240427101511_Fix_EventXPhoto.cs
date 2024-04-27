using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.API.Migrations
{
    public partial class Fix_EventXPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Event_EventId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_EventId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Photo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Photo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_EventId",
                table: "Photo",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Event_EventId",
                table: "Photo",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");
        }
    }
}
