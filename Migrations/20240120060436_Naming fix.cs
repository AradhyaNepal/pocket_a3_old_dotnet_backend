using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketA3.Migrations
{
    /// <inheritdoc />
    public partial class Namingfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "weightKg",
                table: "User",
                newName: "WeightKg");

            migrationBuilder.RenameColumn(
                name: "heightCM",
                table: "User",
                newName: "HeightCM");

            migrationBuilder.RenameColumn(
                name: "fatPercentage",
                table: "User",
                newName: "FatPercentage");

            migrationBuilder.RenameColumn(
                name: "weightKg",
                table: "RegisteringUser",
                newName: "WeightKg");

            migrationBuilder.RenameColumn(
                name: "heightCM",
                table: "RegisteringUser",
                newName: "HeightCM");

            migrationBuilder.RenameColumn(
                name: "fatPercentage",
                table: "RegisteringUser",
                newName: "FatPercentage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightKg",
                table: "User",
                newName: "weightKg");

            migrationBuilder.RenameColumn(
                name: "HeightCM",
                table: "User",
                newName: "heightCM");

            migrationBuilder.RenameColumn(
                name: "FatPercentage",
                table: "User",
                newName: "fatPercentage");

            migrationBuilder.RenameColumn(
                name: "WeightKg",
                table: "RegisteringUser",
                newName: "weightKg");

            migrationBuilder.RenameColumn(
                name: "HeightCM",
                table: "RegisteringUser",
                newName: "heightCM");

            migrationBuilder.RenameColumn(
                name: "FatPercentage",
                table: "RegisteringUser",
                newName: "fatPercentage");
        }
    }
}
