using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Domain.Migrations
{
    public partial class newIsExpired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "RefreshTokens",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("f90b6b88-ef9b-4988-99fe-cb922bf70678"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m },
                    { new Guid("7c6f2ee8-b6a1-4aa6-91d0-46e07e274151"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m },
                    { new Guid("bd917d4d-8ce9-49fd-9d7f-57d02f0f77f1"), "Phones & Tablets", "Latest tchno andriod phone", "Techo Hot 8 lite", 38000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("7d4e711b-5c58-4f02-ae06-b6651c540f41"), "admin@yahoo.com", "111111", "Admin", "admin" },
                    { new Guid("fc7c6066-67b4-481c-9460-40c3dbf976b4"), "user@gmail.com", "222222", "User", "user" },
                    { new Guid("6f53676b-b67c-4e36-838e-a4b0195544cd"), "stephen@hotmail.com", "333333", "User", "stephen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7c6f2ee8-b6a1-4aa6-91d0-46e07e274151"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bd917d4d-8ce9-49fd-9d7f-57d02f0f77f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f90b6b88-ef9b-4988-99fe-cb922bf70678"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f53676b-b67c-4e36-838e-a4b0195544cd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7d4e711b-5c58-4f02-ae06-b6651c540f41"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fc7c6066-67b4-481c-9460-40c3dbf976b4"));

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "RefreshTokens");

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
        }
    }
}
