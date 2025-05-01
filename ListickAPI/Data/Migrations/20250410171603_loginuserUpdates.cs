using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class loginuserUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "Name", table: "LoginUser", newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "AptSuite",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LoginUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "LoginUser",
                type: "datetime2",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "DateFormat",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "LoginUser",
                type: "datetime2",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "LoginUser",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "LoginUser",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "LoginUser",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "LoginUser",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "StateProvince",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "TimeFormat",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "WeekStartWeekDayId",
                table: "LoginUser",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_LoginUser_WeekStartWeekDayId",
                table: "LoginUser",
                column: "WeekStartWeekDayId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_LoginUser_WeekDays_WeekStartWeekDayId",
                table: "LoginUser",
                column: "WeekStartWeekDayId",
                principalTable: "WeekDays",
                principalColumn: "WeekDayId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginUser_WeekDays_WeekStartWeekDayId",
                table: "LoginUser"
            );

            migrationBuilder.DropIndex(name: "IX_LoginUser_WeekStartWeekDayId", table: "LoginUser");

            migrationBuilder.DropColumn(name: "AptSuite", table: "LoginUser");

            migrationBuilder.DropColumn(name: "City", table: "LoginUser");

            migrationBuilder.DropColumn(name: "Country", table: "LoginUser");

            migrationBuilder.DropColumn(name: "Currency", table: "LoginUser");

            migrationBuilder.DropColumn(name: "DateCreated", table: "LoginUser");

            migrationBuilder.DropColumn(name: "DateDeleted", table: "LoginUser");

            migrationBuilder.DropColumn(name: "DateFormat", table: "LoginUser");

            migrationBuilder.DropColumn(name: "DateModified", table: "LoginUser");

            migrationBuilder.DropColumn(name: "DeletedBy", table: "LoginUser");

            migrationBuilder.DropColumn(name: "LastName", table: "LoginUser");

            migrationBuilder.DropColumn(name: "ModifiedBy", table: "LoginUser");

            migrationBuilder.DropColumn(name: "PhoneNumber", table: "LoginUser");

            migrationBuilder.DropColumn(name: "ProfilePictureUrl", table: "LoginUser");

            migrationBuilder.DropColumn(name: "StateProvince", table: "LoginUser");

            migrationBuilder.DropColumn(name: "StreetAddress", table: "LoginUser");

            migrationBuilder.DropColumn(name: "TimeFormat", table: "LoginUser");

            migrationBuilder.DropColumn(name: "TimeZone", table: "LoginUser");

            migrationBuilder.DropColumn(name: "WeekStartWeekDayId", table: "LoginUser");

            migrationBuilder.DropColumn(name: "ZipCode", table: "LoginUser");

            migrationBuilder.RenameColumn(name: "FirstName", table: "LoginUser", newName: "Name");
        }
    }
}
