using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNameToLoginUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LoginUser",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "LoginUser");
        }
    }
}
