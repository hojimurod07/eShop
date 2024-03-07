using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    /// <inheritdoc />
    public partial class UChinchiMarta1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "FullName", "Password", "Phone", "Role" },
                values: new object[] { 11111111, "Database", "Super Admin", "f0a1f305f7f9a57d52a0710420881c0bb2786aff36b0507bb5bca18cea54c3fa", "+998908624707", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11111111);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "FullName", "Password", "Phone", "Role" },
                values: new object[] { 1, "Fergana", "Super User", "Super.Admin", "+998908624707", 1 });
        }
    }
}
