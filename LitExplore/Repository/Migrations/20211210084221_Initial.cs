using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LitExplore.Repository.Migrations
{
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
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
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
                    InternalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.InternalId);
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
                name: "PaperPaper",
                columns: table => new
                {
                    CitedById = table.Column<int>(type: "int", nullable: false),
                    CitingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperPaper", x => new { x.CitedById, x.CitingsId });
                    table.ForeignKey(
                        name: "FK_PaperPaper_Papers_CitedById",
                        column: x => x.CitedById,
                        principalTable: "Papers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaperPaper_Papers_CitingsId",
                        column: x => x.CitingsId,
                        principalTable: "Papers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerInternalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_OwnerInternalId",
                        column: x => x.OwnerInternalId,
                        principalTable: "Users",
                        principalColumn: "InternalId");
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
                    CollaboratorsInternalId = table.Column<int>(type: "int", nullable: false),
                    HasAccessToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.CollaboratorsInternalId, x.HasAccessToId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_HasAccessToId",
                        column: x => x.HasAccessToId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_CollaboratorsInternalId",
                        column: x => x.CollaboratorsInternalId,
                        principalTable: "Users",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPaper_PapersId",
                table: "AuthorPaper",
                column: "PapersId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperPaper_CitingsId",
                table: "PaperPaper",
                column: "CitingsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperProject_UsedInId",
                table: "PaperProject",
                column: "UsedInId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerInternalId",
                table: "Projects",
                column: "OwnerInternalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_HasAccessToId",
                table: "ProjectUser",
                column: "HasAccessToId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPaper");

            migrationBuilder.DropTable(
                name: "PaperPaper");

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
