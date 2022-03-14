using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwaggerTest.Data.Migrations
{
    public partial class StockEntitiesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Open = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    High = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Low = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Close = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrice", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_StockPrice_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Symbol",
                table: "Stock",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrice_StockId",
                table: "StockPrice",
                column: "StockId")
                .Annotation("SqlServer:Clustered", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockPrice");

            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
