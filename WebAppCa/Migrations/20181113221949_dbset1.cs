using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class dbset1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyChannelViewModelUserID",
                table: "Channels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MyChannelViewModel",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyChannelViewModel", x => x.UserID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_MyChannelViewModel_MyChannelViewModelUserID",
                table: "Channels");

            migrationBuilder.DropTable(
                name: "MyChannelViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Channels_MyChannelViewModelUserID",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "MyChannelViewModelUserID",
                table: "Channels");
        }
    }
}
