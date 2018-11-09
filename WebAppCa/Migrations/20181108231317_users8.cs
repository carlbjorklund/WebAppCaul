using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class users8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_User_UserId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Schedules_ScheduleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ScheduleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Schedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ScheduleId",
                table: "User",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_User_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Schedules_ScheduleId",
                table: "User",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
