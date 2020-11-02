using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Domain.Migrations
{
    public partial class initialCreateTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a14e6ba5-1752-4df9-890e-fffdb6f158c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad83ba06-b2d8-4837-b68c-51ff40a267f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc815678-260b-4f16-8fc0-6e53854f3228"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a3571e0-be0d-4228-a214-c52bbbc2ae71"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0bea701-844b-432e-892b-c5cd575bb775"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d2fcc8c8-c47c-42f4-878c-952ca33e44fb"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RefreshTokens");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("fc815678-260b-4f16-8fc0-6e53854f3228"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m },
                    { new Guid("ad83ba06-b2d8-4837-b68c-51ff40a267f1"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m },
                    { new Guid("a14e6ba5-1752-4df9-890e-fffdb6f158c0"), "Phones & Tablets", "Latest tchno andriod phone", "Techo Hot 8 lite", 38000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("d2fcc8c8-c47c-42f4-878c-952ca33e44fb"), "admin@yahoo.com", "111111", "Admin", "admin" },
                    { new Guid("b0bea701-844b-432e-892b-c5cd575bb775"), "user@gmail.com", "222222", "User", "user" },
                    { new Guid("3a3571e0-be0d-4228-a214-c52bbbc2ae71"), "stephen@hotmail.com", "333333", "User", "stephen" }
                });
        }
    }
}
