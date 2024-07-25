using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TercumanTakipWeb.Migrations
{
    /// <inheritdoc />
    public partial class FinMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AramaBasligi",
                table: "isTakipListesi_TopluArama",
                newName: "ArmaBasligiListesi");

            migrationBuilder.CreateTable(
                name: "AramaBasligiListesi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AramaBasligi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AramaBasligiListesi", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AramaBasligiListesi");

            migrationBuilder.RenameColumn(
                name: "ArmaBasligiListesi",
                table: "isTakipListesi_TopluArama",
                newName: "AramaBasligi");
        }
    }
}
