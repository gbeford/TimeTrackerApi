using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackerAPI.Migrations
{
    public partial class checkForSmallSizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowXS",
                table: "Apparels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowYXL",
                table: "Apparels",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowXS",
                table: "Apparels");

            migrationBuilder.DropColumn(
                name: "ShowYXL",
                table: "Apparels");
        }
    }
}
