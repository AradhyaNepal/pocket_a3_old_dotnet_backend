using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketA3.Migrations
{
    /// <inheritdoc />
    public partial class RegisterOTPSalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "OTPSalt",
                table: "RegisterOTP",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTPSalt",
                table: "RegisterOTP");
        }
    }
}
