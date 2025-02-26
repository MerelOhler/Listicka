using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCadenceLookupTableAndData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadence",
                columns: table => new
                {
                    CadenceId = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadenceNameKey = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    CadenceDescription = table.Column<string>(
                        type: "nvarchar(512)",
                        maxLength: 512,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadence", x => x.CadenceId);
                }
            );
            migrationBuilder.InsertData(
                table: "Cadence",
                columns: new[] { "CadenceId", "CadenceNameKey", "CadenceDescription" },
                values: new object[,]
                {
                    { 1, "NK_DAILY", "Daily" },
                    { 2, "NK_WEEKDAY", "Weekday" },
                    { 3, "NK_WEEKEND", "Weekend" },
                    { 4, "NK_WEEKLY", "Weekly" },
                    { 5, "NK_MONTHLY_DATE", "Monthly on the same date" },
                    { 6, "NK_MONTHLY_END", "Monthly on the last day" },
                    { 7, "NK_MONTHLY_WEEK", "Monthly on the weekday of the nth week" },
                    { 8, "NK_YEARLY_DATE", "Yearly on the same date" },
                    { 9, "NK_YEARLY_END", "Yearly on the last day" },
                    { 10, "NK_YEARLY_WEEK", "Yearly on the weekday of the nth week" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Cadence");
        }
    }
}
