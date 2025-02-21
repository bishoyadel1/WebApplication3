using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domin.Migrations
{
    /// <inheritdoc />
    public partial class addimageurlToProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ae2d7ed-ae46-489b-a8e1-790be364c2ed", "AQAAAAIAAYagAAAAENbXrLPfTJ7L+BGYNWMJGOIQAc7UrPpMFIKd3z5swttFIi5GQPJjNGsoKweeWK1yog==", "f1a82914-34cf-45d0-9b51-b6068986d7d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef661642-fec0-49b1-a294-4619eef9582a", "AQAAAAIAAYagAAAAEGqjR4rex7f6szx8LqDnvNSIy9hQXM9BJwylVgtSUluMXDlZiwtYhxnQiWr6JL8iNw==", "27af1646-bac8-492b-a9ff-d04bf145cb4a" });
        }
    }
}
