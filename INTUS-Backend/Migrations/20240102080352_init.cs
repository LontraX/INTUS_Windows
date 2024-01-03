using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTUS_Backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    WindowId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    QuantityOfWindows = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalSubElements = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.WindowId);
                    table.ForeignKey(
                        name: "FK_Windows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "SubElements",
                columns: table => new
                {
                    SubElementId = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    WindowId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubElements", x => x.SubElementId);
                    table.ForeignKey(
                        name: "FK_SubElements_Windows_WindowId",
                        column: x => x.WindowId,
                        principalTable: "Windows",
                        principalColumn: "WindowId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubElements_WindowId",
                table: "SubElements",
                column: "WindowId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_OrderId",
                table: "Windows",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubElements");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
