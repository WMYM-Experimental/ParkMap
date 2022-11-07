using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkMap.Migrations
{
    public partial class ChangePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_ParkMapUserId1",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_ParkMapUserId1",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ParkMapUserId1",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "ParkMapUserId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MyEmail",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ParkMapUserId",
                table: "Post",
                column: "ParkMapUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_ParkMapUserId",
                table: "Post",
                column: "ParkMapUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_ParkMapUserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_ParkMapUserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "MyEmail",
                table: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "ParkMapUserId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParkMapUserId1",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_ParkMapUserId1",
                table: "Post",
                column: "ParkMapUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_ParkMapUserId1",
                table: "Post",
                column: "ParkMapUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
