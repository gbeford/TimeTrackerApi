using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackerAPI.Migrations
{
    public partial class Add_show_size : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShowGenderSize",
                table: "Apparels",
                newName: "ShowSize");

            migrationBuilder.AddColumn<bool>(
                name: "ShowGender",
                table: "Apparels",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowGender",
                table: "Apparels");

            migrationBuilder.RenameColumn(
                name: "ShowSize",
                table: "Apparels",
                newName: "ShowGenderSize");
        }
    }
}
