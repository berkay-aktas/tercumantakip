using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TercumanTakipWeb.Migrations
{
    /// <inheritdoc />
    public partial class LastMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GorusmeSayisi",
                table: "isTakipListesi_Yuzyuze",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GorusmeSayisi",
                table: "isTakipListesi_Yuzyuze",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
