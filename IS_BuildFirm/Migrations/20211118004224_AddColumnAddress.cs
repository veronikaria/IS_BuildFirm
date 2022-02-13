using Microsoft.EntityFrameworkCore.Migrations;

namespace IS_BuildFirm.Migrations
{
    public partial class AddColumnAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Schedules",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Schedules");
        }
    }
}
