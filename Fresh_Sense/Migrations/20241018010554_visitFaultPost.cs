using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fresh_Sense.Migrations
{
    /// <inheritdoc />
    public partial class visitFaultPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "scheduleFaultTechVisits",
                columns: table => new
                {
                    vistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    visitDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visitTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faultID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduleFaultTechVisits", x => x.vistID);
                    table.ForeignKey(
                        name: "FK_scheduleFaultTechVisits_Faults_faultID",
                        column: x => x.faultID,
                        principalTable: "Faults",
                        principalColumn: "faultID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scheduleFaultTechVisits_faultID",
                table: "scheduleFaultTechVisits",
                column: "faultID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scheduleFaultTechVisits");
        }
    }
}
