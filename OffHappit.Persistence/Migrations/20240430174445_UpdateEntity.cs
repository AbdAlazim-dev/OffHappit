using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OffHappit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_UsersCredentials_UserId",
                table: "UsersProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_UsersCredentials_UserId",
                table: "UsersProfiles",
                column: "UserId",
                principalTable: "UsersCredentials",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
