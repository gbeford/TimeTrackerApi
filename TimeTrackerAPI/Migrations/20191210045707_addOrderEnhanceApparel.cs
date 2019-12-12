using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TimeTrackerAPI.Migrations
{
    public partial class addOrderEnhanceApparel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<bool>(
                name: "ShowGenderSize",
                table: "Apparels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowItem",
                table: "Apparels",
                nullable: false,
                defaultValue: false);


            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    StudentId = table.Column<int>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    CanHaveName = table.Column<bool>(nullable: false),
                    NameOnSleeve = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    UpCharge = table.Column<decimal>(nullable: true),
                    NameCharge = table.Column<decimal>(nullable: true),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    ToTalAmountDue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropColumn(
                name: "ShowGenderSize",
                table: "Apparels");

            migrationBuilder.DropColumn(
                name: "ShowItem",
                table: "Apparels");


        }
    }
}
