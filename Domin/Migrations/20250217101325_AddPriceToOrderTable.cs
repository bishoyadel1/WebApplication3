using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domin.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc24368a-916e-4054-ba03-4898b1783505", "AQAAAAIAAYagAAAAEEv8KtjPaZc+OtFoi7V9RXT3wUf5Ygp4u9j8PX83g6cReXp/tB9LGjen3rqQuXGwjw==", "9ec8a080-0853-415a-a8aa-8aa750326b28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e3618af-6b05-4b2d-9852-7fc720cf09a8", "AQAAAAIAAYagAAAAEK37+mbQ6PItVEYyZi+nbqywA6EJb+9cH++mciv8hkv6/JU13Jg8jYzP7jb453usLg==", "c264c63b-98c5-454f-8665-f2df9b28e2de" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f229a08a-7197-41ff-8417-1164fee0e613", "AQAAAAIAAYagAAAAEB6z7MpCyCmV8iWrCXM0dckrJ/kX1muF4SO6JEU4A9vHJOYdC705dQ918wJtJKqfAQ==", "090ed8bd-ef23-4707-a8a6-8cda34ac93e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc2143f3-c54f-416a-a63d-e39f9b0639aa", "AQAAAAIAAYagAAAAEDj1dzASgmJO3mduz7qga6mY9nWiogRDDJFk5ISebFP0FX7u5JnscL9TEUef+ZW0xA==", "488694ef-7d08-472a-b36e-69225e10d1e7" });
        }
    }
}
