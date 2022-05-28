using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamsterWarsV2.Migrations
{
    public partial class AddedMatchDataForTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "LoserId", "WinnerId" },
                values: new object[] { 1, 1, 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1);
        }
    }
}
