using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LitExplore.Repository.Migrations
{
    public partial class RelationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_PaperPaper_CitingsId",
                table: "PaperPaper",
                column: "CitingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaperPaper");
        }
    }
}
