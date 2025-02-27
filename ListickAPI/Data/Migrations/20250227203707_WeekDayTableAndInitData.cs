using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class WeekDayTableAndInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    WeekDayId = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDayNameKey = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    WeekDayDescription = table.Column<string>(
                        type: "nvarchar(512)",
                        maxLength: 512,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.WeekDayId);
                }
            );
            migrationBuilder.InsertData(
                table: "WeekDays",
                columns: new[] { "WeekDayId", "WeekDayNameKey", "WeekDayDescription" },
                values: new object[,]
                {
                    { 1, "NK_MONDAY", "Monday" },
                    { 2, "NK_TUESDAY", "Tuesday" },
                    { 3, "NK_WEDNESDAY", "Wednesday" },
                    { 4, "NK_THURSDAY", "Thursday" },
                    { 5, "NK_FRIDAY", "Friday" },
                    { 6, "NK_SATURDAY", "Saturday" },
                    { 7, "NK_SUNDAY", "Sunday" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "WeekDays");
        }
    }
}
