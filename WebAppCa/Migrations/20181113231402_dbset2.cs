using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class dbset2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_MyChannelViewModel_MyChannelViewModelUserID",
                table: "Channels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyChannelViewModel",
                table: "MyChannelViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Channels_MyChannelViewModelUserID",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "MyChannelViewModelUserID",
                table: "Channels");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "MyChannelViewModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "MyChannelsId",
                table: "MyChannelViewModel",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "MyChannelViewModelMyChannelsId",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyChannelViewModel",
                table: "MyChannelViewModel",
                column: "MyChannelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_MyChannelViewModelMyChannelsId",
                table: "Channels",
                column: "MyChannelViewModelMyChannelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_MyChannelViewModel_MyChannelViewModelMyChannelsId",
                table: "Channels",
                column: "MyChannelViewModelMyChannelsId",
                principalTable: "MyChannelViewModel",
                principalColumn: "MyChannelsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_MyChannelViewModel_MyChannelViewModelMyChannelsId",
                table: "Channels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyChannelViewModel",
                table: "MyChannelViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Channels_MyChannelViewModelMyChannelsId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "MyChannelsId",
                table: "MyChannelViewModel");

            migrationBuilder.DropColumn(
                name: "MyChannelViewModelMyChannelsId",
                table: "Channels");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "MyChannelViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyChannelViewModelUserID",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyChannelViewModel",
                table: "MyChannelViewModel",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_MyChannelViewModelUserID",
                table: "Channels",
                column: "MyChannelViewModelUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_MyChannelViewModel_MyChannelViewModelUserID",
                table: "Channels",
                column: "MyChannelViewModelUserID",
                principalTable: "MyChannelViewModel",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
