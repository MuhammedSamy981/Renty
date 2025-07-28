using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnionArchitectureODataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datetime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Report = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electrical Appliances" },
                    { 2, "Clothes" },
                    { 3, "Bags" },
                    { 4, "Shoes" },
                    { 5, "Books" },
                    { 6, "Laptops" },
                    { 7, "Mobiles & Tablets" },
                    { 8, "Bikes & Motorcycles" },
                    { 9, "Electronic Games" },
                    { 10, "Kitchen Tools" },
                    { 11, "Furniture & Decor" },
                    { 12, "Sports Tools" },
                    { 13, "Cameras" },
                    { 14, "Cars & Trucks" },
                    { 15, "Hunting Tools and Equipment" },
                    { 16, "Medical Tools and Equipment" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "EGYPT" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Cairo" },
                    { 2, 1, "Giza" },
                    { 3, 1, "Alexandria" },
                    { 4, 1, "Dakahlia" },
                    { 5, 1, "Red Sea" },
                    { 6, 1, "Beheira" },
                    { 7, 1, "Fayoum" },
                    { 8, 1, "Gharbia" },
                    { 9, 1, "Ismailia" },
                    { 10, 1, "Monofia" },
                    { 11, 1, "Minya" },
                    { 12, 1, "Qalyubia" },
                    { 13, 1, "New Valley" },
                    { 14, 1, "Suez" },
                    { 15, 1, "Aswan" },
                    { 16, 1, "Assiut" },
                    { 17, 1, "Beni Suef" },
                    { 18, 1, "Port SaId" },
                    { 19, 1, "Damietta" },
                    { 20, 1, "Sharqia" },
                    { 21, 1, "South Sinai" },
                    { 22, 1, "Kafr El Sheikh" },
                    { 23, 1, "Matrouh" },
                    { 24, 1, "Luxor" },
                    { 25, 1, "Qena" },
                    { 26, 1, "North Sinai" },
                    { 27, 1, "Sohag" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "15 May" },
                    { 2, 1, "El-Azbakeya" },
                    { 3, 1, "El-Bostan" },
                    { 4, 1, "El-Tebbin" },
                    { 5, 1, "El-Khalifa" },
                    { 6, 1, "El-Darasa" },
                    { 7, 1, "El-Darb El-Ahmar" },
                    { 8, 1, "El-Zawya El-Hamra" },
                    { 9, 1, "El-Zeitoun" },
                    { 10, 1, "El-Sahel" },
                    { 11, 1, "Peace" },
                    { 12, 1, "SayyIda Zeinab" },
                    { 13, 1, "Sharabia" },
                    { 14, 1, "Shorouk City" },
                    { 15, 1, "Al-Zahir" },
                    { 16, 1, "Al-Attaba" },
                    { 17, 1, "new Cairo" },
                    { 18, 1, "Al-Marg" },
                    { 19, 1, "Ezbet El-Nakhl" },
                    { 20, 1, "Al-Matariya" },
                    { 21, 1, "Maadi" },
                    { 22, 1, "Maasara" },
                    { 23, 1, "Mokattam" },
                    { 24, 1, "El Manial" },
                    { 25, 1, "El Mosky" },
                    { 26, 1, "El Nozha" },
                    { 27, 1, "El Waili" },
                    { 28, 1, "Bab El Shaaria" },
                    { 29, 1, "Boulaq" },
                    { 30, 1, "Garden City" },
                    { 31, 1, "Gardens Dome" },
                    { 32, 1, "Helwan" },
                    { 33, 1, "Dar El Salam" },
                    { 34, 1, "Shubra" },
                    { 35, 1, "Tora" },
                    { 36, 1, "Abdeen" },
                    { 37, 1, "Abbasiya" },
                    { 38, 1, "Ain Shams" },
                    { 39, 1, "Nasr City" },
                    { 40, 1, "new Cairo" },
                    { 41, 1, "Old Cairo" },
                    { 42, 1, "Manshiyat Nasser" },
                    { 43, 1, "Badr City" },
                    { 44, 1, "Obour City" },
                    { 45, 1, "Downtown" },
                    { 46, 1, "Zamalek" },
                    { 47, 1, "Qasr El Nil" },
                    { 48, 1, "El Rehab" },
                    { 49, 1, "Katameya" },
                    { 50, 1, "Madinaty" },
                    { 51, 1, "Rawd El Farag" },
                    { 52, 1, "Sheraton" },
                    { 53, 1, "Gamaleya" },
                    { 54, 1, "10th of Ramadan" },
                    { 55, 1, "El-Helmeya" },
                    { 56, 1, "new Nozha" },
                    { 57, 1, "Administrative Capital" },
                    { 58, 2, "Giza" },
                    { 59, 2, "6th of October" },
                    { 60, 2, "Sheikh Zayed" },
                    { 61, 2, "Al-Hawamdiya" },
                    { 62, 2, "Al-Badrashin" },
                    { 63, 2, "Al-Saff" },
                    { 64, 2, "Atfih" },
                    { 65, 2, "Al-Ayat" },
                    { 66, 2, "Al-Bawiti" },
                    { 67, 2, "Mansha'at Al-Qanater" },
                    { 68, 2, "Oseem" },
                    { 69, 2, "Kerdasa" },
                    { 70, 2, "Abu Al-Numrus" },
                    { 71, 2, "Kafr Ghatati" },
                    { 72, 2, "Manshaet El Bakary" },
                    { 73, 2, "Dokki" },
                    { 74, 2, "El Agouza" },
                    { 75, 2, "El Haram" },
                    { 76, 2, "El Warraq" },
                    { 77, 2, "Imbaba" },
                    { 78, 2, "Boulaq El Dakrour" },
                    { 79, 2, "El Wahat El Bahariya" },
                    { 80, 2, "El Omrania" },
                    { 81, 2, "El-Monib" },
                    { 82, 2, "Bayn El-Sarayat" },
                    { 83, 2, "Kit Kat" },
                    { 84, 2, "El-Mohandeseen" },
                    { 85, 2, "Faisal" },
                    { 86, 2, "Abu Rawash" },
                    { 87, 2, "Ahram Gardens" },
                    { 88, 2, "El-Haraniya" },
                    { 89, 2, "October Gardens" },
                    { 90, 2, "Saft El-Laban" },
                    { 91, 2, "Smart Village" },
                    { 92, 2, "Lion Land" },
                    { 93, 3, "Abu Qir" },
                    { 94, 3, "Ibrahimiya" },
                    { 95, 3, "Azareeta" },
                    { 96, 3, "Anfoushi" },
                    { 97, 3, "Dakhila" },
                    { 98, 3, "Syouf" },
                    { 99, 3, "Al-Ameriya" },
                    { 100, 3, "Al-Luban" },
                    { 101, 3, "Al-Mafroza" },
                    { 102, 3, "El Montazah" },
                    { 103, 3, "El Mansheya" },
                    { 104, 3, "El Nasserya" },
                    { 105, 3, "Ambroso" },
                    { 106, 3, "Bab Sharq" },
                    { 107, 3, "Burj El Arab" },
                    { 108, 3, "Stanley" },
                    { 109, 3, "Smouha" },
                    { 110, 3, "SIdi Bishr" },
                    { 111, 3, "Shades" },
                    { 112, 3, "Gheit El Enab" },
                    { 113, 3, "Fleming" },
                    { 114, 3, "Victoria" },
                    { 115, 3, "Camp Caesar" },
                    { 116, 3, "Karmouz" },
                    { 117, 3, "Raml Station" },
                    { 118, 3, "Mina El Basal" },
                    { 119, 3, "El Asafir" },
                    { 120, 3, "El Ajami" },
                    { 121, 3, "Bakous" },
                    { 122, 3, "Bolkely" },
                    { 123, 3, "Cleopatra" },
                    { 124, 3, "Gleem" },
                    { 125, 3, "Al-Maamoura" },
                    { 126, 3, "Al-Mandara" },
                    { 127, 3, "Moharram Bek" },
                    { 128, 3, "Al-Shatby" },
                    { 129, 3, "SIdi Gaber" },
                    { 130, 3, "North Coast" },
                    { 131, 3, "Al-Hadra" },
                    { 132, 3, "Al Attarin" },
                    { 133, 3, "SIdi Krir" },
                    { 134, 3, "Al Customs" },
                    { 135, 3, "Al Maks" },
                    { 136, 3, "Marina" },
                    { 137, 4, "Al Mansoura" },
                    { 138, 4, "Talkha" },
                    { 139, 4, "Mit Ghamr" },
                    { 140, 4, "Dakernes" },
                    { 141, 4, "Aja" },
                    { 142, 4, "Minya Al-Nasr" },
                    { 143, 4, "Senbalawin" },
                    { 144, 4, "Al-Kurdi" },
                    { 145, 4, "Bani UbaId" },
                    { 146, 4, "Al-Manzala" },
                    { 147, 4, "Tami Al-Amdeed" },
                    { 148, 4, "Al-Gamaleya" },
                    { 149, 4, "Sherbin" },
                    { 150, 4, "Al-Matariya" },
                    { 151, 4, "Belqas" },
                    { 152, 4, "Mit Salsil" },
                    { 153, 4, "Gamasa" },
                    { 154, 4, "Mahalla Demna" },
                    { 155, 4, "Nabroh" },
                    { 156, 5, "Hurghada" },
                    { 157, 5, "Ras Ghareb" },
                    { 158, 5, "Safaga" },
                    { 159, 5, "Quseir" },
                    { 160, 5, "Marsa Alam" },
                    { 161, 5, "Shalateen" },
                    { 162, 5, "Halaib" },
                    { 163, 5, "Dahar" },
                    { 164, 6, "Damanhour" },
                    { 165, 6, "Kafr El Dawar" },
                    { 166, 6, "RashId" },
                    { 167, 6, "Edko" },
                    { 168, 6, "Abu El Matamir" },
                    { 169, 6, "Abu Homs" },
                    { 170, 6, "Dalingat" },
                    { 171, 6, "Mahmoudia" },
                    { 172, 6, "Al-Rahmaniya" },
                    { 173, 6, "Itay Al-Baroud" },
                    { 174, 6, "Hosh Issa" },
                    { 175, 6, "Shibrakhit" },
                    { 176, 6, "Kom Hamada" },
                    { 177, 6, "Badr" },
                    { 178, 6, "Wadi Al-Natrun" },
                    { 179, 6, "new Nubaria" },
                    { 180, 6, "new Nubaria" },
                    { 181, 7, "Fayoum" },
                    { 182, 7, "new Fayoum" },
                    { 183, 7, "Tamia" },
                    { 184, 7, "Snouris" },
                    { 185, 7, "Etsa" },
                    { 186, 7, "Ebshway" },
                    { 187, 7, "Youssef El-SIddiq" },
                    { 188, 7, "El-Hadiqa" },
                    { 189, 7, "Etsa" },
                    { 190, 7, "El-Gamia" },
                    { 191, 7, "El-Sayala" },
                    { 192, 8, "Tanta" },
                    { 193, 8, "El Mahalla El Kubra" },
                    { 194, 8, "Kafr El Zayat" },
                    { 195, 8, "Zifta" },
                    { 196, 8, "El Santa" },
                    { 197, 8, "Qatour" },
                    { 198, 8, "Basion" },
                    { 199, 8, "Samanoud" },
                    { 200, 9, "Ismailia" },
                    { 201, 9, "Fayed" },
                    { 202, 9, "Qantara East" },
                    { 203, 9, "Qantara West" },
                    { 204, 9, "Tall El-Kebir" },
                    { 205, 9, "Abu Suweir" },
                    { 206, 9, "new Qassasin" },
                    { 207, 9, "Nafisha" },
                    { 208, 9, "Sheikh Zayed" },
                    { 209, 10, "Shibin El Kom" },
                    { 210, 10, "Sadat City" },
                    { 211, 10, "Menouf" },
                    { 212, 10, "Sers El Layyan" },
                    { 213, 10, "Ashmoun" },
                    { 214, 10, "El Bagour" },
                    { 215, 10, "Quweisna" },
                    { 216, 10, "Birket El Sabaa" },
                    { 217, 10, "Tala" },
                    { 218, 10, "Martyrs" },
                    { 219, 11, "Minya" },
                    { 220, 11, "new Minya" },
                    { 221, 11, "Al-Adwa" },
                    { 222, 11, "Maghagha" },
                    { 223, 11, "Beni Mazar" },
                    { 224, 11, "Matai" },
                    { 225, 11, "Samalout" },
                    { 226, 11, "Intellectual City" },
                    { 227, 11, "Malawy" },
                    { 228, 11, "Deir Mawas" },
                    { 229, 11, "Abu Qurqas" },
                    { 230, 11, "Sultan Land" },
                    { 231, 12, "Benha" },
                    { 232, 12, "Qalyub" },
                    { 233, 12, "Shubra El-Kheima" },
                    { 234, 12, "El-Qanater El-Khairiya" },
                    { 235, 12, "Al-Khanka" },
                    { 236, 12, "Kafr Shukr" },
                    { 237, 12, "Toukh" },
                    { 238, 12, "Qaha" },
                    { 239, 12, "Al-Obour" },
                    { 240, 12, "Al-Khosoos" },
                    { 241, 12, "Shibin Al-Qanater" },
                    { 242, 12, "Mostorod" },
                    { 243, 13, "Al Kharga" },
                    { 244, 13, "Paris" },
                    { 245, 13, "Mot" },
                    { 246, 13, "Farafra" },
                    { 247, 13, "Balat" },
                    { 248, 13, "Dakhla" },
                    { 249, 14, "Suez" },
                    { 250, 14, "Al Ganain" },
                    { 251, 14, "Ataka" },
                    { 252, 14, "Ain Sokhna" },
                    { 253, 14, "Faisal" },
                    { 254, 15, "Aswan" },
                    { 255, 15, "new Aswan" },
                    { 256, 15, "Draw" },
                    { 257, 15, "Kom Ombo" },
                    { 258, 15, "Nasr El-Nuba" },
                    { 259, 15, "Klabsha" },
                    { 260, 15, "Edfu" },
                    { 261, 15, "Al-Radisiya" },
                    { 262, 15, "Al-Basilia" },
                    { 263, 15, "Al-Sabaia" },
                    { 264, 15, "Abu Simbel Tourist" },
                    { 265, 15, "Marsa Alam" },
                    { 266, 16, "Assiut" },
                    { 267, 16, "new Assiut" },
                    { 268, 16, "Dayrut" },
                    { 269, 16, "Manfalut" },
                    { 270, 16, "Qousiya" },
                    { 271, 16, "Abnub" },
                    { 272, 16, "Abu Tig" },
                    { 273, 16, "Al-Ghanayem" },
                    { 274, 16, "Sahel Selim" },
                    { 275, 16, "Al-Badari" },
                    { 276, 16, "Sadfa" },
                    { 277, 17, "Beni Suef" },
                    { 278, 17, "new Beni Suef" },
                    { 279, 17, "Al-Wasti" },
                    { 280, 17, "Nasser" },
                    { 281, 17, "Ihnesya" },
                    { 282, 17, "Baba" },
                    { 283, 17, "Al-Fashn" },
                    { 284, 17, "Semsta" },
                    { 285, 17, "Al-Abasiry" },
                    { 286, 17, "Muqbil" },
                    { 287, 18, "Port SaId" },
                    { 288, 18, "Port Fouad" },
                    { 289, 18, "Al-Arab" },
                    { 290, 18, "Al-Zohour District" },
                    { 291, 18, "District East" },
                    { 292, 18, "Al-Dawahi District" },
                    { 293, 18, "Al-Manakh District" },
                    { 294, 18, "Mubarak District" },
                    { 295, 19, "Damietta" },
                    { 296, 19, "new Damietta" },
                    { 297, 19, "Ras El-Bar" },
                    { 298, 19, "Farskur" },
                    { 299, 19, "Al-Zarqa" },
                    { 300, 19, "Sarw" },
                    { 301, 19, "Al Rawda" },
                    { 302, 19, "Kafr El Battikh" },
                    { 303, 19, "Ezbet El Borg" },
                    { 304, 19, "Mit Abu Ghaleb" },
                    { 305, 19, "Kafr Saad" },
                    { 306, 20, "Zagazig" },
                    { 307, 20, "10th of Ramadan" },
                    { 308, 20, "Minya Al Qamh" },
                    { 309, 20, "Belbeis" },
                    { 310, 20, "Mashtoul Al Souq" },
                    { 311, 20, "Al Qanayat" },
                    { 312, 20, "Abu Hammad" },
                    { 313, 20, "Al Qurain" },
                    { 314, 20, "Hehia" },
                    { 315, 20, "Abu Kabir" },
                    { 316, 20, "Faqous" },
                    { 317, 20, "Al Salihiya new" },
                    { 318, 20, "Ibrahimiya" },
                    { 319, 20, "Deirb Najm" },
                    { 320, 20, "Kafr Saqr" },
                    { 321, 20, "Awlad Saqr" },
                    { 322, 20, "Al-Husseiniya" },
                    { 323, 20, "San Al-Hajar Al-Qibliya" },
                    { 324, 20, "Mansha'at Abu Omar" },
                    { 325, 21, "Al-Tur" },
                    { 326, 21, "Sharm El Sheikh" },
                    { 327, 21, "Dahab" },
                    { 328, 21, "Nuweiba" },
                    { 329, 21, "Taba" },
                    { 330, 21, "Saint Catherine" },
                    { 331, 21, "Abu Redis" },
                    { 332, 21, "Abu Zenima" },
                    { 333, 21, "Ras Sudr" },
                    { 334, 22, "Kafr El Sheikh" },
                    { 335, 22, "Downtown Kafr El Sheikh" },
                    { 336, 22, "Desouk" },
                    { 337, 22, "Foh" },
                    { 338, 22, "Matoubas" },
                    { 339, 22, "Burj El Burullus" },
                    { 340, 22, "Baltim" },
                    { 341, 22, "Baltim Summer Resort" },
                    { 342, 22, "El Hamoul" },
                    { 343, 22, "Bella" },
                    { 344, 22, "Riyadh" },
                    { 345, 22, "SIdi Salem" },
                    { 346, 22, "Qaleen" },
                    { 347, 22, "SIdi Ghazi" },
                    { 348, 23, "Marsa Matrouh" },
                    { 349, 23, "Hammam" },
                    { 350, 23, "El Alamein" },
                    { 351, 23, "El Dabaa" },
                    { 352, 23, "El Nagila" },
                    { 353, 23, "SIdi Barani" },
                    { 354, 23, "El Salloum" },
                    { 355, 23, "Siwa" },
                    { 356, 23, "Marina" },
                    { 357, 23, "North Coast" },
                    { 358, 24, "El Luxor" },
                    { 359, 24, "new Luxor" },
                    { 360, 24, "Esna" },
                    { 361, 24, "new Thebes" },
                    { 362, 24, "Al-Zainiya" },
                    { 363, 24, "Al-Bayadiya" },
                    { 364, 24, "Al-Qurna" },
                    { 365, 24, "Arment" },
                    { 366, 24, "Al-Tod" },
                    { 367, 25, "Qena" },
                    { 368, 25, "new Qena" },
                    { 369, 25, "Abu Tasht" },
                    { 370, 25, "Nag Hammadi" },
                    { 371, 25, "Dishna" },
                    { 372, 25, "Al-Waqf" },
                    { 373, 25, "Qift" },
                    { 374, 25, "Naqada" },
                    { 375, 25, "Farshout" },
                    { 376, 25, "Qous" },
                    { 377, 26, "Arish" },
                    { 378, 26, "Sheikh ZuweId" },
                    { 379, 26, "Nakhl" },
                    { 380, 26, "Rafah" },
                    { 381, 26, "Bir al-Abd" },
                    { 382, 26, "al-Hasanah" },
                    { 383, 27, "Sohag" },
                    { 384, 27, "Sohag new" },
                    { 385, 27, "Akhmeem" },
                    { 386, 27, "new Akhmim" },
                    { 387, 27, "Belina" },
                    { 388, 27, "Maragha" },
                    { 389, 27, "Al-Mansha" },
                    { 390, 27, "Dar Al-Salam" },
                    { 391, 27, "Girga" },
                    { 392, 27, "Gharbia Jehena" },
                    { 393, 27, "Saqalta" },
                    { 394, 27, "Tama" },
                    { 395, 27, "Tahta" },
                    { 396, 27, "Al-Kawthar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AreaId",
                table: "AspNetUsers",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
