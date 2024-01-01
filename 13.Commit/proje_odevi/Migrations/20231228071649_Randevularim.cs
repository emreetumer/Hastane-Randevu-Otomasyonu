using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace proje_odevi.Migrations
{
    public partial class Randevularim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Randevular",  // Tablo adını belirtin
                columns: table => new
                {
                    RandevuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Klinik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecilenDoktorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Randevular");
        }
    }
}
