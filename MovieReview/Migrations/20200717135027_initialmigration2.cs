using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.Migrations
{
    public partial class initialmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Reviews_reviewid",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_reviewid",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "reviewid",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "moviesId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_moviesId",
                table: "Reviews",
                column: "moviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Movies_moviesId",
                table: "Reviews",
                column: "moviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Movies_moviesId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_moviesId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "moviesId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "reviewid",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_reviewid",
                table: "Movies",
                column: "reviewid");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Reviews_reviewid",
                table: "Movies",
                column: "reviewid",
                principalTable: "Reviews",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
