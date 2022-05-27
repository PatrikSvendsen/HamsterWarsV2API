using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamsterWarsV2.Migrations
{
    public partial class InitialCreateWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerId = table.Column<int>(type: "int", nullable: true),
                    LoserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    HamsterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FavFood = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Loves = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Defeats = table.Column<int>(type: "int", nullable: false),
                    Games = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.HamsterId);
                    table.ForeignKey(
                        name: "FK_Hamsters_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId");
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "HamsterId", "Age", "Defeats", "FavFood", "Games", "ImgName", "Loves", "MatchId", "Name", "Wins" },
                values: new object[,]
                {
                    { 1, 1, 0, "Pizza", 0, "/images/hamsters/hamster-9.jpg", "Hjulet", null, "Rasmus", 0 },
                    { 2, 2, 0, "Fika", 0, "/images/hamsters/hamster-8.jpg", "Meetings", null, "Jimmy", 0 },
                    { 3, 3, 0, "Pancakes", 0, "/images/hamsters/hamster-7.jpg", "Intellisense", null, "Claes", 0 },
                    { 4, 2, 0, "Korv", 0, "/images/hamsters/hamster-1.jpg", "Korvar", null, "Korven", 0 },
                    { 5, 2, 0, "Sallad", 0, "/images/hamsters/hamster-2.jpg", "Jumping", null, "Patrik", 0 },
                    { 6, 4, 0, "Bark", 0, "/images/hamsters/hamster-3.jpg", "Kvivksilver", null, "Pontus", 0 },
                    { 7, 7, 0, "Popcorn", 0, "/images/hamsters/hamster-4.jpg", "Berras Bio", null, "Mikael", 0 },
                    { 8, 10, 0, "Bark", 0, "/images/hamsters/hamster-5.jpg", "Träd", null, "Bävern", 0 },
                    { 9, 2, 0, "Blötmat", 0, "/images/hamsters/hamster-6.jpg", "Lekar", null, "Kattis", 0 },
                    { 10, 3, 0, "FUZEON", 0, "/images/hamsters/hamster-10.jpg", "Kids", null, "Hyaena", 0 },
                    { 11, 3, 0, "Sallad", 0, "/images/hamsters/hamster-11.jpg", "Lekar", null, "Kingfisher", 0 },
                    { 12, 4, 0, "Bark", 0, "/images/hamsters/hamster-12.jpg", "Hjulet", null, "Robin", 0 },
                    { 13, 1, 0, "Sallad", 0, "/images/hamsters/hamster-13.jpg", "Lekar", null, "Lynx", 0 },
                    { 14, 1, 0, "Bark", 0, "/images/hamsters/hamster-14.jpg", "Lekar", null, "Duck", 0 },
                    { 15, 2, 0, "Blötmat", 0, "/images/hamsters/hamster-15.jpg", "Hjulet", null, "Rhinoceros", 0 },
                    { 16, 3, 0, "Sallad", 0, "/images/hamsters/hamster-16.jpg", "Lekar", null, "Red", 0 },
                    { 17, 1, 0, "Bark", 0, "/images/hamsters/hamster-17.jpg", "Hjulet", null, "Gazelle", 0 },
                    { 18, 5, 0, "Sallad", 0, "/images/hamsters/hamster-18.jpg", "Lekar", null, "Dragon", 0 },
                    { 19, 4, 0, "Blötmat", 0, "/images/hamsters/hamster-19.jpg", "Lekar", null, "Lourie", 0 },
                    { 20, 3, 0, "Bark", 0, "/images/hamsters/hamster-20.jpg", "Hjulet", null, "Squirrel", 0 },
                    { 21, 2, 0, "Sallad", 0, "/images/hamsters/hamster-21.jpg", "Lekar", null, "Carmine", 0 },
                    { 22, 2, 0, "Popcorn", 0, "/images/hamsters/hamster-22.jpg", "Hjulet", null, "Snake", 0 },
                    { 23, 1, 0, "Sallad", 0, "/images/hamsters/hamster-23.jpg", "Lekar", null, "Bear", 0 },
                    { 24, 3, 0, "Bark", 0, "/images/hamsters/hamster-24.jpg", "Hjulet", null, "Chickadee", 0 },
                    { 25, 3, 0, "Sallad", 0, "/images/hamsters/hamster-25.jpg", "Lekar", null, "Vervet ", 0 },
                    { 26, 3, 0, "Bark", 0, "/images/hamsters/hamster-26.jpg", "Hjulet", null, "Malagasy ", 0 },
                    { 27, 3, 0, "Sallad", 0, "/images/hamsters/hamster-27.jpg", "Lekar", null, "Malleefowl", 0 },
                    { 28, 1, 0, "Bark", 0, "/images/hamsters/hamster-28.jpg", "Hjulet", null, "Desert", 0 },
                    { 29, 2, 0, "Popcorn", 0, "/images/hamsters/hamster-29.jpg", "Lekar", null, "Kaffir", 0 },
                    { 30, 1, 0, "Sallad", 0, "/images/hamsters/hamster-30.jpg", "Lekar", null, "Nubian ", 0 },
                    { 31, 2, 0, "Popcorn", 0, "/images/hamsters/hamster-31.jpg", "Hjulet", null, "Macaw", 0 },
                    { 32, 3, 0, "Blötmat", 0, "/images/hamsters/hamster-32.jpg", "Lekar", null, "Woodcock", 0 },
                    { 33, 4, 0, "Sallad", 0, "/images/hamsters/hamster-33.jpg", "Hjulet", null, "Eurasian", 0 },
                    { 34, 4, 0, "Gräs", 0, "/images/hamsters/hamster-34.jpg", "Lekar", null, "Mynah", 0 },
                    { 35, 4, 0, "Popcorn", 0, "/images/hamsters/hamster-35.jpg", "Lekar", null, "Sportive", 0 },
                    { 36, 3, 0, "Gräs", 0, "/images/hamsters/hamster-36.jpg", "Hjulet", null, "Marten", 0 },
                    { 37, 2, 0, "Sallad", 0, "/images/hamsters/hamster-37.jpg", "Lekar", null, "Malagasy", 0 },
                    { 38, 1, 0, "Popcorn", 0, "/images/hamsters/hamster-38.jpg", "Hjulet", null, "Grey ", 0 },
                    { 39, 1, 0, "Gräs", 0, "/images/hamsters/hamster-39.jpg", "Lekar", null, "Bear", 0 },
                    { 40, 2, 0, "Sallad", 0, "/images/hamsters/hamster-40.jpg", "Hjulet", null, "Four", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_MatchId",
                table: "Hamsters",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
