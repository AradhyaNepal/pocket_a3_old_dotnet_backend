using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketA3.Migrations
{
    /// <inheritdoc />
    public partial class ModelBugfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "fatPercentage",
                table: "User",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "heightCM",
                table: "User",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "weightKg",
                table: "User",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "fatPercentage",
                table: "RegisteringUser",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "heightCM",
                table: "RegisteringUser",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "weightKg",
                table: "RegisteringUser",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fatPercentage",
                table: "User");

            migrationBuilder.DropColumn(
                name: "heightCM",
                table: "User");

            migrationBuilder.DropColumn(
                name: "weightKg",
                table: "User");

            migrationBuilder.DropColumn(
                name: "fatPercentage",
                table: "RegisteringUser");

            migrationBuilder.DropColumn(
                name: "heightCM",
                table: "RegisteringUser");

            migrationBuilder.DropColumn(
                name: "weightKg",
                table: "RegisteringUser");
        }
    }
}
