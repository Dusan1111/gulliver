using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class QuestionTypeIntroducedToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CollectedAnswers_AnswerId",
                table: "CollectedAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectedAnswers_QuestionId",
                table: "CollectedAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectedAnswers_Answers_AnswerId",
                table: "CollectedAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectedAnswers_Questions_QuestionId",
                table: "CollectedAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectedAnswers_Answers_AnswerId",
                table: "CollectedAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectedAnswers_Questions_QuestionId",
                table: "CollectedAnswers");

            migrationBuilder.DropIndex(
                name: "IX_CollectedAnswers_AnswerId",
                table: "CollectedAnswers");

            migrationBuilder.DropIndex(
                name: "IX_CollectedAnswers_QuestionId",
                table: "CollectedAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Questions");
        }
    }
}
