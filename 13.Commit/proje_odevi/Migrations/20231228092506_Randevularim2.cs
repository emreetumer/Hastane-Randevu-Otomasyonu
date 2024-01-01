using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proje_odevi.Migrations
{
    public partial class Randevularim2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RandevuViewModelRandevuId",
                table: "Hekimler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Randevularim",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    klinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecilenDoktorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevularim", x => x.RandevuId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hekimler_RandevuViewModelRandevuId",
                table: "Hekimler",
                column: "RandevuViewModelRandevuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hekimler_Randevularim_RandevuViewModelRandevuId",
                table: "Hekimler",
                column: "RandevuViewModelRandevuId",
                principalTable: "Randevularim",
                principalColumn: "RandevuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hekimler_Randevularim_RandevuViewModelRandevuId",
                table: "Hekimler");

            migrationBuilder.DropTable(
                name: "Randevularim");

            migrationBuilder.DropIndex(
                name: "IX_Hekimler_RandevuViewModelRandevuId",
                table: "Hekimler");

            migrationBuilder.DropColumn(
                name: "RandevuViewModelRandevuId",
                table: "Hekimler");
        }
    }
}
