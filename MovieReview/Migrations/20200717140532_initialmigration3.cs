using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.Migrations
{
    public partial class initialmigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Movies_movieId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_movieId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "movieId",
                table: "Languages");

            migrationBuilder.AddColumn<int>(
                name: "languagesId",
                table: "Movies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_languagesId",
                table: "Movies",
                column: "languagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Languages_languagesId",
                table: "Movies",
                column: "languagesId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Languages_languagesId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_languagesId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "languagesId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "movieId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_movieId",
                table: "Languages",
                column: "movieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Movies_movieId",
                table: "Languages",
                column: "movieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
