using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackerAPI.Migrations
{
    public partial class UpdateApparelTablewithimagedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Apparels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Filename",
                table: "Apparels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Apparels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Apparels");

            migrationBuilder.DropColumn(
                name: "Filename",
                table: "Apparels");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Apparels");
        }
    }
}
