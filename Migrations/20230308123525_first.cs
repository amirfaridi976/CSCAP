using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCAP.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServerId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Server",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server", x => x.ServerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ServerId",
                table: "User",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Server_ServerId",
                table: "User",
                column: "ServerId",
                principalTable: "Server",
                principalColumn: "ServerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Server_ServerId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Server");

            migrationBuilder.DropIndex(
                name: "IX_User_ServerId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "User");
        }
    }
}
