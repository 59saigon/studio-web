using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.API.Migrations
{
    public partial class EventXService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Event_EventId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_EventId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Service");

            migrationBuilder.CreateTable(
                name: "EventXService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventXService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventXService_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventXService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventXService_EventId",
                table: "EventXService",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventXService_ServiceId",
                table: "EventXService",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventXService");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Service",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Service_EventId",
                table: "Service",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Event_EventId",
                table: "Service",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
