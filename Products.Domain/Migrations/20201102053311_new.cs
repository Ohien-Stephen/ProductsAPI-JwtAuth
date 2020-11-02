using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Domain.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_ApplicationUserId",
                table: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3f1c7809-8b71-43d9-95ca-7edfcb0b6067"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("750141e9-e0a7-4e0a-8334-6f11823edb04"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb64b796-f71b-4d9c-a604-6006ed867ad7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5547e98e-dac7-49af-a82e-112b1941beb1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90553351-867b-4a10-9301-48eb3a7d3db3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eb1a5f70-8bc7-409b-a641-ab1f383014aa"));

            migrationBuilder.DropColumn(
                name: "Expiry",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "RefreshTokens",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expires",
                table: "RefreshTokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("d36a202c-a440-4632-b967-df1c69308240"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m },
                    { new Guid("c6a2270d-1e92-48d0-9b23-a82b81c5a249"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m },
                    { new Guid("52b45712-f3b4-4095-abf8-7d50b2dc8f81"), "Phones & Tablets", "Latest tchno andriod phone", "Techo Hot 8 lite", 38000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("a5308b51-5900-48d0-a8c3-bd278d58659d"), "admin@yahoo.com", "111111", "Admin", "admin" },
                    { new Guid("22bd1b08-5b42-4d11-ab16-48520922dc4b"), "user@gmail.com", "222222", "User", "user" },
                    { new Guid("8382e91b-f11d-4653-a96a-3739618a3f6a"), "stephen@hotmail.com", "333333", "User", "stephen" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_ApplicationUserId",
                table: "RefreshTokens",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_ApplicationUserId",
                table: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("52b45712-f3b4-4095-abf8-7d50b2dc8f81"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6a2270d-1e92-48d0-9b23-a82b81c5a249"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d36a202c-a440-4632-b967-df1c69308240"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22bd1b08-5b42-4d11-ab16-48520922dc4b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8382e91b-f11d-4653-a96a-3739618a3f6a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a5308b51-5900-48d0-a8c3-bd278d58659d"));

            migrationBuilder.DropColumn(
                name: "Expires",
                table: "RefreshTokens");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Expiry",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("cb64b796-f71b-4d9c-a604-6006ed867ad7"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m },
                    { new Guid("750141e9-e0a7-4e0a-8334-6f11823edb04"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m },
                    { new Guid("3f1c7809-8b71-43d9-95ca-7edfcb0b6067"), "Phones & Tablets", "Latest tchno andriod phone", "Techo Hot 8 lite", 38000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("5547e98e-dac7-49af-a82e-112b1941beb1"), "admin@yahoo.com", "111111", "Admin", "admin" },
                    { new Guid("90553351-867b-4a10-9301-48eb3a7d3db3"), "user@gmail.com", "222222", "User", "user" },
                    { new Guid("eb1a5f70-8bc7-409b-a641-ab1f383014aa"), "stephen@hotmail.com", "333333", "User", "stephen" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_ApplicationUserId",
                table: "RefreshTokens",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
