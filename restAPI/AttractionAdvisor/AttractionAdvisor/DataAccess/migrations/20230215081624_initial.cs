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
                        name: "FK_Comments_Attractions_AttractionId",
                        column: x => x.AttractionId,
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
                    { 1, "$2a$11$Kx/U595CrrDDeNZO7VpT7e5fgFBDki7vnC8YBnpRfpFR1TLZ3qzJa", "Violet.Hilll46" },
                    { 2, "$2a$11$qLYB/k40WH7BH4gjMR9EjO3JOFA1SjKiBNggcY1odbpG9MZSkYgx6", "Christy96" },
                    { 3, "$2a$11$CCfeQ5IW.TAZ.tXoqmKP7.bErxn07QPVwoK26AOuRPf6YmlNz6oLG", "Darryl84" },
                    { 4, "$2a$11$zUHnzyZZw4cWVsTAE0rj1uvAh5FIJeWWlP0UJnYFsNL/Bl68CzRzi", "Benny_Kris74" },
                    { 5, "$2a$11$NGBUk1NucXI7rI9auYsOzeyUy/xDXqDwhk3RiP95ydvlw.Y0LY8DK", "Jorge.Fay" },
                    { 6, "$2a$11$9mvrbJPEOytA3l/zbL8.tO8UJ9BlQm65HSEcq/KuKinVB4N90TAmW", "Sabrina96" },
                    { 7, "$2a$11$p0C6thmiYrDzbAuIKvtp7uT1dERkzPHOwHgQEIBGcfsCwgmozcqmm", "Phyllis_Mayer" },
                    { 8, "$2a$11$NU/pEzEbK/HWUS4oD9Oi5e.96n5PG14zRY9H77WIW8SdrRybX.KWi", "Gayle13" },
                    { 9, "$2a$11$MdTjyDFPzOt0epDQZxFdPOK93zHY1/U92jFO1gziZmPuPOWatTeMm", "Charles_Rohan26" },
                    { 10, "$2a$11$H.Tf3Ip7nvcjNUf87pHeUOD/2pz0O/CkiebPvdVSaWdn6Xb9jxt0y", "Reginald.Schoen" },
                    { 11, "$2a$11$FQLlyxzYAdsNdoUbTaDLr.pgU32iiGRW1X1U3/SsLK13TWL/3uoBS", "Paula_Hartmann34" },
                    { 12, "$2a$11$YnPnvI3kHemZDvK5CfhqHOW9HENhlmlx2iI4KXfy5qihPVomUry1.", "Bryant_Gutmann" },
                    { 13, "$2a$11$ri7AHHqb.XCgzptMqkKs/OxD43Xd00m0dfttA0k3DzYvCBsZcoiPC", "Omar.Shields" },
                    { 14, "$2a$11$4PNvLq4mY2idX0.EXkbAe.bEJSw4z7Af3RjXOjYPEwkuRgAaf/OZG", "Patricia.Zemlak64" },
                    { 15, "$2a$11$rHB6MOmdNe3I1jWVPEBR4.VasWD.Ckln4h2PxXvab5APFkMWSaRLi", "Virginia96" },
                    { 16, "$2a$11$VRVUGfqR3wkB/T2erbRRK.uLH163iwlQ9/gVMps5.CKSq867ERIS.", "Ada.Waelchi" },
                    { 17, "$2a$11$8kbrcq/Q98LdrajJDWr/LOHLfabAi9LO8bpIC3WWcfzRwmCetzh6.", "Lillie97" },
                    { 18, "$2a$11$oNB9x1lX6grTxHiOUlkP.O6ldZFIa4/DbmN0bmQQ6fc.pJSm67Cia", "Kara_Pouros" },
                    { 19, "$2a$11$LpZ3oYOHUj5jcfMP8UDVDeH4lRhdOITjOHNON10gtKToukyi.0z.e", "Gail78" },
                    { 20, "$2a$11$Vnt/On63wEHnDcSrvHzVmOC9SqFT5FPgFfyZVUSrWbJJGTK/Q.g52", "Al11" },
                    { 21, "$2a$11$XWkrRqqjj4epVY66QX5h/uyAZV4xAzlmvB5kTHZ/hrVlP4d2tDzNG", "Marion.Schulist37" },
                    { 22, "$2a$11$igPXXPuydPGJqWxs.oUn/eCq9EK2uGAYHB5ayF3clFryJBaeOztse", "Amelia.Wehner" },
                    { 23, "$2a$11$iAo3l.QzgN3NCYfybpziTexMYdS/q46UzB1n5WP4KW4XcTl3VBRI6", "Drew31" },
                    { 24, "$2a$11$l.JcqoKxapmKYiGG1glCo.BvsNztlvs/aeGErtoMbEF8U/H0gTZTu", "Tommy.Jones40" },
                    { 25, "$2a$11$Ej4ob141jcKyxlnuEZti/.1SKG0j4krKZaM/kPw4ETCA.zJb./zqe", "Timothy.Boyer64" },
                    { 26, "$2a$11$cYxW4VVYbu2/NsgYDhClI.yV8mPKncGwBy3NVZxkYKUglX1RATJYG", "Kristine.Stracke27" },
                    { 27, "$2a$11$CtwQZYOW8/B5jPZV0S5gA.Qw3LiMJF756Q9vUpmEyV/nMAb9bL2Ey", "Edwin.Cremin71" },
                    { 28, "$2a$11$eq5x8rHjHMLmqPyxh7bOU..T0HZLGwIHIG7602uvP6Mwtza.NSPBu", "Shelley16" },
                    { 29, "$2a$11$wSiK3Pz4r0b8N7FzlLbWXOwFDaN5o7hEyE/7cnAcnr.qINR8ivVSW", "Latoya23" },
                    { 30, "$2a$11$UirMB1fKv.cFBxLUCmHzI.iLUsW8apt9Bjs0xE9esC1Hrhi9uaQhq", "Louise_Renner68" },
                    { 31, "$2a$11$lYDe0AAypctwj9N3e1cQ1.vSImOJMhhRpl1x8MhiDEmFq.F7gqPfy", "Cora_Kub85" },
                    { 32, "$2a$11$hf3rFtQuXiblJIScND2E2OM/p/c9feOQYc8nyhAPQgaoquY9sV9d.", "Richard_Skiles87" },
                    { 33, "$2a$11$7ImCIatruQpltNvqfkvCd./ECiCncWGrwymerZMPA.N4hJUL8tlW.", "Claire22" },
                    { 34, "$2a$11$0RZWmepymrlqd.k5fAbmYuD4Uo2FcxKkL9.IPrgeJwhoOq.XqgGFG", "Gerard_Klocko20" },
                    { 35, "$2a$11$MtTU/szHcHm35wsoDX7w5.B.i9WA64aX5mqGuKqDrvcbHuPOTgwXm", "Arlene18" },
                    { 36, "$2a$11$hPWNLgE1LcOjxBdEv3mp0OO0BOKtD78nlHB7yly1qFAFzd4axtcRi", "Cathy.Dicki53" },
                    { 37, "$2a$11$xwmo.O8kICoqAn.m1yaEJ.NjFOSmw8JmlcmwE/bOuKMKP9aW.XywW", "Glenn89" },
                    { 38, "$2a$11$l7PwRaKTrpVpm79nP9m1v.oiJmFg4DliUoW7dtM7zPhSEBk5xhCoe", "Suzanne10" },
                    { 39, "$2a$11$i3YIDHqGgAdF8WJgSellfOU5YDVeUft/1/TjnyDLAAKYwKLc5GEMi", "Saul63" },
                    { 40, "$2a$11$s27LspkQvv2ckTFUzHFK/OPaXz2XlkKcFeXni6d3.z663I0T9bxv.", "Desiree_Greenholt" },
                    { 41, "$2a$11$VsTSnA31lCzd1WIscynZOu2TcoeTQoliH9lhmDui8ir5FVkHJ5/Qi", "Lynda73" },
                    { 42, "$2a$11$tafFvpwondGm2V75yVutTOBj/IK/uuV9jJWQmedqxt9eUxBAn1qWC", "Shannon0" },
                    { 43, "$2a$11$9QghmEpsN6hD9oWjcbsYLeTKtaGGdWxf1QYTQjuUT819tGjW3Vb7q", "Vivian.Olson37" },
                    { 44, "$2a$11$r7vP/YqcT5f223kV.AEwPeTBMLlhMf5V0tUrGH3ZYlBxiqTEjyFDS", "Roosevelt_Koch" },
                    { 45, "$2a$11$jtxpLmcGq8O9EelCrw19BevRzuQpMh9vTH.2kQ1CdHVq1KF5VNH7u", "Colin.Walker28" },
                    { 46, "$2a$11$11YAA7BY2xc8NJ20TFIyFOe4uG7fztR1mdaQ1tlAVboRrZ/yqOlzy", "Marc.Hirthe57" },
                    { 47, "$2a$11$UcXboUYvlJhBEp5B14JPZuUuLPPkzRprYoVBwhVG.Aa2Y8Ga0LtZu", "Raymond.Schimmel" },
                    { 48, "$2a$11$QkS5/6D2ZwsJOj/pzrhNvOKv/qw0pya3oVgwSe7m4PNsxZGUujcf.", "Shaun_Deckow" },
                    { 49, "$2a$11$1h6xVhvQZuWT..0iCZnJ3uP9llHvt0MfO9nUBjSrCQKhisq7TUvLa", "Tami21" },
                    { 50, "$2a$11$nAou72YG7SWoRp3Mvo5U2O1yWLpA9cpZ1qAVG/HyT/ZtXUz.1QGl.", "Chelsea.Wisoky53" },
                    { 51, "$2a$11$Ygs8b4UkNyOWvHWAAZy08O7n/zTK6LJNVCby2In25U4WgvePjmvZ2", "Neal14" },
                    { 52, "$2a$11$xU2Oey95F0l9DZP5cQYs0uDITd/S.lC.GX/fPgFbwa.EwIStjyDCq", "Darla.MacGyver70" },
                    { 53, "$2a$11$CtivcH8zfONlAYf.aIeXruN.Pvpjmm710YoDpKutrTRKSAsrfrh6G", "Maryann_Padberg59" },
                    { 54, "$2a$11$JcCKRIEfLNOISL.Q3ZPdXOQ4bGTAWf0cHr9hRByovYcUgjhL8AK5i", "Eunice_Quigley85" },
                    { 55, "$2a$11$Gnx/0yszEDdxBmBdqPv5huK.otXBQ0KwevMf0wkrp.j/ppcYUSCde", "Oscar.Osinski" },
                    { 56, "$2a$11$lYd5n/DsfDez5KmzXf4iVONttPpGer0P15wEg3DQ8YEGV/mmsLAeK", "Jerome11" },
                    { 57, "$2a$11$.tupUTq3tcrSGTyJCakyCOLmRUzr14PoprCDbWjOHtABnYvr5pkn.", "Jan.Hettinger" },
                    { 58, "$2a$11$UDKANMzcdSL5jdJuJyPlouh.ignyn4.iBg/SAhH0k1OfftM6gwNEu", "Alison83" },
                    { 59, "$2a$11$VAAjN8X6ox.IwsvAwAf9cedQDWjgM3KP/QFgljhiJ72NlNEExfF/y", "Olivia99" },
                    { 60, "$2a$11$Xavq5yHKs0tjJx9s00DwfOHdZSJrlekhuehRq/MmUHhQbj1AhCvLy", "Nicole_Ferry" },
                    { 61, "$2a$11$d4hy9lDxbj21Y10I3ZkwdO/PaP/h3XFHaG7eZLj1JBxjKJ/lEA7XG", "Deanna_Tremblay75" },
                    { 62, "$2a$11$MZ65.aajWldoZa5ik5r7guD5Ly2UgM4ySpDxb/0.xjwIQHGHbO4zi", "Yolanda_Haag14" },
                    { 63, "$2a$11$62veXZdVVKFjIl5Pptu7he4G7sireL41ed4jt/8I0VP7Djoyq7zDS", "Ashley_Bode93" },
                    { 64, "$2a$11$qINJrIpfZOE38Cf/t9bZDuo.l6L70hVBvQhYzkvt3luxnu/WJqhES", "Sadie44" },
                    { 65, "$2a$11$XjZk8/kkj5PawRbyfLISleMk0ORSFvY3oWBvM.OkNJFTxAUCDhYDO", "Joey.Kozey" },
                    { 66, "$2a$11$TLjNKk72KdQAbIQEb1d2ceqcYioKC9YDgjT6nrAH9zHykXan9YNHS", "Jenny_Kerluke" },
                    { 67, "$2a$11$2XPfnG9jXd6dCwOLFK84T.fHoqd5z.Hv8aDjdnweFLLOkrdsllBuy", "Johnnie80" },
                    { 68, "$2a$11$HCyStYgbQebLblCLVxM36u5dZa0qaITh4zAaIB66oUjc4KtojMhea", "Danielle4" },
                    { 69, "$2a$11$8m5Wwwdxz9mx00LB7AyQNuECTjK0SD6g3XyECjJpKf.taTkj9/eTe", "Cecilia74" },
                    { 70, "$2a$11$rPCfy2tjFiu7L5nBT5w.fu8uDGKO8doEaozNR69O.WG2sgHvLct6.", "Don37" },
                    { 71, "$2a$11$y..L5MktcoX3R4A74lop6uB2pn7.2rj6twalcZalE9aT/Oz8KMI52", "Brian.Dickinson69" },
                    { 72, "$2a$11$cLexDkBlCcUwl9GLlTp.4u6DwCdxZUvO7WgQYxi36PdXu/JpoI/8y", "Owen.Hyatt" },
                    { 73, "$2a$11$dw/RJcqArzLpSjZfY5jCnOMWTooGcH0ArGKEF.8GtAnzoVLjIk6nG", "Latoya_Zemlak16" },
                    { 74, "$2a$11$6Lu/hqUyQff4l1Eb3fmTCOQBPbpV/psKJvm/X2BP6SKKwbM3NTP5K", "Alejandro_Zulauf59" },
                    { 75, "$2a$11$f0t7uKL/h4wukBtWWPyZmesV7HoMfAlgoOEhGzj9F3xtTiW2OD2pC", "Justin_Oberbrunner" },
                    { 76, "$2a$11$F4316nXqXNB6S74GgKMxKu3hYi16QTwzqFGVbyBFd2A68TRaFCQgG", "Agnes_Bogisich76" },
                    { 77, "$2a$11$XuRIybJlqeL2lb8F54JSguaQRYxP8t9eNO/JLfv/aCRAPmSoGuXXK", "Sonia42" },
                    { 78, "$2a$11$6a3FDXi57EAwSL24Csu0deqO4MIbm9VK0qAoR0aOYOt3xZXKVZbd.", "Martin.Jacobi37" },
                    { 79, "$2a$11$nMB7Dj9mfdLcthgOHYusUe8VUU0kXpOI6JwFCNHrbKIbkB0O4Zh7m", "Paulette60" },
                    { 80, "$2a$11$FjMqeLNv6IfViRY8JH9IZuJC2QCgoyDju6gZzOnsWyWJcXEqkVUuS", "Carmen87" },
                    { 81, "$2a$11$on5rlYFlQY2czgfzS7Lp9e6smTg1oq1JBM3U/kZHEdUL4KXiQRQtK", "Jeanne_Bartoletti7" },
                    { 82, "$2a$11$ekhklGm.fnWoTd33bPKviO6qnpF6TZDshjdB5RL6bf/Q9DrEIKUO.", "Spencer.Ruecker52" },
                    { 83, "$2a$11$u2dBfTBcJ8qXgZFwapUV0uYHBge86juytUYRsu.Zi4//.B/5Lkvnm", "Franklin.Buckridge" },
                    { 84, "$2a$11$ETwhuJCIgz5M36t/WwVnbeXTY8zO1ADnyJOCQr7S5K3lSunOOW5ia", "Kate.Friesen32" },
                    { 85, "$2a$11$177T8bNbQFuhtQRdYmzuoOIzWnwKOdyoiOLft8wbP7fVH3mcN3ukq", "Maxine_Shanahan29" },
                    { 86, "$2a$11$citfylgmFsahXCV6EFS8AuOw7tsUFlLycv3gPRi9ZCVU6faEuKh12", "Arthur.Anderson" },
                    { 87, "$2a$11$BU0X8aOMyP41hQEnYfpj3O33q9LS1gQ87oTfO5peVrS3h14z.4mla", "Francisco70" },
                    { 88, "$2a$11$/yPIWb2FZe2MnznExjUeP.IOAeEAGsnm9gttRrtLkYvjwrVzLT45u", "Stephen48" },
                    { 89, "$2a$11$8xYWwnvEzi0HVX3KgVxFle9VfAuoO7NxPoxCSoRTjs93m2D4HVMNS", "Leigh.Okuneva" },
                    { 90, "$2a$11$2QZR5kpAwS0PXGoQitUHBOEKe0AJREdvbVCaLU17IYDeL9OxiFhMW", "Rene.Hudson93" },
                    { 91, "$2a$11$.rDoJHVnRM13Ign30eX7nOFFo37JVZi71gX6ZtyiMzGXFuK/vkUKO", "Javier.Schinner26" },
                    { 92, "$2a$11$r63Gyxud04ja6UVV9rXEyeiXKQYgUhYB/Yt3unSuU4K4fpfpyVulu", "Florence_Will77" },
                    { 93, "$2a$11$w3OznG/flGiCi7AASiZmMeh8QEeTB0GS6VfLKnFa2uTUn14J.bVcG", "Gregory51" },
                    { 94, "$2a$11$06gRMw7dfCe9yNenPM7vBeWuitVltm.DJHjIDEJGAva2lGcS0U7Bu", "Duane.Bailey26" },
                    { 95, "$2a$11$fKIYssoACGwgbzqtl77na.8LttpmqT.8dbWUtueMB2sEw4r1T0GZ6", "Shelia.Satterfield" },
                    { 96, "$2a$11$FPahRNX24M0HBEmA/DgNiuA2XQ6F49BwIQ4rHaOszMWXkfYaFqB0m", "Desiree_Zboncak71" },
                    { 97, "$2a$11$TxnNsAwW11MIGVSKhAlRYOMChTHEoUXmHjB3QMDbgDO2qqbzwZE6u", "Vera_Mohr95" },
                    { 98, "$2a$11$AlrA8c5/3l5yYAg3fKkwPORKAL417hCsN/yVUbmxSl8/GRA/6H9Rq", "Lynda_DAmore" },
                    { 99, "$2a$11$wYyjgIOi7GUWqOjd8Q6hkerII9MjFo1UI2SeWZ/N74yC3.VtdLHKi", "Mercedes_Vandervort23" },
                    { 100, "$2a$11$JT.qMA1FIYIqgOACM5.c.usG8sRvOAB9P1l95ky7mhbivvKl0n9nu", "Ira_Rempel93" }
                });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "City", "Description", "ImageSource", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Goldenfurt", "Ex eaque sed ipsa dolorem ut minus et odio necessitatibus.", "https://picsum.photos/640/480/?image=209", "Eiffel tower", 80 },
                    { 2, "North Sharonland", "Molestias necessitatibus nihil veniam laboriosam porro est praesentium dicta doloribus.", "https://picsum.photos/640/480/?image=429", "Liseberg", 30 },
                    { 3, "Kochfort", "Sit a culpa et possimus possimus alias qui velit voluptatum.", "https://picsum.photos/640/480/?image=177", "Skansen", 55 },
                    { 4, "Port Abbigailberg", "Voluptate provident est odio aliquam architecto hic eius voluptatum placeat.", "https://picsum.photos/640/480/?image=604", "Empire State Building", 64 },
                    { 5, "Chelseahaven", "Veniam repellendus et cum sunt explicabo quaerat ipsum ea dolorem.", "https://picsum.photos/640/480/?image=115", "Eiffel tower", 98 },
                    { 6, "Trentonberg", "Quia distinctio molestiae alias ullam recusandae ipsam dolorem voluptas dolor.", "https://picsum.photos/640/480/?image=424", "Great Pyramid of Giza", 17 },
                    { 7, "Port George", "Vel nihil ad est possimus quia placeat aut deserunt sapiente.", "https://picsum.photos/640/480/?image=126", "Eiffel tower", 17 },
                    { 8, "Durganhaven", "Quis quod nam nihil id quo voluptas incidunt facere similique.", "https://picsum.photos/640/480/?image=102", "Empire State Building", 58 },
                    { 9, "Bauchmouth", "Molestias mollitia impedit earum soluta eligendi veritatis repellendus iste mollitia.", "https://picsum.photos/640/480/?image=454", "Great Pyramid of Giza", 26 },
                    { 10, "South Jaquelinemouth", "Adipisci placeat ipsam enim aut ut perferendis qui ducimus laboriosam.", "https://picsum.photos/640/480/?image=532", "Skansen", 58 },
                    { 11, "New Edgardo", "Quaerat dolorem voluptatem accusamus a deserunt dolor quod cupiditate suscipit.", "https://picsum.photos/640/480/?image=404", "Empire State Building", 15 },
                    { 12, "South Enosland", "Repellat ratione ut dolores ut quo aperiam cumque officiis rerum.", "https://picsum.photos/640/480/?image=1050", "Eiffel tower", 97 },
                    { 13, "Sylvestertown", "Libero numquam aut eius aut architecto eum voluptate porro corporis.", "https://picsum.photos/640/480/?image=324", "Eiffel tower", 84 },
                    { 14, "Schillerside", "Culpa earum quae aperiam quos minima praesentium repudiandae et aut.", "https://picsum.photos/640/480/?image=389", "Eiffel tower", 32 },
                    { 15, "Port Keyon", "Quis rerum nihil sapiente aut quibusdam et et qui quos.", "https://picsum.photos/640/480/?image=55", "Great Pyramid of Giza", 24 },
                    { 16, "Flossieside", "Odio quia et ipsa minus veritatis eos voluptas necessitatibus aut.", "https://picsum.photos/640/480/?image=380", "Great Pyramid of Giza", 6 },
                    { 17, "Port Noemie", "Voluptatem quam sit optio voluptas facilis est sunt occaecati qui.", "https://picsum.photos/640/480/?image=612", "Liseberg", 90 },
                    { 18, "East Reganshire", "Odit fugiat culpa vero nam quia est voluptates ipsa sequi.", "https://picsum.photos/640/480/?image=516", "Great Pyramid of Giza", 83 },
                    { 19, "South Ottomouth", "Et quisquam et qui est tempora commodi id possimus velit.", "https://picsum.photos/640/480/?image=546", "Skansen", 40 },
                    { 20, "Watersburgh", "Qui aut a officia labore ad itaque et recusandae ut.", "https://picsum.photos/640/480/?image=888", "Skansen", 54 },
                    { 21, "South Tiana", "Architecto ut quas dolores natus sint rerum quas tempore ipsa.", "https://picsum.photos/640/480/?image=356", "Eiffel tower", 41 },
                    { 22, "New Winnifred", "Eos ab tenetur expedita est est ullam alias numquam distinctio.", "https://picsum.photos/640/480/?image=875", "Great Pyramid of Giza", 100 },
                    { 23, "New Graysonville", "Odit cum placeat cum tempore blanditiis culpa voluptatem non accusamus.", "https://picsum.photos/640/480/?image=887", "Eiffel tower", 100 },
                    { 24, "Tiffanyport", "Praesentium dicta inventore a assumenda temporibus quam delectus est corporis.", "https://picsum.photos/640/480/?image=1077", "Empire State Building", 23 },
                    { 25, "Franciscastad", "Quibusdam ut laborum quo quam at iusto ipsa distinctio eaque.", "https://picsum.photos/640/480/?image=482", "Eiffel tower", 70 },
                    { 26, "West Christop", "Ut minus rerum doloribus dolore et quae impedit voluptas aperiam.", "https://picsum.photos/640/480/?image=238", "Empire State Building", 57 },
                    { 27, "Hauckville", "Nihil earum voluptate rerum perspiciatis nihil nulla dolore amet doloribus.", "https://picsum.photos/640/480/?image=701", "Great Pyramid of Giza", 75 },
                    { 28, "Port Marlon", "Voluptate est est aut et eos dolores ipsa reprehenderit neque.", "https://picsum.photos/640/480/?image=315", "Liseberg", 66 },
                    { 29, "Shayleeview", "Voluptatem amet itaque dolor ut et facere sit alias voluptatem.", "https://picsum.photos/640/480/?image=179", "Eiffel tower", 1 },
                    { 30, "Schoenborough", "Harum voluptatem saepe eos et ut et ab provident quas.", "https://picsum.photos/640/480/?image=268", "Skansen", 27 },
                    { 31, "Mooremouth", "Rerum unde dolores nihil dolor eveniet cum ipsa et voluptatem.", "https://picsum.photos/640/480/?image=182", "Liseberg", 17 },
                    { 32, "South Esthertown", "Ut eos nam sit possimus magnam magnam praesentium aut neque.", "https://picsum.photos/640/480/?image=776", "Liseberg", 75 },
                    { 33, "Osinskiside", "Quasi perferendis maxime ipsa et laudantium numquam non aut quo.", "https://picsum.photos/640/480/?image=444", "Eiffel tower", 64 },
                    { 34, "South Jaylonfurt", "Non tempore quia ipsum iste voluptate rerum inventore atque aut.", "https://picsum.photos/640/480/?image=267", "Skansen", 91 },
                    { 35, "North Breanamouth", "Et laboriosam doloribus voluptatem velit omnis qui occaecati sit modi.", "https://picsum.photos/640/480/?image=32", "Great Pyramid of Giza", 46 },
                    { 36, "West Shania", "Tenetur quod aut illum recusandae sed fugit tempore sit quia.", "https://picsum.photos/640/480/?image=597", "Empire State Building", 56 },
                    { 37, "East Sigurd", "Quas ab adipisci eos neque blanditiis ut similique sapiente ut.", "https://picsum.photos/640/480/?image=195", "Eiffel tower", 96 },
                    { 38, "Reichertview", "Et qui vero dolore vero veritatis dolores accusantium est dolor.", "https://picsum.photos/640/480/?image=1038", "Eiffel tower", 16 },
                    { 39, "Kubland", "Consequatur explicabo omnis saepe incidunt porro quis voluptatem assumenda illum.", "https://picsum.photos/640/480/?image=306", "Eiffel tower", 77 },
                    { 40, "Gutmannmouth", "Est aliquid dolorum adipisci voluptas vitae deserunt architecto recusandae laborum.", "https://picsum.photos/640/480/?image=88", "Eiffel tower", 2 },
                    { 41, "East Emmanuel", "Est aspernatur sapiente qui molestias omnis id consequatur dolore quod.", "https://picsum.photos/640/480/?image=400", "Great Pyramid of Giza", 32 },
                    { 42, "Yazminfurt", "Necessitatibus rerum quia inventore magni natus suscipit et aperiam doloribus.", "https://picsum.photos/640/480/?image=858", "Empire State Building", 59 },
                    { 43, "Quitzonview", "Sed expedita exercitationem quis reprehenderit deserunt necessitatibus sed accusamus cupiditate.", "https://picsum.photos/640/480/?image=802", "Empire State Building", 83 },
                    { 44, "Rachaelstad", "Voluptatem dolores ea molestiae laboriosam officiis commodi ullam dolorem temporibus.", "https://picsum.photos/640/480/?image=821", "Liseberg", 77 },
                    { 45, "Amandamouth", "Vel et impedit soluta temporibus nemo ut vel quis sint.", "https://picsum.photos/640/480/?image=926", "Eiffel tower", 51 },
                    { 46, "New Raystad", "Vel exercitationem sit est quae vel perferendis ea nihil consequatur.", "https://picsum.photos/640/480/?image=519", "Great Pyramid of Giza", 47 },
                    { 47, "Charlotteview", "Rerum necessitatibus sint dolores ut itaque id nisi vero aut.", "https://picsum.photos/640/480/?image=604", "Liseberg", 17 },
                    { 48, "Darebury", "Consequuntur quia sit sit porro quidem dolore tempore est est.", "https://picsum.photos/640/480/?image=601", "Empire State Building", 61 },
                    { 49, "Jenkinschester", "Commodi possimus voluptatem perspiciatis ab consequatur rerum veniam explicabo ullam.", "https://picsum.photos/640/480/?image=734", "Liseberg", 51 },
                    { 50, "Kaelynport", "Perspiciatis quia totam doloribus non tempore cum ex dolorem iusto.", "https://picsum.photos/640/480/?image=780", "Skansen", 68 },
                    { 51, "New Bereniceborough", "Ipsam ad doloribus quidem facilis rerum velit consequatur consequatur deleniti.", "https://picsum.photos/640/480/?image=286", "Empire State Building", 91 },
                    { 52, "Bergstrommouth", "Ullam saepe et illum nulla optio est eum accusamus optio.", "https://picsum.photos/640/480/?image=276", "Skansen", 13 },
                    { 53, "Leraport", "Et hic vitae quo beatae doloribus aut aliquam sed sunt.", "https://picsum.photos/640/480/?image=530", "Liseberg", 85 },
                    { 54, "Cruickshankport", "Aut aut rerum facilis voluptas et numquam doloribus sed ut.", "https://picsum.photos/640/480/?image=536", "Skansen", 60 },
                    { 55, "Davionport", "Qui rem exercitationem incidunt asperiores repellendus sunt voluptatem numquam dolores.", "https://picsum.photos/640/480/?image=824", "Skansen", 6 },
                    { 56, "Port Lauryshire", "Architecto sapiente non quis tempore consequatur dolor voluptas quaerat distinctio.", "https://picsum.photos/640/480/?image=493", "Great Pyramid of Giza", 42 },
                    { 57, "Lindstad", "Expedita rerum sunt ipsa optio repellendus ut iusto aliquid magnam.", "https://picsum.photos/640/480/?image=1056", "Skansen", 17 },
                    { 58, "Lake Todstad", "Voluptates blanditiis aliquid eos rem consequatur dignissimos quia perspiciatis minima.", "https://picsum.photos/640/480/?image=912", "Empire State Building", 84 },
                    { 59, "Port Bria", "Aperiam omnis ex repellendus voluptatem quaerat temporibus dolore nihil rerum.", "https://picsum.photos/640/480/?image=754", "Eiffel tower", 70 },
                    { 60, "West Abdulmouth", "Magni nemo atque dolores vel sunt eius minima qui deserunt.", "https://picsum.photos/640/480/?image=252", "Empire State Building", 55 },
                    { 61, "Lake Niachester", "Assumenda unde ut animi assumenda rerum debitis officia est ullam.", "https://picsum.photos/640/480/?image=291", "Empire State Building", 21 },
                    { 62, "Rexside", "Occaecati deleniti nisi sit est beatae ex ea voluptatem sint.", "https://picsum.photos/640/480/?image=403", "Liseberg", 33 },
                    { 63, "Noblestad", "Et temporibus nihil accusamus modi qui libero repellendus est maxime.", "https://picsum.photos/640/480/?image=234", "Empire State Building", 8 },
                    { 64, "Port Robinfort", "Et accusamus possimus voluptatem consequatur eius totam quaerat doloremque sed.", "https://picsum.photos/640/480/?image=854", "Empire State Building", 53 },
                    { 65, "Lilyanfurt", "Maiores et laboriosam adipisci quo qui quidem qui id omnis.", "https://picsum.photos/640/480/?image=59", "Liseberg", 53 },
                    { 66, "Brainfurt", "Quidem earum eligendi corrupti quasi quidem nisi consequuntur occaecati sequi.", "https://picsum.photos/640/480/?image=124", "Empire State Building", 82 },
                    { 67, "South Dallasburgh", "Iste placeat dolores reiciendis et magni officia voluptas magnam excepturi.", "https://picsum.photos/640/480/?image=1075", "Liseberg", 4 },
                    { 68, "Einarmouth", "Maiores natus velit est quam maxime et quo et rem.", "https://picsum.photos/640/480/?image=493", "Liseberg", 32 },
                    { 69, "Riceland", "Facere in et reiciendis aut ut iure rem id maxime.", "https://picsum.photos/640/480/?image=75", "Skansen", 34 },
                    { 70, "Rhodatown", "Et dolor dolorem et quis velit consequatur ullam fuga minima.", "https://picsum.photos/640/480/?image=804", "Great Pyramid of Giza", 58 },
                    { 71, "Port Margarettmouth", "Corrupti sint eum et quis et enim quia praesentium aut.", "https://picsum.photos/640/480/?image=842", "Eiffel tower", 45 },
                    { 72, "North Nelda", "Aliquid quos possimus veniam vero aut cumque suscipit dolorem ullam.", "https://picsum.photos/640/480/?image=483", "Eiffel tower", 14 },
                    { 73, "East Gertrude", "Eos sit temporibus at et omnis eius sed distinctio aut.", "https://picsum.photos/640/480/?image=1047", "Liseberg", 48 },
                    { 74, "Angelitaland", "Aperiam in cumque sunt nihil iste mollitia et qui ut.", "https://picsum.photos/640/480/?image=88", "Liseberg", 58 },
                    { 75, "West Glenda", "Commodi quas porro commodi id voluptate qui molestiae recusandae amet.", "https://picsum.photos/640/480/?image=1015", "Liseberg", 10 },
                    { 76, "Johannachester", "Consequatur culpa at ut officia itaque ea eaque aut ut.", "https://picsum.photos/640/480/?image=446", "Empire State Building", 10 },
                    { 77, "Lake Daija", "Laudantium id dolorem sed vitae quisquam quasi est a suscipit.", "https://picsum.photos/640/480/?image=422", "Empire State Building", 9 },
                    { 78, "New Santosview", "Et rerum laborum ut quia recusandae ut omnis recusandae facere.", "https://picsum.photos/640/480/?image=502", "Skansen", 64 },
                    { 79, "Hermantown", "Aspernatur recusandae ea corporis voluptatibus ut ratione voluptatibus aut consequatur.", "https://picsum.photos/640/480/?image=158", "Eiffel tower", 76 },
                    { 80, "Lake Amyton", "Aliquam consectetur doloremque quibusdam corrupti nesciunt voluptas aut modi ipsa.", "https://picsum.photos/640/480/?image=318", "Eiffel tower", 22 },
                    { 81, "Port Elliebury", "Ipsam doloribus ut veritatis consequuntur nesciunt provident dolor expedita dolor.", "https://picsum.photos/640/480/?image=663", "Empire State Building", 93 },
                    { 82, "South Brandon", "Non recusandae unde cum quia rerum doloremque sequi autem quae.", "https://picsum.photos/640/480/?image=712", "Liseberg", 85 },
                    { 83, "Katlynnhaven", "Voluptas quibusdam quo porro possimus rerum sint voluptates sit sit.", "https://picsum.photos/640/480/?image=888", "Great Pyramid of Giza", 47 },
                    { 84, "North Coleman", "Iure labore soluta sint tempora assumenda vel dolores ducimus eaque.", "https://picsum.photos/640/480/?image=975", "Skansen", 59 },
                    { 85, "Beahanside", "Doloremque est vero quo laboriosam perferendis quaerat nulla sapiente ratione.", "https://picsum.photos/640/480/?image=700", "Great Pyramid of Giza", 85 },
                    { 86, "New Omarimouth", "Assumenda rem magni nisi excepturi sed id in maxime qui.", "https://picsum.photos/640/480/?image=242", "Great Pyramid of Giza", 68 },
                    { 87, "Port Winnifred", "Sed expedita aut expedita in alias nulla est facere est.", "https://picsum.photos/640/480/?image=424", "Liseberg", 6 },
                    { 88, "North Kiana", "Quo autem et exercitationem recusandae rerum sed sed voluptates ea.", "https://picsum.photos/640/480/?image=374", "Great Pyramid of Giza", 46 },
                    { 89, "South Karianestad", "Inventore officiis nobis quibusdam sit quia sit voluptate distinctio molestiae.", "https://picsum.photos/640/480/?image=474", "Great Pyramid of Giza", 63 },
                    { 90, "Lonniemouth", "Ab facilis et nostrum eaque ullam et aut saepe tempore.", "https://picsum.photos/640/480/?image=783", "Liseberg", 75 },
                    { 91, "East Emmyview", "Nihil accusantium consectetur blanditiis et et sunt fuga quia neque.", "https://picsum.photos/640/480/?image=832", "Empire State Building", 15 },
                    { 92, "Swaniawskiborough", "Laborum harum est distinctio quia voluptas voluptatem voluptatibus aut pariatur.", "https://picsum.photos/640/480/?image=292", "Great Pyramid of Giza", 2 },
                    { 93, "Lehnertown", "Dicta rerum sequi modi earum rem aut maxime velit eveniet.", "https://picsum.photos/640/480/?image=63", "Liseberg", 10 },
                    { 94, "South Leslystad", "Facilis facilis sunt voluptatem quae laborum assumenda illum quia corrupti.", "https://picsum.photos/640/480/?image=951", "Empire State Building", 96 },
                    { 95, "Kundemouth", "Inventore ipsum consequatur qui ratione porro praesentium ut natus facilis.", "https://picsum.photos/640/480/?image=581", "Empire State Building", 50 },
                    { 96, "Tamiahaven", "Consequatur laboriosam ut voluptatum sapiente sint sit facere quasi aut.", "https://picsum.photos/640/480/?image=302", "Skansen", 68 },
                    { 97, "Grantmouth", "Qui laboriosam est molestiae saepe ad aliquam aut qui accusantium.", "https://picsum.photos/640/480/?image=696", "Empire State Building", 59 },
                    { 98, "Lake Susana", "Et est ut iure similique voluptatem sunt fugit officia sunt.", "https://picsum.photos/640/480/?image=630", "Great Pyramid of Giza", 98 },
                    { 99, "Lenoremouth", "Vel ut sunt quis eum harum quaerat cupiditate optio vel.", "https://picsum.photos/640/480/?image=463", "Empire State Building", 84 },
                    { 100, "Cummeratatown", "Reiciendis suscipit at adipisci et ipsum earum laudantium hic velit.", "https://picsum.photos/640/480/?image=405", "Eiffel tower", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AttractionId", "Commentary", "UserId" },
                values: new object[,]
                {
                    { 1, 27, "Sed modi quibusdam nemo facere quos nesciunt necessitatibus dolorem.", 18 },
                    { 2, 96, "Ducimus dolores consequatur adipisci quasi maiores.", 67 },
                    { 3, 83, "Rerum molestiae magnam labore.", 79 },
                    { 4, 61, "Dicta tenetur omnis autem cupiditate dolorem repellat molestiae qui.", 72 },
                    { 5, 50, "Dolore dolorem perferendis et consequatur quos.", 18 },
                    { 6, 35, "Id voluptatibus eos laudantium sint deserunt est repellat quasi id.", 8 },
                    { 7, 98, "Ipsa quia minima.", 75 },
                    { 8, 99, "Maxime dolorum sapiente totam tenetur odit autem reiciendis officia ut.", 89 },
                    { 9, 51, "Dolorem quae cum debitis aliquid laboriosam est.", 90 },
                    { 10, 66, "Necessitatibus eligendi soluta harum aut aut non est quis.", 98 },
                    { 11, 47, "Ab odio sequi dicta.", 75 },
                    { 12, 2, "Placeat ut quisquam et excepturi dolorum.", 76 },
                    { 13, 50, "Voluptatum aut esse rerum consequuntur.", 30 },
                    { 14, 32, "Vitae nisi voluptatem sed tempora nobis asperiores necessitatibus eos.", 31 },
                    { 15, 89, "Aut vitae fugiat doloribus saepe accusantium rem.", 41 },
                    { 16, 100, "Praesentium eius nihil harum ipsum blanditiis asperiores in maxime.", 20 },
                    { 17, 5, "Incidunt autem voluptatem vero.", 83 },
                    { 18, 14, "Omnis dolorum consequatur quidem cumque delectus.", 30 },
                    { 19, 59, "Eligendi voluptas alias hic optio debitis.", 53 },
                    { 20, 39, "Iure placeat dolorem omnis mollitia minima praesentium maiores autem quibusdam.", 35 },
                    { 21, 4, "Earum asperiores unde.", 43 },
                    { 22, 32, "Cupiditate et cum.", 3 },
                    { 23, 26, "Et ea quia eos delectus perferendis ipsam.", 68 },
                    { 24, 77, "Ipsa excepturi et voluptatem quas dicta quo quod incidunt corrupti.", 81 },
                    { 25, 22, "Necessitatibus amet dolore autem et suscipit rerum sit cupiditate.", 96 },
                    { 26, 76, "Quis et ea voluptatibus ipsa eligendi.", 50 },
                    { 27, 66, "Maiores temporibus qui voluptas perferendis perferendis numquam.", 79 },
                    { 28, 85, "Voluptas eveniet est omnis pariatur aut voluptates eum et.", 77 },
                    { 29, 48, "Ut rerum recusandae non placeat suscipit.", 30 },
                    { 30, 65, "Perspiciatis corrupti dolorem modi sed vel et at rem.", 28 },
                    { 31, 49, "Incidunt ut iure.", 59 },
                    { 32, 76, "Eaque repellat illo aut quaerat nesciunt.", 86 },
                    { 33, 67, "Iure aliquam deleniti velit qui asperiores ratione qui non praesentium.", 97 },
                    { 34, 27, "Aliquid quod quidem enim dicta veritatis aut laboriosam delectus et.", 52 },
                    { 35, 17, "Non in neque commodi enim doloribus voluptatem minima.", 18 },
                    { 36, 18, "Itaque a quidem.", 35 },
                    { 37, 90, "Aut et aut atque eum ut reprehenderit.", 30 },
                    { 38, 21, "Illo ut et quia sint officiis ut sapiente ea.", 7 },
                    { 39, 6, "Ea veritatis temporibus id excepturi sed enim qui nam deleniti.", 97 },
                    { 40, 43, "Nihil quos ratione non fuga.", 92 },
                    { 41, 17, "Temporibus et recusandae odio exercitationem ullam.", 66 },
                    { 42, 67, "Non delectus sint est.", 76 },
                    { 43, 69, "Dignissimos dolore esse ut fugit qui.", 33 },
                    { 44, 12, "Placeat pariatur et ut et ut possimus cum officia.", 83 },
                    { 45, 87, "Quo voluptatem culpa voluptas.", 95 },
                    { 46, 5, "Non facere ducimus doloremque corporis voluptate qui aspernatur.", 37 },
                    { 47, 50, "Quod quo necessitatibus quia maiores voluptatem unde temporibus ut.", 59 },
                    { 48, 89, "At praesentium maxime eum qui recusandae eum omnis.", 96 },
                    { 49, 59, "Ipsam aut aperiam.", 25 },
                    { 50, 7, "Dolor sapiente nam accusantium aspernatur rerum.", 84 },
                    { 51, 82, "Nemo aut porro hic aut sapiente.", 73 },
                    { 52, 64, "Omnis est odit velit in quia incidunt quasi maxime.", 15 },
                    { 53, 48, "Inventore ut deleniti quisquam ut autem omnis.", 92 },
                    { 54, 21, "Voluptatem nisi et non.", 65 },
                    { 55, 29, "Atque voluptatibus qui vel qui neque atque omnis eveniet voluptatibus.", 51 },
                    { 56, 50, "Impedit optio aut.", 6 },
                    { 57, 28, "Accusantium aut sint iste debitis voluptas quis iure non.", 65 },
                    { 58, 62, "Reiciendis aut voluptatem saepe.", 83 },
                    { 59, 78, "Quo ipsa tenetur nostrum.", 17 },
                    { 60, 12, "Quod exercitationem neque cumque dolor autem velit eos expedita.", 40 },
                    { 61, 54, "Accusantium impedit sint deleniti.", 47 },
                    { 62, 93, "Ducimus nulla animi eos odio maxime consequatur.", 10 },
                    { 63, 19, "Tempore voluptatem asperiores voluptatem voluptatem.", 88 },
                    { 64, 84, "Nihil laborum velit molestiae.", 5 },
                    { 65, 11, "Occaecati blanditiis excepturi.", 35 },
                    { 66, 22, "Fugit autem fuga rerum qui.", 69 },
                    { 67, 89, "Ipsum voluptas id voluptatibus quaerat labore asperiores facere alias.", 87 },
                    { 68, 40, "A non qui.", 91 },
                    { 69, 8, "Voluptates facilis quae.", 76 },
                    { 70, 10, "Consectetur vel ad dolores molestiae vel ab.", 48 },
                    { 71, 92, "Non placeat rerum magnam.", 53 },
                    { 72, 71, "Esse quia quos magni provident dolores a quia.", 91 },
                    { 73, 8, "Dolorem et distinctio ex nemo ipsum et sed aut.", 19 },
                    { 74, 95, "Distinctio omnis optio excepturi ipsa voluptas nesciunt.", 72 },
                    { 75, 1, "Veritatis et dolores ea beatae.", 63 },
                    { 76, 20, "Enim saepe omnis placeat optio qui quia reiciendis repellendus.", 39 },
                    { 77, 1, "Ullam soluta minus incidunt deleniti dolores.", 72 },
                    { 78, 56, "Vitae nihil odit.", 31 },
                    { 79, 98, "Voluptatum et ullam rerum deleniti.", 70 },
                    { 80, 46, "Ducimus sequi modi aut recusandae quod tempore repudiandae quaerat.", 8 },
                    { 81, 19, "Facilis architecto facere.", 15 },
                    { 82, 5, "Fuga porro iure et.", 56 },
                    { 83, 38, "Tempora et culpa corrupti fugit accusamus.", 80 },
                    { 84, 72, "Tempora nemo perspiciatis.", 97 },
                    { 85, 69, "Fuga libero qui aut quaerat.", 48 },
                    { 86, 38, "Voluptatem doloremque quae et ipsam dolorem aliquam accusamus praesentium.", 84 },
                    { 87, 67, "Saepe molestiae dolorum quos.", 22 },
                    { 88, 62, "Natus occaecati maxime.", 88 },
                    { 89, 16, "Quia aut sapiente.", 29 },
                    { 90, 61, "Magnam accusamus consectetur maiores sed eaque perspiciatis aliquam.", 4 },
                    { 91, 17, "Distinctio unde eos consectetur aperiam non aliquam facere corrupti aut.", 11 },
                    { 92, 53, "Reiciendis consectetur sed.", 13 },
                    { 93, 8, "Fuga ratione optio libero impedit.", 47 },
                    { 94, 14, "Nihil eos pariatur sunt sint in enim.", 86 },
                    { 95, 5, "Sunt et sequi dolor fugiat vel in eos velit laudantium.", 1 },
                    { 96, 95, "Magni optio quia quisquam quis et.", 85 },
                    { 97, 5, "Quo magni aut mollitia vel unde.", 22 },
                    { 98, 41, "Pariatur sequi natus.", 26 },
                    { 99, 86, "Expedita quia omnis ipsum iste incidunt esse qui sint libero.", 3 },
                    { 100, 13, "Aspernatur et commodi sit nihil incidunt similique et aut qui.", 75 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "AttractionId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 54, 51, 2 },
                    { 2, 22, 78, 1 },
                    { 3, 46, 63, 2 },
                    { 4, 43, 74, 2 },
                    { 5, 94, 78, 2 },
                    { 6, 56, 59, 2 },
                    { 7, 44, 86, 2 },
                    { 8, 5, 48, 1 },
                    { 9, 75, 18, 1 },
                    { 10, 77, 30, 1 },
                    { 11, 55, 43, 1 },
                    { 12, 41, 34, 1 },
                    { 13, 88, 88, 1 },
                    { 14, 37, 43, 1 },
                    { 15, 75, 76, 1 },
                    { 16, 5, 3, 2 },
                    { 17, 32, 85, 1 },
                    { 18, 95, 27, 1 },
                    { 19, 4, 21, 1 },
                    { 20, 73, 79, 1 },
                    { 21, 62, 61, 1 },
                    { 22, 51, 50, 2 },
                    { 23, 1, 35, 2 },
                    { 24, 30, 68, 2 },
                    { 25, 40, 100, 2 },
                    { 26, 28, 40, 2 },
                    { 27, 56, 89, 2 },
                    { 28, 78, 40, 2 },
                    { 29, 43, 46, 1 },
                    { 30, 99, 57, 2 },
                    { 31, 74, 87, 2 },
                    { 32, 74, 81, 1 },
                    { 33, 9, 67, 2 },
                    { 34, 100, 45, 1 },
                    { 35, 75, 85, 2 },
                    { 36, 76, 94, 1 },
                    { 37, 33, 42, 2 },
                    { 38, 6, 82, 2 },
                    { 39, 2, 57, 2 },
                    { 40, 52, 32, 2 },
                    { 41, 84, 82, 1 },
                    { 42, 96, 92, 2 },
                    { 43, 29, 9, 2 },
                    { 44, 15, 96, 2 },
                    { 45, 84, 3, 1 },
                    { 46, 92, 16, 1 },
                    { 47, 14, 66, 1 },
                    { 48, 62, 79, 1 },
                    { 49, 40, 48, 2 },
                    { 50, 93, 29, 1 },
                    { 51, 96, 68, 2 },
                    { 52, 38, 37, 1 },
                    { 53, 99, 86, 1 },
                    { 54, 12, 72, 2 },
                    { 55, 17, 71, 2 },
                    { 56, 8, 73, 1 },
                    { 57, 36, 32, 1 },
                    { 58, 72, 22, 2 },
                    { 59, 24, 100, 2 },
                    { 60, 78, 37, 2 },
                    { 61, 21, 29, 2 },
                    { 62, 40, 89, 2 },
                    { 63, 3, 45, 2 },
                    { 64, 21, 74, 2 },
                    { 65, 85, 47, 2 },
                    { 66, 26, 30, 1 },
                    { 67, 55, 99, 1 },
                    { 68, 49, 61, 1 },
                    { 69, 2, 35, 2 },
                    { 70, 92, 94, 2 },
                    { 71, 63, 55, 2 },
                    { 72, 98, 34, 2 },
                    { 73, 68, 58, 1 },
                    { 74, 94, 34, 2 },
                    { 75, 61, 94, 2 },
                    { 76, 39, 36, 2 },
                    { 77, 25, 79, 2 },
                    { 78, 60, 34, 2 },
                    { 79, 18, 34, 2 },
                    { 80, 64, 81, 2 },
                    { 81, 17, 86, 1 },
                    { 82, 66, 72, 1 },
                    { 83, 40, 51, 2 },
                    { 84, 29, 23, 2 },
                    { 85, 53, 7, 1 },
                    { 86, 47, 32, 1 },
                    { 87, 81, 6, 2 },
                    { 88, 31, 1, 1 },
                    { 89, 46, 56, 2 },
                    { 90, 97, 26, 1 },
                    { 91, 82, 12, 1 },
                    { 92, 75, 63, 2 },
                    { 93, 5, 29, 1 },
                    { 94, 31, 13, 2 },
                    { 95, 3, 93, 2 },
                    { 96, 16, 11, 2 },
                    { 97, 18, 13, 2 },
                    { 98, 90, 78, 1 },
                    { 99, 100, 90, 2 },
                    { 100, 77, 31, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_UserId",
                table: "Attractions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AttractionId",
                table: "Comments",
                column: "AttractionId");

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
