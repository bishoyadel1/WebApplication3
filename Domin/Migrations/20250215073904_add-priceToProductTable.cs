using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domin.Migrations
{
    /// <inheritdoc />
    public partial class addpriceToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43bbdf78-0e69-403b-98d3-77e6bbc513e1", "AQAAAAIAAYagAAAAEARsY7lhns+Ep9rNbhqEjiLaifXqj0tkmzQ+vFAhBDDFjYA+ELltcmYiymI9uDWrvQ==", "e1fe843d-99ec-404d-9731-8a86497c560e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d23cfe7a-8909-47e0-92fe-00c6303419d6", "AQAAAAIAAYagAAAAELIObvFUFJLqw1KhJ5aE751Ild3v+Qy4K7zFs6ooFortaoPSFvsV5eb46rTLyOiAXQ==", "09da11fd-0bd3-4ab9-a709-88b2fc49b20d" });
        }
    }
}
