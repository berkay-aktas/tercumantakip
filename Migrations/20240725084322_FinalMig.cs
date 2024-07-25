using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TercumanTakipWeb.Migrations
{
    /// <inheritdoc />
    public partial class FinalMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArmaBasligiListesi",
                table: "isTakipListesi_TopluArama",
                newName: "AramaBasligiListesi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AramaBasligiListesi",
                table: "isTakipListesi_TopluArama",
                newName: "ArmaBasligiListesi");
        }
    }
}
