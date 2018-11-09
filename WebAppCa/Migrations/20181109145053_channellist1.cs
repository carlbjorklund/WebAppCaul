using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class channellist1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChannel_Channels_ChannelId",
                table: "UserChannel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannel_User_UserId",
                table: "UserChannel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChannel",
                table: "UserChannel");

            migrationBuilder.RenameTable(
                name: "UserChannel",
                newName: "UserChannels");

            migrationBuilder.RenameIndex(
                name: "IX_UserChannel_UserId",
                table: "UserChannels",
                newName: "IX_UserChannels_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserChannel_ChannelId",
                table: "UserChannels",
                newName: "IX_UserChannels_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChannels",
                table: "UserChannels",
                column: "UserChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_Channels_ChannelId",
                table: "UserChannels",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_User_UserId",
                table: "UserChannels",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_Channels_ChannelId",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_User_UserId",
                table: "UserChannels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChannels",
                table: "UserChannels");

            migrationBuilder.RenameTable(
                name: "UserChannels",
                newName: "UserChannel");

            migrationBuilder.RenameIndex(
                name: "IX_UserChannels_UserId",
                table: "UserChannel",
                newName: "IX_UserChannel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserChannels_ChannelId",
                table: "UserChannel",
                newName: "IX_UserChannel_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChannel",
                table: "UserChannel",
                column: "UserChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannel_Channels_ChannelId",
                table: "UserChannel",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannel_User_UserId",
                table: "UserChannel",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
