using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Training.Data.Migrations
{
    public partial class EditColumnPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 865, DateTimeKind.Local).AddTicks(7532),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 447, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(max)",
                unicode: false,
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 865, DateTimeKind.Local).AddTicks(7305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 447, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 863, DateTimeKind.Local).AddTicks(3065),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 444, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 863, DateTimeKind.Local).AddTicks(2777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 444, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 861, DateTimeKind.Local).AddTicks(2645),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 442, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 859, DateTimeKind.Local).AddTicks(6640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 440, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 859, DateTimeKind.Local).AddTicks(6382),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 440, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 858, DateTimeKind.Local).AddTicks(4064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 439, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 858, DateTimeKind.Local).AddTicks(3791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 439, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 853, DateTimeKind.Local).AddTicks(3333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 434, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 852, DateTimeKind.Local).AddTicks(2505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 432, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 846, DateTimeKind.Local).AddTicks(7972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 427, DateTimeKind.Local).AddTicks(309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 841, DateTimeKind.Local).AddTicks(5504),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 421, DateTimeKind.Local).AddTicks(2992));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 447, DateTimeKind.Local).AddTicks(5614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 865, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldMaxLength: 2147483647);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 447, DateTimeKind.Local).AddTicks(5375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 865, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 444, DateTimeKind.Local).AddTicks(9411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 863, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 444, DateTimeKind.Local).AddTicks(9148),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 863, DateTimeKind.Local).AddTicks(2777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 442, DateTimeKind.Local).AddTicks(7301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 861, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 440, DateTimeKind.Local).AddTicks(9781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 859, DateTimeKind.Local).AddTicks(6640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 440, DateTimeKind.Local).AddTicks(9509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 859, DateTimeKind.Local).AddTicks(6382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 439, DateTimeKind.Local).AddTicks(6163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 858, DateTimeKind.Local).AddTicks(4064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "PostCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 439, DateTimeKind.Local).AddTicks(5911),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 858, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 434, DateTimeKind.Local).AddTicks(256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 853, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 432, DateTimeKind.Local).AddTicks(8217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 852, DateTimeKind.Local).AddTicks(2505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 427, DateTimeKind.Local).AddTicks(309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 846, DateTimeKind.Local).AddTicks(7972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_time",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 7, 40, 30, 421, DateTimeKind.Local).AddTicks(2992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 19, 7, 51, 21, 841, DateTimeKind.Local).AddTicks(5504));
        }
    }
}
