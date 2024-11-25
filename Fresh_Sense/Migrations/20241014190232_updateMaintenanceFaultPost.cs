using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fresh_Sense.Migrations
{
    /// <inheritdoc />
    public partial class updateMaintenanceFaultPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReported",
                table: "maintenance_Faults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateReported",
                table: "maintenance_Faults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
