using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class DBUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_MySchedules_MySchedulesViewModelMyScheduleId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_User_UserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_MySchedulesViewModelMyScheduleId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "MySchedulesViewModelMyScheduleId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "MySchedules",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MySchedules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleID",
                table: "MySchedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScheduleViewModel",
                columns: table => new
                {
                    ScheduleViewModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    ChannelName = table.Column<string>(nullable: true),
                    ProgrameName = table.Column<string>(nullable: true),
                    ProgrameDescription = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    AirDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleViewModel", x => x.ScheduleViewModelId);
                });

            migrationBuilder.CreateTable(
                name: "UserStuff",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStuff", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "MyStuffViewModel",
                columns: table => new
                {
                    MyStuffID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false),
                    ChannelName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    ProgrameName = table.Column<string>(nullable: true),
                    ProgrameDescription = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    AirDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    UserStuffUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyStuffViewModel", x => x.MyStuffID);
                    table.ForeignKey(
                        name: "FK_MyStuffViewModel_UserStuff_UserStuffUserID",
                        column: x => x.UserStuffUserID,
                        principalTable: "UserStuff",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MySchedules_ScheduleID",
                table: "MySchedules",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_MySchedules_UserId",
                table: "MySchedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyStuffViewModel_UserStuffUserID",
                table: "MyStuffViewModel",
                column: "UserStuffUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_MySchedules_Schedules_ScheduleID",
                table: "MySchedules",
                column: "ScheduleID",
                principalTable: "Schedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MySchedules_User_UserId",
                table: "MySchedules",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MySchedules_Schedules_ScheduleID",
                table: "MySchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_MySchedules_User_UserId",
                table: "MySchedules");

            migrationBuilder.DropTable(
                name: "MyStuffViewModel");

            migrationBuilder.DropTable(
                name: "ScheduleViewModel");

            migrationBuilder.DropTable(
                name: "UserStuff");

            migrationBuilder.DropIndex(
                name: "IX_MySchedules_ScheduleID",
                table: "MySchedules");

            migrationBuilder.DropIndex(
                name: "IX_MySchedules_UserId",
                table: "MySchedules");

            migrationBuilder.DropColumn(
                name: "ScheduleID",
                table: "MySchedules");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MySchedules",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "MySchedulesViewModelMyScheduleId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "MySchedules",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_MySchedulesViewModelMyScheduleId",
                table: "Schedules",
                column: "MySchedulesViewModelMyScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_MySchedules_MySchedulesViewModelMyScheduleId",
                table: "Schedules",
                column: "MySchedulesViewModelMyScheduleId",
                principalTable: "MySchedules",
                principalColumn: "MyScheduleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_User_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
