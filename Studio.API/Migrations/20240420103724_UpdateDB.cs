using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.API.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_Country_Id",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_Location_Id",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Wedding_Wedding_Id",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_City_City_Id",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "Wedding_Name",
                table: "Wedding",
                newName: "WeddingTittle");

            migrationBuilder.RenameColumn(
                name: "Location_Name",
                table: "Location",
                newName: "LocationName");

            migrationBuilder.RenameColumn(
                name: "City_Id",
                table: "Location",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_City_Id",
                table: "Location",
                newName: "IX_Location_CityId");

            migrationBuilder.RenameColumn(
                name: "Wedding_Id",
                table: "Event",
                newName: "WeddingId");

            migrationBuilder.RenameColumn(
                name: "Location_Id",
                table: "Event",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "Event_name",
                table: "Event",
                newName: "EventTittle");

            migrationBuilder.RenameIndex(
                name: "IX_Event_Wedding_Id",
                table: "Event",
                newName: "IX_Event_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_Location_Id",
                table: "Event",
                newName: "IX_Event_LocationId");

            migrationBuilder.RenameColumn(
                name: "Country_Name",
                table: "Country",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "Country_Id",
                table: "City",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "City_Name",
                table: "City",
                newName: "CityName");

            migrationBuilder.RenameIndex(
                name: "IX_City_Country_Id",
                table: "City",
                newName: "IX_City_CountryId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Wedding",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeddingDescription",
                table: "Wedding",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ServiceDescription",
                table: "Service",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTittle",
                table: "Service",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoName",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "Event",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Wedding_WeddingId",
                table: "Event",
                column: "WeddingId",
                principalTable: "Wedding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_City_CityId",
                table: "Location",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Wedding_WeddingId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_City_CityId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Wedding");

            migrationBuilder.DropColumn(
                name: "WeddingDescription",
                table: "Wedding");

            migrationBuilder.DropColumn(
                name: "ServiceDescription",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceTittle",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "WeddingTittle",
                table: "Wedding",
                newName: "Wedding_Name");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "Location",
                newName: "Location_Name");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Location",
                newName: "City_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Location_CityId",
                table: "Location",
                newName: "IX_Location_City_Id");

            migrationBuilder.RenameColumn(
                name: "WeddingId",
                table: "Event",
                newName: "Wedding_Id");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Event",
                newName: "Location_Id");

            migrationBuilder.RenameColumn(
                name: "EventTittle",
                table: "Event",
                newName: "Event_name");

            migrationBuilder.RenameIndex(
                name: "IX_Event_WeddingId",
                table: "Event",
                newName: "IX_Event_Wedding_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Event_LocationId",
                table: "Event",
                newName: "IX_Event_Location_Id");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Country",
                newName: "Country_Name");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "City",
                newName: "Country_Id");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "City",
                newName: "City_Name");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountryId",
                table: "City",
                newName: "IX_City_Country_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoName",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_Country_Id",
                table: "City",
                column: "Country_Id",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_Location_Id",
                table: "Event",
                column: "Location_Id",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Wedding_Wedding_Id",
                table: "Event",
                column: "Wedding_Id",
                principalTable: "Wedding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_City_City_Id",
                table: "Location",
                column: "City_Id",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
