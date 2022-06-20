using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JueriShop.Migrations
{
    public partial class MigIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.AddColumn<int>(
                name: "TempId1",
                table: "userOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_userOrders_TempId1",
                table: "userOrders",
                column: "TempId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_userOrders_TempId1",
                table: "userOrders");

            migrationBuilder.DropColumn(
                name: "TempId1",
                table: "userOrders");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserOrderIdUOrder = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_users_UserOrderIdUOrder",
                table: "users",
                column: "UserOrderIdUOrder");
        }
    }
}
