using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ToDoRecurranceAndToDoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ToDo_Cadence_CadenceId", table: "ToDo");

            migrationBuilder.DropTable(name: "ToDoWeekDays");

            migrationBuilder.RenameColumn(
                name: "CadenceId",
                table: "ToDo",
                newName: "ToDoRecurranceId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_CadenceId",
                table: "ToDo",
                newName: "IX_ToDo_ToDoRecurranceId"
            );

            migrationBuilder.CreateTable(
                name: "ToDoRecurrance",
                columns: table => new
                {
                    ToDoRecurranceId = table
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
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    ColorHexCode = table.Column<string>(
                        type: "nvarchar(64)",
                        maxLength: 64,
                        nullable: true
                    ),
                    RecurringNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CadenceId = table.Column<int>(type: "int", nullable: false),
                    CreatedByLoginUserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByLoginUserId = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedByLoginUserId = table.Column<int>(type: "int", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoRecurrance", x => x.ToDoRecurranceId);
                    table.ForeignKey(
                        name: "FK_ToDoRecurrance_Cadence_CadenceId",
                        column: x => x.CadenceId,
                        principalTable: "Cadence",
                        principalColumn: "CadenceId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ToDoRecurrance_LoginUser_CreatedByLoginUserId",
                        column: x => x.CreatedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ToDoRecurrance_LoginUser_DeletedByLoginUserId",
                        column: x => x.DeletedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDoRecurrance_LoginUser_ModifiedByLoginUserId",
                        column: x => x.ModifiedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDoRecurrance_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "PriorityId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDoRecurrance_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId"
                    );
                    table.ForeignKey(
                        name: "FK_ToDoRecurrance_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ToDoRecurranceWeekDays",
                columns: table => new
                {
                    ToDoRecurranceId = table.Column<int>(type: "int", nullable: false),
                    WeekDayId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_ToDoRecurranceWeekDays",
                        x => new { x.ToDoRecurranceId, x.WeekDayId }
                    );
                    table.ForeignKey(
                        name: "FK_ToDoRecurranceWeekDays_ToDoRecurrance_ToDoRecurranceId",
                        column: x => x.ToDoRecurranceId,
                        principalTable: "ToDoRecurrance",
                        principalColumn: "ToDoRecurranceId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ToDoRecurranceWeekDays_WeekDays_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDays",
                        principalColumn: "WeekDayId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDoRecurrance_CadenceId",
                table: "ToDoRecurrance",
                column: "CadenceId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDoRecurrance_CreatedByLoginUserId",
                table: "ToDoRecurrance",
                column: "CreatedByLoginUserId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDoRecurrance_PriorityId",
                table: "ToDoRecurrance",
                column: "PriorityId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDoRecurrance_ProjectId",
                table: "ToDoRecurrance",
                column: "ProjectId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDoRecurrance_StatusId",
                table: "ToDoRecurrance",
                column: "StatusId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDoRecurranceWeekDays_WeekDayId",
                table: "ToDoRecurranceWeekDays",
                column: "WeekDayId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_ToDoRecurrance_ToDoRecurranceId",
                table: "ToDo",
                column: "ToDoRecurranceId",
                principalTable: "ToDoRecurrance",
                principalColumn: "ToDoRecurranceId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_ToDoRecurrance_ToDoRecurranceId",
                table: "ToDo"
            );

            migrationBuilder.DropTable(name: "ToDoRecurranceWeekDays");

            migrationBuilder.DropTable(name: "ToDoRecurrance");

            migrationBuilder.RenameColumn(
                name: "ToDoRecurranceId",
                table: "ToDo",
                newName: "CadenceId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_ToDoRecurranceId",
                table: "ToDo",
                newName: "IX_ToDo_CadenceId"
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
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ToDoWeekDays_WeekDays_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDays",
                        principalColumn: "WeekDayId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ToDoWeekDays_WeekDayId",
                table: "ToDoWeekDays",
                column: "WeekDayId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Cadence_CadenceId",
                table: "ToDo",
                column: "CadenceId",
                principalTable: "Cadence",
                principalColumn: "CadenceId"
            );
        }
    }
}
