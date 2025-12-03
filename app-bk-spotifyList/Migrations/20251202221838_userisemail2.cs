using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_bk_spotifyList.Migrations
{
    /// <inheritdoc />
    public partial class userisemail2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_verify_email",
                table: "RefreshTokens");

            migrationBuilder.AddColumn<bool>(
                name: "is_verify_email",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_verify_email",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "is_verify_email",
                table: "RefreshTokens",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
