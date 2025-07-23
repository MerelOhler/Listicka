using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePriorityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorHexCode",
                table: "Priority",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<int>(
                name: "CreatedByLoginUserId",
                table: "Priority",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Priority",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Priority",
                type: "datetime2",
                nullable: true
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Priority",
                type: "datetime2",
                nullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "DeletedByLoginUserId",
                table: "Priority",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Priority",
                type: "bit",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Priority",
                type: "bit",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByLoginUserId",
                table: "Priority",
                type: "int",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "PriorityName",
                table: "Priority",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: ""
            );

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Priority",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.CreateIndex(
                name: "IX_Priority_CreatedByLoginUserId",
                table: "Priority",
                column: "CreatedByLoginUserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Priority_DeletedByLoginUserId",
                table: "Priority",
                column: "DeletedByLoginUserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Priority_ModifiedByLoginUserId",
                table: "Priority",
                column: "ModifiedByLoginUserId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Priority_LoginUser_CreatedByLoginUserId",
                table: "Priority",
                column: "CreatedByLoginUserId",
                principalTable: "LoginUser",
                principalColumn: "LoginUserId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Priority_LoginUser_DeletedByLoginUserId",
                table: "Priority",
                column: "DeletedByLoginUserId",
                principalTable: "LoginUser",
                principalColumn: "LoginUserId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Priority_LoginUser_ModifiedByLoginUserId",
                table: "Priority",
                column: "ModifiedByLoginUserId",
                principalTable: "LoginUser",
                principalColumn: "LoginUserId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Priority_LoginUser_CreatedByLoginUserId",
                table: "Priority"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Priority_LoginUser_DeletedByLoginUserId",
                table: "Priority"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Priority_LoginUser_ModifiedByLoginUserId",
                table: "Priority"
            );

            migrationBuilder.DropIndex(name: "IX_Priority_CreatedByLoginUserId", table: "Priority");

            migrationBuilder.DropIndex(name: "IX_Priority_DeletedByLoginUserId", table: "Priority");

            migrationBuilder.DropIndex(
                name: "IX_Priority_ModifiedByLoginUserId",
                table: "Priority"
            );

            migrationBuilder.DropColumn(name: "ColorHexCode", table: "Priority");

            migrationBuilder.DropColumn(name: "CreatedByLoginUserId", table: "Priority");

            migrationBuilder.DropColumn(name: "DateCreated", table: "Priority");

            migrationBuilder.DropColumn(name: "DateDeleted", table: "Priority");

            migrationBuilder.DropColumn(name: "DateModified", table: "Priority");

            migrationBuilder.DropColumn(name: "DeletedByLoginUserId", table: "Priority");

            migrationBuilder.DropColumn(name: "IsActive", table: "Priority");

            migrationBuilder.DropColumn(name: "IsDefault", table: "Priority");

            migrationBuilder.DropColumn(name: "ModifiedByLoginUserId", table: "Priority");

            migrationBuilder.DropColumn(name: "PriorityName", table: "Priority");

            migrationBuilder.DropColumn(name: "SortOrder", table: "Priority");
        }
    }
}
