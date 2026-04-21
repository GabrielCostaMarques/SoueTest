using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoWorkerService.Migrations
{
    /// <inheritdoc />
    public partial class initalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    MarketCap = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceChangePercetage = table.Column<decimal>(type: "numeric", nullable: false),
                    HighestPrice24h = table.Column<decimal>(type: "numeric", nullable: false),
                    LowestPrice24h = table.Column<decimal>(type: "numeric", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
