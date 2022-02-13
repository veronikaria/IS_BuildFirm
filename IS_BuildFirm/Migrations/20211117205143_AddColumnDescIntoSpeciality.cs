using Microsoft.EntityFrameworkCore.Migrations;

namespace IS_BuildFirm.Migrations
{
    public partial class AddColumnDescIntoSpeciality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Specialities",
                type: "nvarchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Specialities");
        }
    }
}
