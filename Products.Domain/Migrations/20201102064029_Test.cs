using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Domain.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_ApplicationUserId",
                table: "RefreshTokens");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "RefreshTokens",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("951ea4b8-4770-4f15-a063-b8efa1a90a19"), "Phones & Tablets", "Lastest Iphone 11 Pro, Now available for sale", "Iphone 11 Pro", 369000m },
                    { new Guid("59c49ad1-7aa9-4aad-a74c-395a56c3178c"), "Phones & Tablets", "New Umidigi Smartphone, very affordable", "Umidigi A5 Pro", 49000m },
                    { new Guid("c78555d2-b597-4645-93f4-2004e417d051"), "Phones & Tablets", "Latest tchno andriod phone", "Techo Hot 8 lite", 38000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("e2855d89-8ca3-4728-a712-c0c16cee6bd2"), "admin@yahoo.com", "111111", "Admin", "admin" },
                    { new Guid("38d02f16-345b-40be-83e2-abd63de13f52"), "user@gmail.com", "222222", "User", "user" },
                    { new Guid("1dc9ee61-24f4-46d1-97e8-fe6e230a6af4"), "stephen@hotmail.com", "333333", "User", "stephen" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_ApplicationUserId",
                table: "RefreshTokens",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_ApplicationUserId",
                table: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59c49ad1-7aa9-4aad-a74c-395a56c3178c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("951ea4b8-4770-4f15-a063-b8efa1a90a19"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c78555d2-b597-4645-93f4-2004e417d051"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1dc9ee61-24f4-46d1-97e8-fe6e230a6af4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38d02f16-345b-40be-83e2-abd63de13f52"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e2855d89-8ca3-4728-a712-c0c16cee6bd2"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "RefreshTokens",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "RefreshTokens",
                type: "bit",
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

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_ApplicationUserId",
                table: "RefreshTokens",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
