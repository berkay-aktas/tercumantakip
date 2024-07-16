using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TercumanTakipWeb.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GorusmeSayisi",
                table: "isTakipListesi_Telefon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DestekTarihi",
                table: "isTakipListesi_Telefon",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "isTakipListesi_DisGorev",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanisanAdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurumHastaneAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GidisTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    GidisSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    DonusSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    YonlendirenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkBilgi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isTakipListesi_DisGorev", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "isTakipListesi_MigrantTV",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CeviriKonusu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CeviriTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    KelimeSayisi = table.Column<int>(type: "int", nullable: false),
                    SeslendirmeSayisi = table.Column<int>(type: "int", nullable: false),
                    EkBilgi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isTakipListesi_MigrantTV", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "isTakipListesi_TopluArama",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AramaBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfisListesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestekTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    AramaSayisi = table.Column<int>(type: "int", nullable: false),
                    EkBilgi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isTakipListesi_TopluArama", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "isTakipListesi_YaziliCeviri",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CeviriKonusu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CeviriTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    KelimeSayisi = table.Column<int>(type: "int", nullable: false),
                    EkBilgi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isTakipListesi_YaziliCeviri", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "isTakipListesi_Yuzyuze",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosyaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KimlikNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TalepKisi_Birim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfisListesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestekTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    BaslangicSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisSaati = table.Column<TimeSpan>(type: "time", nullable: false),
                    GorusmeSayisi = table.Column<int>(type: "int", nullable: false),
                    EkBilgi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_isTakipListesi_Yuzyuze", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "isTakipListesi_DisGorev");

            migrationBuilder.DropTable(
                name: "isTakipListesi_MigrantTV");

            migrationBuilder.DropTable(
                name: "isTakipListesi_TopluArama");

            migrationBuilder.DropTable(
                name: "isTakipListesi_YaziliCeviri");

            migrationBuilder.DropTable(
                name: "isTakipListesi_Yuzyuze");

            migrationBuilder.AlterColumn<int>(
                name: "GorusmeSayisi",
                table: "isTakipListesi_Telefon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DestekTarihi",
                table: "isTakipListesi_Telefon",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
