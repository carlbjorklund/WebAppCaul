using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCa.Migrations
{
    public partial class users2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchedulesiewModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchedulesiewModels",
                columns: table => new
                {
                    ScheduleViewModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirDate = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true),
                    Channel = table.Column<string>(nullable: true),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    ProgrameDescription = table.Column<string>(nullable: true),
                    ProgrameName = table.Column<string>(nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulesiewModels", x => x.ScheduleViewModelId);
                });
        }
    }
}
