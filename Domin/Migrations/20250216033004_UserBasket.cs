using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domin.Migrations
{
    /// <inheritdoc />
    public partial class UserBasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBaskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBaskets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBaskets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6513eb36-52ab-4b61-acc9-0758d87856f1", "AQAAAAIAAYagAAAAEFiZctVZDfNA23vNwD4FdfDaxEb4xxdGU586hCqTOrazA9Oolhmy444zT/3uKKju6g==", "5bcdf890-21d1-4396-946a-9fa12bd55ee4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a60495ef-2f7f-4601-b1d2-08e9c49a917d", "AQAAAAIAAYagAAAAEBLHYZdaOyBW3mObnACVMYer1MOQ9LAkSo8bVmC8f3vG85KN2XpzA3feKbkgRFo71w==", "fc5bcea1-d9e4-491e-9a6c-1d5021125405" });

            migrationBuilder.CreateIndex(
                name: "IX_UserBaskets_ProductId",
                table: "UserBaskets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBaskets_UserId",
                table: "UserBaskets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBaskets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6708ee07-6043-47ea-8850-4435b6f045f8", "AQAAAAIAAYagAAAAEI8FnjofD3fDz9HXZHWOg43KR0J2j4THPCwA096YDWlZ3REmdWSfDz9JkPthCDvBMg==", "ae6acd91-0744-46b0-a8e2-1cbb3393ca31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a080f0d7-34a7-44f5-bf90-8b042fa061cc", "AQAAAAIAAYagAAAAEFxD0puZaWH1YvWISBteXBBFaDsZq+5UmvjUiCBq0nJQhWeVoSWfSDsDuQ2wV/VC/w==", "17b84512-252e-4c49-8a40-c822401d4317" });
        }
    }
}
