using Microsoft.EntityFrameworkCore.Migrations;

namespace VueJSSocialNetwork.Data.Migrations
{
    public partial class imageFileCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Posts",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Posts",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
