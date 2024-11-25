using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fresh_Sense.Migrations
{
    /// <inheritdoc />
    public partial class fridgeRequestPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FridgeRequests",
                columns: table => new
                {
                    RequsetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoreAboutYourRequest = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeRequests", x => x.RequsetID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FridgeRequests");
        }
    }
}
