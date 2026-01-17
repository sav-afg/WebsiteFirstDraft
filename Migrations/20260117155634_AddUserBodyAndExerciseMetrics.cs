using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteFirstDraft.Migrations
{
    /// <inheritdoc />
    public partial class AddUserBodyAndExerciseMetrics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ✅ Only add NEW columns to the existing Users table
            migrationBuilder.AddColumn<int>(
                name: "Body_Weight",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Maintenance_Calories",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Daily_Weight_Change",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weekly_Weight_Change",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Daily_Calories_Burnt_Through_Exercise",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weekly_Calories_Burnt_Through_Exercise",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Daily_Cardio",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Daily_Strength",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Daily_Flexibility",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // ✅ Keep Calorie_Logs table creation if it doesn't exist yet
            migrationBuilder.CreateTable(
                name: "Calorie_Logs",
                columns: table => new
                {
                    CalorieLog_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Log_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Calories_Consumed = table.Column<int>(type: "int", nullable: true),
                    Calories_Burned = table.Column<int>(type: "int", nullable: true),
                    Net_Calories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calorie_Logs", x => x.CalorieLog_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // ✅ Only drop the new columns from Users table
            migrationBuilder.DropColumn(name: "Body_Weight", table: "Users");
            migrationBuilder.DropColumn(name: "Maintenance_Calories", table: "Users");
            migrationBuilder.DropColumn(name: "Daily_Weight_Change", table: "Users");
            migrationBuilder.DropColumn(name: "Weekly_Weight_Change", table: "Users");
            migrationBuilder.DropColumn(name: "Daily_Calories_Burnt_Through_Exercise", table: "Users");
            migrationBuilder.DropColumn(name: "Weekly_Calories_Burnt_Through_Exercise", table: "Users");
            migrationBuilder.DropColumn(name: "Daily_Cardio", table: "Users");
            migrationBuilder.DropColumn(name: "Daily_Strength", table: "Users");
            migrationBuilder.DropColumn(name: "Daily_Flexibility", table: "Users");

            // ✅ Drop Calorie_Logs table if rolling back
            migrationBuilder.DropTable(name: "Calorie_Logs");
        }
    }
}
