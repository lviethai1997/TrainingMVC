using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Training.Data.Migrations
{
    public partial class EditDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustommerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PriceProduct",
                table: "Carts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 447, DateTimeKind.Local).AddTicks(5614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 61, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 447, DateTimeKind.Local).AddTicks(5375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 61, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 444, DateTimeKind.Local).AddTicks(9411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 58, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 444, DateTimeKind.Local).AddTicks(9148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 58, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 442, DateTimeKind.Local).AddTicks(7301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 56, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 440, DateTimeKind.Local).AddTicks(9781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 54, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 440, DateTimeKind.Local).AddTicks(9509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 54, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 439, DateTimeKind.Local).AddTicks(6163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 53, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 439, DateTimeKind.Local).AddTicks(5911),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 53, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 434, DateTimeKind.Local).AddTicks(256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 48, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.AddColumn<decimal>(
                name: "PriceSaleProduct",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Sale",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 432, DateTimeKind.Local).AddTicks(8217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 46, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 427, DateTimeKind.Local).AddTicks(309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 41, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 421, DateTimeKind.Local).AddTicks(2992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 35, DateTimeKind.Local).AddTicks(7604));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceSaleProduct",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Sale",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 61, DateTimeKind.Local).AddTicks(4004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 447, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 61, DateTimeKind.Local).AddTicks(3754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 447, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 58, DateTimeKind.Local).AddTicks(6906),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 444, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 58, DateTimeKind.Local).AddTicks(6630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 444, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 56, DateTimeKind.Local).AddTicks(5190),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 442, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 54, DateTimeKind.Local).AddTicks(8010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 440, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 54, DateTimeKind.Local).AddTicks(7703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 440, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 53, DateTimeKind.Local).AddTicks(4642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 439, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 53, DateTimeKind.Local).AddTicks(4397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 439, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 48, DateTimeKind.Local).AddTicks(405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 434, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.AddColumn<int>(
                name: "CustommerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 46, DateTimeKind.Local).AddTicks(8830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 432, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 41, DateTimeKind.Local).AddTicks(1541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 427, DateTimeKind.Local).AddTicks(309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 35, DateTimeKind.Local).AddTicks(7604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 421, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.AddColumn<decimal>(
                name: "PriceProduct",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
