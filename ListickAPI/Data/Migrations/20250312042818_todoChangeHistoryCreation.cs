using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class todoChangeHistoryCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoChangeHistory",
                columns: table => new
                {
                    ToDoChangeHistoryId = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoId = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<string>(
                        type: "nvarchar(16)",
                        maxLength: 16,
                        nullable: false
                    ),
                    ColumnName = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    OriginalValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByLoginUserId = table.Column<int>(type: "int", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoChangeHistory", x => x.ToDoChangeHistoryId);
                    table.ForeignKey(
                        name: "FK_ToDoChangeHistory_LoginUser_ModifiedByLoginUserId",
                        column: x => x.ModifiedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ToDoChangeHistory_ToDo_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDo",
                        principalColumn: "ToDoId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ToDoChangeHistory");
        }
    }
}
