using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class MaxLengthUpdateLoginUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "LoginUser",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "LoginUser",
                type: "varbinary(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "LoginUser",
                type: "varbinary(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "LoginUser",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "LoginUser",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "LoginUser",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
