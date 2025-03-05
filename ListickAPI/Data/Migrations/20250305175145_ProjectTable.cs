using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListickAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(
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
                    CadenceId = table.Column<int>(type: "int", nullable: true),
                    CreatedByLoginUserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByLoginUserId = table.Column<int>(type: "int", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedByLoginUserId = table.Column<int>(type: "int", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Cadence_CadenceId",
                        column: x => x.CadenceId,
                        principalTable: "Cadence",
                        principalColumn: "CadenceId"
                    );
                    table.ForeignKey(
                        name: "FK_Project_LoginUser_CreatedByLoginUserId",
                        column: x => x.CreatedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_Project_LoginUser_DeletedByLoginUserId",
                        column: x => x.DeletedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId"
                    );
                    table.ForeignKey(
                        name: "FK_Project_LoginUser_ModifiedByLoginUserId",
                        column: x => x.ModifiedByLoginUserId,
                        principalTable: "LoginUser",
                        principalColumn: "LoginUserId"
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Project_CadenceId",
                table: "Project",
                column: "CadenceId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedByLoginUserId",
                table: "Project",
                column: "CreatedByLoginUserId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Project");
        }
    }
}
