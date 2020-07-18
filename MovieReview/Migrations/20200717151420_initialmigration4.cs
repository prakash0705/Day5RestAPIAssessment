using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.Migrations
{
    public partial class initialmigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "languageId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_languageId",
                table: "Movies",
                column: "languageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Languages_languageId",
                table: "Movies",
                column: "languageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Languages_languageId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_languageId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "languageId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "languagesId",
                table: "Movies",
                type: "int",
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
    }
}
