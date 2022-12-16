using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intake.Migrations
{
    public partial class sensor_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pum5",
                table: "Sensors",
                newName: "Pump5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pump5",
                table: "Sensors",
                newName: "Pum5");
        }
    }
}
