using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Training.Data.Migrations
{
    public partial class AddColumnSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 61, DateTimeKind.Local).AddTicks(4004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 365, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 61, DateTimeKind.Local).AddTicks(3754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 365, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 58, DateTimeKind.Local).AddTicks(6906),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 363, DateTimeKind.Local).AddTicks(1525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 58, DateTimeKind.Local).AddTicks(6630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 363, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.AddColumn<int>(
                name: "Sold",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 56, DateTimeKind.Local).AddTicks(5190),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 360, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 54, DateTimeKind.Local).AddTicks(8010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 359, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 54, DateTimeKind.Local).AddTicks(7703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 359, DateTimeKind.Local).AddTicks(1239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 53, DateTimeKind.Local).AddTicks(4642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 357, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 53, DateTimeKind.Local).AddTicks(4397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 357, DateTimeKind.Local).AddTicks(7609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 48, DateTimeKind.Local).AddTicks(405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 352, DateTimeKind.Local).AddTicks(3372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 46, DateTimeKind.Local).AddTicks(8830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 351, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 41, DateTimeKind.Local).AddTicks(1541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 345, DateTimeKind.Local).AddTicks(3238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 35, DateTimeKind.Local).AddTicks(7604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 339, DateTimeKind.Local).AddTicks(8185));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sold",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 365, DateTimeKind.Local).AddTicks(8108),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 61, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 365, DateTimeKind.Local).AddTicks(7867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 61, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 363, DateTimeKind.Local).AddTicks(1525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 58, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 363, DateTimeKind.Local).AddTicks(1254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 58, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 360, DateTimeKind.Local).AddTicks(9059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 56, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 359, DateTimeKind.Local).AddTicks(1554),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 54, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 359, DateTimeKind.Local).AddTicks(1239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 54, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 357, DateTimeKind.Local).AddTicks(7854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 53, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 357, DateTimeKind.Local).AddTicks(7609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 53, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 352, DateTimeKind.Local).AddTicks(3372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 48, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 351, DateTimeKind.Local).AddTicks(1434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 46, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 345, DateTimeKind.Local).AddTicks(3238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 41, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 14, 29, 7, 339, DateTimeKind.Local).AddTicks(8185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 15, 12, 33, 15, 35, DateTimeKind.Local).AddTicks(7604));
        }
    }
}
