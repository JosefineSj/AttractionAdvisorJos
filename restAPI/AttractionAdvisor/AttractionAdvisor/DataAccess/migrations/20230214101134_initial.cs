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
                    { 1, "$2a$11$p/9Rj7yTwQm.O4ACAArJoeyOPaQDOz3CujCXsSwmbjnd8cXV5D5T2", "Stacy_Reinger60" },
                    { 2, "$2a$11$w/yJT.T19r/P8v1VisfEtOE7IUpD2RSkfdBvG8eItMTp0qkC/.pnu", "Emmett.Haley83" },
                    { 3, "$2a$11$HXqjE418A8xoOTZb2O7NluZBk9i95CunYV.0S0zu7O2fg.3ePWYSm", "Brittany16" },
                    { 4, "$2a$11$Ft./eYEoCL8dQlBQ7kr4s.bipPJQtCqxiIZjfpRJeSQW/IHaKYnP.", "Emmett88" },
                    { 5, "$2a$11$lamem18bgYTqbfOjUmBI3OS5b3xnw5Sc5DPSvT9VtC4olLZOniGfK", "Willard42" },
                    { 6, "$2a$11$zCrF43WUDmgSZaUG12s1qeSDEEtF1ZPgNFvSWEOM4sbr3X1h6OSs2", "Carroll68" },
                    { 7, "$2a$11$vdlDfXlva90rjCpvgxozr.ixPj2sxLGe3VZiHJx/qc8ZWMMBYeNJy", "Kelley_McLaughlin97" },
                    { 8, "$2a$11$SrBJAjyi9EjOAvtoEnRA0.WGCvOIekWue6bv3X8/Ro9T5xHzY3USi", "Barry_Kerluke" },
                    { 9, "$2a$11$QSE3AwMMiCnMWXDJmKP7COk9B2KqarsUJbsw81fRgOr23cPDaIqee", "Dewey.Schultz95" },
                    { 10, "$2a$11$ODomAwwBSLKJgFgSVLHKueVzWynyydvOyOWkpM6nmIx8n6s6570/S", "Percy_Koepp79" },
                    { 11, "$2a$11$NmAQA2DFn7w/oXFhjEGvluMn3y7QUzuSCf3qs2HChNejtH1pBU5cK", "Jo.Lynch35" },
                    { 12, "$2a$11$tPrQKp9tE89Pfc0uNJaWJeciakQfmhlgWtU/.Bkdy58X3y5kT1jK2", "Jose_Kuhic98" },
                    { 13, "$2a$11$JBDW4n91.a/LCDYi/qjB6uzZT7JfapNuHuBajUOr15iRywywb0zHW", "Dorothy25" },
                    { 14, "$2a$11$LHeY2EOy8PEZ4DwiqYYtxuNSFsbFxkQ5AMJngo4VUQ7s97HRequqe", "Virgil.Fadel23" },
                    { 15, "$2a$11$OtE55GF5Q.SmOXeWOcradOw.l/PtTEvtT5n0JhoHKi8RFw8VsPUxC", "Jean.Jones" },
                    { 16, "$2a$11$.wLrTojykWj4KmY0xmEcOON5mAefjk9CvMZfPW1v5vDub/ivagxFq", "Lauren_Stokes12" },
                    { 17, "$2a$11$fx.9ZRas4aCjDMuCc1Edt.cMPTftUJzFn8m1sZCz.ixY9tPe4a1va", "Candice_Mante20" },
                    { 18, "$2a$11$XnXlpOHdVQJEiOC0Qr6WxuGWTz4d72ZwE1yXSFQmzfP5dIvecyXje", "Olivia64" },
                    { 19, "$2a$11$1GJC4WoKLWiIzUHCODEKY.znGPbRXUXP0RMNFIKTQfsW.1Yz1TUaG", "Marian_Medhurst15" },
                    { 20, "$2a$11$YPoNjItr7OvjFb3w0eVgOuFJ2aRQbY1lZ5UwfndiRBhcAp7tT2z4S", "Jana_Carroll" },
                    { 21, "$2a$11$6rxQy2YkaTnFHAJGtUaKoORyqQasUMrh9eyi4KJ1dt36LJge5ev8m", "Sammy.Huels39" },
                    { 22, "$2a$11$OaJrhmy34riWX8vvuyXxvuezA6kamcnzeY29hg3OcCUNJOe8Z.EHK", "Jessie.Haley54" },
                    { 23, "$2a$11$ktEiLUZaT6/9k9Uy43CzLe/D20hGEG86pKIKZKTURrK7t84mH0WsG", "Laura.Bechtelar57" },
                    { 24, "$2a$11$NOWId81/2.xpZyEIhNSzs.nvQ8dulzPdB0LnXafIzNmLOzz2lkWeO", "Cornelius70" },
                    { 25, "$2a$11$PwMA7G0TQ.VFLJ2/7TcA9u/M/x75SCM.7vlkzAcSt0G0DVhywVyYS", "Joseph.Pouros" },
                    { 26, "$2a$11$wWbpH8NvkfO8UXS46aGzYuAlzHuOywLnlS8ADAJJOjbO72V5TLazy", "Valerie.Schmidt" },
                    { 27, "$2a$11$h.gh5j4HMGJ5.wm2VPYp.uWhmoMdqnZH6DLpKCFif9TXiYXAPHSp2", "Willie.Schowalter38" },
                    { 28, "$2a$11$A.L9HDqHaeV5OLg.oBFZruSQDwX6rqV4Ie/liL9mouVe/TKBsSD4i", "Darrel46" },
                    { 29, "$2a$11$Dig67CCMT3YQLYlKK7iMDuvjHQNAjImH4aHEkLYTxG3NJG4ALiDjm", "Wilfred_Grant35" },
                    { 30, "$2a$11$bGh4OJ/ehfUJnMT8MHqW5.w/QXYefMZP6y49RaD5IRN13.aWjinSa", "Vicki.Predovic58" },
                    { 31, "$2a$11$CBBYSD.3nRBx3Rewo7vt8.NNZW6mWfG8kSPJBdd1d.ec22wWeZDg.", "Eddie25" },
                    { 32, "$2a$11$i6vgd4KAngNomTo8iAKaXuw5MUFVl14ZKvBzM.r5FBSjT14uMLNGy", "Kathleen.Funk16" },
                    { 33, "$2a$11$Vl6IGFMRV/HPw68808MdeO/G0yzDTx9WOx.NM9rOien4vErUhgYfe", "Sarah.Dicki" },
                    { 34, "$2a$11$qBnccYLpFSG827CKPzXfb.jdpyo1PnfUvy4mFmUIxh09xzXaZ5Uby", "Drew2" },
                    { 35, "$2a$11$FkP7mc9JhHsujtgU6PYI5./zzLk01U55adS7DytotHwdICQCflKxu", "Cheryl_Ferry2" },
                    { 36, "$2a$11$qsNQPNplndS/MmPP/3y86unx9tacXkPF6/15UzEQjzfyQXwCWy7nG", "Lori_Hettinger" },
                    { 37, "$2a$11$t6Dkw4HxVCjOTejqzdOY4u0d4QJUtsI0n.xf9.PkvNZWDDmU//OHu", "Loretta_Stokes31" },
                    { 38, "$2a$11$nLLE9h865YzIZd544OOtTeEt2VyNOB2WaZ10QTge77uqvkakqxwOO", "Hattie_Feeney56" },
                    { 39, "$2a$11$JFt/jxAAR9wzszqKS.2nDedI2vfbP6ZuLPSNV8r6a6WqfRvRt5yXW", "Vicki_Goldner56" },
                    { 40, "$2a$11$pXnhm9OHChapmzQLVSVP5.c6Un67e5iZQ2.oW2/dDJ2yNDDSHN4oS", "Johnnie.Abbott6" },
                    { 41, "$2a$11$2POyKg6PrTq59EZpR3cuiOM6Wi.uPXE.goMe7UO2GlnNYxRDSapfm", "Loren.Ruecker" },
                    { 42, "$2a$11$21qQ97mWYPPvIEB9Y1X0IOcegSfN8Lv2nOvfn4Ld6DPf3RwjxgG3q", "Jana15" },
                    { 43, "$2a$11$DFCjFHcleFh19xfxRfQhzuf.eCOQsdFKUDyUBZhjrRcY2muAZFhOC", "Leland39" },
                    { 44, "$2a$11$VXRei3bBGc90JCKydY2hP.j57vXPUcwvLX7jz5L1Qo6tPGJGDdIRK", "Roxanne_Kuhlman" },
                    { 45, "$2a$11$hcHGyun1z4fnbEfNKpSqN.GHCxWB2LCQbVEpxGAga97lfRF2L588m", "Ben5" },
                    { 46, "$2a$11$.7vlKaBnCiLAN9soDRx9PuF086qYxswqK50zlUNOyIQe8d8WxzxtK", "Irene82" },
                    { 47, "$2a$11$Z4poDXIKfv2J25o5BNDlDu3y7FdvXjwWKL8U5P1ic7k7tsu0bO0wW", "Timmy_Langosh87" },
                    { 48, "$2a$11$VXhPQEDoYj.5eM4CWgZR5ewJ9P9mihv25dQ.lJWrNvqE//y3guEy.", "Glenn32" },
                    { 49, "$2a$11$mwTlrmIj4x03aXQZPxyiNO9VCjlKg15hMKvPEhZf5PyB58YIn1yhq", "Sam69" },
                    { 50, "$2a$11$62v/QmDQFtUZjt13tvEpZ.mm9zycT4CPue7YOLK7uZp.5ER5q5rHK", "Carol49" },
                    { 51, "$2a$11$LlKJyicFC/9/.IT/wX1qFOLLkgNKB6Bl0rFcjDxOwsY6jU9J7dBem", "Ernesto14" },
                    { 52, "$2a$11$y37XFJ4n5Tts9mGmoa1MRekCskqHPQkQv5/QWbCtZ1DtwuJKpjyuu", "Jaime67" },
                    { 53, "$2a$11$maa8tZQZBk8XGCxjNh06heDHIhM6kLuxsLYWQ8BkfQ8UKp/.8ifcW", "Roman75" },
                    { 54, "$2a$11$XKnjX7o.j94DEG59K6fObOFyPIuXmv64GYQ.zpbwYkqVfjbqTfmWe", "Jerry_Mosciski" },
                    { 55, "$2a$11$eEMquM4xkQtxagy6M3kDA.BW3u2lgMGjzw8AdPe1CcV6C6nFFccVm", "Charlie64" },
                    { 56, "$2a$11$XvAkdFl7QRYDgK9A5k7I9ORDvNE6g6t4n4zvvHD1Mi6h2T5uXwGUy", "Phil89" },
                    { 57, "$2a$11$5cBx0nBUamkzSN8MTr1jW.u.oKiBjgGPFOxsOZVqwyDn4jhdW7Gte", "Fannie_Lebsack" },
                    { 58, "$2a$11$2662YryMNRKj0ByVSSDT7OEYMCnPH.BiG9/D15H4FH3S7sFz79JQG", "Willard.Lebsack" },
                    { 59, "$2a$11$aE6oOTe.CKCn7EMTz8M83eAa7LL479XlhPCmG5/iHyk2p9xazIlxm", "Barbara51" },
                    { 60, "$2a$11$Iohl4If2BUs7RwRPGGBnZ.ibvlbNqy4EtlAzZcqoc5ZJUU3hoyIUG", "Marty.Stark57" },
                    { 61, "$2a$11$VJ.J53kKDQE9J2OnSKYEyueOO8Gp9yd.zBm0RVQNH6MgMap.YZ4Oa", "Alberta.Beahan30" },
                    { 62, "$2a$11$fEna/E/qJChVNCSYGEmE4uGACkkGrakNsZ2MtcTgqYcvgVoLaAB7a", "Freda.King42" },
                    { 63, "$2a$11$G6j4ghm/fl5WgrjDtev3UO4MAVqYazLR9ZOFJVG.PCzYe.ZvF6lV6", "Kara_Hagenes61" },
                    { 64, "$2a$11$CzoV.gKtw51zELkgSLFQAesyC3pgnyKofvawo5qle7H0HfrlOf/I6", "Franklin77" },
                    { 65, "$2a$11$rYmKXdJKcCOxoddMG7klGuo3VPpkQtom65fvRon2w7U7TmHNYggzG", "Jenna.Thiel" },
                    { 66, "$2a$11$TIiSgyphldP5Oc2MYE69SuVK9eGu3AiA2Vnxn97djjilPfITcyHnO", "Willie.Nolan" },
                    { 67, "$2a$11$GdUaMXK3i34Jkmn5Sqq8POE41c80nA34E/G0Lwnq/1IDaCjvmdxW2", "Dominic97" },
                    { 68, "$2a$11$07tFm9Fn40lZ3M6tWytCKu//SiGQZwh5dtHg5TFahX3uupbwVhZaq", "Willard81" },
                    { 69, "$2a$11$GlugjJ1rotFmUK9Dg.CMOuKIdPUCjWGmYcOC.da9d0t3T2P64ouEy", "Molly.Kozey" },
                    { 70, "$2a$11$oQ7/soHVgEN6kfT8ISsNQervek0Mb.5A7I35EIyvg0fbGnnB6AEOi", "Jared_Bednar41" },
                    { 71, "$2a$11$ITyc/SyOJ975dEDbRiCbXev8AQw.1aA2EuhUAp993PZIBiBO4.ew2", "Stella.Denesik" },
                    { 72, "$2a$11$vIUy3kV0E49YZLawVuqL6e7SdYZU6lqG/8y5tybDRyygHcUI5Ux/i", "Charlie53" },
                    { 73, "$2a$11$GVjCw3XcwtLg3ynnXUVTXOVGQNIKglkzUliquNn8bnaV0FbgKjW5C", "Domingo_Wilderman50" },
                    { 74, "$2a$11$/OoSq7mFKcoRGTxjvlRt2O.Rax2C8g09IZO2DGQRpmnajQ1fUMTga", "Christian97" },
                    { 75, "$2a$11$n7HKv8FU9NBWmZW3iUAiUe.Dy.TCbwwfUngMEvAaup9PPdEZsY/k.", "Charlie.Okuneva12" },
                    { 76, "$2a$11$arnYgi7S9i13uQuVrxbsduq914U.QSZ/Rn1NU0Ku1EL.7LHle/S1K", "Saul65" },
                    { 77, "$2a$11$xg/oD6gkY9CJecflXKVJquHg8jIT8wbdrUFbX3oqA1G9mnlhUMb..", "Katie.Douglas" },
                    { 78, "$2a$11$rNq1KC4TgfveGuX3OOQpdexQ9Etaw3uxj47Hy89DDPmBmMcsPpop6", "Vicki_Pfeffer" },
                    { 79, "$2a$11$6UdR8z41ZdVqTJbqpfIbLuIK6e9HdvIH23B0cBVsc3m/bH.iRf57i", "Edmund.Mann44" },
                    { 80, "$2a$11$D8DssKX.OUBuHfosw2UBmOfd7SbHaVdEWUsBvQxedg8UJ.2Bcnl0a", "Dexter_OConner25" },
                    { 81, "$2a$11$FgUT5cRshHO2XZvkbyHj5e8RzBJTlykC7OUIQVMWzLK.RRDireSMK", "Kerry.Bode" },
                    { 82, "$2a$11$8QtnJ0GDg3KPOccEj/7U6uuuxJ2tdnEuRiZ.rpxyfy4NIp7liQ9IG", "Sergio_Hills65" },
                    { 83, "$2a$11$oY6SOaPtzWXTnCk/c1QrIenjRSZveF3RPmUf2suusKseGgZlFWXne", "Hannah_Roob30" },
                    { 84, "$2a$11$7z9SNtVzBAtYbtpurU9s7uM1D2GjZRfSQXBrM4pdjhiDYdaytjUXK", "Glenda2" },
                    { 85, "$2a$11$YXFm5U47D1slaUTh7nv00.MP2KSEdBUOhHStUAMbHyBJofKLPL7pK", "Alejandro.Lang66" },
                    { 86, "$2a$11$NX/VtoWme2QyLRWo1J86B.LhHFytTWypt.eFBoCAi7tepedDG4cUe", "Kerry89" },
                    { 87, "$2a$11$6zz1VaSQfzHUegWgc65sSOiOWvZLO6iTKlkSntE.MXLmkhD9ItlOy", "Annette.Cruickshank" },
                    { 88, "$2a$11$Cxh7dWQOpMR91Z9Dig9kuO46h6kgkyOg.TskZ./v2Ipo8muADqgYq", "Laura.Lowe" },
                    { 89, "$2a$11$WjQJSCp6.gwD0GrfuS8McOExUnxvwcYZoDVVV9Qjagh3rR4TJm7Ri", "Gayle_Anderson55" },
                    { 90, "$2a$11$jBuEnPArfCN5fYGTaIPEteF5x080.d4hY2GcsXd9AITP4OOaZUnFi", "Gregory.Sporer" },
                    { 91, "$2a$11$Tqyo0H4f/HouutHV76w5cu5cBNEy24aXqphjTDF0W8K9lTuWTlIf.", "Dana_Pollich" },
                    { 92, "$2a$11$GKQOJATzw9EDb7.gO2TJWuJZ4YXQlhR4t8/FIfajJsZ8TsOdDewnq", "Vanessa.Wisoky" },
                    { 93, "$2a$11$LpVtJgFCWQPrRpp/7OEA6eyc4laVgc9XC2s9vPK1RX5IhFHhjk.Se", "Damon_Gibson90" },
                    { 94, "$2a$11$gNOg3YxVZFf7MIaPwiLxo.pJulw7SJ64I38SriLnvSlJu8DfvNXiy", "Ronald1" },
                    { 95, "$2a$11$fw9euw6wlq4IJvp/D9RkKegqEg0wvx9TbgOXCXbIsYnwk68ya6M/K", "Stacy.Nicolas" },
                    { 96, "$2a$11$Bt95FmE1Qzc1qIq5WVz/hOvY.cmfs/8bnWFdA9HtR5bLls0Psf/eu", "Blanche73" },
                    { 97, "$2a$11$PQ8QAigpSF.1hmUAtowu5utyvpvLolpXNQC/0hnRgsuGCT2EedHbm", "Lindsey.Carter13" },
                    { 98, "$2a$11$Z3bRdmpnTtJ5D1d2Affl6esUJ8dwY3vuWq/jsQ14SpYjvQ.B9q7ky", "Jenny.Smith" },
                    { 99, "$2a$11$RBL4Q2zvc5UHVVOEIoA81O2t8lMFqiNHjEZAtPXCYLJ1E.JGYQ66.", "Jeanne_Ebert45" },
                    { 100, "$2a$11$yjsl0uLfnyK0cqquEhhY5.5taaCexSk.yolSWSZ40sguzV/XobrLu", "Byron94" }
                });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "City", "Description", "ImageSource", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "West Lemuelfurt", "Eos fugit dolorem culpa dignissimos delectus non id repellendus suscipit.", "https://picsum.photos/640/480/?image=720", "Skansen", 70 },
                    { 2, "Wuckertmouth", "Vero esse sit modi aspernatur placeat eveniet voluptas corrupti explicabo.", "https://picsum.photos/640/480/?image=761", "Eiffel tower", 91 },
                    { 3, "South Karleeshire", "Fuga et sit eaque eum molestias deleniti qui sit neque.", "https://picsum.photos/640/480/?image=383", "Eiffel tower", 51 },
                    { 4, "Lake Foster", "Eius id dolores incidunt sit qui expedita distinctio dolorum fuga.", "https://picsum.photos/640/480/?image=278", "Eiffel tower", 16 },
                    { 5, "Boyerfort", "Neque est illum neque accusamus nihil aliquid animi consequatur distinctio.", "https://picsum.photos/640/480/?image=318", "Eiffel tower", 67 },
                    { 6, "East Karolann", "Non nesciunt eum dolor laudantium qui ut non aperiam quam.", "https://picsum.photos/640/480/?image=411", "Skansen", 36 },
                    { 7, "Mozellemouth", "Consequuntur provident cum fuga porro nihil expedita tenetur sed maxime.", "https://picsum.photos/640/480/?image=1046", "Empire State Building", 99 },
                    { 8, "West Alfred", "Quasi sed deleniti laudantium distinctio officia vel non expedita omnis.", "https://picsum.photos/640/480/?image=1053", "Liseberg", 3 },
                    { 9, "Gutmannport", "Debitis tenetur laboriosam qui quia sequi facilis vitae et unde.", "https://picsum.photos/640/480/?image=568", "Empire State Building", 52 },
                    { 10, "Lake Olen", "Similique ab est autem harum ut odio quia saepe architecto.", "https://picsum.photos/640/480/?image=148", "Skansen", 51 },
                    { 11, "Schneidershire", "Labore qui facere quae consectetur dolor voluptatum voluptatibus omnis ea.", "https://picsum.photos/640/480/?image=819", "Empire State Building", 75 },
                    { 12, "Priscillaside", "Atque enim laudantium voluptatem aut asperiores cumque ab eum ea.", "https://picsum.photos/640/480/?image=398", "Great Pyramid of Giza", 28 },
                    { 13, "Shawnafurt", "Nihil et eaque vero voluptatum vel qui omnis molestiae magnam.", "https://picsum.photos/640/480/?image=695", "Eiffel tower", 35 },
                    { 14, "Lockmanberg", "Ab incidunt qui molestiae eum vitae quia quia voluptates dolores.", "https://picsum.photos/640/480/?image=1084", "Empire State Building", 20 },
                    { 15, "Marvinton", "Cum ducimus saepe nisi odit earum minus est nihil atque.", "https://picsum.photos/640/480/?image=792", "Great Pyramid of Giza", 76 },
                    { 16, "East Wilfredo", "Dolor nihil recusandae eius similique aliquid numquam ullam iure nobis.", "https://picsum.photos/640/480/?image=56", "Great Pyramid of Giza", 61 },
                    { 17, "North Loraine", "Rerum qui veniam ipsa maiores cumque porro velit cupiditate amet.", "https://picsum.photos/640/480/?image=46", "Skansen", 79 },
                    { 18, "New Alicehaven", "Doloribus quam tenetur temporibus quisquam illo laudantium qui harum ipsa.", "https://picsum.photos/640/480/?image=1035", "Empire State Building", 99 },
                    { 19, "Lake Nevaberg", "In quos voluptatem vel molestias est harum voluptatibus consequuntur aut.", "https://picsum.photos/640/480/?image=821", "Empire State Building", 24 },
                    { 20, "North Malikaside", "Tempore suscipit iure enim id fugiat qui unde cum dolore.", "https://picsum.photos/640/480/?image=1018", "Empire State Building", 37 },
                    { 21, "South Phyllisstad", "Quos numquam sequi ipsam aut laborum consequuntur molestiae libero consequatur.", "https://picsum.photos/640/480/?image=597", "Skansen", 40 },
                    { 22, "Port Braulio", "Illo doloremque et asperiores modi iure excepturi pariatur officia consequatur.", "https://picsum.photos/640/480/?image=1062", "Empire State Building", 30 },
                    { 23, "Port Sandrine", "Voluptatem accusamus perspiciatis excepturi omnis sunt sit non voluptas est.", "https://picsum.photos/640/480/?image=416", "Empire State Building", 29 },
                    { 24, "New Rhodafort", "Qui enim laboriosam eveniet asperiores vel alias voluptatem eius quaerat.", "https://picsum.photos/640/480/?image=1030", "Empire State Building", 62 },
                    { 25, "Paulmouth", "Quis voluptates et eius dolore ut perferendis praesentium laboriosam possimus.", "https://picsum.photos/640/480/?image=782", "Liseberg", 14 },
                    { 26, "Aidanside", "Velit est et et voluptas modi corrupti quia magni accusantium.", "https://picsum.photos/640/480/?image=495", "Great Pyramid of Giza", 83 },
                    { 27, "Friesenmouth", "Facilis repudiandae quo natus numquam ut harum error et veritatis.", "https://picsum.photos/640/480/?image=10", "Empire State Building", 85 },
                    { 28, "Lake Darionmouth", "Aut qui ullam quo est nisi ad vel est inventore.", "https://picsum.photos/640/480/?image=376", "Empire State Building", 88 },
                    { 29, "New Dawnshire", "Corrupti soluta eligendi dolorem a autem quos in omnis nesciunt.", "https://picsum.photos/640/480/?image=915", "Great Pyramid of Giza", 58 },
                    { 30, "New Rachael", "Quia beatae dolores sit est tempora nihil rerum quidem voluptates.", "https://picsum.photos/640/480/?image=606", "Skansen", 75 },
                    { 31, "Port Elenorside", "Repellat atque quo beatae accusantium itaque doloribus incidunt quia provident.", "https://picsum.photos/640/480/?image=485", "Great Pyramid of Giza", 92 },
                    { 32, "Skileschester", "Consequatur perspiciatis voluptatem et consequatur soluta nesciunt laborum est natus.", "https://picsum.photos/640/480/?image=1035", "Great Pyramid of Giza", 64 },
                    { 33, "Port Eliseo", "Ut vero minus corporis minus quod accusamus eos iusto occaecati.", "https://picsum.photos/640/480/?image=162", "Eiffel tower", 25 },
                    { 34, "South Lonnieton", "Ipsam minus aut illo repudiandae nemo sit exercitationem et non.", "https://picsum.photos/640/480/?image=208", "Liseberg", 5 },
                    { 35, "Johnsport", "Porro vel qui earum doloribus quasi placeat ullam dolorum animi.", "https://picsum.photos/640/480/?image=705", "Liseberg", 39 },
                    { 36, "North Carmelberg", "Voluptatem esse modi illum et blanditiis sed quis rerum beatae.", "https://picsum.photos/640/480/?image=1017", "Great Pyramid of Giza", 5 },
                    { 37, "Port Lewborough", "Dicta enim magni et dolore dolore provident aut ut aut.", "https://picsum.photos/640/480/?image=153", "Eiffel tower", 59 },
                    { 38, "North Kristina", "Alias ea beatae quaerat laborum doloribus omnis vel minima dicta.", "https://picsum.photos/640/480/?image=318", "Great Pyramid of Giza", 2 },
                    { 39, "North Dulce", "Sed doloremque aut cupiditate minus repellendus deserunt ea velit est.", "https://picsum.photos/640/480/?image=457", "Liseberg", 93 },
                    { 40, "North Roderickfurt", "Ab iusto quo doloremque qui ullam alias est enim perspiciatis.", "https://picsum.photos/640/480/?image=973", "Eiffel tower", 5 },
                    { 41, "North Taureanborough", "Vero est et distinctio qui delectus ad adipisci ratione labore.", "https://picsum.photos/640/480/?image=807", "Great Pyramid of Giza", 46 },
                    { 42, "South Thurmanburgh", "Beatae qui vel sed corrupti provident inventore ut sit delectus.", "https://picsum.photos/640/480/?image=941", "Empire State Building", 51 },
                    { 43, "Port Kathryn", "Et in consequuntur praesentium recusandae fugiat aut consequuntur suscipit aut.", "https://picsum.photos/640/480/?image=766", "Skansen", 83 },
                    { 44, "East Adrien", "Consectetur rerum impedit quibusdam corporis explicabo impedit eligendi laborum et.", "https://picsum.photos/640/480/?image=619", "Liseberg", 53 },
                    { 45, "South Itzel", "Quia velit qui earum eos porro nulla nisi quae ex.", "https://picsum.photos/640/480/?image=841", "Great Pyramid of Giza", 82 },
                    { 46, "Efrenshire", "Eveniet repellendus voluptas quo et tempora optio et possimus laudantium.", "https://picsum.photos/640/480/?image=485", "Eiffel tower", 15 },
                    { 47, "Lake Camerontown", "Velit deserunt sunt nesciunt qui nihil vel eligendi consequatur quo.", "https://picsum.photos/640/480/?image=178", "Eiffel tower", 9 },
                    { 48, "Beattyburgh", "Tempora quidem reprehenderit consequatur rem laudantium sunt fugiat veniam saepe.", "https://picsum.photos/640/480/?image=59", "Eiffel tower", 41 },
                    { 49, "South Seamus", "Molestiae magni vel itaque ea eligendi iusto aut quidem consequatur.", "https://picsum.photos/640/480/?image=687", "Empire State Building", 50 },
                    { 50, "Port Albertoshire", "Ea et voluptas saepe magni voluptatem saepe id quia quis.", "https://picsum.photos/640/480/?image=1020", "Empire State Building", 85 },
                    { 51, "South Zeldaville", "Minima commodi inventore harum ut quo consequatur expedita aspernatur aut.", "https://picsum.photos/640/480/?image=322", "Empire State Building", 43 },
                    { 52, "South Mablehaven", "Et sit nihil ex tempora voluptatem vel et provident eum.", "https://picsum.photos/640/480/?image=28", "Empire State Building", 69 },
                    { 53, "New Jenniferborough", "Et quas nam consectetur autem rerum aut eligendi pariatur nesciunt.", "https://picsum.photos/640/480/?image=711", "Liseberg", 74 },
                    { 54, "Handton", "Ut alias autem sit nostrum nostrum ipsum impedit incidunt nisi.", "https://picsum.photos/640/480/?image=1063", "Skansen", 40 },
                    { 55, "North Cleta", "Quas ipsa doloribus dolor beatae sunt aut sint natus est.", "https://picsum.photos/640/480/?image=119", "Eiffel tower", 8 },
                    { 56, "Raynorland", "Distinctio ut assumenda repellendus voluptas et itaque ea non fugiat.", "https://picsum.photos/640/480/?image=84", "Skansen", 56 },
                    { 57, "West Hermannfurt", "Labore exercitationem quia quia quas dicta doloribus nisi eum deserunt.", "https://picsum.photos/640/480/?image=461", "Great Pyramid of Giza", 68 },
                    { 58, "East Abdielport", "Nemo consequatur in quos deleniti non eaque deleniti harum voluptatem.", "https://picsum.photos/640/480/?image=512", "Great Pyramid of Giza", 39 },
                    { 59, "Ritchiemouth", "Vel libero eum odio consequatur et ut cupiditate molestiae et.", "https://picsum.photos/640/480/?image=487", "Great Pyramid of Giza", 91 },
                    { 60, "Mackbury", "Iusto commodi ducimus et hic omnis nemo nobis velit reprehenderit.", "https://picsum.photos/640/480/?image=937", "Empire State Building", 15 },
                    { 61, "West Jacey", "Dolores omnis omnis ipsum omnis necessitatibus minus impedit quibusdam in.", "https://picsum.photos/640/480/?image=59", "Liseberg", 23 },
                    { 62, "New Anahiborough", "Eveniet nulla voluptate animi quae quia ut modi recusandae voluptatem.", "https://picsum.photos/640/480/?image=978", "Empire State Building", 70 },
                    { 63, "New Alfonzo", "Iste provident totam magni ipsum cumque quidem eligendi occaecati perferendis.", "https://picsum.photos/640/480/?image=64", "Liseberg", 74 },
                    { 64, "Generalhaven", "Est qui quia minus mollitia ea non provident quam perferendis.", "https://picsum.photos/640/480/?image=217", "Great Pyramid of Giza", 9 },
                    { 65, "Cristmouth", "Iure consequatur tempora et commodi voluptatem maxime quo impedit a.", "https://picsum.photos/640/480/?image=474", "Empire State Building", 70 },
                    { 66, "Townechester", "Tempore non quidem totam dignissimos molestiae atque maxime et dignissimos.", "https://picsum.photos/640/480/?image=599", "Empire State Building", 12 },
                    { 67, "Kraigside", "Nesciunt quia cupiditate aut porro esse labore ex qui exercitationem.", "https://picsum.photos/640/480/?image=135", "Skansen", 12 },
                    { 68, "New Jerroldhaven", "Similique ut accusamus voluptas voluptates officiis dolorum dolores reiciendis ipsum.", "https://picsum.photos/640/480/?image=194", "Skansen", 68 },
                    { 69, "Sonyamouth", "Sed corporis repudiandae pariatur accusantium eos iusto occaecati eveniet perferendis.", "https://picsum.photos/640/480/?image=567", "Liseberg", 40 },
                    { 70, "Lake Avery", "Non exercitationem velit quos et rerum deserunt enim aut accusamus.", "https://picsum.photos/640/480/?image=960", "Empire State Building", 36 },
                    { 71, "Fletcherside", "Suscipit in quia aut ab consequatur quas neque sequi sequi.", "https://picsum.photos/640/480/?image=991", "Empire State Building", 23 },
                    { 72, "Darionmouth", "Qui enim sed tempore in veritatis et aut cupiditate alias.", "https://picsum.photos/640/480/?image=221", "Great Pyramid of Giza", 58 },
                    { 73, "New Mason", "Sint sint impedit odit quo laboriosam error quasi tempora molestiae.", "https://picsum.photos/640/480/?image=1069", "Liseberg", 64 },
                    { 74, "Bechtelarton", "Ea quia at soluta voluptatibus quia et inventore doloremque consectetur.", "https://picsum.photos/640/480/?image=841", "Empire State Building", 28 },
                    { 75, "Robertchester", "Totam omnis beatae amet voluptatum qui molestiae impedit sit omnis.", "https://picsum.photos/640/480/?image=431", "Great Pyramid of Giza", 58 },
                    { 76, "Scottymouth", "Reprehenderit ut quis non porro ducimus id illum voluptatem et.", "https://picsum.photos/640/480/?image=565", "Skansen", 67 },
                    { 77, "Ritaport", "Facilis ratione unde aperiam aut laudantium accusantium eius perferendis placeat.", "https://picsum.photos/640/480/?image=858", "Liseberg", 94 },
                    { 78, "South Adela", "Et nihil consequatur enim ut et molestiae sequi magni quam.", "https://picsum.photos/640/480/?image=167", "Great Pyramid of Giza", 11 },
                    { 79, "Libbyland", "Quaerat aut eius dignissimos cumque sed perspiciatis et non dolor.", "https://picsum.photos/640/480/?image=799", "Eiffel tower", 54 },
                    { 80, "West Westonmouth", "Saepe et quod incidunt error dicta sed cum id deserunt.", "https://picsum.photos/640/480/?image=790", "Liseberg", 80 },
                    { 81, "Lake Hailee", "Debitis sapiente expedita molestias at recusandae quam voluptatum nam eveniet.", "https://picsum.photos/640/480/?image=489", "Liseberg", 36 },
                    { 82, "Schuppestad", "Sunt fugiat omnis pariatur itaque in esse molestias reprehenderit veniam.", "https://picsum.photos/640/480/?image=984", "Great Pyramid of Giza", 54 },
                    { 83, "Lake Alethastad", "Laboriosam dolore facere amet similique voluptatem et totam quibusdam cumque.", "https://picsum.photos/640/480/?image=635", "Eiffel tower", 35 },
                    { 84, "South Elouise", "Modi id repudiandae illum illum vitae odit hic ex laborum.", "https://picsum.photos/640/480/?image=100", "Great Pyramid of Giza", 98 },
                    { 85, "East Willa", "Assumenda rerum dolore rerum maxime consequatur autem et sunt iusto.", "https://picsum.photos/640/480/?image=797", "Eiffel tower", 67 },
                    { 86, "East Jamey", "Velit in nihil totam dignissimos consequatur aut distinctio hic aperiam.", "https://picsum.photos/640/480/?image=1054", "Great Pyramid of Giza", 77 },
                    { 87, "Port Eulaton", "Voluptas accusantium iure sed reprehenderit tempore dolorem ipsa esse rerum.", "https://picsum.photos/640/480/?image=816", "Great Pyramid of Giza", 23 },
                    { 88, "Feilport", "Voluptate distinctio placeat tenetur numquam temporibus recusandae quo et modi.", "https://picsum.photos/640/480/?image=253", "Eiffel tower", 76 },
                    { 89, "Ortizchester", "Voluptatum magnam sunt eius ipsum sed quisquam ut voluptas consequatur.", "https://picsum.photos/640/480/?image=872", "Skansen", 40 },
                    { 90, "Norafurt", "Quisquam aliquid id qui labore magni omnis nisi provident eveniet.", "https://picsum.photos/640/480/?image=362", "Eiffel tower", 59 },
                    { 91, "New Tyler", "Dignissimos voluptatem ipsam consectetur porro expedita fuga fugiat qui sequi.", "https://picsum.photos/640/480/?image=790", "Great Pyramid of Giza", 5 },
                    { 92, "Port Gunnartown", "Nisi deleniti corrupti ab architecto consequuntur ipsa rerum quibusdam libero.", "https://picsum.photos/640/480/?image=377", "Empire State Building", 25 },
                    { 93, "Therontown", "Provident natus nihil aut qui nesciunt aut sed omnis nam.", "https://picsum.photos/640/480/?image=662", "Eiffel tower", 13 },
                    { 94, "New Krystel", "Voluptate molestiae omnis aut amet omnis praesentium non hic nihil.", "https://picsum.photos/640/480/?image=833", "Great Pyramid of Giza", 74 },
                    { 95, "Martinburgh", "Est rerum molestiae repudiandae odit a qui quae voluptatem sequi.", "https://picsum.photos/640/480/?image=659", "Empire State Building", 57 },
                    { 96, "North Bernard", "Est deleniti aut est occaecati nam enim veritatis quas aut.", "https://picsum.photos/640/480/?image=205", "Eiffel tower", 93 },
                    { 97, "Port Randi", "Harum et iusto nemo sunt natus earum sunt dolorem aspernatur.", "https://picsum.photos/640/480/?image=545", "Skansen", 1 },
                    { 98, "Framiville", "Ipsum et et corrupti atque facere debitis vel ipsum nihil.", "https://picsum.photos/640/480/?image=46", "Empire State Building", 50 },
                    { 99, "East Herthashire", "Corporis officiis aliquam sint sint sunt nam rerum ea non.", "https://picsum.photos/640/480/?image=509", "Liseberg", 4 },
                    { 100, "East Abrahamburgh", "Blanditiis excepturi blanditiis earum laboriosam repellendus nisi unde quos consectetur.", "https://picsum.photos/640/480/?image=490", "Empire State Building", 43 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AttractionId", "Commentary", "UserId" },
                values: new object[,]
                {
                    { 1, 31, "Voluptas sit recusandae architecto.", 41 },
                    { 2, 64, "Ut assumenda nihil.", 13 },
                    { 3, 63, "Unde quia inventore.", 63 },
                    { 4, 93, "Harum ut quia sapiente ex consectetur unde iusto.", 43 },
                    { 5, 52, "Quas necessitatibus vel porro.", 4 },
                    { 6, 67, "Nihil eius vel nobis perspiciatis sed fugit.", 23 },
                    { 7, 78, "Qui ad iste unde.", 54 },
                    { 8, 65, "Sunt consequatur similique ullam.", 47 },
                    { 9, 65, "Rerum rerum saepe quidem cum.", 65 },
                    { 10, 33, "Adipisci id vitae commodi explicabo et molestiae occaecati suscipit.", 51 },
                    { 11, 50, "Et atque vitae ipsa voluptatem eveniet qui fugit sapiente.", 75 },
                    { 12, 36, "Consectetur magni reprehenderit aut eum voluptatem magnam.", 97 },
                    { 13, 99, "Incidunt labore et aliquid dolore quaerat veritatis cum.", 18 },
                    { 14, 87, "Et voluptatem consequatur.", 18 },
                    { 15, 29, "Et sint aut quia molestiae quam eveniet tenetur recusandae.", 79 },
                    { 16, 95, "Ducimus sed dolorem et at.", 72 },
                    { 17, 43, "Nostrum quo commodi id blanditiis explicabo voluptas consequuntur non ad.", 41 },
                    { 18, 12, "Eos sequi qui nulla quibusdam natus consequuntur dolorem iure.", 85 },
                    { 19, 25, "Non molestiae optio illum.", 43 },
                    { 20, 8, "Corporis deleniti nihil porro qui porro error.", 80 },
                    { 21, 78, "Rem molestias fugit.", 92 },
                    { 22, 96, "Sunt eaque nihil molestiae eum ab et optio exercitationem.", 47 },
                    { 23, 99, "Voluptatibus voluptatum et modi itaque rerum.", 20 },
                    { 24, 55, "Saepe impedit repellendus vitae sunt nostrum eaque accusamus fuga deleniti.", 40 },
                    { 25, 46, "Saepe autem minus vel similique labore.", 92 },
                    { 26, 16, "Earum totam assumenda eaque consequatur rem fuga harum ea corporis.", 66 },
                    { 27, 8, "Similique sit sed nobis facilis dolor est minima.", 97 },
                    { 28, 68, "Quo voluptatem vitae.", 30 },
                    { 29, 85, "Tempore aperiam facilis aut omnis nostrum perspiciatis consectetur culpa repellat.", 85 },
                    { 30, 55, "Sapiente magnam amet harum porro ipsam.", 9 },
                    { 31, 46, "Voluptatem repellendus sequi ullam nihil qui nemo vero.", 78 },
                    { 32, 96, "Dicta veniam ut ea vel.", 61 },
                    { 33, 72, "Optio cumque recusandae odit sed nam.", 95 },
                    { 34, 70, "Voluptas labore voluptatem quidem nihil dolorem dolores alias excepturi magni.", 3 },
                    { 35, 51, "In corporis iste.", 14 },
                    { 36, 99, "Voluptatem eum quasi molestiae beatae repellat voluptatem expedita sed.", 88 },
                    { 37, 6, "Veniam nemo ipsam quis ipsam.", 81 },
                    { 38, 52, "Nihil qui soluta ut.", 77 },
                    { 39, 74, "Odit ducimus ratione molestiae.", 89 },
                    { 40, 6, "Odio provident tempora voluptates quis quas amet natus quae.", 13 },
                    { 41, 39, "Iure omnis ratione aut enim.", 9 },
                    { 42, 8, "Saepe porro eum labore unde rerum sequi non sunt.", 83 },
                    { 43, 37, "Laborum maxime vero provident qui sed sint atque.", 88 },
                    { 44, 27, "Quidem at iure dolorem consequatur rerum.", 16 },
                    { 45, 23, "Esse aut aperiam vitae accusamus magnam debitis.", 21 },
                    { 46, 4, "Et est fugit.", 16 },
                    { 47, 25, "Exercitationem aliquid quis itaque perspiciatis.", 63 },
                    { 48, 86, "Expedita officia qui dolorum.", 46 },
                    { 49, 46, "Similique voluptatem aperiam.", 37 },
                    { 50, 5, "Nobis delectus eaque dicta placeat optio.", 82 },
                    { 51, 39, "Nobis dolores enim.", 7 },
                    { 52, 68, "Et consequatur quasi.", 35 },
                    { 53, 62, "Ipsum et aliquam excepturi fugiat qui molestiae asperiores.", 87 },
                    { 54, 41, "Vel tempora velit illo nemo ut saepe.", 9 },
                    { 55, 79, "Nobis est ipsa ullam voluptatem dolorum voluptates fugit aliquid.", 80 },
                    { 56, 24, "Recusandae ut cupiditate quasi quas numquam adipisci error cumque.", 22 },
                    { 57, 81, "Reiciendis magnam voluptatibus sed.", 16 },
                    { 58, 64, "Vitae minima consequatur molestiae in debitis qui maiores quia.", 51 },
                    { 59, 61, "Quae dolor et vel et.", 41 },
                    { 60, 48, "Reprehenderit esse et.", 50 },
                    { 61, 51, "Qui vero voluptatem corporis rerum laborum.", 34 },
                    { 62, 96, "Dolor et adipisci in iste maiores ut natus quasi et.", 14 },
                    { 63, 59, "In aut voluptatem fugiat voluptas laborum quae omnis est.", 26 },
                    { 64, 18, "Dolor eum corrupti fugiat quo beatae quam dolor.", 53 },
                    { 65, 82, "Et voluptas minima rerum cumque consectetur quasi repellat.", 29 },
                    { 66, 95, "Nihil molestiae qui delectus.", 50 },
                    { 67, 17, "Modi ab perspiciatis repellat.", 3 },
                    { 68, 58, "Sed natus delectus sit dolorem autem.", 13 },
                    { 69, 92, "Beatae voluptas ut voluptates quis.", 92 },
                    { 70, 50, "Placeat eaque id quidem.", 28 },
                    { 71, 68, "Et atque ducimus rerum quasi ratione assumenda.", 47 },
                    { 72, 74, "Mollitia nihil qui ut iure officiis similique.", 45 },
                    { 73, 42, "Eligendi sapiente expedita et doloribus dolores ut.", 19 },
                    { 74, 56, "Rerum et veritatis enim est quia.", 46 },
                    { 75, 20, "Et similique dolore eos et sit eos eius.", 35 },
                    { 76, 13, "Neque officiis in voluptas.", 73 },
                    { 77, 80, "Fugiat ex modi incidunt qui quia veniam et provident.", 38 },
                    { 78, 49, "Aut dolorem id minus harum qui mollitia alias voluptates sunt.", 42 },
                    { 79, 10, "Et quia inventore incidunt.", 36 },
                    { 80, 83, "Ab ullam laboriosam modi.", 34 },
                    { 81, 26, "Repudiandae placeat doloremque quas quaerat asperiores id et.", 30 },
                    { 82, 23, "Et dolores rerum in dolores exercitationem.", 68 },
                    { 83, 52, "Natus voluptas dolor consequatur.", 8 },
                    { 84, 53, "Consequatur autem possimus iste occaecati ullam est vel cupiditate ut.", 26 },
                    { 85, 77, "Minus error et qui.", 56 },
                    { 86, 71, "Qui enim corrupti.", 54 },
                    { 87, 16, "Autem non voluptas quia quos.", 51 },
                    { 88, 62, "Libero neque perspiciatis autem.", 70 },
                    { 89, 70, "Doloribus eaque quo eligendi ab ab.", 99 },
                    { 90, 4, "Eum illum neque et et eius adipisci voluptatum dolorem.", 95 },
                    { 91, 41, "Fuga culpa cum eos inventore commodi qui excepturi fugiat.", 52 },
                    { 92, 26, "Ut delectus corrupti.", 20 },
                    { 93, 89, "Suscipit optio dolorum omnis maxime.", 23 },
                    { 94, 4, "Autem vitae amet suscipit consequuntur.", 5 },
                    { 95, 36, "Eum hic explicabo voluptatibus et vel.", 31 },
                    { 96, 42, "Aperiam sit ab recusandae nobis cumque reprehenderit accusamus porro.", 33 },
                    { 97, 95, "Amet possimus aliquam quibusdam.", 90 },
                    { 98, 60, "Voluptatem quidem consequatur molestias ab sed consequatur qui reprehenderit.", 87 },
                    { 99, 31, "Voluptates repellendus laborum.", 67 },
                    { 100, 30, "Nam labore explicabo itaque dignissimos et qui possimus nisi et.", 35 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "AttractionId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 29, 20, 1 },
                    { 2, 39, 15, 1 },
                    { 3, 84, 70, 1 },
                    { 4, 85, 75, 2 },
                    { 5, 49, 39, 1 },
                    { 6, 69, 44, 1 },
                    { 7, 12, 10, 1 },
                    { 8, 13, 85, 1 },
                    { 9, 12, 68, 1 },
                    { 10, 98, 67, 2 },
                    { 11, 49, 62, 2 },
                    { 12, 64, 27, 2 },
                    { 13, 6, 53, 2 },
                    { 14, 25, 19, 1 },
                    { 15, 85, 14, 2 },
                    { 16, 60, 1, 1 },
                    { 17, 99, 58, 2 },
                    { 18, 43, 20, 1 },
                    { 19, 11, 100, 1 },
                    { 20, 57, 32, 1 },
                    { 21, 6, 71, 2 },
                    { 22, 42, 96, 1 },
                    { 23, 83, 69, 1 },
                    { 24, 73, 51, 1 },
                    { 25, 35, 5, 2 },
                    { 26, 3, 10, 2 },
                    { 27, 56, 3, 2 },
                    { 28, 71, 41, 1 },
                    { 29, 27, 24, 2 },
                    { 30, 75, 77, 1 },
                    { 31, 74, 39, 1 },
                    { 32, 57, 17, 1 },
                    { 33, 41, 23, 1 },
                    { 34, 32, 11, 1 },
                    { 35, 60, 56, 1 },
                    { 36, 3, 28, 1 },
                    { 37, 62, 96, 1 },
                    { 38, 41, 27, 2 },
                    { 39, 56, 44, 2 },
                    { 40, 93, 97, 2 },
                    { 41, 55, 94, 1 },
                    { 42, 15, 84, 2 },
                    { 43, 33, 56, 2 },
                    { 44, 14, 14, 1 },
                    { 45, 47, 93, 2 },
                    { 46, 36, 4, 2 },
                    { 47, 95, 100, 1 },
                    { 48, 74, 88, 1 },
                    { 49, 76, 7, 2 },
                    { 50, 92, 19, 1 },
                    { 51, 16, 24, 2 },
                    { 52, 92, 8, 2 },
                    { 53, 32, 67, 1 },
                    { 54, 14, 81, 2 },
                    { 55, 90, 50, 1 },
                    { 56, 26, 65, 1 },
                    { 57, 79, 43, 1 },
                    { 58, 92, 84, 1 },
                    { 59, 39, 76, 1 },
                    { 60, 69, 87, 2 },
                    { 61, 88, 5, 2 },
                    { 62, 6, 48, 2 },
                    { 63, 82, 80, 1 },
                    { 64, 83, 51, 2 },
                    { 65, 36, 69, 2 },
                    { 66, 31, 37, 1 },
                    { 67, 14, 83, 2 },
                    { 68, 3, 97, 2 },
                    { 69, 99, 73, 2 },
                    { 70, 24, 4, 1 },
                    { 71, 44, 20, 2 },
                    { 72, 81, 92, 2 },
                    { 73, 31, 11, 1 },
                    { 74, 16, 46, 2 },
                    { 75, 62, 71, 2 },
                    { 76, 96, 12, 1 },
                    { 77, 2, 61, 2 },
                    { 78, 1, 11, 2 },
                    { 79, 48, 86, 2 },
                    { 80, 85, 35, 1 },
                    { 81, 83, 92, 2 },
                    { 82, 89, 11, 1 },
                    { 83, 69, 70, 2 },
                    { 84, 46, 4, 1 },
                    { 85, 99, 90, 1 },
                    { 86, 1, 22, 1 },
                    { 87, 63, 50, 1 },
                    { 88, 49, 87, 2 },
                    { 89, 28, 5, 1 },
                    { 90, 37, 61, 2 },
                    { 91, 47, 63, 1 },
                    { 92, 84, 76, 1 },
                    { 93, 64, 58, 2 },
                    { 94, 58, 48, 1 },
                    { 95, 4, 24, 1 },
                    { 96, 45, 10, 1 },
                    { 97, 27, 40, 1 },
                    { 98, 20, 23, 2 },
                    { 99, 8, 25, 1 },
                    { 100, 9, 11, 2 }
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
