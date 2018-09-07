using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackerAPI.Migrations
{
    public partial class AddSignInTimeToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SignInTime",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignInTime",
                table: "Students");
        }
    }
}
