using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeTrackerAPI.Migrations
{
    public partial class addSecurityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserType",
                schema: "Security",
                table: "UserType");

            migrationBuilder.RenameTable(
                name: "UserType",
                schema: "Security",
                newName: "UserClaim",
                newSchema: "Security");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaim",
                schema: "Security",
                table: "UserClaim",
                column: "ClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaim",
                schema: "Security",
                table: "UserClaim");

            migrationBuilder.RenameTable(
                name: "UserClaim",
                schema: "Security",
                newName: "UserType",
                newSchema: "Security");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserType",
                schema: "Security",
                table: "UserType",
                column: "ClaimId");
        }
    }
}
