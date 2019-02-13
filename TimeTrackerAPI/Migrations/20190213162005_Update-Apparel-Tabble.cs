using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackerAPI.Migrations
{
    public partial class UpdateApparelTabble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Apparels");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Apparels",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<float>(
                name: "NameCharge",
                table: "Apparels",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "UpCharge",
                table: "Apparels",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameCharge",
                table: "Apparels");

            migrationBuilder.DropColumn(
                name: "UpCharge",
                table: "Apparels");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Apparels",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Apparels",
                nullable: true);
        }
    }
}
