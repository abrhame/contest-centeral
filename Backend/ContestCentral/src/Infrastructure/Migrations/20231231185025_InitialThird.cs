using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialThird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verification_Users_UserId",
                table: "Verification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verification",
                table: "Verification");

            migrationBuilder.RenameTable(
                name: "Verification",
                newName: "Verifications");

            migrationBuilder.RenameIndex(
                name: "IX_Verification_UserId",
                table: "Verifications",
                newName: "IX_Verifications_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verifications",
                table: "Verifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verifications_Users_UserId",
                table: "Verifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verifications_Users_UserId",
                table: "Verifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verifications",
                table: "Verifications");

            migrationBuilder.RenameTable(
                name: "Verifications",
                newName: "Verification");

            migrationBuilder.RenameIndex(
                name: "IX_Verifications_UserId",
                table: "Verification",
                newName: "IX_Verification_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verification",
                table: "Verification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Verification_Users_UserId",
                table: "Verification",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
