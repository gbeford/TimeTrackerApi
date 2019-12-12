using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TimeTrackerAPI.Migrations
{
    public partial class Add_Order_OrderItem_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanHaveName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NameCharge",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NameOnSleeve",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpCharge",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ToTalAmountDue",
                table: "Orders",
                newName: "ItemsTotaltal");

            migrationBuilder.RenameColumn(
                name: "OrderTotal",
                table: "Orders",
                newName: "GrossTotal");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApparelId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    UpCharge = table.Column<decimal>(nullable: true),
                    NameCharge = table.Column<decimal>(nullable: true),
                    NameOnSleeve = table.Column<bool>(nullable: true),
                    SleeveName = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "ItemsTotaltal",
                table: "Orders",
                newName: "ToTalAmountDue");

            migrationBuilder.RenameColumn(
                name: "GrossTotal",
                table: "Orders",
                newName: "OrderTotal");

            migrationBuilder.AlterColumn<int>(
                name: "StudentTimeID",
                table: "StudentTimes",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<bool>(
                name: "CanHaveName",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NameCharge",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOnSleeve",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Orders",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UpCharge",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MessageID",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ApparelId",
                table: "Apparels",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ApparelImageId",
                table: "ApparelImages",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
