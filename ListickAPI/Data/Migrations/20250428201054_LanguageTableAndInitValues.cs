using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class LanguageTableAndInitValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "LoginUser",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: true
                    ),
                    LanguageCode = table.Column<string>(
                        type: "nvarchar(10)",
                        maxLength: 10,
                        nullable: true
                    ),
                    DateFormat = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: true
                    ),
                    TimeFormat = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: true
                    ),
                    FlagIconUrl = table.Column<string>(
                        type: "nvarchar(150)",
                        maxLength: 150,
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_LoginUser_LanguageId",
                table: "LoginUser",
                column: "LanguageId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_LoginUser_Language_LanguageId",
                table: "LoginUser",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.NoAction
            );

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[]
                {
                    "LanguageId",
                    "DateFormat",
                    "FlagIconUrl",
                    "LanguageCode",
                    "LanguageName",
                    "TimeFormat",
                },
                values: new object[,]
                {
                    { 1, "MM/dd/yyyy", null, "en-US", "English (United States)", "hh:mm tt" },
                    { 2, "dd/MM/yyyy", null, "en-GB", "English (United Kingdom)", "HH:mm" },
                    { 3, "dd/MM/yyyy", null, "de-DE", "German (Germany)", "HH:mm" },
                    { 4, "dd/MM/yyyy", null, "nl-NL", "Italian (Italy)", "HH:mm" },
                    { 5, "dd/MM/yyyy", null, "cs-CZ", "Portuguese (Brazil)", "HH:mm" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginUser_Language_LanguageId",
                table: "LoginUser"
            );

            migrationBuilder.DropTable(name: "Language");

            migrationBuilder.DropIndex(name: "IX_LoginUser_LanguageId", table: "LoginUser");

            migrationBuilder.DropColumn(name: "LanguageId", table: "LoginUser");
        }
    }
}
