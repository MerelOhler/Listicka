using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToDo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    ToDoId = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoName = table.Column<string>(
                        type: "nvarchar(100)",
                        maxLength: 100,
                        nullable: false
                    ),
                    Description = table.Column<string>(
                        type: "nvarchar(512)",
                        maxLength: 512,
                        nullable: true
                    ),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeNeeded = table.Column<short>(type: "smallint", nullable: true),
                    CadenceId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    ColorHexCode = table.Column<string>(
                        type: "nvarchar(64)",
                        maxLength: 64,
                        nullable: true
                    ),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentComplete = table.Column<short>(type: "smallint", nullable: true),
                    CreatedByLoginUserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByLoginUserId = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedByLoginUserId = table.Column<int>(type: "int", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.ToDoId);
                    table.ForeignKey(
                        name: "FK_ToDo_Cadence_CadenceId",
                        column: x => x.CadenceId,
                        principalTable: "Cadence",
                        principalColumn: "CadenceId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDo_LoginUser_CreatedByLoginUserId",
                        column: x => x.CreatedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId",
                        onDelete: ReferentialAction.NoAction
                    );
                    table.ForeignKey(
                        name: "FK_ToDo_LoginUser_DeletedByLoginUserId",
                        column: x => x.DeletedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDo_LoginUser_ModifiedByLoginUserId",
                        column: x => x.ModifiedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDo_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "PriorityId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDo_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDo_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ToDoWeekDays",
                columns: table => new
                {
                    ToDoId = table.Column<int>(type: "int", nullable: false),
                    WeekDayId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoWeekDays", x => new { x.ToDoId, x.WeekDayId });
                    table.ForeignKey(
                        name: "FK_ToDoWeekDays_ToDo_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDo",
                        principalColumn: "ToDoId",
                        onDelete: ReferentialAction.NoAction
                    );
                    table.ForeignKey(
                        name: "FK_ToDoWeekDays_WeekDays_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDays",
                        principalColumn: "WeekDayId",
                        onDelete: ReferentialAction.NoAction
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_CadenceId",
                table: "ToDo",
                column: "CadenceId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_CreatedByLoginUserId",
                table: "ToDo",
                column: "CreatedByLoginUserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_PriorityId",
                table: "ToDo",
                column: "PriorityId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ProjectId",
                table: "ToDo",
                column: "ProjectId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_StatusId",
                table: "ToDo",
                column: "StatusId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDoWeekDays_WeekDayId",
                table: "ToDoWeekDays",
                column: "WeekDayId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ToDoWeekDays");

            migrationBuilder.DropTable(name: "ToDo");
        }
    }
}
