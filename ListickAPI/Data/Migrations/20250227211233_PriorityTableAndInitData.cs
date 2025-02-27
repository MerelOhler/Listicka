using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class PriorityTableAndInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    PriorityId = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorityNameKey = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    PriorityDescription = table.Column<string>(
                        type: "nvarchar(512)",
                        maxLength: 512,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.PriorityId);
                }
            );
            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "PriorityId", "PriorityNameKey", "PriorityDescription" },
                values: new object[,]
                {
                    { 1, "NK_CAN_SKIP", "Can be skipped." },
                    { 2, "NK_SHOULD_HAPPEN", "Should happen." },
                    {
                        3,
                        "NK_GO_OVER",
                        "Should be done before deadline but can go over by some days.",
                    },
                    {
                        4,
                        "NK_DONE_BEFORE_NEXT_CADENCE",
                        "Has to absolutely be done before the next cadence deadline.",
                    },
                    { 5, "NK_DONE_BY_DEADLINE", "Has to absolutely be done by deadline." },
                    { 6, "NK_MUST_HAPPEN", "Must happen." },
                    { 7, "NK_NO_DEADLINE", "No deadline." },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Priority");
        }
    }
}
