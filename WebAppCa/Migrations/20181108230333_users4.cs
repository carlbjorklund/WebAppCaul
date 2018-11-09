using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class users4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSchedule_Schedules_ScheduleId",
                table: "UserSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSchedule_User_UserId",
                table: "UserSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSchedule",
                table: "UserSchedule");

            migrationBuilder.RenameTable(
                name: "UserSchedule",
                newName: "UserSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_UserSchedule_UserId",
                table: "UserSchedules",
                newName: "IX_UserSchedules_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSchedule_ScheduleId",
                table: "UserSchedules",
                newName: "IX_UserSchedules_ScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSchedules",
                table: "UserSchedules",
                column: "UserScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchedules_Schedules_ScheduleId",
                table: "UserSchedules",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchedules_User_UserId",
                table: "UserSchedules",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSchedules_Schedules_ScheduleId",
                table: "UserSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSchedules_User_UserId",
                table: "UserSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSchedules",
                table: "UserSchedules");

            migrationBuilder.RenameTable(
                name: "UserSchedules",
                newName: "UserSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_UserSchedules_UserId",
                table: "UserSchedule",
                newName: "IX_UserSchedule_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSchedules_ScheduleId",
                table: "UserSchedule",
                newName: "IX_UserSchedule_ScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSchedule",
                table: "UserSchedule",
                column: "UserScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchedule_Schedules_ScheduleId",
                table: "UserSchedule",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchedule_User_UserId",
                table: "UserSchedule",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
