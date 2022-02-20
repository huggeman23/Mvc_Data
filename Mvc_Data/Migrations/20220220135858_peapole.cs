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
                name: "Language",
                columns: table => new
                {
                    LanguageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageID);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
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
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguage", x => new { x.Id, x.LanguageID });
                    table.ForeignKey(
                        name: "FK_PersonLanguage_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguage_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countery",
                column: "CounteryName",
                value: "USA");

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LanguageID", "LanguageName" },
                values: new object[] { 1, "Engelska" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CounteryName", "Name" },
                values: new object[] { 1, "USA", "Montana" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "CityID", "Name", "Phone" },
                values: new object[] { 1, 1, "Mathiew", 220002298 });

            migrationBuilder.InsertData(
                table: "PersonLanguage",
                columns: new[] { "Id", "LanguageID" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_City_CounteryName",
                table: "City",
                column: "CounteryName");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityID",
                table: "Person",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguage_LanguageID",
                table: "PersonLanguage",
                column: "LanguageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguage");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Countery");
        }
    }
}
