using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackerAPI.Migrations
{
    public partial class AddStudentTimesCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentTimes_StudentId",
                table: "StudentTimes",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTimes_Students_StudentId",
                table: "StudentTimes",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTimes_Students_StudentId",
                table: "StudentTimes");

            migrationBuilder.DropIndex(
                name: "IX_StudentTimes_StudentId",
                table: "StudentTimes");
        }
    }
}
