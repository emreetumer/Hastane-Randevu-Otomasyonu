using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proje_odevi.Migrations
{
    public partial class Randevularim3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SecilenKlinikId",
                table: "Randevularim",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "RandevuViewModelRandevuId",
                table: "Klinikler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klinikler_RandevuViewModelRandevuId",
                table: "Klinikler",
                column: "RandevuViewModelRandevuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klinikler_Randevularim_RandevuViewModelRandevuId",
                table: "Klinikler",
                column: "RandevuViewModelRandevuId",
                principalTable: "Randevularim",
                principalColumn: "RandevuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klinikler_Randevularim_RandevuViewModelRandevuId",
                table: "Klinikler");

            migrationBuilder.DropIndex(
                name: "IX_Klinikler_RandevuViewModelRandevuId",
                table: "Klinikler");

            migrationBuilder.DropColumn(
                name: "SecilenKlinikId",
                table: "Randevularim");

            migrationBuilder.DropColumn(
                name: "RandevuViewModelRandevuId",
                table: "Klinikler");
        }
    }
}
