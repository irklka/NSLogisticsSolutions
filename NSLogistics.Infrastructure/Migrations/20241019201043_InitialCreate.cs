using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSLogistics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocationName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PortCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IdNumber = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    Salt = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedById = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shipping_prices",
                columns: table => new
                {
                    ShippingPriceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OriginLocationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DestinationLocationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TransitDays = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_prices", x => x.ShippingPriceId);
                    table.ForeignKey(
                        name: "FK_shipping_prices_locations_DestinationLocationId",
                        column: x => x.DestinationLocationId,
                        principalTable: "locations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_shipping_prices_locations_OriginLocationId",
                        column: x => x.OriginLocationId,
                        principalTable: "locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CarBrand = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CarModel = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CarYear = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    AuctionName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    VinCode = table.Column<string>(type: "TEXT", maxLength: 17, nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ContainerNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ShipmentName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AuctionPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ShipmentPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_applications_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageOrigin = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageBytes = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ImageType = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ApplicationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_images_applications_ImageId",
                        column: x => x.ImageId,
                        principalTable: "applications",
                        principalColumn: "ApplicationId");
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedById", "DateOfBirth", "Email", "Firstname", "IdNumber", "IsActive", "IsDeleted", "Lastname", "Password", "Role", "Salt" },
                values: new object[] { new Guid("90241396-04ad-4e49-b917-a2f516a295e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vaja.Kacia@example.com", "Saba", "00000000001", true, false, "Sani-Peradze", "C62D1C801386EDBDB84735BA14E873B007AF19841A5EC0BE22AD34478FD33086", 2, "qzlxcBpNh8pJq5GP1V7OBA==" });

            migrationBuilder.CreateIndex(
                name: "IX_applications_UserId",
                table: "applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_prices_DestinationLocationId",
                table: "shipping_prices",
                column: "DestinationLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_prices_OriginLocationId",
                table: "shipping_prices",
                column: "OriginLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "shipping_prices");

            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
