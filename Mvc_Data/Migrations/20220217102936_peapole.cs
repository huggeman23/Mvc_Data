using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc_Data.Migrations
{
    public partial class peapole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countery",
                columns: table => new
                {
                    CounteryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countery", x => x.CounteryName);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CounteryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Countery_CounteryName",
                        column: x => x.CounteryName,
                        principalTable: "Countery",
                        principalColumn: "CounteryName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countery",
                column: "CounteryName",
                value: "USA");

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CounteryName", "Name" },
                values: new object[] { 1, "USA", "Montana" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CityID", "Name", "Phone" },
                values: new object[] { 1, 1, "Mathiew", 220002298 });

            migrationBuilder.CreateIndex(
                name: "IX_City_CounteryName",
                table: "City",
                column: "CounteryName");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityID",
                table: "Persons",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Countery");
        }
    }
}
