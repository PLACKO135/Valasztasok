using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valasztasok.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_888 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partok",
                columns: table => new
                {
                    Rovid_nev = table.Column<string>(type: "TEXT", nullable: false),
                    Teljes_nev = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partok", x => x.Rovid_nev);
                });

            migrationBuilder.CreateTable(
                name: "Jeloltek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    PartRovid_nev = table.Column<string>(type: "TEXT", nullable: false),
                    Kerulet = table.Column<int>(type: "INTEGER", nullable: false),
                    Szavazatszam = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeloltek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jeloltek_Partok_PartRovid_nev",
                        column: x => x.PartRovid_nev,
                        principalTable: "Partok",
                        principalColumn: "Rovid_nev",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jeloltek_PartRovid_nev",
                table: "Jeloltek",
                column: "PartRovid_nev");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jeloltek");

            migrationBuilder.DropTable(
                name: "Partok");
        }
    }
}
