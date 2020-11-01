using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Domain.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40fbdcdd-9af7-4faa-8986-398b75841a90"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ed63e18a-1f8c-42c5-bc45-1b67cfc2e0fd"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("463619b6-8302-4415-bec5-42f8ebebad82"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m },
                    { new Guid("ab14c219-46b5-45f0-a396-8c56808261e4"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m },
                    { new Guid("f37ac86c-18f6-4d06-9904-787e1120a98a"), "Phones & Tablets", "Latest tchno andriod phone", "Techo Hot 8 lite", 38000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("675a2bc2-9ee4-413f-9eb2-71cfcf65d0ed"), "admin@yahoo.com", "111111", "Admin", "admin" },
                    { new Guid("0ec74a29-bd98-4e1a-a70b-1fafb9900cf5"), "user@gmail.com", "222222", "User", "user" },
                    { new Guid("1cb0962e-9d7b-4a71-9533-24ce9929c608"), "stephen@hotmail.com", "333333", "User", "stephen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("463619b6-8302-4415-bec5-42f8ebebad82"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ab14c219-46b5-45f0-a396-8c56808261e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f37ac86c-18f6-4d06-9904-787e1120a98a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0ec74a29-bd98-4e1a-a70b-1fafb9900cf5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1cb0962e-9d7b-4a71-9533-24ce9929c608"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("675a2bc2-9ee4-413f-9eb2-71cfcf65d0ed"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { new Guid("40fbdcdd-9af7-4faa-8986-398b75841a90"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[] { new Guid("ed63e18a-1f8c-42c5-bc45-1b67cfc2e0fd"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m });
        }
    }
}
