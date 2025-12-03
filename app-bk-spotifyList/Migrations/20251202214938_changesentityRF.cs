using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_bk_spotifyList.Migrations
{
    /// <inheritdoc />
    public partial class changesentityRF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_refreshToken",
                table: "RefreshTokens",
                newName: "id_refresh_token");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_refresh_token",
                table: "RefreshTokens",
                newName: "id_refreshToken");
        }
    }
}
