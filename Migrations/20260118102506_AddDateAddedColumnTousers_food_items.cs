using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteFirstDraft.Migrations
{
    /// <inheritdoc />
    public partial class AddDateAddedColumnTousers_food_items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Added",
                table: "users_food_items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder) 
        {
            migrationBuilder.DropColumn(
                name: "Date_Added",
                table: "users_food_items");
        }


    }
}
