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
                    { 1, "$2a$11$YCUtumKygHTyZlsbHcNdj.EyUGeQIzIPdhT6HW2pW25ub1qQaH4fy", "Violet.Herzog" },
                    { 2, "$2a$11$bD9i718hHouKC8ULmiWqyur73GE0oEEn69DBCj17H.NhcGVNXFajK", "Hazel_Upton52" },
                    { 3, "$2a$11$kq1lyrp4YsnbexORwGljBeNrex4xNhGZRsQeL8GOn4bfepMlp2ugu", "Harry_DAmore37" },
                    { 4, "$2a$11$WspwjF3tM/PwVb70f3HuqO7g2N2dp4HOEdIeA4C6mjXssBb5aB.di", "Betsy15" },
                    { 5, "$2a$11$xru3/r1dAhIzCwrHqFLVbup4NErOHqYcyz7W41DErS/a0Q1dlSyKe", "Armando32" },
                    { 6, "$2a$11$LIRP/8jn8OdUVJJhJKgxEeWQsRs8vwC39fhMtQgD2yAnJnt5mn2eO", "Larry_Abernathy15" },
                    { 7, "$2a$11$ILLnfnN//3LiMImnTENwCOH7IE5cuXzCRuVD6PyVT2gOLIYDisUCy", "Myra58" },
                    { 8, "$2a$11$IX7u8IIw5qseGYQDEzg/0um9z/nq8KCR/vb8f9gODM3ZHGDjvORni", "Nathaniel24" },
                    { 9, "$2a$11$JBmglW9byjGID4EylqSJzOovFLEgwIt7IotOjRkUGkNGY5n2RAp5C", "Steven.Mosciski68" },
                    { 10, "$2a$11$qe0rW1gZll3owfxU/v32PeRsdtCIVYk5HyupdIM61L4UNz8MgvK9q", "Patricia58" },
                    { 11, "$2a$11$oI/txtwm44Fi/nBeDDgVoubqi5w7gRIAOjdgYJFmQq0otZi9rAWCi", "Edmund33" },
                    { 12, "$2a$11$cHXoCgXd2gqQ9kCKUqz/NOMXhBkY0rKiLFBILqLVzyIPc.EXlHy8W", "Esther90" },
                    { 13, "$2a$11$gF2n20sbfSJLad28nx32aOvCF.LPKIjwzliRN6Mqdna.hUCJvSp7C", "Raquel_Cremin62" },
                    { 14, "$2a$11$pbwmjouvufrfe0zpGcxUZOgY2zt0El8RLSrSva.kj43naw30ZFZiq", "Terrell_Kutch" },
                    { 15, "$2a$11$CECsubbqKVs.sO2pBgobaeV1Snk45P.kvXfdhnr0nENnGIP4mToOK", "Lonnie37" },
                    { 16, "$2a$11$Iy0o1ZNON/1PW.yEnmvoruHP4/gAhbT4hj64llQwohNTmdxQhPDFy", "Grace.Rosenbaum69" },
                    { 17, "$2a$11$QR07G7jjpiR38DnOFhZFseZZk8m/OWAOvPerLG81tggGHGaVv74I6", "Fernando.Balistreri92" },
                    { 18, "$2a$11$IJIanuc.i3ND4wAKUOZnnOhIRcfJvtNJtUcwCxVnZ4vv2i0FGT7/6", "Robyn_Mosciski7" },
                    { 19, "$2a$11$SbQBOF8Z5wKuF6GtqDlzneBcDjUV0vrX0MEfCdyR3sl7Weupm5.sq", "Charlie_Sporer" },
                    { 20, "$2a$11$IzRfYmr/XN0a3.5tyLHLBeYN02E7ziChdnKtgUh5tU1XAWjnKplgW", "Luz.Berge" },
                    { 21, "$2a$11$spTYG.IIs6KrABPdA3whdeB6GmwIWAzBAcENx46oYS41ML1lrAlgS", "Vincent_Koss17" },
                    { 22, "$2a$11$78KWUhQruCjS1z.ifuUf4uqSR0O5cljdO5oS4B9ErAzLKXH9ktmLa", "Shari.Gaylord" },
                    { 23, "$2a$11$B0eV8mIdZLMzi16R4dm2JeiWuJ.uGbHgSlDdk6VlpNIDqKr27C5SW", "Clay17" },
                    { 24, "$2a$11$O1hu1BaMc34sxXsASpXXVu2jNp3CKLFzTu42HI/AYpgAKr3K/m3OW", "Catherine84" },
                    { 25, "$2a$11$wB4olC4XEvJR37911YDGIu.PUIXFGdFAZ1hNawsloBCd3kr3fQGnu", "Randal.Stehr" },
                    { 26, "$2a$11$yOM0AcoOnsP1UNCbrL0XIOLcUVfSunj7a9PPNg/isd0AyL5zmJkDG", "Margaret_Koss97" },
                    { 27, "$2a$11$kDkjxKg3SeoM.J0d0QFiIOcanjMlVcPdAdafTmrjfw7A24aRl2k2K", "Claire78" },
                    { 28, "$2a$11$Dg3lUt.d4wZt9V2yeG/AFOy9oHq0TgNDImDlGnVaFug6iaTbKyKt.", "Bennie.Stracke" },
                    { 29, "$2a$11$1zF0zSUHoUMcldL31IDAYeYEAI3zOo91UNRpUXwnusiluxlKtKhYO", "Cecil_Halvorson46" },
                    { 30, "$2a$11$Wg1WfWkbt.1ZP/oF6xTzV.P7M2OyEhB3grvG8qFPCC9I1uWM3LBWW", "Angelina_Emmerich" },
                    { 31, "$2a$11$b0UYJDitCQv5atSxSEJw2e5jzp21Z9ZYy5J2tDPYj4KRKk5TfKrNS", "Jeanette.Ryan" },
                    { 32, "$2a$11$kmsWHoNfc5d0sQh3bWAH2eihQillgdV785UPs8n81Biq5YR4PbewC", "Abraham_Hartmann" },
                    { 33, "$2a$11$UCi1FUWvAP1rBoBznaCffe0cEt6rlFee..ewgUVtUhrRmgBEFf6h6", "Randal_Mosciski" },
                    { 34, "$2a$11$ZNNfVVC.O8AbMhQTl202Ae8xAYMPntR.AY02Wng2njUcgJ2ygZ0re", "Tami52" },
                    { 35, "$2a$11$yk8NqgsZyvph2kaCuHcJSO9t59Um0ObtuGq8RMR9t4B3gkwz1sHOy", "Patti24" },
                    { 36, "$2a$11$tUzFeo26nrkZGkFe5qGCW.ODtN9nWo.9ft7b0ouiMFEdqyKzRvsNO", "Ebony_Donnelly95" },
                    { 37, "$2a$11$WQcnyswGvPxZCv.IsUjXmOOgJYOqrfrFSiP9wTeeSpQe8/BGFI5GC", "Terry4" },
                    { 38, "$2a$11$CWpiFkDwGiIhY1JZ3vgpP./zTEbJDFXbgCDmEgcXfLaYpVAXJJEeW", "Roderick31" },
                    { 39, "$2a$11$SOHgxZTAsIu3E5N9rG5TfulSKUJ92PrEON67RrRpCo71VNWrBDXDG", "Allison.Schultz" },
                    { 40, "$2a$11$9jMNIW8yP3NSRjXAuD03yuFLbJRZyzZIE2vtWK6gXzjw9LWxFYTlW", "Jorge_Russel" },
                    { 41, "$2a$11$MNV02J90LGstPDkgiPilueyyeNVOWPvTOYxFU35cVKAPdxR9VajuO", "Jean53" },
                    { 42, "$2a$11$NwmMvYHPPQzj8L1cdCiim.jsQlrzTuzEVC02pxW8O1XINVXtqVuGm", "Yvette75" },
                    { 43, "$2a$11$HCkoHaqp0kLgYN7/pZOdzOGDkaA.E.pX3M3bjMwrzOmZF1n0oGnaK", "Maggie.Walker36" },
                    { 44, "$2a$11$v8AwDrPAoq9/QUg5cs.5a.W7chmXnvlGcWqKwG2C7Bd5rwkObxzF2", "Curtis_Feeney" },
                    { 45, "$2a$11$y9FxtbHh1G9ZZElAH9v95uDClKUMAJx8zwSDS.WaRBoXYsTVVocym", "Josh27" },
                    { 46, "$2a$11$3GRFxouqhsdVLR7X1Dg/0.2s1WXnfl1VLaCJoORPVH7JEHhYZ.7G6", "Erick_Hilll" },
                    { 47, "$2a$11$0NsWpK2DbBGKrL5ZIFSAp.qrh7aLSNt3kjuUNJSOyjnxDTesrUfym", "Esther16" },
                    { 48, "$2a$11$FC1TSaWEnUvOmjNXA.X2ku9ZWKolsymmuAXzAcPM6dYCbeZCPDAYK", "Blake77" },
                    { 49, "$2a$11$ypti39XEMMp29LL9CBAnFeVlPW7Lr9DSP5Gha.SoKOz4KKZXm02si", "Dustin_Davis80" },
                    { 50, "$2a$11$KXkqIfI7icXODjP9e/bmQOT4/KUN1vfY2WORV1Erc9DZb/apelUoi", "Ed.Cormier" },
                    { 51, "$2a$11$wBEvFcsXAPzwcPpyb1bOfOLmv6JbGXVX9C7AlNSdfOXRq0Ji/QrWq", "Phillip_Wiegand71" },
                    { 52, "$2a$11$KY6u6NYFpqjBdzGFlTGU8.LJQ1cEMHH9B/q3Xm.LrBI4Xox4IvAYC", "Brandi72" },
                    { 53, "$2a$11$qi2cIXlS9ZGLWeXP2mb0/uYHWclqOlP9dScE.KcMn9bjJ8VVSd1YK", "May_Greenholt" },
                    { 54, "$2a$11$Dp6UA8ZnSapDfsd1jmxcfuYeDF8mRdJ9Df.pteNpQC2pwQM.zJ3nG", "Javier.Wolff59" },
                    { 55, "$2a$11$VIPJFOOtiSwEVlmBWiySzeDqA0JKeQASK5EpiuC4X8XvxFXsF.Vq2", "Isaac.Veum62" },
                    { 56, "$2a$11$qvbPjzvE0APVuSO/R19CW.B9tcOGTh9fP5ijpJMtZDVfR4MUmpyr.", "Beatrice5" },
                    { 57, "$2a$11$Ho2id.X6iw7rlAbUYYkDn.EuKHPNM2GlFp4EuKyEDlp.z70BuFX3a", "Kellie_Weimann15" },
                    { 58, "$2a$11$0VLFZ6vgzMXTSChnfOuYYuhP5XVAhNuBlBMv/CU9eu33uLsUz7rYe", "Edith.McGlynn" },
                    { 59, "$2a$11$Q.Y2D5Cl/7FVQVAEDDHvQe7cwuaJWOzBiNeaOTP/p9Hc6cUNqv5uS", "Bertha29" },
                    { 60, "$2a$11$YlnBlUVz/GwpiJKckt.8fO7r8edhf85VgLPQghBq6byI5JOBBsi6K", "Peter.Koepp21" },
                    { 61, "$2a$11$ltW3Xd7R53.Bpa4HU5BWXOK9OEB0/hPJg4wXVoCnHtRPZbIUgCz4G", "Kirk_Swift34" },
                    { 62, "$2a$11$1/qfPkvQWMYbu1TiF49HW.IXrltH2SMzXJGPhxJWXJH.EU/DiaveW", "Kim_West78" },
                    { 63, "$2a$11$cy7o5Tq1rWwAryuNFVmpeuONeIou3o1QJokWnteXpuWAB0CMdA0Wy", "Evan_Grimes" },
                    { 64, "$2a$11$xLK1FE2GAQgAfGU6smntf.GTyvwtovwsho.nqYC4aA1AJJa/CY6UC", "Josh_Larkin34" },
                    { 65, "$2a$11$6DPmi3FSdDt467QtO1RNu.DIES1jWWD8vnygoEAuDGQnbIrWd1XaW", "Jacquelyn27" },
                    { 66, "$2a$11$uyXxc6cBod9eeZ44.0g41OBdwVxbjfg4O7OBSyVNe3hmPgvo.1hgu", "Blake.Zieme" },
                    { 67, "$2a$11$G2JEwRVkcC0pcF4KFwhfj.Aj99LAPangb74uPvJk0bd1Q6Pv9hWnq", "Glenda_Schmitt" },
                    { 68, "$2a$11$iHxedp6/Vn8qlYa3Antv4uLpNKtQCs5qtevSMrk9OIxV1jf2oz17K", "Nettie65" },
                    { 69, "$2a$11$iayi8PXvy70PzO0QnzgiZ.U5kze7UKgT.UPeBSitWwOwyet18H0ku", "Corey89" },
                    { 70, "$2a$11$LI8ghVbLDqkYXn9SyfrnJ.7nmGLDowmo2ie.2ROrv73BUE6vAfLuS", "Joyce59" },
                    { 71, "$2a$11$fFdO9QX0Oe.JFQIoyTf5iO9ME0H71VmLHgCpYWflQNktlQDbRcQ3i", "Abraham.Parisian" },
                    { 72, "$2a$11$IEr8YkbYR0HAQg9Tx0DK1.2GgTElfm5Wb0F5ogbVw99539nIiFlAi", "Maggie_Reichert14" },
                    { 73, "$2a$11$LKFCf0R0G9Ia6kMpjcvWHeFvX/cOl4jETxIb.9rtMXtrSWckCTFx2", "Erika_Deckow" },
                    { 74, "$2a$11$1VIHKFJrmb3r.txDU3F9b.Q8JyEJmU3D.0mDAWiDoOc.Dl6uHGj0y", "Peggy_Kutch" },
                    { 75, "$2a$11$XSgcf6QV5dQtxYkJ8kKheuAPcnQZm0DUFQKdBFIwGPJfgOX678OtS", "Tiffany_Armstrong55" },
                    { 76, "$2a$11$Y5y4v1Cw7VRV4E3PPiYq5epJEoyyLyQE2FaiDJlFV219kK3jh/.PS", "Josh85" },
                    { 77, "$2a$11$hGBTzl1ROutMdsSHQO22OejHsHGYWcuhcwPhArL9UvvVQro2jxf5u", "Nelson_Walter" },
                    { 78, "$2a$11$XJ/leuhdgoo0mfPPvqOa8etRNMY5ag3UA2rkKhWLGOnLBu/AAkk/S", "Sean.Ruecker39" },
                    { 79, "$2a$11$FowJWLcTZ5tuKjDttiDJM.s4CiEci5ASDkDVQwnuZrXbkCaVCIHCG", "Thomas16" },
                    { 80, "$2a$11$kXUZLjVdQy/ST5RYzYGq8e8VWV1vG7CQA4TsygXWE3gNP1SKA9ZNG", "Ann24" },
                    { 81, "$2a$11$.SrKCMZn/CP1zPB26UvGqOV9nX2QOR0lZRhtpaxkaiZAYBpyDVGDq", "Percy43" },
                    { 82, "$2a$11$I1FCQT1kcNM54H8pnZ1.L.5tSvqze1wxpaTHMlqOTXSIkJ5cfdi/2", "Ronnie.Kuvalis" },
                    { 83, "$2a$11$prRSn9VOKCbvJo4oVYRbJerC97TgQ7gbUaeJ0a71ZtDG8eL4Li1b2", "Alfred75" },
                    { 84, "$2a$11$TLR2Ym96Ky8oc4/Omux7CuObcfHEcoujsfxQgyH2fMYc.KW9ofj8m", "Ernestine.Bailey" },
                    { 85, "$2a$11$mnut76z2Au4iTamEiMeFQOoeuT2VRZaQc0NLuWnTNVp4xmlW9oqsW", "Ed.Deckow20" },
                    { 86, "$2a$11$wZIbj.nR2ioqDZPJPXrBcOJnKZj47tnZQyckrhz0nc8omaHaRdiWm", "Brandy.Collins" },
                    { 87, "$2a$11$w3/jBAss3d5tIOuY2AvM9.k4Nl2j7ekerg0iCGzICbAtdOdykUb1C", "Abraham.Witting" },
                    { 88, "$2a$11$EQkofdn2aUajBsPkCTzkfe8h6cfPH0fVUC1.2G8EtWlMXn2jFH5h2", "Juana_Ledner" },
                    { 89, "$2a$11$v78XI.UI1BGo90h/ksz3iei4VRxYjEVfjUHuBcqAoMUazBs/fSxb2", "Max.Kozey" },
                    { 90, "$2a$11$YeuQegNCLSAm0DCpcTIod.T37vLcxHWzClRp3OMJ6oxypYQtKvO6i", "Edmond_Russel32" },
                    { 91, "$2a$11$O6YH82pm.EH36otRpctF0.X57nPo6k5KIoFeN05EITA10OoQFvb32", "Cathy_Boehm18" },
                    { 92, "$2a$11$7UiYsvit.7EiaVBygGM5/u.nExw9slq/TMLays4yJTrURn3pzvZoW", "Kathleen_Bosco57" },
                    { 93, "$2a$11$2GlSVuIN4OGaTw8BYtsdouUhZ0wMo1d9/tcRolYM8Zr8NYPcLp1Y6", "Cody73" },
                    { 94, "$2a$11$eMpLA.5Dpcs16GSgGPEVFOqajitSIyIVKfge3GuOagA.CfKViIxjW", "Yolanda_Fahey97" },
                    { 95, "$2a$11$6aHhzGqFjXJ9fMcjG/P3j.NblOPQL/7mzhX9G93tyuSQyxjg/b.6.", "Louis_Abbott" },
                    { 96, "$2a$11$wmmqk5rw2dXwf1VW2e61ruDAdtQwazbEPk1F/sfHon0.GmCErGM/a", "Mandy.Wilkinson35" },
                    { 97, "$2a$11$ncMJYKhnX3DWH1Js9.mMaOjcKZk8I.vi9gjlujKws3BJq0TEYxQju", "Sandy83" },
                    { 98, "$2a$11$72WQjIdhRsl9YpHswwh2vuw25KcTOADS7utz1Im4vvDvyUxUChfhy", "Brittany_Walsh" },
                    { 99, "$2a$11$UytIWoLtev1rvFb4v1vWtuzsjnOaVEor/FVvkMYcS3f5ZJcFMUksi", "Rosalie54" },
                    { 100, "$2a$11$AmuHqAa4VdzABrT04fNFNeoVvpCS.m4BvjeEfDFLVn1ETuRgWer7O", "Jean41" }
                });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "City", "Description", "ImageSource", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "South Elaina", "Explicabo at quidem placeat excepturi earum et fugiat vel doloribus.", "https://picsum.photos/640/480/?image=436", "Skansen", 12 },
                    { 2, "Port Marilouborough", "Iste animi quia est quo iste commodi sit maiores a.", "https://picsum.photos/640/480/?image=743", "Empire State Building", 21 },
                    { 3, "Kingburgh", "Et hic minima accusantium facilis magnam neque doloremque ut exercitationem.", "https://picsum.photos/640/480/?image=520", "Great Pyramid of Giza", 10 },
                    { 4, "Lake Vicentechester", "Eaque tenetur rerum error at illo sint vero iste tempore.", "https://picsum.photos/640/480/?image=972", "Empire State Building", 23 },
                    { 5, "New Matteohaven", "Delectus suscipit explicabo error omnis ut veritatis recusandae vel quidem.", "https://picsum.photos/640/480/?image=698", "Eiffel tower", 4 },
                    { 6, "Maceyside", "Consequatur sequi necessitatibus quia maxime a neque adipisci deleniti expedita.", "https://picsum.photos/640/480/?image=329", "Empire State Building", 20 },
                    { 7, "West Madelynn", "Sapiente harum est libero et quisquam ab iure quo ut.", "https://picsum.photos/640/480/?image=125", "Empire State Building", 63 },
                    { 8, "Hauckland", "Facere sunt voluptates molestiae officiis illo aliquam non iure rerum.", "https://picsum.photos/640/480/?image=253", "Skansen", 53 },
                    { 9, "Schimmelborough", "Cum ut nisi exercitationem adipisci ut magnam ut iste et.", "https://picsum.photos/640/480/?image=222", "Great Pyramid of Giza", 4 },
                    { 10, "Janaetown", "Ea aut ullam non aut et a sunt sed nihil.", "https://picsum.photos/640/480/?image=906", "Liseberg", 24 },
                    { 11, "Port Kevin", "Molestiae eum delectus aliquid omnis aspernatur reiciendis consectetur distinctio omnis.", "https://picsum.photos/640/480/?image=828", "Great Pyramid of Giza", 73 },
                    { 12, "New Braden", "Voluptatem est fugit eum earum qui quia tempora repudiandae corrupti.", "https://picsum.photos/640/480/?image=460", "Liseberg", 66 },
                    { 13, "West Ruth", "Officiis laborum error cum provident impedit consequatur dolorem corrupti dolore.", "https://picsum.photos/640/480/?image=920", "Liseberg", 75 },
                    { 14, "South Callie", "Molestiae officia veniam amet porro sunt rerum officia incidunt aperiam.", "https://picsum.photos/640/480/?image=252", "Great Pyramid of Giza", 47 },
                    { 15, "Lake Genesis", "Quos ipsum officiis id facilis dolorem quia enim eum laudantium.", "https://picsum.photos/640/480/?image=508", "Empire State Building", 56 },
                    { 16, "Lubowitzton", "Aliquam veniam nobis sed commodi voluptate enim beatae iste laboriosam.", "https://picsum.photos/640/480/?image=793", "Eiffel tower", 7 },
                    { 17, "Alleneside", "Ea ipsum voluptatum eum nihil dolorem error deserunt quas impedit.", "https://picsum.photos/640/480/?image=307", "Empire State Building", 44 },
                    { 18, "Labadiemouth", "Asperiores quia incidunt amet qui blanditiis aliquam sunt voluptatum voluptas.", "https://picsum.photos/640/480/?image=356", "Empire State Building", 49 },
                    { 19, "Sporerport", "Eaque aut sit modi porro qui sapiente perferendis rerum ab.", "https://picsum.photos/640/480/?image=8", "Skansen", 21 },
                    { 20, "Vanessastad", "Doloremque eos quos aspernatur eveniet ut soluta sint alias quas.", "https://picsum.photos/640/480/?image=178", "Liseberg", 63 },
                    { 21, "West Lauraport", "Cumque quibusdam dolores eaque sed beatae aliquam totam similique maiores.", "https://picsum.photos/640/480/?image=201", "Empire State Building", 54 },
                    { 22, "Lemkeberg", "Dicta sed repudiandae vel at laboriosam dolorem illo corporis exercitationem.", "https://picsum.photos/640/480/?image=870", "Liseberg", 88 },
                    { 23, "Port Trenton", "Adipisci doloribus laborum maiores laborum necessitatibus eum asperiores eaque iusto.", "https://picsum.photos/640/480/?image=556", "Empire State Building", 75 },
                    { 24, "Daughertyfurt", "Tempora et sint fugit ut facilis delectus beatae libero dolores.", "https://picsum.photos/640/480/?image=798", "Empire State Building", 16 },
                    { 25, "Lillianville", "Modi quod perferendis odio minima dolor quas nobis quasi quasi.", "https://picsum.photos/640/480/?image=935", "Liseberg", 43 },
                    { 26, "Annabellbury", "Quod et voluptate consequatur amet velit illum ut vitae et.", "https://picsum.photos/640/480/?image=659", "Liseberg", 72 },
                    { 27, "Erikaland", "Quam voluptates qui est quia fugit id iusto provident maxime.", "https://picsum.photos/640/480/?image=785", "Skansen", 52 },
                    { 28, "Lake Cynthiamouth", "Natus repellat nam voluptatem dolore ut et est saepe quis.", "https://picsum.photos/640/480/?image=933", "Skansen", 50 },
                    { 29, "Rutherfordton", "Id dolor voluptas laboriosam tempore assumenda delectus voluptatem inventore nesciunt.", "https://picsum.photos/640/480/?image=453", "Liseberg", 20 },
                    { 30, "South Aureliemouth", "Suscipit quo ducimus quia ut laborum aspernatur ea harum dolorem.", "https://picsum.photos/640/480/?image=450", "Skansen", 47 },
                    { 31, "Langview", "Pariatur non cupiditate culpa qui ipsum sit natus repellat est.", "https://picsum.photos/640/480/?image=341", "Skansen", 52 },
                    { 32, "New Elton", "Eaque ad a laboriosam fugit ducimus occaecati eius molestiae est.", "https://picsum.photos/640/480/?image=820", "Great Pyramid of Giza", 13 },
                    { 33, "Mullerville", "Recusandae quo earum libero hic quasi placeat tempora libero maxime.", "https://picsum.photos/640/480/?image=180", "Empire State Building", 92 },
                    { 34, "Missourimouth", "Voluptatem neque minima dolores molestiae a et voluptas est possimus.", "https://picsum.photos/640/480/?image=617", "Great Pyramid of Giza", 64 },
                    { 35, "South Lurlinebury", "Aut tempore fugiat sint repellendus pariatur enim dolor voluptas eveniet.", "https://picsum.photos/640/480/?image=341", "Skansen", 39 },
                    { 36, "Heathcoteland", "Ipsum suscipit dolores deleniti in voluptatibus aliquid ipsum asperiores est.", "https://picsum.photos/640/480/?image=156", "Great Pyramid of Giza", 69 },
                    { 37, "Olenfurt", "Libero quos sed commodi ullam dolores quia in unde modi.", "https://picsum.photos/640/480/?image=733", "Skansen", 15 },
                    { 38, "Hoegershire", "Asperiores eum ut laborum nihil consequuntur maxime voluptatem corporis consequatur.", "https://picsum.photos/640/480/?image=707", "Empire State Building", 95 },
                    { 39, "Paucektown", "Facere et est rerum dolorum rerum ut quae voluptas mollitia.", "https://picsum.photos/640/480/?image=983", "Skansen", 87 },
                    { 40, "Port Buford", "Aut aperiam qui totam commodi asperiores saepe et placeat magni.", "https://picsum.photos/640/480/?image=316", "Empire State Building", 46 },
                    { 41, "Vonshire", "Tempore sequi tempore esse aut exercitationem exercitationem expedita doloremque eius.", "https://picsum.photos/640/480/?image=830", "Great Pyramid of Giza", 71 },
                    { 42, "North Leora", "Facilis omnis sapiente alias nostrum error assumenda dolorem sint odit.", "https://picsum.photos/640/480/?image=776", "Empire State Building", 4 },
                    { 43, "Port Kendallbury", "Inventore voluptatem praesentium cumque nihil et architecto autem dolorem cumque.", "https://picsum.photos/640/480/?image=80", "Great Pyramid of Giza", 98 },
                    { 44, "Lake Loyal", "Consectetur molestias ab sed nesciunt in inventore veritatis magni dolor.", "https://picsum.photos/640/480/?image=731", "Empire State Building", 32 },
                    { 45, "Port Jamarcusland", "Provident voluptatem consectetur aspernatur quisquam ea dolores dolorum sunt iste.", "https://picsum.photos/640/480/?image=136", "Eiffel tower", 17 },
                    { 46, "New Domenick", "Et illo et laboriosam natus iste ut saepe iusto sit.", "https://picsum.photos/640/480/?image=59", "Eiffel tower", 53 },
                    { 47, "Lynchfort", "Ut quia aut dignissimos ut quo eum est voluptatem asperiores.", "https://picsum.photos/640/480/?image=25", "Empire State Building", 46 },
                    { 48, "Albaborough", "Enim exercitationem tempore sit qui nihil est suscipit voluptatibus natus.", "https://picsum.photos/640/480/?image=166", "Liseberg", 28 },
                    { 49, "Hermanmouth", "Aut ex iure sit assumenda quo vitae deleniti maxime reiciendis.", "https://picsum.photos/640/480/?image=617", "Great Pyramid of Giza", 87 },
                    { 50, "Port Elmo", "Aliquid ut tenetur ea voluptatem cumque similique aut ut laborum.", "https://picsum.photos/640/480/?image=912", "Eiffel tower", 62 },
                    { 51, "Armstronghaven", "Magni dolorem eaque consequatur est voluptatum corporis quas dolorum consequuntur.", "https://picsum.photos/640/480/?image=875", "Empire State Building", 76 },
                    { 52, "Port Zakarymouth", "Occaecati esse vel aspernatur omnis provident ut dolores nemo nesciunt.", "https://picsum.photos/640/480/?image=643", "Empire State Building", 64 },
                    { 53, "Walkerport", "Ipsum voluptatem dolor minus explicabo aut nesciunt voluptas eos quos.", "https://picsum.photos/640/480/?image=362", "Great Pyramid of Giza", 18 },
                    { 54, "North Petehaven", "Nobis qui modi delectus delectus ullam possimus explicabo ad est.", "https://picsum.photos/640/480/?image=975", "Skansen", 19 },
                    { 55, "South Dillan", "Quia commodi quaerat hic adipisci aut rerum veniam commodi qui.", "https://picsum.photos/640/480/?image=304", "Empire State Building", 42 },
                    { 56, "Maudeport", "Sunt accusantium voluptatem aut ut repellendus ab nihil accusantium sint.", "https://picsum.photos/640/480/?image=220", "Great Pyramid of Giza", 31 },
                    { 57, "Heaneyshire", "Quod molestiae ut odio qui dolorem id laudantium non ea.", "https://picsum.photos/640/480/?image=1023", "Liseberg", 22 },
                    { 58, "Jacynthetown", "Est laudantium quia fugit illo aut et cumque qui in.", "https://picsum.photos/640/480/?image=763", "Skansen", 84 },
                    { 59, "Hansenhaven", "Incidunt enim doloremque non qui cum eligendi rem numquam quisquam.", "https://picsum.photos/640/480/?image=791", "Empire State Building", 17 },
                    { 60, "Batzbury", "Numquam deleniti rem a possimus saepe aperiam ut similique quibusdam.", "https://picsum.photos/640/480/?image=329", "Skansen", 93 },
                    { 61, "South Deondrefort", "Magni cum optio nihil facilis autem corporis vel ea cupiditate.", "https://picsum.photos/640/480/?image=96", "Empire State Building", 62 },
                    { 62, "Sanfordside", "Tempore beatae esse ut quo exercitationem accusantium suscipit tempore ipsa.", "https://picsum.photos/640/480/?image=287", "Great Pyramid of Giza", 63 },
                    { 63, "New Patsyland", "Dignissimos quia consequatur repellat sequi atque aut sit possimus et.", "https://picsum.photos/640/480/?image=961", "Skansen", 88 },
                    { 64, "North Cordiafort", "Nisi sunt animi voluptas perferendis dolorem non similique consequatur sint.", "https://picsum.photos/640/480/?image=863", "Empire State Building", 99 },
                    { 65, "Antoniohaven", "Reiciendis sint ipsum expedita qui occaecati aliquid consequatur enim mollitia.", "https://picsum.photos/640/480/?image=779", "Liseberg", 31 },
                    { 66, "Nitzschetown", "Deleniti ipsum dolor provident quaerat nulla repellendus itaque nam omnis.", "https://picsum.photos/640/480/?image=172", "Eiffel tower", 7 },
                    { 67, "Rainamouth", "Quia qui a excepturi magni nihil commodi dolores eius voluptatem.", "https://picsum.photos/640/480/?image=519", "Liseberg", 86 },
                    { 68, "Port Donnahaven", "Eos quia culpa possimus nobis autem ab et soluta est.", "https://picsum.photos/640/480/?image=767", "Liseberg", 93 },
                    { 69, "Cooperton", "Labore voluptas voluptatibus consequuntur perferendis impedit sit nemo non at.", "https://picsum.photos/640/480/?image=790", "Great Pyramid of Giza", 67 },
                    { 70, "Antwonview", "Aliquam ea non similique vel animi velit mollitia ut dolores.", "https://picsum.photos/640/480/?image=569", "Skansen", 45 },
                    { 71, "Woodrowchester", "Doloribus dolor hic recusandae quam repudiandae cum id autem quidem.", "https://picsum.photos/640/480/?image=208", "Skansen", 14 },
                    { 72, "Dachberg", "Non a rerum explicabo velit voluptatem dicta animi est nostrum.", "https://picsum.photos/640/480/?image=487", "Liseberg", 76 },
                    { 73, "Roobhaven", "Id minus eaque quo beatae omnis voluptatem quasi eos autem.", "https://picsum.photos/640/480/?image=86", "Eiffel tower", 9 },
                    { 74, "Koeppburgh", "Architecto ut expedita doloremque exercitationem nisi itaque doloremque totam laborum.", "https://picsum.photos/640/480/?image=344", "Eiffel tower", 78 },
                    { 75, "Kohlerhaven", "Eos reprehenderit quia autem ut voluptatem porro nostrum laborum voluptate.", "https://picsum.photos/640/480/?image=976", "Skansen", 69 },
                    { 76, "Imogenefurt", "Voluptatum rerum aperiam impedit quam magnam maiores non voluptate odit.", "https://picsum.photos/640/480/?image=316", "Skansen", 61 },
                    { 77, "North Erinborough", "Aut neque sint sed alias quaerat aut esse quia totam.", "https://picsum.photos/640/480/?image=426", "Skansen", 74 },
                    { 78, "Giovanniborough", "Dolores modi necessitatibus ea cupiditate ipsum dolores non maxime maxime.", "https://picsum.photos/640/480/?image=74", "Liseberg", 46 },
                    { 79, "Ullrichfort", "Magnam nihil inventore vel assumenda et harum itaque natus voluptatum.", "https://picsum.photos/640/480/?image=885", "Great Pyramid of Giza", 79 },
                    { 80, "East Jakobhaven", "Qui et quae dolorem hic quidem ab quia totam odio.", "https://picsum.photos/640/480/?image=1083", "Great Pyramid of Giza", 33 },
                    { 81, "Port Gabriella", "Aspernatur quis illum quae molestias dolor iusto voluptate molestiae doloremque.", "https://picsum.photos/640/480/?image=5", "Skansen", 79 },
                    { 82, "North Sylvestershire", "Recusandae aliquam optio nulla perspiciatis dolorem repellendus porro cum facere.", "https://picsum.photos/640/480/?image=984", "Eiffel tower", 59 },
                    { 83, "Lubowitzbury", "Et autem voluptatem consequatur totam odio non neque possimus neque.", "https://picsum.photos/640/480/?image=685", "Liseberg", 28 },
                    { 84, "Alessiaberg", "Deserunt ipsum est exercitationem minus pariatur dolor quibusdam sapiente reiciendis.", "https://picsum.photos/640/480/?image=738", "Liseberg", 81 },
                    { 85, "Cornellland", "Saepe necessitatibus atque dolores ullam est sed minima aperiam itaque.", "https://picsum.photos/640/480/?image=1066", "Great Pyramid of Giza", 50 },
                    { 86, "Haileyton", "Repellendus id aut voluptatem quia fuga minima voluptatem beatae totam.", "https://picsum.photos/640/480/?image=200", "Great Pyramid of Giza", 27 },
                    { 87, "South Erich", "Dolores beatae vitae voluptatum cumque voluptatem corrupti velit unde exercitationem.", "https://picsum.photos/640/480/?image=734", "Skansen", 38 },
                    { 88, "South Sadieville", "Similique eveniet non ut quibusdam fugit magni dolor nobis iure.", "https://picsum.photos/640/480/?image=643", "Empire State Building", 43 },
                    { 89, "New Daynetown", "Alias earum blanditiis laudantium eum veritatis at omnis et ut.", "https://picsum.photos/640/480/?image=208", "Eiffel tower", 41 },
                    { 90, "Lake Linnieburgh", "Numquam asperiores optio et tempora eaque molestiae voluptas dolorem neque.", "https://picsum.photos/640/480/?image=446", "Eiffel tower", 40 },
                    { 91, "West Savanna", "Qui ratione officia nostrum rem omnis porro illum modi veritatis.", "https://picsum.photos/640/480/?image=554", "Great Pyramid of Giza", 83 },
                    { 92, "New Jerad", "Sed tenetur explicabo qui earum veritatis aut voluptate ipsa dolores.", "https://picsum.photos/640/480/?image=503", "Great Pyramid of Giza", 64 },
                    { 93, "South Susiestad", "Et eum accusantium quibusdam sapiente recusandae repellendus quia soluta commodi.", "https://picsum.photos/640/480/?image=920", "Liseberg", 8 },
                    { 94, "Mabelleview", "Autem ratione non nesciunt et veritatis nostrum ea laborum aut.", "https://picsum.photos/640/480/?image=568", "Liseberg", 83 },
                    { 95, "Martychester", "Consequuntur incidunt doloremque magni maiores voluptatem ab perferendis qui non.", "https://picsum.photos/640/480/?image=637", "Liseberg", 29 },
                    { 96, "West Wallace", "Praesentium vel qui inventore quae est quam dolorum assumenda quo.", "https://picsum.photos/640/480/?image=357", "Eiffel tower", 56 },
                    { 97, "New Syble", "Voluptatem dolorem nam est eveniet quis quod inventore omnis consequatur.", "https://picsum.photos/640/480/?image=1037", "Empire State Building", 77 },
                    { 98, "Jamalchester", "Reiciendis voluptatum illum at quidem incidunt voluptate dolore eos harum.", "https://picsum.photos/640/480/?image=788", "Empire State Building", 22 },
                    { 99, "South Eli", "Et est velit et aut similique ut ipsum omnis velit.", "https://picsum.photos/640/480/?image=958", "Empire State Building", 67 },
                    { 100, "Fadelport", "Aut enim voluptatum enim aspernatur dolor fuga dolorum ea quo.", "https://picsum.photos/640/480/?image=608", "Skansen", 79 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AttractionId", "Commentary", "UserId" },
                values: new object[,]
                {
                    { 1, 96, "Et rerum temporibus id fugit amet totam.", 14 },
                    { 2, 82, "Ducimus enim quia quod velit culpa qui voluptatum.", 27 },
                    { 3, 82, "Quos quis aut omnis soluta id laudantium.", 45 },
                    { 4, 91, "Ab qui nihil.", 26 },
                    { 5, 5, "Aut id mollitia.", 91 },
                    { 6, 81, "Quisquam accusantium est at autem dolorum suscipit.", 84 },
                    { 7, 100, "Suscipit et mollitia quisquam.", 58 },
                    { 8, 68, "Iste debitis omnis explicabo.", 41 },
                    { 9, 35, "Praesentium debitis eos.", 11 },
                    { 10, 15, "Ut eum occaecati adipisci.", 2 },
                    { 11, 40, "Ipsa accusantium ullam perspiciatis ducimus aut repudiandae.", 91 },
                    { 12, 68, "Placeat voluptatum quia id quia maxime ipsa.", 83 },
                    { 13, 43, "Earum consequatur in est laboriosam soluta ex explicabo omnis.", 13 },
                    { 14, 18, "Numquam sed sit aut quo soluta dolor laudantium quia quia.", 71 },
                    { 15, 45, "Sed officiis velit sit alias aut non et architecto.", 5 },
                    { 16, 26, "Quis eveniet tenetur ipsa hic animi.", 8 },
                    { 17, 72, "Perferendis minima beatae quo dolor quis magnam.", 56 },
                    { 18, 53, "Quisquam quis dignissimos vel odio maiores.", 19 },
                    { 19, 75, "Ut sed illo quis nemo delectus temporibus laboriosam et.", 80 },
                    { 20, 78, "Doloremque enim aliquam in distinctio natus qui illo amet quas.", 1 },
                    { 21, 87, "Impedit sit ad ut illum.", 85 },
                    { 22, 70, "Illum fugit placeat voluptatem placeat ducimus beatae.", 86 },
                    { 23, 97, "Aut fugiat hic.", 73 },
                    { 24, 31, "Ut occaecati tenetur illo ut quae dolorem velit earum.", 91 },
                    { 25, 62, "Aut ut atque modi eos provident fugit.", 56 },
                    { 26, 83, "Molestiae error quis soluta aut.", 24 },
                    { 27, 40, "Enim quia voluptate nisi neque dolores.", 96 },
                    { 28, 33, "Non nisi consequatur corporis ipsum numquam corporis autem illum odit.", 60 },
                    { 29, 58, "Molestias ut quaerat temporibus.", 44 },
                    { 30, 15, "Quia qui dolor eligendi.", 87 },
                    { 31, 83, "Rerum tempora minus aut eius et saepe officiis.", 29 },
                    { 32, 16, "Temporibus magnam debitis perferendis similique sequi molestias iure.", 79 },
                    { 33, 30, "Repellendus et aperiam et nihil ea consequatur.", 42 },
                    { 34, 64, "Aut quo perspiciatis.", 19 },
                    { 35, 72, "Dolores recusandae ullam delectus quo hic non.", 9 },
                    { 36, 68, "Molestiae optio quo minus nisi dolorem.", 78 },
                    { 37, 25, "Sed atque nulla esse alias.", 95 },
                    { 38, 75, "Ratione et qui ea distinctio itaque distinctio in ut aliquid.", 38 },
                    { 39, 47, "Quae asperiores est.", 41 },
                    { 40, 71, "Et nisi cum illo id eos mollitia accusamus dolor.", 7 },
                    { 41, 49, "Aperiam nobis beatae eaque dolorem maxime porro.", 68 },
                    { 42, 75, "Distinctio blanditiis maxime provident cumque nobis officia nobis vero.", 51 },
                    { 43, 14, "Quae nobis impedit architecto.", 98 },
                    { 44, 44, "Eum error sed aspernatur nulla omnis.", 61 },
                    { 45, 11, "Est voluptatem doloremque voluptatem ut quae.", 79 },
                    { 46, 98, "Atque saepe harum reiciendis at magni a consectetur asperiores.", 59 },
                    { 47, 58, "Voluptates culpa consectetur voluptatem facilis suscipit esse.", 98 },
                    { 48, 26, "Ut doloribus suscipit.", 56 },
                    { 49, 21, "Perferendis maxime at laboriosam et reiciendis sit tempora saepe.", 40 },
                    { 50, 47, "Ad voluptatem quo.", 36 },
                    { 51, 71, "Eveniet eum tempore accusamus.", 25 },
                    { 52, 38, "Doloribus tempora quod.", 32 },
                    { 53, 67, "Debitis quod molestiae non blanditiis quae delectus beatae.", 72 },
                    { 54, 11, "Maiores in sint quia.", 18 },
                    { 55, 24, "Minima ut natus voluptatem dolor dolores dolores nihil deleniti voluptas.", 97 },
                    { 56, 20, "Eaque culpa est exercitationem assumenda quia quia odit.", 66 },
                    { 57, 28, "Rem dolorem sit consequatur.", 99 },
                    { 58, 48, "A est deleniti aperiam.", 19 },
                    { 59, 90, "Qui consequuntur alias eos qui ad.", 77 },
                    { 60, 4, "In perferendis quisquam quaerat eligendi illo laudantium molestiae aut.", 58 },
                    { 61, 73, "Id voluptates occaecati ea inventore molestiae eos.", 33 },
                    { 62, 34, "Rem natus odit aliquam explicabo non dolorem maiores repudiandae et.", 56 },
                    { 63, 27, "Omnis molestiae officia nisi aut nam.", 54 },
                    { 64, 79, "Error quidem ut rem qui.", 6 },
                    { 65, 27, "Sed minima velit omnis est nesciunt qui.", 23 },
                    { 66, 37, "Accusantium numquam asperiores id a voluptas.", 82 },
                    { 67, 97, "Est nam tempora tempore vel.", 87 },
                    { 68, 84, "Non quia aperiam qui fugit.", 85 },
                    { 69, 15, "Deserunt aliquam similique voluptatem.", 60 },
                    { 70, 45, "Aspernatur aperiam tenetur qui.", 41 },
                    { 71, 75, "Culpa sint ipsa exercitationem autem suscipit molestias aut.", 70 },
                    { 72, 21, "Tenetur corporis ea inventore hic.", 56 },
                    { 73, 44, "Qui debitis optio culpa est.", 19 },
                    { 74, 23, "Laudantium consequuntur omnis enim explicabo est quo.", 93 },
                    { 75, 23, "Deleniti quis facere quis et autem suscipit.", 39 },
                    { 76, 31, "Consequatur nisi officiis non assumenda.", 88 },
                    { 77, 17, "Facilis voluptatem nihil.", 7 },
                    { 78, 95, "Libero sunt vel magnam.", 84 },
                    { 79, 15, "Porro repellat laudantium veniam saepe ipsa laboriosam dolores.", 77 },
                    { 80, 83, "Voluptatem ut necessitatibus omnis vero et assumenda dolor qui facilis.", 17 },
                    { 81, 4, "Ut enim id voluptatibus iste atque voluptates ab non.", 44 },
                    { 82, 46, "Blanditiis aut voluptatem.", 46 },
                    { 83, 5, "Sunt debitis sint nisi aut eveniet facilis sint doloremque.", 24 },
                    { 84, 71, "Nemo harum facere.", 33 },
                    { 85, 60, "Nihil et ut.", 59 },
                    { 86, 50, "Eos vero ea.", 43 },
                    { 87, 32, "Nam quibusdam labore sed perspiciatis sit repudiandae optio.", 19 },
                    { 88, 9, "Animi quis aspernatur neque iste et.", 71 },
                    { 89, 1, "Adipisci aliquam corporis.", 50 },
                    { 90, 55, "At autem ipsam et dicta voluptatum atque et quibusdam.", 93 },
                    { 91, 46, "Earum omnis deleniti et id voluptates labore maiores.", 12 },
                    { 92, 47, "Eius deleniti cum magni qui ea quasi nemo.", 93 },
                    { 93, 14, "Eaque in nulla illo nihil esse in.", 6 },
                    { 94, 22, "Et quas dignissimos quis nesciunt.", 66 },
                    { 95, 50, "Ea rerum deserunt distinctio et exercitationem earum consectetur est.", 68 },
                    { 96, 35, "Rerum tempore quisquam et fugit sint.", 82 },
                    { 97, 35, "Saepe voluptatem omnis.", 100 },
                    { 98, 56, "Quidem laborum doloribus excepturi mollitia corrupti.", 6 },
                    { 99, 60, "Ipsum sit sunt ad facere laboriosam.", 7 },
                    { 100, 44, "Iste quaerat minus aspernatur tenetur illum.", 15 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "AttractionId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 93, 90, 1 },
                    { 2, 1, 42, 1 },
                    { 3, 50, 61, 1 },
                    { 4, 23, 65, 1 },
                    { 5, 66, 1, 2 },
                    { 6, 92, 62, 1 },
                    { 7, 86, 47, 2 },
                    { 8, 20, 96, 2 },
                    { 9, 20, 61, 1 },
                    { 10, 76, 61, 1 },
                    { 11, 45, 40, 2 },
                    { 12, 90, 59, 2 },
                    { 13, 99, 95, 1 },
                    { 14, 22, 91, 1 },
                    { 15, 25, 78, 1 },
                    { 16, 52, 67, 1 },
                    { 17, 98, 25, 2 },
                    { 18, 62, 74, 2 },
                    { 19, 21, 34, 2 },
                    { 20, 73, 57, 1 },
                    { 21, 64, 33, 1 },
                    { 22, 15, 17, 1 },
                    { 23, 45, 31, 1 },
                    { 24, 97, 68, 1 },
                    { 25, 99, 41, 1 },
                    { 26, 57, 4, 1 },
                    { 27, 33, 67, 1 },
                    { 28, 39, 55, 1 },
                    { 29, 88, 72, 1 },
                    { 30, 35, 21, 2 },
                    { 31, 89, 70, 1 },
                    { 32, 25, 32, 2 },
                    { 33, 16, 23, 2 },
                    { 34, 23, 15, 2 },
                    { 35, 39, 50, 1 },
                    { 36, 34, 87, 2 },
                    { 37, 91, 44, 2 },
                    { 38, 81, 81, 1 },
                    { 39, 47, 84, 1 },
                    { 40, 77, 13, 2 },
                    { 41, 35, 83, 2 },
                    { 42, 85, 10, 1 },
                    { 43, 6, 17, 2 },
                    { 44, 37, 45, 2 },
                    { 45, 100, 46, 1 },
                    { 46, 35, 97, 2 },
                    { 47, 59, 94, 1 },
                    { 48, 48, 30, 1 },
                    { 49, 98, 61, 1 },
                    { 50, 47, 71, 2 },
                    { 51, 72, 31, 2 },
                    { 52, 44, 62, 1 },
                    { 53, 22, 60, 2 },
                    { 54, 68, 80, 1 },
                    { 55, 23, 76, 1 },
                    { 56, 45, 72, 2 },
                    { 57, 5, 48, 1 },
                    { 58, 70, 34, 2 },
                    { 59, 93, 97, 1 },
                    { 60, 86, 20, 2 },
                    { 61, 11, 15, 1 },
                    { 62, 27, 73, 2 },
                    { 63, 77, 98, 1 },
                    { 64, 72, 19, 2 },
                    { 65, 97, 20, 1 },
                    { 66, 94, 74, 1 },
                    { 67, 47, 31, 2 },
                    { 68, 25, 76, 2 },
                    { 69, 73, 20, 2 },
                    { 70, 12, 96, 2 },
                    { 71, 76, 67, 1 },
                    { 72, 3, 23, 1 },
                    { 73, 26, 95, 2 },
                    { 74, 29, 100, 1 },
                    { 75, 37, 61, 2 },
                    { 76, 63, 8, 1 },
                    { 77, 38, 92, 2 },
                    { 78, 36, 68, 2 },
                    { 79, 11, 73, 1 },
                    { 80, 97, 25, 1 },
                    { 81, 9, 16, 2 },
                    { 82, 79, 95, 2 },
                    { 83, 58, 22, 2 },
                    { 84, 30, 22, 1 },
                    { 85, 18, 9, 1 },
                    { 86, 72, 86, 1 },
                    { 87, 66, 100, 2 },
                    { 88, 63, 65, 1 },
                    { 89, 79, 90, 2 },
                    { 90, 46, 87, 1 },
                    { 91, 76, 95, 1 },
                    { 92, 93, 76, 1 },
                    { 93, 13, 51, 1 },
                    { 94, 24, 76, 2 },
                    { 95, 73, 46, 2 },
                    { 96, 100, 3, 1 },
                    { 97, 23, 29, 2 },
                    { 98, 52, 64, 2 },
                    { 99, 33, 64, 1 },
                    { 100, 17, 74, 1 }
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
