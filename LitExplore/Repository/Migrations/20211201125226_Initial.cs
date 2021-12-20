using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LitExplore.Repository.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GivenName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    URL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Abstract = table.Column<string>(type: "nvarchar(2200)", maxLength: 2200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPaper",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    PapersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPaper", x => new { x.AuthorsId, x.PapersId });
                    table.ForeignKey(
                        name: "FK_AuthorPaper_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPaper_Papers_PapersId",
                        column: x => x.PapersId,
                        principalTable: "Papers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaperProject",
                columns: table => new
                {
                    PapersId = table.Column<int>(type: "int", nullable: false),
                    UsedInId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperProject", x => new { x.PapersId, x.UsedInId });
                    table.ForeignKey(
                        name: "FK_PaperProject_Papers_PapersId",
                        column: x => x.PapersId,
                        principalTable: "Papers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaperProject_Projects_UsedInId",
                        column: x => x.UsedInId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    CollaboratorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasAccessToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.CollaboratorsId, x.HasAccessToId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_HasAccessToId",
                        column: x => x.HasAccessToId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_CollaboratorsId",
                        column: x => x.CollaboratorsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPaper_PapersId",
                table: "AuthorPaper",
                column: "PapersId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperProject_UsedInId",
                table: "PaperProject",
                column: "UsedInId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_HasAccessToId",
                table: "ProjectUser",
                column: "HasAccessToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPaper");

            migrationBuilder.DropTable(
                name: "PaperProject");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
