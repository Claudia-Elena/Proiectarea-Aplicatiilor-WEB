using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JueriShop.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    IdOrdIt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJewelry = table.Column<int>(type: "int", nullable: false),
                    UserOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.IdOrdIt);
                });

            migrationBuilder.CreateTable(
                name: "jewels",
                columns: table => new
                {
                    IdJewel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OrderItemIdOrdIt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jewels", x => x.IdJewel);
                    table.ForeignKey(
                        name: "FK_jewels_orderItems_OrderItemIdOrdIt",
                        column: x => x.OrderItemIdOrdIt,
                        principalTable: "orderItems",
                        principalColumn: "IdOrdIt");
                });

            migrationBuilder.CreateTable(
                name: "userOrders",
                columns: table => new
                {
                    IdUOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeliverAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OrderItemIdOrdIt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userOrders", x => x.IdUOrder);
                    table.ForeignKey(
                        name: "FK_userOrders_orderItems_OrderItemIdOrdIt",
                        column: x => x.OrderItemIdOrdIt,
                        principalTable: "orderItems",
                        principalColumn: "IdOrdIt");
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    IdCateg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JewelryIdOrdIt = table.Column<int>(type: "int", nullable: true),
                    JewelryIdJewel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.IdCateg);
                    table.ForeignKey(
                        name: "FK_categories_jewels_JewelryIdJewel",
                        column: x => x.JewelryIdJewel,
                        principalTable: "jewels",
                        principalColumn: "IdJewel");
                    table.ForeignKey(
                        name: "FK_categories_orderItems_JewelryIdOrdIt",
                        column: x => x.JewelryIdOrdIt,
                        principalTable: "orderItems",
                        principalColumn: "IdOrdIt");
                });

            migrationBuilder.CreateTable(
                name: "orderStatuses",
                columns: table => new
                {
                    IdOrdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserOrderIdUOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderStatuses", x => x.IdOrdStatus);
                    table.ForeignKey(
                        name: "FK_orderStatuses_userOrders_UserOrderIdUOrder",
                        column: x => x.UserOrderIdUOrder,
                        principalTable: "userOrders",
                        principalColumn: "IdUOrder");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserOrderIdUOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_users_userOrders_UserOrderIdUOrder",
                        column: x => x.UserOrderIdUOrder,
                        principalTable: "userOrders",
                        principalColumn: "IdUOrder");
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_JewelryIdJewel",
                table: "categories",
                column: "JewelryIdJewel");

            migrationBuilder.CreateIndex(
                name: "IX_categories_JewelryIdOrdIt",
                table: "categories",
                column: "JewelryIdOrdIt");

            migrationBuilder.CreateIndex(
                name: "IX_jewels_OrderItemIdOrdIt",
                table: "jewels",
                column: "OrderItemIdOrdIt");

            migrationBuilder.CreateIndex(
                name: "IX_orderStatuses_UserOrderIdUOrder",
                table: "orderStatuses",
                column: "UserOrderIdUOrder");

            migrationBuilder.CreateIndex(
                name: "IX_userOrders_OrderItemIdOrdIt",
                table: "userOrders",
                column: "OrderItemIdOrdIt");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserOrderIdUOrder",
                table: "users",
                column: "UserOrderIdUOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "orderStatuses");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "jewels");

            migrationBuilder.DropTable(
                name: "userOrders");

            migrationBuilder.DropTable(
                name: "orderItems");
        }
    }
}
