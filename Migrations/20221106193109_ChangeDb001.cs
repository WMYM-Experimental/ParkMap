using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkMap.Migrations
{
    public partial class ChangeDb001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_UserId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_AspNetUsers_ParkMapUserId1",
                table: "Reaction");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_ParkMapUserId1",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "ParkMapUserId1",
                table: "Reaction");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Post",
                newName: "ParkMapUserId1");

            migrationBuilder.RenameColumn(
                name: "ParMapUserId",
                table: "Post",
                newName: "ParkMapUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserId",
                table: "Post",
                newName: "IX_Post_ParkMapUserId1");

            migrationBuilder.AlterColumn<string>(
                name: "ParkMapUserId",
                table: "Reaction",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_ParkMapUserId",
                table: "Reaction",
                column: "ParkMapUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_ParkMapUserId1",
                table: "Post",
                column: "ParkMapUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_AspNetUsers_ParkMapUserId",
                table: "Reaction",
                column: "ParkMapUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_ParkMapUserId1",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_AspNetUsers_ParkMapUserId",
                table: "Reaction");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_ParkMapUserId",
                table: "Reaction");

            migrationBuilder.RenameColumn(
                name: "ParkMapUserId1",
                table: "Post",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ParkMapUserId",
                table: "Post",
                newName: "ParMapUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_ParkMapUserId1",
                table: "Post",
                newName: "IX_Post_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "ParkMapUserId",
                table: "Reaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParkMapUserId1",
                table: "Reaction",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_ParkMapUserId1",
                table: "Reaction",
                column: "ParkMapUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_AspNetUsers_ParkMapUserId1",
                table: "Reaction",
                column: "ParkMapUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
