using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBlog.Server.Migrations
{
    /// <inheritdoc />
    public partial class Add_Image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "BlogPosts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2022, 11, 10, 14, 10, 44, 835, DateTimeKind.Local).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 57,
                column: "Created",
                value: new DateTime(2022, 12, 26, 7, 6, 24, 866, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 73,
                column: "Created",
                value: new DateTime(2022, 12, 26, 14, 21, 3, 200, DateTimeKind.Local).AddTicks(1413));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "BlogPosts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 24,
                column: "Created",
                value: new DateTime(2022, 11, 10, 13, 56, 25, 175, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 57,
                column: "Created",
                value: new DateTime(2022, 12, 26, 6, 52, 5, 206, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 73,
                column: "Created",
                value: new DateTime(2022, 12, 26, 14, 6, 43, 540, DateTimeKind.Local).AddTicks(1300));
        }
    }
}
