using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstTryDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Index_Author_Reader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Reader",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reader",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Author",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Reader_Email",
                table: "Reader",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reader_UserName",
                table: "Reader",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_Email",
                table: "Author",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reader_Email",
                table: "Reader");

            migrationBuilder.DropIndex(
                name: "IX_Reader_UserName",
                table: "Reader");

            migrationBuilder.DropIndex(
                name: "IX_Author_Email",
                table: "Author");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Reader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
