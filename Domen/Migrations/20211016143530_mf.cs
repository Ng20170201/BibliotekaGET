using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domen.Migrations
{
    public partial class mf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    ImeIPrezime = table.Column<string>(nullable: true),
                    Passsword = table.Column<string>(nullable: true),
                    TipKorisnika = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    DatumVracanja = table.Column<DateTime>(nullable: false),
                    KorisnikUsername = table.Column<string>(nullable: true),
                    IDKnjige = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Knjiga_IDKnjige",
                        column: x => x.IDKnjige,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_KorisnikUsername",
                        column: x => x.KorisnikUsername,
                        principalTable: "Korisnik",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtev",
                columns: table => new
                {
                    knjigaId = table.Column<int>(nullable: false),
                    usernameKorisnik = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtev", x => new { x.knjigaId, x.usernameKorisnik });
                    table.ForeignKey(
                        name: "FK_Zahtev_Knjiga_knjigaId",
                        column: x => x.knjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zahtev_Korisnik_usernameKorisnik",
                        column: x => x.usernameKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_IDKnjige",
                table: "Rezervacija",
                column: "IDKnjige");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikUsername",
                table: "Rezervacija",
                column: "KorisnikUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtev_usernameKorisnik",
                table: "Zahtev",
                column: "usernameKorisnik");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Zahtev");

            migrationBuilder.DropTable(
                name: "Knjiga");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
