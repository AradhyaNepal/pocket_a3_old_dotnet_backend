using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketA3.Migrations
{
    /// <inheritdoc />
    public partial class RegisterOTP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterOTP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(type: "int", nullable: false),
                    OTPHashed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterOTP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterOTP_RegisteringUser_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "RegisteringUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOTP_RegistrationId",
                table: "RegisterOTP",
                column: "RegistrationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterOTP");
        }
    }
}
