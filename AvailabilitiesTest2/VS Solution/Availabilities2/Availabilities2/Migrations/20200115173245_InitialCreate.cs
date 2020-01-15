using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Availabilities2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    BrokerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinnessDate = table.Column<DateTime>(nullable: true),
                    BrokerCode = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Quantity = table.Column<long>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    BrokerSource = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.BrokerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities");
        }
    }
}
