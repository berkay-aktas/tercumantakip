using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TercumanTakipWeb.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DilListesi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DilListesi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "isTakipListesi_Telefon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosyaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KimlikNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TalepKisi_Birim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfisListesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestekTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaslangicSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    GorusmeSayisi = table.Column<int>(type: "int", nullable: false),
                    EkBilgi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isTakipListesi_Telefon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OfisListesi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfisAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfisListesi", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DilListesi");

            migrationBuilder.DropTable(
                name: "isTakipListesi_Telefon");

            migrationBuilder.DropTable(
                name: "OfisListesi");
        }
    }
}
