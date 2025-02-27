using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class StatusTableAndInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusNameKey = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    StatusDescription = table.Column<string>(
                        type: "nvarchar(512)",
                        maxLength: 512,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                }
            );
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "StatusNameKey", "StatusDescription" },
                values: new object[,]
                {
                    { 1, "NK_TODO", "ToDo" },
                    { 2, "NK_INPROGRESS", "In Progress" },
                    { 3, "NK_DONE", "Done" },
                    { 4, "NK_LATER", "Later" },
                    { 5, "NK_SOON", "Soon" },
                    { 6, "NK_HALFWAY", "Halfway done" },
                    { 7, "NK_CANCELLED", "Cancelled" },
                    { 8, "NK_ONHOLD", "On Hold" },
                    { 9, "NK_REJECTED", "Rejected" },
                    { 10, "NK_APPROVED", "Approved" },
                    { 11, "NK_COMPLETED", "Completed" },
                    { 12, "NK_NOTCOMPLETED", "Not Completed" },
                    { 13, "NK_NOTSTARTED", "Not Started" },
                    { 14, "NK_INCOMPLETE", "Incomplete" },
                    { 15, "NK_COMPLETE", "Complete" },
                    { 17, "NK_PENDING", "Pending" },
                    { 18, "NK_APPROVALPENDING", "Approval Pending" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Status");
        }
    }
}
