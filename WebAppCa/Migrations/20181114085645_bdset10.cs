using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class bdset10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MySchedulesViewModelMyScheduleId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProgrammesViewModelMyProgrammeId",
                table: "Programmes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MyProgrammes",
                columns: table => new
                {
                    MyProgrammeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProgrammes", x => x.MyProgrammeId);
                });

            migrationBuilder.CreateTable(
                name: "MySchedules",
                columns: table => new
                {
                    MyScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySchedules", x => x.MyScheduleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_MySchedulesViewModelMyScheduleId",
                table: "Schedules",
                column: "MySchedulesViewModelMyScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Programmes_MyProgrammesViewModelMyProgrammeId",
                table: "Programmes",
                column: "MyProgrammesViewModelMyProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programmes_MyProgrammes_MyProgrammesViewModelMyProgrammeId",
                table: "Programmes",
                column: "MyProgrammesViewModelMyProgrammeId",
                principalTable: "MyProgrammes",
                principalColumn: "MyProgrammeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_MySchedules_MySchedulesViewModelMyScheduleId",
                table: "Schedules",
                column: "MySchedulesViewModelMyScheduleId",
                principalTable: "MySchedules",
                principalColumn: "MyScheduleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programmes_MyProgrammes_MyProgrammesViewModelMyProgrammeId",
                table: "Programmes");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_MySchedules_MySchedulesViewModelMyScheduleId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "MyProgrammes");

            migrationBuilder.DropTable(
                name: "MySchedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_MySchedulesViewModelMyScheduleId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Programmes_MyProgrammesViewModelMyProgrammeId",
                table: "Programmes");

            migrationBuilder.DropColumn(
                name: "MySchedulesViewModelMyScheduleId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "MyProgrammesViewModelMyProgrammeId",
                table: "Programmes");
        }
    }
}
