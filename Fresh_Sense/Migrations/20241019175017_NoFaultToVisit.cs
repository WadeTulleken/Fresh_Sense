using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fresh_Sense.Migrations
{
    /// <inheritdoc />
    public partial class NoFaultToVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scheduleFaultTechVisits_Faults_faultID",
                table: "scheduleFaultTechVisits");

            migrationBuilder.DropIndex(
                name: "IX_scheduleFaultTechVisits_faultID",
                table: "scheduleFaultTechVisits");

            migrationBuilder.DropColumn(
                name: "faultID",
                table: "scheduleFaultTechVisits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "faultID",
                table: "scheduleFaultTechVisits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_scheduleFaultTechVisits_faultID",
                table: "scheduleFaultTechVisits",
                column: "faultID");

            migrationBuilder.AddForeignKey(
                name: "FK_scheduleFaultTechVisits_Faults_faultID",
                table: "scheduleFaultTechVisits",
                column: "faultID",
                principalTable: "Faults",
                principalColumn: "faultID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
