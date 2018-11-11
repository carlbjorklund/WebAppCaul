using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class Update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChannels");

            migrationBuilder.DropTable(
                name: "UserSchedules");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Programmes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Channels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_UserId",
                table: "Programmes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_UserId",
                table: "Channels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_User_UserId",
                table: "Channels",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programmes_User_UserId",
                table: "Programmes",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_User_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_User_UserId",
                table: "Channels");

            migrationBuilder.DropForeignKey(
                name: "FK_Programmes_User_UserId",
                table: "Programmes");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_User_UserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Programmes_UserId",
                table: "Programmes");

            migrationBuilder.DropIndex(
                name: "IX_Channels_UserId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Programmes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Channels");

            migrationBuilder.CreateTable(
                name: "UserChannels",
                columns: table => new
                {
                    UserChannelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChannelId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChannels", x => x.UserChannelId);
                    table.ForeignKey(
                        name: "FK_UserChannels_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "ChannelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChannels_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSchedules",
                columns: table => new
                {
                    UserScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSchedules", x => x.UserScheduleID);
                    table.ForeignKey(
                        name: "FK_UserSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSchedules_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserChannels_ChannelId",
                table: "UserChannels",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChannels_UserId",
                table: "UserChannels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSchedules_ScheduleId",
                table: "UserSchedules",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSchedules_UserId",
                table: "UserSchedules",
                column: "UserId");
        }
    }
}
