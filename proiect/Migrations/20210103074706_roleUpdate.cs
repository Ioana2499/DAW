using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Playlist_Manager.Migrations
{
    public partial class roleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_SongEditors_SongEditorId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "SongEditors");

            migrationBuilder.RenameColumn(
                name: "SongEditorId",
                table: "Songs",
                newName: "PlaylistEditorId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_SongEditorId",
                table: "Songs",
                newName: "IX_Songs_PlaylistEditorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_PlaylistEditors_PlaylistEditorId",
                table: "Songs",
                column: "PlaylistEditorId",
                principalTable: "PlaylistEditors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_PlaylistEditors_PlaylistEditorId",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "PlaylistEditorId",
                table: "Songs",
                newName: "SongEditorId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_PlaylistEditorId",
                table: "Songs",
                newName: "IX_Songs_SongEditorId");

            migrationBuilder.CreateTable(
                name: "SongEditors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongEditors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongEditors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongEditors_UserId",
                table: "SongEditors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_SongEditors_SongEditorId",
                table: "Songs",
                column: "SongEditorId",
                principalTable: "SongEditors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
