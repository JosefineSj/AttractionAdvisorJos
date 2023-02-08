using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AttractionAdvisor.DataAccess.migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attractions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttractionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Commentary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Attractions_UserId",
                        column: x => x.UserId,
                        principalTable: "Attractions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttractionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Attractions_UserId",
                        column: x => x.UserId,
                        principalTable: "Attractions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "$2a$11$MuseL0b0MrZHDvTwG6/ZnOqYKIlBfc/v5wpiZ4OtuL7t.eH9sjUwu", "Sahar" },
                    { 2, "$2a$11$Cqp89KEgxO8FE2oa4TI6OOX1LA1oJFeENtyDqgCBbwurLPEsMnOg6", "Hanna" },
                    { 3, "$2a$11$hLvfWhSUgDybQtqprffJy.Rlph/sjX9Ou9RvV6BYQjHqNkAWgR6y6", "Josefine" },
                    { 4, "$2a$11$rWIek.BBprnN5h60kXmvfe3xI9WjIhnE6xBJwwWDVWevFJj7TUkke", "Carl-Henrik" },
                    { 5, "$2a$11$JrSO2qf2BfGT7K288kBP6eJUhw9/A0yOod5lb12N2P1YHL0pcWw0O", "Kamran" },
                    { 6, "$2a$11$MPiU4d9YFnZX9AXeduR.Derd7uBedLzLQSrZLzmmHxIJQkVwmgMYe", "Jessica" },
                    { 7, "$2a$11$TX72BTGLJkYd.GO533/kL.6JdKtX1kNkCUhZPI9wWNH9khiVcqAd.", "Alfons" },
                    { 8, "$2a$11$bJMJYybsxKs4T20AVirSOOg21KhHFuMZ8jRU6v8ko36TfoG.R0sIK", "Sophie" },
                    { 9, "$2a$11$SR0u62UtnoyG1iEOrmCV5.cbnm/HWbwban0sWFGddxWhB1mWHcIJW", "Jenny" }
                });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "City", "Description", "ImageSource", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Stockholm", "The world's oldest open-air museum", "https://skansen.se/wp-content/uploads/2022/10/Hazeliusporten_skansen-600x450.jpg", "Skansen", 1 },
                    { 2, "Göteborg", "Amusement park in the centre of Gothenburg", "https://www.liseberg.se/optimized/facebook/046e6139/globalassets/parken/parkvyer/hela-parken-vy.jpg", "Liseberg", 2 },
                    { 3, "Malmö", "One of the leading art museums in scandinavia", "https://upload.wikimedia.org/wikipedia/commons/e/ea/Malmo_art_museum-malmo_castle.jpg", "Malmö Art Museum", 6 },
                    { 4, "Paris", "Wrought-iron tower on the Champ de Mars in Paris", "https://cdn.britannica.com/54/75854-050-E27E66C0/Eiffel-Tower-Paris.jpg", "Eiffel tower", 4 },
                    { 5, "New York City", "Is a 102-story Art Deco skyscraper in Midtown Manhattan, New York City", "https://lh5.googleusercontent.com/p/AF1QipNVlM5lo7fIJrmvjN4EOrTMiQjDgDyTfw7ATdV6=w243-h174-n-k-no-nu", "Empire State Building", 5 },
                    { 6, "Cairo", "", "https://media.architecturaldigest.com/photos/58e2a407c0e88d1a6a20066b/2:1/w_1287,h_643,c_limit/Pyramid%20of%20Giza%201.jpg", "Great Pyramid of Giza", 7 },
                    { 7, "Rome", "The Colosseum is an oval amphitheatre in the centre of the city of Rome", "https://jwttravel.ie/app/uploads/2022/04/Rome-Colosseum-travel-lessons-blog-JWT-Travel-Schools.jpg", "Colosseum", 8 },
                    { 8, "London", "The Tower of London is an internationally famous monument and one of England's most iconic structures.", "https://upload.wikimedia.org/wikipedia/commons/2/2c/Tower_of_London_viewed_from_the_River_Thames.jpg", "Tower of London", 3 },
                    { 9, "Rome", "Trevi Fountain is perhaps the most famous fountain in the world and definitely in Rome.", "https://www.italiandualcitizenship.net/wp-content/uploads/2019/03/Historic-Trevi-Fountain-in-Rome-Italy.jpg", "Trevi Fountain", 9 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AttractionId", "Commentary", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I didn't expect such nice place at all.PErfect way to spend time in Stockholm.", 1 },
                    { 2, 2, "Beautiful place and the kids enjoyed the few rides they could have, but they were dissapointed when they had to wait more than 2 hours to ride the rollercoaster.", 2 },
                    { 3, 4, "You will spend half a day only to visit the Eiffel tower. The interest is huge and the crowds are humongous.", 4 },
                    { 4, 3, "Oftast mycket intressanta utställningar,alltid gratis inträde och en gratis visning varje dag av kunniga guider", 6 },
                    { 5, 5, "Helt klart värt ett besök!Otroligt häftig film visas i hissen både påväg upp pch påväg ner vilket gör att man glömmer var man är påväg! Här finns inget att klaga på!", 5 },
                    { 6, 6, "Excellent visit Sunny January. Bring bottle of water and snack. Hat or a cap to protect ur head", 7 },
                    { 7, 7, "Good but there aare so much better places in Rome. If you don't jave a lot of time in Rome dont go inside of it cause its a waste of time", 8 },
                    { 8, 8, "The history alone is a reason to go. Go early, the lines get long especially for the crown jewels! A lot of walking and narrow stairs and cobblestones.Plan on a good couple of hours here.", 3 },
                    { 9, 9, "This was on my bucket list & I can happily say it’s been done but it wasn’t the best time of day to visit (late afternoon in the height of Summer) as the crowds were thick.", 9 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "AttractionId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 2 },
                    { 3, 3, 6, 1 },
                    { 4, 4, 4, 1 },
                    { 5, 5, 5, 1 },
                    { 6, 6, 7, 1 },
                    { 7, 7, 8, 2 },
                    { 8, 8, 3, 1 },
                    { 9, 9, 9, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_UserId",
                table: "Attractions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId_AttractionId",
                table: "Ratings",
                columns: new[] { "UserId", "AttractionId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
