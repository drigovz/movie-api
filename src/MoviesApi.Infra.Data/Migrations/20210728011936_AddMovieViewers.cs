using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApi.Infra.Data.Migrations
{
    public partial class AddMovieViewers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieViewer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    ViewerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieViewer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieViewer_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieViewer_Viewer_ViewerId",
                        column: x => x.ViewerId,
                        principalTable: "Viewer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieViewer_MovieId",
                table: "MovieViewer",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieViewer_ViewerId",
                table: "MovieViewer",
                column: "ViewerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieViewer");
        }
    }
}
