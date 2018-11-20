using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class databaseupdate101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MySchedules_User_UserId",
                table: "MySchedules");

            migrationBuilder.DropIndex(
                name: "IX_MySchedules_UserId",
                table: "MySchedules");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MySchedules",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "MySchedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MySchedules_UserId1",
                table: "MySchedules",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MySchedules_User_UserId1",
                table: "MySchedules",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MySchedules_User_UserId1",
                table: "MySchedules");

            migrationBuilder.DropIndex(
                name: "IX_MySchedules_UserId1",
                table: "MySchedules");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MySchedules");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MySchedules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MySchedules_UserId",
                table: "MySchedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MySchedules_User_UserId",
                table: "MySchedules",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
